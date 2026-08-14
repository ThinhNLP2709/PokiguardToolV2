namespace Unity.VisualScripting;

[AttributeUsage(AttributeTargets::Class (4))]
[fsObject(Converter = typeof(UnitCategoryConverter))]
public class UnitCategory : Attribute
{
	[CompilerGenerated]
	private sealed class <AndAncestors>d__18 : IEnumerable<UnitCategory>, IEnumerable, IEnumerator<UnitCategory>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private UnitCategory <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public UnitCategory <>4__this; //Field offset: 0x28
		private IEnumerator<UnitCategory> <>7__wrap1; //Field offset: 0x30

		private override UnitCategory System.Collections.Generic.IEnumerator<Unity.VisualScripting.UnitCategory>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <AndAncestors>d__18(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<UnitCategory> System.Collections.Generic.IEnumerable<Unity.VisualScripting.UnitCategory>.GetEnumerator() { }

		[DebuggerHidden]
		private override UnitCategory System.Collections.Generic.IEnumerator<Unity.VisualScripting.UnitCategory>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <get_ancestors>d__17 : IEnumerable<UnitCategory>, IEnumerable, IEnumerator<UnitCategory>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private UnitCategory <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public UnitCategory <>4__this; //Field offset: 0x28
		private UnitCategory <ancestor>5__2; //Field offset: 0x30

		private override UnitCategory System.Collections.Generic.IEnumerator<Unity.VisualScripting.UnitCategory>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <get_ancestors>d__17(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<UnitCategory> System.Collections.Generic.IEnumerable<Unity.VisualScripting.UnitCategory>.GetEnumerator() { }

		[DebuggerHidden]
		private override UnitCategory System.Collections.Generic.IEnumerator<Unity.VisualScripting.UnitCategory>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private readonly UnitCategory <root>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly UnitCategory <parent>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <fullName>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <name>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly bool <isRoot>k__BackingField; //Field offset: 0x30

	public IEnumerable<UnitCategory> ancestors
	{
		[IteratorStateMachine(typeof(<get_ancestors>d__17))]
		 get { } //Length: 113
	}

	public string fullName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public bool isRoot
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public UnitCategory parent
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public UnitCategory root
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public UnitCategory(string fullName) { }

	[IteratorStateMachine(typeof(<AndAncestors>d__18))]
	public IEnumerable<UnitCategory> AndAncestors() { }

	public virtual bool Equals(object obj) { }

	[IteratorStateMachine(typeof(<get_ancestors>d__17))]
	public IEnumerable<UnitCategory> get_ancestors() { }

	[CompilerGenerated]
	public string get_fullName() { }

	[CompilerGenerated]
	public bool get_isRoot() { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	public UnitCategory get_parent() { }

	[CompilerGenerated]
	public UnitCategory get_root() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(UnitCategory a, UnitCategory b) { }

	public static bool op_Inequality(UnitCategory a, UnitCategory b) { }

	public virtual string ToString() { }

}

