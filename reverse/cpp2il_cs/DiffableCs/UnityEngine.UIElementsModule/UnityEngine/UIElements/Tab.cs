namespace UnityEngine.UIElements;

public class Tab : VisualElement
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static EventCallback<TooltipEvent> <>9__63_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__63_0(TooltipEvent evt) { }

	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Tab, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private readonly UxmlStringAttributeDescription m_Label; //Field offset: 0x88
		private readonly UxmlImageAttributeDescription m_IconImage; //Field offset: 0x90
		private readonly UxmlBoolAttributeDescription m_Closeable; //Field offset: 0x98

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId labelProperty; //Field offset: 0x0
	internal static readonly BindingId iconImageProperty; //Field offset: 0x98
	internal static readonly BindingId closeableProperty; //Field offset: 0x130
	public static readonly string ussClassName; //Field offset: 0x1C8
	public static readonly string tabHeaderUssClassName; //Field offset: 0x1D0
	public static readonly string tabHeaderImageUssClassName; //Field offset: 0x1D8
	public static readonly string tabHeaderEmptyImageUssClassName; //Field offset: 0x1E0
	public static readonly string tabHeaderStandaloneImageUssClassName; //Field offset: 0x1E8
	public static readonly string tabHeaderLabelUssClassName; //Field offset: 0x1F0
	public static readonly string tabHeaderEmptyLabeUssClassName; //Field offset: 0x1F8
	public static readonly string tabHeaderUnderlineUssClassName; //Field offset: 0x200
	public static readonly string contentUssClassName; //Field offset: 0x208
	public static readonly string draggingUssClassName; //Field offset: 0x210
	public static readonly string reorderableUssClassName; //Field offset: 0x218
	public static readonly string reorderableItemHandleUssClassName; //Field offset: 0x220
	public static readonly string reorderableItemHandleBarUssClassName; //Field offset: 0x228
	public static readonly string closeableUssClassName; //Field offset: 0x230
	public static readonly string closeButtonUssClassName; //Field offset: 0x238
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Tab> selected; //Field offset: 0x4A8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Func<Boolean> closing; //Field offset: 0x4B0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Tab> closed; //Field offset: 0x4B8
	private string m_Label; //Field offset: 0x4C0
	private Background m_IconImage; //Field offset: 0x4C8
	private bool m_Closeable; //Field offset: 0x4E8
	private VisualElement m_ContentContainer; //Field offset: 0x4F0
	private VisualElement m_DragHandle; //Field offset: 0x4F8
	private VisualElement m_CloseButton; //Field offset: 0x500
	private VisualElement m_TabHeader; //Field offset: 0x508
	private Image m_TabHeaderImage; //Field offset: 0x510
	private Label m_TabHeaderLabel; //Field offset: 0x518
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly TabDragger <dragger>k__BackingField; //Field offset: 0x520

	public event Action<Tab> selected
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	[CreateProperty]
	public bool closeable
	{
		 get { } //Length: 8
		 set { } //Length: 268
	}

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 8
	}

	[CreateProperty]
	public Background iconImage
	{
		 get { } //Length: 25
		 set { } //Length: 853
	}

	[CreateProperty]
	public string label
	{
		 get { } //Length: 8
		 set { } //Length: 341
	}

	public VisualElement tabHeader
	{
		 get { } //Length: 8
	}

	private static Tab() { }

	public Tab() { }

	public Tab(string label, Background iconImage) { }

	[CompilerGenerated]
	public void add_selected(Action<Tab> value) { }

	private void AddCloseButton() { }

	private void AddDragHandles() { }

	internal void EnableTabCloseButton(bool enable) { }

	internal void EnableTabDragHandles(bool enable) { }

	public bool get_closeable() { }

	public virtual VisualElement get_contentContainer() { }

	public Background get_iconImage() { }

	public string get_label() { }

	public VisualElement get_tabHeader() { }

	private void OnCloseButtonClicked(PointerDownEvent evt) { }

	private void OnTabClicked(PointerDownEvent _) { }

	[CompilerGenerated]
	public void remove_selected(Action<Tab> value) { }

	private void RemoveCloseButton() { }

	private void RemoveDragHandles() { }

	public void set_closeable(bool value) { }

	public void set_iconImage(Background value) { }

	public void set_label(string value) { }

	internal void SetActive() { }

	internal void SetInactive() { }

	private void UpdateTooltip(TooltipEvent evt) { }

}

