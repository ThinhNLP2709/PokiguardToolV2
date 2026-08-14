namespace Unity.VisualScripting;

public interface IUnifiedVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public VariableKind kind
	{
		 get { } //Length: 0
	}

	public ValueInput name
	{
		 get { } //Length: 0
	}

	public VariableKind get_kind() { }

	public ValueInput get_name() { }

}

