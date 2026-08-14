namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(20)]
public sealed class OnScroll : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnScroll() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

