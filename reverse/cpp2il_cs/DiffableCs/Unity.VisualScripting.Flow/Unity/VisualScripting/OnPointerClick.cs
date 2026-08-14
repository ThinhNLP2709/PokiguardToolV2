namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(11)]
public sealed class OnPointerClick : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnPointerClick() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

