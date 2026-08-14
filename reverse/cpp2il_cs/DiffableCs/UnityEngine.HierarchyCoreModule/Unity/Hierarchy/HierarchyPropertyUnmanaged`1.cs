namespace Unity.Hierarchy;

[IsReadOnly]
public struct HierarchyPropertyUnmanaged : IEquatable<HierarchyPropertyUnmanaged`1<T>>, IHierarchyProperty<T>
{
	private readonly Hierarchy m_Hierarchy; //Field offset: 0x0
	internal readonly HierarchyPropertyId m_Property; //Field offset: 0x0

	internal HierarchyPropertyUnmanaged`1(Hierarchy hierarchy, in HierarchyPropertyId property) { }

	[ExcludeFromDocs]
	public override bool Equals(HierarchyPropertyUnmanaged<T> other) { }

	[ExcludeFromDocs]
	public virtual bool Equals(object obj) { }

	[ExcludeFromDocs]
	public virtual int GetHashCode() { }

	public T GetValue(in HierarchyNode node) { }

	public void SetValue(in HierarchyNode node, T value) { }

	[ExcludeFromDocs]
	public virtual string ToString() { }

	private override T Unity.Hierarchy.IHierarchyProperty<T>.GetValue(in HierarchyNode node) { }

	private override void Unity.Hierarchy.IHierarchyProperty<T>.SetValue(in HierarchyNode node, T value) { }

}

