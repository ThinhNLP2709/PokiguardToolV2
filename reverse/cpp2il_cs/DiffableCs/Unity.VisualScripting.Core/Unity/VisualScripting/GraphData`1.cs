namespace Unity.VisualScripting;

public class GraphData : IGraphData
{
	[CompilerGenerated]
	private readonly TGraph <definition>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Dictionary<IGraphElementWithData, IGraphElementData> <elementsData>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Dictionary<IGraphParentElement, IGraphData> <childrenGraphsData>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Dictionary<Guid, IGraphElementData> <phantomElementsData>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Dictionary<Guid, IGraphData> <phantomChildrenGraphsData>k__BackingField; //Field offset: 0x0

	protected Dictionary<IGraphParentElement, IGraphData> childrenGraphsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected TGraph definition
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected Dictionary<IGraphElementWithData, IGraphElementData> elementsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected Dictionary<Guid, IGraphData> phantomChildrenGraphsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected Dictionary<Guid, IGraphElementData> phantomElementsData
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public GraphData`1(TGraph definition) { }

	public override IGraphData CreateChildGraphData(IGraphParentElement element) { }

	public override IGraphElementData CreateElementData(IGraphElementWithData element) { }

	public override void FreeChildGraphData(IGraphParentElement element) { }

	public override void FreeElementData(IGraphElementWithData element) { }

	[CompilerGenerated]
	protected Dictionary<IGraphParentElement, IGraphData> get_childrenGraphsData() { }

	[CompilerGenerated]
	protected TGraph get_definition() { }

	[CompilerGenerated]
	protected Dictionary<IGraphElementWithData, IGraphElementData> get_elementsData() { }

	[CompilerGenerated]
	protected Dictionary<Guid, IGraphData> get_phantomChildrenGraphsData() { }

	[CompilerGenerated]
	protected Dictionary<Guid, IGraphElementData> get_phantomElementsData() { }

	public override bool TryGetChildGraphData(IGraphParentElement element, out IGraphData data) { }

	public override bool TryGetElementData(IGraphElementWithData element, out IGraphElementData data) { }

}

