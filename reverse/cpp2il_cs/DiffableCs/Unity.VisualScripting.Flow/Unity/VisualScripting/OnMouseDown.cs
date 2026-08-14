namespace Unity.VisualScripting;

[UnitCategory("Events/Input")]
public sealed class OnMouseDown : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnMouseDown() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

