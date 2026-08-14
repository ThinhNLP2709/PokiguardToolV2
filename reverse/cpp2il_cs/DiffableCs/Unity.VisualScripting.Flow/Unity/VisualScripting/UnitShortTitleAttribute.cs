namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = True)]
public sealed class UnitShortTitleAttribute : Attribute
{
	[CompilerGenerated]
	private string <title>k__BackingField; //Field offset: 0x10

	public private string title
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public UnitShortTitleAttribute(string title) { }

	[CompilerGenerated]
	public string get_title() { }

	[CompilerGenerated]
	private void set_title(string value) { }

}

