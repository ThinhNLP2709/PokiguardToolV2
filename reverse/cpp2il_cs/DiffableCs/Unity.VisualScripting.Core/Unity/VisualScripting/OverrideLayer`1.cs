namespace Unity.VisualScripting;

public struct OverrideLayer : IDisposable
{
	[CompilerGenerated]
	private readonly OverrideStack<T> <stack>k__BackingField; //Field offset: 0x0

	public OverrideStack<T> stack
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	internal OverrideLayer`1(OverrideStack<T> stack, T item) { }

	public override void Dispose() { }

	[CompilerGenerated]
	[IsReadOnly]
	public OverrideStack<T> get_stack() { }

}

