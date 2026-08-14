namespace UnityEngine.Rendering;

public class DynamicResolutionHandler
{
	private struct ScalerContainer
	{
		public DynamicResScalePolicyType type; //Field offset: 0x0
		public PerformDynamicRes method; //Field offset: 0x8

	}

	internal enum UpsamplerScheduleType
	{
		BeforePost = 0,
		AfterDepthOfField = 1,
		AfterPost = 2,
	}

	private const int CameraDictionaryMaxcCapacity = 32; //Field offset: 0x0
	private static DynamicResScalerSlot s_ActiveScalerSlot; //Field offset: 0x0
	private static ScalerContainer[] s_ScalerContainers; //Field offset: 0x8
	private static Dictionary<Int32, DynamicResUpscaleFilter> s_CameraUpscaleFilters; //Field offset: 0x10
	private static Dictionary<Int32, DynamicResolutionHandler> s_CameraInstances; //Field offset: 0x18
	private static DynamicResolutionHandler s_DefaultInstance; //Field offset: 0x20
	private static int s_ActiveCameraId; //Field offset: 0x28
	private static DynamicResolutionHandler s_ActiveInstance; //Field offset: 0x30
	private static bool s_ActiveInstanceDirty; //Field offset: 0x38
	private static float s_GlobalHwFraction; //Field offset: 0x3C
	private static bool s_GlobalHwUpresActive; //Field offset: 0x40
	private bool m_Enabled; //Field offset: 0x10
	private bool m_UseMipBias; //Field offset: 0x11
	private float m_MinScreenFraction; //Field offset: 0x14
	private float m_MaxScreenFraction; //Field offset: 0x18
	private float m_CurrentFraction; //Field offset: 0x1C
	private bool m_ForcingRes; //Field offset: 0x20
	private bool m_CurrentCameraRequest; //Field offset: 0x21
	private float m_PrevFraction; //Field offset: 0x24
	private bool m_ForceSoftwareFallback; //Field offset: 0x28
	private bool m_RunUpscalerFilterOnFullResolution; //Field offset: 0x29
	private float m_PrevHWScaleWidth; //Field offset: 0x2C
	private float m_PrevHWScaleHeight; //Field offset: 0x30
	private Vector2Int m_LastScaledSize; //Field offset: 0x34
	private Vector2Int cachedOriginalSize; //Field offset: 0x3C
	[CompilerGenerated]
	private DynamicResUpscaleFilter <filter>k__BackingField; //Field offset: 0x44
	[CompilerGenerated]
	private Vector2Int <finalViewport>k__BackingField; //Field offset: 0x48
	private DynamicResolutionType type; //Field offset: 0x50
	private GlobalDynamicResolutionSettings m_CachedSettings; //Field offset: 0x58
	private WeakReference m_OwnerCameraWeakRef; //Field offset: 0xC8
	private UpsamplerScheduleType m_UpsamplerSchedule; //Field offset: 0xD0

	public private DynamicResUpscaleFilter filter
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public Vector2Int finalViewport
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 5
	}

	public bool forcingResolution
	{
		 get { } //Length: 5
	}

	public static DynamicResolutionHandler instance
	{
		 get { } //Length: 79
	}

	public bool runUpscalerFilterOnFullResolution
	{
		 get { } //Length: 17
		 set { } //Length: 4
	}

	public UpsamplerScheduleType upsamplerSchedule
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	private static DynamicResolutionHandler() { }

	private DynamicResolutionHandler() { }

	public Vector2Int ApplyScalesOnSize(Vector2Int size) { }

	internal Vector2Int ApplyScalesOnSize(Vector2Int size, Vector2 scales) { }

	public float CalculateMipBias(Vector2Int inputResolution, Vector2Int outputResolution, bool forceApply = false) { }

	public static void ClearSelectedCamera() { }

	private static float DefaultDynamicResMethod() { }

	public bool DynamicResolutionEnabled() { }

	private bool FlushScalableBufferManagerState() { }

	public void ForceSoftwareFallback() { }

	[CompilerGenerated]
	public DynamicResUpscaleFilter get_filter() { }

	[CompilerGenerated]
	public Vector2Int get_finalViewport() { }

	public bool get_forcingResolution() { }

	public static DynamicResolutionHandler get_instance() { }

	public bool get_runUpscalerFilterOnFullResolution() { }

	public UpsamplerScheduleType get_upsamplerSchedule() { }

	public float GetCurrentScale() { }

	public Vector2Int GetLastScaledSize() { }

	public float GetLowResMultiplier(float targetLowRes, float minimumThreshold) { }

	public float GetLowResMultiplier(float targetLowRes) { }

	private static DynamicResolutionHandler GetOrCreateDrsInstanceHandler(Camera camera) { }

	public Vector2 GetResolvedScale() { }

	public Vector2Int GetScaledSize(Vector2Int size) { }

	public bool HardwareDynamicResIsEnabled() { }

	private void ProcessSettings(GlobalDynamicResolutionSettings settings) { }

	public bool RequestsHardwareDynamicResolution() { }

	private void Reset() { }

	[CompilerGenerated]
	private void set_filter(DynamicResUpscaleFilter value) { }

	[CompilerGenerated]
	public void set_finalViewport(Vector2Int value) { }

	public void set_runUpscalerFilterOnFullResolution(bool value) { }

	public void set_upsamplerSchedule(UpsamplerScheduleType value) { }

	public static void SetActiveDynamicScalerSlot(DynamicResScalerSlot slot) { }

	public void SetCurrentCameraRequest(bool cameraRequest) { }

	public static void SetDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = 1) { }

	public static void SetSystemDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = 1) { }

	public static void SetUpscaleFilter(Camera camera, DynamicResUpscaleFilter filter) { }

	public bool SoftwareDynamicResIsEnabled() { }

	public void Update(GlobalDynamicResolutionSettings settings, Action OnResolutionChange = null) { }

	public static void UpdateAndUseCamera(Camera camera, Nullable<GlobalDynamicResolutionSettings> settings = null, Action OnResolutionChange = null) { }

}

