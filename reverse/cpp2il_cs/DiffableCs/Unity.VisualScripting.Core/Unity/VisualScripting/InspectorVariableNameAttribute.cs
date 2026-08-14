namespace Unity.VisualScripting;

[AttributeUsage(2432, AllowMultiple = False, Inherited = True)]
public sealed class InspectorVariableNameAttribute : Attribute
{
	[CompilerGenerated]
	private ActionDirection <direction>k__BackingField; //Field offset: 0x10

	public private ActionDirection direction
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public InspectorVariableNameAttribute(ActionDirection direction) { }

	[CompilerGenerated]
	public ActionDirection get_direction() { }

	[CompilerGenerated]
	private void set_direction(ActionDirection value) { }

}

