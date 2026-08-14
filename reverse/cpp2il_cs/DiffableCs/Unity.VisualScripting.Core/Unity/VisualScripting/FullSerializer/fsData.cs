namespace Unity.VisualScripting.FullSerializer;

public sealed class fsData
{
	public static readonly fsData True; //Field offset: 0x0
	public static readonly fsData False; //Field offset: 0x8
	public static readonly fsData Null; //Field offset: 0x10
	private object _value; //Field offset: 0x10

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public bool AsBool
	{
		 get { } //Length: 57
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public Dictionary<String, fsData> AsDictionary
	{
		 get { } //Length: 57
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public double AsDouble
	{
		 get { } //Length: 57
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public long AsInt64
	{
		 get { } //Length: 57
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public List<fsData> AsList
	{
		 get { } //Length: 57
	}

	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	public string AsString
	{
		 get { } //Length: 57
	}

	public bool IsBool
	{
		 get { } //Length: 32
	}

	public bool IsDictionary
	{
		 get { } //Length: 117
	}

	public bool IsDouble
	{
		 get { } //Length: 32
	}

	public bool IsInt64
	{
		 get { } //Length: 32
	}

	public bool IsList
	{
		 get { } //Length: 117
	}

	public bool IsNull
	{
		 get { } //Length: 9
	}

	public bool IsString
	{
		 get { } //Length: 32
	}

	public fsDataType Type
	{
		 get { } //Length: 400
	}

	private static fsData() { }

	public fsData() { }

	public fsData(bool boolean) { }

	public fsData(double f) { }

	public fsData(long i) { }

	public fsData(string str) { }

	public fsData(Dictionary<String, fsData> dict) { }

	public fsData(List<fsData> list) { }

	internal void BecomeDictionary() { }

	private T Cast() { }

	internal fsData Clone() { }

	public static fsData CreateDictionary() { }

	public static fsData CreateList() { }

	public static fsData CreateList(int capacity) { }

	public bool Equals(fsData other) { }

	public virtual bool Equals(object obj) { }

	public bool get_AsBool() { }

	public Dictionary<String, fsData> get_AsDictionary() { }

	public double get_AsDouble() { }

	public long get_AsInt64() { }

	public List<fsData> get_AsList() { }

	public string get_AsString() { }

	public bool get_IsBool() { }

	public bool get_IsDictionary() { }

	public bool get_IsDouble() { }

	public bool get_IsInt64() { }

	public bool get_IsList() { }

	public bool get_IsNull() { }

	public bool get_IsString() { }

	public fsDataType get_Type() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(fsData a, fsData b) { }

	public static bool op_Inequality(fsData a, fsData b) { }

	public virtual string ToString() { }

}

