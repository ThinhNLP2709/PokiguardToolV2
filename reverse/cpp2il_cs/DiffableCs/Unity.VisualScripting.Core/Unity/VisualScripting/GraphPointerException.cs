namespace Unity.VisualScripting;

public sealed class GraphPointerException : Exception
{
	[CompilerGenerated]
	private readonly GraphPointer <pointer>k__BackingField; //Field offset: 0x90

	public GraphPointer pointer
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public GraphPointerException(string message, GraphPointer pointer) { }

	[CompilerGenerated]
	public GraphPointer get_pointer() { }

}

