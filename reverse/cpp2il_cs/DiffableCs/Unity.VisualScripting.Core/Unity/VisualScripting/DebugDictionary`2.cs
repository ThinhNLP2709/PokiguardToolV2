namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class DebugDictionary : IDictionary<TKey, TValue>, ICollection<KeyValuePair`2<TKey, TValue>>, IEnumerable<KeyValuePair`2<TKey, TValue>>, IEnumerable, IDictionary, ICollection
{
	private readonly Dictionary<TKey, TValue> dictionary; //Field offset: 0x0
	[CompilerGenerated]
	private string <label>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private bool <debug>k__BackingField; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 46
	}

	public bool debug
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 1011
	}

	public override TValue Item
	{
		 get { } //Length: 306
		 set { } //Length: 638
	}

	public override ICollection<TKey> Keys
	{
		 get { } //Length: 46
	}

	public string label
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly
	{
		private get { } //Length: 73
	}

	private override bool System.Collections.ICollection.IsSynchronized
	{
		private get { } //Length: 73
	}

	private override object System.Collections.ICollection.SyncRoot
	{
		private get { } //Length: 73
	}

	private override bool System.Collections.IDictionary.IsFixedSize
	{
		private get { } //Length: 73
	}

	private override bool System.Collections.IDictionary.IsReadOnly
	{
		private get { } //Length: 73
	}

	private override object System.Collections.IDictionary.Item
	{
		private get { } //Length: 313
		private set { } //Length: 378
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
		 get { } //Length: 46
	}

	public DebugDictionary`2() { }

	public override void Add(TKey key, TValue value) { }

	public override void Clear() { }

	public override bool Contains(KeyValuePair<TKey, TValue> item) { }

	public override bool ContainsKey(TKey key) { }

	private void Debug(string message) { }

	public override int get_Count() { }

	[CompilerGenerated]
	public bool get_debug() { }

	public override TValue get_Item(TKey key) { }

	public override ICollection<TKey> get_Keys() { }

	[CompilerGenerated]
	public string get_label() { }

	public override ICollection<TValue> get_Values() { }

	public override IEnumerator<KeyValuePair`2<TKey, TValue>> GetEnumerator() { }

	public override bool Remove(TKey key) { }

	[CompilerGenerated]
	public void set_debug(bool value) { }

	public override void set_Item(TKey key, TValue value) { }

	[CompilerGenerated]
	public void set_label(string value) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Add(KeyValuePair<TKey, TValue> item) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.get_IsReadOnly() { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> item) { }

	private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

	private override bool System.Collections.ICollection.get_IsSynchronized() { }

	private override object System.Collections.ICollection.get_SyncRoot() { }

	private override void System.Collections.IDictionary.Add(object key, object value) { }

	private override bool System.Collections.IDictionary.Contains(object key) { }

	private override bool System.Collections.IDictionary.get_IsFixedSize() { }

	private override bool System.Collections.IDictionary.get_IsReadOnly() { }

	private override object System.Collections.IDictionary.get_Item(object key) { }

	private override ICollection System.Collections.IDictionary.get_Keys() { }

	private override ICollection System.Collections.IDictionary.get_Values() { }

	private override IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() { }

	private override void System.Collections.IDictionary.Remove(object key) { }

	private override void System.Collections.IDictionary.set_Item(object key, object value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override bool TryGetValue(TKey key, out TValue value) { }

}

