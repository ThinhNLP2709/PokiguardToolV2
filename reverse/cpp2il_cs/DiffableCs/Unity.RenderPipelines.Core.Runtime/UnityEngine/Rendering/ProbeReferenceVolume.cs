namespace UnityEngine.Rendering;

public class ProbeReferenceVolume
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static UnityAction<Cell> <>9__148_0; //Field offset: 0x8
		public static UnityAction<CellStreamingRequest> <>9__148_1; //Field offset: 0x10
		public static Func<Boolean> <>9__219_1; //Field offset: 0x18
		public static Func<Single> <>9__219_8; //Field offset: 0x20
		public static Func<Single> <>9__219_18; //Field offset: 0x28
		public static Func<Single> <>9__219_19; //Field offset: 0x30
		public static Func<Int32> <>9__219_25; //Field offset: 0x38
		public static Func<Int32> <>9__219_29; //Field offset: 0x40
		public static Func<Single> <>9__219_36; //Field offset: 0x48
		public static Func<Single> <>9__219_37; //Field offset: 0x50
		public static Func<Single> <>9__219_45; //Field offset: 0x58
		public static Func<Single> <>9__219_46; //Field offset: 0x60
		public static Func<Single> <>9__219_50; //Field offset: 0x68
		public static Func<Boolean> <>9__219_60; //Field offset: 0x70
		public static Action<Boolean> <>9__219_61; //Field offset: 0x78
		public static Func<Boolean> <>9__219_62; //Field offset: 0x80
		public static Func<Int32> <>9__219_63; //Field offset: 0x88
		public static Action<Int32> <>9__219_64; //Field offset: 0x90
		public static Func<Int32> <>9__219_65; //Field offset: 0x98
		public static Func<Int32> <>9__219_66; //Field offset: 0xA0
		public static Func<Object> <>9__219_70; //Field offset: 0xA8
		public static Func<Int32> <>9__219_76; //Field offset: 0xB0
		public static Action<Int32> <>9__219_77; //Field offset: 0xB8
		public static Func<Int32> <>9__219_78; //Field offset: 0xC0
		public static Func<Single> <>9__219_79; //Field offset: 0xC8
		public static Action<Single> <>9__219_80; //Field offset: 0xD0
		public static Func<Single> <>9__219_81; //Field offset: 0xD8
		public static Func<Single> <>9__219_82; //Field offset: 0xE0
		public static Func<Single> <>9__219_87; //Field offset: 0xE8
		public static Action<Single> <>9__219_88; //Field offset: 0xF0
		public static Func<Single> <>9__219_89; //Field offset: 0xF8
		public static Func<Single> <>9__219_90; //Field offset: 0x100
		public static BaseRenderFunc<RenderFragmentationOverlayPassData, RenderGraphContext> <>9__222_0; //Field offset: 0x108
		public static UnityAction<CellStreamingRequest> <>9__283_0; //Field offset: 0x110

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__148_0(Cell x) { }

		internal void <.ctor>b__148_1(CellStreamingRequest val) { }

		internal void <CleanupStreaming>b__283_0(CellStreamingRequest val) { }

		internal bool <RegisterDebug>b__219_1() { }

		internal float <RegisterDebug>b__219_18() { }

		internal float <RegisterDebug>b__219_19() { }

		internal int <RegisterDebug>b__219_25() { }

		internal int <RegisterDebug>b__219_29() { }

		internal float <RegisterDebug>b__219_36() { }

		internal float <RegisterDebug>b__219_37() { }

		internal float <RegisterDebug>b__219_45() { }

		internal float <RegisterDebug>b__219_46() { }

		internal float <RegisterDebug>b__219_50() { }

		internal bool <RegisterDebug>b__219_60() { }

		internal void <RegisterDebug>b__219_61(bool value) { }

		internal bool <RegisterDebug>b__219_62() { }

		internal int <RegisterDebug>b__219_63() { }

		internal void <RegisterDebug>b__219_64(int value) { }

		internal int <RegisterDebug>b__219_65() { }

		internal int <RegisterDebug>b__219_66() { }

		internal object <RegisterDebug>b__219_70() { }

		internal int <RegisterDebug>b__219_76() { }

		internal void <RegisterDebug>b__219_77(int value) { }

		internal int <RegisterDebug>b__219_78() { }

		internal float <RegisterDebug>b__219_79() { }

		internal float <RegisterDebug>b__219_8() { }

		internal void <RegisterDebug>b__219_80(float value) { }

		internal float <RegisterDebug>b__219_81() { }

		internal float <RegisterDebug>b__219_82() { }

		internal float <RegisterDebug>b__219_87() { }

		internal void <RegisterDebug>b__219_88(float value) { }

		internal float <RegisterDebug>b__219_89() { }

		internal float <RegisterDebug>b__219_90() { }

		internal void <RenderFragmentationOverlay>b__222_0(RenderFragmentationOverlayPassData data, RenderGraphContext ctx) { }

	}

	[DebuggerDisplay("Index = {desc.index} Loaded = {loaded}")]
	public class Cell : IComparable<Cell>
	{
		public CellDesc desc; //Field offset: 0x10
		public CellData data; //Field offset: 0x18
		public CellPoolInfo poolInfo; //Field offset: 0x20
		public CellIndexInfo indexInfo; //Field offset: 0x28
		public CellBlendingInfo blendingInfo; //Field offset: 0x30
		public CellStreamingInfo streamingInfo; //Field offset: 0x38
		public int referenceCount; //Field offset: 0x40
		public bool loaded; //Field offset: 0x44
		public PerScenarioData scenario0; //Field offset: 0x48
		public PerScenarioData scenario1; //Field offset: 0xC8
		public bool hasTwoScenarios; //Field offset: 0x148
		public CellInstancedDebugProbes debugProbes; //Field offset: 0x150

		public Cell() { }

		public void Clear() { }

		public override int CompareTo(Cell other) { }

		public bool UpdateCellScenarioData(string scenario0, string scenario1) { }

	}

	public class CellBlendingInfo
	{
		public List<BrickChunkAlloc> chunkList; //Field offset: 0x10
		public float blendingScore; //Field offset: 0x18
		public float blendingFactor; //Field offset: 0x1C
		public bool blending; //Field offset: 0x20

		public CellBlendingInfo() { }

		public void Clear() { }

		public void ForceReupload() { }

		public bool IsUpToDate() { }

		public void MarkUpToDate() { }

		public void Prioritize() { }

		public bool ShouldPrioritize() { }

		public bool ShouldReupload() { }

	}

	public class CellData
	{
		internal struct PerScenarioData
		{
			public NativeArray<UInt16> shL0L1RxData; //Field offset: 0x0
			public NativeArray<Byte> shL1GL1RyData; //Field offset: 0x10
			public NativeArray<Byte> shL1BL1RzData; //Field offset: 0x20
			public NativeArray<Byte> shL2Data_0; //Field offset: 0x30
			public NativeArray<Byte> shL2Data_1; //Field offset: 0x40
			public NativeArray<Byte> shL2Data_2; //Field offset: 0x50
			public NativeArray<Byte> shL2Data_3; //Field offset: 0x60
			public NativeArray<Byte> probeOcclusion; //Field offset: 0x70

		}

		public NativeArray<Byte> validityNeighMaskData; //Field offset: 0x10
		[CompilerGenerated]
		private NativeArray<UInt16> <skyOcclusionDataL0L1>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private NativeArray<Byte> <skyShadingDirectionIndices>k__BackingField; //Field offset: 0x30
		public Dictionary<String, PerScenarioData> scenarios; //Field offset: 0x40
		[CompilerGenerated]
		private NativeArray<Brick> <bricks>k__BackingField; //Field offset: 0x48
		[CompilerGenerated]
		private NativeArray<Vector3> <probePositions>k__BackingField; //Field offset: 0x58
		[CompilerGenerated]
		private NativeArray<Single> <touchupVolumeInteraction>k__BackingField; //Field offset: 0x68
		[CompilerGenerated]
		private NativeArray<Vector3> <offsetVectors>k__BackingField; //Field offset: 0x78
		[CompilerGenerated]
		private NativeArray<Single> <validity>k__BackingField; //Field offset: 0x88
		[CompilerGenerated]
		private NativeArray<Byte> <layer>k__BackingField; //Field offset: 0x98

		public internal NativeArray<Brick> bricks
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<Byte> layer
		{
			[CompilerGenerated]
			 get { } //Length: 14
			[CompilerGenerated]
			internal set { } //Length: 11
		}

		public internal NativeArray<Vector3> offsetVectors
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<Vector3> probePositions
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<UInt16> skyOcclusionDataL0L1
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<Byte> skyShadingDirectionIndices
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<Single> touchupVolumeInteraction
		{
			[CompilerGenerated]
			 get { } //Length: 11
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public internal NativeArray<Single> validity
		{
			[CompilerGenerated]
			 get { } //Length: 14
			[CompilerGenerated]
			internal set { } //Length: 11
		}

		public CellData() { }

		public void Cleanup(bool cleanScenarioList) { }

		public void CleanupPerScenarioData(in PerScenarioData data) { }

		[CompilerGenerated]
		public NativeArray<Brick> get_bricks() { }

		[CompilerGenerated]
		public NativeArray<Byte> get_layer() { }

		[CompilerGenerated]
		public NativeArray<Vector3> get_offsetVectors() { }

		[CompilerGenerated]
		public NativeArray<Vector3> get_probePositions() { }

		[CompilerGenerated]
		public NativeArray<UInt16> get_skyOcclusionDataL0L1() { }

		[CompilerGenerated]
		public NativeArray<Byte> get_skyShadingDirectionIndices() { }

		[CompilerGenerated]
		public NativeArray<Single> get_touchupVolumeInteraction() { }

		[CompilerGenerated]
		public NativeArray<Single> get_validity() { }

		[CompilerGenerated]
		internal void set_bricks(NativeArray<Brick> value) { }

		[CompilerGenerated]
		internal void set_layer(NativeArray<Byte> value) { }

		[CompilerGenerated]
		internal void set_offsetVectors(NativeArray<Vector3> value) { }

		[CompilerGenerated]
		internal void set_probePositions(NativeArray<Vector3> value) { }

		[CompilerGenerated]
		internal void set_skyOcclusionDataL0L1(NativeArray<UInt16> value) { }

		[CompilerGenerated]
		internal void set_skyShadingDirectionIndices(NativeArray<Byte> value) { }

		[CompilerGenerated]
		internal void set_touchupVolumeInteraction(NativeArray<Single> value) { }

		[CompilerGenerated]
		internal void set_validity(NativeArray<Single> value) { }

	}

	public class CellDesc
	{
		public Vector3Int position; //Field offset: 0x10
		public int index; //Field offset: 0x1C
		public int probeCount; //Field offset: 0x20
		public int minSubdiv; //Field offset: 0x24
		public int indexChunkCount; //Field offset: 0x28
		public int shChunkCount; //Field offset: 0x2C
		public int bricksCount; //Field offset: 0x30
		public IndirectionEntryInfo[] indirectionEntryInfo; //Field offset: 0x38

		public CellDesc() { }

		public virtual string ToString() { }

	}

	public class CellIndexInfo
	{
		public Int32[] flatIndicesInGlobalIndirection; //Field offset: 0x10
		public CellIndexUpdateInfo updateInfo; //Field offset: 0x18
		public bool indexUpdated; //Field offset: 0x20
		public IndirectionEntryInfo[] indirectionEntryInfo; //Field offset: 0x28
		public int indexChunkCount; //Field offset: 0x30

		public CellIndexInfo() { }

		public void Clear() { }

	}

	public class CellInstancedDebugProbes
	{
		public List<Matrix4x4[]> probeBuffers; //Field offset: 0x10
		public List<Matrix4x4[]> offsetBuffers; //Field offset: 0x18
		public List<MaterialPropertyBlock> props; //Field offset: 0x20

		public CellInstancedDebugProbes() { }

	}

	public class CellPoolInfo
	{
		public List<BrickChunkAlloc> chunkList; //Field offset: 0x10
		public int shChunkCount; //Field offset: 0x18

		public CellPoolInfo() { }

		public void Clear() { }

	}

	public class CellStreamingInfo
	{
		public CellStreamingRequest request; //Field offset: 0x10
		public CellStreamingRequest blendingRequest0; //Field offset: 0x18
		public CellStreamingRequest blendingRequest1; //Field offset: 0x20
		public float streamingScore; //Field offset: 0x28

		public CellStreamingInfo() { }

		public void Clear() { }

		public bool IsBlendingStreaming() { }

		public bool IsStreaming() { }

	}

	[DebuggerDisplay("Index = {cell.desc.index} State = {state}")]
	public class CellStreamingRequest
	{
		internal sealed class OnStreamingCompleteDelegate : MulticastDelegate
		{

			public OnStreamingCompleteDelegate(object object, IntPtr method) { }

			public override IAsyncResult BeginInvoke(CellStreamingRequest request, CommandBuffer cmd, AsyncCallback callback, object object) { }

			public override void EndInvoke(IAsyncResult result) { }

			public override void Invoke(CellStreamingRequest request, CommandBuffer cmd) { }

		}

		internal enum State
		{
			Pending = 0,
			Active = 1,
			Canceled = 2,
			Invalid = 3,
			Complete = 4,
		}

		[CompilerGenerated]
		private Cell <cell>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private State <state>k__BackingField; //Field offset: 0x18
		[CompilerGenerated]
		private CellStreamingScratchBuffer <scratchBuffer>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private CellStreamingScratchBufferLayout <scratchBufferLayout>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		private PerScenarioDataInfo <scenarioData>k__BackingField; //Field offset: 0x98
		[CompilerGenerated]
		private int <poolIndex>k__BackingField; //Field offset: 0xA0
		[CompilerGenerated]
		private bool <streamSharedData>k__BackingField; //Field offset: 0xA4
		public OnStreamingCompleteDelegate onStreamingComplete; //Field offset: 0xA8
		public DiskStreamingRequest cellDataStreamingRequest; //Field offset: 0xB0
		public DiskStreamingRequest cellOptionalDataStreamingRequest; //Field offset: 0xB8
		public DiskStreamingRequest cellSharedDataStreamingRequest; //Field offset: 0xC0
		public DiskStreamingRequest cellProbeOcclusionDataStreamingRequest; //Field offset: 0xC8
		public DiskStreamingRequest brickStreamingRequest; //Field offset: 0xD0
		public DiskStreamingRequest supportStreamingRequest; //Field offset: 0xD8
		public int bytesWritten; //Field offset: 0xE0

		public Cell cell
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public int poolIndex
		{
			[CompilerGenerated]
			 get { } //Length: 7
			[CompilerGenerated]
			 set { } //Length: 7
		}

		public PerScenarioDataInfo scenarioData
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 19
		}

		public CellStreamingScratchBuffer scratchBuffer
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public CellStreamingScratchBufferLayout scratchBufferLayout
		{
			[CompilerGenerated]
			 get { } //Length: 62
			[CompilerGenerated]
			 set { } //Length: 59
		}

		public State state
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool streamSharedData
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 7
		}

		public CellStreamingRequest() { }

		public void Cancel() { }

		public void Clear() { }

		public void Dispose() { }

		[CompilerGenerated]
		public Cell get_cell() { }

		[CompilerGenerated]
		public int get_poolIndex() { }

		[CompilerGenerated]
		public PerScenarioDataInfo get_scenarioData() { }

		[CompilerGenerated]
		public CellStreamingScratchBuffer get_scratchBuffer() { }

		[CompilerGenerated]
		public CellStreamingScratchBufferLayout get_scratchBufferLayout() { }

		[CompilerGenerated]
		public State get_state() { }

		[CompilerGenerated]
		public bool get_streamSharedData() { }

		public bool IsStreaming() { }

		public void Reset() { }

		[CompilerGenerated]
		public void set_cell(Cell value) { }

		[CompilerGenerated]
		public void set_poolIndex(int value) { }

		[CompilerGenerated]
		public void set_scenarioData(PerScenarioDataInfo value) { }

		[CompilerGenerated]
		public void set_scratchBuffer(CellStreamingScratchBuffer value) { }

		[CompilerGenerated]
		public void set_scratchBufferLayout(CellStreamingScratchBufferLayout value) { }

		[CompilerGenerated]
		public void set_state(State value) { }

		[CompilerGenerated]
		public void set_streamSharedData(bool value) { }

		public bool UpdateRequestState(DiskStreamingRequest request, ref bool isComplete) { }

		public void UpdateState() { }

		public void WaitAll() { }

	}

	public class CellStreamingScratchBuffer
	{
		public NativeArray<Byte> stagingBuffer; //Field offset: 0x10
		[CompilerGenerated]
		private readonly int <chunkCount>k__BackingField; //Field offset: 0x20
		private int m_CurrentBuffer; //Field offset: 0x24
		private GraphicsBuffer[] m_GraphicsBuffers; //Field offset: 0x28

		public GraphicsBuffer buffer
		{
			 get { } //Length: 43
		}

		public int chunkCount
		{
			[CompilerGenerated]
			 get { } //Length: 4
		}

		public CellStreamingScratchBuffer(int chunkCount, int chunkSize, bool allocateGraphicsBuffers) { }

		public void Dispose() { }

		public GraphicsBuffer get_buffer() { }

		[CompilerGenerated]
		public int get_chunkCount() { }

		public void Swap() { }

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\Lighting\\ProbeVolume\\ProbeReferenceVolume.Streaming.cs", needAccessors = False, generateCBuffer = True)]
	public struct CellStreamingScratchBufferLayout
	{
		public int _SharedDestChunksOffset; //Field offset: 0x0
		public int _L0L1rxOffset; //Field offset: 0x4
		public int _L1GryOffset; //Field offset: 0x8
		public int _L1BrzOffset; //Field offset: 0xC
		public int _ValidityOffset; //Field offset: 0x10
		public int _ProbeOcclusionOffset; //Field offset: 0x14
		public int _SkyOcclusionOffset; //Field offset: 0x18
		public int _SkyShadingDirectionOffset; //Field offset: 0x1C
		public int _L2_0Offset; //Field offset: 0x20
		public int _L2_1Offset; //Field offset: 0x24
		public int _L2_2Offset; //Field offset: 0x28
		public int _L2_3Offset; //Field offset: 0x2C
		public int _L0Size; //Field offset: 0x30
		public int _L0ProbeSize; //Field offset: 0x34
		public int _L1Size; //Field offset: 0x38
		public int _L1ProbeSize; //Field offset: 0x3C
		public int _ValiditySize; //Field offset: 0x40
		public int _ValidityProbeSize; //Field offset: 0x44
		public int _ProbeOcclusionSize; //Field offset: 0x48
		public int _ProbeOcclusionProbeSize; //Field offset: 0x4C
		public int _SkyOcclusionSize; //Field offset: 0x50
		public int _SkyOcclusionProbeSize; //Field offset: 0x54
		public int _SkyShadingDirectionSize; //Field offset: 0x58
		public int _SkyShadingDirectionProbeSize; //Field offset: 0x5C
		public int _L2Size; //Field offset: 0x60
		public int _L2ProbeSize; //Field offset: 0x64
		public int _ProbeCountInChunkLine; //Field offset: 0x68
		public int _ProbeCountInChunkSlice; //Field offset: 0x6C

	}

	public class DiskStreamingRequest
	{
		private ReadHandle m_ReadHandle; //Field offset: 0x10
		private ReadCommandArray m_ReadCommandArray; //Field offset: 0x20
		private NativeArray<ReadCommand> m_ReadCommandBuffer; //Field offset: 0x30
		private int m_BytesWritten; //Field offset: 0x40

		public DiskStreamingRequest(int maxRequestCount) { }

		public void AddReadCommand(int offset, int size, Byte* dest) { }

		public void Cancel() { }

		public void Clear() { }

		public void Dispose() { }

		public ReadStatus GetStatus() { }

		public int RunCommands(FileHandle file) { }

		public void Wait() { }

	}

	internal struct ExtraDataActionInput
	{

	}

	public struct IndirectionEntryInfo
	{
		public Vector3Int positionInBricks; //Field offset: 0x0
		public int minSubdiv; //Field offset: 0xC
		public Vector3Int minBrickPos; //Field offset: 0x10
		public Vector3Int maxBrickPosPlusOne; //Field offset: 0x1C
		public bool hasMinMax; //Field offset: 0x28
		public bool hasOnlyBiggerBricks; //Field offset: 0x29

	}

	public struct RefVolTransform
	{
		public Vector3 posWS; //Field offset: 0x0
		public Quaternion rot; //Field offset: 0xC
		public float scale; //Field offset: 0x1C

	}

	private class RenderFragmentationOverlayPassData
	{
		public Material debugFragmentationMaterial; //Field offset: 0x10
		public DebugOverlay debugOverlay; //Field offset: 0x18
		public int chunkCount; //Field offset: 0x20
		public ComputeBuffer debugFragmentationData; //Field offset: 0x28
		public TextureHandle colorBuffer; //Field offset: 0x30
		public TextureHandle depthBuffer; //Field offset: 0x40

		public RenderFragmentationOverlayPassData() { }

	}

	internal struct RuntimeResources
	{
		public ComputeBuffer index; //Field offset: 0x0
		public ComputeBuffer cellIndices; //Field offset: 0x8
		public RenderTexture L0_L1rx; //Field offset: 0x10
		public RenderTexture L1_G_ry; //Field offset: 0x18
		public RenderTexture L1_B_rz; //Field offset: 0x20
		public RenderTexture L2_0; //Field offset: 0x28
		public RenderTexture L2_1; //Field offset: 0x30
		public RenderTexture L2_2; //Field offset: 0x38
		public RenderTexture L2_3; //Field offset: 0x40
		public RenderTexture ProbeOcclusion; //Field offset: 0x48
		public RenderTexture Validity; //Field offset: 0x50
		public RenderTexture SkyOcclusionL0L1; //Field offset: 0x58
		public RenderTexture SkyShadingDirectionIndices; //Field offset: 0x60
		public ComputeBuffer SkyPrecomputedDirections; //Field offset: 0x68
		public ComputeBuffer QualityLeakReductionData; //Field offset: 0x70

	}

	public static class ShaderIDs
	{
		public static readonly int _APVResIndex; //Field offset: 0x0
		public static readonly int _APVResCellIndices; //Field offset: 0x4
		public static readonly int _APVResL0_L1Rx; //Field offset: 0x8
		public static readonly int _APVResL1G_L1Ry; //Field offset: 0xC
		public static readonly int _APVResL1B_L1Rz; //Field offset: 0x10
		public static readonly int _APVResL2_0; //Field offset: 0x14
		public static readonly int _APVResL2_1; //Field offset: 0x18
		public static readonly int _APVResL2_2; //Field offset: 0x1C
		public static readonly int _APVResL2_3; //Field offset: 0x20
		public static readonly int _APVProbeOcclusion; //Field offset: 0x24
		public static readonly int _APVResValidity; //Field offset: 0x28
		public static readonly int _SkyOcclusionTexL0L1; //Field offset: 0x2C
		public static readonly int _SkyShadingDirectionIndicesTex; //Field offset: 0x30
		public static readonly int _SkyPrecomputedDirections; //Field offset: 0x34
		public static readonly int _AntiLeakData; //Field offset: 0x38

		private static ShaderIDs() { }

	}

	public struct Volume : IEquatable<Volume>
	{
		internal Vector3 corner; //Field offset: 0x0
		internal Vector3 X; //Field offset: 0xC
		internal Vector3 Y; //Field offset: 0x18
		internal Vector3 Z; //Field offset: 0x24
		internal float maxSubdivisionMultiplier; //Field offset: 0x30
		internal float minSubdivisionMultiplier; //Field offset: 0x34

		public Volume(Matrix4x4 trs, float maxSubdivision, float minSubdivision) { }

		public Volume(Vector3 corner, Vector3 X, Vector3 Y, Vector3 Z, float maxSubdivision = 1, float minSubdivision = 0) { }

		public Volume(Volume copy) { }

		public Volume(Bounds bounds) { }

		public Bounds CalculateAABB() { }

		public void CalculateCenterAndSize(out Vector3 center, out Vector3 size) { }

		public override bool Equals(Volume other) { }

		public virtual string ToString() { }

		public void Transform(Matrix4x4 trs) { }

	}

	private const float kIndexFragmentationThreshold = 0.2; //Field offset: 0x0
	private const int kMaxCellLoadedPerFrame = 10; //Field offset: 0x0
	private const int kProbesPerBatch = 511; //Field offset: 0x0
	internal static string defaultLightingScenario; //Field offset: 0x0
	private static ProbeReferenceVolume _instance; //Field offset: 0x8
	public static readonly string k_DebugPanelName; //Field offset: 0x10
	internal static ProbeSamplingDebugData probeSamplingDebugData; //Field offset: 0x18
	private static Vector4[] s_BoundsArray; //Field offset: 0x20
	private static SortComparer<Cell> s_BlendingComparer; //Field offset: 0x28
	private static SortComparer<Cell> s_DefragComparer; //Field offset: 0x30
	private ComputeBuffer m_EmptyIndexBuffer; //Field offset: 0x10
	private bool m_IsInitialized; //Field offset: 0x18
	private bool m_SupportScenarios; //Field offset: 0x19
	private bool m_SupportScenarioBlending; //Field offset: 0x1A
	private bool m_ForceNoDiskStreaming; //Field offset: 0x1B
	private bool m_SupportDiskStreaming; //Field offset: 0x1C
	private bool m_SupportGPUStreaming; //Field offset: 0x1D
	private bool m_UseStreamingAssets; //Field offset: 0x1E
	private float m_MinBrickSize; //Field offset: 0x20
	private int m_MaxSubdivision; //Field offset: 0x24
	private Vector3 m_ProbeOffset; //Field offset: 0x28
	private ProbeBrickPool m_Pool; //Field offset: 0x38
	private ProbeBrickIndex m_Index; //Field offset: 0x40
	private ProbeGlobalIndirection m_CellIndices; //Field offset: 0x48
	private ProbeBrickBlendingPool m_BlendingPool; //Field offset: 0x50
	private List<BrickChunkAlloc> m_TmpSrcChunks; //Field offset: 0x58
	private Single[] m_PositionOffsets; //Field offset: 0x60
	private Bounds m_CurrGlobalBounds; //Field offset: 0x68
	internal Dictionary<Int32, Cell> cells; //Field offset: 0x80
	private ObjectPool<Cell> m_CellPool; //Field offset: 0x88
	private DataLocation m_TemporaryDataLocation; //Field offset: 0x90
	private int m_TemporaryDataLocationMemCost; //Field offset: 0xF8
	[Obsolete("This field is only kept for migration purpose.")]
	internal ProbeVolumeSceneData sceneData; //Field offset: 0x100
	private Vector3Int minLoadedCellPos; //Field offset: 0x108
	private Vector3Int maxLoadedCellPos; //Field offset: 0x114
	public Action<ExtraDataActionInput> retrieveExtraDataAction; //Field offset: 0x120
	public Action checksDuringBakeAction; //Field offset: 0x128
	private Dictionary<String, ValueTuple`2<ProbeVolumeBakingSet, List`1<Int32>>> m_PendingScenesToBeLoaded; //Field offset: 0x130
	private Dictionary<String, List`1<Int32>> m_PendingScenesToBeUnloaded; //Field offset: 0x138
	private List<String> m_ActiveScenes; //Field offset: 0x140
	private ProbeVolumeBakingSet m_CurrentBakingSet; //Field offset: 0x148
	private bool m_NeedLoadAsset; //Field offset: 0x150
	private bool m_ProbeReferenceVolumeInit; //Field offset: 0x151
	private bool m_EnabledBySRP; //Field offset: 0x152
	private bool m_VertexSampling; //Field offset: 0x153
	private bool m_NeedsIndexRebuild; //Field offset: 0x154
	private bool m_HasChangedIndex; //Field offset: 0x155
	private int m_CBShaderID; //Field offset: 0x158
	private ProbeVolumeTextureMemoryBudget m_MemoryBudget; //Field offset: 0x15C
	private ProbeVolumeBlendingTextureMemoryBudget m_BlendingMemoryBudget; //Field offset: 0x160
	private ProbeVolumeSHBands m_SHBands; //Field offset: 0x164
	internal bool clearAssetsOnVolumeClear; //Field offset: 0x168
	[CompilerGenerated]
	private List<ProbeVolumePerSceneData> <perSceneDataList>k__BackingField; //Field offset: 0x170
	[CompilerGenerated]
	private readonly ProbeVolumeDebug <probeVolumeDebug>k__BackingField; //Field offset: 0x178
	[CompilerGenerated]
	private readonly Color[] <subdivisionDebugColors>k__BackingField; //Field offset: 0x180
	private Mesh m_DebugMesh; //Field offset: 0x188
	private Widget[] m_DebugItems; //Field offset: 0x190
	private Material m_DebugMaterial; //Field offset: 0x198
	private Mesh m_DebugProbeSamplingMesh; //Field offset: 0x1A0
	private Material m_ProbeSamplingDebugMaterial; //Field offset: 0x1A8
	private Material m_ProbeSamplingDebugMaterial02; //Field offset: 0x1B0
	private Texture m_DisplayNumbersTexture; //Field offset: 0x1B8
	private Mesh m_DebugOffsetMesh; //Field offset: 0x1C0
	private Material m_DebugOffsetMaterial; //Field offset: 0x1C8
	private Material m_DebugFragmentationMaterial; //Field offset: 0x1D0
	private Plane[] m_DebugFrustumPlanes; //Field offset: 0x1D8
	private GUIContent[] m_DebugScenarioNames; //Field offset: 0x1E0
	private Int32[] m_DebugScenarioValues; //Field offset: 0x1E8
	private string m_DebugActiveSceneGUID; //Field offset: 0x1F0
	private string m_DebugActiveScenario; //Field offset: 0x1F8
	private EnumField m_DebugScenarioField; //Field offset: 0x200
	internal Dictionary<Bounds, Brick[]> realtimeSubdivisionInfo; //Field offset: 0x208
	private bool m_MaxSubdivVisualizedIsMaxAvailable; //Field offset: 0x210
	private bool m_LoadMaxCellsPerFrame; //Field offset: 0x211
	private int m_NumberOfCellsLoadedPerFrame; //Field offset: 0x214
	private int m_NumberOfCellsBlendedPerFrame; //Field offset: 0x218
	private float m_TurnoverRate; //Field offset: 0x21C
	private DynamicArray<Cell> m_LoadedCells; //Field offset: 0x220
	private DynamicArray<Cell> m_ToBeLoadedCells; //Field offset: 0x228
	private DynamicArray<Cell> m_WorseLoadedCells; //Field offset: 0x230
	private DynamicArray<Cell> m_BestToBeLoadedCells; //Field offset: 0x238
	private DynamicArray<Cell> m_TempCellToLoadList; //Field offset: 0x240
	private DynamicArray<Cell> m_TempCellToUnloadList; //Field offset: 0x248
	private DynamicArray<Cell> m_LoadedBlendingCells; //Field offset: 0x250
	private DynamicArray<Cell> m_ToBeLoadedBlendingCells; //Field offset: 0x258
	private DynamicArray<Cell> m_TempBlendingCellToLoadList; //Field offset: 0x260
	private DynamicArray<Cell> m_TempBlendingCellToUnloadList; //Field offset: 0x268
	private Vector3 m_FrozenCameraPosition; //Field offset: 0x270
	private Vector3 m_FrozenCameraDirection; //Field offset: 0x27C
	private bool m_IndexDefragmentationInProgress; //Field offset: 0x288
	private ProbeBrickIndex m_DefragIndex; //Field offset: 0x290
	private ProbeGlobalIndirection m_DefragCellIndices; //Field offset: 0x298
	private DynamicArray<Cell> m_IndexDefragCells; //Field offset: 0x2A0
	private DynamicArray<Cell> m_TempIndexDefragCells; //Field offset: 0x2A8
	internal float minStreamingScore; //Field offset: 0x2B0
	internal float maxStreamingScore; //Field offset: 0x2B4
	private Queue<CellStreamingRequest> m_StreamingQueue; //Field offset: 0x2B8
	private List<CellStreamingRequest> m_ActiveStreamingRequests; //Field offset: 0x2C0
	private ObjectPool<CellStreamingRequest> m_StreamingRequestsPool; //Field offset: 0x2C8
	private bool m_DiskStreamingUseCompute; //Field offset: 0x2D0
	private ProbeVolumeScratchBufferPool m_ScratchBufferPool; //Field offset: 0x2D8
	private OnStreamingCompleteDelegate m_OnStreamingComplete; //Field offset: 0x2E0
	private OnStreamingCompleteDelegate m_OnBlendingStreamingComplete; //Field offset: 0x2E8

	public ProbeVolumeBakingSet currentBakingSet
	{
		 get { } //Length: 8
	}

	private Mesh debugMesh
	{
		private get { } //Length: 437
	}

	internal bool diskStreamingEnabled
	{
		internal get { } //Length: 17
	}

	internal bool enabledBySRP
	{
		internal get { } //Length: 8
	}

	internal Bounds globalBounds
	{
		internal get { } //Length: 21
		internal set { } //Length: 18
	}

	internal bool gpuStreamingEnabled
	{
		internal get { } //Length: 5
	}

	internal bool hasUnloadedCells
	{
		internal get { } //Length: 67
	}

	internal float indexFragmentationRate
	{
		internal get { } //Length: 45
	}

	public static ProbeReferenceVolume instance
	{
		 get { } //Length: 79
	}

	public bool isInitialized
	{
		 get { } //Length: 5
	}

	public string lightingScenario
	{
		 get { } //Length: 131
		 set { } //Length: 141
	}

	public bool loadMaxCellsPerFrame
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	public ProbeVolumeTextureMemoryBudget memoryBudget
	{
		 get { } //Length: 7
	}

	public int numberOfCellsBlendedPerFrame
	{
		 get { } //Length: 7
		 set { } //Length: 19
	}

	private int numberOfCellsLoadedPerFrame
	{
		private get { } //Length: 92
	}

	public string otherScenario
	{
		 get { } //Length: 131
	}

	internal List<ProbeVolumePerSceneData> perSceneDataList
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public bool probeOcclusion
	{
		 get { } //Length: 131
	}

	internal ProbeVolumeDebug probeVolumeDebug
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	public float scenarioBlendingFactor
	{
		 get { } //Length: 133
		 set { } //Length: 152
	}

	public ProbeVolumeSHBands shBands
	{
		 get { } //Length: 7
	}

	public bool skyOcclusion
	{
		 get { } //Length: 130
	}

	public bool skyOcclusionShadingDirection
	{
		 get { } //Length: 130
	}

	public Color[] subdivisionDebugColors
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal bool supportLightingScenarios
	{
		internal get { } //Length: 5
	}

	internal bool supportScenarioBlending
	{
		internal get { } //Length: 5
	}

	public float turnoverRate
	{
		 get { } //Length: 9
		 set { } //Length: 39
	}

	private bool useRenderingLayers
	{
		private get { } //Length: 36
	}

	internal bool vertexSampling
	{
		internal get { } //Length: 8
	}

	private static ProbeReferenceVolume() { }

	private ProbeReferenceVolume() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_10(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_11() { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_12() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_13(int value) { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_14() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_15(int value) { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_16() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_17(float value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_2() { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_20() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_21(float value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_22() { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_23() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_24(int v) { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_26() { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_27() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_28(int v) { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_3(bool value) { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_30() { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_31() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_32(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_33() { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_34() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_35(float value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_38() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_39(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_4() { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_40() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_41(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_42() { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_43() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_44(float value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_47() { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_48() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_49(float value) { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_5(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_51() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_52(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_53() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_54(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_55() { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_56() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_57(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_58() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_59(bool value) { }

	[CompilerGenerated]
	private float <RegisterDebug>b__219_6() { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_67() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_68(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_69() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_7(float value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_71() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_72(bool value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_73() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_74(bool value) { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_83() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_84(int value) { }

	[CompilerGenerated]
	private int <RegisterDebug>b__219_85() { }

	[CompilerGenerated]
	private void <RegisterDebug>b__219_86(int value) { }

	[CompilerGenerated]
	private bool <RegisterDebug>b__219_9() { }

	[CompilerGenerated]
	private void <RegisterDebug>g__RefreshDebug|219_0(Field<T> field, T value) { }

	[CompilerGenerated]
	private void <RegisterDebug>g__RefreshScenarioNames|219_75(string guid) { }

	private bool AddBlendingBricks(Cell cell) { }

	private bool AddBricks(Cell cell) { }

	private void AddCell(int cellIndex) { }

	internal void AddPendingSceneLoading(string sceneGUID, ProbeVolumeBakingSet bakingSet) { }

	internal void AddPendingSceneRemoval(string sceneGUID) { }

	private void AllocateScratchBufferPoolIfNeeded() { }

	public void BindAPVRuntimeResources(CommandBuffer cmdBuffer, bool isProbeVolumeEnabled) { }

	private static int BlendingComparer(Cell a, Cell b) { }

	public void BlendLightingScenario(string otherScenario, float blendingFactor) { }

	internal float BrickSize(int subdivisionLevel) { }

	private void CancelBlendingStreamingRequest(Cell cell) { }

	private void CancelStreamingRequest(Cell cell) { }

	internal static int CellSize(int subdivisionLevel) { }

	public void Cleanup() { }

	private void CleanupDebug() { }

	private void CleanupLoadedData() { }

	private void CleanupStreaming() { }

	internal void Clear() { }

	private void ClearDebugData() { }

	private void ComputeBestToBeLoadedCells(Vector3 cameraPosition, Vector3 cameraDirection) { }

	private void ComputeBlendingScore(DynamicArray<Cell> cells, float worstScore) { }

	private void ComputeCellGlobalInfo() { }

	private static void ComputeCellStreamingScore(Cell cell, Vector3 cameraPosition, Vector3 cameraDirection) { }

	internal void ComputeEntryMinMax(ref IndirectionEntryInfo entryInfo, ReadOnlySpan<Brick> bricks) { }

	private void ComputeMinMaxStreamingScore() { }

	private void ComputeStreamingScore(Vector3 cameraPosition, Vector3 cameraDirection, DynamicArray<Cell> cells) { }

	private void ComputeStreamingScoreAndWorseLoadedCells(Vector3 cameraPosition, Vector3 cameraDirection) { }

	private CellInstancedDebugProbes CreateInstancedProbes(Cell cell) { }

	public bool DataHasBeenLoaded() { }

	private void DebugCellIndexChanged(Field<T> field, T value) { }

	private static int DefragComparer(Cell a, Cell b) { }

	private void DeinitProbeReferenceVolume() { }

	private void DrawProbeDebug(Camera camera, Texture exposureTexture) { }

	public void EnableMaxCellStreaming(bool value) { }

	private int FindWorstBlendingCellToBeLoaded() { }

	internal void ForceNoDiskStreaming(bool state) { }

	internal void ForceSHBand(ProbeVolumeSHBands shBands) { }

	public ProbeVolumeBakingSet get_currentBakingSet() { }

	private Mesh get_debugMesh() { }

	internal bool get_diskStreamingEnabled() { }

	internal bool get_enabledBySRP() { }

	internal Bounds get_globalBounds() { }

	internal bool get_gpuStreamingEnabled() { }

	internal bool get_hasUnloadedCells() { }

	internal float get_indexFragmentationRate() { }

	public static ProbeReferenceVolume get_instance() { }

	public bool get_isInitialized() { }

	public string get_lightingScenario() { }

	public bool get_loadMaxCellsPerFrame() { }

	public ProbeVolumeTextureMemoryBudget get_memoryBudget() { }

	public int get_numberOfCellsBlendedPerFrame() { }

	private int get_numberOfCellsLoadedPerFrame() { }

	public string get_otherScenario() { }

	[CompilerGenerated]
	internal List<ProbeVolumePerSceneData> get_perSceneDataList() { }

	public bool get_probeOcclusion() { }

	[CompilerGenerated]
	internal ProbeVolumeDebug get_probeVolumeDebug() { }

	public float get_scenarioBlendingFactor() { }

	public ProbeVolumeSHBands get_shBands() { }

	public bool get_skyOcclusion() { }

	public bool get_skyOcclusionShadingDirection() { }

	[CompilerGenerated]
	public Color[] get_subdivisionDebugColors() { }

	internal bool get_supportLightingScenarios() { }

	internal bool get_supportScenarioBlending() { }

	public float get_turnoverRate() { }

	private bool get_useRenderingLayers() { }

	internal bool get_vertexSampling() { }

	private Bounds GetCellBounds(Vector3 cellPosition) { }

	internal float GetDistanceBetweenProbes(int subdivisionLevel) { }

	internal float GetEntrySize() { }

	internal int GetEntrySubdivLevel() { }

	internal int GetGlobalIndirectionEntryMaxSubdiv() { }

	internal int GetMaxSubdivision(float multiplier) { }

	internal int GetMaxSubdivision() { }

	internal static int GetNumberOfBricksAtSubdiv(IndirectionEntryInfo entryInfo) { }

	public bool GetProbeSamplingDebugResources(Camera camera, out GraphicsBuffer resultBuffer, out Vector2 coords) { }

	public RuntimeResources GetRuntimeResources() { }

	internal static string GetSceneGUID(Scene scene) { }

	private List<BrickChunkAlloc> GetSourceLocations(int count, int chunkSize, DataLocation dataLoc) { }

	public int GetVideoMemoryCost() { }

	public void Initialize(in ProbeVolumeSystemParameters parameters) { }

	private void InitializeDebug() { }

	internal void InitializeGlobalIndirection() { }

	private void InitProbeReferenceVolume() { }

	private void InitStreaming() { }

	public bool IsProbeSamplingDebugEnabled() { }

	internal void LoadAllCells() { }

	internal bool LoadCell(Cell cell, bool ignoreErrorLog = false) { }

	private bool LoadCells(List<Int32> cellIndices) { }

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	private void LogStreaming(string log) { }

	internal float MaxBrickSize() { }

	internal float MinBrickSize() { }

	internal float MinDistanceBetweenProbes() { }

	private void OnBlendingStreamingComplete(CellStreamingRequest request, CommandBuffer cmd) { }

	private void OnClearLightingdata() { }

	private void OnStreamingComplete(CellStreamingRequest request, CommandBuffer cmd) { }

	private void PerformPendingDeletion() { }

	private void PerformPendingIndexChangeAndInit() { }

	private void PerformPendingLoading() { }

	public void PerformPendingOperations() { }

	internal Vector3 ProbeOffset() { }

	private bool ProcessDiskStreamingRequest(CellStreamingRequest request) { }

	private void ProcessNewRequests() { }

	private void PushDiskStreamingRequest(Cell cell, string scenario, int poolIndex, OnStreamingCompleteDelegate onStreamingComplete) { }

	internal void RegisterBakingSet(ProbeVolumePerSceneData data) { }

	private void RegisterDebug() { }

	internal void RegisterPerSceneData(ProbeVolumePerSceneData data) { }

	private void ReleaseBricks(Cell cell) { }

	private void ReleasePoolChunks(List<BrickChunkAlloc> chunkList) { }

	private void RemoveCell(int cellIndex) { }

	internal void RemovePendingScene(string sceneGUID, List<Int32> cellList) { }

	[Obsolete("Use the other override to support sampling offset in debug modes.")]
	public void RenderDebug(Camera camera, Texture exposureTexture) { }

	public void RenderDebug(Camera camera, ProbeVolumesOptions options, Texture exposureTexture) { }

	public void RenderFragmentationOverlay(RenderGraph renderGraph, TextureHandle colorBuffer, TextureHandle depthBuffer, DebugOverlay debugOverlay) { }

	private bool ReservePoolChunks(int brickCount, List<BrickChunkAlloc> chunkList, bool ignoreErrorLog) { }

	internal void ResetDebugViewToMaxSubdiv() { }

	internal void ScenarioBlendingChanged(bool scenarioChanged) { }

	internal void set_globalBounds(Bounds value) { }

	public void set_lightingScenario(string value) { }

	public void set_loadMaxCellsPerFrame(bool value) { }

	public void set_numberOfCellsBlendedPerFrame(int value) { }

	[CompilerGenerated]
	private void set_perSceneDataList(List<ProbeVolumePerSceneData> value) { }

	public void set_scenarioBlendingFactor(float value) { }

	public void set_turnoverRate(float value) { }

	public void SetActiveBakingSet(ProbeVolumeBakingSet bakingSet) { }

	internal void SetActiveScenario(string scenario, bool verbose = true) { }

	public void SetActiveScene(Scene scene) { }

	private void SetBakingSetAsCurrent(ProbeVolumeBakingSet bakingSet) { }

	public void SetEnableStateFromSRP(bool srpEnablesPV) { }

	internal void SetMaxSubdivision(int maxSubdivision) { }

	public void SetNumberOfCellsLoadedPerFrame(int numberOfCells) { }

	internal void SetSubdivisionDimensions(float minBrickSize, int maxSubdiv, Vector3 offset) { }

	public void SetVertexSamplingEnabled(bool value) { }

	private bool ShouldCullCell(Vector3 cellPosition, Transform cameraTransform, Plane[] frustumPlanes) { }

	private bool ShouldCullCell(Vector3 cellPosition, Vector4[] adjustmentVolumeBounds, int adjustmentVolumeCount) { }

	private void StartIndexDefragmentation() { }

	private bool TryCreateDebugRenderData() { }

	internal bool TryGetPerSceneData(string sceneGUID, out ProbeVolumePerSceneData perSceneData) { }

	private bool TryLoadBlendingCell(Cell cell, DynamicArray<Cell> loadedCells) { }

	private bool TryLoadCell(Cell cell, ref int shBudget, ref int indexBudget, DynamicArray<Cell> loadedCells) { }

	internal void UnloadAllBlendingCells() { }

	internal void UnloadAllCells() { }

	internal void UnloadBakingSet() { }

	private void UnloadBlendingCell(Cell cell, DynamicArray<Cell> unloadedCells) { }

	internal void UnloadBlendingCell(Cell cell) { }

	internal void UnloadCell(Cell cell) { }

	private void UnregisterDebug(bool destroyPanel) { }

	internal void UnregisterPerSceneData(ProbeVolumePerSceneData data) { }

	private void UpdateActiveRequests(CommandBuffer cmd) { }

	private void UpdateBlendingCellStreaming(CommandBuffer cmd) { }

	private void UpdateCellIndex(Cell cell) { }

	public void UpdateCellStreaming(CommandBuffer cmd, Camera camera, ProbeVolumesOptions options) { }

	public void UpdateCellStreaming(CommandBuffer cmd, Camera camera) { }

	internal void UpdateConstantBuffer(CommandBuffer cmd, ProbeVolumeShadingParameters parameters) { }

	private void UpdateDataLocationTexture(Texture output, NativeArray<T> input) { }

	private static void UpdateDebugFromSelection(ref Vector4[] _AdjustmentVolumeBounds, ref int _AdjustmentVolumeCount) { }

	private void UpdateDiskStreaming(CommandBuffer cmd) { }

	private void UpdateIndexDefragmentation() { }

	private void UpdatePool(CommandBuffer cmd, List<BrickChunkAlloc> chunkList, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, int poolIndex) { }

	private void UpdatePool(List<BrickChunkAlloc> chunkList, PerScenarioData data, NativeArray<Byte> validityNeighMaskData, NativeArray<UInt16> skyOcclusionL0L1Data, NativeArray<Byte> skyShadingDirectionIndices, int chunkIndex, int poolIndex) { }

	private void UpdatePoolAndIndex(Cell cell, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, int poolIndex, CommandBuffer cmd) { }

	public bool UpdateShaderVariablesProbeVolumes(CommandBuffer cmd, ProbeVolumesOptions probeVolumeOptions, int taaFrameIndex, bool supportRenderingLayers = false) { }

	private void UpdateSharedData(List<BrickChunkAlloc> chunkList, NativeArray<Byte> validityNeighMaskData, NativeArray<UInt16> skyOcclusionData, NativeArray<Byte> skyShadingDirectionIndices, int chunkIndex) { }

	private void UpdateValidityTextureWithoutMask(Texture output, NativeArray<Byte> input) { }

}

