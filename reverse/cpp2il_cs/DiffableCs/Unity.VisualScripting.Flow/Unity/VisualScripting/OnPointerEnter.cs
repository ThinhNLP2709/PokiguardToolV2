namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(14)]
public sealed class OnPointerEnter : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnPointerEnter() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

