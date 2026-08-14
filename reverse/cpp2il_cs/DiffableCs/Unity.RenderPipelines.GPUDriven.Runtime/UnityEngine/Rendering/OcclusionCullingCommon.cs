namespace UnityEngine.Rendering;

internal class OcclusionCullingCommon : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<OcclusionTestOverlaySetupPassData, ComputeGraphContext> <>9__29_0; //Field offset: 0x8
		public static BaseRenderFunc<OccluderOverlayPassData, RasterGraphContext> <>9__32_0; //Field offset: 0x10
		public static BaseRenderFunc<UpdateOccludersPassData, ComputeGraphContext> <>9__37_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <RenderDebugOccluderOverlay>b__32_0(OccluderOverlayPassData data, RasterGraphContext ctx) { }

		internal void <RenderDebugOcclusionTestOverlay>b__29_0(OcclusionTestOverlaySetupPassData data, ComputeGraphContext ctx) { }

		internal void <UpdateInstanceOccluders>b__37_0(UpdateOccludersPassData data, ComputeGraphContext context) { }

	}

	private struct DebugOccluderViewData
	{
		public int passIndex; //Field offset: 0x0
		public Rect viewport; //Field offset: 0x4
		public bool valid; //Field offset: 0x14

	}

	private struct OccluderContextSlot
	{
		public bool valid; //Field offset: 0x0
		public int lastUsedFrameIndex; //Field offset: 0x4
		public int viewInstanceID; //Field offset: 0x8

	}

	private class OccluderOverlayPassData
	{
		public Material debugMaterial; //Field offset: 0x10
		public RTHandle occluderTexture; //Field offset: 0x18
		public Rect viewport; //Field offset: 0x20
		public int passIndex; //Field offset: 0x30
		public Vector2 validRange; //Field offset: 0x34

		public OccluderOverlayPassData() { }

	}

	private class OcclusionTestOverlayPassData
	{
		public BufferHandle debugPyramid; //Field offset: 0x10

		public OcclusionTestOverlayPassData() { }

	}

	private class OcclusionTestOverlaySetupPassData
	{
		public OcclusionCullingDebugShaderVariables cb; //Field offset: 0x10

		public OcclusionTestOverlaySetupPassData() { }

	}

	private static class ShaderIDs
	{
		public static readonly int OcclusionCullingCommonShaderVariables; //Field offset: 0x0
		public static readonly int _OccluderDepthPyramid; //Field offset: 0x4
		public static readonly int _OcclusionDebugOverlay; //Field offset: 0x8
		public static readonly int OcclusionCullingDebugShaderVariables; //Field offset: 0xC

		private static ShaderIDs() { }

	}

	private class UpdateOccludersPassData
	{
		public OccluderParameters occluderParams; //Field offset: 0x10
		public List<OccluderSubviewUpdate> occluderSubviewUpdates; //Field offset: 0x38
		public OccluderHandles occluderHandles; //Field offset: 0x40

		public UpdateOccludersPassData() { }

	}

	private static readonly int s_MaxContextGCFrame; //Field offset: 0x0
	private Material m_DebugOcclusionTestMaterial; //Field offset: 0x10
	private Material m_OccluderDebugViewMaterial; //Field offset: 0x18
	private ComputeShader m_OcclusionDebugCS; //Field offset: 0x20
	private int m_ClearOcclusionDebugKernel; //Field offset: 0x28
	private ComputeShader m_OccluderDepthPyramidCS; //Field offset: 0x30
	private int m_OccluderDepthDownscaleKernel; //Field offset: 0x38
	private int m_FrameIndex; //Field offset: 0x3C
	private SilhouettePlaneCache m_SilhouettePlaneCache; //Field offset: 0x40
	private NativeParallelHashMap<Int32, Int32> m_ViewIDToIndexMap; //Field offset: 0x68
	private List<OccluderContext> m_OccluderContextData; //Field offset: 0x78
	private NativeList<OccluderContextSlot> m_OccluderContextSlots; //Field offset: 0x80
	private NativeList<Int32> m_FreeOccluderContexts; //Field offset: 0x88
	private NativeArray<OcclusionCullingCommonShaderVariables> m_CommonShaderVariables; //Field offset: 0x90
	private ComputeBuffer m_CommonConstantBuffer; //Field offset: 0xA0
	private NativeArray<OcclusionCullingDebugShaderVariables> m_DebugShaderVariables; //Field offset: 0xA8
	private ComputeBuffer m_DebugConstantBuffer; //Field offset: 0xB8
	private ProfilingSampler m_ProfilingSamplerUpdateOccluders; //Field offset: 0xC0
	private ProfilingSampler m_ProfilingSamplerOcclusionTestOverlay; //Field offset: 0xC8
	private ProfilingSampler m_ProfilingSamplerOccluderOverlay; //Field offset: 0xD0

	private static OcclusionCullingCommon() { }

	public OcclusionCullingCommon() { }

	[CompilerGenerated]
	private void <RenderDebugOcclusionTestOverlay>b__29_1(OcclusionTestOverlayPassData data, RasterGraphContext ctx) { }

	private void CreateFarDepthPyramid(ComputeCommandBuffer cmd, in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, in OccluderHandles occluderHandles) { }

	private void DeleteContext(int viewInstanceID) { }

	private void DispatchDebugClear(ComputeCommandBuffer cmd, int viewInstanceID) { }

	public override void Dispose() { }

	internal bool GetOccluderContext(int viewInstanceID, out OccluderContext occluderContext) { }

	internal OcclusionCullingDebugOutput GetOcclusionTestDebugOutput(int viewInstanceID) { }

	internal bool HasOccluderContext(int viewInstanceID) { }

	internal void Init(GPUResidentDrawerResources resources) { }

	private int NewContext(int viewInstanceID) { }

	internal void PrepareCulling(ComputeCommandBuffer cmd, in OccluderContext occluderCtx, in OcclusionCullingSettings settings, in InstanceOcclusionTestSubviewSettings subviewSettings, in OcclusionTestComputeShader shader, bool useOcclusionDebug) { }

	private OccluderHandles PrepareOccluders(RenderGraph renderGraph, in OccluderParameters occluderParams) { }

	public void RenderDebugOccluderOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, Vector2 screenPos, float maxHeight, TextureHandle colorBuffer) { }

	public void RenderDebugOcclusionTestOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, int viewInstanceID, TextureHandle colorBuffer) { }

	internal static void SetDebugPyramid(ComputeCommandBuffer cmd, in OcclusionTestComputeShader shader, int kernel, in OccluderHandles occluderHandles) { }

	internal static void SetDepthPyramid(ComputeCommandBuffer cmd, in OcclusionTestComputeShader shader, int kernel, in OccluderHandles occluderHandles) { }

	internal void UpdateFrame() { }

	public bool UpdateInstanceOccluders(RenderGraph renderGraph, in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates) { }

	public void UpdateOccluderStats(DebugRendererBatcherStats debugStats) { }

	internal void UpdateSilhouettePlanes(int viewInstanceID, NativeArray<Plane> planes) { }

	internal static bool UseOcclusionDebug(in OccluderContext occluderCtx) { }

}

