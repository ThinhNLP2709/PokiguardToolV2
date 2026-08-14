namespace UnityEngine.UIElements.UIR;

internal class NativePagedList : IDisposable
{
	internal struct Enumerator
	{
		private NativePagedList<T> m_NativePagedList; //Field offset: 0x0
		private NativeArray<T> m_CurrentPage; //Field offset: 0x0
		private int m_IndexInCurrentPage; //Field offset: 0x0
		private int m_IndexOfCurrentPage; //Field offset: 0x0
		private int m_CountInCurrentPage; //Field offset: 0x0

		public Enumerator(NativePagedList<T> nativePagedList, int offset) { }

		public T GetNext() { }

		public bool HasNext() { }

	}

	private readonly int k_PoolCapacity; //Field offset: 0x0
	private List<NativeArray`1<T>> m_Pages; //Field offset: 0x0
	private NativeArray<T> m_LastPage; //Field offset: 0x0
	private int m_CountInLastPage; //Field offset: 0x0
	private Allocator m_FirstPageAllocator; //Field offset: 0x0
	private Allocator m_OtherPagesAllocator; //Field offset: 0x0
	private List<NativeSlice`1<T>> m_Enumerator; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x0

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public NativePagedList`1(int poolCapacity, Allocator firstPageAllocator = 4, Allocator otherPagesAllocator = 4) { }

	public void Add(ref T data) { }

	public void Add(T data) { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	public int GetCount() { }

	public List<NativeSlice`1<T>> GetPages() { }

	public void Reset() { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

