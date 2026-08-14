namespace UnityEngine.UIElements;

[DefaultMember("Item")]
internal class ReadOnlyHierarchyViewModelList : IList, ICollection, IEnumerable
{
	private struct Enumerator : IEnumerator
	{
		private readonly HierarchyViewModel m_HierarchyViewModel; //Field offset: 0x0
		private Enumerator m_Enumerator; //Field offset: 0x8

		public override object Current
		{
			 get { } //Length: 191
		}

		public Enumerator(HierarchyViewModel hierarchyViewModel) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	private readonly HierarchyViewModel m_HierarchyViewModel; //Field offset: 0x10

	public override int Count
	{
		 get { } //Length: 26
	}

	public override bool IsFixedSize
	{
		 get { } //Length: 3
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override bool IsSynchronized
	{
		 get { } //Length: 62
	}

	public override object Item
	{
		 get { } //Length: 103
		 set { } //Length: 62
	}

	public override object SyncRoot
	{
		 get { } //Length: 62
	}

	public ReadOnlyHierarchyViewModelList(HierarchyViewModel viewModel) { }

	public override int Add(object value) { }

	public override void Clear() { }

	public override bool Contains(object value) { }

	public override void CopyTo(Array array, int index) { }

	public override int get_Count() { }

	public override bool get_IsFixedSize() { }

	public override bool get_IsReadOnly() { }

	public override bool get_IsSynchronized() { }

	public override object get_Item(int index) { }

	public override object get_SyncRoot() { }

	public override IEnumerator GetEnumerator() { }

	public override int IndexOf(object value) { }

	public override void Insert(int index, object value) { }

	public override void Remove(object value) { }

	public override void RemoveAt(int index) { }

	public override void set_Item(int index, object value) { }

}

