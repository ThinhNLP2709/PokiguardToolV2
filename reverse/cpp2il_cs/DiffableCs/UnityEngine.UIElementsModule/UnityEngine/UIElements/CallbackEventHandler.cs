namespace UnityEngine.UIElements;

public abstract class CallbackEventHandler : IEventHandler
{
	internal const string HandleEventBubbleUpName = "HandleEventBubbleUp"; //Field offset: 0x0
	internal const string HandleEventTrickleDownName = "HandleEventTrickleDown"; //Field offset: 0x0
	internal const string ExecuteDefaultActionName = "ExecuteDefaultAction"; //Field offset: 0x0
	internal const string ExecuteDefaultActionAtTargetName = "ExecuteDefaultActionAtTarget"; //Field offset: 0x0
	internal bool isIMGUIContainer; //Field offset: 0x10
	internal EventCallbackRegistry m_CallbackRegistry; //Field offset: 0x18

	protected CallbackEventHandler() { }

	private void AddEventCategories(TrickleDown useTrickleDown) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	[Obsolete("Use HandleEventBubbleUp. Before proceeding, make sure you understand the latest changes to UIToolkit event propagation rules by visiting Unity's manual page https://docs.unity3d.com/Manual/UIE-Events-Dispatching.html")]
	protected override void ExecuteDefaultAction(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	[Obsolete("Use HandleEventBubbleUp. Before proceeding, make sure you understand the latest changes to UIToolkit event propagation rules by visiting Unity's manual page https://docs.unity3d.com/Manual/UIE-Events-Dispatching.html")]
	protected override void ExecuteDefaultActionAtTarget(EventBase evt) { }

	internal void ExecuteDefaultActionAtTargetInternal(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	[Obsolete("Use HandleEventBubbleUpDisabled.")]
	internal override void ExecuteDefaultActionDisabled(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	[Obsolete("Use HandleEventBubbleUpDisabled.")]
	internal override void ExecuteDefaultActionDisabledAtTarget(EventBase evt) { }

	internal void ExecuteDefaultActionDisabledAtTargetInternal(EventBase evt) { }

	internal void ExecuteDefaultActionDisabledInternal(EventBase evt) { }

	internal void ExecuteDefaultActionInternal(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	protected override void HandleEventBubbleUp(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	internal override void HandleEventBubbleUpDisabled(EventBase evt) { }

	internal void HandleEventBubbleUpInternal(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	protected override void HandleEventTrickleDown(EventBase evt) { }

	[EventInterest(EventInterestOptions::Inherit (0))]
	internal override void HandleEventTrickleDownDisabled(EventBase evt) { }

	internal void HandleEventTrickleDownInternal(EventBase evt) { }

	protected void NotifyPropertyChanged(in BindingId property) { }

	internal void RegisterCallback(EventCallback<TEventType> callback, InvokePolicy invokePolicy, TrickleDown useTrickleDown = 0) { }

	public void RegisterCallback(EventCallback<TEventType, TUserArgsType> callback, TUserArgsType userArgs, TrickleDown useTrickleDown = 0) { }

	public void RegisterCallback(EventCallback<TEventType> callback, TrickleDown useTrickleDown = 0) { }

	internal abstract void SendEvent(EventBase e, DispatchMode dispatchMode) { }

	public abstract void SendEvent(EventBase e) { }

	public void UnregisterCallback(EventCallback<TEventType, TUserArgsType> callback, TrickleDown useTrickleDown = 0) { }

	public void UnregisterCallback(EventCallback<TEventType> callback, TrickleDown useTrickleDown = 0) { }

}

