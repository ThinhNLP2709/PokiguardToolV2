namespace Unity.VisualScripting;

public class MergedList : IMergedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private Enumerator<Type, IList<T>> listsEnumerator; //Field offset: 0x0
		private T currentItem; //Field offset: 0x0
		private IList<T> currentList; //Field offset: 0x0
		private int indexInCurrentList; //Field offset: 0x0
		private bool exceeded; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 209
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 362
		}

		public Enumerator(MergedList<T> merged) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

	}

	protected readonly Dictionary<Type, IList`1<T>> lists; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 616
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public MergedList`1() { }

	public override void Add(T item) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public IList<TI> ForType() { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public Enumerator<T> GetEnumerator() { }

	protected IList<T> GetListForItem(T item) { }

	protected IList<T> GetListForType(Type type, bool throwOnFail = true) { }

	public override void Include(IList<TI> list) { }

	public override bool Includes(Type elementType) { }

	public override bool Includes() { }

	public override bool Remove(T item) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

