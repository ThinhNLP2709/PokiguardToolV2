namespace DG.Tweening.Core;

public static class Debugger
{
	public static class Sequence
	{

		public static void LogAddAlreadySequencedTween(Tween t) { }

		public static void LogAddInactiveTween(Tween t) { }

		public static void LogAddNullTween() { }

		public static void LogAddToInactiveSequence() { }

		public static void LogAddToLockedSequence() { }

		public static void LogAddToNullSequence() { }

	}

	private static int _logPriority; //Field offset: 0x0
	private const string _LogPrefix = "<color=#0099bc><b>DOTWEEN ► </b></color>"; //Field offset: 0x0

	public static int logPriority
	{
		 get { } //Length: 53
	}

	private static void AddDebugDataToMessage(ref string message, Tween t) { }

	public static int get_logPriority() { }

	private static string GetDebugDataMessage(Tween t) { }

	public static void Log(object message) { }

	public static void LogAddActiveTweenError(string errorInfo, Tween t) { }

	public static void LogError(object message, Tween t = null) { }

	public static void LogInvalidTween(Tween t) { }

	public static void LogMissingMaterialProperty(int propertyId) { }

	public static void LogMissingMaterialProperty(string propertyName) { }

	public static void LogNestedTween(Tween t) { }

	public static void LogNonPathTween(Tween t) { }

	public static void LogNullTween(Tween t) { }

	public static void LogRemoveActiveTweenError(string errorInfo, Tween t) { }

	public static void LogReport(object message) { }

	public static void LogSafeModeCapturedError(object message, Tween t = null) { }

	public static void LogSafeModeReport(object message) { }

	public static void LogWarning(object message, Tween t = null) { }

	public static void SetLogPriority(LogBehaviour logBehaviour) { }

	public static bool ShouldLogSafeModeCapturedError() { }

}

