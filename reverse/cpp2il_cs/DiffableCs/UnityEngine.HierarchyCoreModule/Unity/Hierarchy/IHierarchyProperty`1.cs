namespace Unity.Hierarchy;

public interface IHierarchyProperty
{

	public T GetValue(in HierarchyNode node) { }

	public void SetValue(in HierarchyNode node, T value) { }

}

