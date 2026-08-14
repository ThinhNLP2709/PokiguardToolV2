namespace Unity.VisualScripting;

public class VariantCollection : ICollection<TBase>, IEnumerable<TBase>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <GetEnumerator>d__10 : IEnumerator<TBase>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private TBase <>2__current; //Field offset: 0x0
		public VariantCollection<TBase, TImplementation> <>4__this; //Field offset: 0x0
		private IEnumerator<TImplementation> <>7__wrap1; //Field offset: 0x0

		private override TBase System.Collections.Generic.IEnumerator<TBase>.Current
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
		public <GetEnumerator>d__10(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override TBase System.Collections.Generic.IEnumerator<TBase>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private ICollection<TImplementation> <implementation>k__BackingField; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 69
	}

	public private ICollection<TImplementation> implementation
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 72
	}

	public VariantCollection`2(ICollection<TImplementation> implementation) { }

	public override void Add(TBase item) { }

	public override void Clear() { }

	public override bool Contains(TBase item) { }

	public override void CopyTo(TBase[] array, int arrayIndex) { }

	public override int get_Count() { }

	[CompilerGenerated]
	public ICollection<TImplementation> get_implementation() { }

	public override bool get_IsReadOnly() { }

	[IteratorStateMachine(typeof(<GetEnumerator>d__10))]
	public override IEnumerator<TBase> GetEnumerator() { }

	public override bool Remove(TBase item) { }

	[CompilerGenerated]
	private void set_implementation(ICollection<TImplementation> value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

