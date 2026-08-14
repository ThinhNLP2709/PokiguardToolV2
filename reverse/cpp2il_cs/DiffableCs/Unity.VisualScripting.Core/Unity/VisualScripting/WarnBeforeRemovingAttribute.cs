namespace Unity.VisualScripting;

[AttributeUsage(384, AllowMultiple = False, Inherited = True)]
public sealed class WarnBeforeRemovingAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string <warningTitle>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <warningMessage>k__BackingField; //Field offset: 0x18

	public string warningMessage
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string warningTitle
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public WarnBeforeRemovingAttribute(string warningTitle, string warningMessage) { }

	[CompilerGenerated]
	public string get_warningMessage() { }

	[CompilerGenerated]
	public string get_warningTitle() { }

}

