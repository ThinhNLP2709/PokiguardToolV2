namespace Unity.VisualScripting;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class TypeFilter : Attribute, ICloneable
{
	private readonly HashSet<Type> types; //Field offset: 0x10
	[CompilerGenerated]
	private TypesMatching <Matching>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <Value>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private bool <Reference>k__BackingField; //Field offset: 0x1D
	[CompilerGenerated]
	private bool <Classes>k__BackingField; //Field offset: 0x1E
	[CompilerGenerated]
	private bool <Interfaces>k__BackingField; //Field offset: 0x1F
	[CompilerGenerated]
	private bool <Structs>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <Enums>k__BackingField; //Field offset: 0x21
	[CompilerGenerated]
	private bool <Public>k__BackingField; //Field offset: 0x22
	[CompilerGenerated]
	private bool <NonPublic>k__BackingField; //Field offset: 0x23
	[CompilerGenerated]
	private bool <Abstract>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private bool <Generic>k__BackingField; //Field offset: 0x25
	[CompilerGenerated]
	private bool <OpenConstructedGeneric>k__BackingField; //Field offset: 0x26
	[CompilerGenerated]
	private bool <Static>k__BackingField; //Field offset: 0x27
	[CompilerGenerated]
	private bool <Sealed>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <Nested>k__BackingField; //Field offset: 0x29
	[CompilerGenerated]
	private bool <Primitives>k__BackingField; //Field offset: 0x2A
	[CompilerGenerated]
	private bool <Object>k__BackingField; //Field offset: 0x2B
	[CompilerGenerated]
	private bool <NonSerializable>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	private bool <Obsolete>k__BackingField; //Field offset: 0x2D

	public bool Abstract
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public static TypeFilter Any
	{
		 get { } //Length: 194
	}

	public bool Classes
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Enums
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool ExpectsBoolean
	{
		 get { } //Length: 163
	}

	public bool Generic
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Interfaces
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public TypesMatching Matching
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Nested
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool NonPublic
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool NonSerializable
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Object
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Obsolete
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool OpenConstructedGeneric
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Primitives
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 170
	}

	public bool Public
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Reference
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Sealed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Static
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Structs
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 1011
	}

	public HashSet<Type> Types
	{
		 get { } //Length: 5
	}

	public bool Value
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public TypeFilter(TypesMatching matching, IEnumerable<Type> types) { }

	public TypeFilter(TypesMatching matching, Type[] types) { }

	public TypeFilter(IEnumerable<Type> types) { }

	public TypeFilter(Type[] types) { }

	public TypeFilter Clone() { }

	public virtual bool Equals(object obj) { }

	[CompilerGenerated]
	public bool get_Abstract() { }

	public static TypeFilter get_Any() { }

	[CompilerGenerated]
	public bool get_Classes() { }

	[CompilerGenerated]
	public bool get_Enums() { }

	public bool get_ExpectsBoolean() { }

	[CompilerGenerated]
	public bool get_Generic() { }

	[CompilerGenerated]
	public bool get_Interfaces() { }

	[CompilerGenerated]
	public TypesMatching get_Matching() { }

	[CompilerGenerated]
	public bool get_Nested() { }

	[CompilerGenerated]
	public bool get_NonPublic() { }

	[CompilerGenerated]
	public bool get_NonSerializable() { }

	[CompilerGenerated]
	public bool get_Object() { }

	[CompilerGenerated]
	public bool get_Obsolete() { }

	[CompilerGenerated]
	public bool get_OpenConstructedGeneric() { }

	[CompilerGenerated]
	public bool get_Primitives() { }

	[CompilerGenerated]
	public bool get_Public() { }

	[CompilerGenerated]
	public bool get_Reference() { }

	[CompilerGenerated]
	public bool get_Sealed() { }

	[CompilerGenerated]
	public bool get_Static() { }

	[CompilerGenerated]
	public bool get_Structs() { }

	public HashSet<Type> get_Types() { }

	[CompilerGenerated]
	public bool get_Value() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	public void set_Abstract(bool value) { }

	[CompilerGenerated]
	public void set_Classes(bool value) { }

	[CompilerGenerated]
	public void set_Enums(bool value) { }

	[CompilerGenerated]
	public void set_Generic(bool value) { }

	[CompilerGenerated]
	public void set_Interfaces(bool value) { }

	[CompilerGenerated]
	public void set_Matching(TypesMatching value) { }

	[CompilerGenerated]
	public void set_Nested(bool value) { }

	[CompilerGenerated]
	public void set_NonPublic(bool value) { }

	[CompilerGenerated]
	public void set_NonSerializable(bool value) { }

	[CompilerGenerated]
	public void set_Object(bool value) { }

	[CompilerGenerated]
	public void set_Obsolete(bool value) { }

	[CompilerGenerated]
	public void set_OpenConstructedGeneric(bool value) { }

	[CompilerGenerated]
	public void set_Primitives(bool value) { }

	[CompilerGenerated]
	public void set_Public(bool value) { }

	[CompilerGenerated]
	public void set_Reference(bool value) { }

	[CompilerGenerated]
	public void set_Sealed(bool value) { }

	[CompilerGenerated]
	public void set_Static(bool value) { }

	[CompilerGenerated]
	public void set_Structs(bool value) { }

	[CompilerGenerated]
	public void set_Value(bool value) { }

	private override object System.ICloneable.Clone() { }

	public virtual string ToString() { }

	public bool ValidateType(Type type) { }

}

