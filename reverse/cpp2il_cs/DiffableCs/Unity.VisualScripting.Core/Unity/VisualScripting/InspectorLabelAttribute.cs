namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::All (32767), AllowMultiple = False, Inherited = True)]
public sealed class InspectorLabelAttribute : Attribute
{
	[CompilerGenerated]
	private string <text>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <tooltip>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Texture <image>k__BackingField; //Field offset: 0x20

	public Texture image
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public private string text
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string tooltip
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public InspectorLabelAttribute(string text) { }

	public InspectorLabelAttribute(string text, string tooltip) { }

	[CompilerGenerated]
	public Texture get_image() { }

	[CompilerGenerated]
	public string get_text() { }

	[CompilerGenerated]
	public string get_tooltip() { }

	[CompilerGenerated]
	public void set_image(Texture value) { }

	[CompilerGenerated]
	private void set_text(string value) { }

	[CompilerGenerated]
	private void set_tooltip(string value) { }

}

