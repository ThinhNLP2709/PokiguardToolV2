namespace Unity.VisualScripting;

[Extension]
public static class XEventGraph
{

	[Extension]
	public static void TriggerEventHandler(GraphReference reference, Func<EventHook, Boolean> predicate, TArgs args, Func<IGraphParentElement, Boolean> recurse, bool force) { }

	[Extension]
	public static void TriggerEventHandler(GraphStack stack, Func<EventHook, Boolean> predicate, TArgs args, Func<IGraphParentElement, Boolean> recurse, bool force) { }

}

