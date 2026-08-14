namespace UnityEngine.Rendering;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(SerializedDictionaryDebugView`2))]
public class SerializedDictionary : SerializedDictionary<K, V, K, V>
{

	public SerializedDictionary`2() { }

	public virtual K DeserializeKey(K key) { }

	public virtual V DeserializeValue(V val) { }

	public virtual K SerializeKey(K key) { }

	public virtual V SerializeValue(V val) { }

}

