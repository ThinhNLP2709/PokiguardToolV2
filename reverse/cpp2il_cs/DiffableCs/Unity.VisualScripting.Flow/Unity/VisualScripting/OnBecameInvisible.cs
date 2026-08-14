namespace Unity.VisualScripting;

[UnitCategory("Events/Rendering")]
public sealed class OnBecameInvisible : GameObjectEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnBecameInvisible() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

}

