namespace UnityEngine.InputSystem.Utilities;

[DefaultMember("Item")]
internal struct Substring : IComparable<Substring>, IEquatable<Substring>
{
	private readonly string m_String; //Field offset: 0x0
	private readonly int m_Index; //Field offset: 0x8
	private readonly int m_Length; //Field offset: 0xC

	public int index
	{
		 get { } //Length: 4
	}

	public bool isEmpty
	{
		 get { } //Length: 8
	}

	public char Item
	{
		 get { } //Length: 126
	}

	public int length
	{
		 get { } //Length: 4
	}

	public Substring(string str) { }

	public Substring(string str, int index, int length) { }

	public Substring(string str, int index) { }

	public static int Compare(Substring left, Substring right, StringComparison comparison) { }

	public override int CompareTo(Substring other) { }

	public virtual bool Equals(object obj) { }

	public bool Equals(string other) { }

	public override bool Equals(Substring other) { }

	public bool Equals(InternedString other) { }

	public int get_index() { }

	public bool get_isEmpty() { }

	public char get_Item(int index) { }

	public int get_length() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(Substring a, Substring b) { }

	public static bool op_Equality(Substring a, InternedString b) { }

	public static bool op_Equality(InternedString a, Substring b) { }

	public static Substring op_Implicit(string s) { }

	public static bool op_Inequality(Substring a, Substring b) { }

	public static bool op_Inequality(Substring a, InternedString b) { }

	public static bool op_Inequality(InternedString a, Substring b) { }

	public bool StartsWith(string str) { }

	public string Substr(int index = 0, int length = -1) { }

	public virtual string ToString() { }

}

