namespace Unity.VisualScripting;

public struct SerializationData
{
	[SerializeField]
	private string _json; //Field offset: 0x0
	[SerializeField]
	private Object[] _objectReferences; //Field offset: 0x8

	public string json
	{
		 get { } //Length: 4
	}

	public Object[] objectReferences
	{
		 get { } //Length: 5
	}

	public SerializationData(string json, IEnumerable<Object> objectReferences) { }

	public SerializationData(string json, Object[] objectReferences) { }

	internal void Clear() { }

	public string get_json() { }

	public Object[] get_objectReferences() { }

	public void ShowString(string title = null) { }

	public string ToString(string title) { }

	public virtual string ToString() { }

}

