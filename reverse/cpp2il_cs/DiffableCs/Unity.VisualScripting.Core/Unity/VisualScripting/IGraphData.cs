namespace Unity.VisualScripting;

public interface IGraphData
{

	public IGraphData CreateChildGraphData(IGraphParentElement element) { }

	public IGraphElementData CreateElementData(IGraphElementWithData element) { }

	public void FreeChildGraphData(IGraphParentElement element) { }

	public void FreeElementData(IGraphElementWithData element) { }

	public bool TryGetChildGraphData(IGraphParentElement element, out IGraphData data) { }

	public bool TryGetElementData(IGraphElementWithData element, out IGraphElementData data) { }

}

