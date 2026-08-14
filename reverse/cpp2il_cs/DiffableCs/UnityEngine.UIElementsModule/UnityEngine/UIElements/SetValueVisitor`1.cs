namespace UnityEngine.UIElements;

internal class SetValueVisitor : PathVisitor
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TSrcValue> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal SetValueVisitor<TSrcValue> <.cctor>b__9_0() { }

		internal void <.cctor>b__9_1(SetValueVisitor<TSrcValue> v) { }

	}

	public static readonly ObjectPool<SetValueVisitor`1<TSrcValue>> Pool; //Field offset: 0x0
	public TSrcValue Value; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ConverterGroup <group>k__BackingField; //Field offset: 0x0

	public ConverterGroup group
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	private static SetValueVisitor`1() { }

	public SetValueVisitor`1() { }

	[CompilerGenerated]
	public ConverterGroup get_group() { }

	public virtual void Reset() { }

	[CompilerGenerated]
	public void set_group(ConverterGroup value) { }

	protected virtual void VisitPath(Property<TContainer, TValue> property, ref TContainer container, ref TValue value) { }

}

