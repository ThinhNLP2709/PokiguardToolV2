namespace UnityEngine.InputSystem.Utilities;

internal class WhereObservable : IObservable<TValue>
{
	private class Where : IObserver<TValue>
	{
		private WhereObservable<TValue> m_Observable; //Field offset: 0x0
		private readonly IObserver<TValue> m_Observer; //Field offset: 0x0

		public Where(WhereObservable<TValue> observable, IObserver<TValue> observer) { }

		public override void OnCompleted() { }

		public override void OnError(Exception error) { }

		public override void OnNext(TValue evt) { }

	}

	private readonly IObservable<TValue> m_Source; //Field offset: 0x0
	private readonly Func<TValue, Boolean> m_Predicate; //Field offset: 0x0

	public WhereObservable`1(IObservable<TValue> source, Func<TValue, Boolean> predicate) { }

	public override IDisposable Subscribe(IObserver<TValue> observer) { }

}

