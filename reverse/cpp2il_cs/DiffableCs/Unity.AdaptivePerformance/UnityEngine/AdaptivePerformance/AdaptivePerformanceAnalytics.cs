namespace UnityEngine.AdaptivePerformance;

internal static class AdaptivePerformanceAnalytics
{
	public static class AnalyticsLog
	{

		[Conditional("ADAPTIVE_PERFORMANCE_ANALYTICS_LOGGING")]
		public static void Debug(string format, Object[] args) { }

	}


	[Conditional("UNITY_ANALYTICS")]
	public static void RegisterFeature(string feature, bool status) { }

	[Conditional("UNITY_ANALYTICS")]
	public static void SendAdaptiveFeatureUpdateEvent(string feature, bool status) { }

	[Conditional("UNITY_ANALYTICS")]
	public static void SendAdaptivePerformanceThermalEvent(ThermalMetrics thermalMetrics) { }

	[Conditional("UNITY_ANALYTICS")]
	public static void SendAdaptiveStartupEvent(AdaptivePerformanceSubsystem subsystem) { }

}

