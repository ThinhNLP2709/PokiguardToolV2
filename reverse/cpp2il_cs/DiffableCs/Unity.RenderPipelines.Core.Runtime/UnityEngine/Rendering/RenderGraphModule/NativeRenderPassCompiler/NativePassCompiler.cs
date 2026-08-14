namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal class NativePassCompiler : IDisposable
{
	public enum NativeCompilerProfileId
	{
		NRPRGComp_PrepareNativePass = 0,
		NRPRGComp_SetupContextData = 1,
		NRPRGComp_BuildGraph = 2,
		NRPRGComp_CullNodes = 3,
		NRPRGComp_TryMergeNativePasses = 4,
		NRPRGComp_FindResourceUsageRanges = 5,
		NRPRGComp_DetectMemorylessResources = 6,
		NRPRGComp_ExecuteCreateResources = 7,
		NRPRGComp_ExecuteBeginRenderpassCommand = 8,
		NRPRGComp_ExecuteDestroyResources = 9,
	}

	public struct RenderGraphInputInfo
	{
		public RenderGraphResourceRegistry m_ResourcesForDebugOnly; //Field offset: 0x0
		public List<RenderGraphPass> m_RenderPasses; //Field offset: 0x8
		public string debugName; //Field offset: 0x10
		public bool disableCulling; //Field offset: 0x18

	}

	internal const int k_EstimatedPassCount = 100; //Field offset: 0x0
	internal const int k_MaxSubpass = 8; //Field offset: 0x0
	private const int ArbitraryMaxNbMergedPasses = 16; //Field offset: 0x0
	internal RenderGraphInputInfo graph; //Field offset: 0x10
	internal CompilerContextData contextData; //Field offset: 0x30
	internal CompilerContextData defaultContextData; //Field offset: 0x38
	internal CommandBuffer previousCommandBuffer; //Field offset: 0x40
	private Stack<Int32> toVisitPassIds; //Field offset: 0x48
	private RenderGraphCompilationCache m_CompilationCache; //Field offset: 0x50
	private NativeList<AttachmentDescriptor> m_BeginRenderPassAttachments; //Field offset: 0x58
	private bool m_Disposed; //Field offset: 0x60
	private DynamicArray<Name> graphPassNamesForDebug; //Field offset: 0x68

	public NativePassCompiler(RenderGraphCompilationCache cache) { }

	private void BuildGraph() { }

	private void Cleanup() { }

	public void Clear(bool clearContextData) { }

	public void Compile(RenderGraphResourceRegistry resources) { }

	private void CullUnusedRenderPasses() { }

	private void DetectMemoryLessResources() { }

	private void DetermineLoadStoreActions(ref NativePassData nativePass) { }

	public override void Dispose() { }

	internal void ExecuteBeginRenderPass(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, ref NativePassData nativePass) { }

	private void ExecuteCreateRessource(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, in PassData pass) { }

	private void ExecuteDestroyResource(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, ref PassData pass) { }

	public void ExecuteGraph(InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, in List<RenderGraphPass>& passes) { }

	internal void ExecuteGraphNode(ref InternalRenderGraphContext rgContext, RenderGraphResourceRegistry resources, RenderGraphPass pass) { }

	protected virtual void Finalize() { }

	private void FindResourceUsageRanges() { }

	internal void GenerateNativeCompilerDebugData(ref DebugData debugData) { }

	public bool Initialize(RenderGraphResourceRegistry resources, List<RenderGraphPass> renderPasses, bool disableCulling, string debugName, bool useCompilationCaching, int graphHash, int frameIndex) { }

	private static string InjectSpaces(string camelCaseString) { }

	private static bool IsGlobalTextureInPass(RenderGraphPass pass, ResourceHandle handle) { }

	internal static bool IsSameNativeSubPass(ref SubPassDescriptor a, ref SubPassDescriptor b) { }

	private static AttachmentInfo MakeAttachmentInfo(CompilerContextData ctx, in NativePassData nativePass, int attachmentIndex) { }

	internal static string MakePassBreakInfoMessage(CompilerContextData ctx, in NativePassData nativePass) { }

	internal static string MakePassMergeMessage(CompilerContextData ctx, in PassData pass, in PassData prevPass, PassBreakAudit mergeResult) { }

	private void PrepareNativeRenderPasses() { }

	private void SetPassStatesForNativePass(int nativePassId) { }

	internal void SetRandomWriteTarget(in CommandBuffer cmd, RenderGraphResourceRegistry resources, int index, ResourceHandle resource, bool preserveCounterValue = true) { }

	private void SetupContextData(RenderGraphResourceRegistry resources) { }

	private void TryMergeNativePasses() { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateAttachmentRenderTarget(in RenderTargetInfo attRenderTargetInfo, RenderGraphResourceRegistry resources, int nativePassWidth, int nativePassHeight, int nativePassMSAASamples) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	private void ValidateNativePass(in NativePassData nativePass, int width, int height, int depth, int samples, int attachmentCount) { }

}

