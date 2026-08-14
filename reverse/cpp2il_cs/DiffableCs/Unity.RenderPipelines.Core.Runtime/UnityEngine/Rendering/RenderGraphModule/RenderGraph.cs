namespace UnityEngine.Rendering.RenderGraphModule;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
public class RenderGraph
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<ProfilingScopePassData, RenderGraphContext> <>9__110_0; //Field offset: 0x8
		public static BaseRenderFunc<ProfilingScopePassData, RenderGraphContext> <>9__111_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <BeginProfilingSampler>b__110_0(ProfilingScopePassData data, RenderGraphContext ctx) { }

		internal void <EndProfilingSampler>b__111_0(ProfilingScopePassData data, RenderGraphContext ctx) { }

	}

	public class CompiledGraph : ICompiledGraph
	{
		public DynamicArray<CompiledResourceInfo>[] compiledResourcesInfos; //Field offset: 0x10
		public DynamicArray<CompiledPassInfo> compiledPassInfos; //Field offset: 0x18
		public int lastExecutionFrame; //Field offset: 0x20

		public CompiledGraph() { }

		public override void Clear() { }

		public void InitializeCompilationData(List<RenderGraphPass> passes, RenderGraphResourceRegistry resources) { }

		private void InitResourceInfosData(DynamicArray<CompiledResourceInfo> resourceInfos, int count) { }

	}

	[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
	public struct CompiledPassInfo
	{
		public string name; //Field offset: 0x0
		public int index; //Field offset: 0x8
		public List<Int32>[] resourceCreateList; //Field offset: 0x10
		public List<Int32>[] resourceReleaseList; //Field offset: 0x18
		public GraphicsFence fence; //Field offset: 0x20
		public int refCount; //Field offset: 0x30
		public int syncToPassIndex; //Field offset: 0x34
		public int syncFromPassIndex; //Field offset: 0x38
		public bool enableAsyncCompute; //Field offset: 0x3C
		public bool allowPassCulling; //Field offset: 0x3D
		public bool needGraphicsFence; //Field offset: 0x3E
		public bool culled; //Field offset: 0x3F
		public bool culledByRendererList; //Field offset: 0x40
		public bool hasSideEffect; //Field offset: 0x41
		public bool enableFoveatedRasterization; //Field offset: 0x42

		public void Reset(RenderGraphPass pass, int index) { }

	}

	public struct CompiledResourceInfo
	{
		public List<Int32> producers; //Field offset: 0x0
		public List<Int32> consumers; //Field offset: 0x8
		public int refCount; //Field offset: 0x10
		public bool imported; //Field offset: 0x14

		public void Reset() { }

	}

	public class DebugData
	{
		internal class BufferResourceData
		{
			public int count; //Field offset: 0x10
			public int stride; //Field offset: 0x14
			public Target target; //Field offset: 0x18
			public UsageFlags usage; //Field offset: 0x1C

			public BufferResourceData() { }

		}

		[DebuggerDisplay("PassDebug: {name}")]
		internal struct PassData
		{
			internal class NRPInfo
			{
				internal class NativeRenderPassInfo
				{
					internal class AttachmentInfo
					{
						public string resourceName; //Field offset: 0x10
						public int attachmentIndex; //Field offset: 0x18
						public string loadAction; //Field offset: 0x20
						public string loadReason; //Field offset: 0x28
						public string storeAction; //Field offset: 0x30
						public string storeReason; //Field offset: 0x38
						public string storeMsaaReason; //Field offset: 0x40

						public AttachmentInfo() { }

					}

					internal struct PassCompatibilityInfo
					{
						public string message; //Field offset: 0x0
						public bool isCompatible; //Field offset: 0x8

					}

					public string passBreakReasoning; //Field offset: 0x10
					public List<AttachmentInfo> attachmentInfos; //Field offset: 0x18
					public Dictionary<Int32, PassCompatibilityInfo> passCompatibility; //Field offset: 0x20
					public List<Int32> mergedPassIds; //Field offset: 0x28

					public NativeRenderPassInfo() { }

				}

				public NativeRenderPassInfo nativePassInfo; //Field offset: 0x10
				public List<Int32> textureFBFetchList; //Field offset: 0x18
				public List<Int32> setGlobals; //Field offset: 0x20
				public int width; //Field offset: 0x28
				public int height; //Field offset: 0x2C
				public int volumeDepth; //Field offset: 0x30
				public int samples; //Field offset: 0x34
				public bool hasDepth; //Field offset: 0x38

				public NRPInfo() { }

			}

			public string name; //Field offset: 0x0
			public RenderGraphPassType type; //Field offset: 0x8
			public List<Int32>[] resourceReadLists; //Field offset: 0x10
			public List<Int32>[] resourceWriteLists; //Field offset: 0x18
			public bool culled; //Field offset: 0x20
			public bool async; //Field offset: 0x21
			public int nativeSubPassIndex; //Field offset: 0x24
			public int syncToPassIndex; //Field offset: 0x28
			public int syncFromPassIndex; //Field offset: 0x2C
			public bool generateDebugData; //Field offset: 0x30
			public NRPInfo nrpInfo; //Field offset: 0x38
			public PassScriptInfo scriptInfo; //Field offset: 0x40

		}

		internal class PassScriptInfo
		{
			public string filePath; //Field offset: 0x10
			public int line; //Field offset: 0x18

			public PassScriptInfo() { }

		}

		[DebuggerDisplay("ResourceDebug: {name} [{creationPassIndex}:{releasePassIndex}]")]
		internal struct ResourceData
		{
			public string name; //Field offset: 0x0
			public bool imported; //Field offset: 0x8
			public int creationPassIndex; //Field offset: 0xC
			public int releasePassIndex; //Field offset: 0x10
			public List<Int32> consumerList; //Field offset: 0x18
			public List<Int32> producerList; //Field offset: 0x20
			public bool memoryless; //Field offset: 0x28
			public TextureResourceData textureData; //Field offset: 0x30
			public BufferResourceData bufferData; //Field offset: 0x38

		}

		internal class TextureResourceData
		{
			public int width; //Field offset: 0x10
			public int height; //Field offset: 0x14
			public int depth; //Field offset: 0x18
			public bool bindMS; //Field offset: 0x1C
			public int samples; //Field offset: 0x20
			public GraphicsFormat format; //Field offset: 0x24
			public bool clearBuffer; //Field offset: 0x28

			public TextureResourceData() { }

		}

		internal static readonly Dictionary<String, PassScriptInfo> s_PassScriptMetadata; //Field offset: 0x0
		public readonly List<PassData> passList; //Field offset: 0x10
		public readonly List<ResourceData>[] resourceLists; //Field offset: 0x18
		public bool isNRPCompiler; //Field offset: 0x20

		private static DebugData() { }

		public DebugData() { }

		public void Clear() { }

	}

	public interface ICompiledGraph
	{

		public void Clear() { }

	}

	public sealed class OnExecutionRegisteredDelegate : MulticastDelegate
	{

		public OnExecutionRegisteredDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(RenderGraph graph, string executionName, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(RenderGraph graph, string executionName) { }

	}

	public sealed class OnGraphRegisteredDelegate : MulticastDelegate
	{

		public OnGraphRegisteredDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(RenderGraph graph, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(RenderGraph graph) { }

	}

	private class ProfilingScopePassData
	{
		public ProfilingSampler sampler; //Field offset: 0x10

		public ProfilingScopePassData() { }

	}

	public static readonly int kMaxMRTCount; //Field offset: 0x0
	private const string k_BeginProfilingSamplerPassName = "BeginProfile"; //Field offset: 0x0
	private const string k_EndProfilingSamplerPassName = "EndProfile"; //Field offset: 0x0
	private static List<RenderGraph> s_RegisteredGraphs; //Field offset: 0x8
	[CompilerGenerated]
	private static bool <isRenderGraphViewerActive>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static bool <enableValidityChecks>k__BackingField; //Field offset: 0x11
	[CompilerGenerated]
	private static OnGraphRegisteredDelegate onGraphRegistered; //Field offset: 0x18
	[CompilerGenerated]
	private static OnGraphRegisteredDelegate onGraphUnregistered; //Field offset: 0x20
	[CompilerGenerated]
	private static OnExecutionRegisteredDelegate onExecutionRegistered; //Field offset: 0x28
	[CompilerGenerated]
	private static OnExecutionRegisteredDelegate onExecutionUnregistered; //Field offset: 0x30
	[CompilerGenerated]
	private static Action onDebugDataCaptured; //Field offset: 0x38
	private NativePassCompiler nativeCompiler; //Field offset: 0x10
	[CompilerGenerated]
	private bool <nativeRenderPassesEnabled>k__BackingField; //Field offset: 0x18
	internal RenderGraphResourceRegistry m_Resources; //Field offset: 0x20
	private RenderGraphObjectPool m_RenderGraphPool; //Field offset: 0x28
	private RenderGraphBuilders m_builderInstance; //Field offset: 0x30
	internal List<RenderGraphPass> m_RenderPasses; //Field offset: 0x38
	private List<RendererListHandle> m_RendererLists; //Field offset: 0x40
	private RenderGraphDebugParams m_DebugParameters; //Field offset: 0x48
	private RenderGraphLogger m_FrameInformationLogger; //Field offset: 0x50
	private RenderGraphDefaultResources m_DefaultResources; //Field offset: 0x58
	private Dictionary<Int32, ProfilingSampler> m_DefaultProfilingSamplers; //Field offset: 0x60
	private InternalRenderGraphContext m_RenderGraphContext; //Field offset: 0x68
	private CommandBuffer m_PreviousCommandBuffer; //Field offset: 0x70
	private List<Int32>[] m_ImmediateModeResourceList; //Field offset: 0x78
	private RenderGraphCompilationCache m_CompilationCache; //Field offset: 0x80
	private RenderTargetIdentifier[][] m_TempMRTArrays; //Field offset: 0x88
	private Stack<Int32> m_CullingStack; //Field offset: 0x90
	private string m_CurrentExecutionName; //Field offset: 0x98
	private int m_ExecutionCount; //Field offset: 0xA0
	private int m_CurrentFrameIndex; //Field offset: 0xA4
	private int m_CurrentImmediatePassIndex; //Field offset: 0xA8
	private bool m_ExecutionExceptionWasRaised; //Field offset: 0xAC
	private bool m_HasRenderGraphBegun; //Field offset: 0xAD
	private bool m_RendererListCulling; //Field offset: 0xAE
	private bool m_EnableCompilationCaching; //Field offset: 0xAF
	private CompiledGraph m_DefaultCompiledGraph; //Field offset: 0xB0
	private CompiledGraph m_CurrentCompiledGraph; //Field offset: 0xB8
	private string m_CaptureDebugDataForExecution; //Field offset: 0xC0
	private Dictionary<String, DebugData> m_DebugData; //Field offset: 0xC8
	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0xD0
	private Dictionary<Int32, TextureHandle> registeredGlobals; //Field offset: 0xD8
	private readonly String[] k_PassNameDebugIgnoreList; //Field offset: 0xE0

	internal static event Action onDebugDataCaptured
	{
		[CompilerGenerated]
		internal add { } //Length: 242
		[CompilerGenerated]
		internal remove { } //Length: 242
	}

	internal static event OnExecutionRegisteredDelegate onExecutionRegistered
	{
		[CompilerGenerated]
		internal add { } //Length: 242
		[CompilerGenerated]
		internal remove { } //Length: 242
	}

	internal static event OnExecutionRegisteredDelegate onExecutionUnregistered
	{
		[CompilerGenerated]
		internal add { } //Length: 242
		[CompilerGenerated]
		internal remove { } //Length: 242
	}

	internal static event OnGraphRegisteredDelegate onGraphRegistered
	{
		[CompilerGenerated]
		internal add { } //Length: 242
		[CompilerGenerated]
		internal remove { } //Length: 242
	}

	internal static event OnGraphRegisteredDelegate onGraphUnregistered
	{
		[CompilerGenerated]
		internal add { } //Length: 242
		[CompilerGenerated]
		internal remove { } //Length: 242
	}

	internal bool areAnySettingsActive
	{
		internal get { } //Length: 58
	}

	internal RenderGraphDebugParams debugParams
	{
		internal get { } //Length: 5
	}

	public RenderGraphDefaultResources defaultResources
	{
		 get { } //Length: 5
	}

	internal static bool enableValidityChecks
	{
		[CompilerGenerated]
		internal get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	public internal static bool isRenderGraphViewerActive
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		internal set { } //Length: 84
	}

	public private string name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public bool nativeRenderPassesEnabled
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	private static RenderGraph() { }

	public RenderGraph(string name = "RenderGraph") { }

	[CompilerGenerated]
	internal static void add_onDebugDataCaptured(Action value) { }

	[CompilerGenerated]
	internal static void add_onExecutionRegistered(OnExecutionRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void add_onExecutionUnregistered(OnExecutionRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void add_onGraphRegistered(OnGraphRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void add_onGraphUnregistered(OnGraphRegisteredDelegate value) { }

	public IComputeRenderGraphBuilder AddComputePass(string passName, out PassData passData, ProfilingSampler sampler, string file = "", int line = 0) { }

	public IComputeRenderGraphBuilder AddComputePass(string passName, out PassData passData, string file = "", int line = 0) { }

	[Conditional("UNITY_EDITOR")]
	private void AddPassDebugMetadata(string passName, string file, int line) { }

	public IRasterRenderGraphBuilder AddRasterRenderPass(string passName, out PassData passData, ProfilingSampler sampler, string file = "", int line = 0) { }

	public IRasterRenderGraphBuilder AddRasterRenderPass(string passName, out PassData passData, string file = "", int line = 0) { }

	public RenderGraphBuilder AddRenderPass(string passName, out PassData passData, string file = "", int line = 0) { }

	public RenderGraphBuilder AddRenderPass(string passName, out PassData passData, ProfilingSampler sampler, string file = "", int line = 0) { }

	public IUnsafeRenderGraphBuilder AddUnsafePass(string passName, out PassData passData, ProfilingSampler sampler, string file = "", int line = 0) { }

	public IUnsafeRenderGraphBuilder AddUnsafePass(string passName, out PassData passData, string file = "", int line = 0) { }

	internal ValueCollection<Int32, TextureHandle> AllGlobals() { }

	private void AllocateCulledPassResources(ref CompiledPassInfo passInfo) { }

	private bool AreRendererListsEmpty(List<RendererListHandle> rendererLists) { }

	public void BeginProfilingSampler(ProfilingSampler sampler, string file = "", int line = 0) { }

	public void BeginRecording(in RenderGraphParameters parameters) { }

	public void Cleanup() { }

	private void CleanupDebugData() { }

	private void ClearCompiledGraph(CompiledGraph compiledGraph, bool useCompilationCaching) { }

	internal void ClearCompiledGraph() { }

	internal void ClearGlobalBindings() { }

	[Conditional("UNITY_EDITOR")]
	private void ClearPassDebugMetadata() { }

	private void ClearRenderPasses() { }

	internal NativePassCompiler CompileNativeRenderGraph(int graphHash) { }

	private CompiledPassInfo CompilePassImmediatly(RenderGraphPass pass) { }

	internal void CompileRenderGraph(int graphHash) { }

	internal int ComputeGraphHash() { }

	private void CountReferences() { }

	public BufferHandle CreateBuffer(in BufferHandle graphicsBuffer) { }

	public BufferHandle CreateBuffer(in BufferDesc desc) { }

	public RendererListHandle CreateGizmoRendererList(in Camera camera, in GizmoSubset gizmoSubset) { }

	public RendererListHandle CreateRendererList(in RendererListDesc desc) { }

	public RendererListHandle CreateRendererList(in RendererListParams desc) { }

	private void CreateRendererLists() { }

	public RendererListHandle CreateShadowRendererList(ref ShadowDrawingSettings shadowDrawingSettings) { }

	public TextureHandle CreateSharedTexture(in TextureDesc desc, bool explicitRelease = false) { }

	public RendererListHandle CreateSkyboxRendererList(in Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix) { }

	public RendererListHandle CreateSkyboxRendererList(in Camera camera) { }

	public RendererListHandle CreateSkyboxRendererList(in Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR) { }

	public TextureHandle CreateTexture(TextureHandle texture) { }

	public TextureHandle CreateTexture(in TextureDesc desc) { }

	public void CreateTextureIfInvalid(in TextureDesc desc, ref TextureHandle texture) { }

	public RendererListHandle CreateUIOverlayRendererList(in Camera camera, in UISubset uiSubset) { }

	public RendererListHandle CreateUIOverlayRendererList(in Camera camera) { }

	public RendererListHandle CreateWireOverlayRendererList(in Camera camera) { }

	private void CullRendererLists() { }

	private void CullUnusedPasses() { }

	public void EndFrame() { }

	public void EndProfilingSampler(ProfilingSampler sampler, string file = "", int line = 0) { }

	public void EndRecordingAndExecute() { }

	internal void Execute() { }

	private void ExecuteCompiledPass(ref CompiledPassInfo passInfo) { }

	private void ExecuteNativeRenderGraph() { }

	private void ExecutePassImmediately(RenderGraphPass pass) { }

	private void ExecuteRenderGraph() { }

	private int FindTextureProducer(int consumerPass, in CompiledResourceInfo info, out int index) { }

	private void GenerateCompilerDebugData(ref DebugData debugData) { }

	private void GenerateDebugData() { }

	internal bool get_areAnySettingsActive() { }

	internal RenderGraphDebugParams get_debugParams() { }

	public RenderGraphDefaultResources get_defaultResources() { }

	[CompilerGenerated]
	internal static bool get_enableValidityChecks() { }

	[CompilerGenerated]
	public static bool get_isRenderGraphViewerActive() { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	public bool get_nativeRenderPassesEnabled() { }

	public BufferDesc GetBufferDesc(in BufferHandle graphicsBuffer) { }

	internal DynamicArray<CompiledPassInfo> GetCompiledPassInfos() { }

	internal DebugData GetDebugData(string executionName) { }

	private ProfilingSampler GetDefaultProfilingSampler(string name) { }

	private int GetFirstValidConsumerIndex(int passIndex, in CompiledResourceInfo info) { }

	private int GetFirstValidWriteIndex(in CompiledResourceInfo info) { }

	internal TextureHandle GetGlobal(int globalPropertyId) { }

	internal bool GetImportedFallback(TextureDesc desc, out TextureHandle fallback) { }

	private int GetLatestProducerIndex(int passIndex, in CompiledResourceInfo info) { }

	private int GetLatestValidReadIndex(in CompiledResourceInfo info) { }

	private int GetLatestValidWriteIndex(in CompiledResourceInfo info) { }

	public static List<RenderGraph> GetRegisteredRenderGraphs() { }

	public RenderTargetInfo GetRenderTargetInfo(TextureHandle texture) { }

	public TextureDesc GetTextureDesc(TextureHandle texture) { }

	internal List<Widget> GetWidgetList() { }

	public TextureHandle ImportBackbuffer(RenderTargetIdentifier rt) { }

	public TextureHandle ImportBackbuffer(RenderTargetIdentifier rt, RenderTargetInfo info, ImportResourceParams importParams = null) { }

	public BufferHandle ImportBuffer(GraphicsBuffer graphicsBuffer, bool forceRelease = false) { }

	public RayTracingAccelerationStructureHandle ImportRayTracingAccelerationStructure(in RayTracingAccelerationStructure accelStruct, string name = null) { }

	public TextureHandle ImportTexture(RTHandle rt, RenderTargetInfo info, ImportResourceParams importParams = null) { }

	public TextureHandle ImportTexture(RTHandle rt) { }

	internal TextureHandle ImportTexture(RTHandle rt, bool isBuiltin) { }

	public TextureHandle ImportTexture(RTHandle rt, ImportResourceParams importParams) { }

	private void InvalidateContext() { }

	internal bool IsGlobal(int globalPropertyId) { }

	private void LogCulledPasses() { }

	private void LogFrameInformation() { }

	private void LogRendererListsCreation() { }

	private void LogRenderPassBegin(in CompiledPassInfo passInfo) { }

	internal void OnPassAdded(RenderGraphPass pass) { }

	private void PostRenderPassExecute(ref CompiledPassInfo passInfo, RenderGraphPass pass, InternalRenderGraphContext rgContext) { }

	private void PreRenderPassExecute(in CompiledPassInfo passInfo, RenderGraphPass pass, InternalRenderGraphContext rgContext) { }

	private void PreRenderPassSetRenderTargets(in CompiledPassInfo passInfo, RenderGraphPass pass, InternalRenderGraphContext rgContext) { }

	public void RefreshSharedTextureDesc(TextureHandle handle, in TextureDesc desc) { }

	public void RegisterDebug(Panel panel = null) { }

	private void ReleaseImmediateModeResources() { }

	public void ReleaseSharedTexture(TextureHandle texture) { }

	[CompilerGenerated]
	internal static void remove_onDebugDataCaptured(Action value) { }

	[CompilerGenerated]
	internal static void remove_onExecutionRegistered(OnExecutionRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void remove_onExecutionUnregistered(OnExecutionRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void remove_onGraphRegistered(OnGraphRegisteredDelegate value) { }

	[CompilerGenerated]
	internal static void remove_onGraphUnregistered(OnGraphRegisteredDelegate value) { }

	internal void RequestCaptureDebugData(string executionName) { }

	[CompilerGenerated]
	private static void set_enableValidityChecks(bool value) { }

	[CompilerGenerated]
	internal static void set_isRenderGraphViewerActive(bool value) { }

	[CompilerGenerated]
	private void set_name(string value) { }

	[CompilerGenerated]
	public void set_nativeRenderPassesEnabled(bool value) { }

	internal void SetGlobal(TextureHandle h, int globalPropertyId) { }

	private void TryCullPassAtIndex(int passIndex) { }

	public void UnRegisterDebug() { }

	private void UpdateAllSharedResourceLastFrameIndex() { }

	private bool UpdateCurrentCompiledGraph(int graphHash, bool forceNoCaching = false) { }

	private void UpdateImportedResourceLifeTime(ref ResourceData data, List<Int32> passList) { }

	private void UpdatePassSynchronization(ref CompiledPassInfo currentPassInfo, ref CompiledPassInfo producerPassInfo, int currentPassIndex, int lastProducer, ref int intLastSyncIndex) { }

	private void UpdateResourceAllocationAndSynchronization() { }

	private void UpdateResourceSynchronization(ref int lastGraphicsPipeSync, ref int lastComputePipeSync, int currentPassIndex, in CompiledResourceInfo resource) { }

}

