namespace Unity.VisualScripting;

public interface IVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public ValueInput name
	{
		 get { } //Length: 0
	}

	public ValueInput get_name() { }

}

