namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(4)]
[UnitTitle("On Fixed Update")]
public sealed class FixedUpdate : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public FixedUpdate() { }

	protected virtual string get_hookName() { }

}

