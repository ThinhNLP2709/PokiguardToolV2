namespace UnityEngine.InputSystem.Utilities;

internal class Observer : IObserver<TValue>
{
	private Action<TValue> m_OnNext; //Field offset: 0x0
	private Action m_OnCompleted; //Field offset: 0x0

	public Observer`1(Action<TValue> onNext, Action onCompleted = null) { }

	public override void OnCompleted() { }

	public override void OnError(Exception error) { }

	public override void OnNext(TValue evt) { }

}

