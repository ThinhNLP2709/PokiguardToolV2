namespace Unity.VisualScripting;

[UnitCategory("Events/Animation")]
public sealed class OnAnimatorMove : GameObjectEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnAnimatorMove() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

