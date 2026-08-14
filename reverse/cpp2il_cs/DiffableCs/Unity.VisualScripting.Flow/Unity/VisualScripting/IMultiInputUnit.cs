namespace Unity.VisualScripting;

public interface IMultiInputUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public int inputCount
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public ReadOnlyCollection<ValueInput> multiInputs
	{
		 get { } //Length: 0
	}

	public int get_inputCount() { }

	public ReadOnlyCollection<ValueInput> get_multiInputs() { }

	public void set_inputCount(int value) { }

}

