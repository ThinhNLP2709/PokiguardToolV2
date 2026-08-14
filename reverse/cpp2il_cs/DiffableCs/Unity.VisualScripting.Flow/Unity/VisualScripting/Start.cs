namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(2)]
[UnitTitle("On Start")]
public sealed class Start : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public Start() { }

	protected virtual string get_hookName() { }

}

