namespace Unity.VisualScripting;

[UnitCategory("Events/Application")]
public sealed class OnApplicationResume : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnApplicationResume() { }

	protected virtual string get_hookName() { }

}

