namespace Unity.VisualScripting;

[TypeIcon(typeof(GUI))]
[UnitCategory("Events/GUI")]
[UnitOrder(0)]
public sealed class OnGUI : GlobalEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnGUI() { }

	protected virtual string get_hookName() { }

}

