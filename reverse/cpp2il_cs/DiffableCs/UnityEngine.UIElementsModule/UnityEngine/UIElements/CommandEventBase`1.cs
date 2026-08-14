namespace UnityEngine.UIElements;

[EventCategory(EventCategory::Command (15))]
public abstract class CommandEventBase : EventBase<T>
{
	private string m_CommandName; //Field offset: 0x0

	public override string commandName
	{
		 get { } //Length: 73
		 set { } //Length: 13
	}

	protected CommandEventBase`1() { }

	internal virtual void Dispatch(BaseVisualElementPanel panel) { }

	public override string get_commandName() { }

	public static T GetPooled(Event systemEvent) { }

	public static T GetPooled(string commandName) { }

	protected virtual void Init() { }

	private void LocalInit() { }

	protected void set_commandName(string value) { }

}

