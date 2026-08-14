namespace Unity.VisualScripting;

[SpecialUnit]
public sealed class Expose : Unit, IAotStubbable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<MemberInfo, Boolean> <>9__25_0; //Field offset: 0x8
		public static Func<Member, String> <>9__25_2; //Field offset: 0x10
		public static Func<Member, Int32> <>9__25_3; //Field offset: 0x18
		public static Func<Member, Int32> <>9__25_4; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <Definition>b__25_0(MemberInfo m) { }

		internal string <Definition>b__25_2(Member m) { }

		internal int <Definition>b__25_3(Member m) { }

		internal int <Definition>b__25_4(Member m) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public Member member; //Field offset: 0x10
		public Expose <>4__this; //Field offset: 0x18

		public <>c__DisplayClass25_0() { }

		internal object <Definition>b__5(Flow flow) { }

	}

	[CompilerGenerated]
	private sealed class <GetAotStubs>d__24 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public Expose <>4__this; //Field offset: 0x28
		private Enumerator<ValueOutput, Member> <>7__wrap1; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <GetAotStubs>d__24(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Object> System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

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
	private Type <type>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private bool <instance>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private bool <static>k__BackingField; //Field offset: 0x99
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private Dictionary<ValueOutput, Member> <members>k__BackingField; //Field offset: 0xA8

	public virtual bool canDefine
	{
		 get { } //Length: 52
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Instance")]
	public bool instance
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	public private Dictionary<ValueOutput, Member> members
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Static")]
	public bool static
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[Serialize]
	[TypeFilter(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {}, Enums = False)]
	public Type type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Expose() { }

	public Expose(Type type) { }

	[CompilerGenerated]
	private Member <Definition>b__25_1(MemberInfo m) { }

	protected virtual void Definition() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public bool get_instance() { }

	[CompilerGenerated]
	public Dictionary<ValueOutput, Member> get_members() { }

	[CompilerGenerated]
	public bool get_static() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	[CompilerGenerated]
	public Type get_type() { }

	[IteratorStateMachine(typeof(<GetAotStubs>d__24))]
	public virtual IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	private object GetValue(Flow flow, Member member) { }

	private bool Include(Member member) { }

	[CompilerGenerated]
	public void set_instance(bool value) { }

	[CompilerGenerated]
	private void set_members(Dictionary<ValueOutput, Member> value) { }

	[CompilerGenerated]
	public void set_static(bool value) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

	[CompilerGenerated]
	public void set_type(Type value) { }

}

