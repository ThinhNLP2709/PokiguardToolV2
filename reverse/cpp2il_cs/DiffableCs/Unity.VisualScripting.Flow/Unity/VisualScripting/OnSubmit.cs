namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(24)]
public sealed class OnSubmit : GenericGuiEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnSubmit() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

