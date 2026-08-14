namespace UnityEngine.UIElements;

[EventCategory(EventCategory::ChangeValue (9))]
public class ChangeEvent : EventBase<ChangeEvent`1<T>>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal ChangeEvent<T> <.cctor>b__0_0() { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private T <previousValue>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private T <newValue>k__BackingField; //Field offset: 0x0

	public T newValue
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public T previousValue
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	private static ChangeEvent`1() { }

	public ChangeEvent`1() { }

	[CompilerGenerated]
	public T get_newValue() { }

	[CompilerGenerated]
	public T get_previousValue() { }

	public static ChangeEvent<T> GetPooled(T previousValue, T newValue) { }

	protected virtual void Init() { }

	private void LocalInit() { }

	[CompilerGenerated]
	protected void set_newValue(T value) { }

	[CompilerGenerated]
	protected void set_previousValue(T value) { }

}

