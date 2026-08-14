namespace UnityEngine.UIElements.UIR;

internal class RenderChain : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<RenderChainCommand> <>9__31_0; //Field offset: 0x8
		public static Func<ExtraRenderChainVEData> <>9__31_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal RenderChainCommand <.ctor>b__31_0() { }

		internal ExtraRenderChainVEData <.ctor>b__31_1() { }

	}

	private struct DepthOrderedDirtyTracking
	{
		public List<VisualElement> heads; //Field offset: 0x0
		public List<VisualElement> tails; //Field offset: 0x8
		public Int32[] minDepths; //Field offset: 0x10
		public Int32[] maxDepths; //Field offset: 0x18
		public uint dirtyID; //Field offset: 0x20

		public void ClearDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypesInverse) { }

		public void EnsureFits(int maxDepth) { }

		public void RegisterDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypes, RenderDataDirtyTypeClasses dirtyTypeClass) { }

		public void Reset() { }

	}

	private class VisualChangesProcessor : IDisposable
	{
		private struct EntryProcessingInfo
		{
			public VisualElement visualElement; //Field offset: 0x0
			public VisualsProcessingType type; //Field offset: 0x8
			public Entry rootEntry; //Field offset: 0x10

		}

		private enum VisualsProcessingType
		{
			Head = 0,
			Tail = 1,
		}

		private static readonly ProfilerMarker k_GenerateEntriesMarker; //Field offset: 0x0
		private static readonly ProfilerMarker k_ConvertEntriesToCommandsMarker; //Field offset: 0x8
		private static readonly ProfilerMarker k_UpdateOpacityIdMarker; //Field offset: 0x10
		private RenderChain m_RenderChain; //Field offset: 0x10
		private MeshGenerationContext m_MeshGenerationContext; //Field offset: 0x18
		private BaseElementBuilder m_ElementBuilder; //Field offset: 0x20
		private List<EntryProcessingInfo> m_EntryProcessingList; //Field offset: 0x28
		private List<EntryProcessor> m_Processors; //Field offset: 0x30
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <disposed>k__BackingField; //Field offset: 0x38

		protected private bool disposed
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public BaseElementBuilder elementBuilder
		{
			 get { } //Length: 5
		}

		public MeshGenerationContext meshGenerationContext
		{
			 get { } //Length: 5
		}

		private static VisualChangesProcessor() { }

		public VisualChangesProcessor(RenderChain renderChain) { }

		public void ConvertEntriesToCommands(ref ChainBuilderStats stats) { }

		private void DepthFirstOnVisualsChanged(VisualElement ve, uint dirtyID, bool hierarchical, ref ChainBuilderStats stats) { }

		public override void Dispose() { }

		protected void Dispose(bool disposing) { }

		private static void DoUpdateOpacityId(VisualElement ve, RenderChain renderChain, MeshHandle mesh) { }

		[CompilerGenerated]
		protected bool get_disposed() { }

		public BaseElementBuilder get_elementBuilder() { }

		public MeshGenerationContext get_meshGenerationContext() { }

		public void ProcessOnVisualsChanged(VisualElement ve, uint dirtyID, ref ChainBuilderStats stats) { }

		public void ScheduleMeshGenerationJobs() { }

		[CompilerGenerated]
		private void set_disposed(bool value) { }

		public static void UpdateOpacityId(VisualElement ve, RenderChain renderChain) { }

		private static void UpdateWorldFlipsWinding(VisualElement ve) { }

	}

	private static EntryPool s_SharedEntryPool; //Field offset: 0x0
	private static readonly ProfilerMarker k_MarkerProcess; //Field offset: 0x8
	private static readonly ProfilerMarker k_MarkerClipProcessing; //Field offset: 0x10
	private static readonly ProfilerMarker k_MarkerOpacityProcessing; //Field offset: 0x18
	private static readonly ProfilerMarker k_MarkerColorsProcessing; //Field offset: 0x20
	private static readonly ProfilerMarker k_MarkerTransformProcessing; //Field offset: 0x28
	private static readonly ProfilerMarker k_MarkerVisualsProcessing; //Field offset: 0x30
	private static readonly ProfilerMarker k_MarkerSerialize; //Field offset: 0x38
	private RenderChainCommand m_FirstCommand; //Field offset: 0x10
	private DepthOrderedDirtyTracking m_DirtyTracker; //Field offset: 0x18
	private VisualChangesProcessor m_VisualChangesProcessor; //Field offset: 0x40
	private LinkedPool<RenderChainCommand> m_CommandPool; //Field offset: 0x48
	private LinkedPool<ExtraRenderChainVEData> m_ExtraDataPool; //Field offset: 0x50
	private BasicNodePool<MeshHandle> m_MeshHandleNodePool; //Field offset: 0x58
	private BasicNodePool<TextureEntry> m_TexturePool; //Field offset: 0x60
	private Dictionary<VisualElement, ExtraRenderChainVEData> m_ExtraData; //Field offset: 0x68
	private MeshGenerationDeferrer m_MeshGenerationDeferrer; //Field offset: 0x70
	private Material m_DefaultMat; //Field offset: 0x78
	private bool m_BlockDirtyRegistration; //Field offset: 0x80
	private ChainBuilderStats m_Stats; //Field offset: 0x84
	private uint m_StatsElementsAdded; //Field offset: 0xE0
	private uint m_StatsElementsRemoved; //Field offset: 0xE4
	private TextureRegistry m_TextureRegistry; //Field offset: 0xE8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private OpacityIdAccelerator <opacityIdAccelerator>k__BackingField; //Field offset: 0xF0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0xF8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private BaseVisualElementPanel <panel>k__BackingField; //Field offset: 0x100
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UIRenderDevice <device>k__BackingField; //Field offset: 0x108
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AtlasBase <atlas>k__BackingField; //Field offset: 0x110
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VectorImageManager <vectorImageManager>k__BackingField; //Field offset: 0x118
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private TempMeshAllocatorImpl <tempMeshAllocator>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly MeshWriteDataPool <meshWriteDataPool>k__BackingField; //Field offset: 0x128
	public EntryRecorder entryRecorder; //Field offset: 0x130
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private MeshGenerationNodeManager <meshGenerationNodeManager>k__BackingField; //Field offset: 0x138
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private JobManager <jobManager>k__BackingField; //Field offset: 0x140
	internal UIRVEShaderInfoAllocator shaderInfoAllocator; //Field offset: 0x148
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <drawStats>k__BackingField; //Field offset: 0x150
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <drawInCameras>k__BackingField; //Field offset: 0x151
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <isFlat>k__BackingField; //Field offset: 0x152
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <forceGammaRendering>k__BackingField; //Field offset: 0x153

	internal AtlasBase atlas
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal UIRenderDevice device
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	internal bool drawInCameras
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal bool drawStats
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public BaseElementBuilder elementBuilder
	{
		 get { } //Length: 27
	}

	internal EntryPool entryPool
	{
		internal get { } //Length: 78
	}

	public bool forceGammaRendering
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal bool isFlat
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal JobManager jobManager
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public MeshGenerationDeferrer meshGenerationDeferrer
	{
		 get { } //Length: 5
	}

	public private MeshGenerationNodeManager meshGenerationNodeManager
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal MeshWriteDataPool meshWriteDataPool
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	public private OpacityIdAccelerator opacityIdAccelerator
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal BaseVisualElementPanel panel
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal ChainBuilderStats statsByRef
	{
		internal get { } //Length: 8
	}

	internal TempMeshAllocatorImpl tempMeshAllocator
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal VectorImageManager vectorImageManager
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	private static RenderChain() { }

	public RenderChain(BaseVisualElementPanel panel) { }

	protected RenderChain(BaseVisualElementPanel panel, UIRenderDevice device, AtlasBase atlas, VectorImageManager vectorImageManager) { }

	internal RenderChainCommand AllocCommand() { }

	internal void ChildWillBeRemoved(VisualElement ve) { }

	public override void Dispose() { }

	protected void Dispose(bool disposing) { }

	private void DrawStats() { }

	internal void EnsureFitsDepth(int depth) { }

	internal void FreeCommand(RenderChainCommand cmd) { }

	public void FreeExtraData(VisualElement ve) { }

	public void FreeExtraMeshes(VisualElement ve) { }

	[CompilerGenerated]
	internal AtlasBase get_atlas() { }

	[CompilerGenerated]
	internal UIRenderDevice get_device() { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	[CompilerGenerated]
	internal bool get_drawInCameras() { }

	[CompilerGenerated]
	internal bool get_drawStats() { }

	public BaseElementBuilder get_elementBuilder() { }

	internal EntryPool get_entryPool() { }

	[CompilerGenerated]
	public bool get_forceGammaRendering() { }

	[CompilerGenerated]
	internal bool get_isFlat() { }

	[CompilerGenerated]
	internal JobManager get_jobManager() { }

	public MeshGenerationDeferrer get_meshGenerationDeferrer() { }

	[CompilerGenerated]
	public MeshGenerationNodeManager get_meshGenerationNodeManager() { }

	[CompilerGenerated]
	internal MeshWriteDataPool get_meshWriteDataPool() { }

	[CompilerGenerated]
	public OpacityIdAccelerator get_opacityIdAccelerator() { }

	[CompilerGenerated]
	internal BaseVisualElementPanel get_panel() { }

	internal ChainBuilderStats get_statsByRef() { }

	[CompilerGenerated]
	internal TempMeshAllocatorImpl get_tempMeshAllocator() { }

	[CompilerGenerated]
	internal VectorImageManager get_vectorImageManager() { }

	private static VisualElement GetFirstElementInPanel(VisualElement ve) { }

	public ExtraRenderChainVEData GetOrAddExtraData(VisualElement ve) { }

	public void InsertExtraMesh(VisualElement ve, MeshHandle mesh) { }

	public void InsertTexture(VisualElement ve, Texture src, TextureId id, bool isAtlas) { }

	internal void OnRenderCommandAdded(RenderChainCommand command) { }

	internal void OnRenderCommandsRemoved(RenderChainCommand firstCommand, RenderChainCommand lastCommand) { }

	public void ProcessChanges() { }

	public void Render() { }

	internal void RepaintTexturedElements() { }

	public void ResetTextures(VisualElement ve) { }

	private void SerializeCommandsForCameras() { }

	[CompilerGenerated]
	private void set_atlas(AtlasBase value) { }

	[CompilerGenerated]
	private void set_device(UIRenderDevice value) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

	[CompilerGenerated]
	internal void set_drawStats(bool value) { }

	[CompilerGenerated]
	private void set_jobManager(JobManager value) { }

	[CompilerGenerated]
	private void set_meshGenerationNodeManager(MeshGenerationNodeManager value) { }

	[CompilerGenerated]
	private void set_opacityIdAccelerator(OpacityIdAccelerator value) { }

	[CompilerGenerated]
	private void set_panel(BaseVisualElementPanel value) { }

	[CompilerGenerated]
	private void set_tempMeshAllocator(TempMeshAllocatorImpl value) { }

	[CompilerGenerated]
	private void set_vectorImageManager(VectorImageManager value) { }

	public void UIEOnChildAdded(VisualElement ve) { }

	public void UIEOnChildRemoving(VisualElement ve) { }

	public void UIEOnChildrenReordered(VisualElement ve) { }

	public void UIEOnClippingChanged(VisualElement ve, bool hierarchical) { }

	public void UIEOnColorChanged(VisualElement ve) { }

	public void UIEOnDisableRenderingChanged(VisualElement ve) { }

	public void UIEOnOpacityChanged(VisualElement ve, bool hierarchical = false) { }

	public void UIEOnOpacityIdChanged(VisualElement ve) { }

	public void UIEOnRenderHintsChanged(VisualElement ve) { }

	public void UIEOnTransformOrSizeChanged(VisualElement ve, bool transformChanged, bool clipRectSizeChanged) { }

	public void UIEOnVisualsChanged(VisualElement ve, bool hierarchical) { }

}

