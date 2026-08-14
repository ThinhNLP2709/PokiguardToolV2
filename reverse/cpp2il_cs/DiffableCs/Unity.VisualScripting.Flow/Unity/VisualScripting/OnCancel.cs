namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(25)]
public sealed class OnCancel : GenericGuiEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnCancel() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

