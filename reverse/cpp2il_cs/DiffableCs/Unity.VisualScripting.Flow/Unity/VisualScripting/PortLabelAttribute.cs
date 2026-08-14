namespace Unity.VisualScripting;

[AttributeUsage(384, AllowMultiple = False, Inherited = False)]
public class PortLabelAttribute : Attribute
{
	[CompilerGenerated]
	private string <label>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private bool <hidden>k__BackingField; //Field offset: 0x18

	public bool hidden
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public private string label
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public PortLabelAttribute(string label) { }

	[CompilerGenerated]
	public bool get_hidden() { }

	[CompilerGenerated]
	public string get_label() { }

	[CompilerGenerated]
	public void set_hidden(bool value) { }

	[CompilerGenerated]
	private void set_label(string value) { }

}

