namespace Unity.VisualScripting;

public sealed class InvalidConnection : UnitConnection<IUnitOutputPort, IUnitInputPort>, IUnitConnection, IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public virtual IUnitInputPort destination
	{
		 get { } //Length: 198
	}

	public virtual bool destinationExists
	{
		 get { } //Length: 198
	}

	public virtual IUnitOutputPort source
	{
		 get { } //Length: 198
	}

	public virtual bool sourceExists
	{
		 get { } //Length: 198
	}

	public IUnitInputPort validDestination
	{
		 get { } //Length: 198
	}

	public bool validDestinationExists
	{
		 get { } //Length: 198
	}

	public IUnitOutputPort validSource
	{
		 get { } //Length: 198
	}

	public bool validSourceExists
	{
		 get { } //Length: 198
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public InvalidConnection() { }

	public InvalidConnection(IUnitOutputPort source, IUnitInputPort destination) { }

	[CompilerGenerated]
	private bool <get_destination>b__6_0(IUnitInputPort p) { }

	[CompilerGenerated]
	private bool <get_destinationExists>b__14_0(IUnitInputPort p) { }

	[CompilerGenerated]
	private bool <get_source>b__4_0(IUnitOutputPort p) { }

	[CompilerGenerated]
	private bool <get_sourceExists>b__12_0(IUnitOutputPort p) { }

	[CompilerGenerated]
	private bool <get_validDestination>b__10_0(IUnitInputPort p) { }

	[CompilerGenerated]
	private bool <get_validDestinationExists>b__18_0(IUnitInputPort p) { }

	[CompilerGenerated]
	private bool <get_validSource>b__8_0(IUnitOutputPort p) { }

	[CompilerGenerated]
	private bool <get_validSourceExists>b__16_0(IUnitOutputPort p) { }

	public virtual void AfterRemove() { }

	public virtual IUnitInputPort get_destination() { }

	public virtual bool get_destinationExists() { }

	public virtual IUnitOutputPort get_source() { }

	public virtual bool get_sourceExists() { }

	public IUnitInputPort get_validDestination() { }

	public bool get_validDestinationExists() { }

	public IUnitOutputPort get_validSource() { }

	public bool get_validSourceExists() { }

	public virtual bool HandleDependencies() { }

	private override FlowGraph Unity.VisualScripting.IUnitConnection.get_graph() { }

}

