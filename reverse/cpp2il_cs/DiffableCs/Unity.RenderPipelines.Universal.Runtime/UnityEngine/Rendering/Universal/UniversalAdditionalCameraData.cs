namespace UnityEngine.Rendering.Universal;

[DisallowMultipleComponent]
[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class UniversalAdditionalCameraData : MonoBehaviour, ISerializationCallbackReceiver, IAdditionalData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Camera> <>9__53_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <UpdateCameraStack>b__53_0(Camera cam) { }

	}

	private const string k_GizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/"; //Field offset: 0x0
	private const string k_PostProcessingGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_PostProcessing.png"; //Field offset: 0x0
	private static UniversalAdditionalCameraData s_DefaultAdditionalCameraData; //Field offset: 0x0
	private const string k_BaseCameraGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_Base.png"; //Field offset: 0x0
	private const string k_OverlayCameraGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_Base.png"; //Field offset: 0x0
	private static List<VolumeStack> s_CachedVolumeStacks; //Field offset: 0x8
	[FormerlySerializedAs("renderShadows")]
	[SerializeField]
	private bool m_RenderShadows; //Field offset: 0x20
	[SerializeField]
	private CameraOverrideOption m_RequiresDepthTextureOption; //Field offset: 0x24
	[SerializeField]
	private CameraOverrideOption m_RequiresOpaqueTextureOption; //Field offset: 0x28
	[SerializeField]
	private CameraRenderType m_CameraType; //Field offset: 0x2C
	[SerializeField]
	private List<Camera> m_Cameras; //Field offset: 0x30
	[SerializeField]
	private int m_RendererIndex; //Field offset: 0x38
	[SerializeField]
	private LayerMask m_VolumeLayerMask; //Field offset: 0x3C
	[SerializeField]
	private Transform m_VolumeTrigger; //Field offset: 0x40
	[SerializeField]
	private VolumeFrameworkUpdateMode m_VolumeFrameworkUpdateModeOption; //Field offset: 0x48
	[SerializeField]
	private bool m_RenderPostProcessing; //Field offset: 0x4C
	[SerializeField]
	private AntialiasingMode m_Antialiasing; //Field offset: 0x50
	[SerializeField]
	private AntialiasingQuality m_AntialiasingQuality; //Field offset: 0x54
	[SerializeField]
	private bool m_StopNaN; //Field offset: 0x58
	[SerializeField]
	private bool m_Dithering; //Field offset: 0x59
	[SerializeField]
	private bool m_ClearDepth; //Field offset: 0x5A
	[SerializeField]
	private bool m_AllowXRRendering; //Field offset: 0x5B
	[SerializeField]
	private bool m_AllowHDROutput; //Field offset: 0x5C
	[SerializeField]
	private bool m_UseScreenCoordOverride; //Field offset: 0x5D
	[SerializeField]
	private Vector4 m_ScreenSizeOverride; //Field offset: 0x60
	[SerializeField]
	private Vector4 m_ScreenCoordScaleBias; //Field offset: 0x70
	private Camera m_Camera; //Field offset: 0x80
	[FormerlySerializedAs("requiresDepthTexture")]
	[SerializeField]
	private bool m_RequiresDepthTexture; //Field offset: 0x88
	[FormerlySerializedAs("requiresColorTexture")]
	[SerializeField]
	private bool m_RequiresColorTexture; //Field offset: 0x89
	[HideInInspector]
	[SerializeField]
	private float m_Version; //Field offset: 0x8C
	private MotionVectorsPersistentData m_MotionVectorsPersistentData; //Field offset: 0x90
	internal UniversalCameraHistory m_History; //Field offset: 0x98
	[SerializeField]
	internal Settings m_TaaSettings; //Field offset: 0xA0
	private VolumeStack m_VolumeStack; //Field offset: 0xC0

	public bool allowHDROutput
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool allowXRRendering
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public AntialiasingMode antialiasing
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public AntialiasingQuality antialiasingQuality
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	internal Camera camera
	{
		internal get { } //Length: 155
	}

	public List<Camera> cameraStack
	{
		 get { } //Length: 365
	}

	public bool clearDepth
	{
		 get { } //Length: 5
	}

	internal static UniversalAdditionalCameraData defaultAdditionalCameraData
	{
		internal get { } //Length: 540
	}

	public bool dithering
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public ICameraHistoryReadAccess history
	{
		 get { } //Length: 8
	}

	internal UniversalCameraHistory historyManager
	{
		internal get { } //Length: 8
	}

	internal MotionVectorsPersistentData motionVectorsPersistentData
	{
		internal get { } //Length: 8
	}

	public bool renderPostProcessing
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool renderShadows
	{
		 get { } //Length: 5
		 set { } //Length: 1011
	}

	public CameraRenderType renderType
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public CameraOverrideOption requiresColorOption
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool requiresColorTexture
	{
		 get { } //Length: 104
		 set { } //Length: 25
	}

	public CameraOverrideOption requiresDepthOption
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool requiresDepthTexture
	{
		 get { } //Length: 104
		 set { } //Length: 25
	}

	public bool requiresVolumeFrameworkUpdate
	{
		 get { } //Length: 110
	}

	public bool resetHistory
	{
		 get { } //Length: 11
		 set { } //Length: 63
	}

	public Vector4 screenCoordScaleBias
	{
		 get { } //Length: 11
		 set { } //Length: 8
	}

	public Vector4 screenSizeOverride
	{
		 get { } //Length: 11
		 set { } //Length: 8
	}

	public ScriptableRenderer scriptableRenderer
	{
		 get { } //Length: 730
	}

	public bool stopNaN
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public Settings taaSettings
	{
		 get { } //Length: 8
	}

	public bool useScreenCoordOverride
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public float version
	{
		 get { } //Length: 9
	}

	internal VolumeFrameworkUpdateMode volumeFrameworkUpdateMode
	{
		internal get { } //Length: 4
		internal set { } //Length: 4
	}

	public LayerMask volumeLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public VolumeStack volumeStack
	{
		 get { } //Length: 8
		 set { } //Length: 383
	}

	public Transform volumeTrigger
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public UniversalAdditionalCameraData() { }

	public bool get_allowHDROutput() { }

	public bool get_allowXRRendering() { }

	public AntialiasingMode get_antialiasing() { }

	public AntialiasingQuality get_antialiasingQuality() { }

	internal Camera get_camera() { }

	public List<Camera> get_cameraStack() { }

	public bool get_clearDepth() { }

	internal static UniversalAdditionalCameraData get_defaultAdditionalCameraData() { }

	public bool get_dithering() { }

	public ICameraHistoryReadAccess get_history() { }

	internal UniversalCameraHistory get_historyManager() { }

	internal MotionVectorsPersistentData get_motionVectorsPersistentData() { }

	public bool get_renderPostProcessing() { }

	public bool get_renderShadows() { }

	public CameraRenderType get_renderType() { }

	public CameraOverrideOption get_requiresColorOption() { }

	public bool get_requiresColorTexture() { }

	public CameraOverrideOption get_requiresDepthOption() { }

	public bool get_requiresDepthTexture() { }

	public bool get_requiresVolumeFrameworkUpdate() { }

	public bool get_resetHistory() { }

	public Vector4 get_screenCoordScaleBias() { }

	public Vector4 get_screenSizeOverride() { }

	public ScriptableRenderer get_scriptableRenderer() { }

	public bool get_stopNaN() { }

	public Settings get_taaSettings() { }

	public bool get_useScreenCoordOverride() { }

	public float get_version() { }

	internal VolumeFrameworkUpdateMode get_volumeFrameworkUpdateMode() { }

	public LayerMask get_volumeLayerMask() { }

	public VolumeStack get_volumeStack() { }

	public Transform get_volumeTrigger() { }

	internal void GetOrCreateVolumeStack() { }

	private ScriptableRenderer GetRawRenderer() { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	public void OnDestroy() { }

	public void OnDrawGizmos() { }

	public void OnValidate() { }

	public void set_allowHDROutput(bool value) { }

	public void set_allowXRRendering(bool value) { }

	public void set_antialiasing(AntialiasingMode value) { }

	public void set_antialiasingQuality(AntialiasingQuality value) { }

	public void set_dithering(bool value) { }

	public void set_renderPostProcessing(bool value) { }

	public void set_renderShadows(bool value) { }

	public void set_renderType(CameraRenderType value) { }

	public void set_requiresColorOption(CameraOverrideOption value) { }

	public void set_requiresColorTexture(bool value) { }

	public void set_requiresDepthOption(CameraOverrideOption value) { }

	public void set_requiresDepthTexture(bool value) { }

	public void set_resetHistory(bool value) { }

	public void set_screenCoordScaleBias(Vector4 value) { }

	public void set_screenSizeOverride(Vector4 value) { }

	public void set_stopNaN(bool value) { }

	public void set_useScreenCoordOverride(bool value) { }

	internal void set_volumeFrameworkUpdateMode(VolumeFrameworkUpdateMode value) { }

	public void set_volumeLayerMask(LayerMask value) { }

	public void set_volumeStack(VolumeStack value) { }

	public void set_volumeTrigger(Transform value) { }

	public void SetRenderer(int index) { }

	private void Start() { }

	internal void UpdateCameraStack() { }

}

