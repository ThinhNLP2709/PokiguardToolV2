namespace UnityEngine.Rendering;

public class GPUResidentDrawer
{
	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct FindUnsupportedMaterialsJob : IJob
	{
		[ReadOnly]
		public NativeParallelHashMap<Int32, BatchMaterialID> batchMaterialHash; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> changedMaterialIDs; //Field offset: 0x10
		public NativeList<Int32> unsupportedMaterialIDs; //Field offset: 0x20

		public override void Execute() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct FindUnsupportedRenderersJob : IJob
	{
		[ReadOnly]
		public ReadOnly<Int32> unsupportedMaterials; //Field offset: 0x0
		[ReadOnly]
		public ReadOnly<SmallIntegerArray> materialIDArrays; //Field offset: 0x10
		[ReadOnly]
		public ReadOnly<Int32> rendererGroups; //Field offset: 0x20
		public NativeList<Int32> unsupportedRenderers; //Field offset: 0x30

		public override void Execute() { }

	}

	private static class Strings
	{
		public static readonly string drawerModeDisabled; //Field offset: 0x0
		public static readonly string allowInEditModeDisabled; //Field offset: 0x8
		public static readonly string notGPUResidentRenderPipeline; //Field offset: 0x10
		public static readonly string rawBufferNotSupportedByPlatform; //Field offset: 0x18
		public static readonly string kernelNotPresent; //Field offset: 0x20
		public static readonly string batchRendererGroupShaderStrippingModeInvalid; //Field offset: 0x28

		private static Strings() { }

	}

	private static GPUResidentDrawer s_Instance; //Field offset: 0x0
	private IntPtr m_ContextIntPtr; //Field offset: 0x10
	private GPUResidentDrawerSettings m_Settings; //Field offset: 0x18
	private GPUDrivenProcessor m_GPUDrivenProcessor; //Field offset: 0x30
	private RenderersBatchersContext m_BatchersContext; //Field offset: 0x38
	private GPUResidentBatcher m_Batcher; //Field offset: 0x40
	private ObjectDispatcher m_Dispatcher; //Field offset: 0x48

	internal GPUResidentBatcher batcher
	{
		internal get { } //Length: 5
	}

	internal static GPUResidentDrawer instance
	{
		internal get { } //Length: 54
	}

	internal GPUResidentDrawerSettings settings
	{
		internal get { } //Length: 21
	}

	private GPUResidentDrawer(GPUResidentDrawerSettings settings, int maxInstanceCount, int maxTreeInstanceCount) { }

	private InstanceHandle AppendNewInstance(int rendererGroupID, in Matrix4x4 instanceTransform) { }

	private static void CleanUp() { }

	private void Dispose() { }

	private NativeList<Int32> FindUnsupportedMaterials(NativeArray<Int32> changedMaterialIDs) { }

	private NativeList<Int32> FindUnsupportedRenderers(NativeArray<Int32> unsupportedMaterials) { }

	private void FreeInstances(NativeArray<InstanceHandle> instances) { }

	private void FreeRendererGroupInstances(NativeArray<Int32> rendererGroupIDs, NativeArray<Int32> unsupportedRendererGroupIDs) { }

	internal GPUResidentBatcher get_batcher() { }

	internal static GPUResidentDrawer get_instance() { }

	internal GPUResidentDrawerSettings get_settings() { }

	internal static DebugRendererBatcherStats GetDebugStats() { }

	internal static GPUResidentDrawerSettings GetGlobalSettingsFromRPAsset() { }

	private void InsertIntoPlayerLoop() { }

	public static void InstanceOcclusionTest(RenderGraph renderGraph, in OcclusionCullingSettings settings, ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests) { }

	internal static bool IsEnabled() { }

	private static bool IsForcedOnViaCommandLine() { }

	internal static bool IsGPUResidentDrawerSupportedBySRP(GPUResidentDrawerSettings settings, out string message, out LogType severity) { }

	public static bool IsInstanceOcclusionCullingEnabled() { }

	private static bool IsOcclusionForcedOnViaCommandLine() { }

	internal static bool IsProjectSupported() { }

	internal static bool IsProjectSupported(out string message, out LogType severity) { }

	internal static void LogMessage(string message, LogType severity) { }

	private void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera) { }

	private void OnBeginContextRendering(ScriptableRenderContext context, List<Camera> cameras) { }

	private void OnEndCameraRendering(ScriptableRenderContext context, Camera camera) { }

	private void OnEndContextRendering(ScriptableRenderContext context, List<Camera> cameras) { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	public static void OnSetupAmbientProbe() { }

	public static void PostCullBeginCameraRendering(RenderRequestBatcherContext context) { }

	private void PostPostLateUpdate() { }

	private static void PostPostLateUpdateStatic() { }

	private void ProcessLODGroups(NativeArray<Int32> changedID, NativeArray<Int32> destroyed, NativeArray<Int32> transformedID) { }

	private void ProcessMaterials(NativeArray<Int32> destroyedID, NativeArray<Int32> unsupportedMaterials) { }

	private void ProcessMeshes(NativeArray<Int32> destroyedID) { }

	private void ProcessRenderers(TypeDispatchData rendererChanges, NativeArray<Int32> unsupportedRenderers) { }

	private static void Recreate(GPUResidentDrawerSettings settings) { }

	internal static void Reinitialize() { }

	public static void ReinitializeIfNeeded() { }

	private void RemoveFromPlayerLoop() { }

	public static void RenderDebugOccluderOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, Vector2 screenPos, float maxHeight, TextureHandle colorBuffer) { }

	public static void RenderDebugOcclusionTestOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, int viewInstanceID, TextureHandle colorBuffer) { }

	private JobHandle ScheduleQueryMeshInstancesJob(NativeArray<Int32> sortedMeshIDs, NativeList<InstanceHandle> instances) { }

	private JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<InstanceHandle> instances) { }

	private JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeList<InstanceHandle> instances) { }

	private JobHandle ScheduleQueryRendererGroupInstancesJob(NativeArray<Int32> rendererGroupIDs, NativeArray<Int32> instancesOffset, NativeArray<Int32> instancesCount, NativeList<InstanceHandle> instances) { }

	private void TransformInstances(NativeArray<InstanceHandle> instances, NativeArray<Matrix4x4> localToWorldMatrices) { }

	public static void UpdateInstanceOccluders(RenderGraph renderGraph, in OccluderParameters occluderParameters, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates) { }

}

