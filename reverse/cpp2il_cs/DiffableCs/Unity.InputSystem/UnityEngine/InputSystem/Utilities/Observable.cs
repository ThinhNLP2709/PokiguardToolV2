namespace UnityEngine.InputSystem.Utilities;

[Extension]
public static class Observable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public IDisposable subscription; //Field offset: 0x0

		public <>c__DisplayClass6_0`1() { }

		internal void <CallOnce>b__0() { }

	}


	[Extension]
	public static IDisposable Call(IObservable<TValue> source, Action<TValue> action) { }

	[Extension]
	public static IDisposable CallOnce(IObservable<TValue> source, Action<TValue> action) { }

	[Extension]
	public static IObservable<InputEventPtr> ForDevice(IObservable<InputEventPtr> source, InputDevice device) { }

	[Extension]
	public static IObservable<InputEventPtr> ForDevice(IObservable<InputEventPtr> source) { }

	[Extension]
	public static IObservable<TResult> Select(IObservable<TSource> source, Func<TSource, TResult> filter) { }

	[Extension]
	public static IObservable<TResult> SelectMany(IObservable<TSource> source, Func<TSource, IEnumerable`1<TResult>> filter) { }

	[Extension]
	public static IObservable<TValue> Take(IObservable<TValue> source, int count) { }

	[Extension]
	public static IObservable<TValue> Where(IObservable<TValue> source, Func<TValue, Boolean> predicate) { }

}

