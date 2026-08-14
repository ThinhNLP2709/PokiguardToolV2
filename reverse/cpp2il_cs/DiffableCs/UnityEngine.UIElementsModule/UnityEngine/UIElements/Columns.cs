namespace UnityEngine.UIElements;

[DefaultMember("Item")]
[UxmlObject]
public class Columns : ICollection<Column>, IEnumerable<Column>, IEnumerable, INotifyBindablePropertyChanged
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Column> <>9__87_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <UpdateVisibleColumns>b__87_0(Column c) { }

	}

	internal enum StretchMode
	{
		Grow = 0,
		GrowAndFill = 1,
	}

	[Obsolete("UxmlObjectFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	public class UxmlObjectFactory : UxmlObjectFactory<Columns>
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
		private readonly UxmlStringAttributeDescription m_PrimaryColumnName; //Field offset: 0x0
		private readonly UxmlEnumAttributeDescription<StretchMode> m_StretchMode; //Field offset: 0x0
		private readonly UxmlBoolAttributeDescription m_Reorderable; //Field offset: 0x0
		private readonly UxmlBoolAttributeDescription m_Resizable; //Field offset: 0x0
		private readonly UxmlBoolAttributeDescription m_ResizePreview; //Field offset: 0x0
		private readonly UxmlObjectListAttributeDescription<Column> m_Columns; //Field offset: 0x0

		public UxmlObjectTraits`1() { }

		public virtual void Init(ref T obj, IUxmlAttributes bag, CreationContext cc) { }

	}

	private static readonly BindingId primaryColumnNameProperty; //Field offset: 0x0
	private static readonly BindingId reorderableProperty; //Field offset: 0x98
	private static readonly BindingId resizableProperty; //Field offset: 0x130
	private static readonly BindingId resizePreviewProperty; //Field offset: 0x1C8
	private static readonly BindingId stretchModeProperty; //Field offset: 0x260
	private IList<Column> m_Columns; //Field offset: 0x10
	private List<Column> m_DisplayColumns; //Field offset: 0x18
	private List<Column> m_VisibleColumns; //Field offset: 0x20
	private bool m_VisibleColumnsDirty; //Field offset: 0x28
	private StretchMode m_StretchMode; //Field offset: 0x2C
	private bool m_Reorderable; //Field offset: 0x30
	private bool m_Resizable; //Field offset: 0x31
	private bool m_ResizePreview; //Field offset: 0x32
	private string m_PrimaryColumnName; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<BindablePropertyChangedEventArgs> propertyChanged; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<ColumnsDataType> changed; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column, Int32> columnAdded; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column> columnRemoved; //Field offset: 0x58
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column, ColumnDataType> columnChanged; //Field offset: 0x60
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column> columnResized; //Field offset: 0x68
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Column, Int32, Int32> columnReordered; //Field offset: 0x70

	internal event Action<ColumnsDataType> changed
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	internal event Action<Column, Int32> columnAdded
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	internal event Action<Column, ColumnDataType> columnChanged
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	internal event Action<Column> columnRemoved
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	internal event Action<Column, Int32, Int32> columnReordered
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	internal event Action<Column> columnResized
	{
		[CompilerGenerated]
		internal add { } //Length: 172
		[CompilerGenerated]
		internal remove { } //Length: 172
	}

	public override event EventHandler<BindablePropertyChangedEventArgs> propertyChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public override int Count
	{
		 get { } //Length: 70
	}

	internal IEnumerable<Column> displayList
	{
		internal get { } //Length: 26
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 73
	}

	public Column Item
	{
		 get { } //Length: 84
	}

	public Column Item
	{
		 get { } //Length: 372
	}

	[CreateProperty]
	public string primaryColumnName
	{
		 get { } //Length: 5
		 set { } //Length: 164
	}

	[CreateProperty]
	public bool reorderable
	{
		 get { } //Length: 5
		 set { } //Length: 149
	}

	[CreateProperty]
	public bool resizable
	{
		 get { } //Length: 5
		 set { } //Length: 149
	}

	[CreateProperty]
	public bool resizePreview
	{
		 get { } //Length: 5
		 set { } //Length: 149
	}

	[CreateProperty]
	public StretchMode stretchMode
	{
		 get { } //Length: 4
		 set { } //Length: 146
	}

	internal IEnumerable<Column> visibleList
	{
		internal get { } //Length: 26
	}

	private static Columns() { }

	public Columns() { }

	public override void Add(Column item) { }

	[CompilerGenerated]
	internal void add_changed(Action<ColumnsDataType> value) { }

	[CompilerGenerated]
	internal void add_columnAdded(Action<Column, Int32> value) { }

	[CompilerGenerated]
	internal void add_columnChanged(Action<Column, ColumnDataType> value) { }

	[CompilerGenerated]
	internal void add_columnRemoved(Action<Column> value) { }

	[CompilerGenerated]
	internal void add_columnReordered(Action<Column, Int32, Int32> value) { }

	[CompilerGenerated]
	internal void add_columnResized(Action<Column> value) { }

	[CompilerGenerated]
	public override void add_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	public override void Clear() { }

	public bool Contains(string name) { }

	public override bool Contains(Column item) { }

	public override void CopyTo(Column[] array, int arrayIndex) { }

	private void DirtyVisibleColumns() { }

	public override int get_Count() { }

	internal IEnumerable<Column> get_displayList() { }

	public override bool get_IsReadOnly() { }

	public Column get_Item(int index) { }

	public Column get_Item(string name) { }

	public string get_primaryColumnName() { }

	public bool get_reorderable() { }

	public bool get_resizable() { }

	public bool get_resizePreview() { }

	public StretchMode get_stretchMode() { }

	internal IEnumerable<Column> get_visibleList() { }

	public override IEnumerator<Column> GetEnumerator() { }

	public int IndexOf(Column column) { }

	private void InitOrderColumns() { }

	public void Insert(int index, Column column) { }

	public bool IsPrimary(Column column) { }

	private void NotifyChange(ColumnsDataType type) { }

	private void NotifyPropertyChanged(in BindingId property) { }

	private void OnColumnChanged(Column column, ColumnDataType type) { }

	private void OnColumnResized(Column column) { }

	private void OnColumnsPropertyChanged(object sender, BindablePropertyChangedEventArgs args) { }

	public override bool Remove(Column column) { }

	[CompilerGenerated]
	internal void remove_changed(Action<ColumnsDataType> value) { }

	[CompilerGenerated]
	internal void remove_columnAdded(Action<Column, Int32> value) { }

	[CompilerGenerated]
	internal void remove_columnChanged(Action<Column, ColumnDataType> value) { }

	[CompilerGenerated]
	internal void remove_columnRemoved(Action<Column> value) { }

	[CompilerGenerated]
	internal void remove_columnReordered(Action<Column, Int32, Int32> value) { }

	[CompilerGenerated]
	internal void remove_columnResized(Action<Column> value) { }

	[CompilerGenerated]
	public override void remove_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	public void ReorderDisplay(int from, int to) { }

	public void set_primaryColumnName(string value) { }

	public void set_reorderable(bool value) { }

	public void set_resizable(bool value) { }

	public void set_resizePreview(bool value) { }

	public void set_stretchMode(StretchMode value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private void UpdateVisibleColumns() { }

}

