namespace UnityEngine.InputSystem.Utilities;

internal class TakeNObservable : IObservable<TValue>
{
	private class Take : IObserver<TValue>
	{
		private IObserver<TValue> m_Observer; //Field offset: 0x0
		private int m_Remaining; //Field offset: 0x0

		public Take(TakeNObservable<TValue> observable, IObserver<TValue> observer) { }

		public override void OnCompleted() { }

		public override void OnError(Exception error) { }

		public override void OnNext(TValue evt) { }

	}

	private IObservable<TValue> m_Source; //Field offset: 0x0
	private int m_Count; //Field offset: 0x0

	public TakeNObservable`1(IObservable<TValue> source, int count) { }

	public override IDisposable Subscribe(IObserver<TValue> observer) { }

}

