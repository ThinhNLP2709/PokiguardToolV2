namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(10)]
[UnitTitle("For Each Loop")]
public class ForEach : LoopUnit
{
	[CompilerGenerated]
	private sealed class <LoopCoroutine>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ForEach <>4__this; //Field offset: 0x20
		public Flow flow; //Field offset: 0x28
		private int <loop>5__2; //Field offset: 0x30
		private IEnumerator <enumerator>5__3; //Field offset: 0x38
		private IDictionaryEnumerator <dictionaryEnumerator>5__4; //Field offset: 0x40
		private int <currentIndex>5__5; //Field offset: 0x48
		private GraphStack <stack>5__6; //Field offset: 0x50

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
		public <LoopCoroutine>d__24(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private ValueInput <collection>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <currentIndex>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <currentKey>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <currentItem>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private bool <dictionary>k__BackingField; //Field offset: 0xC8

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput collection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Index")]
	public private ValueOutput currentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Item")]
	public private ValueOutput currentItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Key")]
	public private ValueOutput currentKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Dictionary")]
	public bool dictionary
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public ForEach() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_collection() { }

	[CompilerGenerated]
	public ValueOutput get_currentIndex() { }

	[CompilerGenerated]
	public ValueOutput get_currentItem() { }

	[CompilerGenerated]
	public ValueOutput get_currentKey() { }

	[CompilerGenerated]
	public bool get_dictionary() { }

	protected virtual ControlOutput Loop(Flow flow) { }

	[IteratorStateMachine(typeof(<LoopCoroutine>d__24))]
	protected virtual IEnumerator LoopCoroutine(Flow flow) { }

	private bool MoveNext(Flow flow, IEnumerator enumerator, IDictionaryEnumerator dictionaryEnumerator, ref int currentIndex) { }

	[CompilerGenerated]
	private void set_collection(ValueInput value) { }

	[CompilerGenerated]
	private void set_currentIndex(ValueOutput value) { }

	[CompilerGenerated]
	private void set_currentItem(ValueOutput value) { }

	[CompilerGenerated]
	private void set_currentKey(ValueOutput value) { }

	[CompilerGenerated]
	public void set_dictionary(bool value) { }

	private int Start(Flow flow, out IEnumerator enumerator, out IDictionaryEnumerator dictionaryEnumerator, out int currentIndex) { }

}

