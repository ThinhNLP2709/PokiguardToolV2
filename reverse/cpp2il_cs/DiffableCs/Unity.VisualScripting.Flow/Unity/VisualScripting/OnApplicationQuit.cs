namespace Unity.VisualScripting;

[UnitCategory("Events/Application")]
public sealed class OnApplicationQuit : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnApplicationQuit() { }

	protected virtual string get_hookName() { }

}

