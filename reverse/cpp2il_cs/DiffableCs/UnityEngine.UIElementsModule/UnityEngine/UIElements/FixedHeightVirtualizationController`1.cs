namespace UnityEngine.UIElements;

internal class FixedHeightVirtualizationController : VerticalVirtualizationController<T>
{
	private Nullable<Int32> m_ScrolledToItemIndex; //Field offset: 0x0

	private float resolvedItemHeight
	{
		private get { } //Length: 38
	}

	public FixedHeightVirtualizationController`1(BaseVerticalCollectionView collectionView) { }

	internal virtual void EndDrag(int dropIndex) { }

	private float get_resolvedItemHeight() { }

	public virtual float GetExpectedContentHeight() { }

	public virtual float GetExpectedItemHeight(int index) { }

	public virtual int GetIndexFromPosition(Vector2 position) { }

	internal virtual T GetOrMakeItemAtIndex(int activeItemIndex = -1, int scrollViewIndex = -1) { }

	private void OnGeometryChangedEvent(GeometryChangedEvent _) { }

	public virtual void OnScroll(Vector2 scrollOffset) { }

	public virtual void Resize(Vector2 size) { }

	public virtual void ScrollToItem(int index) { }

	protected virtual bool VisibleItemPredicate(T i) { }

}

