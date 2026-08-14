namespace Unity.VisualScripting;

[DefaultMember("Item")]
[IncludeInSettings(False)]
public sealed class DictionaryAsset : LudiqScriptableObject, IDictionary<String, Object>, ICollection<KeyValuePair`2<String, Object>>, IEnumerable<KeyValuePair`2<String, Object>>, IEnumerable
{
	[CompilerGenerated]
	private Dictionary<String, Object> <dictionary>k__BackingField; //Field offset: 0x30

	public override int Count
	{
		 get { } //Length: 68
	}

	[Serialize]
	public private Dictionary<String, Object> dictionary
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public override object Item
	{
		 get { } //Length: 83
		 set { } //Length: 99
	}

	public override ICollection<String> Keys
	{
		 get { } //Length: 68
	}

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly
	{
		private get { } //Length: 73
	}

	public override ICollection<Object> Values
	{
		 get { } //Length: 68
	}

	public DictionaryAsset() { }

	public override void Add(string key, object value) { }

	public override void Clear() { }

	public override bool ContainsKey(string key) { }

	public override int get_Count() { }

	[CompilerGenerated]
	public Dictionary<String, Object> get_dictionary() { }

	public override object get_Item(string key) { }

	public override ICollection<String> get_Keys() { }

	public override ICollection<Object> get_Values() { }

	public override IEnumerator<KeyValuePair`2<String, Object>> GetEnumerator() { }

	public void Merge(DictionaryAsset other, bool overwriteExisting = true) { }

	protected virtual void OnAfterDeserialize() { }

	public override bool Remove(string key) { }

	[CompilerGenerated]
	private void set_dictionary(Dictionary<String, Object> value) { }

	public override void set_Item(string key, object value) { }

	[ContextMenu("Show Data...")]
	protected virtual void ShowData() { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(KeyValuePair<String, Object> item) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(KeyValuePair<String, Object> item) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(KeyValuePair<String, Object>[] array, int arrayIndex) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.get_IsReadOnly() { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(KeyValuePair<String, Object> item) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override bool TryGetValue(string key, out object value) { }

}

