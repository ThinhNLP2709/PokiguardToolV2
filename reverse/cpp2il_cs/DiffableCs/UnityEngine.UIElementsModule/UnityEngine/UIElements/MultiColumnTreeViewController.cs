namespace UnityEngine.UIElements;

public abstract class MultiColumnTreeViewController : BaseTreeViewController
{
	private MultiColumnController m_ColumnController; //Field offset: 0x68

	public MultiColumnController columnController
	{
		 get { } //Length: 5
	}

	protected MultiColumnTreeViewController(Columns columns, SortColumnDescriptions sortDescriptions, List<SortColumnDescription> sortedColumns) { }

	protected virtual void BindItem(VisualElement element, int index) { }

	protected virtual void DestroyItem(VisualElement element) { }

	public virtual void Dispose() { }

	public MultiColumnController get_columnController() { }

	internal virtual void InvokeBindItem(ReusableCollectionItem reusableItem, int index) { }

	internal virtual void InvokeMakeItem(ReusableCollectionItem reusableItem) { }

	internal virtual void InvokeUnbindItem(ReusableCollectionItem reusableItem, int index) { }

	protected virtual VisualElement MakeItem() { }

	protected virtual void PrepareView() { }

	internal virtual void PreRefresh() { }

	protected virtual void UnbindItem(VisualElement element, int index) { }

}

