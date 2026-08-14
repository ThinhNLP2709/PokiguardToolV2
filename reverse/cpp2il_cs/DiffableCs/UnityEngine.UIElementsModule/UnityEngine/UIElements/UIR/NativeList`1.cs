namespace UnityEngine.UIElements.UIR;

internal class NativeList : IDisposable
{
	private NativeArray<T> m_NativeArray; //Field offset: 0x0
	private int m_Count; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 4
	}

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public NativeList`1(int initialCapacity) { }

	public void Add(NativeSlice<T> src) { }

	public void Clear() { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	private void Expand(int newLength) { }

	public int get_Count() { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	public NativeSlice<T> GetSlice(int start, int length) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

