namespace UnityEngine.AdaptivePerformance;

public sealed class ThermalEventHandler : MulticastDelegate
{

	public ThermalEventHandler(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(ThermalMetrics thermalMetrics, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(ThermalMetrics thermalMetrics) { }

}

