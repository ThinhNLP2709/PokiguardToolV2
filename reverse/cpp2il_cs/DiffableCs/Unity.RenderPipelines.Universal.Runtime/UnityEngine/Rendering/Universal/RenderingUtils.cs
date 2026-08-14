namespace UnityEngine.Rendering.Universal;

public static class RenderingUtils
{
	private static List<ShaderTagId> m_LegacyShaderPassNames; //Field offset: 0x0
	private static AttachmentDescriptor s_EmptyAttachment; //Field offset: 0x8
	private static Mesh s_FullscreenMesh; //Field offset: 0x80
	private static Material s_ErrorMaterial; //Field offset: 0x88
	private static ShaderTagId[] s_ShaderTagValues; //Field offset: 0x90
	private static RenderStateBlock[] s_RenderStateBlocks; //Field offset: 0x98
	private static Dictionary<RenderTextureFormat, Boolean> m_RenderTextureFormatSupport; //Field offset: 0xA0

	internal static AttachmentDescriptor emptyAttachment
	{
		internal get { } //Length: 149
	}

	private static Material errorMaterial
	{
		private get { } //Length: 336
	}

	[Obsolete("Use Blitter.BlitCameraTexture instead of CommandBuffer.DrawMesh(fullscreenMesh, ...)")]
	public static Mesh fullscreenMesh
	{
		 get { } //Length: 1420
	}

	internal static bool useStructuredBuffer
	{
		internal get { } //Length: 3
	}

	private static RenderingUtils() { }

	internal static void AddStaleResourceToPoolOrRelease(TextureDesc desc, RTHandle handle) { }

	internal static void Blit(CommandBuffer cmd, RTHandle source, Rect viewport, RTHandle destinationColor, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RTHandle destinationDepthStencil, RenderBufferLoadAction depthStencilLoadAction, RenderBufferStoreAction depthStencilStoreAction, ClearFlag clearFlag, Color clearColor, Material material, int passIndex = 0) { }

	internal static void Blit(CommandBuffer cmd, RTHandle source, Rect viewport, RTHandle destination, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, Material material, int passIndex = 0) { }

	internal static void ClearSystemInfoCache() { }

	internal static bool Contains(ClearFlag a, ClearFlag b) { }

	internal static bool Contains(RenderTargetIdentifier[] source, RenderTargetIdentifier value) { }

	internal static uint CountDistinct(RTHandle[] source, RTHandle value) { }

	public static DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, ref RenderingData renderingData, SortingCriteria sortingCriteria) { }

	public static DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, ref RenderingData renderingData, SortingCriteria sortingCriteria) { }

	public static DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria) { }

	public static DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal static void CreateRendererListObjectsWithError(ScriptableRenderContext context, ref CullingResults cullResults, Camera camera, FilteringSettings filterSettings, SortingCriteria sortFlags, ref RendererList rl) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal static void CreateRendererListObjectsWithError(RenderGraph renderGraph, ref CullingResults cullResults, Camera camera, FilteringSettings filterSettings, SortingCriteria sortFlags, ref RendererListHandle rl) { }

	internal static void CreateRendererListWithRenderStateBlock(RenderGraph renderGraph, ref CullingResults cullResults, DrawingSettings ds, FilteringSettings fs, RenderStateBlock rsb, ref RendererListHandle rl) { }

	internal static void CreateRendererListWithRenderStateBlock(ScriptableRenderContext context, ref CullingResults cullResults, DrawingSettings ds, FilteringSettings fs, RenderStateBlock rsb, ref RendererList rl) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal static void CreateRendererParamsObjectsWithError(ref CullingResults cullResults, Camera camera, FilteringSettings filterSettings, SortingCriteria sortFlags, ref RendererListParams param) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal static void DrawRendererListObjectsWithError(RasterCommandBuffer cmd, ref RendererList rl) { }

	internal static void FinalBlit(CommandBuffer cmd, UniversalCameraData cameraData, RTHandle source, RTHandle destination, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, Material material, int passIndex) { }

	internal static AttachmentDescriptor get_emptyAttachment() { }

	private static Material get_errorMaterial() { }

	public static Mesh get_fullscreenMesh() { }

	internal static bool get_useStructuredBuffer() { }

	internal static RenderTargetIdentifier GetCameraTargetIdentifier(ref RenderingData renderingData) { }

	internal static Vector4 GetFinalBlitScaleBias(RTHandle source, RTHandle destination, UniversalCameraData cameraData) { }

	internal static int GetLastValidColorBufferIndex(RenderTargetIdentifier[] colorBuffers) { }

	internal static uint GetValidColorBufferCount(RTHandle[] colorBuffers) { }

	internal static int IndexOf(RTHandle[] source, RenderTargetIdentifier value) { }

	internal static int IndexOf(RTHandle[] source, RTHandle value) { }

	internal static bool IsMRT(RTHandle[] colorBuffers) { }

	internal static int LastValid(RTHandle[] source) { }

	internal static bool MultisampleDepthResolveSupported() { }

	public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, Vector2 scaleFactor, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, ScaleFunc scaleFunc, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
	public static bool ReAllocateIfNeeded(ref RTHandle handle, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
	public static bool ReAllocateIfNeeded(ref RTHandle handle, Vector2 scaleFactor, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
	public static bool ReAllocateIfNeeded(ref RTHandle handle, ScaleFunc scaleFunc, in RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	internal static bool RTHandleNeedsReAlloc(RTHandle handle, in TextureDesc descriptor, bool scaled) { }

	internal static bool SequenceEqual(RTHandle[] left, RTHandle[] right) { }

	public static bool SetMaxRTHandlePoolCapacity(int capacity) { }

	internal static void SetScaleBiasRt(RasterCommandBuffer cmd, in UniversalCameraData cameraData, RTHandle rTHandle) { }

	internal static void SetScaleBiasRt(RasterCommandBuffer cmd, in RenderingData renderingData) { }

	public static void SetViewAndProjectionMatrices(CommandBuffer cmd, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, bool setInverseMatrices) { }

	internal static void SetViewAndProjectionMatrices(RasterCommandBuffer cmd, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, bool setInverseMatrices) { }

	[Obsolete("Use SystemInfo.IsFormatSupported instead.", False)]
	public static bool SupportsGraphicsFormat(GraphicsFormat format, FormatUsage usage) { }

	internal static bool SupportsLightLayers(GraphicsDeviceType type) { }

	public static bool SupportsRenderTextureFormat(RenderTextureFormat format) { }

}

