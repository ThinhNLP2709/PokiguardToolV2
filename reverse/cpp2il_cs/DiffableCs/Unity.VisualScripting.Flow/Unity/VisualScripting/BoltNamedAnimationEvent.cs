namespace Unity.VisualScripting;

[DisplayName("Visual Scripting Named Animation Event")]
[TypeIcon(typeof(AnimationClip))]
[UnitCategory("Events/Animation")]
[UnitShortTitle("Animation Event")]
[UnitTitle("Named Animation Event")]
public sealed class BoltNamedAnimationEvent : MachineEventUnit<AnimationEvent>
{
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <floatParameter>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <intParameter>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <objectReferenceParameter>k__BackingField; //Field offset: 0xB8

	[DoNotSerialize]
	[PortLabel("Float")]
	public private ValueOutput floatParameter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	[PortLabel("Integer")]
	public private ValueOutput intParameter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Object")]
	public private ValueOutput objectReferenceParameter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public BoltNamedAnimationEvent() { }

	protected virtual void AssignArguments(Flow flow, AnimationEvent animationEvent) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_floatParameter() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueOutput get_intParameter() { }

	[CompilerGenerated]
	public ValueInput get_name() { }

	[CompilerGenerated]
	public ValueOutput get_objectReferenceParameter() { }

	[CompilerGenerated]
	private void set_floatParameter(ValueOutput value) { }

	[CompilerGenerated]
	private void set_intParameter(ValueOutput value) { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	[CompilerGenerated]
	private void set_objectReferenceParameter(ValueOutput value) { }

	protected virtual bool ShouldTrigger(Flow flow, AnimationEvent animationEvent) { }

}

