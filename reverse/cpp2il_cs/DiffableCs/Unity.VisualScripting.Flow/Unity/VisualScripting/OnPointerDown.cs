namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(12)]
public sealed class OnPointerDown : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnPointerDown() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

