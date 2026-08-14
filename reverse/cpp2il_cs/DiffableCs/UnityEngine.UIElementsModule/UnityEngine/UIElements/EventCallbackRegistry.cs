namespace UnityEngine.UIElements;

internal class EventCallbackRegistry
{
	public struct DynamicCallbackList
	{
		private TrickleDown m_UseTrickleDown; //Field offset: 0x0
		[NotNull]
		private EventCallbackList m_Callbacks; //Field offset: 0x8
		[CanBeNull]
		private EventCallbackList m_TemporaryCallbacks; //Field offset: 0x10
		[CanBeNull]
		private List<EventCallbackFunctorBase> m_UnregisteredCallbacksDuringInvoke; //Field offset: 0x18
		private int m_IsInvoking; //Field offset: 0x20

		private void BeginInvoke() { }

		public static DynamicCallbackList Create(TrickleDown useTrickleDown) { }

		private void EndInvoke() { }

		[IsReadOnly]
		[NotNull]
		public EventCallbackList GetCallbackListForReading() { }

		[NotNull]
		public EventCallbackList GetCallbackListForWriting() { }

		public void Invoke(EventBase evt, BaseVisualElementPanel panel, VisualElement target) { }

		public bool UnregisterCallback(long eventTypeId, Delegate callback) { }

	}

	private static readonly EventCallbackListPool s_ListPool; //Field offset: 0x0
	internal DynamicCallbackList m_TrickleDownCallbacks; //Field offset: 0x10
	internal DynamicCallbackList m_BubbleUpCallbacks; //Field offset: 0x38

	private static EventCallbackRegistry() { }

	public EventCallbackRegistry() { }

	private static EventCallbackList GetCallbackList(EventCallbackList initializer = null) { }

	private DynamicCallbackList GetDynamicCallbackList(TrickleDown useTrickleDown) { }

	public void RegisterCallback(EventCallback<TEventType> callback, TrickleDown useTrickleDown = 0, InvokePolicy invokePolicy = 0) { }

	public void RegisterCallback(EventCallback<TEventType, TCallbackArgs> callback, TCallbackArgs userArgs, TrickleDown useTrickleDown = 0, InvokePolicy invokePolicy = 0) { }

	private static void ReleaseCallbackList(EventCallbackList toRelease) { }

	public bool UnregisterCallback(EventCallback<TEventType> callback, TrickleDown useTrickleDown = 0) { }

	public bool UnregisterCallback(EventCallback<TEventType, TCallbackArgs> callback, TrickleDown useTrickleDown = 0) { }

}

