namespace Unity.VisualScripting;

[TypeIcon(typeof(Button))]
[UnitCategory("Events/GUI")]
[UnitOrder(1)]
public sealed class OnButtonClick : GameObjectEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnButtonClick() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

