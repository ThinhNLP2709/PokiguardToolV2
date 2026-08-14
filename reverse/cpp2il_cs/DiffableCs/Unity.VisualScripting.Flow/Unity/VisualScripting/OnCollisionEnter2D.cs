namespace Unity.VisualScripting;

public sealed class OnCollisionEnter2D : CollisionEvent2DUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnCollisionEnter2D() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

