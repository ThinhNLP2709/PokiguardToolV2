namespace Unity.VisualScripting;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class MemberFilter : Attribute, ICloneable
{
	[CompilerGenerated]
	private bool <Fields>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <Properties>k__BackingField; //Field offset: 0x11
	[CompilerGenerated]
	private bool <Methods>k__BackingField; //Field offset: 0x12
	[CompilerGenerated]
	private bool <Constructors>k__BackingField; //Field offset: 0x13
	[CompilerGenerated]
	private bool <Gettable>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private bool <Settable>k__BackingField; //Field offset: 0x15
	[CompilerGenerated]
	private bool <Inherited>k__BackingField; //Field offset: 0x16
	[CompilerGenerated]
	private bool <Targeted>k__BackingField; //Field offset: 0x17
	[CompilerGenerated]
	private bool <NonTargeted>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private bool <Public>k__BackingField; //Field offset: 0x19
	[CompilerGenerated]
	private bool <NonPublic>k__BackingField; //Field offset: 0x1A
	[CompilerGenerated]
	private bool <ReadOnly>k__BackingField; //Field offset: 0x1B
	[CompilerGenerated]
	private bool <WriteOnly>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private bool <Extensions>k__BackingField; //Field offset: 0x1D
	[CompilerGenerated]
	private bool <Operators>k__BackingField; //Field offset: 0x1E
	[CompilerGenerated]
	private bool <Conversions>k__BackingField; //Field offset: 0x1F
	[CompilerGenerated]
	private bool <Setters>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <Parameters>k__BackingField; //Field offset: 0x21
	[CompilerGenerated]
	private bool <Obsolete>k__BackingField; //Field offset: 0x22
	[CompilerGenerated]
	private bool <OpenConstructedGeneric>k__BackingField; //Field offset: 0x23
	[CompilerGenerated]
	private bool <TypeInitializers>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private bool <ClsNonCompliant>k__BackingField; //Field offset: 0x25

	public static MemberFilter Any
	{
		 get { } //Length: 107
	}

	public bool ClsNonCompliant
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Constructors
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Conversions
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Extensions
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Fields
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Gettable
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Inherited
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Methods
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

	public bool NonTargeted
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

	public bool Operators
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Parameters
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Properties
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Public
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool ReadOnly
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Settable
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Setters
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 1011
	}

	public bool Targeted
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool TypeInitializers
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public BindingFlags validBindingFlags
	{
		 get { } //Length: 85
	}

	public MemberTypes validMemberTypes
	{
		 get { } //Length: 74
	}

	public bool WriteOnly
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public MemberFilter() { }

	public MemberFilter Clone() { }

	public virtual bool Equals(object obj) { }

	public static MemberFilter get_Any() { }

	[CompilerGenerated]
	public bool get_ClsNonCompliant() { }

	[CompilerGenerated]
	public bool get_Constructors() { }

	[CompilerGenerated]
	public bool get_Conversions() { }

	[CompilerGenerated]
	public bool get_Extensions() { }

	[CompilerGenerated]
	public bool get_Fields() { }

	[CompilerGenerated]
	public bool get_Gettable() { }

	[CompilerGenerated]
	public bool get_Inherited() { }

	[CompilerGenerated]
	public bool get_Methods() { }

	[CompilerGenerated]
	public bool get_NonPublic() { }

	[CompilerGenerated]
	public bool get_NonTargeted() { }

	[CompilerGenerated]
	public bool get_Obsolete() { }

	[CompilerGenerated]
	public bool get_OpenConstructedGeneric() { }

	[CompilerGenerated]
	public bool get_Operators() { }

	[CompilerGenerated]
	public bool get_Parameters() { }

	[CompilerGenerated]
	public bool get_Properties() { }

	[CompilerGenerated]
	public bool get_Public() { }

	[CompilerGenerated]
	public bool get_ReadOnly() { }

	[CompilerGenerated]
	public bool get_Settable() { }

	[CompilerGenerated]
	public bool get_Setters() { }

	[CompilerGenerated]
	public bool get_Targeted() { }

	[CompilerGenerated]
	public bool get_TypeInitializers() { }

	public BindingFlags get_validBindingFlags() { }

	public MemberTypes get_validMemberTypes() { }

	[CompilerGenerated]
	public bool get_WriteOnly() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	public void set_ClsNonCompliant(bool value) { }

	[CompilerGenerated]
	public void set_Constructors(bool value) { }

	[CompilerGenerated]
	public void set_Conversions(bool value) { }

	[CompilerGenerated]
	public void set_Extensions(bool value) { }

	[CompilerGenerated]
	public void set_Fields(bool value) { }

	[CompilerGenerated]
	public void set_Gettable(bool value) { }

	[CompilerGenerated]
	public void set_Inherited(bool value) { }

	[CompilerGenerated]
	public void set_Methods(bool value) { }

	[CompilerGenerated]
	public void set_NonPublic(bool value) { }

	[CompilerGenerated]
	public void set_NonTargeted(bool value) { }

	[CompilerGenerated]
	public void set_Obsolete(bool value) { }

	[CompilerGenerated]
	public void set_OpenConstructedGeneric(bool value) { }

	[CompilerGenerated]
	public void set_Operators(bool value) { }

	[CompilerGenerated]
	public void set_Parameters(bool value) { }

	[CompilerGenerated]
	public void set_Properties(bool value) { }

	[CompilerGenerated]
	public void set_Public(bool value) { }

	[CompilerGenerated]
	public void set_ReadOnly(bool value) { }

	[CompilerGenerated]
	public void set_Settable(bool value) { }

	[CompilerGenerated]
	public void set_Setters(bool value) { }

	[CompilerGenerated]
	public void set_Targeted(bool value) { }

	[CompilerGenerated]
	public void set_TypeInitializers(bool value) { }

	[CompilerGenerated]
	public void set_WriteOnly(bool value) { }

	private override object System.ICloneable.Clone() { }

	public virtual string ToString() { }

	public bool ValidateMember(MemberInfo member, TypeFilter typeFilter = null) { }

}

