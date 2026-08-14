namespace UnityEngine.UIElements.UIR;

internal class UIRenderDevice : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<MeshHandle> <>9__58_0; //Field offset: 0x8
		public static Action<MeshHandle> <>9__58_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal MeshHandle <.ctor>b__58_0() { }

		internal void <.ctor>b__58_1(MeshHandle mh) { }

	}

	private struct AllocToFree
	{
		public Alloc alloc; //Field offset: 0x0
		public Page page; //Field offset: 0x18
		public bool vertices; //Field offset: 0x20

	}

	public struct AllocToUpdate
	{
		public uint id; //Field offset: 0x0
		public uint allocTime; //Field offset: 0x4
		public MeshHandle meshHandle; //Field offset: 0x8
		public Alloc permAllocVerts; //Field offset: 0x10
		public Alloc permAllocIndices; //Field offset: 0x28
		public Page permPage; //Field offset: 0x40
		public bool copyBackIndices; //Field offset: 0x48

	}

	private struct DeviceToFree
	{
		public uint handle; //Field offset: 0x0
		public Page page; //Field offset: 0x8
		public List<CommandList>[] commandLists; //Field offset: 0x10

		public void Dispose() { }

	}

	public struct DrawStatistics
	{
		public int currentFrameIndex; //Field offset: 0x0
		public uint totalIndices; //Field offset: 0x4
		public uint commandCount; //Field offset: 0x8
		public uint skippedCommandCount; //Field offset: 0xC
		public uint drawCommandCount; //Field offset: 0x10
		public uint disableCommandCount; //Field offset: 0x14
		public uint materialSetCount; //Field offset: 0x18
		public uint drawRangeCount; //Field offset: 0x1C
		public uint drawRangeCallCount; //Field offset: 0x20
		public uint immediateDraws; //Field offset: 0x24
		public uint stencilRefChanges; //Field offset: 0x28

	}

	private struct EvaluationState
	{
		public CommandList activeCommandList; //Field offset: 0x0
		public MaterialPropertyBlock constantProps; //Field offset: 0x8
		public MaterialPropertyBlock batchProps; //Field offset: 0x10
		public Material defaultMat; //Field offset: 0x18
		public State curState; //Field offset: 0x20
		public Page curPage; //Field offset: 0x38
		public bool mustApplyMaterial; //Field offset: 0x40
		public bool mustApplyBatchProps; //Field offset: 0x41
		public bool mustApplyStencil; //Field offset: 0x42

	}

	private static LinkedList<DeviceToFree> m_DeviceFreeQueue; //Field offset: 0x0
	private static int m_ActiveDeviceCount; //Field offset: 0x8
	private static bool m_SubscribedToNotifications; //Field offset: 0xC
	private static bool m_SynchronousFree; //Field offset: 0xD
	private static readonly int s_GradientSettingsTexID; //Field offset: 0x10
	private static readonly int s_ShaderInfoTexID; //Field offset: 0x14
	private static ProfilerMarker s_MarkerAllocate; //Field offset: 0x18
	private static ProfilerMarker s_MarkerFree; //Field offset: 0x20
	private static ProfilerMarker s_MarkerAdvanceFrame; //Field offset: 0x28
	private static ProfilerMarker s_MarkerFence; //Field offset: 0x30
	private static ProfilerMarker s_MarkerBeforeDraw; //Field offset: 0x38
	private readonly bool m_MockDevice; //Field offset: 0x10
	private IntPtr m_DefaultStencilState; //Field offset: 0x18
	private IntPtr m_VertexDecl; //Field offset: 0x20
	private Page m_FirstPage; //Field offset: 0x28
	private uint m_NextPageVertexCount; //Field offset: 0x30
	private uint m_LargeMeshVertexCount; //Field offset: 0x34
	private float m_IndexToVertexCountRatio; //Field offset: 0x38
	private List<List`1<AllocToFree>> m_DeferredFrees; //Field offset: 0x40
	private List<List`1<AllocToUpdate>> m_Updates; //Field offset: 0x48
	private List<CommandList>[] m_CommandLists; //Field offset: 0x50
	private UInt32[] m_Fences; //Field offset: 0x58
	private MaterialPropertyBlock m_ConstantProps; //Field offset: 0x60
	private MaterialPropertyBlock m_BatchProps; //Field offset: 0x68
	private uint m_FrameIndex; //Field offset: 0x70
	private uint m_NextUpdateID; //Field offset: 0x74
	private DrawStatistics m_DrawStats; //Field offset: 0x78
	private readonly LinkedPool<MeshHandle> m_MeshHandles; //Field offset: 0xA8
	private readonly DrawParams m_DrawParams; //Field offset: 0xB0
	private readonly TextureSlotManager m_TextureSlotManager; //Field offset: 0xB8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <breakBatches>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isFlat>k__BackingField; //Field offset: 0xC1
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <drawsInCameras>k__BackingField; //Field offset: 0xC2
	internal int currentFrameCommandListCount; //Field offset: 0xC4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0xC8

	internal bool breakBatches
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal List<CommandList>[] commandLists
	{
		internal get { } //Length: 5
	}

	internal List<CommandList> currentFrameCommandLists
	{
		internal get { } //Length: 64
	}

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	internal bool drawsInCameras
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal uint frameIndex
	{
		internal get { } //Length: 4
	}

	private bool fullyCreated
	{
		private get { } //Length: 11
	}

	internal bool isFlat
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal static uint maxVerticesPerPage
	{
		internal get { } //Length: 6
	}

	private static UIRenderDevice() { }

	public UIRenderDevice(uint initialVertexCapacity = 0, uint initialIndexCapacity = 0) { }

	protected UIRenderDevice(uint initialVertexCapacity, uint initialIndexCapacity, bool mockDevice) { }

	internal List<AllocToUpdate> ActiveUpdatesForMeshHandle(MeshHandle mesh) { }

	public void AdvanceFrame() { }

	private void Allocate(MeshHandle meshHandle, uint vertexCount, uint indexCount, out NativeSlice<Vertex>& vertexData, out NativeSlice<UInt16>& indexData, bool shortLived) { }

	public MeshHandle Allocate(uint vertexCount, uint indexCount, out NativeSlice<Vertex>& vertexData, out NativeSlice<UInt16>& indexData, out ushort indexOffset) { }

	private void ApplyBatchState(ref EvaluationState st) { }

	private void ApplyDrawCommandState(RenderChainCommand cmd, int textureSlot, Material newMat, bool newMatDiffers, ref EvaluationState st) { }

	private void CompleteCreation() { }

	protected override void Dispose(bool disposing) { }

	public override void Dispose() { }

	private void DrawRanges(GPUBuffer<UInt16> ib, GPUBuffer<Vertex> vb, NativeSlice<DrawBufferRange> ranges, CommandList commandList) { }

	public void EvaluateChain(RenderChainCommand head, Material initialMat, Material defaultMat, Texture gradientSettings, Texture shaderInfo, float pixelsPerPoint, ref Exception immediateException) { }

	internal static void FlushAllPendingDeviceDisposes() { }

	public void Free(MeshHandle mesh) { }

	internal DrawStatistics GatherDrawStatistics() { }

	[CompilerGenerated]
	internal bool get_breakBatches() { }

	internal List<CommandList>[] get_commandLists() { }

	internal List<CommandList> get_currentFrameCommandLists() { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	[CompilerGenerated]
	internal bool get_drawsInCameras() { }

	internal uint get_frameIndex() { }

	private bool get_fullyCreated() { }

	[CompilerGenerated]
	internal bool get_isFlat() { }

	internal static uint get_maxVerticesPerPage() { }

	private void InitVertexDeclaration() { }

	private void KickRanges(DrawBufferRange* ranges, ref int rangesReady, ref int rangesStart, int rangesCount, Page curPage, CommandList commandList) { }

	private static void OnEngineUpdateGlobal() { }

	private static void OnFlushPendingResources() { }

	public void OnFrameRenderingBegin() { }

	internal static void PrepareForGfxDeviceRecreate() { }

	private static void ProcessDeviceFreeQueue() { }

	private void PruneUnusedPages() { }

	internal static NativeSlice<T> PtrToSlice(Void* p, int count) { }

	[CompilerGenerated]
	internal void set_breakBatches(bool value) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

	[CompilerGenerated]
	internal void set_drawsInCameras(bool value) { }

	[CompilerGenerated]
	internal void set_isFlat(bool value) { }

	private bool TryAllocFromPage(Page page, uint vertexCount, uint indexCount, ref Alloc va, ref Alloc ia, bool shortLived) { }

	public void Update(MeshHandle mesh, uint vertexCount, out NativeSlice<Vertex>& vertexData) { }

	public void Update(MeshHandle mesh, uint vertexCount, uint indexCount, out NativeSlice<Vertex>& vertexData, out NativeSlice<UInt16>& indexData, out ushort indexOffset) { }

	private void UpdateAfterGPUUsedData(MeshHandle mesh, uint vertexCount, uint indexCount, out NativeSlice<Vertex>& vertexData, out NativeSlice<UInt16>& indexData, out ushort indexOffset, out AllocToUpdate allocToUpdate, bool copyBackIndices) { }

	private void UpdateCopyBackIndices(MeshHandle mesh, bool copyBackIndices) { }

	private void UpdateFenceValue() { }

	private void WaitOnCpuFence(uint fence) { }

	internal static void WrapUpGfxDeviceRecreate() { }

}

