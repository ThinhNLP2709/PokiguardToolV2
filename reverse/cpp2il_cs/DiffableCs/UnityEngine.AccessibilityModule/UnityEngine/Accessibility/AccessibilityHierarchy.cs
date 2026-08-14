namespace UnityEngine.Accessibility;

public class AccessibilityHierarchy
{
	internal List<AccessibilityNode> m_RootNodes; //Field offset: 0x10
	private readonly IDictionary<Int32, AccessibilityNode> m_Nodes; //Field offset: 0x18

	[CompilerGenerated]
	internal static AccessibilityNode <TryGetNodeAt>g__FindNodeContainingPoint|27_0(IList<AccessibilityNode> nodes, Vector2 pos) { }

	internal void FreeNative() { }

	public bool TryGetNode(int id, out AccessibilityNode node) { }

	public bool TryGetNodeAt(float horizontalPosition, float verticalPosition, out AccessibilityNode node) { }

}

