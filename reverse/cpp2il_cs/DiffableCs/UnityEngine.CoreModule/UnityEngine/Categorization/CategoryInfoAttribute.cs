namespace UnityEngine.Categorization;

[AttributeUsage(AttributeTargets::Class (4), Inherited = False, AllowMultiple = False)]
public sealed class CategoryInfoAttribute : Attribute
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <Order>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <Name>k__BackingField; //Field offset: 0x18

	public string Name
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public int Order
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public CategoryInfoAttribute() { }

	[CompilerGenerated]
	public void set_Name(string value) { }

	[CompilerGenerated]
	public void set_Order(int value) { }

}

