namespace Unity.VisualScripting;

[TypeIcon(typeof(OnDrag))]
[UnitCategory("Events/GUI")]
[UnitOrder(19)]
public sealed class OnDrop : PointerEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnDrop() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

