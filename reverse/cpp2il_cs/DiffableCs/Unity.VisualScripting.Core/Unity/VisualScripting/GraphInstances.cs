namespace Unity.VisualScripting;

public static class GraphInstances
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Dictionary<IGraph, HashSet`1<GraphReference>> byGraph; //Field offset: 0x8
	private static readonly Dictionary<IGraphParent, HashSet`1<GraphReference>> byParent; //Field offset: 0x10

	private static GraphInstances() { }

	public static HashSet<GraphReference> ChildrenOfPooled(IGraphParent parent) { }

	public static void Instantiate(GraphReference instance) { }

	public static HashSet<GraphReference> OfPooled(IGraph graph) { }

	public static void Uninstantiate(GraphReference instance) { }

}

