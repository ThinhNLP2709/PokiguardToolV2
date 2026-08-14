namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(3)]
[UnitTitle("On Update")]
public sealed class Update : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public Update() { }

	protected virtual string get_hookName() { }

}

