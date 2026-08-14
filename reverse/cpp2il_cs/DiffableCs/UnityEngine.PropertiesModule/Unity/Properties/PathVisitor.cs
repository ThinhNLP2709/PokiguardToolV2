namespace Unity.Properties;

public abstract class PathVisitor : IPropertyBagVisitor, IPropertyVisitor
{
	[IsReadOnly]
	private struct PropertyScope : IDisposable
	{
		private readonly PathVisitor m_Visitor; //Field offset: 0x0
		private readonly IProperty m_Property; //Field offset: 0x8

		public PropertyScope(PathVisitor visitor, IProperty property) { }

		public override void Dispose() { }

	}

	private int m_PathIndex; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PropertyPath <Path>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private IProperty <Property>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <ReadonlyVisit>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisitReturnCode <ReturnCode>k__BackingField; //Field offset: 0xB4

	public PropertyPath Path
	{
		[CompilerGenerated]
		 get { } //Length: 84
		[CompilerGenerated]
		 set { } //Length: 91
	}

	private IProperty Property
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public bool ReadonlyVisit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public VisitReturnCode ReturnCode
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	protected PathVisitor() { }

	[CompilerGenerated]
	public PropertyPath get_Path() { }

	[CompilerGenerated]
	private IProperty get_Property() { }

	[CompilerGenerated]
	public bool get_ReadonlyVisit() { }

	[CompilerGenerated]
	public VisitReturnCode get_ReturnCode() { }

	public override void Reset() { }

	[CompilerGenerated]
	public void set_Path(PropertyPath value) { }

	[CompilerGenerated]
	private void set_Property(IProperty value) { }

	[CompilerGenerated]
	public void set_ReadonlyVisit(bool value) { }

	[CompilerGenerated]
	protected void set_ReturnCode(VisitReturnCode value) { }

	private override void Unity.Properties.IPropertyBagVisitor.Visit(IPropertyBag<TContainer> properties, ref TContainer container) { }

	private override void Unity.Properties.IPropertyVisitor.Visit(Property<TContainer, TValue> property, ref TContainer container) { }

	protected override void VisitPath(Property<TContainer, TValue> property, ref TContainer container, ref TValue value) { }

}

