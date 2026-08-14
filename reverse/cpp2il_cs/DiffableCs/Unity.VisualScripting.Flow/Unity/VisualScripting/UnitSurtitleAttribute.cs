namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = False)]
public sealed class UnitSurtitleAttribute : Attribute
{
	[CompilerGenerated]
	private string <surtitle>k__BackingField; //Field offset: 0x10

	public private string surtitle
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public UnitSurtitleAttribute(string surtitle) { }

	[CompilerGenerated]
	public string get_surtitle() { }

	[CompilerGenerated]
	private void set_surtitle(string value) { }

}

