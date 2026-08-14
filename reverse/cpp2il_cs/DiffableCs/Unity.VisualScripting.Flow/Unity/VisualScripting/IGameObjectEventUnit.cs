namespace Unity.VisualScripting;

public interface IGameObjectEventUnit : IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
{

	public Type MessageListenerType
	{
		 get { } //Length: 0
	}

	public Type get_MessageListenerType() { }

}

