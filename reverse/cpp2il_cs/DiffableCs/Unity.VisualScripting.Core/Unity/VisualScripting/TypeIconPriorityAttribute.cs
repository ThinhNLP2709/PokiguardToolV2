namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Interface (1024), AllowMultiple = False, Inherited = False)]
public sealed class TypeIconPriorityAttribute : Attribute
{
	[CompilerGenerated]
	private readonly int <priority>k__BackingField; //Field offset: 0x10

	public int priority
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public TypeIconPriorityAttribute(int priority) { }

	public TypeIconPriorityAttribute() { }

	[CompilerGenerated]
	public int get_priority() { }

}

