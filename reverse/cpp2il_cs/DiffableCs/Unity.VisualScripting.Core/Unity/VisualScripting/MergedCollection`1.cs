namespace Unity.VisualScripting;

public class MergedCollection : IMergedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <GetEnumerator>d__11 : IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		public MergedCollection<T> <>4__this; //Field offset: 0x0
		private Enumerator<Type, ICollection<T>> <>7__wrap1; //Field offset: 0x0
		private IEnumerator<T> <>7__wrap2; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 175
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 179
		}

		[DebuggerHidden]
		public <GetEnumerator>d__11(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private readonly Dictionary<Type, ICollection`1<T>> collections; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 565
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public MergedCollection`1() { }

	public override void Add(T item) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public ICollection<TI> ForType() { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	private ICollection<T> GetCollectionForItem(T item) { }

	private ICollection<T> GetCollectionForType(Type type, bool throwOnFail = true) { }

	[IteratorStateMachine(typeof(<GetEnumerator>d__11))]
	public override IEnumerator<T> GetEnumerator() { }

	public void Include(ICollection<TI> collection) { }

	public override bool Includes() { }

	public override bool Includes(Type implementationType) { }

	public override bool Remove(T item) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

