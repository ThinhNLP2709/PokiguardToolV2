namespace UnityEngine.Rendering.Universal;

public sealed class UniversalRenderPipeline : RenderPipeline
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<Camera> <>9__47_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__124_0(Light[] requests, NativeArray<LightDataGI> lightsOutput) { }

		internal int <.ctor>b__47_0(Camera camera1, Camera camera2) { }

	}

	public static class CameraMetadataCache
	{
		internal class CameraMetadataCacheEntry
		{
			public string name; //Field offset: 0x10
			public ProfilingSampler sampler; //Field offset: 0x18

			public CameraMetadataCacheEntry() { }

		}

		private static Dictionary<Int32, CameraMetadataCacheEntry> s_MetadataCache; //Field offset: 0x0
		private static readonly CameraMetadataCacheEntry k_NoAllocEntry; //Field offset: 0x8

		private static CameraMetadataCache() { }

		public static CameraMetadataCacheEntry GetCached(Camera camera) { }

	}

	[IsReadOnly]
	private struct CameraRenderingScope : IDisposable
	{
		private static readonly ProfilingSampler beginCameraRenderingSampler; //Field offset: 0x0
		private static readonly ProfilingSampler endCameraRenderingSampler; //Field offset: 0x8
		private readonly ScriptableRenderContext m_Context; //Field offset: 0x0
		private readonly Camera m_Camera; //Field offset: 0x8

		private static CameraRenderingScope() { }

		public CameraRenderingScope(ScriptableRenderContext context, Camera camera) { }

		public override void Dispose() { }

	}

	[IsReadOnly]
	private struct ContextRenderingScope : IDisposable
	{
		private static readonly ProfilingSampler beginContextRenderingSampler; //Field offset: 0x0
		private static readonly ProfilingSampler endContextRenderingSampler; //Field offset: 0x8
		private readonly ScriptableRenderContext m_Context; //Field offset: 0x0
		private readonly List<Camera> m_Cameras; //Field offset: 0x8

		private static ContextRenderingScope() { }

		public ContextRenderingScope(ScriptableRenderContext context, List<Camera> cameras) { }

		public override void Dispose() { }

	}

	public static class Profiling
	{
		internal static class Pipeline
		{
			internal static class Context
			{
				private const string k_Name = "ScriptableRenderContext"; //Field offset: 0x0
				public static readonly ProfilingSampler submit; //Field offset: 0x0

				private static Context() { }

			}

			internal static class Renderer
			{
				private const string k_Name = "ScriptableRenderer"; //Field offset: 0x0
				public static readonly ProfilingSampler setupCullingParameters; //Field offset: 0x0
				public static readonly ProfilingSampler setup; //Field offset: 0x8

				private static Renderer() { }

			}

			private const string k_Name = "UniversalRenderPipeline"; //Field offset: 0x0
			public static readonly ProfilingSampler initializeCameraData; //Field offset: 0x0
			public static readonly ProfilingSampler initializeStackedCameraData; //Field offset: 0x8
			public static readonly ProfilingSampler initializeAdditionalCameraData; //Field offset: 0x10
			public static readonly ProfilingSampler initializeRenderingData; //Field offset: 0x18
			public static readonly ProfilingSampler initializeShadowData; //Field offset: 0x20
			public static readonly ProfilingSampler initializeLightData; //Field offset: 0x28
			public static readonly ProfilingSampler buildAdditionalLightsShadowAtlasLayout; //Field offset: 0x30
			public static readonly ProfilingSampler getPerObjectLightFlags; //Field offset: 0x38
			public static readonly ProfilingSampler getMainLightIndex; //Field offset: 0x40
			public static readonly ProfilingSampler setupPerFrameShaderConstants; //Field offset: 0x48
			public static readonly ProfilingSampler setupPerCameraShaderConstants; //Field offset: 0x50

			private static Pipeline() { }

		}


	}

	internal class SingleCameraRequest
	{
		public RenderTexture destination; //Field offset: 0x10
		public int mipLevel; //Field offset: 0x18
		public CubemapFace face; //Field offset: 0x1C
		public int slice; //Field offset: 0x20

		public SingleCameraRequest() { }

	}

	public const string k_ShaderTagName = "UniversalPipeline"; //Field offset: 0x0
	internal const int k_DefaultRenderingLayerMask = 1; //Field offset: 0x0
	internal static bool cameraStackRequiresDepthForPostprocessing; //Field offset: 0x0
	internal static RenderGraph s_RenderGraph; //Field offset: 0x8
	internal static RTHandleResourcePool s_RTHandlePool; //Field offset: 0x10
	internal static bool useRenderGraph; //Field offset: 0x18
	[CompilerGenerated]
	private static bool <canOptimizeScreenMSAASamples>k__BackingField; //Field offset: 0x19
	[CompilerGenerated]
	private static int <startFrameScreenMSAASamples>k__BackingField; //Field offset: 0x1C
	private static Vector4 k_DefaultLightPosition; //Field offset: 0x20
	private static Vector4 k_DefaultLightColor; //Field offset: 0x30
	private static Vector4 k_DefaultLightAttenuation; //Field offset: 0x40
	private static Vector4 k_DefaultLightSpotDirection; //Field offset: 0x50
	private static Vector4 k_DefaultLightsProbeChannel; //Field offset: 0x60
	private static List<Vector4> m_ShadowBiasData; //Field offset: 0x70
	private static List<Int32> m_ShadowResolutionData; //Field offset: 0x78
	private static RequestLightsDelegate lightsDelegate; //Field offset: 0x80
	private readonly DebugDisplaySettingsUI m_DebugDisplaySettingsUI; //Field offset: 0x18
	private UniversalRenderPipelineGlobalSettings m_GlobalSettings; //Field offset: 0x20
	[CompilerGenerated]
	private UniversalRenderPipelineRuntimeTextures <runtimeTextures>k__BackingField; //Field offset: 0x28
	internal bool apvIsEnabled; //Field offset: 0x30
	private readonly UniversalRenderPipelineAsset pipelineAsset; //Field offset: 0x38
	internal bool enableHDROnce; //Field offset: 0x40
	private Comparison<Camera> cameraComparison; //Field offset: 0x48

	public static UniversalRenderPipelineAsset asset
	{
		 get { } //Length: 147
	}

	internal static bool canOptimizeScreenMSAASamples
	{
		[CompilerGenerated]
		internal get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	public virtual RenderPipelineGlobalSettings defaultSettings
	{
		 get { } //Length: 5
	}

	internal static int lightsPerTile
	{
		internal get { } //Length: 77
	}

	public static int maxNumIterationsEnclosingSphere
	{
		 get { } //Length: 6
	}

	public static int maxPerObjectLights
	{
		 get { } //Length: 6
	}

	public static float maxRenderScale
	{
		 get { } //Length: 9
	}

	public static float maxShadowBias
	{
		 get { } //Length: 9
	}

	internal static int maxTileWords
	{
		internal get { } //Length: 83
	}

	public static int maxVisibleAdditionalLights
	{
		 get { } //Length: 253
	}

	internal static int maxVisibleReflectionProbes
	{
		internal get { } //Length: 117
	}

	internal static int maxZBinWords
	{
		internal get { } //Length: 6
	}

	public static float minRenderScale
	{
		 get { } //Length: 9
	}

	internal UniversalRenderPipelineRuntimeTextures runtimeTextures
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal static int startFrameScreenMSAASamples
	{
		[CompilerGenerated]
		internal get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 83
	}

	private static UniversalRenderPipeline() { }

	public UniversalRenderPipeline(UniversalRenderPipelineAsset asset) { }

	private static void AdjustUIOverlayOwnership(int cameraCount) { }

	private static void ApplyAdaptivePerformance(ContextContainer frameData) { }

	private static void ApplyAdaptivePerformance(UniversalCameraData cameraData) { }

	private static void ApplyTaaRenderingDebugOverrides(ref Settings taaSettings) { }

	private static AdditionalLightsShadowAtlasLayout BuildAdditionalLightsShadowAtlasLayout(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData) { }

	private static void CheckAndApplyDebugSettings(ref RenderingData renderingData) { }

	private static bool CheckPostProcessForDepth() { }

	private static bool CheckPostProcessForDepth(UniversalCameraData cameraData) { }

	private static UniversalCameraData CreateCameraData(ContextContainer frameData, Camera camera, UniversalAdditionalCameraData additionalCameraData, bool resolveFinalTarget) { }

	private static UniversalLightData CreateLightData(ContextContainer frameData, UniversalRenderPipelineAsset settings, NativeArray<VisibleLight> visibleLights) { }

	private static UniversalPostProcessingData CreatePostProcessingData(ContextContainer frameData, UniversalRenderPipelineAsset settings) { }

	private static UniversalRenderingData CreateRenderingData(ContextContainer frameData, UniversalRenderPipelineAsset settings, CommandBuffer cmd, bool isForwardPlus, ScriptableRenderer renderer) { }

	internal static RenderTextureDescriptor CreateRenderTextureDescriptor(Camera camera, UniversalCameraData cameraData, bool isHdrEnabled, HDRColorBufferPrecision requestHDRColorBufferPrecision, int msaaSamples, bool needsAlpha, bool requiresOpaqueTexture) { }

	private static void CreateShadowAtlasAndCullShadowCasters(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData, ref CullingResults cullResults, ref ScriptableRenderContext context) { }

	private static UniversalShadowData CreateShadowData(ContextContainer frameData, UniversalRenderPipelineAsset urpAsset, bool isForwardPlus) { }

	private static UniversalResourceData CreateUniversalResourceData(ContextContainer frameData) { }

	protected virtual void Dispose(bool disposing) { }

	private void DisposeAdditionalCameraData() { }

	public static UniversalRenderPipelineAsset get_asset() { }

	[CompilerGenerated]
	internal static bool get_canOptimizeScreenMSAASamples() { }

	public virtual RenderPipelineGlobalSettings get_defaultSettings() { }

	internal static int get_lightsPerTile() { }

	public static int get_maxNumIterationsEnclosingSphere() { }

	public static int get_maxPerObjectLights() { }

	public static float get_maxRenderScale() { }

	public static float get_maxShadowBias() { }

	internal static int get_maxTileWords() { }

	public static int get_maxVisibleAdditionalLights() { }

	internal static int get_maxVisibleReflectionProbes() { }

	internal static int get_maxZBinWords() { }

	public static float get_minRenderScale() { }

	[CompilerGenerated]
	internal UniversalRenderPipelineRuntimeTextures get_runtimeTextures() { }

	[CompilerGenerated]
	internal static int get_startFrameScreenMSAASamples() { }

	internal static void GetHDROutputGradingParameters(Tonemapping tonemapping, out Vector4 hdrOutputParameters) { }

	internal static void GetHDROutputLuminanceParameters(HDRDisplayInformation hdrDisplayInformation, ColorGamut hdrDisplayColorGamut, Tonemapping tonemapping, out Vector4 hdrOutputParameters) { }

	public static void GetLightAttenuationAndSpotDirection(LightType lightType, float lightRange, Matrix4x4 lightLocalToWorldMatrix, float spotAngle, Nullable<Single> innerSpotAngle, out Vector4 lightAttenuation, out Vector4 lightSpotDir) { }

	private static Vector3 GetMainLightCascadeSplit(int mainLightShadowCascadesCount, UniversalRenderPipelineAsset urpAsset) { }

	private static int GetMainLightIndex(UniversalRenderPipelineAsset settings, NativeArray<VisibleLight> visibleLights) { }

	private static PerObjectData GetPerObjectLightFlags(int additionalLightsCount, bool isForwardPlus, bool reflectionProbeBlending) { }

	internal static void GetPunctualLightDistanceAttenuation(float lightRange, ref Vector4 lightAttenuation) { }

	private static ScriptableRenderer GetRenderer(Camera camera, UniversalAdditionalCameraData additionalCameraData) { }

	internal static void GetSpotAngleAttenuation(float spotAngle, Nullable<Single> innerSpotAngle, ref Vector4 lightAttenuation) { }

	internal static void GetSpotDirection(ref Matrix4x4 lightLocalToWorldMatrix, out Vector4 lightSpotDir) { }

	internal static bool HDROutputForAnyDisplayIsActive() { }

	internal static bool HDROutputForMainDisplayIsActive() { }

	private static void InitializeAdditionalCameraData(Camera camera, UniversalAdditionalCameraData additionalCameraData, bool resolveFinalTarget, UniversalCameraData cameraData) { }

	public static void InitializeLightConstants_Common(NativeArray<VisibleLight> lights, int lightIndex, out Vector4 lightPos, out Vector4 lightColor, out Vector4 lightAttenuation, out Vector4 lightSpotDir, out Vector4 lightOcclusionProbeChannel) { }

	private static void InitializeMainLightShadowResolution(UniversalShadowData shadowData) { }

	private static void InitializeStackedCameraData(Camera baseCamera, UniversalAdditionalCameraData baseAdditionalCameraData, UniversalCameraData cameraData) { }

	public static bool IsGameCamera(Camera camera) { }

	protected virtual bool IsRenderRequestSupported(Camera camera, RequestData data) { }

	internal static GraphicsFormat MakeRenderTextureGraphicsFormat(bool isHdrEnabled, HDRColorBufferPrecision requestHDRColorBufferPrecision, bool needsAlpha) { }

	internal static GraphicsFormat MakeUnormRenderTextureGraphicsFormat() { }

	protected virtual void ProcessRenderRequests(ScriptableRenderContext context, Camera camera, RequestData renderRequest) { }

	private static void RecordAndExecuteRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context, ScriptableRenderer renderer, CommandBuffer cmd, Camera camera, string cameraName) { }

	private static void RecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context, ScriptableRenderer renderer) { }

	protected virtual void Render(ScriptableRenderContext renderContext, List<Camera> cameras) { }

	protected virtual void Render(ScriptableRenderContext renderContext, Camera[] cameras) { }

	private static void RenderCameraStack(ScriptableRenderContext context, Camera baseCamera) { }

	private static void RenderSingleCamera(ScriptableRenderContext context, UniversalCameraData cameraData) { }

	[Obsolete("RenderSingleCamera is obsolete, please use RenderPipeline.SubmitRenderRequest with UniversalRenderer.SingleCameraRequest as RequestData type")]
	public static void RenderSingleCamera(ScriptableRenderContext context, Camera camera) { }

	internal static void RenderSingleCameraInternal(ScriptableRenderContext context, Camera camera) { }

	internal static void RenderSingleCameraInternal(ScriptableRenderContext context, Camera camera, ref UniversalAdditionalCameraData additionalCameraData) { }

	private static ImageUpscalingFilter ResolveUpscalingFilterSelection(Vector2 imageSize, float renderScale, UpscalingFilterSelection selection, bool enableRenderGraph) { }

	[CompilerGenerated]
	private static void set_canOptimizeScreenMSAASamples(bool value) { }

	[CompilerGenerated]
	private void set_runtimeTextures(UniversalRenderPipelineRuntimeTextures value) { }

	[CompilerGenerated]
	private static void set_startFrameScreenMSAASamples(int value) { }

	private void SetHDRState(List<Camera> cameras) { }

	private static void SetSupportedRenderingFeatures(UniversalRenderPipelineAsset pipelineAsset) { }

	private static void SetupPerCameraShaderConstants(CommandBuffer cmd) { }

	private void SetupPerFrameShaderConstants() { }

	private static void SetupScreenMSAASamplesState(int cameraCount) { }

	private void SortCameras(List<Camera> cameras) { }

	public virtual string ToString() { }

	private static bool TryGetCullingParameters(UniversalCameraData cameraData, out ScriptableCullingParameters cullingParams) { }

	private static void UpdateCameraData(UniversalCameraData baseCameraData, in XRPass xr) { }

	private static void UpdateCameraStereoMatrices(Camera camera, XRPass xr) { }

	private static void UpdateTemporalAAData(UniversalCameraData cameraData, UniversalAdditionalCameraData additionalCameraData) { }

	private static void UpdateTemporalAATargets(UniversalCameraData cameraData) { }

	private static void UpdateVolumeFramework(Camera camera, UniversalAdditionalCameraData additionalCameraData) { }

}

