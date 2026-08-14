namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Assembly (1), AllowMultiple = True)]
public sealed class RenamedAssemblyAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string <previousName>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <newName>k__BackingField; //Field offset: 0x18

	public string newName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string previousName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public RenamedAssemblyAttribute(string previousName, string newName) { }

	[CompilerGenerated]
	public string get_newName() { }

	[CompilerGenerated]
	public string get_previousName() { }

}

