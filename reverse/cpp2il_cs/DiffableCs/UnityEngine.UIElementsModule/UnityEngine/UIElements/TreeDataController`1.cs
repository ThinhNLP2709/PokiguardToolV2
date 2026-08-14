namespace UnityEngine.UIElements;

internal sealed class TreeDataController
{
	private Dictionary<HierarchyNode, TreeViewItemData`1<T>> m_NodeToItemDataDictionary; //Field offset: 0x0
	private Stack<IEnumerator`1<TreeViewItemData`1<T>>> m_ItemStack; //Field offset: 0x0
	private Stack<HierarchyNode> m_NodeStack; //Field offset: 0x0

	public TreeDataController`1() { }

	internal void ClearNodeToDataDictionary() { }

	internal void ConvertTreeViewItemDataToHierarchy(IEnumerable<TreeViewItemData`1<T>> list, Func<HierarchyNode, HierarchyNode> createNode, Action<Int32, HierarchyNode> updateDictionary) { }

	public T GetDataForNode(HierarchyNode node) { }

	internal void UpdateNodeToDataDictionary(HierarchyNode node, TreeViewItemData<T> item) { }

}

