namespace UnityEngine;

[NativeHeader("Runtime/Export/Debug/Debug.bindings.h")]
internal sealed class DebugLogHandler : ILogHandler
{

	public DebugLogHandler() { }

	[ThreadAndSerializationSafe]
	internal static void Internal_Log(LogType level, LogOption options, string msg, object obj) { }

	private static void Internal_Log_Injected(LogType level, LogOption options, ref ManagedSpanWrapper msg, IntPtr obj) { }

	[ThreadAndSerializationSafe]
	internal static void Internal_LogException(Exception ex, object obj) { }

	private static void Internal_LogException_Injected(Exception ex, IntPtr obj) { }

	public override void LogException(Exception exception, object context) { }

	public override void LogFormat(LogType logType, object context, string format, Object[] args) { }

	public void LogFormat(LogType logType, LogOption logOptions, object context, string format, Object[] args) { }

}

