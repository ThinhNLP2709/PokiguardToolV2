namespace Unity.VisualScripting;

public interface IGraphElementWithData : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public IGraphElementData CreateData() { }

}

