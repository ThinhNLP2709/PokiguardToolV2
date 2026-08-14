namespace Unity.VisualScripting;

[Extension]
public static class GraphsExceptionUtility
{
	private const string handledKey = "Bolt.Core.Handled"; //Field offset: 0x0

	[Extension]
	public static Exception GetException(IGraphElementWithDebugData element, GraphPointer pointer) { }

	[Extension]
	private static bool HandledIn(Exception ex, GraphReference reference) { }

	[Extension]
	public static void HandleException(IGraphElementWithDebugData element, GraphPointer pointer, Exception ex) { }

	[Extension]
	public static void SetException(IGraphElementWithDebugData element, GraphPointer pointer, Exception ex) { }

}

