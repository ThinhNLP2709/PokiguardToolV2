namespace UnityEngine.UIElements.Internal;

internal class ColumnMover : PointerManipulator
{
	private float m_StartPos; //Field offset: 0x28
	private float m_LastPos; //Field offset: 0x2C
	private bool m_Active; //Field offset: 0x30
	private bool m_Moving; //Field offset: 0x31
	private bool m_Cancelled; //Field offset: 0x32
	private MultiColumnCollectionHeader m_Header; //Field offset: 0x38
	private VisualElement m_PreviewElement; //Field offset: 0x40
	private MultiColumnHeaderColumnMoveLocationPreview m_LocationPreviewElement; //Field offset: 0x48
	private Column m_ColumnToMove; //Field offset: 0x50
	private float m_ColumnToMovePos; //Field offset: 0x58
	private float m_ColumnToMoveWidth; //Field offset: 0x5C
	private Column m_DestinationColumn; //Field offset: 0x60
	private bool m_MoveBeforeDestination; //Field offset: 0x68
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ColumnLayout <columnLayout>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<ColumnMover> activeChanged; //Field offset: 0x78
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<ColumnMover> movingChanged; //Field offset: 0x80

	public event Action<ColumnMover> activeChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<ColumnMover> movingChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public bool active
	{
		 get { } //Length: 5
		 set { } //Length: 36
	}

	public ColumnLayout columnLayout
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public bool moving
	{
		 get { } //Length: 5
		 set { } //Length: 39
	}

	public ColumnMover() { }

	[CompilerGenerated]
	public void add_activeChanged(Action<ColumnMover> value) { }

	[CompilerGenerated]
	public void add_movingChanged(Action<ColumnMover> value) { }

	private void BeginDragMove(float pos) { }

	internal void DragMove(float pos) { }

	private void EndDragMove(bool cancelled) { }

	public bool get_active() { }

	[CompilerGenerated]
	public ColumnLayout get_columnLayout() { }

	public bool get_moving() { }

	private void OnKeyDown(KeyDownEvent e) { }

	private void OnPointerCancel(PointerCancelEvent evt) { }

	private void OnPointerCaptureOut(PointerCaptureOutEvent evt) { }

	private void OnPointerDown(PointerDownEvent evt) { }

	private void OnPointerMove(PointerMoveEvent evt) { }

	private void OnPointerUp(PointerUpEvent evt) { }

	protected void ProcessCancelEvent(EventBase evt, int pointerId) { }

	private void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId) { }

	private void ProcessMoveEvent(EventBase e, Vector2 localPosition) { }

	private void ProcessUpEvent(EventBase evt, Vector2 localPosition, int pointerId) { }

	protected virtual void RegisterCallbacksOnTarget() { }

	[CompilerGenerated]
	public void remove_activeChanged(Action<ColumnMover> value) { }

	[CompilerGenerated]
	public void remove_movingChanged(Action<ColumnMover> value) { }

	public void set_active(bool value) { }

	[CompilerGenerated]
	public void set_columnLayout(ColumnLayout value) { }

	public void set_moving(bool value) { }

	protected virtual void UnregisterCallbacksFromTarget() { }

	private void UpdateMoveLocation() { }

	private void UpdatePreviewPosition() { }

}

