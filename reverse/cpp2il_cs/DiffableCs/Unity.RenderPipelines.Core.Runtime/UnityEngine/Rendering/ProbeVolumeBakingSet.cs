namespace UnityEngine.Rendering;

public sealed class ProbeVolumeBakingSet : ScriptableObject, ISerializationCallbackReceiver
{
	public struct CellCounts
	{
		public int bricksCount; //Field offset: 0x0
		public int chunksCount; //Field offset: 0x4

		public void Add(CellCounts o) { }

	}

	public class PerScenarioDataInfo
	{
		public int sceneHash; //Field offset: 0x10
		public ProbeVolumeStreamableAsset cellDataAsset; //Field offset: 0x18
		public ProbeVolumeStreamableAsset cellOptionalDataAsset; //Field offset: 0x20
		public ProbeVolumeStreamableAsset cellProbeOcclusionDataAsset; //Field offset: 0x28
		private bool m_HasValidData; //Field offset: 0x30

		public PerScenarioDataInfo() { }

		public bool ComputeHasValidData(ProbeVolumeSHBands shBands) { }

		public bool HasValidData(ProbeVolumeSHBands shBands) { }

		public void Initialize(ProbeVolumeSHBands shBands) { }

		public bool IsValid() { }

	}

	public struct ProbeLayerMask
	{
		public RenderingLayerMask mask; //Field offset: 0x0
		public string name; //Field offset: 0x8

	}

	private struct SerializedPerSceneCellList
	{
		public string sceneGUID; //Field offset: 0x0
		public List<Int32> cellList; //Field offset: 0x8

	}

	public enum Version
	{
		Initial = 0,
		RemoveProbeVolumeSceneData = 1,
	}

	internal const int k_MaxSkyOcclusionBakingSamples = 8192; //Field offset: 0x0
	[SerializeField]
	internal bool singleSceneMode; //Field offset: 0x18
	[SerializeField]
	internal bool dialogNoProbeVolumeInSetShown; //Field offset: 0x19
	[SerializeField]
	internal ProbeVolumeBakingProcessSettings settings; //Field offset: 0x1C
	[SerializeField]
	private List<String> m_SceneGUIDs; //Field offset: 0x50
	[FormerlySerializedAs("scenesToNotBake")]
	[Obsolete("This is now contained in the SceneBakeData structure")]
	[SerializeField]
	internal List<String> obsoleteScenesToNotBake; //Field offset: 0x58
	[FormerlySerializedAs("lightingScenarios")]
	[SerializeField]
	internal List<String> m_LightingScenarios; //Field offset: 0x60
	[SerializeField]
	internal SerializedDictionary<Int32, CellDesc> cellDescs; //Field offset: 0x68
	internal Dictionary<Int32, CellData> cellDataMap; //Field offset: 0x70
	private List<Int32> m_TotalIndexList; //Field offset: 0x78
	[SerializeField]
	private List<SerializedPerSceneCellList> m_SerializedPerSceneCellList; //Field offset: 0x80
	internal Dictionary<String, List`1<Int32>> perSceneCellLists; //Field offset: 0x88
	[SerializeField]
	internal ProbeVolumeStreamableAsset cellSharedDataAsset; //Field offset: 0x90
	[SerializeField]
	internal SerializedDictionary<String, PerScenarioDataInfo> scenarios; //Field offset: 0x98
	[SerializeField]
	internal ProbeVolumeStreamableAsset cellBricksDataAsset; //Field offset: 0xA0
	[SerializeField]
	internal ProbeVolumeStreamableAsset cellSupportDataAsset; //Field offset: 0xA8
	[SerializeField]
	internal int chunkSizeInBricks; //Field offset: 0xB0
	[SerializeField]
	internal Vector3Int maxCellPosition; //Field offset: 0xB4
	[SerializeField]
	internal Vector3Int minCellPosition; //Field offset: 0xC0
	[SerializeField]
	internal Bounds globalBounds; //Field offset: 0xCC
	[SerializeField]
	internal int bakedSimplificationLevels; //Field offset: 0xE4
	[SerializeField]
	internal float bakedMinDistanceBetweenProbes; //Field offset: 0xE8
	[SerializeField]
	internal bool bakedProbeOcclusion; //Field offset: 0xEC
	[SerializeField]
	internal int bakedSkyOcclusionValue; //Field offset: 0xF0
	[SerializeField]
	internal int bakedSkyShadingDirectionValue; //Field offset: 0xF4
	[SerializeField]
	internal Vector3 bakedProbeOffset; //Field offset: 0xF8
	[SerializeField]
	internal int bakedMaskCount; //Field offset: 0x104
	[SerializeField]
	internal uint4 bakedLayerMasks; //Field offset: 0x108
	[SerializeField]
	internal int maxSHChunkCount; //Field offset: 0x118
	[SerializeField]
	internal int L0ChunkSize; //Field offset: 0x11C
	[SerializeField]
	internal int L1ChunkSize; //Field offset: 0x120
	[SerializeField]
	internal int L2TextureChunkSize; //Field offset: 0x124
	[SerializeField]
	internal int ProbeOcclusionChunkSize; //Field offset: 0x128
	[SerializeField]
	internal int sharedValidityMaskChunkSize; //Field offset: 0x12C
	[SerializeField]
	internal int sharedSkyOcclusionL0L1ChunkSize; //Field offset: 0x130
	[SerializeField]
	internal int sharedSkyShadingDirectionIndicesChunkSize; //Field offset: 0x134
	[SerializeField]
	internal int sharedDataChunkSize; //Field offset: 0x138
	[SerializeField]
	internal int supportPositionChunkSize; //Field offset: 0x13C
	[SerializeField]
	internal int supportValidityChunkSize; //Field offset: 0x140
	[SerializeField]
	internal int supportTouchupChunkSize; //Field offset: 0x144
	[SerializeField]
	internal int supportLayerMaskChunkSize; //Field offset: 0x148
	[SerializeField]
	internal int supportOffsetsChunkSize; //Field offset: 0x14C
	[SerializeField]
	internal int supportDataChunkSize; //Field offset: 0x150
	[SerializeField]
	internal string lightingScenario; //Field offset: 0x158
	private string m_OtherScenario; //Field offset: 0x160
	private float m_ScenarioBlendingFactor; //Field offset: 0x168
	private ReadCommandArray m_ReadCommandArray; //Field offset: 0x170
	private NativeArray<ReadCommand> m_ReadCommandBuffer; //Field offset: 0x180
	private Stack<NativeArray`1<Byte>> m_ReadOperationScratchBuffers; //Field offset: 0x190
	private List<Int32> m_PrunedIndexList; //Field offset: 0x198
	private List<Int32> m_PrunedScenarioIndexList; //Field offset: 0x1A0
	[SerializeField]
	private Version version; //Field offset: 0x1A8
	[SerializeField]
	internal bool freezePlacement; //Field offset: 0x1AC
	[SerializeField]
	public Vector3 probeOffset; //Field offset: 0x1B0
	[Range(2, 5)]
	public int simplificationLevels; //Field offset: 0x1BC
	[Min(0.1)]
	public float minDistanceBetweenProbes; //Field offset: 0x1C0
	public LayerMask renderersLayerMask; //Field offset: 0x1C4
	[Min(0)]
	public float minRendererVolumeSize; //Field offset: 0x1C8
	public bool skyOcclusion; //Field offset: 0x1CC
	[Logarithmic(1, 8192)]
	public int skyOcclusionBakingSamples; //Field offset: 0x1D0
	[Range(0, 5)]
	public int skyOcclusionBakingBounces; //Field offset: 0x1D4
	[Range(0, 1)]
	public float skyOcclusionAverageAlbedo; //Field offset: 0x1D8
	public bool skyOcclusionBackFaceCulling; //Field offset: 0x1DC
	public bool skyOcclusionShadingDirection; //Field offset: 0x1DD
	[SerializeField]
	internal bool useRenderingLayers; //Field offset: 0x1DE
	[SerializeField]
	internal ProbeLayerMask[] renderingLayerMasks; //Field offset: 0x1E0
	private bool m_HasSupportData; //Field offset: 0x1E8
	private bool m_SharedDataIsValid; //Field offset: 0x1E9
	private bool m_UseStreamingAsset; //Field offset: 0x1EA

	internal bool bakedSkyOcclusion
	{
		internal get { } //Length: 11
		internal set { } //Length: 28
	}

	internal bool bakedSkyShadingDirection
	{
		internal get { } //Length: 11
		internal set { } //Length: 28
	}

	public int cellSizeInBricks
	{
		 get { } //Length: 37
	}

	public float cellSizeInMeters
	{
		 get { } //Length: 82
	}

	internal bool hasDilation
	{
		internal get { } //Length: 24
	}

	public IReadOnlyList<String> lightingScenarios
	{
		 get { } //Length: 694
	}

	public int maxSubdivision
	{
		 get { } //Length: 9
	}

	public float minBrickSize
	{
		 get { } //Length: 31
	}

	internal string otherScenario
	{
		internal get { } //Length: 8
	}

	internal float scenarioBlendingFactor
	{
		internal get { } //Length: 9
	}

	public IReadOnlyList<String> sceneGUIDs
	{
		 get { } //Length: 5
	}

	public ProbeVolumeBakingSet() { }

	private static int AlignUp16(int count) { }

	internal void BlendLightingScenario(string otherScenario, float blendingFactor) { }

	internal bool CheckCompatibleCellLayout() { }

	internal void Cleanup() { }

	private bool ComputeHasSupportData() { }

	private bool ComputeHasValidSharedData() { }

	internal uint4 ComputeRegionMasks() { }

	internal bool get_bakedSkyOcclusion() { }

	internal bool get_bakedSkyShadingDirection() { }

	public int get_cellSizeInBricks() { }

	public float get_cellSizeInMeters() { }

	internal bool get_hasDilation() { }

	public IReadOnlyList<String> get_lightingScenarios() { }

	public int get_maxSubdivision() { }

	public float get_minBrickSize() { }

	internal string get_otherScenario() { }

	internal float get_scenarioBlendingFactor() { }

	public IReadOnlyList<String> get_sceneGUIDs() { }

	internal int GetBakingHashCode() { }

	internal CellData GetCellData(int cellIndex) { }

	internal CellDesc GetCellDesc(int cellIndex) { }

	internal static int GetCellSizeInBricks(int simplificationLevels) { }

	internal int GetChunkGPUMemory(ProbeVolumeSHBands shBands) { }

	internal static int GetMaxSubdivision(int simplificationLevels) { }

	internal static float GetMinBrickSize(float minDistanceBetweenProbes) { }

	internal List<Int32> GetSceneCellIndexList(string sceneGUID) { }

	private NativeArray<T> GetSubArray(NativeArray<Byte> input, int count, ref int offset) { }

	public bool HasBakedData(string scenario = null) { }

	internal bool HasSupportData() { }

	internal bool HasValidSharedData() { }

	internal void Initialize(bool useStreamingAsset) { }

	private NativeArray<T> LoadStreambleAssetData(ProbeVolumeStreamableAsset asset, List<Int32> cellIndices) { }

	internal void Migrate() { }

	private void OnEnable() { }

	private void OnValidate() { }

	private void PruneCellIndexList(List<Int32> cellIndices, List<Int32> prunedIndexList) { }

	private void PruneCellIndexListForScenario(List<Int32> cellIndices, PerScenarioDataInfo scenarioData, List<Int32> prunedIndexList) { }

	internal void ReleaseCell(int cellIndex) { }

	private void ReleaseStreamableAssetData(NativeArray<T> buffer) { }

	private NativeArray<Byte> RequestScratchBuffer(int size) { }

	private bool ResolveAllCellData() { }

	internal bool ResolveCellData(List<Int32> cellIndices) { }

	internal bool ResolvePerScenarioCellData(NativeArray<Byte> cellData, NativeArray<Byte> cellOptionalData, NativeArray<Byte> cellProbeOcclusionData, string scenario, List<Int32> cellIndices) { }

	internal bool ResolvePerScenarioCellData(List<Int32> cellIndices) { }

	private void ResolveSharedCellData(List<Int32> cellIndices, NativeArray<Brick> bricksData, NativeArray<Byte> cellSharedData, NativeArray<Byte> cellSupportData) { }

	internal bool ResolveSharedCellData(List<Int32> cellIndices) { }

	internal void set_bakedSkyOcclusion(bool value) { }

	internal void set_bakedSkyShadingDirection(bool value) { }

	internal void SetActiveScenario(string scenario, bool verbose = true) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

