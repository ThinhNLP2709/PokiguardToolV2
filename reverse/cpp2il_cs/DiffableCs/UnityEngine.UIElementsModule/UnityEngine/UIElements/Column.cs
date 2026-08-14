namespace UnityEngine.UIElements;

[UxmlObject]
public class Column : INotifyBindablePropertyChanged
{
	[Obsolete("UxmlObjectFactory<T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	public class UxmlObjectFactory : UxmlObjectFactory<Column>
	{

		public UxmlObjectFactory() { }

	}

	[Obsolete("UxmlObjectFactory<T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	public class UxmlObjectFactory : UxmlObjectFactory<T, UxmlObjectTraits`1<T>>
	{

		public UxmlObjectFactory`1() { }

	}

	[Obsolete("UxmlObjectTraits<T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	public class UxmlObjectTraits : UxmlObjectTraits<T>
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass14_0
		{
			public VisualTreeAsset asset; //Field offset: 0x0

			public <>c__DisplayClass14_0() { }

			internal VisualElement <Init>b__0() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass14_1
		{
			public VisualTreeAsset asset; //Field offset: 0x0

			public <>c__DisplayClass14_1() { }

			internal VisualElement <Init>b__1() { }

		}

		private UxmlStringAttributeDescription m_Name; //Field offset: 0x0
		private UxmlStringAttributeDescription m_Text; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Visible; //Field offset: 0x0
		private UxmlStringAttributeDescription m_Width; //Field offset: 0x0
		private UxmlStringAttributeDescription m_MinWidth; //Field offset: 0x0
		private UxmlStringAttributeDescription m_MaxWidth; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Stretch; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Sortable; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Optional; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Resizable; //Field offset: 0x0
		private UxmlStringAttributeDescription m_HeaderTemplateId; //Field offset: 0x0
		private UxmlStringAttributeDescription m_CellTemplateId; //Field offset: 0x0
		private UxmlStringAttributeDescription m_BindingPath; //Field offset: 0x0

		public UxmlObjectTraits`1() { }

		public virtual void Init(ref T obj, IUxmlAttributes bag, CreationContext cc) { }

		private static Length ParseLength(string str, Length defaultValue) { }

	}

	private static readonly BindingId nameProperty; //Field offset: 0x0
	private static readonly BindingId titleProperty; //Field offset: 0x98
	private static readonly BindingId iconProperty; //Field offset: 0x130
	private static readonly BindingId visibleProperty; //Field offset: 0x1C8
	private static readonly BindingId widthProperty; //Field offset: 0x260
	private static readonly BindingId minWidthProperty; //Field offset: 0x2F8
	private static readonly BindingId maxWidthProperty; //Field offset: 0x390
	private static readonly BindingId sortableProperty; //Field offset: 0x428
	private static readonly BindingId stretchableProperty; //Field offset: 0x4C0
	private static readonly BindingId optionalProperty; //Field offset: 0x558
	private static readonly BindingId resizableProperty; //Field offset: 0x5F0
	private static readonly BindingId headerTemplateProperty; //Field offset: 0x688
	private static readonly BindingId cellTemplateProperty; //Field offset: 0x720
	private string m_Name; //Field offset: 0x10
	private string m_Title; //Field offset: 0x18
	private Background m_Icon; //Field offset: 0x20
	private bool m_Visible; //Field offset: 0x40
	private Length m_Width; //Field offset: 0x44
	private Length m_MinWidth; //Field offset: 0x4C
	private Length m_MaxWidth; //Field offset: 0x54
	private float m_DesiredWidth; //Field offset: 0x5C
	private bool m_Stretchable; //Field offset: 0x60
	private bool m_Sortable; //Field offset: 0x61
	private bool m_Optional; //Field offset: 0x62
	private bool m_Resizable; //Field offset: 0x63
	private VisualTreeAsset m_HeaderTemplate; //Field offset: 0x68
	private VisualTreeAsset m_CellTemplate; //Field offset: 0x70
	private Func<VisualElement> m_MakeHeader; //Field offset: 0x78
	private Action<VisualElement> m_BindHeader; //Field offset: 0x80
	private Action<VisualElement> m_UnbindHeader; //Field offset: 0x88
	private Action<VisualElement> m_DestroyHeader; //Field offset: 0x90
	private Func<VisualElement> m_MakeCell; //Field offset: 0x98
	private Action<VisualElement, Int32> m_BindCell; //Field offset: 0xA0
	private Action<VisualElement, Int32> m_UnbindCellItem; //Field offset: 0xA8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<BindablePropertyChangedEventArgs> propertyChanged; //Field offset: 0xB0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Comparison<Int32> <comparison>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <bindingPath>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<VisualElement> <destroyCell>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Columns <collection>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column, ColumnDataType> changed; //Field offset: 0xD8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column> resized; //Field offset: 0xE0

	internal event Action<Column, ColumnDataType> changed
	{
		[CompilerGenerated]
		internal add { } //Length: 186
		[CompilerGenerated]
		internal remove { } //Length: 186
	}

	public override event EventHandler<BindablePropertyChangedEventArgs> propertyChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	internal event Action<Column> resized
	{
		[CompilerGenerated]
		internal add { } //Length: 186
		[CompilerGenerated]
		internal remove { } //Length: 186
	}

	public Action<VisualElement, Int32> bindCell
	{
		 get { } //Length: 8
	}

	public Action<VisualElement> bindHeader
	{
		 get { } //Length: 8
	}

	public string bindingPath
	{
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[CreateProperty]
	public VisualTreeAsset cellTemplate
	{
		 get { } //Length: 5
		 set { } //Length: 227
	}

	public internal Columns collection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 19
	}

	public Comparison<Int32> comparison
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal float desiredWidth
	{
		internal get { } //Length: 6
		internal set { } //Length: 48
	}

	public Action<VisualElement> destroyCell
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Action<VisualElement> destroyHeader
	{
		 get { } //Length: 8
	}

	internal int displayIndex
	{
		internal get { } //Length: 169
	}

	[CreateProperty]
	public VisualTreeAsset headerTemplate
	{
		 get { } //Length: 5
		 set { } //Length: 227
	}

	[CreateProperty]
	public Background icon
	{
		 get { } //Length: 19
		 set { } //Length: 229
	}

	internal int index
	{
		internal get { } //Length: 113
	}

	public Func<VisualElement> makeCell
	{
		 get { } //Length: 8
		 set { } //Length: 103
	}

	public Func<VisualElement> makeHeader
	{
		 get { } //Length: 5
		 set { } //Length: 94
	}

	[CreateProperty]
	public Length maxWidth
	{
		 get { } //Length: 5
		 set { } //Length: 169
	}

	[CreateProperty]
	public Length minWidth
	{
		 get { } //Length: 5
		 set { } //Length: 169
	}

	[CreateProperty]
	public string name
	{
		 get { } //Length: 5
		 set { } //Length: 171
	}

	[CreateProperty]
	public bool optional
	{
		 get { } //Length: 5
		 set { } //Length: 156
	}

	[CreateProperty]
	public bool resizable
	{
		 get { } //Length: 5
		 set { } //Length: 156
	}

	[CreateProperty]
	public bool sortable
	{
		 get { } //Length: 5
		 set { } //Length: 156
	}

	[CreateProperty]
	public bool stretchable
	{
		 get { } //Length: 5
		 set { } //Length: 156
	}

	[CreateProperty]
	public string title
	{
		 get { } //Length: 5
		 set { } //Length: 181
	}

	public Action<VisualElement, Int32> unbindCell
	{
		 get { } //Length: 8
	}

	public Action<VisualElement> unbindHeader
	{
		 get { } //Length: 8
	}

	[CreateProperty]
	public bool visible
	{
		 get { } //Length: 5
		 set { } //Length: 156
	}

	internal int visibleIndex
	{
		internal get { } //Length: 169
	}

	[CreateProperty]
	public Length width
	{
		 get { } //Length: 5
		 set { } //Length: 225
	}

	private static Column() { }

	public Column() { }

	[CompilerGenerated]
	internal void add_changed(Action<Column, ColumnDataType> value) { }

	[CompilerGenerated]
	public override void add_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	[CompilerGenerated]
	internal void add_resized(Action<Column> value) { }

	public Action<VisualElement, Int32> get_bindCell() { }

	public Action<VisualElement> get_bindHeader() { }

	public VisualTreeAsset get_cellTemplate() { }

	[CompilerGenerated]
	public Columns get_collection() { }

	[CompilerGenerated]
	public Comparison<Int32> get_comparison() { }

	internal float get_desiredWidth() { }

	[CompilerGenerated]
	public Action<VisualElement> get_destroyCell() { }

	public Action<VisualElement> get_destroyHeader() { }

	internal int get_displayIndex() { }

	public VisualTreeAsset get_headerTemplate() { }

	public Background get_icon() { }

	internal int get_index() { }

	public Func<VisualElement> get_makeCell() { }

	public Func<VisualElement> get_makeHeader() { }

	public Length get_maxWidth() { }

	public Length get_minWidth() { }

	public string get_name() { }

	public bool get_optional() { }

	public bool get_resizable() { }

	public bool get_sortable() { }

	public bool get_stretchable() { }

	public string get_title() { }

	public Action<VisualElement, Int32> get_unbindCell() { }

	public Action<VisualElement> get_unbindHeader() { }

	public bool get_visible() { }

	internal int get_visibleIndex() { }

	public Length get_width() { }

	internal float GetMaxWidth(float layoutWidth) { }

	internal float GetMinWidth(float layoutWidth) { }

	internal float GetWidth(float layoutWidth) { }

	private void NotifyChange(ColumnDataType type) { }

	private void NotifyPropertyChanged(in BindingId property) { }

	[CompilerGenerated]
	internal void remove_changed(Action<Column, ColumnDataType> value) { }

	[CompilerGenerated]
	public override void remove_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	[CompilerGenerated]
	internal void remove_resized(Action<Column> value) { }

	[CompilerGenerated]
	public void set_bindingPath(string value) { }

	public void set_cellTemplate(VisualTreeAsset value) { }

	[CompilerGenerated]
	internal void set_collection(Columns value) { }

	internal void set_desiredWidth(float value) { }

	public void set_headerTemplate(VisualTreeAsset value) { }

	public void set_icon(Background value) { }

	public void set_makeCell(Func<VisualElement> value) { }

	public void set_makeHeader(Func<VisualElement> value) { }

	public void set_maxWidth(Length value) { }

	public void set_minWidth(Length value) { }

	public void set_name(string value) { }

	public void set_optional(bool value) { }

	public void set_resizable(bool value) { }

	public void set_sortable(bool value) { }

	public void set_stretchable(bool value) { }

	public void set_title(string value) { }

	public void set_visible(bool value) { }

	public void set_width(Length value) { }

}

