namespace UnityEngine.UIElements;

public class TabView : VisualElement
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public string key; //Field offset: 0x10

		public <>c__DisplayClass46_0() { }

		internal bool <FindTabByKey>b__0(Tab tab) { }

	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<TabView, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private readonly UxmlBoolAttributeDescription m_Reorderable; //Field offset: 0x88

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	private class ViewState : ISerializationCallbackReceiver
	{
		private bool m_HasPersistedData; //Field offset: 0x10
		[SerializeField]
		private List<String> m_TabOrder; //Field offset: 0x18
		[SerializeField]
		private string m_ActiveTabKey; //Field offset: 0x20

		public ViewState() { }

		internal void Apply(TabView tabView) { }

		public override void OnAfterDeserialize() { }

		public override void OnBeforeSerialize() { }

		internal void Save(TabView tabView) { }

	}

	internal static readonly BindingId reorderableProperty; //Field offset: 0x0
	public static readonly string ussClassName; //Field offset: 0x98
	public static readonly string headerContainerClassName; //Field offset: 0xA0
	public static readonly string contentContainerUssClassName; //Field offset: 0xA8
	public static readonly string reorderableUssClassName; //Field offset: 0xB0
	public static readonly string verticalUssClassName; //Field offset: 0xB8
	private VisualElement m_HeaderContainer; //Field offset: 0x4A8
	private VisualElement m_ContentContainer; //Field offset: 0x4B0
	private List<Tab> m_Tabs; //Field offset: 0x4B8
	private List<VisualElement> m_TabHeaders; //Field offset: 0x4C0
	private Tab m_ActiveTab; //Field offset: 0x4C8
	private ViewState m_ViewState; //Field offset: 0x4D0
	private bool m_ApplyingViewState; //Field offset: 0x4D8
	private bool m_Reordering; //Field offset: 0x4D9
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Tab, Tab> activeTabChanged; //Field offset: 0x4E0
	private bool m_Reorderable; //Field offset: 0x4E8

	public Tab activeTab
	{
		 get { } //Length: 8
		 set { } //Length: 421
	}

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 8
	}

	internal VisualElement header
	{
		internal get { } //Length: 8
	}

	[CreateProperty]
	public bool reorderable
	{
		 get { } //Length: 8
		 set { } //Length: 439
	}

	internal List<VisualElement> tabHeaders
	{
		internal get { } //Length: 8
	}

	internal List<Tab> tabs
	{
		internal get { } //Length: 8
	}

	private static TabView() { }

	public TabView() { }

	internal Tab FindTabByKey(string key) { }

	public Tab get_activeTab() { }

	public virtual VisualElement get_contentContainer() { }

	internal VisualElement get_header() { }

	public bool get_reorderable() { }

	internal List<VisualElement> get_tabHeaders() { }

	internal List<Tab> get_tabs() { }

	private void OnElementAdded(VisualElement ve) { }

	private void OnElementRemoved(VisualElement ve) { }

	private void OnTabSelected(Tab tab) { }

	internal virtual void OnViewDataReady() { }

	internal void ReorderTab(int from, int to) { }

	private void SaveViewState() { }

	public void set_activeTab(Tab value) { }

	public void set_reorderable(bool value) { }

}

