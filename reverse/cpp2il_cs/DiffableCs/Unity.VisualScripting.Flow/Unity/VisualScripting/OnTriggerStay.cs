namespace Unity.VisualScripting;

public sealed class OnTriggerStay : TriggerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnTriggerStay() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

