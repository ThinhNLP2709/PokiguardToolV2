namespace UnityEngine.Rendering;

internal class BottleneckHistory
{
	private List<PerformanceBottleneck> m_Bottlenecks; //Field offset: 0x10
	internal BottleneckHistogram Histogram; //Field offset: 0x18

	public BottleneckHistory(int initialCapacity) { }

	internal void AddBottleneckFromAveragedSample(FrameTimeSample frameHistorySampleAverage) { }

	internal void Clear() { }

	internal void ComputeHistogram() { }

	private static PerformanceBottleneck DetermineBottleneck(FrameTimeSample s) { }

	internal void DiscardOldSamples(int historySize) { }

}

