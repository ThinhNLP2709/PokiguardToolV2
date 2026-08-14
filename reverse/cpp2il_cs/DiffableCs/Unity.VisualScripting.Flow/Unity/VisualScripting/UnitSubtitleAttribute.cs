namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = False)]
public sealed class UnitSubtitleAttribute : Attribute
{
	[CompilerGenerated]
	private string <subtitle>k__BackingField; //Field offset: 0x10

	public private string subtitle
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public UnitSubtitleAttribute(string subtitle) { }

	[CompilerGenerated]
	public string get_subtitle() { }

	[CompilerGenerated]
	private void set_subtitle(string value) { }

}

