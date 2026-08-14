namespace UnityEngine.UIElements;

internal class MeshGenerationNodeImpl : IDisposable
{
	private GCHandle m_SelfHandle; //Field offset: 0x10
	private Entry m_ParentEntry; //Field offset: 0x18
	private EntryRecorder m_EntryRecorder; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x28

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public MeshGenerationNodeImpl() { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	public void DrawGradients(NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, VectorImage gradientsOwner) { }

	public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture = null, bool skipAtlas = false) { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	public void GetNode(out MeshGenerationNode node) { }

	public Entry GetParentEntry() { }

	public void GetUnsafeNode(out UnsafeMeshGenerationNode node) { }

	public void Init(Entry parentEntry, EntryRecorder entryRecorder, bool safe) { }

	public void Reset() { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

