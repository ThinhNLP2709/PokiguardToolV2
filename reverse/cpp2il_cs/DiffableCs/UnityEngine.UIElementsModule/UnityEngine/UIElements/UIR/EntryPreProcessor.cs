namespace UnityEngine.UIElements.UIR;

internal class EntryPreProcessor
{
	internal struct AllocSize
	{
		public int vertexCount; //Field offset: 0x0
		public int indexCount; //Field offset: 0x4

	}

	private int m_ChildrenIndex; //Field offset: 0x10
	private List<AllocSize> m_Allocs; //Field offset: 0x18
	private List<AllocSize> m_HeadAllocs; //Field offset: 0x20
	private List<AllocSize> m_TailAllocs; //Field offset: 0x28
	private List<Entry> m_FlattenedEntries; //Field offset: 0x30
	private AllocSize m_Pending; //Field offset: 0x38
	private Stack<AllocSize> m_Mask; //Field offset: 0x40
	private bool m_IsPushingMask; //Field offset: 0x48

	public int childrenIndex
	{
		 get { } //Length: 4
	}

	public List<Entry> flattenedEntries
	{
		 get { } //Length: 5
	}

	public List<AllocSize> headAllocs
	{
		 get { } //Length: 5
	}

	public List<AllocSize> tailAllocs
	{
		 get { } //Length: 5
	}

	public EntryPreProcessor() { }

	private void Add(int vertexCount, int indexCount) { }

	private void DoEvaluate(Entry entry) { }

	private void Flush() { }

	public int get_childrenIndex() { }

	public List<Entry> get_flattenedEntries() { }

	public List<AllocSize> get_headAllocs() { }

	public List<AllocSize> get_tailAllocs() { }

	public void PreProcess(Entry root) { }

}

