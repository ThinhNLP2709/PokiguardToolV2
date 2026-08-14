namespace UnityEngine.UIElements;

internal class EventCallbackFunctor : EventCallbackFunctorBase
{
	private EventCallback<TEventType, TCallbackArgs> m_Callback; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private TCallbackArgs <userArgs>k__BackingField; //Field offset: 0x0

	internal TCallbackArgs userArgs
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public EventCallbackFunctor`2() { }

	public virtual void Dispose() { }

	[CompilerGenerated]
	internal TCallbackArgs get_userArgs() { }

	public static EventCallbackFunctor<TEventType, TCallbackArgs> GetPooled(long eventTypeId, EventCallback<TEventType, TCallbackArgs> callback, TCallbackArgs userArgs, InvokePolicy invokePolicy = 0) { }

	public virtual void Invoke(EventBase evt) { }

	public virtual bool IsEquivalentTo(long eventTypeId, Delegate callback) { }

	[CompilerGenerated]
	internal void set_userArgs(TCallbackArgs value) { }

	public virtual void UnregisterCallback(CallbackEventHandler target, TrickleDown useTrickleDown) { }

}

