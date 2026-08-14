namespace Unity.VisualScripting;

public class GraphDebugData : IGraphDebugData
{
	[CompilerGenerated]
	private readonly Dictionary<IGraphElementWithDebugData, IGraphElementDebugData> <elementsData>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Dictionary<IGraphParentElement, IGraphDebugData> <childrenGraphsData>k__BackingField; //Field offset: 0x18

	protected Dictionary<IGraphParentElement, IGraphDebugData> childrenGraphsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected Dictionary<IGraphElementWithDebugData, IGraphElementDebugData> elementsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	private override IEnumerable<IGraphElementDebugData> Unity.VisualScripting.IGraphDebugData.elementsData
	{
		private get { } //Length: 68
	}

	public GraphDebugData(IGraph definition) { }

	[CompilerGenerated]
	protected Dictionary<IGraphParentElement, IGraphDebugData> get_childrenGraphsData() { }

	[CompilerGenerated]
	protected Dictionary<IGraphElementWithDebugData, IGraphElementDebugData> get_elementsData() { }

	public override IGraphDebugData GetOrCreateChildGraphData(IGraphParentElement element) { }

	public override IGraphElementDebugData GetOrCreateElementData(IGraphElementWithDebugData element) { }

	private override IEnumerable<IGraphElementDebugData> Unity.VisualScripting.IGraphDebugData.get_elementsData() { }

}

