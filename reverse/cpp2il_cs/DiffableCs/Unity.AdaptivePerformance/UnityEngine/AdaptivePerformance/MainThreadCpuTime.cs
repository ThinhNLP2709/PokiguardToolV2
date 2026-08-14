namespace UnityEngine.AdaptivePerformance;

internal class MainThreadCpuTime
{
	private double m_LastAbsoluteMainThreadCpuTime; //Field offset: 0x10
	private float m_LatestMainthreadCpuTime; //Field offset: 0x18

	public MainThreadCpuTime() { }

	public float GetLatestResult() { }

	public void Measure() { }

}

