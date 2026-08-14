namespace Unity.VisualScripting;

public abstract class UnitConnection : GraphElement<FlowGraph>, IConnection<TSourcePort, TDestinationPort>
{
	[CompilerGenerated]
	private IUnit <sourceUnit>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private string <sourceKey>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private IUnit <destinationUnit>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private string <destinationKey>k__BackingField; //Field offset: 0x0

	public virtual int dependencyOrder
	{
		 get { } //Length: 6
	}

	[DoNotSerialize]
	public abstract TDestinationPort destination
	{
		 get { } //Length: 0
	}

	public abstract bool destinationExists
	{
		 get { } //Length: 0
	}

	[Serialize]
	protected private string destinationKey
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[Serialize]
	protected private IUnit destinationUnit
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[DoNotSerialize]
	public abstract TSourcePort source
	{
		 get { } //Length: 0
	}

	public abstract bool sourceExists
	{
		 get { } //Length: 0
	}

	[Serialize]
	protected private string sourceKey
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[Serialize]
	protected private IUnit sourceUnit
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	protected UnitConnection`2() { }

	protected UnitConnection`2(TSourcePort source, TDestinationPort destination) { }

	protected void CopyFrom(UnitConnection<TSourcePort, TDestinationPort> source) { }

	public override IGraphElementDebugData CreateDebugData() { }

	public virtual int get_dependencyOrder() { }

	public abstract TDestinationPort get_destination() { }

	public abstract bool get_destinationExists() { }

	[CompilerGenerated]
	protected string get_destinationKey() { }

	[CompilerGenerated]
	protected IUnit get_destinationUnit() { }

	public abstract TSourcePort get_source() { }

	public abstract bool get_sourceExists() { }

	[CompilerGenerated]
	protected string get_sourceKey() { }

	[CompilerGenerated]
	protected IUnit get_sourceUnit() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	public virtual bool HandleDependencies() { }

	[CompilerGenerated]
	private void set_destinationKey(string value) { }

	[CompilerGenerated]
	private void set_destinationUnit(IUnit value) { }

	[CompilerGenerated]
	private void set_sourceKey(string value) { }

	[CompilerGenerated]
	private void set_sourceUnit(IUnit value) { }

}

