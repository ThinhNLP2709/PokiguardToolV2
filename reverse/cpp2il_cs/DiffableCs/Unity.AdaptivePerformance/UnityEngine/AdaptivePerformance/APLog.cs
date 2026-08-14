namespace UnityEngine.AdaptivePerformance;

internal static class APLog
{
	public static bool enabled; //Field offset: 0x0

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	public static void Debug(string format, Object[] args) { }

}

