namespace Unity.VisualScripting;

[TypeIcon(typeof(Null))]
[UnitCategory("Nulls")]
public sealed class NullCoalesce : Unit
{
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <fallback>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <result>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	public private ValueInput fallback
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput result
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public NullCoalesce() { }

	public object Coalesce(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_fallback() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_result() { }

	[CompilerGenerated]
	private void set_fallback(ValueInput value) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_result(ValueOutput value) { }

}

