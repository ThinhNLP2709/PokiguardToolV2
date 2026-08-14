namespace Unity.VisualScripting;

[UnitCategory("Events/Animation")]
public sealed class OnAnimatorIK : GameObjectEventUnit<Int32>
{
	[CompilerGenerated]
	private ValueOutput <layerIndex>k__BackingField; //Field offset: 0xA8

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	public private ValueOutput layerIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnAnimatorIK() { }

	protected virtual void AssignArguments(Flow flow, int layerIndex) { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueOutput get_layerIndex() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	private void set_layerIndex(ValueOutput value) { }

}

