namespace UnityEngine.UIElements;

public class TreeView : BaseTreeView
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<TreeView, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlAssetAttributeDescription<VisualTreeAsset> m_ItemTemplate; //Field offset: 0xD0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId itemTemplateProperty; //Field offset: 0x0
	internal static readonly BindingId makeItemProperty; //Field offset: 0x98
	internal static readonly BindingId bindItemProperty; //Field offset: 0x130
	internal static readonly BindingId unbindItemProperty; //Field offset: 0x1C8
	internal static readonly BindingId destroyItemProperty; //Field offset: 0x260
	private Func<VisualElement> m_MakeItem; //Field offset: 0x5A8
	private Func<VisualElement> m_TemplateMakeItem; //Field offset: 0x5B0
	private VisualTreeAsset m_ItemTemplate; //Field offset: 0x5B8
	private Action<VisualElement, Int32> m_BindItem; //Field offset: 0x5C0
	private Action<VisualElement, Int32> m_UnbindItem; //Field offset: 0x5C8
	private Action<VisualElement> m_DestroyItem; //Field offset: 0x5D0

	[CreateProperty]
	public Action<VisualElement, Int32> bindItem
	{
		 get { } //Length: 8
		 set { } //Length: 165
	}

	[CreateProperty]
	public Action<VisualElement> destroyItem
	{
		 get { } //Length: 8
		 set { } //Length: 155
	}

	[CreateProperty]
	public VisualTreeAsset itemTemplate
	{
		 get { } //Length: 8
		 set { } //Length: 247
	}

	[CreateProperty]
	public Func<VisualElement> makeItem
	{
		 get { } //Length: 8
		 set { } //Length: 165
	}

	[CreateProperty]
	public Action<VisualElement, Int32> unbindItem
	{
		 get { } //Length: 8
		 set { } //Length: 155
	}

	private static TreeView() { }

	public TreeView() { }

	public TreeView(Func<VisualElement> makeItem, Action<VisualElement, Int32> bindItem) { }

	protected virtual CollectionViewController CreateViewController() { }

	public Action<VisualElement, Int32> get_bindItem() { }

	public Action<VisualElement> get_destroyItem() { }

	public VisualTreeAsset get_itemTemplate() { }

	public Func<VisualElement> get_makeItem() { }

	public Action<VisualElement, Int32> get_unbindItem() { }

	internal virtual bool HasValidDataAndBindings() { }

	public void set_bindItem(Action<VisualElement, Int32> value) { }

	public void set_destroyItem(Action<VisualElement> value) { }

	public void set_itemTemplate(VisualTreeAsset value) { }

	public void set_makeItem(Func<VisualElement> value) { }

	public void set_unbindItem(Action<VisualElement, Int32> value) { }

	private VisualElement TemplateMakeItem() { }

}

