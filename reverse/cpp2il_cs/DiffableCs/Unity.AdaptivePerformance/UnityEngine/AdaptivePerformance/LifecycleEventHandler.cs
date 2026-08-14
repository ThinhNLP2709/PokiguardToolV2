namespace UnityEngine.AdaptivePerformance;

public sealed class LifecycleEventHandler : MulticastDelegate
{

	public LifecycleEventHandler(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(IAdaptivePerformance instance, LifecycleChangeType changeType, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(IAdaptivePerformance instance, LifecycleChangeType changeType) { }

}

