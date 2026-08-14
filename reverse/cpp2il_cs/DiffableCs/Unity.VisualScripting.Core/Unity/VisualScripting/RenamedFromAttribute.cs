namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::All (32767), AllowMultiple = True, Inherited = True)]
public sealed class RenamedFromAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string <previousName>k__BackingField; //Field offset: 0x10

	public string previousName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public RenamedFromAttribute(string previousName) { }

	[CompilerGenerated]
	public string get_previousName() { }

}

