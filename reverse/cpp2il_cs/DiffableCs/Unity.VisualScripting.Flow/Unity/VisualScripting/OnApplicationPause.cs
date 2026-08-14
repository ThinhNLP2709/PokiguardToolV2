namespace Unity.VisualScripting;

[UnitCategory("Events/Application")]
public sealed class OnApplicationPause : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnApplicationPause() { }

	protected virtual string get_hookName() { }

}

