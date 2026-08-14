namespace Unity.VisualScripting;

[UnitOrder(502)]
public abstract class MoveTowards : Unit
{
	[CompilerGenerated]
	private ValueInput <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <maxDelta>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <result>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private bool <perSecond>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public private ValueInput current
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	protected override T defaultCurrent
	{
		 get { } //Length: 4
	}

	[DoNotSerialize]
	protected override T defaultTarget
	{
		 get { } //Length: 4
	}

	[DoNotSerialize]
	public private ValueInput maxDelta
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Per Second")]
	public bool perSecond
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
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

	[DoNotSerialize]
	public private ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected MoveTowards`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_current() { }

	protected override T get_defaultCurrent() { }

	protected override T get_defaultTarget() { }

	[CompilerGenerated]
	public ValueInput get_maxDelta() { }

	[CompilerGenerated]
	public bool get_perSecond() { }

	[CompilerGenerated]
	public ValueOutput get_result() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	private T Operation(Flow flow) { }

	public abstract T Operation(T current, T target, float maxDelta) { }

	[CompilerGenerated]
	private void set_current(ValueInput value) { }

	[CompilerGenerated]
	private void set_maxDelta(ValueInput value) { }

	[CompilerGenerated]
	public void set_perSecond(bool value) { }

	[CompilerGenerated]
	private void set_result(ValueOutput value) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

}

