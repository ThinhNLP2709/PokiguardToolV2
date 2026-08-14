namespace Unity.VisualScripting;

[DisplayName("Visual Scripting Animation Event")]
[TypeIcon(typeof(AnimationClip))]
[UnitCategory("Events/Animation")]
[UnitShortTitle("Animation Event")]
[UnitTitle("Animation Event")]
public sealed class BoltAnimationEvent : MachineEventUnit<AnimationEvent>
{
	[CompilerGenerated]
	private ValueOutput <stringParameter>k__BackingField; //Field offset: 0xA0
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
	[PortLabel("Object")]
	public private ValueOutput objectReferenceParameter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("String")]
	public private ValueOutput stringParameter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public BoltAnimationEvent() { }

	protected virtual void AssignArguments(Flow flow, AnimationEvent args) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_floatParameter() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueOutput get_intParameter() { }

	[CompilerGenerated]
	public ValueOutput get_objectReferenceParameter() { }

	[CompilerGenerated]
	public ValueOutput get_stringParameter() { }

	[CompilerGenerated]
	private void set_floatParameter(ValueOutput value) { }

	[CompilerGenerated]
	private void set_intParameter(ValueOutput value) { }

	[CompilerGenerated]
	private void set_objectReferenceParameter(ValueOutput value) { }

	[CompilerGenerated]
	private void set_stringParameter(ValueOutput value) { }

}

