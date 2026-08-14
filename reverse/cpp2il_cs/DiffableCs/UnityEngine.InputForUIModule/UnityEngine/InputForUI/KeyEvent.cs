namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct KeyEvent : IEventProperties
{
	internal struct ButtonsState
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <buttons>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		[CompilerGenerated]
		private sealed class <GetAllPressed>d__8 : IEnumerable<KeyCode>, IEnumerable, IEnumerator<KeyCode>, IEnumerator, IDisposable
		{
			private int <>1__state; //Field offset: 0x10
			private KeyCode <>2__current; //Field offset: 0x14
			private int <>l__initialThreadId; //Field offset: 0x18
			public ButtonsState <>4__this; //Field offset: 0x1C
			public ButtonsState <>3__<>4__this; //Field offset: 0x44
			private uint <index>5__1; //Field offset: 0x6C

			private override KeyCode System.Collections.Generic.IEnumerator<UnityEngine.KeyCode>.Current
			{
				[DebuggerHidden]
				private get { } //Length: 4
			}

			private override object System.Collections.IEnumerator.Current
			{
				[DebuggerHidden]
				private get { } //Length: 67
			}

			[DebuggerHidden]
			public <GetAllPressed>d__8(int <>1__state) { }

			private override bool MoveNext() { }

			[DebuggerHidden]
			private override IEnumerator<KeyCode> System.Collections.Generic.IEnumerable<UnityEngine.KeyCode>.GetEnumerator() { }

			[DebuggerHidden]
			private override KeyCode System.Collections.Generic.IEnumerator<UnityEngine.KeyCode>.get_Current() { }

			[DebuggerHidden]
			private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

			[DebuggerHidden]
			private override object System.Collections.IEnumerator.get_Current() { }

			[DebuggerHidden]
			private override void System.Collections.IEnumerator.Reset() { }

			[DebuggerHidden]
			private override void System.IDisposable.Dispose() { }

		}

		[FixedBuffer(typeof(byte), 40)]
		private <buttons>e__FixedBuffer buttons; //Field offset: 0x0

		private void ClearUnchecked(uint index) { }

		[IteratorStateMachine(typeof(<GetAllPressed>d__8))]
		public IEnumerable<KeyCode> GetAllPressed() { }

		private bool GetUnchecked(uint index) { }

		public bool IsPressed(KeyCode keyCode) { }

		public void Reset() { }

		public void SetPressed(KeyCode keyCode, bool pressed) { }

		private void SetUnchecked(uint index) { }

		internal static bool ShouldBeProcessed(KeyCode keyCode) { }

		public virtual string ToString() { }

	}

	internal enum Type
	{
		KeyPressed = 1,
		KeyRepeated = 2,
		KeyReleased = 3,
		State = 4,
	}

	public Type type; //Field offset: 0x0
	public KeyCode keyCode; //Field offset: 0x4
	public ButtonsState buttonsState; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private DiscreteTime <timestamp>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventSource <eventSource>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private uint <playerId>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventModifiers <eventModifiers>k__BackingField; //Field offset: 0x40

	public override EventModifiers eventModifiers
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override EventSource eventSource
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public uint playerId
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DiscreteTime timestamp
	{
		[CompilerGenerated]
		 set { } //Length: 5
	}

	[CompilerGenerated]
	[IsReadOnly]
	public override EventModifiers get_eventModifiers() { }

	[CompilerGenerated]
	[IsReadOnly]
	public override EventSource get_eventSource() { }

	[CompilerGenerated]
	public void set_eventModifiers(EventModifiers value) { }

	[CompilerGenerated]
	public void set_eventSource(EventSource value) { }

	[CompilerGenerated]
	public void set_playerId(uint value) { }

	[CompilerGenerated]
	public void set_timestamp(DiscreteTime value) { }

	public virtual string ToString() { }

}

