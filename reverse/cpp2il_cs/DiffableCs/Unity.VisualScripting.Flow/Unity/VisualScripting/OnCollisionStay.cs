namespace Unity.VisualScripting;

public sealed class OnCollisionStay : CollisionEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnCollisionStay() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

