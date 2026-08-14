namespace Unity.VisualScripting;

[Extension]
public static class XGraphEventListener
{

	public static bool IsHierarchyListening(GraphReference reference) { }

	[Extension]
	public static void StartListening(IGraphEventListener listener, GraphReference reference) { }

	[Extension]
	public static void StopListening(IGraphEventListener listener, GraphReference reference) { }

}

