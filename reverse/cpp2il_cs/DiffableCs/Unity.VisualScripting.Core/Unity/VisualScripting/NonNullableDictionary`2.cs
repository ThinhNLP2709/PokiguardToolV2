namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class NonNullableDictionary : IDictionary<TKey, TValue>, ICollection<KeyValuePair`2<TKey, TValue>>, IEnumerable<KeyValuePair`2<TKey, TValue>>, IEnumerable, IDictionary, ICollection
{
	private readonly Dictionary<TKey, TValue> dictionary; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 46
	}

	public override bool IsFixedSize
	{
		 get { } //Length: 73
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override bool IsSynchronized
	{
		 get { } //Length: 73
	}

	public override TValue Item
	{
		 get { } //Length: 306
		 set { } //Length: 368
	}

	public override ICollection<TKey> Keys
	{
		 get { } //Length: 46
	}

	public override object SyncRoot
	{
		 get { } //Length: 73
	}

	private override object System.Collections.IDictionary.Item
	{
		private get { } //Length: 187
		private set { } //Length: 107
	}

	private override ICollection System.Collections.IDictionary.Keys
	{
		private get { } //Length: 73
	}

	private override ICollection System.Collections.IDictionary.Values
	{
		private get { } //Length: 73
	}

	public override ICollection<TValue> Values
	{
		 get { } //Length: 49
	}

	public NonNullableDictionary`2() { }

	public NonNullableDictionary`2(int capacity) { }

	public NonNullableDictionary`2(IEqualityComparer<TKey> comparer) { }

	public NonNullableDictionary`2(IDictionary<TKey, TValue> dictionary) { }

	public NonNullableDictionary`2(int capacity, IEqualityComparer<TKey> comparer) { }

	public NonNullableDictionary`2(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) { }

	public override void Add(TKey key, TValue value) { }

	public override void Add(object key, object value) { }

	public override void Clear() { }

	public override bool Contains(object key) { }

	public override bool ContainsKey(TKey key) { }

	public override void CopyTo(Array array, int index) { }

	public override int get_Count() { }

	public override bool get_IsFixedSize() { }

	public override bool get_IsReadOnly() { }

	public override bool get_IsSynchronized() { }

	public override TValue get_Item(TKey key) { }

	public override ICollection<TKey> get_Keys() { }

	public override object get_SyncRoot() { }

	public override ICollection<TValue> get_Values() { }

	public override IEnumerator<KeyValuePair`2<TKey, TValue>> GetEnumerator() { }

	public override void Remove(object key) { }

	public override bool Remove(TKey key) { }

	public override void set_Item(TKey key, TValue value) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Add(KeyValuePair<TKey, TValue> item) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Contains(KeyValuePair<TKey, TValue> item) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> item) { }

	private override object System.Collections.IDictionary.get_Item(object key) { }

	private override ICollection System.Collections.IDictionary.get_Keys() { }

	private override ICollection System.Collections.IDictionary.get_Values() { }

	private override IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() { }

	private override void System.Collections.IDictionary.set_Item(object key, object value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override bool TryGetValue(TKey key, out TValue value) { }

}

