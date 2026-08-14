namespace Unity.VisualScripting;

public sealed class GetMember : MemberUnit
{
	[CompilerGenerated]
	private ValueOutput <value>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[MemberFilter(Fields = True, Properties = True, WriteOnly = False)]
	public Member getter
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public GetMember() { }

	public GetMember(Member member) { }

	protected virtual void Definition() { }

	public Member get_getter() { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	protected virtual bool IsMemberValid(Member member) { }

	public void set_getter(Member value) { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

	private object Value(Flow flow) { }

}

