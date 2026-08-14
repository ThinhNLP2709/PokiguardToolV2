namespace Unity.VisualScripting;

public sealed class SetMember : MemberUnit
{
	[CompilerGenerated]
	private bool <chainable>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlInput <assign>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <targetOutput>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ControlOutput <assigned>k__BackingField; //Field offset: 0xC8

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlInput assign
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput assigned
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[InspectableIf("supportsChaining")]
	[Serialize]
	public bool chainable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	[PortLabel("Value")]
	[PortLabelHidden]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Value")]
	[PortLabelHidden]
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[MemberFilter(Fields = True, Properties = True, ReadOnly = False)]
	public Member setter
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	[DoNotSerialize]
	public bool supportsChaining
	{
		 get { } //Length: 32
	}

	[DoNotSerialize]
	[PortLabel("Target")]
	[PortLabelHidden]
	public private ValueOutput targetOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SetMember() { }

	public SetMember(Member member) { }

	private ControlOutput Assign(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_assign() { }

	[CompilerGenerated]
	public ControlOutput get_assigned() { }

	[CompilerGenerated]
	public bool get_chainable() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	public Member get_setter() { }

	public bool get_supportsChaining() { }

	[CompilerGenerated]
	public ValueOutput get_targetOutput() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	private object GetAndChainTarget(Flow flow) { }

	protected virtual bool IsMemberValid(Member member) { }

	[CompilerGenerated]
	private void set_assign(ControlInput value) { }

	[CompilerGenerated]
	private void set_assigned(ControlOutput value) { }

	[CompilerGenerated]
	public void set_chainable(bool value) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

	public void set_setter(Member value) { }

	[CompilerGenerated]
	private void set_targetOutput(ValueOutput value) { }

}

