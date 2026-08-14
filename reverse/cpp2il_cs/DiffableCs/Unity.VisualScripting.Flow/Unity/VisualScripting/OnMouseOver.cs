namespace Unity.VisualScripting;

[UnitCategory("Events/Input")]
public sealed class OnMouseOver : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnMouseOver() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

