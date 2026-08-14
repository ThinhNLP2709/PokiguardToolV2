namespace Unity.VisualScripting;

[UnitCategory("Events/Input")]
public sealed class OnMouseDrag : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnMouseDrag() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

