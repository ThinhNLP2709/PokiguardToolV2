namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(22)]
public sealed class OnSelect : GenericGuiEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnSelect() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

