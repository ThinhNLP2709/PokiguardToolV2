namespace UnityEngine.UIElements;

[UxmlObject]
public class SortColumnDescription : INotifyBindablePropertyChanged
{
	[Obsolete("UxmlObjectFactory<T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	public class UxmlObjectFactory : UxmlObjectFactory<SortColumnDescription>
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
		private readonly UxmlStringAttributeDescription m_ColumnName; //Field offset: 0x0
		private readonly UxmlIntAttributeDescription m_ColumnIndex; //Field offset: 0x0
		private readonly UxmlEnumAttributeDescription<SortDirection> m_SortDescription; //Field offset: 0x0

		public UxmlObjectTraits`1() { }

		public virtual void Init(ref T obj, IUxmlAttributes bag, CreationContext cc) { }

	}

	private static readonly BindingId columnNameProperty; //Field offset: 0x0
	private static readonly BindingId columnIndexProperty; //Field offset: 0x98
	private static readonly BindingId directionProperty; //Field offset: 0x130
	[SerializeField]
	private int m_ColumnIndex; //Field offset: 0x10
	[SerializeField]
	private string m_ColumnName; //Field offset: 0x18
	[SerializeField]
	private SortDirection m_SortDirection; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventHandler<BindablePropertyChangedEventArgs> propertyChanged; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Column <column>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<SortColumnDescription> changed; //Field offset: 0x38

	internal event Action<SortColumnDescription> changed
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

	public internal Column column
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	[CreateProperty]
	public int columnIndex
	{
		 get { } //Length: 4
		 set { } //Length: 144
	}

	[CreateProperty]
	public string columnName
	{
		 get { } //Length: 5
		 set { } //Length: 165
	}

	[CreateProperty]
	public SortDirection direction
	{
		 get { } //Length: 4
		 set { } //Length: 144
	}

	private static SortColumnDescription() { }

	public SortColumnDescription(string columnName, SortDirection direction) { }

	public SortColumnDescription(int columnIndex, SortDirection direction) { }

	public SortColumnDescription() { }

	[CompilerGenerated]
	internal void add_changed(Action<SortColumnDescription> value) { }

	[CompilerGenerated]
	public override void add_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	[CompilerGenerated]
	public Column get_column() { }

	public int get_columnIndex() { }

	public string get_columnName() { }

	public SortDirection get_direction() { }

	private void NotifyPropertyChanged(in BindingId property) { }

	[CompilerGenerated]
	internal void remove_changed(Action<SortColumnDescription> value) { }

	[CompilerGenerated]
	public override void remove_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	[CompilerGenerated]
	internal void set_column(Column value) { }

	public void set_columnIndex(int value) { }

	public void set_columnName(string value) { }

	public void set_direction(SortDirection value) { }

}

