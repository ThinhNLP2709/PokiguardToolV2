namespace UnityEngine.UIElements;

internal class MeshGenerationNodeManager : IDisposable
{
	private List<MeshGenerationNodeImpl> m_Nodes; //Field offset: 0x10
	private int m_UsedCounter; //Field offset: 0x18
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

	public MeshGenerationNodeManager(EntryRecorder entryRecorder) { }

	private MeshGenerationNodeImpl CreateImpl(Entry parentEntry, bool safe) { }

	public void CreateNode(Entry parentEntry, out MeshGenerationNode node) { }

	public void CreateUnsafeNode(Entry parentEntry, out UnsafeMeshGenerationNode node) { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	public void ResetAll() { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

