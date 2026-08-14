namespace Unity.VisualScripting;

public sealed class OnTriggerEnter : TriggerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnTriggerEnter() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

