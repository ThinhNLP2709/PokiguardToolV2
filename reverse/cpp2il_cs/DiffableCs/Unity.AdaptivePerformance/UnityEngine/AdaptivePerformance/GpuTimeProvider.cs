namespace UnityEngine.AdaptivePerformance;

internal class GpuTimeProvider
{
	private FrameTiming[] m_FrameTiming; //Field offset: 0x10

	public float GpuFrameTime
	{
		 get { } //Length: 105
	}

	public GpuTimeProvider() { }

	public float get_GpuFrameTime() { }

	protected override uint GetLatestTimings() { }

	public void Measure() { }

}

