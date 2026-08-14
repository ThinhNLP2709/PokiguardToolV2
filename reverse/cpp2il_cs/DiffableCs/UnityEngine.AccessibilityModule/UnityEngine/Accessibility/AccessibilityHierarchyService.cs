namespace UnityEngine.Accessibility;

internal class AccessibilityHierarchyService : IService
{
	private AccessibilityHierarchy m_Hierarchy; //Field offset: 0x10

	internal AccessibilityHierarchy hierarchy
	{
		internal get { } //Length: 5
	}

	public AccessibilityHierarchyService() { }

	internal AccessibilityHierarchy get_hierarchy() { }

	internal List<AccessibilityNode> GetRootNodes() { }

	private void RemoveActiveHierarchy(bool notifyScreenChanged) { }

	public override void Start() { }

	public override void Stop() { }

	internal bool TryGetNode(int id, out AccessibilityNode node) { }

	internal bool TryGetNodeAt(float x, float y, out AccessibilityNode node) { }

}

