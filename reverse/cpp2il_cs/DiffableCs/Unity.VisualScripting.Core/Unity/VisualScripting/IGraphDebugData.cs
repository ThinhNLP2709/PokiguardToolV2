namespace Unity.VisualScripting;

public interface IGraphDebugData
{

	public IEnumerable<IGraphElementDebugData> elementsData
	{
		 get { } //Length: 0
	}

	public IEnumerable<IGraphElementDebugData> get_elementsData() { }

	public IGraphDebugData GetOrCreateChildGraphData(IGraphParentElement element) { }

	public IGraphElementDebugData GetOrCreateElementData(IGraphElementWithDebugData element) { }

}

