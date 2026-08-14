namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(5)]
[UnitTitle("On Late Update")]
public sealed class LateUpdate : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public LateUpdate() { }

	protected virtual string get_hookName() { }

}

