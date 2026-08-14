namespace UnityEngine.InputSystem;

[DebuggerDisplay("Count = {Count}")]
[DefaultMember("Item")]
public struct InputControlList : IList<TControl>, ICollection<TControl>, IEnumerable<TControl>, IEnumerable, IReadOnlyList<TControl>, IReadOnlyCollection<TControl>, IDisposable
{
	private struct Enumerator : IEnumerator<TControl>, IEnumerator, IDisposable
	{
		private readonly UInt64* m_Indices; //Field offset: 0x0
		private readonly int m_Count; //Field offset: 0x0
		private int m_Current; //Field offset: 0x0

		public override TControl Current
		{
			 get { } //Length: 140
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 54
		}

		public Enumerator(InputControlList<TControl> list) { }

		public override void Dispose() { }

		public override TControl get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private const ulong kInvalidIndex = 18446744073709551615; //Field offset: 0x0
	private int m_Count; //Field offset: 0x0
	private NativeArray<UInt64> m_Indices; //Field offset: 0x0
	private readonly Allocator m_Allocator; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 61
		 set { } //Length: 241
	}

	public override int Count
	{
		 get { } //Length: 3
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override TControl Item
	{
		 get { } //Length: 240
		 set { } //Length: 254
	}

	public InputControlList`1(Allocator allocator, int initialCapacity = 0) { }

	public InputControlList`1(IEnumerable<TControl> values, Allocator allocator = 4) { }

	public InputControlList`1(TControl[] values) { }

	public override void Add(TControl item) { }

	public void AddRange(IEnumerable<TControl> list, int count = -1, int destinationIndex = -1) { }

	public void AddSlice(TList list, int count = -1, int destinationIndex = -1, int sourceIndex = 0) { }

	internal void AppendTo(ref TControl[] array, ref int count) { }

	public override void Clear() { }

	public bool Contains(TControl item, int startIndex, int count = -1) { }

	public override bool Contains(TControl item) { }

	public override void CopyTo(TControl[] array, int arrayIndex) { }

	public override void Dispose() { }

	private static TControl FromIndex(ulong index) { }

	public int get_Capacity() { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override TControl get_Item(int index) { }

	public override IEnumerator<TControl> GetEnumerator() { }

	public override int IndexOf(TControl item) { }

	public int IndexOf(TControl item, int startIndex, int count = -1) { }

	public override void Insert(int index, TControl item) { }

	public override bool Remove(TControl item) { }

	public override void RemoveAt(int index) { }

	public void Resize(int size) { }

	public void set_Capacity(int value) { }

	public override void set_Item(int index, TControl value) { }

	public void Sort(int startIndex, int count, TCompare comparer) { }

	public void SwapElements(int index1, int index2) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public TControl[] ToArray(bool dispose = false) { }

	private static ulong ToIndex(TControl control) { }

	public virtual string ToString() { }

}

