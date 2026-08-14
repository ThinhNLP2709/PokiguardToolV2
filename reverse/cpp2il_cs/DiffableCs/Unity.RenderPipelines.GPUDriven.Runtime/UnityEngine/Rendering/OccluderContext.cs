namespace UnityEngine.Rendering;

internal struct OccluderContext : IDisposable
{
	private static class ShaderIDs
	{
		public static readonly int _SrcDepth; //Field offset: 0x0
		public static readonly int _DstDepth; //Field offset: 0x4
		public static readonly int OccluderDepthPyramidConstants; //Field offset: 0x8

		private static ShaderIDs() { }

	}

	public const int k_FirstDepthMipIndex = 3; //Field offset: 0x0
	public const int k_MaxOccluderMips = 8; //Field offset: 0x0
	public const int k_MaxSilhouettePlanes = 6; //Field offset: 0x0
	public const int k_MaxSubviewsPerView = 6; //Field offset: 0x0
	public int version; //Field offset: 0x0
	public Vector2Int depthBufferSize; //Field offset: 0x4
	public NativeArray<OccluderDerivedData> subviewData; //Field offset: 0x10
	public int subviewValidMask; //Field offset: 0x20
	public NativeArray<OccluderMipBounds> occluderMipBounds; //Field offset: 0x28
	public Vector2Int occluderMipLayoutSize; //Field offset: 0x38
	public Vector2Int occluderDepthPyramidSize; //Field offset: 0x40
	public RTHandle occluderDepthPyramid; //Field offset: 0x48
	public int occlusionDebugOverlaySize; //Field offset: 0x50
	public GraphicsBuffer occlusionDebugOverlay; //Field offset: 0x58
	public bool debugNeedsClear; //Field offset: 0x60
	public ComputeBuffer constantBuffer; //Field offset: 0x68
	public NativeArray<OccluderDepthPyramidConstants> constantBufferData; //Field offset: 0x70

	public Vector2 depthBufferSizeInOccluderPixels
	{
		 get { } //Length: 43
	}

	public int subviewCount
	{
		 get { } //Length: 4
	}

	private void AllocateTexturesIfNecessary(bool debugOverlayEnabled) { }

	public void CreateFarDepthPyramid(ComputeCommandBuffer cmd, in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, in OccluderHandles occluderHandles, NativeArray<Plane> silhouettePlanes, ComputeShader occluderDepthPyramidCS, int occluderDepthDownscaleKernel) { }

	public override void Dispose() { }

	public Vector2 get_depthBufferSizeInOccluderPixels() { }

	public int get_subviewCount() { }

	internal OcclusionCullingDebugOutput GetDebugOutput() { }

	public OccluderHandles Import(RenderGraph renderGraph) { }

	public bool IsSubviewValid(int subviewIndex) { }

	public void PrepareOccluders(in OccluderParameters occluderParams) { }

	internal static void SetKeyword(ComputeCommandBuffer cmd, ComputeShader cs, in LocalKeyword keyword, bool value) { }

	private OccluderDepthPyramidConstants SetupFarDepthPyramidConstants(ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, NativeArray<Plane> silhouettePlanes) { }

	private void UpdateMipBounds() { }

}

