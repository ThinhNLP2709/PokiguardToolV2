namespace Unity.Properties;

[IsReadOnly]
public struct PropertyPathPart : IEquatable<PropertyPathPart>
{
	private readonly PropertyPathPartKind m_Kind; //Field offset: 0x0
	private readonly string m_Name; //Field offset: 0x8
	private readonly int m_Index; //Field offset: 0x10
	private readonly object m_Key; //Field offset: 0x18

	public int Index
	{
		 get { } //Length: 83
	}

	public bool IsIndex
	{
		 get { } //Length: 7
	}

	public bool IsName
	{
		 get { } //Length: 7
	}

	public object Key
	{
		 get { } //Length: 84
	}

	public PropertyPathPartKind Kind
	{
		 get { } //Length: 3
	}

	public string Name
	{
		 get { } //Length: 84
	}

	public PropertyPathPart(string name) { }

	public PropertyPathPart(int index) { }

	public PropertyPathPart(object key) { }

	private void CheckKind(PropertyPathPartKind type) { }

	public override bool Equals(PropertyPathPart other) { }

	public virtual bool Equals(object obj) { }

	public int get_Index() { }

	public bool get_IsIndex() { }

	public bool get_IsName() { }

	public object get_Key() { }

	public PropertyPathPartKind get_Kind() { }

	public string get_Name() { }

	public virtual int GetHashCode() { }

	public virtual string ToString() { }

}

