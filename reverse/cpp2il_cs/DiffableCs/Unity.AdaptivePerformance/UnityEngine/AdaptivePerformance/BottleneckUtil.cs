namespace UnityEngine.AdaptivePerformance;

internal class BottleneckUtil
{

	public BottleneckUtil() { }

	public static PerformanceBottleneck DetermineBottleneck(PerformanceBottleneck prevBottleneck, float averageCpuFrameTime, float averageGpuFrametime, float averageOverallFrametime, float targetFrameTime) { }

	private static bool HittingFrameRateLimit(float actualFrameTime, float thresholdFactor, float targetFrameTime) { }

}

