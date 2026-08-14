namespace Unity.VisualScripting;

public abstract class ValuePortDefinition : UnitPortDefinition, IUnitValuePortDefinition, IUnitPortDefinition
{
	[CompilerGenerated]
	private Type <_type>k__BackingField; //Field offset: 0x30

	[SerializeAs("_type")]
	private Type _type
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public virtual bool isValid
	{
		 get { } //Length: 90
	}

	[DoNotSerialize]
	[Inspectable]
	public override Type type
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	protected ValuePortDefinition() { }

	[CompilerGenerated]
	private Type get__type() { }

	public virtual bool get_isValid() { }

	public override Type get_type() { }

	[CompilerGenerated]
	private void set__type(Type value) { }

	public override void set_type(Type value) { }

}

