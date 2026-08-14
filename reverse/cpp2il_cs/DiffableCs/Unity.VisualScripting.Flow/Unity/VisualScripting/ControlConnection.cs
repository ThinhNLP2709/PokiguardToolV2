namespace Unity.VisualScripting;

public sealed class ControlConnection : UnitConnection<ControlOutput, ControlInput>, IUnitConnection, IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public virtual ControlInput destination
	{
		 get { } //Length: 251
	}

	public virtual bool destinationExists
	{
		 get { } //Length: 138
	}

	public virtual ControlOutput source
	{
		 get { } //Length: 251
	}

	public virtual bool sourceExists
	{
		 get { } //Length: 138
	}

	private override IUnitInputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.destination
	{
		private get { } //Length: 20
	}

	private override IUnitOutputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.source
	{
		private get { } //Length: 20
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public ControlConnection() { }

	public ControlConnection(ControlOutput source, ControlInput destination) { }

	public virtual ControlInput get_destination() { }

	public virtual bool get_destinationExists() { }

	public virtual ControlOutput get_source() { }

	public virtual bool get_sourceExists() { }

	private override IUnitInputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.get_destination() { }

	private override IUnitOutputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.get_source() { }

	private override FlowGraph Unity.VisualScripting.IUnitConnection.get_graph() { }

}

