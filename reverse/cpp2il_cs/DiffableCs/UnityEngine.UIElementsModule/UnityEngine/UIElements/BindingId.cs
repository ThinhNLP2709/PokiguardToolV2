namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindingId : IEquatable<BindingId>
{
	public static readonly BindingId Invalid; //Field offset: 0x0
	private readonly PropertyPath m_PropertyPath; //Field offset: 0x0
	private readonly string m_Path; //Field offset: 0x90

	private static BindingId() { }

	public BindingId(string path) { }

	public BindingId(in PropertyPath path) { }

	public override bool Equals(BindingId other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(in BindingId lhs, in BindingId rhs) { }

	public static PropertyPath op_Implicit(in BindingId vep) { }

	public static string op_Implicit(in BindingId vep) { }

	public static BindingId op_Implicit(string name) { }

	public static BindingId op_Implicit(in PropertyPath path) { }

	public static bool op_Inequality(in BindingId lhs, in BindingId rhs) { }

	public virtual string ToString() { }

}

