namespace Unity.VisualScripting;

[SpecialUnit]
public abstract class MemberUnit : Unit, IAotStubbable
{
	[CompilerGenerated]
	private sealed class <GetAotStubs>d__15 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public MemberUnit <>4__this; //Field offset: 0x28

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
		public <GetAotStubs>d__15(int <>1__state) { }

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
	private Member <member>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0x98

	public virtual bool canDefine
	{
		 get { } //Length: 83
	}

	[MemberFilter(Fields = True, Properties = True, Methods = True, Constructors = True)]
	[Serialize]
	public Member member
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
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

	protected MemberUnit() { }

	protected MemberUnit(Member member) { }

	protected virtual void Definition() { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public Member get_member() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	[IteratorStateMachine(typeof(<GetAotStubs>d__15))]
	public virtual IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	protected abstract bool IsMemberValid(Member member) { }

	public virtual void Prewarm() { }

	[CompilerGenerated]
	public void set_member(Member value) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

}

