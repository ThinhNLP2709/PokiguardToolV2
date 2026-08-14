namespace Unity.VisualScripting;

[TypeIconPriority]
public interface ISelectUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public ValueOutput selection
	{
		 get { } //Length: 0
	}

	public ValueOutput get_selection() { }

}

