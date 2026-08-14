namespace Unity.VisualScripting;

[UnitCategory("Events/Hierarchy")]
public sealed class OnTransformParentChanged : GameObjectEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnTransformParentChanged() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

