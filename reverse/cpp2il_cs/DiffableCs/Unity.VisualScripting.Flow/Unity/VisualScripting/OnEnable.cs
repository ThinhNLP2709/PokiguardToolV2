namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(1)]
public sealed class OnEnable : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnEnable() { }

	protected virtual string get_hookName() { }

}

