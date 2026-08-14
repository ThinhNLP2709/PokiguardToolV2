namespace UnityEngine.InputSystem;

public struct InputBindingCompositeContext
{
	[CompilerGenerated]
	private sealed class <get_controls>d__2 : IEnumerable<PartBinding>, IEnumerable, IEnumerator<PartBinding>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private PartBinding <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x28
		public InputBindingCompositeContext <>4__this; //Field offset: 0x30
		public InputBindingCompositeContext <>3__<>4__this; //Field offset: 0x40
		private int <totalBindingCount>5__2; //Field offset: 0x50
		private int <bindingIndex>5__3; //Field offset: 0x54
		private BindingState <bindingState>5__4; //Field offset: 0x58
		private int <controlStartIndex>5__5; //Field offset: 0x78
		private int <i>5__6; //Field offset: 0x7C

		private override PartBinding System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputBindingCompositeContext.PartBinding>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 11
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 69
		}

		[DebuggerHidden]
		public <get_controls>d__2(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<PartBinding> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputBindingCompositeContext.PartBinding>.GetEnumerator() { }

		[DebuggerHidden]
		private override PartBinding System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputBindingCompositeContext.PartBinding>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private struct DefaultComparer : IComparer<TValue>
	{

		public override int Compare(TValue x, TValue y) { }

	}

	internal struct PartBinding
	{
		[CompilerGenerated]
		private int <part>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private InputControl <control>k__BackingField; //Field offset: 0x8

		public InputControl control
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public int part
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 3
			[CompilerGenerated]
			 set { } //Length: 3
		}

		[CompilerGenerated]
		[IsReadOnly]
		public InputControl get_control() { }

		[CompilerGenerated]
		[IsReadOnly]
		public int get_part() { }

		[CompilerGenerated]
		public void set_control(InputControl value) { }

		[CompilerGenerated]
		public void set_part(int value) { }

	}

	internal InputActionState m_State; //Field offset: 0x0
	internal int m_BindingIndex; //Field offset: 0x8

	public IEnumerable<PartBinding> controls
	{
		[IteratorStateMachine(typeof(<get_controls>d__2))]
		 get { } //Length: 115
	}

	public float EvaluateMagnitude(int partNumber) { }

	[IteratorStateMachine(typeof(<get_controls>d__2))]
	public IEnumerable<PartBinding> get_controls() { }

	public double GetPressTime(int partNumber) { }

	public TValue ReadValue(int partNumber) { }

	public TValue ReadValue(int partNumber, out InputControl sourceControl) { }

	public TValue ReadValue(int partNumber, TComparer comparer = null) { }

	public TValue ReadValue(int partNumber, out InputControl sourceControl, TComparer comparer = null) { }

	public void ReadValue(int partNumber, Void* buffer, int bufferSize) { }

	public bool ReadValueAsButton(int partNumber) { }

	public object ReadValueAsObject(int partNumber) { }

}

