namespace UnityEngine.Rendering;

public static class RTHandles
{
	private static RTHandleSystem s_DefaultInstance; //Field offset: 0x0

	public static int maxHeight
	{
		 get { } //Length: 91
	}

	public static int maxWidth
	{
		 get { } //Length: 91
	}

	public static RTHandleProperties rtHandleProperties
	{
		 get { } //Length: 120
	}

	private static RTHandles() { }

	private static RTHandle Alloc(RTHandle tex) { }

	public static RTHandle Alloc(RenderTargetIdentifier tex, string name) { }

	public static RTHandle Alloc(RenderTargetIdentifier tex) { }

	public static RTHandle Alloc(RenderTexture tex, bool transferOwnership = false) { }

	public static RTHandle Alloc(Texture tex) { }

	public static RTHandle Alloc(ScaleFunc scaleFunc, RTHandleAllocInfo info) { }

	public static RTHandle Alloc(ScaleFunc scaleFunc, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public static RTHandle Alloc(ScaleFunc scaleFunc, GraphicsFormat format, int slices = 1, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(Vector2 scaleFactor, RTHandleAllocInfo info) { }

	public static RTHandle Alloc(Vector2 scaleFactor, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public static RTHandle Alloc(Vector2 scaleFactor, GraphicsFormat format, int slices = 1, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(ScaleFunc scaleFunc, int slices = 1, DepthBits depthBufferBits = 0, GraphicsFormat colorFormat = 4, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public static RTHandle Alloc(int width, int height, RTHandleAllocInfo info) { }

	public static RTHandle Alloc(int width, int height, TextureWrapMode wrapModeU, TextureWrapMode wrapModeV, TextureWrapMode wrapModeW = 0, int slices = 1, DepthBits depthBufferBits = 0, GraphicsFormat colorFormat = 4, FilterMode filterMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(int width, int height, GraphicsFormat format, int slices = 1, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(int width, int height, int slices = 1, DepthBits depthBufferBits = 0, GraphicsFormat colorFormat = 4, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static RTHandle Alloc(Vector2 scaleFactor, int slices = 1, DepthBits depthBufferBits = 0, GraphicsFormat colorFormat = 4, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, TextureDimension dimension = 2, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, MSAASamples msaaSamples = 1, bool bindTextureMS = false, bool useDynamicScale = false, bool useDynamicScaleExplicit = false, RenderTextureMemoryless memoryless = 0, VRTextureUsage vrUsage = 0, string name = "") { }

	public static Vector2Int CalculateDimensions(ScaleFunc scaleFunc) { }

	public static Vector2Int CalculateDimensions(Vector2 scaleFactor) { }

	public static Vector2 CalculateRatioAgainstMaxSize(int width, int height) { }

	public static int get_maxHeight() { }

	public static int get_maxWidth() { }

	public static RTHandleProperties get_rtHandleProperties() { }

	internal static GraphicsFormat GetFormat(GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat) { }

	[Obsolete("useLegacyDynamicResControl is deprecated. Please use SetHardwareDynamicResolutionState() instead.")]
	public static void Initialize(int width, int height, bool useLegacyDynamicResControl = false) { }

	public static void Initialize(int width, int height) { }

	public static void Release(RTHandle rth) { }

	public static void ResetReferenceSize(int width, int height) { }

	public static void SetHardwareDynamicResolutionState(bool hwDynamicResRequested) { }

	public static void SetReferenceSize(int width, int height) { }

}

