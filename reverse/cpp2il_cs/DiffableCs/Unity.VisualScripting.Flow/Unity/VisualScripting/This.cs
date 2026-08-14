namespace Unity.VisualScripting;

[RenamedFrom("Bolt.Self")]
[RenamedFrom("Unity.VisualScripting.Self")]
[SpecialUnit]
public sealed class This : Unit
{
	[CompilerGenerated]
	private ValueOutput <self>k__BackingField; //Field offset: 0x90

	[DoNotSerialize]
	[PortLabel("This")]
	[PortLabelHidden]
	public private ValueOutput self
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public This() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_self() { }

	private bool IsPredictable(Flow flow) { }

	private GameObject Result(Flow flow) { }

	[CompilerGenerated]
	private void set_self(ValueOutput value) { }

}

