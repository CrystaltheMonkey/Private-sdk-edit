#if VRC_ENABLE_PROPS

namespace VRC.SDKBase.Validation
{
    // ReSharper disable once PartialTypeWithSinglePart
    public static partial class PropValidation
    {
        public static readonly string[] ComponentTypeWhiteListCommon = {
            "UnityEngine.Light",
            "UnityEngine.BoxCollider",
            "UnityEngine.SphereCollider",
            "UnityEngine.CapsuleCollider",
            "UnityEngine.MeshCollider",
            "UnityEngine.Rigidbody",
            "UnityEngine.Joint",
            "UnityEngine.AudioSource",
            #if !VRC_CLIENT
            "VRC.Core.PipelineSaver",
            #endif
            "VRC.Core.PipelineManager",
            "UnityEngine.Transform",
            "UnityEngine.Animator",
            "UnityEngine.SkinnedMeshRenderer",
            "UnityEngine.MeshFilter",
            "UnityEngine.MeshRenderer",
            "UnityEngine.ParticleSystem",
            "UnityEngine.ParticleSystemRenderer",
            "UnityEngine.TrailRenderer",
            "UnityEngine.LineRenderer",
            #region UI Items
            "UnityEngine.CanvasRenderer",
            "UnityEngine.Canvas",
            "UnityEngine.UI.CanvasScaler",
            "TMPro.TextMeshProUGUI",
            "TMPro.TMP_Dropdown",
            "TMPro.TMP_InputField",
            "TMPro.TMP_ScrollbarEventHandler",
            "TMPro.TMP_SelectionCaret",
            "TMPro.TMP_SpriteAnimator",
            "TMPro.TMP_SubMesh",
            "TMPro.TMP_SubMeshUI",
            "TMPro.TMP_Text",
            "TMPro.TextMeshPro",
            "TMPro.TextMeshProUGUI",
            "TMPro.TextContainer",
            "TMPro.TMP_Dropdown+DropdownItem",
            "UnityEngine.UI.Button",
            "UnityEngine.UI.Dropdown",
            "UnityEngine.UI.Dropdown+DropdownItem",
            "UnityEngine.UI.Graphic",
            "UnityEngine.UI.GraphicRaycaster",
            "UnityEngine.UI.Image",
            "UnityEngine.UI.InputField",
            "UnityEngine.UI.Mask",
            "UnityEngine.UI.MaskableGraphic",
            "UnityEngine.UI.RawImage",
            "UnityEngine.UI.RectMask2D",
            "UnityEngine.UI.Scrollbar",
            "UnityEngine.UI.ScrollRect",
            "UnityEngine.UI.Selectable",
            "UnityEngine.UI.Slider",
            "UnityEngine.UI.Text",
            "UnityEngine.UI.Toggle",
            "UnityEngine.UI.ToggleGroup",
            "UnityEngine.UI.AspectRatioFitter",
            "UnityEngine.UI.CanvasScaler",
            "UnityEngine.UI.ContentSizeFitter",
            "UnityEngine.UI.GridLayoutGroup",
            "UnityEngine.UI.HorizontalLayoutGroup",
            "UnityEngine.UI.HorizontalOrVerticalLayoutGroup",
            "UnityEngine.UI.LayoutElement",
            "UnityEngine.UI.LayoutGroup",
            "UnityEngine.UI.VerticalLayoutGroup",
            "UnityEngine.UI.BaseMeshEffect",
            "UnityEngine.UI.Outline",
            "UnityEngine.UI.PositionAsUV1",
            "UnityEngine.UI.Shadow",
            #endregion
        };

        public static readonly string[] ComponentTypeWhiteListSdk3 = {
            "VRC.SDK3.VRCTestMarker",
            "VRC.SDK3.Components.VRCPickup",
            "VRC.SDK3.Components.VRCObjectSync",
            "VRC.SDK3.Components.VRCStation",
            "VRC.SDK3.Components.VRCSpatialAudioSource",
            "VRC.SDK3.Props.Components.VRCPropDescriptor",
            "VRC.Udon.UdonBehaviour",
            "VRC.Udon.AbstractUdonBehaviourEventProxy",
            "VRC.SDK3.Components.VRCUiShape",

            // TODO: Props and Worlds don't initialize Dynamics properly yet.
            // "VRC.SDK3.Dynamics.PhysBone.Components.VRCPhysBone",
            // "VRC.SDK3.Dynamics.PhysBone.Components.VRCPhysBoneCollider",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCAimConstraint",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCLookAtConstraint",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCParentConstraint",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCPositionConstraint",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCRotationConstraint",
            // "VRC.SDK3.Dynamics.Constraint.Components.VRCScaleConstraint",
            // "VRC.SDK3.Dynamics.Contact.Components.VRCContactSender",
            // "VRC.SDK3.Dynamics.Contact.Components.VRCContactReceiver",
        };
    }
}
#endif
