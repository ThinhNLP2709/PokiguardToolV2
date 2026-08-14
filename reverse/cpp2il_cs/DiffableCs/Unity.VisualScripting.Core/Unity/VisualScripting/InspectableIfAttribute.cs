namespace Unity.VisualScripting;

[AttributeUsage(396, AllowMultiple = False, Inherited = True)]
public sealed class InspectableIfAttribute : Attribute, IInspectableAttribute
{
	[CompilerGenerated]
	private int <order>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <conditionMember>k__BackingField; //Field offset: 0x18

	public string conditionMember
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override int order
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public InspectableIfAttribute(string conditionMember) { }

	[CompilerGenerated]
	public string get_conditionMember() { }

	[CompilerGenerated]
	public override int get_order() { }

	[CompilerGenerated]
	public void set_order(int value) { }

}

