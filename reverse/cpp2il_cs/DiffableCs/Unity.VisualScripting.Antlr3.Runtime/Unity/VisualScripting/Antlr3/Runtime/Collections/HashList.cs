namespace Unity.VisualScripting.Antlr3.Runtime.Collections;

[DefaultMember("Item")]
public sealed class HashList : IDictionary, ICollection, IEnumerable
{
	private sealed class HashListEnumerator : IDictionaryEnumerator, IEnumerator
	{
		public enum EnumerationMode
		{
			Key = 0,
			Value = 1,
			Entry = 2,
		}

		private HashList _hashList; //Field offset: 0x10
		private List<Object> _orderList; //Field offset: 0x18
		private EnumerationMode _mode; //Field offset: 0x20
		private int _index; //Field offset: 0x24
		private int _version; //Field offset: 0x28
		private object _key; //Field offset: 0x30
		private object _value; //Field offset: 0x38

		public override object Current
		{
			 get { } //Length: 204
		}

		public override DictionaryEntry Entry
		{
			 get { } //Length: 122
		}

		public override object Key
		{
			 get { } //Length: 102
		}

		public override object Value
		{
			 get { } //Length: 102
		}

		internal HashListEnumerator() { }

		internal HashListEnumerator(HashList hashList, EnumerationMode mode) { }

		public override object get_Current() { }

		public override DictionaryEntry get_Entry() { }

		public override object get_Key() { }

		public override object get_Value() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	private sealed class KeyCollection : ICollection, IEnumerable
	{
		private HashList _hashList; //Field offset: 0x10

		public override int Count
		{
			 get { } //Length: 51
		}

		public override bool IsSynchronized
		{
			 get { } //Length: 51
		}

		public override object SyncRoot
		{
			 get { } //Length: 51
		}

		internal KeyCollection() { }

		internal KeyCollection(HashList hashList) { }

		public override void CopyTo(Array array, int index) { }

		public virtual bool Equals(object o) { }

		public override int get_Count() { }

		public override bool get_IsSynchronized() { }

		public override object get_SyncRoot() { }

		public override IEnumerator GetEnumerator() { }

		public virtual int GetHashCode() { }

		public virtual string ToString() { }

	}

	private sealed class ValueCollection : ICollection, IEnumerable
	{
		private HashList _hashList; //Field offset: 0x10

		public override int Count
		{
			 get { } //Length: 51
		}

		public override bool IsSynchronized
		{
			 get { } //Length: 51
		}

		public override object SyncRoot
		{
			 get { } //Length: 51
		}

		internal ValueCollection() { }

		internal ValueCollection(HashList hashList) { }

		public override void CopyTo(Array array, int index) { }

		public override int get_Count() { }

		public override bool get_IsSynchronized() { }

		public override object get_SyncRoot() { }

		public override IEnumerator GetEnumerator() { }

		public virtual string ToString() { }

	}

	private Hashtable _dictionary; //Field offset: 0x10
	private List<Object> _insertionOrderList; //Field offset: 0x18
	private int _version; //Field offset: 0x20

	public override int Count
	{
		 get { } //Length: 42
	}

	public override bool IsFixedSize
	{
		 get { } //Length: 42
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 42
	}

	public override bool IsSynchronized
	{
		 get { } //Length: 42
	}

	public override object Item
	{
		 get { } //Length: 42
		 set { } //Length: 184
	}

	public override ICollection Keys
	{
		 get { } //Length: 96
	}

	public override object SyncRoot
	{
		 get { } //Length: 42
	}

	public override ICollection Values
	{
		 get { } //Length: 96
	}

	public HashList() { }

	public HashList(int capacity) { }

	public override void Add(object key, object value) { }

	public override void Clear() { }

	public override bool Contains(object key) { }

	private void CopyKeysTo(Array array, int index) { }

	public override void CopyTo(Array array, int index) { }

	private void CopyValuesTo(Array array, int index) { }

	public override int get_Count() { }

	public override bool get_IsFixedSize() { }

	public override bool get_IsReadOnly() { }

	public override bool get_IsSynchronized() { }

	public override object get_Item(object key) { }

	public override ICollection get_Keys() { }

	public override object get_SyncRoot() { }

	public override ICollection get_Values() { }

	public override IDictionaryEnumerator GetEnumerator() { }

	public override void Remove(object key) { }

	public override void set_Item(object key, object value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

