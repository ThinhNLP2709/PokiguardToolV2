namespace UnityEngine.AdaptivePerformance;

internal class AdaptivePerformanceScalerEfficiencyTracker
{
	private AdaptivePerformanceScaler m_Scaler; //Field offset: 0x10
	private float m_LastAverageGpuFrameTime; //Field offset: 0x18
	private float m_LastAverageCpuFrameTime; //Field offset: 0x1C
	private bool m_IsApplied; //Field offset: 0x20

	public bool IsRunning
	{
		 get { } //Length: 80
	}

	public AdaptivePerformanceScalerEfficiencyTracker() { }

	public bool get_IsRunning() { }

	public void Start(AdaptivePerformanceScaler scaler, bool isApply) { }

	public void Stop() { }

}

