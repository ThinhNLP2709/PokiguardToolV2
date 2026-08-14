namespace UnityEngine.UIElements;

public abstract class BaseListView : BaseVerticalCollectionView
{
	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private readonly UxmlBoolAttributeDescription m_ShowFoldoutHeader; //Field offset: 0xC8
		private readonly UxmlStringAttributeDescription m_HeaderTitle; //Field offset: 0xD0
		private readonly UxmlBoolAttributeDescription m_ShowAddRemoveFooter; //Field offset: 0xD8
		private readonly UxmlBoolAttributeDescription m_AllowAdd; //Field offset: 0xE0
		private readonly UxmlBoolAttributeDescription m_AllowRemove; //Field offset: 0xE8
		private readonly UxmlEnumAttributeDescription<ListViewReorderMode> m_ReorderMode; //Field offset: 0xF0
		private readonly UxmlBoolAttributeDescription m_ShowBoundCollectionSize; //Field offset: 0xF8
		private readonly UxmlEnumAttributeDescription<BindingSourceSelectionMode> m_BindingSourceSelectionMode; //Field offset: 0x100

		protected UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	private static readonly string k_SizeFieldLabel; //Field offset: 0x0
	internal static readonly BindingId showBoundCollectionSizeProperty; //Field offset: 0x8
	internal static readonly BindingId showFoldoutHeaderProperty; //Field offset: 0xA0
	internal static readonly BindingId headerTitleProperty; //Field offset: 0x138
	internal static readonly BindingId makeHeaderProperty; //Field offset: 0x1D0
	internal static readonly BindingId makeFooterProperty; //Field offset: 0x268
	internal static readonly BindingId showAddRemoveFooterProperty; //Field offset: 0x300
	internal static readonly BindingId bindingSourceSelectionModeProperty; //Field offset: 0x398
	internal static readonly BindingId reorderModeProperty; //Field offset: 0x430
	internal static readonly BindingId makeNoneElementProperty; //Field offset: 0x4C8
	internal static readonly BindingId allowAddProperty; //Field offset: 0x560
	internal static readonly BindingId overridingAddButtonBehaviorProperty; //Field offset: 0x5F8
	internal static readonly BindingId onAddProperty; //Field offset: 0x690
	internal static readonly BindingId allowRemoveProperty; //Field offset: 0x728
	internal static readonly BindingId onRemoveProperty; //Field offset: 0x7C0
	public static readonly string ussClassName; //Field offset: 0x858
	public static readonly string itemUssClassName; //Field offset: 0x860
	public static readonly string emptyLabelUssClassName; //Field offset: 0x868
	public static readonly string overMaxMultiEditLimitClassName; //Field offset: 0x870
	public static readonly string reorderableUssClassName; //Field offset: 0x878
	public static readonly string reorderableItemUssClassName; //Field offset: 0x880
	public static readonly string reorderableItemContainerUssClassName; //Field offset: 0x888
	public static readonly string reorderableItemHandleUssClassName; //Field offset: 0x890
	public static readonly string reorderableItemHandleBarUssClassName; //Field offset: 0x898
	public static readonly string footerUssClassName; //Field offset: 0x8A0
	public static readonly string foldoutHeaderUssClassName; //Field offset: 0x8A8
	public static readonly string arraySizeFieldUssClassName; //Field offset: 0x8B0
	public static readonly string arraySizeFieldWithHeaderUssClassName; //Field offset: 0x8B8
	public static readonly string arraySizeFieldWithFooterUssClassName; //Field offset: 0x8C0
	public static readonly string listViewWithHeaderUssClassName; //Field offset: 0x8C8
	public static readonly string listViewWithFooterUssClassName; //Field offset: 0x8D0
	public static readonly string scrollViewWithFooterUssClassName; //Field offset: 0x8D8
	public static readonly string footerAddButtonName; //Field offset: 0x8E0
	public static readonly string footerRemoveButtonName; //Field offset: 0x8E8
	private static readonly string k_EmptyListStr; //Field offset: 0x8F0
	private bool m_ShowBoundCollectionSize; //Field offset: 0x590
	private bool m_ShowFoldoutHeader; //Field offset: 0x591
	private string m_HeaderTitle; //Field offset: 0x598
	private VisualElement drawnHeader; //Field offset: 0x5A0
	private Func<VisualElement> m_MakeHeader; //Field offset: 0x5A8
	private VisualElement drawnFooter; //Field offset: 0x5B0
	private Func<VisualElement> m_MakeFooter; //Field offset: 0x5B8
	private bool m_ShowAddRemoveFooter; //Field offset: 0x5C0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<IEnumerable`1<Int32>> itemsAdded; //Field offset: 0x5C8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<IEnumerable`1<Int32>> itemsRemoved; //Field offset: 0x5D0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action itemsSourceSizeChanged; //Field offset: 0x5D8
	private IVisualElementScheduledItem m_TrackedItem; //Field offset: 0x5E0
	private Action m_TrackCount; //Field offset: 0x5E8
	private Func<Boolean> m_WhileAutoAssign; //Field offset: 0x5F0
	private BindingSourceSelectionMode m_BindingSourceSelectionMode; //Field offset: 0x5F8
	private Label m_ListViewLabel; //Field offset: 0x600
	private Foldout m_Foldout; //Field offset: 0x608
	private TextField m_ArraySizeField; //Field offset: 0x610
	private bool m_IsOverMultiEditLimit; //Field offset: 0x618
	private VisualElement m_Footer; //Field offset: 0x620
	private Button m_AddButton; //Field offset: 0x628
	private Button m_RemoveButton; //Field offset: 0x630
	private Action<IEnumerable`1<Int32>> m_ItemAddedCallback; //Field offset: 0x638
	private Action<IEnumerable`1<Int32>> m_ItemRemovedCallback; //Field offset: 0x640
	private Action m_ItemsSourceSizeChangedCallback; //Field offset: 0x648
	private ListViewReorderMode m_ReorderMode; //Field offset: 0x650
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action reorderModeChanged; //Field offset: 0x658
	private VisualElement m_NoneElement; //Field offset: 0x660
	private Func<VisualElement> m_MakeNoneElement; //Field offset: 0x668
	private bool m_AllowAdd; //Field offset: 0x670
	private Action<BaseListView, Button> m_OverridingAddButtonBehavior; //Field offset: 0x678
	private Action<BaseListView> m_OnAdd; //Field offset: 0x680
	private bool m_AllowRemove; //Field offset: 0x688
	private Action<BaseListView> m_OnRemove; //Field offset: 0x690
	private string m_MaxMultiEditStr; //Field offset: 0x698

	internal event Action reorderModeChanged
	{
		[CompilerGenerated]
		internal add { } //Length: 162
		[CompilerGenerated]
		internal remove { } //Length: 162
	}

	[CreateProperty]
	public bool allowAdd
	{
		 get { } //Length: 8
		 set { } //Length: 151
	}

	[CreateProperty]
	public bool allowRemove
	{
		 get { } //Length: 8
		 set { } //Length: 151
	}

	internal bool autoAssignSource
	{
		internal get { } //Length: 11
	}

	[CreateProperty]
	public BindingSourceSelectionMode bindingSourceSelectionMode
	{
		 get { } //Length: 7
		 set { } //Length: 195
	}

	internal VisualElement footer
	{
		internal get { } //Length: 8
	}

	[CreateProperty]
	public string headerTitle
	{
		 get { } //Length: 8
		 set { } //Length: 204
	}

	[CreateProperty]
	public Func<VisualElement> makeFooter
	{
		 get { } //Length: 8
		 set { } //Length: 587
	}

	[CreateProperty]
	public Func<VisualElement> makeHeader
	{
		 get { } //Length: 8
		 set { } //Length: 693
	}

	[CreateProperty]
	public Func<VisualElement> makeNoneElement
	{
		 get { } //Length: 8
		 set { } //Length: 213
	}

	[CreateProperty]
	public Action<BaseListView> onAdd
	{
		 get { } //Length: 8
		 set { } //Length: 165
	}

	[CreateProperty]
	public Action<BaseListView> onRemove
	{
		 get { } //Length: 8
		 set { } //Length: 165
	}

	[CreateProperty]
	public Action<BaseListView, Button> overridingAddButtonBehavior
	{
		 get { } //Length: 8
		 set { } //Length: 165
	}

	[CreateProperty]
	public ListViewReorderMode reorderMode
	{
		 get { } //Length: 7
		 set { } //Length: 184
	}

	[CreateProperty]
	public bool showAddRemoveFooter
	{
		 get { } //Length: 12
		 set { } //Length: 267
	}

	[CreateProperty]
	public bool showBoundCollectionSize
	{
		 get { } //Length: 8
		 set { } //Length: 134
	}

	[CreateProperty]
	public bool showFoldoutHeader
	{
		 get { } //Length: 8
		 set { } //Length: 549
	}

	private Action trackCount
	{
		private get { } //Length: 138
	}

	private IVisualElementScheduledItem trackItemCount
	{
		private get { } //Length: 518
	}

	private Func<Boolean> untilManualBindingSourceSelectionMode
	{
		private get { } //Length: 138
	}

	public BaseListViewController viewController
	{
		 get { } //Length: 117
	}

	private static BaseListView() { }

	public BaseListView(IList itemsSource, float itemHeight = -1) { }

	public BaseListView() { }

	[CompilerGenerated]
	private void <get_trackCount>b__65_0() { }

	[CompilerGenerated]
	private bool <get_untilManualBindingSourceSelectionMode>b__68_0() { }

	[CompilerGenerated]
	private void <OnAddClicked>b__81_0() { }

	[CompilerGenerated]
	internal void add_reorderModeChanged(Action value) { }

	private void AddFoldout() { }

	private void AddItems(int itemCount) { }

	internal virtual ICollectionDragAndDropController CreateDragAndDropController() { }

	internal virtual ListViewDragger CreateDragger() { }

	virtual void CreateVirtualizationController() { }

	private void EnableFooter(bool enabled) { }

	public bool get_allowAdd() { }

	public bool get_allowRemove() { }

	internal bool get_autoAssignSource() { }

	public BindingSourceSelectionMode get_bindingSourceSelectionMode() { }

	internal VisualElement get_footer() { }

	public string get_headerTitle() { }

	public Func<VisualElement> get_makeFooter() { }

	public Func<VisualElement> get_makeHeader() { }

	public Func<VisualElement> get_makeNoneElement() { }

	public Action<BaseListView> get_onAdd() { }

	public Action<BaseListView> get_onRemove() { }

	public Action<BaseListView, Button> get_overridingAddButtonBehavior() { }

	public ListViewReorderMode get_reorderMode() { }

	public bool get_showAddRemoveFooter() { }

	public bool get_showBoundCollectionSize() { }

	public bool get_showFoldoutHeader() { }

	private Action get_trackCount() { }

	private IVisualElementScheduledItem get_trackItemCount() { }

	private Func<Boolean> get_untilManualBindingSourceSelectionMode() { }

	public BaseListViewController get_viewController() { }

	virtual bool HandleItemNavigation(bool moveIn, bool altPressed) { }

	private void OnAddClicked() { }

	private void OnArraySizeFieldChanged(ChangeEvent<String> evt) { }

	private void OnItemAdded(IEnumerable<Int32> indices) { }

	private void OnItemsRemoved(IEnumerable<Int32> indices) { }

	private void OnItemsSourceSizeChanged() { }

	private void OnRemoveClicked() { }

	virtual void PostRefresh() { }

	[CompilerGenerated]
	internal void remove_reorderModeChanged(Action value) { }

	private void RemoveFoldout() { }

	public void set_allowAdd(bool value) { }

	public void set_allowRemove(bool value) { }

	public void set_bindingSourceSelectionMode(BindingSourceSelectionMode value) { }

	public void set_headerTitle(string value) { }

	public void set_makeFooter(Func<VisualElement> value) { }

	public void set_makeHeader(Func<VisualElement> value) { }

	public void set_makeNoneElement(Func<VisualElement> value) { }

	public void set_onAdd(Action<BaseListView> value) { }

	public void set_onRemove(Action<BaseListView> value) { }

	public void set_overridingAddButtonBehavior(Action<BaseListView, Button> value) { }

	public void set_reorderMode(ListViewReorderMode value) { }

	public void set_showAddRemoveFooter(bool value) { }

	public void set_showBoundCollectionSize(bool value) { }

	public void set_showFoldoutHeader(bool value) { }

	internal void SetupArraySizeField() { }

	public virtual void SetViewController(CollectionViewController controller) { }

	internal void UpdateArraySizeField() { }

	internal void UpdateListViewLabel() { }

}

