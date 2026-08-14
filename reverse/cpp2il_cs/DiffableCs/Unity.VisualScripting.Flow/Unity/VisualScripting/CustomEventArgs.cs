namespace Unity.VisualScripting;

public struct CustomEventArgs
{
	public readonly string name; //Field offset: 0x0
	public readonly Object[] arguments; //Field offset: 0x8

	public CustomEventArgs(string name, Object[] arguments) { }

}

