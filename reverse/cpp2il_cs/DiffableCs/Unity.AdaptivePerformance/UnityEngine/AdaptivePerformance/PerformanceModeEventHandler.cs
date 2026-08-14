namespace UnityEngine.AdaptivePerformance;

public sealed class PerformanceModeEventHandler : MulticastDelegate
{

	public PerformanceModeEventHandler(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(PerformanceMode performanceMode, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(PerformanceMode performanceMode) { }

}

