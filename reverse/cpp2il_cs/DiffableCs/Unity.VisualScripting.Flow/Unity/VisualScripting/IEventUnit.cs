namespace Unity.VisualScripting;

public interface IEventUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
{

	public bool coroutine
	{
		 get { } //Length: 0
	}

	public bool get_coroutine() { }

}

