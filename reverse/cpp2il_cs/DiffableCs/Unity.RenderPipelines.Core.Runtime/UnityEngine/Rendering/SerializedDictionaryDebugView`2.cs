namespace UnityEngine.Rendering;

internal sealed class SerializedDictionaryDebugView
{
	private IDictionary<K, V> dict; //Field offset: 0x0

	[DebuggerBrowsable(DebuggerBrowsableState::RootHidden (3))]
	public KeyValuePair<K, V>[] Items
	{
		 get { } //Length: 436
	}

	public SerializedDictionaryDebugView`2(IDictionary<K, V> dictionary) { }

	public KeyValuePair<K, V>[] get_Items() { }

}

