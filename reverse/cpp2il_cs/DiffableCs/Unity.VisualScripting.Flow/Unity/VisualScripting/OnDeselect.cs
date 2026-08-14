namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(23)]
public sealed class OnDeselect : GenericGuiEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnDeselect() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

