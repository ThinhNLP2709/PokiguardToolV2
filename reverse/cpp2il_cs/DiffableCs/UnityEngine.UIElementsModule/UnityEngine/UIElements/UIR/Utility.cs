namespace UnityEngine.UIElements.UIR;

[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRendererUtility.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"Unity.UIElements"})]
internal class Utility
{
	internal class GPUBuffer : IDisposable
	{
		private IntPtr buffer; //Field offset: 0x0
		private int elemCount; //Field offset: 0x0
		private int elemStride; //Field offset: 0x0

		internal IntPtr BufferPointer
		{
			internal get { } //Length: 7
		}

		public int ElementStride
		{
			 get { } //Length: 6
		}

		public GPUBuffer`1(int elementCount, GPUBufferType type) { }

		public override void Dispose() { }

		internal IntPtr get_BufferPointer() { }

		public int get_ElementStride() { }

		public void UpdateRanges(NativeSlice<GfxUpdateBufferRange> ranges, int rangesMin, int rangesMax) { }

	}

	public enum GPUBufferType
	{
		Vertex = 0,
		Index = 1,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> GraphicsResourcesRecreate; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action EngineUpdate; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action FlushPendingResources; //Field offset: 0x10
	private static ProfilerMarker s_MarkerRaiseEngineUpdate; //Field offset: 0x18

	public static event Action EngineUpdate
	{
		[CompilerGenerated]
		 add { } //Length: 242
		[CompilerGenerated]
		 remove { } //Length: 242
	}

	public static event Action FlushPendingResources
	{
		[CompilerGenerated]
		 add { } //Length: 242
		[CompilerGenerated]
		 remove { } //Length: 242
	}

	public static event Action<Boolean> GraphicsResourcesRecreate
	{
		[CompilerGenerated]
		 add { } //Length: 257
		[CompilerGenerated]
		 remove { } //Length: 257
	}

	private static Utility() { }

	[CompilerGenerated]
	public static void add_EngineUpdate(Action value) { }

	[CompilerGenerated]
	public static void add_FlushPendingResources(Action value) { }

	[CompilerGenerated]
	public static void add_GraphicsResourcesRecreate(Action<Boolean> value) { }

	[ThreadSafe]
	private static IntPtr AllocateBuffer(int elementCount, int elementStride, bool vertexBuffer) { }

	[ThreadSafe]
	public static bool CPUFencePassed(uint fence) { }

	[ThreadSafe]
	public static IntPtr CreateStencilState(StencilState stencilState) { }

	private static IntPtr CreateStencilState_Injected(in StencilState stencilState) { }

	[ThreadSafe]
	public static void DisableScissor() { }

	[ThreadSafe]
	public static void DrawRanges(IntPtr ib, IntPtr* vertexStreams, int streamCount, IntPtr ranges, int rangeCount, IntPtr vertexDecl) { }

	[ThreadSafe]
	private static void FreeBuffer(IntPtr buffer) { }

	[ThreadSafe]
	public static RectInt GetActiveViewport() { }

	private static void GetActiveViewport_Injected(out RectInt ret) { }

	[ThreadSafe]
	public static Matrix4x4 GetUnityProjectionMatrix() { }

	private static void GetUnityProjectionMatrix_Injected(out Matrix4x4 ret) { }

	[ThreadSafe]
	public static IntPtr GetVertexDeclaration(VertexAttributeDescriptor[] vertexAttributes) { }

	private static IntPtr GetVertexDeclaration_Injected(ref ManagedSpanWrapper vertexAttributes) { }

	[ThreadSafe]
	public static bool HasMappedBufferRange() { }

	[ThreadSafe]
	public static uint InsertCPUFence() { }

	public static void NotifyOfUIREvents(bool subscribe) { }

	[ThreadSafe]
	public static void ProfileDrawChainBegin() { }

	[ThreadSafe]
	public static void ProfileDrawChainEnd() { }

	[RequiredByNativeCode]
	internal static void RaiseEngineUpdate() { }

	[RequiredByNativeCode]
	internal static void RaiseFlushPendingResources() { }

	[RequiredByNativeCode]
	internal static void RaiseGraphicsResourcesRecreate(bool recreate) { }

	[CompilerGenerated]
	public static void remove_EngineUpdate(Action value) { }

	[CompilerGenerated]
	public static void remove_FlushPendingResources(Action value) { }

	[CompilerGenerated]
	public static void remove_GraphicsResourcesRecreate(Action<Boolean> value) { }

	[ThreadSafe]
	public static void SetPropertyBlock(MaterialPropertyBlock props) { }

	private static void SetPropertyBlock_Injected(IntPtr props) { }

	[ThreadSafe]
	public static void SetScissorRect(RectInt scissorRect) { }

	private static void SetScissorRect_Injected(in RectInt scissorRect) { }

	[ThreadSafe]
	public static void SetStencilState(IntPtr stencilState, int stencilRef) { }

	[ThreadSafe]
	public static void SyncRenderThread() { }

	[ThreadSafe]
	private static void UpdateBufferRanges(IntPtr buffer, IntPtr ranges, int rangeCount, int writeRangeStart, int writeRangeEnd) { }

	[ThreadSafe]
	public static void WaitForCPUFencePassed(uint fence) { }

}

