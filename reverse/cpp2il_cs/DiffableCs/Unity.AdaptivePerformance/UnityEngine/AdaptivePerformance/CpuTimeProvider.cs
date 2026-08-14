namespace UnityEngine.AdaptivePerformance;

internal class CpuTimeProvider
{
	private RenderThreadCpuTime m_RenderThreadCpuTime; //Field offset: 0x10
	private MainThreadCpuTime m_MainThreadCpuTime; //Field offset: 0x18

	public float CpuFrameTime
	{
		 get { } //Length: 43
	}

	public CpuTimeProvider() { }

	public void EndOfFrame() { }

	public float get_CpuFrameTime() { }

	protected override bool IsGraphicsMultiThreaded() { }

	public void LateUpdate() { }

	public void Reset() { }

}

