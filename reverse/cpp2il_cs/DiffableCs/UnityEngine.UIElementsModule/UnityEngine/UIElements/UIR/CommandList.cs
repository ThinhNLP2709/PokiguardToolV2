namespace UnityEngine.UIElements.UIR;

internal class CommandList : IDisposable
{
	public VisualElement m_Owner; //Field offset: 0x10
	private readonly IntPtr m_VertexDecl; //Field offset: 0x18
	private readonly IntPtr m_StencilState; //Field offset: 0x20
	public MaterialPropertyBlock constantProps; //Field offset: 0x28
	public MaterialPropertyBlock batchProps; //Field offset: 0x30
	public GCHandle handle; //Field offset: 0x38
	private List<SerializedCommand> m_Commands; //Field offset: 0x40
	private Vector4[] m_GpuTextureData; //Field offset: 0x48
	private NativeList<DrawBufferRange> m_DrawRanges; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x58

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public CommandList(VisualElement owner, IntPtr vertexDecl, IntPtr stencilState) { }

	public void ApplyBatchProps() { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	public void DrawRanges(GPUBuffer<UInt16> ib, GPUBuffer<Vertex> vb, NativeSlice<DrawBufferRange> ranges) { }

	public void Execute() { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	public void Reset(VisualElement newOwner) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

	public void SetTexture(int name, Texture texture, int gpuDataOffset, Vector4 gpuData0, Vector4 gpuData1) { }

}

