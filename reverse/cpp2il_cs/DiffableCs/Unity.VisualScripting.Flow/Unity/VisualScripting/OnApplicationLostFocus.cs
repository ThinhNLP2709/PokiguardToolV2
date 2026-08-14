namespace Unity.VisualScripting;

[UnitCategory("Events/Application")]
public sealed class OnApplicationLostFocus : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnApplicationLostFocus() { }

	protected virtual string get_hookName() { }

}

