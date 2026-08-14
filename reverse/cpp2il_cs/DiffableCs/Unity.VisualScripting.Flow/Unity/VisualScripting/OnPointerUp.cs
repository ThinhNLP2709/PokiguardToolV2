namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(13)]
public sealed class OnPointerUp : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnPointerUp() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

