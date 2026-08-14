namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(4)]
[UnitShortTitle("Switch")]
[UnitSubtitle("On String")]
[UnitTitle("Switch On String")]
public class SwitchOnString : SwitchUnit<String>
{
	[CompilerGenerated]
	private bool <ignoreCase>k__BackingField; //Field offset: 0xB8

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Ignore Case")]
	public bool ignoreCase
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public SwitchOnString() { }

	[CompilerGenerated]
	public bool get_ignoreCase() { }

	protected virtual bool Matches(string a, string b) { }

	[CompilerGenerated]
	public void set_ignoreCase(bool value) { }

}

