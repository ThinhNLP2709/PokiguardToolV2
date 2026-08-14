namespace Unity.VisualScripting;

[Extension]
public static class LinqUtility
{
	[CompilerGenerated]
	private sealed class <>c__1
	{
		public static readonly <>c__1<T, TKey> <>9; //Field offset: 0x0
		public static Func<IGrouping`2<TKey, T>, T> <>9__1_0; //Field offset: 0x0

		private static <>c__1`2() { }

		public <>c__1`2() { }

		internal T <DistinctBy>b__1_0(IGrouping<TKey, T> x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__2
	{
		public static readonly <>c__2<T> <>9; //Field offset: 0x0
		public static Func<T, Boolean> <>9__2_0; //Field offset: 0x0

		private static <>c__2`1() { }

		public <>c__2`1() { }

		internal bool <NotNull>b__2_0(T i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public Dictionary<T, HashSet`1<T>> dependencies; //Field offset: 0x0

		public <>c__DisplayClass13_0`1() { }

		internal IEnumerable<T> <OrderByDependers>b__0(T depender) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public string message; //Field offset: 0x0

		public <>c__DisplayClass16_0`1() { }

		internal void <CatchAsLogError>b__0(Exception ex) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public string message; //Field offset: 0x0

		public <>c__DisplayClass17_0`1() { }

		internal void <CatchAsLogWarning>b__0(Exception ex) { }

	}

	[CompilerGenerated]
	private sealed class <Catch>d__14 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable<T> source; //Field offset: 0x0
		public IEnumerable<T> <>3__source; //Field offset: 0x0
		private Action<Exception> catch; //Field offset: 0x0
		public Action<Exception> <>3__catch; //Field offset: 0x0
		private IEnumerator<T> <enumerator>5__2; //Field offset: 0x0
		private bool <success>5__3; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 172
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 173
		}

		[DebuggerHidden]
		public <Catch>d__14`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

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
	private sealed class <Concat>d__0 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private IEnumerable[] enumerables; //Field offset: 0x0
		public IEnumerable[] <>3__enumerables; //Field offset: 0x0
		private IEnumerator<IEnumerable> <>7__wrap1; //Field offset: 0x0
		private IEnumerator<T> <>7__wrap2; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
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
		public <Concat>d__0`1(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

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
	private sealed class <Yield>d__3 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private T <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private T t; //Field offset: 0x0
		public T <>3__t; //Field offset: 0x0

		private override T System.Collections.Generic.IEnumerator<T>.Current
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
		public <Yield>d__3`1(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		[DebuggerHidden]
		private override T System.Collections.Generic.IEnumerator<T>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}


	[Extension]
	public static void AddRange(ICollection<T> collection, IEnumerable<T> items) { }

	[Extension]
	public static void AddRange(IList list, IEnumerable items) { }

	[Extension]
	public static ICollection<T> AsReadOnlyCollection(IEnumerable<T> enumerable) { }

	[Extension]
	public static IList<T> AsReadOnlyList(IEnumerable<T> enumerable) { }

	[Extension]
	public static IEnumerable<T> Catch(IEnumerable<T> source, ICollection<Exception> exceptions) { }

	[Extension]
	[IteratorStateMachine(typeof(<Catch>d__14`1))]
	public static IEnumerable<T> Catch(IEnumerable<T> source, Action<Exception> catch) { }

	[Extension]
	public static IEnumerable<T> CatchAsLogError(IEnumerable<T> source, string message) { }

	[Extension]
	public static IEnumerable<T> CatchAsLogWarning(IEnumerable<T> source, string message) { }

	[IteratorStateMachine(typeof(<Concat>d__0`1))]
	public static IEnumerable<T> Concat(IEnumerable[] enumerables) { }

	[Extension]
	public static IEnumerable<T> DistinctBy(IEnumerable<T> items, Func<T, TKey> property) { }

	[Extension]
	public static IEnumerable<T> Flatten(IEnumerable<T> source, Func<T, IEnumerable`1<T>> childrenSelector) { }

	[Extension]
	public static IEnumerable<T> IntersectAll(IEnumerable<IEnumerable`1<T>> groups) { }

	[Extension]
	public static IEnumerable<T> NotNull(IEnumerable<T> enumerable) { }

	[Extension]
	public static IEnumerable<T> OrderByDependencies(IEnumerable<T> source, Func<T, IEnumerable`1<T>> getDependencies, bool throwOnCycle = true) { }

	private static void OrderByDependenciesVisit(T item, HashSet<T> visited, List<T> sorted, Func<T, IEnumerable`1<T>> getDependencies, bool throwOnCycle) { }

	[Extension]
	public static IEnumerable<T> OrderByDependers(IEnumerable<T> source, Func<T, IEnumerable`1<T>> getDependers, bool throwOnCycle = true) { }

	[Extension]
	public static HashSet<T> ToHashSet(IEnumerable<T> enumerable) { }

	[Extension]
	[IteratorStateMachine(typeof(<Yield>d__3`1))]
	public static IEnumerable<T> Yield(T t) { }

}

