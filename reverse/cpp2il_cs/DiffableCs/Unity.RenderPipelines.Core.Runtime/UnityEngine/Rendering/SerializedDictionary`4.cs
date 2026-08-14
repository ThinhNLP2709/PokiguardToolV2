namespace UnityEngine.Rendering;

public abstract class SerializedDictionary : Dictionary<K, V>, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<SK> m_Keys; //Field offset: 0x0
	[SerializeField]
	private List<SV> m_Values; //Field offset: 0x0

	protected SerializedDictionary`4() { }

	public abstract K DeserializeKey(SK serializedKey) { }

	public abstract V DeserializeValue(SV serializedValue) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	public abstract SK SerializeKey(K key) { }

	public abstract SV SerializeValue(V value) { }

}

