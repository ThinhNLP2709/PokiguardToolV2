namespace Unity.VisualScripting;

public sealed class Namespace
{
	[CompilerGenerated]
	private sealed class <AndAncestors>d__21 : IEnumerable<Namespace>, IEnumerable, IEnumerator<Namespace>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Namespace <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public Namespace <>4__this; //Field offset: 0x28
		private IEnumerator<Namespace> <>7__wrap1; //Field offset: 0x30

		private override Namespace System.Collections.Generic.IEnumerator<Unity.VisualScripting.Namespace>.Current
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
		public <AndAncestors>d__21(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Namespace> System.Collections.Generic.IEnumerable<Unity.VisualScripting.Namespace>.GetEnumerator() { }

		[DebuggerHidden]
		private override Namespace System.Collections.Generic.IEnumerator<Unity.VisualScripting.Namespace>.get_Current() { }

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
	private sealed class <get_Ancestors>d__20 : IEnumerable<Namespace>, IEnumerable, IEnumerator<Namespace>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private Namespace <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public Namespace <>4__this; //Field offset: 0x28
		private Namespace <ancestor>5__2; //Field offset: 0x30

		private override Namespace System.Collections.Generic.IEnumerator<Unity.VisualScripting.Namespace>.Current
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
		public <get_Ancestors>d__20(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Namespace> System.Collections.Generic.IEnumerable<Unity.VisualScripting.Namespace>.GetEnumerator() { }

		[DebuggerHidden]
		private override Namespace System.Collections.Generic.IEnumerator<Unity.VisualScripting.Namespace>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class Collection : KeyedCollection<String, Namespace>, IKeyedCollection<String, Namespace>, ICollection<Namespace>, IEnumerable<Namespace>, IEnumerable
	{

		public Collection() { }

		protected virtual string GetKeyForItem(Namespace item) { }

		public override bool TryGetValue(string key, out Namespace value) { }

		private override bool Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.Namespace>.Contains(string key) { }

		private override Namespace Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.Namespace>.get_Item(string key) { }

		private override bool Unity.VisualScripting.IKeyedCollection<System.String,Unity.VisualScripting.Namespace>.Remove(string key) { }

	}

	private static readonly Collection collection; //Field offset: 0x0
	[CompilerGenerated]
	private static readonly Namespace <Global>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private readonly Namespace <Root>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Namespace <Parent>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <FullName>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <Name>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly bool <IsRoot>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly bool <IsGlobal>k__BackingField; //Field offset: 0x31

	public IEnumerable<Namespace> Ancestors
	{
		[IteratorStateMachine(typeof(<get_Ancestors>d__20))]
		 get { } //Length: 113
	}

	public string FullName
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public static Namespace Global
	{
		[CompilerGenerated]
		 get { } //Length: 79
	}

	public bool IsGlobal
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public bool IsRoot
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public string Name
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public Namespace Parent
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public Namespace Root
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	private static Namespace() { }

	private Namespace(string fullName) { }

	[IteratorStateMachine(typeof(<AndAncestors>d__21))]
	public IEnumerable<Namespace> AndAncestors() { }

	public virtual bool Equals(object obj) { }

	public static Namespace FromFullName(string fullName) { }

	[IteratorStateMachine(typeof(<get_Ancestors>d__20))]
	public IEnumerable<Namespace> get_Ancestors() { }

	[CompilerGenerated]
	public string get_FullName() { }

	[CompilerGenerated]
	public static Namespace get_Global() { }

	[CompilerGenerated]
	public bool get_IsGlobal() { }

	[CompilerGenerated]
	public bool get_IsRoot() { }

	[CompilerGenerated]
	public string get_Name() { }

	[CompilerGenerated]
	public Namespace get_Parent() { }

	[CompilerGenerated]
	public Namespace get_Root() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(Namespace a, Namespace b) { }

	public static Namespace op_Implicit(string fullName) { }

	public static string op_Implicit(Namespace namespace) { }

	public static bool op_Inequality(Namespace a, Namespace b) { }

	public virtual string ToString() { }

}

