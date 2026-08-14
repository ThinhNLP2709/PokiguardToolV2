namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(15)]
public sealed class OnPointerExit : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnPointerExit() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

