namespace Unity.VisualScripting;

public interface IUnitConnection : IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public FlowGraph graph
	{
		 get { } //Length: 0
	}

	public FlowGraph get_graph() { }

}

