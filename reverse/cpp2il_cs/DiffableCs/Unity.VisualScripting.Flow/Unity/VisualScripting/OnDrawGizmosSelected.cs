namespace Unity.VisualScripting;

[UnitCategory("Events/Editor")]
public sealed class OnDrawGizmosSelected : ManualEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnDrawGizmosSelected() { }

	protected virtual string get_hookName() { }

}

