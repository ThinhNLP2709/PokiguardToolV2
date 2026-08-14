//Type is in global namespace

public static class D
{

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void Log(object message) { }

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void Log(object message, object context) { }

	public static void LogError(object message) { }

	public static void LogError(object message, object context) { }

	public static void LogException(Exception e) { }

	public static void LogException(Exception e, object context) { }

	public static void LogWarning(object message) { }

	public static void LogWarning(object message, object context) { }

}

