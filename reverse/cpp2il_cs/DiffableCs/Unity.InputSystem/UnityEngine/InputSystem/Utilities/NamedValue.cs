namespace UnityEngine.InputSystem.Utilities;

public struct NamedValue : IEquatable<NamedValue>
{
	public const string Separator = ","; //Field offset: 0x0
	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private PrimitiveValue <value>k__BackingField; //Field offset: 0x8

	public string name
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public TypeCode type
	{
		 get { } //Length: 4
	}

	public PrimitiveValue value
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public static void ApplyAllToObject(object instance, TParameterList parameters) { }

	public void ApplyToObject(object instance) { }

	public NamedValue ConvertTo(TypeCode type) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(NamedValue other) { }

	public static NamedValue From(string name, TValue value) { }

	[CompilerGenerated]
	[IsReadOnly]
	public string get_name() { }

	public TypeCode get_type() { }

	[CompilerGenerated]
	[IsReadOnly]
	public PrimitiveValue get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(NamedValue left, NamedValue right) { }

	public static bool op_Inequality(NamedValue left, NamedValue right) { }

	public static NamedValue Parse(string str) { }

	public static NamedValue[] ParseMultiple(string parameterString) { }

	private static NamedValue ParseParameter(string parameterString, ref int index) { }

	[CompilerGenerated]
	public void set_name(string value) { }

	[CompilerGenerated]
	public void set_value(PrimitiveValue value) { }

	public virtual string ToString() { }

}

