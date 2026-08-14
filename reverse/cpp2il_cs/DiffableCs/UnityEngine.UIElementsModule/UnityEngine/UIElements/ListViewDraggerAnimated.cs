namespace UnityEngine.UIElements;

internal class ListViewDraggerAnimated : ListViewDragger
{
	private int m_DragStartIndex; //Field offset: 0x80
	private int m_CurrentIndex; //Field offset: 0x84
	private float m_SelectionHeight; //Field offset: 0x88
	private float m_LocalOffsetOnStart; //Field offset: 0x8C
	private Vector3 m_CurrentPointerPosition; //Field offset: 0x90
	private ReusableCollectionItem m_Item; //Field offset: 0xA0
	private ReusableCollectionItem m_OffsetItem; //Field offset: 0xA8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isDragging>k__BackingField; //Field offset: 0xB0

	public ReusableCollectionItem draggedItem
	{
		 get { } //Length: 8
	}

	public private bool isDragging
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	protected virtual bool supportsDragEvents
	{
		 get { } //Length: 3
	}

	public ListViewDraggerAnimated(BaseVerticalCollectionView listView) { }

	private void Animate(ReusableCollectionItem element, float paddingTop) { }

	protected virtual void ClearDragAndDropUI(bool dragCancelled) { }

	public ReusableCollectionItem get_draggedItem() { }

	[CompilerGenerated]
	public bool get_isDragging() { }

	protected virtual bool get_supportsDragEvents() { }

	protected private virtual void OnDrop(Vector3 pointerPosition) { }

	[CompilerGenerated]
	private void set_isDragging(bool value) { }

	protected private virtual StartDragArgs StartDrag(Vector3 pointerPosition) { }

	protected virtual bool TryGetDragPosition(Vector2 pointerPosition, ref DragPosition dragPosition) { }

	protected private virtual void UpdateDrag(Vector3 pointerPosition) { }

}

