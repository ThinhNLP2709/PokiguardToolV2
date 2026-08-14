namespace UnityEngine.UIElements;

public abstract class BaseTreeView : BaseVerticalCollectionView
{
	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private readonly UxmlBoolAttributeDescription m_AutoExpand; //Field offset: 0xC8

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId autoExpandProperty; //Field offset: 0x0
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static readonly int invalidId; //Field offset: 0x98
	public static readonly string ussClassName; //Field offset: 0xA0
	public static readonly string itemUssClassName; //Field offset: 0xA8
	public static readonly string itemToggleUssClassName; //Field offset: 0xB0
	[Obsolete("Individual item indents are no longer used, see itemIndentUssClassName instead", False)]
	public static readonly string itemIndentsContainerUssClassName; //Field offset: 0xB8
	public static readonly string itemIndentUssClassName; //Field offset: 0xC0
	public static readonly string itemContentContainerUssClassName; //Field offset: 0xC8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<TreeViewExpansionChangedArgs> itemExpandedChanged; //Field offset: 0x590
	private bool m_AutoExpand; //Field offset: 0x598
	[DontCreateProperty]
	[SerializeField]
	private List<Int32> m_ExpandedItemIds; //Field offset: 0x5A0

	[CreateProperty]
	public bool autoExpand
	{
		 get { } //Length: 8
		 set { } //Length: 130
	}

	internal List<Int32> expandedItemIds
	{
		internal get { } //Length: 8
		internal set { } //Length: 19
	}

	[CreateProperty(ReadOnly = True)]
	public internal IList itemsSource
	{
		 get { } //Length: 48
		internal set { } //Length: 121
	}

	public BaseTreeViewController viewController
	{
		 get { } //Length: 117
	}

	private static BaseTreeView() { }

	public BaseTreeView(int itemHeight) { }

	public BaseTreeView() { }

	[CompilerGenerated]
	private int <SetSelectionInternalById>b__54_0(int id) { }

	public void CollapseItem(int id, bool collapseAllChildren = false, bool refresh = true) { }

	private void CollapseItemByIndex(int index, bool collapseAll) { }

	internal virtual ICollectionDragAndDropController CreateDragAndDropController() { }

	virtual void CreateVirtualizationController() { }

	public void ExpandItem(int id, bool expandAllChildren = false, bool refresh = true) { }

	private void ExpandItemByIndex(int index, bool expandAll) { }

	public bool get_autoExpand() { }

	internal List<Int32> get_expandedItemIds() { }

	public IList get_itemsSource() { }

	public BaseTreeViewController get_viewController() { }

	private int GetItemIndex(int id, bool expand = false) { }

	virtual bool HandleItemNavigation(bool moveIn, bool altPressed) { }

	public bool IsExpanded(int id) { }

	private bool IsExpandedByIndex(int index) { }

	private void OnItemExpandedChanged(TreeViewExpansionChangedArgs arg) { }

	private void OnItemIndexChanged(int srcIndex, int dstIndex) { }

	internal virtual void OnViewDataReady() { }

	public void set_autoExpand(bool value) { }

	internal void set_expandedItemIds(List<Int32> value) { }

	internal void set_itemsSource(IList value) { }

	public void SetSelectionById(int id) { }

	public void SetSelectionById(IEnumerable<Int32> ids) { }

	internal void SetSelectionInternalById(IEnumerable<Int32> ids, bool sendNotification) { }

	public virtual void SetViewController(CollectionViewController controller) { }

}

