namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False, Inherited = True)]
public sealed class UnitOrderAttribute : Attribute
{
	[CompilerGenerated]
	private int <order>k__BackingField; //Field offset: 0x10

	public private int order
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public UnitOrderAttribute(int order) { }

	[CompilerGenerated]
	public int get_order() { }

	[CompilerGenerated]
	private void set_order(int value) { }

}

