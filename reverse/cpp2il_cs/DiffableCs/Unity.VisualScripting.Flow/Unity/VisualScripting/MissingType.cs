namespace Unity.VisualScripting;

[SpecialUnit]
[UnitShortTitle("Missing Script!")]
[UnitTitle("Node script is missing!")]
public sealed class MissingType : Unit
{
	[CompilerGenerated]
	private string <formerType>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private string <formerValue>k__BackingField; //Field offset: 0x98

	[Serialize]
	public private string formerType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Serialize]
	public private string formerValue
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public MissingType() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public string get_formerType() { }

	[CompilerGenerated]
	public string get_formerValue() { }

	[CompilerGenerated]
	private void set_formerType(string value) { }

	[CompilerGenerated]
	private void set_formerValue(string value) { }

}

