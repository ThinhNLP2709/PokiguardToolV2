namespace UnityEngine.Rendering;

public static class CoreUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Assembly, IEnumerable`1<Type>> <>9__97_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal IEnumerable<Type> <GetAllAssemblyTypes>b__97_0(Assembly t) { }

	}

	[CompilerGenerated]
	private sealed class <>c__98
	{
		public static readonly <>c__98<T> <>9; //Field offset: 0x0
		public static Func<Type, Boolean> <>9__98_0; //Field offset: 0x0

		private static <>c__98`1() { }

		public <>c__98`1() { }

		internal bool <GetAllTypesDerivedFrom>b__98_0(Type t) { }

	}

	internal static class Priorities
	{
		public const int assetsCreateShaderMenuPriority = 83; //Field offset: 0x0
		public const int assetsCreateRenderingMenuPriority = 308; //Field offset: 0x0
		public const int editMenuPriority = 320; //Field offset: 0x0
		public const int gameObjectMenuPriority = 10; //Field offset: 0x0
		public const int srpLensFlareMenuPriority = 303; //Field offset: 0x0

	}

	internal static class Sections
	{
		public const int section1 = 10000; //Field offset: 0x0
		public const int section2 = 20000; //Field offset: 0x0
		public const int section3 = 30000; //Field offset: 0x0
		public const int section4 = 40000; //Field offset: 0x0
		public const int section5 = 50000; //Field offset: 0x0
		public const int section6 = 60000; //Field offset: 0x0
		public const int section7 = 70000; //Field offset: 0x0
		public const int section8 = 80000; //Field offset: 0x0

	}

	public static readonly Vector3[] lookAtList; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int gameObjectMenuPriority = 10; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int assetCreateMenuPriority2 = 241; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int assetCreateMenuPriority1 = 230; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int editMenuPriority4 = 353; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int assetCreateMenuPriority3 = 300; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int editMenuPriority2 = 331; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int editMenuPriority1 = 320; //Field offset: 0x0
	private const string obsoletePriorityMessage = "Use CoreUtils.Priorities instead"; //Field offset: 0x0
	[Obsolete("Use CoreUtils.Priorities instead", False)]
	public const int editMenuPriority3 = 342; //Field offset: 0x0
	public static readonly Vector3[] upVectorList; //Field offset: 0x8
	private static Cubemap m_BlackCubeTexture; //Field offset: 0x10
	private static Cubemap m_MagentaCubeTexture; //Field offset: 0x18
	private static CubemapArray m_MagentaCubeTextureArray; //Field offset: 0x20
	private static Cubemap m_WhiteCubeTexture; //Field offset: 0x28
	private static RenderTexture m_EmptyUAV; //Field offset: 0x30
	private static GraphicsBuffer m_EmptyBuffer; //Field offset: 0x38
	private static Texture3D m_BlackVolumeTexture; //Field offset: 0x40
	internal static Texture3D m_WhiteVolumeTexture; //Field offset: 0x48
	private static IEnumerable<Type> m_AssemblyTypes; //Field offset: 0x50

	public static Cubemap blackCubeTexture
	{
		 get { } //Length: 480
	}

	public static Texture3D blackVolumeTexture
	{
		 get { } //Length: 462
	}

	public static GraphicsBuffer emptyBuffer
	{
		 get { } //Length: 317
	}

	public static RenderTexture emptyUAV
	{
		 get { } //Length: 369
	}

	public static Cubemap magentaCubeTexture
	{
		 get { } //Length: 480
	}

	public static CubemapArray magentaCubeTextureArray
	{
		 get { } //Length: 549
	}

	public static Cubemap whiteCubeTexture
	{
		 get { } //Length: 480
	}

	internal static Texture3D whiteVolumeTexture
	{
		internal get { } //Length: 462
	}

	private static CoreUtils() { }

	public static bool AreAnimatedMaterialsEnabled(Camera camera) { }

	public static bool ArePostProcessesEnabled(Camera camera) { }

	public static Vector3[] CalculateViewSpaceCorners(Matrix4x4 proj, float z) { }

	public static void ClearCubemap(CommandBuffer cmd, RenderTexture renderTexture, Color clearColor, bool clearMips = false) { }

	public static void ClearRenderTarget(CommandBuffer cmd, ClearFlag clearFlag, Color clearColor) { }

	public static Color ConvertLinearToActiveColorSpace(Color color) { }

	public static Color ConvertSRGBToActiveColorSpace(Color color) { }

	public static Mesh CreateCubeMesh(Vector3 min, Vector3 max) { }

	public static Material CreateEngineMaterial(Shader shader) { }

	public static Material CreateEngineMaterial(string shaderPath) { }

	public static void Destroy(object obj) { }

	public static int DivRoundUp(int value, int divisor) { }

	public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawFullScreen(RasterCommandBuffer commandBuffer, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0) { }

	public static void DrawRendererList(ScriptableRenderContext renderContext, CommandBuffer cmd, RendererList rendererList) { }

	private static int FixupDepthSlice(int depthSlice, RTHandle buffer) { }

	private static int FixupDepthSlice(int depthSlice, CubemapFace cubemapFace) { }

	public static Cubemap get_blackCubeTexture() { }

	public static Texture3D get_blackVolumeTexture() { }

	public static GraphicsBuffer get_emptyBuffer() { }

	public static RenderTexture get_emptyUAV() { }

	public static Cubemap get_magentaCubeTexture() { }

	public static CubemapArray get_magentaCubeTextureArray() { }

	public static Cubemap get_whiteCubeTexture() { }

	internal static Texture3D get_whiteVolumeTexture() { }

	public static IEnumerable<Type> GetAllAssemblyTypes() { }

	public static IEnumerable<Type> GetAllTypesDerivedFrom() { }

	internal static string GetCorePath() { }

	public static T GetLastEnumValue() { }

	public static int GetMipCount(float size) { }

	public static int GetMipCount(int size) { }

	public static string GetRenderTargetAutoName(int width, int height, int depth, RenderTextureFormat format, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = 1) { }

	private static string GetRenderTargetAutoName(int width, int height, int depth, string format, TextureDimension dim, string name, bool mips, bool enableMSAA, MSAASamples msaaSamples, bool dynamicRes, bool dynamicResExplicit) { }

	public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, TextureDimension dim, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = 1, bool dynamicRes = false, bool dynamicResExplicit = false) { }

	public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = 1) { }

	public static string GetTextureAutoName(int width, int height, GraphicsFormat format, TextureDimension dim = 0, string name = "", bool mips = false, int depth = 0) { }

	private static string GetTextureAutoName(int width, int height, string format, TextureDimension dim = 0, string name = "", bool mips = false, int depth = 0) { }

	public static string GetTextureAutoName(int width, int height, TextureFormat format, TextureDimension dim = 0, string name = "", bool mips = false, int depth = 0) { }

	public static int GetTextureHash(Texture texture) { }

	public static bool HasFlag(T mask, T flag) { }

	public static bool IsLightOverlapDebugEnabled(Camera camera) { }

	public static bool IsSceneFilteringEnabled() { }

	public static bool IsSceneLightingDisabled(Camera camera) { }

	public static bool IsSceneViewFogEnabled(Camera camera) { }

	public static bool IsSceneViewPrefabStageContextHidden() { }

	public static int PreviousPowerOfTwo(int size) { }

	public static void SafeRelease(ComputeBuffer buffer) { }

	public static void SafeRelease(GraphicsBuffer buffer) { }

	public static void SetKeyword(ComputeShader cs, string keyword, bool state) { }

	public static void SetKeyword(Material material, LocalKeyword keyword, bool state) { }

	public static void SetKeyword(Material material, string keyword, bool state) { }

	public static void SetKeyword(BaseCommandBuffer cmd, string keyword, bool state) { }

	public static void SetKeyword(CommandBuffer cmd, ComputeShader cs, string keyword, bool state) { }

	public static void SetKeyword(CommandBuffer cmd, string keyword, bool state) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag = 0, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag = 0, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RTHandle depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag = 0) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag = 0) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, int miplevel = 0, CubemapFace cubemapFace = -1, int depthSlice = -1) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor) { }

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor) { }

	public static void SetViewport(CommandBuffer cmd, RTHandle target) { }

	private static void SetViewportAndClear(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor) { }

	public static void Swap(ref T a, ref T b) { }

}

