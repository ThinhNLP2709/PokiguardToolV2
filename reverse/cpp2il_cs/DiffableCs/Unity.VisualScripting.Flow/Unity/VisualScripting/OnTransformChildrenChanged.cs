namespace Unity.VisualScripting;

[UnitCategory("Events/Hierarchy")]
public sealed class OnTransformChildrenChanged : GameObjectEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnTransformChildrenChanged() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

