namespace Unity.VisualScripting.Antlr3.Runtime.Misc;

public class ErrorManager
{

	public ErrorManager() { }

	public static void Error(object arg) { }

	private static StackFrame GetLastNonErrorManagerCodeLocation(Exception e) { }

	public static void InternalError(object error, Exception e) { }

	public static void InternalError(object error) { }

}

