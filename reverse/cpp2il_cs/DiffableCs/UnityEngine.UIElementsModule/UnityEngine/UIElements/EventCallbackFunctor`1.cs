namespace UnityEngine.UIElements;

internal class EventCallbackFunctor : EventCallbackFunctorBase
{
	private EventCallback<TEventType> m_Callback; //Field offset: 0x0

	public EventCallbackFunctor`1() { }

	public virtual void Dispose() { }

	public static EventCallbackFunctor<TEventType> GetPooled(long eventTypeId, EventCallback<TEventType> callback, InvokePolicy invokePolicy = 0) { }

	public virtual void Invoke(EventBase evt) { }

	public virtual bool IsEquivalentTo(long eventTypeId, Delegate callback) { }

	public virtual void UnregisterCallback(CallbackEventHandler target, TrickleDown useTrickleDown) { }

}

