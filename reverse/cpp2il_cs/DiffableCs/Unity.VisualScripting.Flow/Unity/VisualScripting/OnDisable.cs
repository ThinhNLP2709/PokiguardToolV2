namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(6)]
public sealed class OnDisable : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnDisable() { }

	protected virtual string get_hookName() { }

}

