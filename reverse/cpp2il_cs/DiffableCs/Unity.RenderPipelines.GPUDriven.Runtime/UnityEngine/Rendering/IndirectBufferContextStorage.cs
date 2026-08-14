namespace UnityEngine.Rendering;

internal struct IndirectBufferContextStorage : IDisposable
{
	private const int kAllocatorCount = 2; //Field offset: 0x0
	internal const int kExtraDrawAllocationCount = 1; //Field offset: 0x0
	internal const int kInstanceInfoGpuOffsetMultiplier = 2; //Field offset: 0x0
	private IndirectBufferLimits m_BufferLimits; //Field offset: 0x0
	private GraphicsBuffer m_InstanceBuffer; //Field offset: 0x8
	private GraphicsBuffer m_InstanceInfoBuffer; //Field offset: 0x10
	private NativeArray<IndirectInstanceInfo> m_InstanceInfoStaging; //Field offset: 0x18
	private GraphicsBuffer m_ArgsBuffer; //Field offset: 0x28
	private GraphicsBuffer m_DrawInfoBuffer; //Field offset: 0x30
	private NativeArray<IndirectDrawInfo> m_DrawInfoStaging; //Field offset: 0x38
	private int m_ContextAllocCounter; //Field offset: 0x48
	private NativeHashMap<Int32, Int32> m_ContextIndexFromViewID; //Field offset: 0x50
	private NativeList<IndirectBufferContext> m_Contexts; //Field offset: 0x58
	private NativeArray<IndirectBufferAllocInfo> m_ContextAllocInfo; //Field offset: 0x60
	private NativeArray<Int32> m_AllocationCounters; //Field offset: 0x70

	public NativeArray<Int32> allocationCounters
	{
		 get { } //Length: 11
	}

	public GraphicsBuffer argsBuffer
	{
		 get { } //Length: 5
	}

	public GraphicsBuffer drawInfoBuffer
	{
		 get { } //Length: 5
	}

	public NativeArray<IndirectDrawInfo> drawInfoGlobalArray
	{
		 get { } //Length: 11
	}

	public GraphicsBufferHandle indirectArgsBufferHandle
	{
		 get { } //Length: 29
	}

	public GraphicsBuffer instanceBuffer
	{
		 get { } //Length: 5
	}

	public GraphicsBuffer instanceInfoBuffer
	{
		 get { } //Length: 5
	}

	public NativeArray<IndirectInstanceInfo> instanceInfoGlobalArray
	{
		 get { } //Length: 11
	}

	public GraphicsBufferHandle visibleInstanceBufferHandle
	{
		 get { } //Length: 29
	}

	private void AllocateDrawBuffers(int maxDrawCount) { }

	private void AllocateInstanceBuffers(int maxInstanceCount) { }

	public void ClearContextsAndGrowBuffers() { }

	public void CopyFromStaging(CommandBuffer cmd, in IndirectBufferAllocInfo allocInfo) { }

	public override void Dispose() { }

	private void FreeDrawBuffers() { }

	private void FreeInstanceBuffers() { }

	public NativeArray<Int32> get_allocationCounters() { }

	public GraphicsBuffer get_argsBuffer() { }

	public GraphicsBuffer get_drawInfoBuffer() { }

	public NativeArray<IndirectDrawInfo> get_drawInfoGlobalArray() { }

	public GraphicsBufferHandle get_indirectArgsBufferHandle() { }

	public GraphicsBuffer get_instanceBuffer() { }

	public GraphicsBuffer get_instanceInfoBuffer() { }

	public NativeArray<IndirectInstanceInfo> get_instanceInfoGlobalArray() { }

	public GraphicsBufferHandle get_visibleInstanceBufferHandle() { }

	public IndirectBufferAllocInfo GetAllocInfo(int contextIndex) { }

	public NativeArray<IndirectBufferAllocInfo> GetAllocInfoSubArray(int contextIndex) { }

	public IndirectBufferContext GetBufferContext(int contextIndex) { }

	public IndirectBufferLimits GetLimits(int contextIndex) { }

	private void GrowBuffers() { }

	public IndirectBufferContextHandles ImportBuffers(RenderGraph renderGraph) { }

	public void Init() { }

	private void ResetAllocators() { }

	public void SetBufferContext(int contextIndex, IndirectBufferContext ctx) { }

	private void SyncContexts() { }

	public int TryAllocateContext(int viewID) { }

	public int TryGetContextIndex(int viewID) { }

}

