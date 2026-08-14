namespace Unity.VisualScripting;

[UnitCategory("Events/Editor")]
public sealed class OnDrawGizmos : ManualEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnDrawGizmos() { }

	protected virtual string get_hookName() { }

}

