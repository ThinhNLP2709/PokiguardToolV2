namespace UnityEngine.Rendering.Universal;

public struct CameraData
{
	private ContextContainer frameData; //Field offset: 0x0

	public bool allowHDROutput
	{
		 get { } //Length: 79
	}

	public AntialiasingMode antialiasing
	{
		 get { } //Length: 79
	}

	public AntialiasingQuality antialiasingQuality
	{
		 get { } //Length: 79
	}

	internal float aspectRatio
	{
		internal get { } //Length: 79
	}

	public Color backgroundColor
	{
		 get { } //Length: 79
	}

	public Camera baseCamera
	{
		 get { } //Length: 79
	}

	public Camera camera
	{
		 get { } //Length: 79
	}

	public RenderTextureDescriptor cameraTargetDescriptor
	{
		 get { } //Length: 79
	}

	public CameraType cameraType
	{
		 get { } //Length: 79
	}

	public IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>>& captureActions
	{
		 get { } //Length: 79
	}

	public bool clearDepth
	{
		 get { } //Length: 79
	}

	public SortingCriteria defaultOpaqueSortFlags
	{
		 get { } //Length: 79
	}

	internal bool fsrOverrideSharpness
	{
		internal get { } //Length: 79
	}

	internal float fsrSharpness
	{
		internal get { } //Length: 79
	}

	internal HDRColorBufferPrecision hdrColorBufferPrecision
	{
		internal get { } //Length: 79
	}

	public ColorGamut hdrDisplayColorGamut
	{
		 get { } //Length: 82
	}

	public HDRDisplayInformation hdrDisplayInformation
	{
		 get { } //Length: 110
	}

	public UniversalCameraHistory historyManager
	{
		 get { } //Length: 79
	}

	internal ImageScalingMode imageScalingMode
	{
		internal get { } //Length: 79
	}

	public bool isAlphaOutputEnabled
	{
		 get { } //Length: 79
	}

	public bool isDefaultViewport
	{
		 get { } //Length: 79
	}

	public bool isDitheringEnabled
	{
		 get { } //Length: 79
	}

	public bool isHdrEnabled
	{
		 get { } //Length: 79
	}

	public bool isHDROutputActive
	{
		 get { } //Length: 82
	}

	public bool isPreviewCamera
	{
		 get { } //Length: 82
	}

	internal bool isRenderPassSupportedCamera
	{
		internal get { } //Length: 82
	}

	public bool isSceneViewCamera
	{
		 get { } //Length: 82
	}

	public bool isStopNaNEnabled
	{
		 get { } //Length: 79
	}

	public float maxShadowDistance
	{
		 get { } //Length: 79
	}

	internal int pixelHeight
	{
		internal get { } //Length: 79
	}

	internal Rect pixelRect
	{
		internal get { } //Length: 79
	}

	internal int pixelWidth
	{
		internal get { } //Length: 79
	}

	public bool postProcessEnabled
	{
		 get { } //Length: 79
	}

	public bool postProcessingRequiresDepthTexture
	{
		 get { } //Length: 79
	}

	public ScriptableRenderer renderer
	{
		 get { } //Length: 79
	}

	public float renderScale
	{
		 get { } //Length: 79
	}

	public bool rendersOverlayUI
	{
		 get { } //Length: 82
	}

	public CameraRenderType renderType
	{
		 get { } //Length: 79
	}

	public bool requiresDepthTexture
	{
		 get { } //Length: 79
	}

	public bool requiresOpaqueTexture
	{
		 get { } //Length: 79
	}

	internal bool requireSrgbConversion
	{
		internal get { } //Length: 82
	}

	internal bool resetHistory
	{
		internal get { } //Length: 82
	}

	public bool resolveFinalTarget
	{
		 get { } //Length: 79
	}

	internal bool resolveToScreen
	{
		internal get { } //Length: 82
	}

	internal Vector4 screenCoordScaleBias
	{
		internal get { } //Length: 79
	}

	internal Vector4 screenSizeOverride
	{
		internal get { } //Length: 79
	}

	internal TaaHistory taaHistory
	{
		internal get { } //Length: 79
	}

	internal Settings taaSettings
	{
		internal get { } //Length: 79
	}

	public RenderTexture targetTexture
	{
		 get { } //Length: 79
	}

	internal UniversalCameraData universalCameraData
	{
		internal get { } //Length: 67
	}

	internal ImageUpscalingFilter upscalingFilter
	{
		internal get { } //Length: 79
	}

	internal bool useScreenCoordOverride
	{
		internal get { } //Length: 79
	}

	public LayerMask volumeLayerMask
	{
		 get { } //Length: 79
	}

	public Transform volumeTrigger
	{
		 get { } //Length: 79
	}

	public Vector3 worldSpaceCameraPos
	{
		 get { } //Length: 79
	}

	public internal XRPass xr
	{
		 get { } //Length: 80
		internal set { } //Length: 106
	}

	public bool xrRendering
	{
		 get { } //Length: 79
	}

	internal XRPassUniversal xrUniversal
	{
		internal get { } //Length: 82
	}

	internal CameraData(ContextContainer frameData) { }

	public bool get_allowHDROutput() { }

	public AntialiasingMode get_antialiasing() { }

	public AntialiasingQuality get_antialiasingQuality() { }

	internal float get_aspectRatio() { }

	public Color get_backgroundColor() { }

	public Camera get_baseCamera() { }

	public Camera get_camera() { }

	public RenderTextureDescriptor get_cameraTargetDescriptor() { }

	public CameraType get_cameraType() { }

	public IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>>& get_captureActions() { }

	public bool get_clearDepth() { }

	public SortingCriteria get_defaultOpaqueSortFlags() { }

	internal bool get_fsrOverrideSharpness() { }

	internal float get_fsrSharpness() { }

	internal HDRColorBufferPrecision get_hdrColorBufferPrecision() { }

	public ColorGamut get_hdrDisplayColorGamut() { }

	public HDRDisplayInformation get_hdrDisplayInformation() { }

	public UniversalCameraHistory get_historyManager() { }

	internal ImageScalingMode get_imageScalingMode() { }

	public bool get_isAlphaOutputEnabled() { }

	public bool get_isDefaultViewport() { }

	public bool get_isDitheringEnabled() { }

	public bool get_isHdrEnabled() { }

	public bool get_isHDROutputActive() { }

	public bool get_isPreviewCamera() { }

	internal bool get_isRenderPassSupportedCamera() { }

	public bool get_isSceneViewCamera() { }

	public bool get_isStopNaNEnabled() { }

	public float get_maxShadowDistance() { }

	internal int get_pixelHeight() { }

	internal Rect get_pixelRect() { }

	internal int get_pixelWidth() { }

	public bool get_postProcessEnabled() { }

	public bool get_postProcessingRequiresDepthTexture() { }

	public ScriptableRenderer get_renderer() { }

	public float get_renderScale() { }

	public bool get_rendersOverlayUI() { }

	public CameraRenderType get_renderType() { }

	public bool get_requiresDepthTexture() { }

	public bool get_requiresOpaqueTexture() { }

	internal bool get_requireSrgbConversion() { }

	internal bool get_resetHistory() { }

	public bool get_resolveFinalTarget() { }

	internal bool get_resolveToScreen() { }

	internal Vector4 get_screenCoordScaleBias() { }

	internal Vector4 get_screenSizeOverride() { }

	internal TaaHistory get_taaHistory() { }

	internal Settings get_taaSettings() { }

	public RenderTexture get_targetTexture() { }

	internal UniversalCameraData get_universalCameraData() { }

	internal ImageUpscalingFilter get_upscalingFilter() { }

	internal bool get_useScreenCoordOverride() { }

	public LayerMask get_volumeLayerMask() { }

	public Transform get_volumeTrigger() { }

	public Vector3 get_worldSpaceCameraPos() { }

	public XRPass get_xr() { }

	public bool get_xrRendering() { }

	internal XRPassUniversal get_xrUniversal() { }

	internal Matrix4x4 GetGPUProjectionMatrix(bool renderIntoTexture, int viewIndex = 0) { }

	public Matrix4x4 GetGPUProjectionMatrix(int viewIndex = 0) { }

	public Matrix4x4 GetGPUProjectionMatrixNoJitter(int viewIndex = 0) { }

	public Matrix4x4 GetProjectionMatrix(int viewIndex = 0) { }

	internal Matrix4x4 GetProjectionMatrixNoJitter(int viewIndex = 0) { }

	public Matrix4x4 GetViewMatrix(int viewIndex = 0) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public bool IsCameraProjectionMatrixFlipped() { }

	public bool IsHandleYFlipped(RTHandle handle) { }

	public bool IsRenderTargetProjectionMatrixFlipped(RTHandle color, RTHandle depth = null) { }

	internal bool IsTemporalAAEnabled() { }

	internal void PushBuiltinShaderConstantsXR(RasterCommandBuffer cmd, bool renderIntoTexture) { }

	internal void set_xr(XRPass value) { }

	internal void SetViewAndProjectionMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix) { }

	internal void SetViewProjectionAndJitterMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, Matrix4x4 jitterMatrix) { }

}

