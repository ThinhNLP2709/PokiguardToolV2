namespace UnityEngine.UIElements;

public class MultiColumnListView : BaseListView
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<MultiColumnListView, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private readonly UxmlEnumAttributeDescription<ColumnSortingMode> m_SortingMode; //Field offset: 0x108
		private readonly UxmlObjectAttributeDescription<Columns> m_Columns; //Field offset: 0x110
		private readonly UxmlObjectAttributeDescription<SortColumnDescriptions> m_SortColumnDescriptions; //Field offset: 0x118

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	private static readonly BindingId columnsProperty; //Field offset: 0x0
	private static readonly BindingId sortColumnDescriptionsProperty; //Field offset: 0x98
	private static readonly BindingId sortingModeProperty; //Field offset: 0x130
	private Columns m_Columns; //Field offset: 0x6A0
	private ColumnSortingMode m_SortingMode; //Field offset: 0x6A8
	private SortColumnDescriptions m_SortColumnDescriptions; //Field offset: 0x6B0
	private List<SortColumnDescription> m_SortedColumns; //Field offset: 0x6B8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action columnSortingChanged; //Field offset: 0x6C0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<ContextualMenuPopulateEvent, Column> headerContextMenuPopulateEvent; //Field offset: 0x6C8

	[CreateProperty]
	public private Columns columns
	{
		 get { } //Length: 8
		private set { } //Length: 371
	}

	[CreateProperty]
	public private SortColumnDescriptions sortColumnDescriptions
	{
		 get { } //Length: 8
		private set { } //Length: 273
	}

	[CreateProperty]
	public ColumnSortingMode sortingMode
	{
		 get { } //Length: 7
		 set { } //Length: 178
	}

	public MultiColumnListViewController viewController
	{
		 get { } //Length: 123
	}

	private static MultiColumnListView() { }

	public MultiColumnListView() { }

	public MultiColumnListView(Columns columns) { }

	private void ColumnsChanged(object sender, BindablePropertyChangedEventArgs args) { }

	protected virtual CollectionViewController CreateViewController() { }

	virtual void CreateVirtualizationController() { }

	public Columns get_columns() { }

	public SortColumnDescriptions get_sortColumnDescriptions() { }

	public ColumnSortingMode get_sortingMode() { }

	public MultiColumnListViewController get_viewController() { }

	private void RaiseColumnSortingChanged() { }

	private void RaiseHeaderContextMenuPopulate(ContextualMenuPopulateEvent evt, Column column) { }

	private void set_columns(Columns value) { }

	private void set_sortColumnDescriptions(SortColumnDescriptions value) { }

	public void set_sortingMode(ColumnSortingMode value) { }

	public virtual void SetViewController(CollectionViewController controller) { }

}

