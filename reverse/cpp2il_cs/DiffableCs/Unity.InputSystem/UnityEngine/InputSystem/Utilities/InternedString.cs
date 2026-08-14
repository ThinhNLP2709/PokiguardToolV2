namespace UnityEngine.InputSystem.Utilities;

public struct InternedString : IEquatable<InternedString>, IComparable<InternedString>
{
	private readonly string m_StringOriginalCase; //Field offset: 0x0
	private readonly string m_StringLowerCase; //Field offset: 0x8

	public int length
	{
		 get { } //Length: 14
	}

	public InternedString(string text) { }

	public override int CompareTo(InternedString other) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InternedString other) { }

	public int get_length() { }

	public virtual int GetHashCode() { }

	public bool IsEmpty() { }

	public static bool op_Equality(string a, InternedString b) { }

	public static bool op_Equality(InternedString a, InternedString b) { }

	public static bool op_Equality(InternedString a, string b) { }

	public static bool op_GreaterThan(InternedString left, InternedString right) { }

	public static string op_Implicit(InternedString str) { }

	public static bool op_Inequality(InternedString a, string b) { }

	public static bool op_Inequality(string a, InternedString b) { }

	public static bool op_Inequality(InternedString a, InternedString b) { }

	public static bool op_LessThan(InternedString left, InternedString right) { }

	public string ToLower() { }

	public virtual string ToString() { }

}

