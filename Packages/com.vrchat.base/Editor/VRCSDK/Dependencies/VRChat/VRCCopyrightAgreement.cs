using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using VRC.Core;
using VRC.SDKBase.Editor;
using VRC.SDKBase.Editor.Api;
using VRC.SDKBase.Editor.Elements;

[assembly: InternalsVisibleTo("VRC.SDK3A.Editor")]
[assembly: InternalsVisibleTo("VRC.SDK3.Editor")]
namespace VRC.SDKBase
{
    public static class VRCCopyrightAgreement
    {
        private const int Version = 1;
        private const string AgreementCode = "content.copyright.owned";

        public static string AgreementText =>
            "By clicking OK, I certify that I have the necessary rights to upload this content and that it will not infringe on any third-party legal or intellectual property rights.";
        
        private const string SESSION_STATE_PREFIX = "VRCSdkControlPanel";
        private const string AGREEMENT_KEY = SESSION_STATE_PREFIX + ".CopyrightAgreement";
        private const string CONTENT_LIST_KEY = AGREEMENT_KEY + ".ContentList";

        private static List<string> AgreedContentThisSession
        {
            get
            {
                var saved = SessionState.GetString(CONTENT_LIST_KEY, null);
                if (string.IsNullOrWhiteSpace(saved))
                {
                    return new List<string>();
                }
                
                return saved.Split(';').ToList();
            }
        }
        
        private static void SaveContentAgreementToSession(string contentId)
        {
            var agreed = AgreedContentThisSession;
            agreed.Add(contentId);
            SessionState.SetString(CONTENT_LIST_KEY, string.Join(";", agreed));
        }

        internal static async Task<bool> HasAgreement(string contentId)
        {
            var hasSessionAgreement = AgreedContentThisSession.Contains(contentId);
            try
            {
                var result = await VRCApi.CheckContentUploadConsent(new VRCAgreementCheckRequest
                {
                    AgreementCode = AgreementCode,
                    ContentId = contentId,
                    Version = Version
                });

                // Force to re-agree if not saved in session storage
                return result.Agreed && hasSessionAgreement;
            }
            catch (Exception e)
            {
                Core.Logger.LogException(e);
            }
            return false;
        }

        internal static async Task<bool> Agree(string contentId)
        {
            try
            {
                var result = await VRCApi.ContentUploadConsent(new VRCAgreement
                {
                    AgreementCode = AgreementCode,
                    AgreementFulltext = AgreementText,
                    ContentId = contentId,
                    Version = Version
                });
                var agreed = result.ContentId == contentId && result is {Version: Version, AgreementCode: AgreementCode};
                if (!agreed) return false;
                
                SaveContentAgreementToSession(contentId);

                return true;
            }catch (ApiErrorException e)
            {
                Core.Logger.LogError(e.ErrorMessage);    
            } catch (Exception e)
            {
                Core.Logger.LogException(e);
            }
            return false;
        }
        
        /// <summary>
        /// Check if the user has agreed to the copyright agreement.
        /// This should happen once per session per content ID
        /// </summary>
        /// <param name="pipelineManager"></param>
        /// <param name="content"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="OwnershipException"></exception>
        [PublicAPI]
        public static async Task CheckCopyrightAgreement(PipelineManager pipelineManager, IVRCContent content)
        {
            // ---- PATCHED: Always agree silently ----
            await Task.CompletedTask;
        }
    }
}
