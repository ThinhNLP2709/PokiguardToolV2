namespace Unity.VisualScripting;

[AttributeUsage(384, AllowMultiple = False, Inherited = True)]
public sealed class WarnBeforeEditingAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string <warningTitle>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <warningMessage>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly Object[] <emptyValues>k__BackingField; //Field offset: 0x20

	public Object[] emptyValues
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

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

	public WarnBeforeEditingAttribute(string warningTitle, string warningMessage) { }

	public WarnBeforeEditingAttribute(string warningTitle, string warningMessage, Object[] emptyValues) { }

	[CompilerGenerated]
	public Object[] get_emptyValues() { }

	[CompilerGenerated]
	public string get_warningMessage() { }

	[CompilerGenerated]
	public string get_warningTitle() { }

}

