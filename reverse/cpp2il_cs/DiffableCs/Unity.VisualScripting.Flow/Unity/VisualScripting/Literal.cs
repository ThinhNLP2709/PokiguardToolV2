namespace Unity.VisualScripting;

[SpecialUnit]
public sealed class Literal : Unit
{
	[SerializeAs("value")]
	private object _value; //Field offset: 0x90
	[CompilerGenerated]
	private Type <type>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0xA0

	public virtual bool canDefine
	{
		 get { } //Length: 52
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Serialize]
	public internal Type type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 19
	}

	[DoNotSerialize]
	public object value
	{
		 get { } //Length: 8
		 set { } //Length: 170
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public Literal() { }

	public Literal(Type type) { }

	public Literal(Type type, object value) { }

	[CompilerGenerated]
	private object <Definition>b__17_0(Flow flow) { }

	protected virtual void Definition() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	[CompilerGenerated]
	public Type get_type() { }

	public object get_value() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

	[CompilerGenerated]
	internal void set_type(Type value) { }

	public void set_value(object value) { }

}

