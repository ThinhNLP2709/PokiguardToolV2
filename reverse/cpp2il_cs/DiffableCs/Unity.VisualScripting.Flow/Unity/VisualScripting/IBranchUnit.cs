namespace Unity.VisualScripting;

[TypeIconPriority]
public interface IBranchUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public ControlInput enter
	{
		 get { } //Length: 0
	}

	public ControlInput get_enter() { }

}

