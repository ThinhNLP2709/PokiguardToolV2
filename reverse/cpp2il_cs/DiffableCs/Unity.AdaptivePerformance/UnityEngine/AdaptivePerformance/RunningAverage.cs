namespace UnityEngine.AdaptivePerformance;

internal class RunningAverage
{
	private Single[] m_Values; //Field offset: 0x10
	private int m_NumValues; //Field offset: 0x18
	private int m_LastIndex; //Field offset: 0x1C
	private float m_AverageValue; //Field offset: 0x20

	public RunningAverage(int sampleWindowSize = 100) { }

	public void AddValue(float NewValue) { }

	public float GetAverageOr(float defaultValue) { }

	public float GetMostRecentValueOr(float defaultValue) { }

	public int GetNumValues() { }

	public int GetSampleWindowSize() { }

	public void Reset() { }

}

