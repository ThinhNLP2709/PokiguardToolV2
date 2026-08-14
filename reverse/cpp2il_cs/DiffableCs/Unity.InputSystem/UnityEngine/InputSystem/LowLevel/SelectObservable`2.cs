namespace UnityEngine.InputSystem.LowLevel;

internal class SelectObservable : IObservable<TResult>
{
	private class Select : IObserver<TSource>
	{
		private SelectObservable<TSource, TResult> m_Observable; //Field offset: 0x0
		private readonly IObserver<TResult> m_Observer; //Field offset: 0x0

		public Select(SelectObservable<TSource, TResult> observable, IObserver<TResult> observer) { }

		public override void OnCompleted() { }

		public override void OnError(Exception error) { }

		public override void OnNext(TSource evt) { }

	}

	private readonly IObservable<TSource> m_Source; //Field offset: 0x0
	private readonly Func<TSource, TResult> m_Filter; //Field offset: 0x0

	public SelectObservable`2(IObservable<TSource> source, Func<TSource, TResult> filter) { }

	public override IDisposable Subscribe(IObserver<TResult> observer) { }

}

