namespace Unity.VisualScripting;

[UnitCategory("Events/Application")]
public sealed class OnApplicationFocus : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnApplicationFocus() { }

	protected virtual string get_hookName() { }

}

