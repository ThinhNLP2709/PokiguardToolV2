namespace Unity.VisualScripting;

public sealed class ValueInputDefinition : ValuePortDefinition, IUnitInputPortDefinition, IUnitPortDefinition
{
	[SerializeAs("defaultValue")]
	private object _defaultvalue; //Field offset: 0x38
	[CompilerGenerated]
	private bool <hasDefaultValue>k__BackingField; //Field offset: 0x40

	[DoNotSerialize]
	[Inspectable]
	public object defaultValue
	{
		 get { } //Length: 5
		 set { } //Length: 485
	}

	[Inspectable]
	[Serialize]
	public bool hasDefaultValue
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[DoNotSerialize]
	[Inspectable]
	public virtual Type type
	{
		 get { } //Length: 5
		 set { } //Length: 312
	}

	public ValueInputDefinition() { }

	public object get_defaultValue() { }

	[CompilerGenerated]
	public bool get_hasDefaultValue() { }

	public virtual Type get_type() { }

	public void set_defaultValue(object value) { }

	[CompilerGenerated]
	public void set_hasDefaultValue(bool value) { }

	public virtual void set_type(Type value) { }

}

