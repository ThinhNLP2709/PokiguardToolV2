namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(17)]
public sealed class OnDrag : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnDrag() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

