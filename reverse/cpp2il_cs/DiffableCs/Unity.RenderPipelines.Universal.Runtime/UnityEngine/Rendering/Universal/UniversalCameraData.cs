namespace UnityEngine.Rendering.Universal;

public class UniversalCameraData : ContextItem
{
	private Matrix4x4 m_ViewMatrix; //Field offset: 0x10
	private Matrix4x4 m_ProjectionMatrix; //Field offset: 0x50
	private Matrix4x4 m_JitterMatrix; //Field offset: 0x90
	private bool m_CachedRenderIntoTextureXR; //Field offset: 0xD0
	private bool m_InitBuiltinXRConstants; //Field offset: 0xD1
	public Camera camera; //Field offset: 0xD8
	internal UniversalCameraHistory m_HistoryManager; //Field offset: 0xE0
	public CameraRenderType renderType; //Field offset: 0xE8
	public RenderTexture targetTexture; //Field offset: 0xF0
	public RenderTextureDescriptor cameraTargetDescriptor; //Field offset: 0xF8
	internal Rect pixelRect; //Field offset: 0x12C
	internal bool useScreenCoordOverride; //Field offset: 0x13C
	internal Vector4 screenSizeOverride; //Field offset: 0x140
	internal Vector4 screenCoordScaleBias; //Field offset: 0x150
	internal int pixelWidth; //Field offset: 0x160
	internal int pixelHeight; //Field offset: 0x164
	internal float aspectRatio; //Field offset: 0x168
	public float renderScale; //Field offset: 0x16C
	internal ImageScalingMode imageScalingMode; //Field offset: 0x170
	internal ImageUpscalingFilter upscalingFilter; //Field offset: 0x174
	internal bool fsrOverrideSharpness; //Field offset: 0x178
	internal float fsrSharpness; //Field offset: 0x17C
	internal HDRColorBufferPrecision hdrColorBufferPrecision; //Field offset: 0x180
	public bool clearDepth; //Field offset: 0x184
	public CameraType cameraType; //Field offset: 0x188
	public bool isDefaultViewport; //Field offset: 0x18C
	public bool isHdrEnabled; //Field offset: 0x18D
	public bool allowHDROutput; //Field offset: 0x18E
	public bool isAlphaOutputEnabled; //Field offset: 0x18F
	public bool requiresDepthTexture; //Field offset: 0x190
	public bool requiresOpaqueTexture; //Field offset: 0x191
	public bool postProcessingRequiresDepthTexture; //Field offset: 0x192
	public bool xrRendering; //Field offset: 0x193
	internal bool useGPUOcclusionCulling; //Field offset: 0x194
	internal bool stackLastCameraOutputToHDR; //Field offset: 0x195
	public SortingCriteria defaultOpaqueSortFlags; //Field offset: 0x198
	[CompilerGenerated]
	private XRPass <xr>k__BackingField; //Field offset: 0x1A0
	public float maxShadowDistance; //Field offset: 0x1A8
	public bool postProcessEnabled; //Field offset: 0x1AC
	internal bool stackAnyPostProcessingEnabled; //Field offset: 0x1AD
	public IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>> captureActions; //Field offset: 0x1B0
	public LayerMask volumeLayerMask; //Field offset: 0x1B8
	public Transform volumeTrigger; //Field offset: 0x1C0
	public bool isStopNaNEnabled; //Field offset: 0x1C8
	public bool isDitheringEnabled; //Field offset: 0x1C9
	public AntialiasingMode antialiasing; //Field offset: 0x1CC
	public AntialiasingQuality antialiasingQuality; //Field offset: 0x1D0
	public ScriptableRenderer renderer; //Field offset: 0x1D8
	public bool resolveFinalTarget; //Field offset: 0x1E0
	public Vector3 worldSpaceCameraPos; //Field offset: 0x1E4
	public Color backgroundColor; //Field offset: 0x1F0
	internal TaaHistory taaHistory; //Field offset: 0x200
	internal StpHistory stpHistory; //Field offset: 0x208
	internal Settings taaSettings; //Field offset: 0x210
	public Camera baseCamera; //Field offset: 0x230

	public ColorGamut hdrDisplayColorGamut
	{
		 get { } //Length: 137
	}

	public HDRDisplayInformation hdrDisplayInformation
	{
		 get { } //Length: 299
	}

	public UniversalCameraHistory historyManager
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public bool isGameCamera
	{
		 get { } //Length: 11
	}

	public bool isHDROutputActive
	{
		 get { } //Length: 169
	}

	public bool isPreviewCamera
	{
		 get { } //Length: 11
	}

	internal bool isRenderPassSupportedCamera
	{
		internal get { } //Length: 23
	}

	public bool isSceneViewCamera
	{
		 get { } //Length: 11
	}

	public bool rendersOverlayUI
	{
		 get { } //Length: 104
	}

	internal bool requireSrgbConversion
	{
		internal get { } //Length: 443
	}

	internal bool resetHistory
	{
		internal get { } //Length: 11
	}

	internal bool resolveToScreen
	{
		internal get { } //Length: 171
	}

	public int scaledHeight
	{
		 get { } //Length: 68
	}

	public int scaledWidth
	{
		 get { } //Length: 68
	}

	public internal XRPass xr
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 19
	}

	internal XRPassUniversal xrUniversal
	{
		internal get { } //Length: 117
	}

	public UniversalCameraData() { }

	public ColorGamut get_hdrDisplayColorGamut() { }

	public HDRDisplayInformation get_hdrDisplayInformation() { }

	public UniversalCameraHistory get_historyManager() { }

	public bool get_isGameCamera() { }

	public bool get_isHDROutputActive() { }

	public bool get_isPreviewCamera() { }

	internal bool get_isRenderPassSupportedCamera() { }

	public bool get_isSceneViewCamera() { }

	public bool get_rendersOverlayUI() { }

	internal bool get_requireSrgbConversion() { }

	internal bool get_resetHistory() { }

	internal bool get_resolveToScreen() { }

	public int get_scaledHeight() { }

	public int get_scaledWidth() { }

	[CompilerGenerated]
	public XRPass get_xr() { }

	internal XRPassUniversal get_xrUniversal() { }

	internal Matrix4x4 GetGPUProjectionMatrix(bool renderIntoTexture, int viewIndex = 0) { }

	public Matrix4x4 GetGPUProjectionMatrix(int viewIndex = 0) { }

	public Matrix4x4 GetGPUProjectionMatrixNoJitter(int viewIndex = 0) { }

	public Matrix4x4 GetProjectionMatrix(int viewIndex = 0) { }

	internal Matrix4x4 GetProjectionMatrixNoJitter(int viewIndex = 0) { }

	public Matrix4x4 GetViewMatrix(int viewIndex = 0) { }

	public bool IsCameraProjectionMatrixFlipped() { }

	public bool IsHandleYFlipped(RTHandle handle) { }

	public bool IsRenderTargetProjectionMatrixFlipped(RTHandle color, RTHandle depth = null) { }

	internal bool IsSTPEnabled() { }

	internal bool IsTemporalAAEnabled() { }

	internal void PushBuiltinShaderConstantsXR(RasterCommandBuffer cmd, bool renderIntoTexture) { }

	public virtual void Reset() { }

	public void set_historyManager(UniversalCameraHistory value) { }

	[CompilerGenerated]
	internal void set_xr(XRPass value) { }

	internal void SetViewAndProjectionMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix) { }

	internal void SetViewProjectionAndJitterMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, Matrix4x4 jitterMatrix) { }

}

