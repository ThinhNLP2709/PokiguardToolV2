namespace Unity.VisualScripting;

public class OverrideStack
{
	private readonly Func<T> getValue; //Field offset: 0x0
	private readonly Action<T> setValue; //Field offset: 0x0
	private readonly Action clearValue; //Field offset: 0x0
	private T _value; //Field offset: 0x0
	private readonly Stack<T> previous; //Field offset: 0x0

	public internal T value
	{
		 get { } //Length: 198
		internal set { } //Length: 271
	}

	public OverrideStack`1(T defaultValue) { }

	public OverrideStack`1(Func<T> getValue, Action<T> setValue) { }

	public OverrideStack`1(Func<T> getValue, Action<T> setValue, Action clearValue) { }

	[CompilerGenerated]
	private T <.ctor>b__0_0() { }

	[CompilerGenerated]
	private void <.ctor>b__0_1(T value) { }

	public void BeginOverride(T item) { }

	public void EndOverride() { }

	public T get_value() { }

	public static T op_Implicit(OverrideStack<T> stack) { }

	public OverrideLayer<T> Override(T item) { }

	internal void set_value(T value) { }

}

