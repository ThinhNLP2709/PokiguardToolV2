namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(7)]
[UnitShortTitle("Select")]
[UnitSubtitle("On String")]
[UnitTitle("Select On String")]
public class SelectOnString : SelectUnit<String>
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

	public SelectOnString() { }

	[CompilerGenerated]
	public bool get_ignoreCase() { }

	protected virtual bool Matches(string a, string b) { }

	[CompilerGenerated]
	public void set_ignoreCase(bool value) { }

}

