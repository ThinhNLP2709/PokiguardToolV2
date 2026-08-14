namespace UnityEngine.UIElements;

public class DefaultMultiColumnTreeViewController : MultiColumnTreeViewController
{
	private TreeDataController<T> m_TreeDataController; //Field offset: 0x0

	public virtual IList itemsSource
	{
		 get { } //Length: 25
		 set { } //Length: 275
	}

	private TreeDataController<T> treeDataController
	{
		private get { } //Length: 131
	}

	public DefaultMultiColumnTreeViewController`1(Columns columns, SortColumnDescriptions sortDescriptions, List<SortColumnDescription> sortedColumns) { }

	[CompilerGenerated]
	private HierarchyNode <SetRootItems>b__7_0(HierarchyNode node) { }

	[CompilerGenerated]
	private void <SetRootItems>b__7_1(int id, HierarchyNode node) { }

	public virtual IList get_itemsSource() { }

	private TreeDataController<T> get_treeDataController() { }

	public virtual object GetItemForIndex(int index) { }

	public virtual void set_itemsSource(IList value) { }

	public override void SetRootItems(IList<TreeViewItemData`1<T>> items) { }

}

