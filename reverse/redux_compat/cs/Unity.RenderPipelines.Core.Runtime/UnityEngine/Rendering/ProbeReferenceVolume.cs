/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.SceneManagement;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class ProbeReferenceVolume // TypeDefIndex: 5555
	{
		// Fields
		private ComputeBuffer m_EmptyIndexBuffer; // 0x10
		private const int kProbesPerBatch = 511; // Metadata: 0x006616F2
		public static readonly string k_DebugPanelName; // 0x00
		[CompilerGenerated]
		private ProbeVolumeDebug _probeVolumeDebug_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly Color[] _subdivisionDebugColors_k__BackingField; // 0x20
		private Mesh m_DebugMesh; // 0x28
		private DebugUI.Widget[] m_DebugItems; // 0x30
		private Material m_DebugMaterial; // 0x38
		private Mesh m_DebugProbeSamplingMesh; // 0x40
		private Material m_ProbeSamplingDebugMaterial; // 0x48
		private Material m_ProbeSamplingDebugMaterial02; // 0x50
		private Texture m_DisplayNumbersTexture; // 0x58
		[NoAutoStaticsCleanup]
		internal static ProbeSamplingDebugData probeSamplingDebugData; // 0x08
		private Mesh m_DebugOffsetMesh; // 0x60
		private Material m_DebugOffsetMaterial; // 0x68
		private Material m_DebugFragmentationMaterial; // 0x70
		private Plane[] m_DebugFrustumPlanes; // 0x78
		private GUIContent[] m_DebugScenarioNames; // 0x80
		private int[] m_DebugScenarioValues; // 0x88
		private string m_DebugActiveSceneGUID; // 0x90
		private string m_DebugActiveScenario; // 0x98
		private DebugUI.EnumField m_DebugScenarioField; // 0xA0
		internal Dictionary<Bounds, ProbeBrickIndex.Brick[]> realtimeSubdivisionInfo; // 0xA8
		private bool m_MaxSubdivVisualizedIsMaxAvailable; // 0xB0
		private bool m_LoadMaxCellsPerFrame; // 0xB1
		private const int kMaxCellLoadedPerFrame = 10; // Metadata: 0x006616F4
		private int m_NumberOfCellsLoadedPerFrame; // 0xB4
		private int m_NumberOfCellsBlendedPerFrame; // 0xB8
		private float m_TurnoverRate; // 0xBC
		private DynamicArray<Cell> m_LoadedCells; // 0xC0
		private DynamicArray<Cell> m_ToBeLoadedCells; // 0xC8
		private DynamicArray<Cell> m_WorseLoadedCells; // 0xD0
		private DynamicArray<Cell> m_BestToBeLoadedCells; // 0xD8
		private DynamicArray<Cell> m_TempCellToLoadList; // 0xE0
		private DynamicArray<Cell> m_TempCellToUnloadList; // 0xE8
		private DynamicArray<Cell> m_LoadedBlendingCells; // 0xF0
		private DynamicArray<Cell> m_ToBeLoadedBlendingCells; // 0xF8
		private DynamicArray<Cell> m_TempBlendingCellToLoadList; // 0x100
		private DynamicArray<Cell> m_TempBlendingCellToUnloadList; // 0x108
		private Vector3 m_FrozenCameraPosition; // 0x110
		private Vector3 m_FrozenCameraDirection; // 0x11C
		private const float kIndexFragmentationThreshold = 0.2f; // Metadata: 0x006616F5
		private bool m_IndexDefragmentationInProgress; // 0x128
		private ProbeBrickIndex m_DefragIndex; // 0x130
		private ProbeGlobalIndirection m_DefragCellIndices; // 0x138
		private DynamicArray<Cell> m_IndexDefragCells; // 0x140
		private DynamicArray<Cell> m_TempIndexDefragCells; // 0x148
		internal float minStreamingScore; // 0x150
		internal float maxStreamingScore; // 0x154
		private Queue<CellStreamingRequest> m_StreamingQueue; // 0x158
		private List<CellStreamingRequest> m_ActiveStreamingRequests; // 0x160
		private ObjectPool<CellStreamingRequest> m_StreamingRequestsPool; // 0x168
		private bool m_DiskStreamingUseCompute; // 0x170
		private ProbeVolumeScratchBufferPool m_ScratchBufferPool; // 0x178
		private CellStreamingRequest.OnStreamingCompleteDelegate m_OnStreamingComplete; // 0x180
		private CellStreamingRequest.OnStreamingCompleteDelegate m_OnBlendingStreamingComplete; // 0x188
		[NoAutoStaticsCleanup]
		private static readonly DynamicArray<Cell> s_BlendingComparer; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly DynamicArray<Cell> s_DefragComparer; // 0x18
		private bool m_IsInitialized; // 0x190
		private bool m_SupportScenarios; // 0x191
		private bool m_SupportScenarioBlending; // 0x192
		private bool m_ForceNoDiskStreaming; // 0x193
		private bool m_SupportDiskStreaming; // 0x194
		private bool m_SupportGPUStreaming; // 0x195
		private bool m_UseStreamingAssets; // 0x196
		private float m_MinBrickSize; // 0x198
		private int m_MaxSubdivision; // 0x19C
		private Vector3 m_ProbeOffset; // 0x1A0
		private ProbeBrickPool m_Pool; // 0x1B0
		private ProbeBrickIndex m_Index; // 0x1B8
		private ProbeGlobalIndirection m_CellIndices; // 0x1C0
		private ProbeBrickBlendingPool m_BlendingPool; // 0x1C8
		private List<ProbeBrickPool.BrickChunkAlloc> m_TmpSrcChunks; // 0x1D0
		private float[] m_PositionOffsets; // 0x1D8
		private Bounds m_CurrGlobalBounds; // 0x1E0
		internal Dictionary<int, Cell> cells; // 0x1F8
		private ObjectPool<Cell> m_CellPool; // 0x200
		private ProbeBrickPool.DataLocation m_TemporaryDataLocation; // 0x208
		private int m_TemporaryDataLocationMemCost; // 0x270
		[Obsolete("This field is only kept for migration purpose. #from(2023.3)")]
		internal ProbeVolumeSceneData sceneData; // 0x278
		private Vector3Int minLoadedCellPos; // 0x280
		private Vector3Int maxLoadedCellPos; // 0x28C
		public Action<ExtraDataActionInput> retrieveExtraDataAction; // 0x298
		public Action checksDuringBakeAction; // 0x2A0
		private Dictionary<string, ValueTuple<ProbeVolumeBakingSet, List<int>>> m_PendingScenesToBeLoaded; // 0x2A8
		private Dictionary<string, List<int>> m_PendingScenesToBeUnloaded; // 0x2B0
		private List<string> m_ActiveScenes; // 0x2B8
		private ProbeVolumeBakingSetWeakReference m_CurrentBakingSetReference; // 0x2C0
		private ProbeVolumeBakingSetWeakReference m_LazyBakingSetReference; // 0x2C8
		private bool m_NeedLoadAsset; // 0x2D0
		private bool m_ProbeReferenceVolumeInit; // 0x2D1
		private bool m_EnabledBySRP; // 0x2D2
		private bool m_VertexSampling; // 0x2D3
		private bool m_NeedsIndexRebuild; // 0x2D4
		private bool m_HasChangedIndex; // 0x2D5
		private int m_CBShaderID; // 0x2D8
		private static readonly ProfilerMarker k_InitializeReferenceVolume; // 0x20
		private ProbeVolumeTextureMemoryBudget m_MemoryBudget; // 0x2DC
		private ProbeVolumeBlendingTextureMemoryBudget m_BlendingMemoryBudget; // 0x2E0
		private ProbeVolumeSHBands m_SHBands; // 0x2E4
		internal bool clearAssetsOnVolumeClear; // 0x2E8
		internal static readonly string defaultLightingScenario; // 0x28
		[NoAutoStaticsCleanup]
		private static ProbeReferenceVolume s_Instance; // 0x30
		[CompilerGenerated]
		private List<ProbeVolumePerSceneData> _perSceneDataList_k__BackingField; // 0x2F0
	
		// Properties
		internal ProbeVolumeDebug probeVolumeDebug { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Color[] subdivisionDebugColors { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		private Mesh debugMesh { get; } // 0x0000000181E6EB90-0x0000000181E6ECF0 
		public bool loadMaxCellsPerFrame { get; set; } // 0x000000018172A3C0-0x000000018172A3D0 0x000000018172A4C0-0x000000018172A4D0
		private int numberOfCellsLoadedPerFrame { get; } // 0x0000000181E6EEF0-0x0000000181E6EF30 
		public int numberOfCellsBlendedPerFrame { get; set; } // 0x00000001806342B0-0x00000001806342C0 0x0000000181E6F410-0x0000000181E6F430
		public float turnoverRate { get; set; } // 0x0000000181E6F280-0x0000000181E6F290 0x0000000181E6F500-0x0000000181E6F520
		internal Bounds globalBounds { get; set; } // 0x0000000181E6ED20-0x0000000181E6ED40 0x0000000181E6F2E0-0x0000000181E6F300
		private ProbeVolumeBakingSet m_CurrentBakingSet { get; set; } // 0x0000000181E6EB60-0x0000000181E6EB90 0x0000000181E6F3B0-0x0000000181E6F3E0
		private ProbeVolumeBakingSet m_LazyBakingSet { get; set; } // 0x0000000181E6EEB0-0x0000000181E6EEE0 0x0000000181E6F3E0-0x0000000181E6F410
		public bool isInitialized { get; } // 0x0000000181C0F720-0x0000000181C0F730 
		internal bool enabledBySRP { get; } // 0x0000000181E6ED10-0x0000000181E6ED20 
		internal bool vertexSampling { get; } // 0x0000000181E6F2D0-0x0000000181E6F2E0 
		internal bool hasUnloadedCells { get; } // 0x0000000181E6ED50-0x0000000181E6ED80 
		internal bool supportLightingScenarios { get; } // 0x0000000181C0F7A0-0x0000000181C0F7B0 
		internal bool supportScenarioBlending { get; } // 0x0000000181E6F270-0x0000000181E6F280 
		internal bool gpuStreamingEnabled { get; } // 0x0000000181E6ED40-0x0000000181E6ED50 
		internal bool diskStreamingEnabled { get; } // 0x0000000181E6ECF0-0x0000000181E6ED10 
		public bool probeOcclusion { get; } // 0x0000000181E6EFE0-0x0000000181E6F080 
		public bool skyOcclusion { get; } // 0x0000000181E6F1D0-0x0000000181E6F270 
		public bool skyOcclusionShadingDirection { get; } // 0x0000000181E6F130-0x0000000181E6F1D0 
		private bool useRenderingLayers { get; } // 0x0000000181E6F290-0x0000000181E6F2D0 
		public ProbeVolumeSHBands shBands { get; } // 0x0000000181E6F120-0x0000000181E6F130 
		public ProbeVolumeBakingSet currentBakingSet { get; } // 0x0000000181E6EB60-0x0000000181E6EB90 
		public string lightingScenario { get; set; } // 0x0000000181E6EE10-0x0000000181E6EEB0 0x0000000181E6F300-0x0000000181E6F3B0
		public string otherScenario { get; } // 0x0000000181E6EF30-0x0000000181E6EFD0 
		public float scenarioBlendingFactor { get; set; } // 0x0000000181E6F080-0x0000000181E6F120 0x0000000181E6F430-0x0000000181E6F500
		public ProbeVolumeTextureMemoryBudget memoryBudget { get; } // 0x0000000181E6EEE0-0x0000000181E6EEF0 
		internal List<ProbeVolumePerSceneData> perSceneDataList { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E6EFD0-0x0000000181E6EFE0 0x00000001813802B0-0x00000001813802D0
		internal float indexFragmentationRate { get; } // 0x0000000181E6ED80-0x0000000181E6EDC0 
		public static ProbeReferenceVolume instance { get; } // 0x0000000181E6EDC0-0x0000000181E6EE10 
	
		// Nested types
		internal static class ShaderIDs // TypeDefIndex: 5556
		{
			// Fields
			public static readonly int _APVResIndex; // 0x00
			public static readonly int _APVResCellIndices; // 0x04
			public static readonly int _APVResL0_L1Rx; // 0x08
			public static readonly int _APVResL1G_L1Ry; // 0x0C
			public static readonly int _APVResL1B_L1Rz; // 0x10
			public static readonly int _APVResL2_0; // 0x14
			public static readonly int _APVResL2_1; // 0x18
			public static readonly int _APVResL2_2; // 0x1C
			public static readonly int _APVResL2_3; // 0x20
			public static readonly int _APVProbeOcclusion; // 0x24
			public static readonly int _APVResValidity; // 0x28
			public static readonly int _SkyOcclusionTexL0L1; // 0x2C
			public static readonly int _SkyShadingDirectionIndicesTex; // 0x30
			public static readonly int _SkyPrecomputedDirections; // 0x34
			public static readonly int _AntiLeakData; // 0x38
	
			// Constructors
			static ShaderIDs(); // 0x0000000181E88C80-0x0000000181E88F30
		}
	
		internal class CellInstancedDebugProbes // TypeDefIndex: 5557
		{
			// Fields
			public List<Matrix4x4[]> probeBuffers; // 0x10
			public List<Matrix4x4[]> offsetBuffers; // 0x18
			public List<MaterialPropertyBlock> props; // 0x20
	
			// Constructors
			public CellInstancedDebugProbes(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class RenderFragmentationOverlayPassData // TypeDefIndex: 5558
		{
			// Fields
			public Material debugFragmentationMaterial; // 0x10
			public DebugOverlay debugOverlay; // 0x18
			public int chunkCount; // 0x20
			public ComputeBuffer debugFragmentationData; // 0x28
			public TextureHandle colorBuffer; // 0x30
			public TextureHandle depthBuffer; // 0x40
	
			// Constructors
			public RenderFragmentationOverlayPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal class DiskStreamingRequest // TypeDefIndex: 5559
		{
			// Fields
			private ReadHandle m_ReadHandle; // 0x10
			private ReadCommandArray m_ReadCommandArray; // 0x20
			private NativeArray<ReadCommand> m_ReadCommandBuffer; // 0x30
			private int m_BytesWritten; // 0x40
	
			// Constructors
			public DiskStreamingRequest(int maxRequestCount); // 0x0000000181E77810-0x0000000181E77870
	
			// Methods
			public unsafe void AddReadCommand(int offset, int size, byte* dest); // 0x0000000181E77620-0x0000000181E77680
			public int RunCommands(FileHandle file); // 0x0000000181E77780-0x0000000181E777C0
			public void Clear(); // 0x0000000181E776B0-0x0000000181E77710
			public void Cancel(); // 0x0000000181E77680-0x0000000181E776B0
			public void Wait(); // 0x0000000181E777C0-0x0000000181E77810
			public void Dispose(); // 0x0000000181E77710-0x0000000181E77750
			public ReadStatus GetStatus(); // 0x0000000181E77750-0x0000000181E77780
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\Lighting\\ProbeVolume\\ProbeReferenceVolume.Streaming.cs", needAccessors = false, generateCBuffer = true)]
		internal struct CellStreamingScratchBufferLayout // TypeDefIndex: 5560
		{
			// Fields
			public int _SharedDestChunksOffset; // 0x00
			public int _L0L1rxOffset; // 0x04
			public int _L1GryOffset; // 0x08
			public int _L1BrzOffset; // 0x0C
			public int _ValidityOffset; // 0x10
			public int _ProbeOcclusionOffset; // 0x14
			public int _SkyOcclusionOffset; // 0x18
			public int _SkyShadingDirectionOffset; // 0x1C
			public int _L2_0Offset; // 0x20
			public int _L2_1Offset; // 0x24
			public int _L2_2Offset; // 0x28
			public int _L2_3Offset; // 0x2C
			public int _L0Size; // 0x30
			public int _L0ProbeSize; // 0x34
			public int _L1Size; // 0x38
			public int _L1ProbeSize; // 0x3C
			public int _ValiditySize; // 0x40
			public int _ValidityProbeSize; // 0x44
			public int _ProbeOcclusionSize; // 0x48
			public int _ProbeOcclusionProbeSize; // 0x4C
			public int _SkyOcclusionSize; // 0x50
			public int _SkyOcclusionProbeSize; // 0x54
			public int _SkyShadingDirectionSize; // 0x58
			public int _SkyShadingDirectionProbeSize; // 0x5C
			public int _L2Size; // 0x60
			public int _L2ProbeSize; // 0x64
			public int _ProbeCountInChunkLine; // 0x68
			public int _ProbeCountInChunkSlice; // 0x6C
		}
	
		internal struct BufferLayoutBuilder // TypeDefIndex: 5561
		{
			// Fields
			private int _Offset; // 0x00
	
			// Constructors
			public BufferLayoutBuilder(int initialOffset = 0 /* Metadata: 0x006616F9 */); // 0x0000000180732D50-0x0000000180732D60
	
			// Methods
			public int AddBlock(int blockSize); // 0x0000000181E755E0-0x0000000181E755F0
		}
	
		internal class CellStreamingScratchBuffer // TypeDefIndex: 5562
		{
			// Fields
			public NativeArray<byte> stagingBuffer; // 0x10
			[CompilerGenerated]
			private readonly int _chunkCount_k__BackingField; // 0x20
			[CompilerGenerated]
			private readonly int _chunkSize_k__BackingField; // 0x24
			private int m_CurrentBuffer; // 0x28
			private GraphicsBuffer[] m_GraphicsBuffers; // 0x30
	
			// Properties
			public GraphicsBuffer buffer { get; } // 0x0000000181E77170-0x0000000181E771A0 
			public int chunkCount { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
			public int chunkSize { [CompilerGenerated] get; } // 0x0000000180D17D10-0x0000000180D17D20 
	
			// Constructors
			public CellStreamingScratchBuffer(int chunkCount, int chunkSize, bool allocateGraphicsBuffers); // 0x0000000181E76FF0-0x0000000181E77170
	
			// Methods
			public void Swap(); // 0x0000000181E76FD0-0x0000000181E76FF0
			public void Dispose(); // 0x0000000181E76F40-0x0000000181E76FD0
		}
	
		[DebuggerDisplay("Index = {cell.desc.index} State = {state}")]
		internal class CellStreamingRequest // TypeDefIndex: 5563
		{
			// Fields
			[CompilerGenerated]
			private Cell _cell_k__BackingField; // 0x10
			[CompilerGenerated]
			private State _state_k__BackingField; // 0x18
			[CompilerGenerated]
			private CellStreamingScratchBuffer _scratchBuffer_k__BackingField; // 0x20
			[CompilerGenerated]
			private CellStreamingScratchBufferLayout _scratchBufferLayout_k__BackingField; // 0x28
			[CompilerGenerated]
			private ProbeVolumeBakingSet.PerScenarioDataInfo _scenarioData_k__BackingField; // 0x98
			[CompilerGenerated]
			private int _poolIndex_k__BackingField; // 0xA0
			[CompilerGenerated]
			private bool _streamSharedData_k__BackingField; // 0xA4
			public OnStreamingCompleteDelegate onStreamingComplete; // 0xA8
			public DiskStreamingRequest cellDataStreamingRequest; // 0xB0
			public DiskStreamingRequest cellOptionalDataStreamingRequest; // 0xB8
			public DiskStreamingRequest cellSharedDataStreamingRequest; // 0xC0
			public DiskStreamingRequest cellProbeOcclusionDataStreamingRequest; // 0xC8
			public DiskStreamingRequest brickStreamingRequest; // 0xD0
			public DiskStreamingRequest supportStreamingRequest; // 0xD8
			public int bytesWritten; // 0xE0
	
			// Properties
			public Cell cell { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public State state { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
			public CellStreamingScratchBuffer scratchBuffer { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public CellStreamingScratchBufferLayout scratchBufferLayout { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E76EA0-0x0000000181E76EE0 0x0000000181E76EF0-0x0000000181E76F30
			public ProbeVolumeBakingSet.PerScenarioDataInfo scenarioData { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
			public int poolIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D1F0-0x000000018033D200 0x000000018033E7D0-0x000000018033E7E0
			public bool streamSharedData { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E76EE0-0x0000000181E76EF0 0x0000000181E76F30-0x0000000181E76F40
	
			// Nested types
			public enum State // TypeDefIndex: 5564
			{
				Pending = 0,
				Active = 1,
				Canceled = 2,
				Invalid = 3,
				Complete = 4
			}
	
			public delegate void OnStreamingCompleteDelegate(CellStreamingRequest request, CommandBuffer cmd); // TypeDefIndex: 5565; 0x0000000180A70FB0-0x0000000180A70FC0
	
			// Constructors
			public CellStreamingRequest(); // 0x0000000181E76C20-0x0000000181E76EA0
	
			// Methods
			public bool IsStreaming(); // 0x0000000181E76440-0x0000000181E76460
			public void Cancel(); // 0x0000000181E76170-0x0000000181E76290
			public void WaitAll(); // 0x0000000181E76A30-0x0000000181E76C20
			public bool UpdateRequestState(DiskStreamingRequest request, ref bool isComplete); // 0x0000000181E766A0-0x0000000181E76700
			public void UpdateState(); // 0x0000000181E76700-0x0000000181E76A30
			public void Clear(); // 0x0000000181E76290-0x0000000181E762C0
			public void Reset(); // 0x0000000181E76460-0x0000000181E766A0
			public void Dispose(); // 0x0000000181E762C0-0x0000000181E76440
		}
	
		[Serializable]
		internal struct IndirectionEntryInfo // TypeDefIndex: 5566
		{
			// Fields
			public Vector3Int positionInBricks; // 0x00
			public int minSubdiv; // 0x0C
			public Vector3Int minBrickPos; // 0x10
			public Vector3Int maxBrickPosPlusOne; // 0x1C
			public bool hasMinMax; // 0x28
			public bool hasOnlyBiggerBricks; // 0x29
		}
	
		[Serializable]
		internal class CellDesc // TypeDefIndex: 5567
		{
			// Fields
			public Vector3Int position; // 0x10
			public int index; // 0x1C
			public int probeCount; // 0x20
			public int minSubdiv; // 0x24
			public int indexChunkCount; // 0x28
			public int shChunkCount; // 0x2C
			public int bricksCount; // 0x30
			public IndirectionEntryInfo[] indirectionEntryInfo; // 0x38
	
			// Constructors
			public CellDesc(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override string ToString(); // 0x0000000181E75F70-0x0000000181E76000
		}
	
		internal class CellData // TypeDefIndex: 5568
		{
			// Fields
			public NativeArray<byte> validityNeighMaskData; // 0x10
			[CompilerGenerated]
			private NativeArray<ushort> _skyOcclusionDataL0L1_k__BackingField; // 0x20
			[CompilerGenerated]
			private NativeArray<byte> _skyShadingDirectionIndices_k__BackingField; // 0x30
			public Dictionary<string, PerScenarioData> scenarios; // 0x40
			[CompilerGenerated]
			private NativeArray<ProbeBrickIndex.Brick> _bricks_k__BackingField; // 0x48
			[CompilerGenerated]
			private NativeArray<Vector3> _probePositions_k__BackingField; // 0x58
			[CompilerGenerated]
			private NativeArray<float> _touchupVolumeInteraction_k__BackingField; // 0x68
			[CompilerGenerated]
			private NativeArray<Vector3> _offsetVectors_k__BackingField; // 0x78
			[CompilerGenerated]
			private NativeArray<float> _validity_k__BackingField; // 0x88
			[CompilerGenerated]
			private NativeArray<byte> _layer_k__BackingField; // 0x98
	
			// Properties
			public NativeArray<ushort> skyOcclusionDataL0L1 { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180D91A40-0x0000000180D91A50 0x0000000181424780-0x0000000181424790
			public NativeArray<byte> skyShadingDirectionIndices { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181E304D0-0x0000000181E304E0 0x0000000181E305E0-0x0000000181E305F0
			public NativeArray<ProbeBrickIndex.Brick> bricks { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001817273C0-0x00000001817273D0 0x0000000181727450-0x0000000181727460
			public NativeArray<Vector3> probePositions { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181B2AD40-0x0000000181B2AD50 0x0000000181E75F40-0x0000000181E75F50
			public NativeArray<float> touchupVolumeInteraction { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181D97A10-0x0000000181D97A20 0x0000000181E75F50-0x0000000181E75F60
			public NativeArray<Vector3> offsetVectors { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181C4BDC0-0x0000000181C4BDD0 0x0000000181E75F30-0x0000000181E75F40
			public NativeArray<float> validity { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181C2D2F0-0x0000000181C2D300 0x0000000181E75F60-0x0000000181E75F70
			public NativeArray<byte> layer { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181E75F10-0x0000000181E75F20 0x0000000181E75F20-0x0000000181E75F30
	
			// Nested types
			public struct PerScenarioData // TypeDefIndex: 5569
			{
				// Fields
				public NativeArray<ushort> shL0L1RxData; // 0x00
				public NativeArray<byte> shL1GL1RyData; // 0x10
				public NativeArray<byte> shL1BL1RzData; // 0x20
				public NativeArray<byte> shL2Data_0; // 0x30
				public NativeArray<byte> shL2Data_1; // 0x40
				public NativeArray<byte> shL2Data_2; // 0x50
				public NativeArray<byte> shL2Data_3; // 0x60
				public NativeArray<byte> probeOcclusion; // 0x70
			}
	
			// Constructors
			public CellData(); // 0x0000000181E75E90-0x0000000181E75F10
	
			// Methods
			public void CleanupPerScenarioData([IsReadOnly] in PerScenarioData data); // 0x0000000181E75740-0x0000000181E75880
			public void Cleanup(bool cleanScenarioList); // 0x0000000181E75880-0x0000000181E75E90
		}
	
		internal class CellPoolInfo // TypeDefIndex: 5570
		{
			// Fields
			public List<ProbeBrickPool.BrickChunkAlloc> chunkList; // 0x10
			public int shChunkCount; // 0x18
	
			// Constructors
			public CellPoolInfo(); // 0x0000000181E76040-0x0000000181E760C0
	
			// Methods
			public void Clear(); // 0x0000000181E49C80-0x0000000181E49CB0
		}
	
		internal class CellIndexInfo // TypeDefIndex: 5571
		{
			// Fields
			public int[] flatIndicesInGlobalIndirection; // 0x10
			public ProbeBrickIndex.CellIndexUpdateInfo updateInfo; // 0x18
			public bool indexUpdated; // 0x20
			public IndirectionEntryInfo[] indirectionEntryInfo; // 0x28
			public int indexChunkCount; // 0x30
	
			// Constructors
			public CellIndexInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Clear(); // 0x0000000181E76000-0x0000000181E76040
		}
	
		internal class CellBlendingInfo // TypeDefIndex: 5572
		{
			// Fields
			public List<ProbeBrickPool.BrickChunkAlloc> chunkList; // 0x10
			public float blendingScore; // 0x18
			public float blendingFactor; // 0x1C
			public bool blending; // 0x20
	
			// Constructors
			public CellBlendingInfo(); // 0x0000000181E756B0-0x0000000181E75730
	
			// Methods
			public void MarkUpToDate(); // 0x0000000181E75650-0x0000000181E75660
			public bool IsUpToDate(); // 0x0000000181E75630-0x0000000181E75650
			public void ForceReupload(); // 0x0000000181E75620-0x0000000181E75630
			public bool ShouldReupload(); // 0x0000000181E75690-0x0000000181E756B0
			public void Prioritize(); // 0x0000000181E75660-0x0000000181E75670
			public bool ShouldPrioritize(); // 0x0000000181E75670-0x0000000181E75690
			public void Clear(); // 0x0000000181E755F0-0x0000000181E75620
		}
	
		internal class CellStreamingInfo // TypeDefIndex: 5573
		{
			// Fields
			public CellStreamingRequest request; // 0x10
			public CellStreamingRequest blendingRequest0; // 0x18
			public CellStreamingRequest blendingRequest1; // 0x20
			public float streamingScore; // 0x28
	
			// Constructors
			public CellStreamingInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool IsStreaming(); // 0x0000000181E76150-0x0000000181E76170
			public bool IsBlendingStreaming(); // 0x0000000181E76110-0x0000000181E76150
			public void Clear(); // 0x0000000181E760C0-0x0000000181E76110
		}
	
		[DebuggerDisplay("Index = {desc.index} Loaded = {loaded}")]
		internal class Cell : IComparable<Cell> // TypeDefIndex: 5574
		{
			// Fields
			public CellDesc desc; // 0x10
			public CellData data; // 0x18
			public CellPoolInfo poolInfo; // 0x20
			public CellIndexInfo indexInfo; // 0x28
			public CellBlendingInfo blendingInfo; // 0x30
			public CellStreamingInfo streamingInfo; // 0x38
			public int referenceCount; // 0x40
			public bool loaded; // 0x44
			public CellData.PerScenarioData scenario0; // 0x48
			public CellData.PerScenarioData scenario1; // 0xC8
			public bool hasTwoScenarios; // 0x148
			public CellInstancedDebugProbes debugProbes; // 0x150
	
			// Constructors
			public Cell(); // 0x0000000181E77460-0x0000000181E77620
	
			// Methods
			public int CompareTo(Cell other); // 0x0000000181E77330-0x0000000181E77380
			public bool UpdateCellScenarioData(string scenario0, string scenario1); // 0x0000000181E77380-0x0000000181E77460
			public void Clear(); // 0x0000000181E771A0-0x0000000181E77330
		}
	
		internal struct Volume : IEquatable<Volume> // TypeDefIndex: 5575
		{
			// Fields
			internal Vector3 corner; // 0x00
			internal Vector3 X; // 0x0C
			internal Vector3 Y; // 0x18
			internal Vector3 Z; // 0x24
			internal float maxSubdivisionMultiplier; // 0x30
			internal float minSubdivisionMultiplier; // 0x34
	
			// Constructors
			public Volume(Matrix4x4 trs, float maxSubdivision, float minSubdivision); // 0x0000000181E8B130-0x0000000181E8B280
			public Volume(Vector3 corner, Vector3 X, Vector3 Y, Vector3 Z, float maxSubdivision = 1f /* Metadata: 0x006616FF */, float minSubdivision = 0f /* Metadata: 0x00661703 */); // 0x0000000181E8B080-0x0000000181E8B0E0
			public Volume(Volume copy); // 0x0000000181E8B0E0-0x0000000181E8B130
			public Volume(Bounds bounds); // 0x0000000181E8B280-0x0000000181E8B6C0
	
			// Methods
			public Bounds CalculateAABB(); // 0x0000000181E8A620-0x0000000181E8A8D0
			public void CalculateCenterAndSize(out Vector3 center, out Vector3 size); // 0x0000000181E8A8D0-0x0000000181E8A9F0
			public void Transform(Matrix4x4 trs); // 0x0000000181E8AE10-0x0000000181E8B080
			public override string ToString(); // 0x0000000181E8AB60-0x0000000181E8AE10
			public bool Equals(Volume other); // 0x0000000181E8A9F0-0x0000000181E8AB60
		}
	
		internal struct RefVolTransform // TypeDefIndex: 5576
		{
			// Fields
			public Vector3 posWS; // 0x00
			public Quaternion rot; // 0x0C
			public float scale; // 0x1C
		}
	
		public struct RuntimeResources // TypeDefIndex: 5577
		{
			// Fields
			public ComputeBuffer index; // 0x00
			public ComputeBuffer cellIndices; // 0x08
			public RenderTexture L0_L1rx; // 0x10
			public RenderTexture L1_G_ry; // 0x18
			public RenderTexture L1_B_rz; // 0x20
			public RenderTexture L2_0; // 0x28
			public RenderTexture L2_1; // 0x30
			public RenderTexture L2_2; // 0x38
			public RenderTexture L2_3; // 0x40
			public RenderTexture ProbeOcclusion; // 0x48
			public RenderTexture Validity; // 0x50
			public RenderTexture SkyOcclusionL0L1; // 0x58
			public RenderTexture SkyShadingDirectionIndices; // 0x60
			public ComputeBuffer SkyPrecomputedDirections; // 0x68
			public ComputeBuffer QualityLeakReductionData; // 0x70
		}
	
		public struct ExtraDataActionInput // TypeDefIndex: 5578
		{
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5579
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<RenderFragmentationOverlayPassData, UnsafeGraphContext> __9__40_0; // 0x08
			public static Func<CellStreamingRequest> __9__99_0; // 0x10
			public static Action<CellStreamingRequest> __9__99_1; // 0x18
			public static Func<CellStreamingRequest> __9__287_0; // 0x20
			public static Action<CellStreamingRequest> __9__287_1; // 0x28
			public static Func<Cell> __9__287_2; // 0x30
			public static Action<Cell> __9__287_3; // 0x38
	
			// Constructors
			static __c(); // 0x0000000181E8A4D0-0x0000000181E8A540
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RenderFragmentationOverlay_b__40_0(RenderFragmentationOverlayPassData data, UnsafeGraphContext ctx); // 0x0000000181E8A0C0-0x0000000181E8A270
			internal CellStreamingRequest _CleanupStreaming_b__99_0(); // 0x0000000181E89FE0-0x0000000181E8A030
			internal void _CleanupStreaming_b__99_1(CellStreamingRequest val); // 0x0000000181E8A030-0x0000000181E8A070
			internal CellStreamingRequest _.ctor_b__287_0(); // 0x0000000181E8A270-0x0000000181E8A2C0
			internal void _.ctor_b__287_1(CellStreamingRequest val); // 0x0000000181E8A030-0x0000000181E8A070
			internal Cell _.ctor_b__287_2(); // 0x0000000181E8A2C0-0x0000000181E8A4B0
			internal void _.ctor_b__287_3(Cell x); // 0x0000000181E8A4B0-0x0000000181E8A4D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass130_0 // TypeDefIndex: 5580
		{
			// Fields
			public Cell cell; // 0x10
	
			// Constructors
			public __c__DisplayClass130_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _HasActiveStreamingRequest_b__0(CellStreamingRequest x); // 0x0000000181C83CD0-0x0000000181C83CF0
		}
	
		// Constructors
		private ProbeReferenceVolume(); // 0x0000000181E6E090-0x0000000181E6EB60
		static ProbeReferenceVolume(); // 0x0000000181E6DE40-0x0000000181E6E090
	
		// Methods
		public void BindAPVRuntimeResources(CommandBuffer cmdBuffer, bool isProbeVolumeEnabled); // 0x0000000181E5CCB0-0x0000000181E5D890
		public bool UpdateShaderVariablesProbeVolumes(CommandBuffer cmd, ProbeVolumesOptions probeVolumeOptions, int taaFrameIndex, bool supportRenderingLayers = false /* Metadata: 0x006616EF */); // 0x0000000181E6D490-0x0000000181E6D840
		[Obsolete("Use the other override to support sampling offset in debug modes. #from(6000.0)")]
		public void RenderDebug(Camera camera, Texture exposureTexture); // 0x00000001802E76C0-0x00000001802E76D0
		public void RenderDebug(Camera camera, ProbeVolumesOptions options, Texture exposureTexture); // 0x00000001802E76C0-0x00000001802E76D0
		public bool IsProbeSamplingDebugEnabled(); // 0x0000000181E64540-0x0000000181E645B0
		public bool GetProbeSamplingDebugResources(Camera camera, out GraphicsBuffer resultBuffer, out Vector2 coords); // 0x0000000181E62C60-0x0000000181E62D80
		public void RenderFragmentationOverlay(RenderGraph renderGraph, TextureHandle colorBuffer, TextureHandle depthBuffer, DebugOverlay debugOverlay); // 0x0000000181E67510-0x0000000181E67A20
		internal void ResetDebugViewToMaxSubdiv(); // 0x0000000181E67AD0-0x0000000181E67B00
		private void ClearDebugData(); // 0x0000000181E5DEC0-0x0000000181E5DEF0
		private static void DecompressSH(ref SphericalHarmonicsL2 shv); // 0x0000000181E60560-0x0000000181E607E0
		internal static Vector3 DecodeSkyShadingDirection(uint directionIndex); // 0x0000000181E60470-0x0000000181E60560
		internal bool GetFlattenedProbeData(string scenario, out Vector3[] positions, out SphericalHarmonicsL2[] irradiance, out float[] validity, out Vector4[] occlusion, out Vector4[] skyOcclusion, out Vector3[] skyOcclusionDirections, out Vector3[] virtualOffset); // 0x0000000181E61190-0x0000000181E62AC0
		private CellInstancedDebugProbes CreateInstancedProbes(Cell cell); // 0x0000000181E5F5B0-0x0000000181E60440
		private void OnClearLightingdata(); // 0x0000000181E5DEC0-0x0000000181E5DEF0
		public void EnableMaxCellStreaming(bool value); // 0x000000018172A4C0-0x000000018172A4D0
		public void SetNumberOfCellsLoadedPerFrame(int numberOfCells); // 0x0000000181E682D0-0x0000000181E682F0
		private void InitStreaming(); // 0x0000000181E63B90-0x0000000181E63C50
		private void CleanupStreaming(); // 0x0000000181E5DAC0-0x0000000181E5DDB0
		internal void ScenarioBlendingChanged(bool scenarioChanged); // 0x0000000181E67B00-0x0000000181E67B80
		private static void ComputeCellStreamingScore(Cell cell, Vector3 cameraPosition, Vector3 cameraDirection); // 0x0000000181E5E7C0-0x0000000181E5EA20
		private void ComputeStreamingScore(Vector3 cameraPosition, Vector3 cameraDirection, DynamicArray<Cell> cells); // 0x0000000181E5F4D0-0x0000000181E5F5B0
		private void ComputeBestToBeLoadedCells(Vector3 cameraPosition, Vector3 cameraDirection); // 0x0000000181E5E010-0x0000000181E5E3D0
		private void ComputeStreamingScoreAndWorseLoadedCells(Vector3 cameraPosition, Vector3 cameraDirection); // 0x0000000181E5F110-0x0000000181E5F4D0
		private void ComputeBlendingScore(DynamicArray<Cell> cells, float worstScore); // 0x0000000181E5E3D0-0x0000000181E5E480
		private bool TryLoadCell(Cell cell, ref int shBudget, ref int indexBudget, DynamicArray<Cell> loadedCells); // 0x0000000181E687C0-0x0000000181E688B0
		private void UnloadBlendingCell(Cell cell, DynamicArray<Cell> unloadedCells); // 0x0000000181E68FD0-0x0000000181E69040
		private bool TryLoadBlendingCell(Cell cell, DynamicArray<Cell> loadedCells); // 0x0000000181E686E0-0x0000000181E687C0
		private void ComputeMinMaxStreamingScore(); // 0x0000000181E5EFA0-0x0000000181E5F110
		public void UpdateCellStreaming(CommandBuffer cmd, Camera camera); // 0x0000000181E69F00-0x0000000181E69F20
		public void UpdateCellStreaming(CommandBuffer cmd, Camera camera, ProbeVolumesOptions options); // 0x0000000181E69F20-0x0000000181E6B120
		private int FindWorstBlendingCellToBeLoaded(); // 0x0000000181E60E50-0x0000000181E60F90
		private static int BlendingComparer(Cell a, Cell b); // 0x0000000181E5D950-0x0000000181E5D9B0
		private void UpdateBlendingCellStreaming(CommandBuffer cmd); // 0x0000000181E69600-0x0000000181E69DD0
		private static int DefragComparer(Cell a, Cell b); // 0x0000000181E607E0-0x0000000181E60980
		private void StartIndexDefragmentation(); // 0x0000000181E683F0-0x0000000181E684F0
		private void UpdateIndexDefragmentation(); // 0x0000000181E6BBF0-0x0000000181E6C0C0
		private void OnStreamingComplete(CellStreamingRequest request, CommandBuffer cmd); // 0x0000000181E651C0-0x0000000181E652B0
		private void OnBlendingStreamingComplete(CellStreamingRequest request, CommandBuffer cmd); // 0x0000000181E65060-0x0000000181E651C0
		private void PushDiskStreamingRequest(Cell cell, string scenario, int poolIndex, CellStreamingRequest.OnStreamingCompleteDelegate onStreamingComplete); // 0x0000000181E668A0-0x0000000181E66A50
		private void CancelStreamingRequest(Cell cell); // 0x0000000181E5DA20-0x0000000181E5DAA0
		private void CancelBlendingStreamingRequest(Cell cell); // 0x0000000181E5D9C0-0x0000000181E5DA20
		private bool ProcessDiskStreamingRequest(CellStreamingRequest request); // 0x0000000181E65850-0x0000000181E66700
		private void AllocateScratchBufferPoolIfNeeded(); // 0x0000000181E5CB60-0x0000000181E5CCB0
		private void UpdateActiveRequests(CommandBuffer cmd); // 0x0000000181E69330-0x0000000181E69600
		private void ProcessNewRequests(); // 0x0000000181E66700-0x0000000181E667E0
		private void UpdateDiskStreaming(CommandBuffer cmd); // 0x0000000181E6B5E0-0x0000000181E6BBF0
		private bool HasActiveStreamingRequest(Cell cell); // 0x0000000181E63360-0x0000000181E63460
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void LogStreaming(string log); // 0x0000000181E64FB0-0x0000000181E65000
		internal static string GetSceneGUID(Scene scene); // 0x0000000181E630E0-0x0000000181E63130
		internal void SetActiveScenario(string scenario, bool verbose = true /* Metadata: 0x006616F0 */); // 0x0000000181E67E40-0x0000000181E67F00
		public void BlendLightingScenario(string otherScenario, float blendingFactor); // 0x0000000181E5D890-0x0000000181E5D950
		internal void RegisterPerSceneData(ProbeVolumePerSceneData data); // 0x0000000181E66AF0-0x0000000181E66BE0
		internal bool ScheduleBakingSet(ProbeVolumeBakingSet bakingSet); // 0x0000000181E67B80-0x0000000181E67BC0
		internal bool ProcessScheduledBakingSet(); // 0x0000000181E667E0-0x0000000181E668A0
		public void SetActiveScene(Scene scene); // 0x0000000181E67F00-0x0000000181E67FD0
		public void SetActiveBakingSet(ProbeVolumeBakingSet bakingSet); // 0x0000000181E67BC0-0x0000000181E67E40
		private void SetBakingSetAsCurrent(ProbeVolumeBakingSet bakingSet); // 0x0000000181E67FD0-0x0000000181E68200
		internal void RegisterBakingSet(ProbeVolumePerSceneData data); // 0x0000000181E66A50-0x0000000181E66AF0
		internal void UnloadBakingSet(); // 0x0000000181E68D90-0x0000000181E68ED0
		internal void UnregisterPerSceneData(ProbeVolumePerSceneData data); // 0x0000000181E692B0-0x0000000181E69330
		internal bool TryGetPerSceneData(string sceneGUID, out ProbeVolumePerSceneData perSceneData); // 0x0000000181E684F0-0x0000000181E686E0
		public void Initialize([IsReadOnly] in ProbeVolumeSystemParameters parameters); // 0x0000000181E63F20-0x0000000181E64540
		public void SetEnableStateFromSRP(bool srpEnablesPV); // 0x0000000181E68200-0x0000000181E68210
		public void SetVertexSamplingEnabled(bool value); // 0x0000000181E683E0-0x0000000181E683F0
		internal void ForceMemoryBudget(ProbeVolumeTextureMemoryBudget budget); // 0x0000000181E60F90-0x0000000181E60FA0
		internal void ForceSHBand(ProbeVolumeSHBands shBands); // 0x0000000181E60FB0-0x0000000181E61110
		internal void ForceNoDiskStreaming(bool state); // 0x0000000181E60FA0-0x0000000181E60FB0
		public void Cleanup(); // 0x0000000181E5DDB0-0x0000000181E5DEC0
		public int GetVideoMemoryCost(); // 0x0000000181E632D0-0x0000000181E63360
		private void RemoveCell(int cellIndex); // 0x0000000181E66D30-0x0000000181E67390
		internal void UnloadCell(Cell cell); // 0x0000000181E69040-0x0000000181E692B0
		internal void UnloadBlendingCell(Cell cell); // 0x0000000181E68ED0-0x0000000181E68FD0
		internal void UnloadAllCells(); // 0x0000000181E68A80-0x0000000181E68D90
		internal void UnloadAllBlendingCells(); // 0x0000000181E688B0-0x0000000181E68A80
		private void AddCell(int cellIndex); // 0x0000000181E5C2E0-0x0000000181E5C5D0
		internal bool LoadCell(Cell cell, bool ignoreErrorLog = false /* Metadata: 0x006616F1 */); // 0x0000000181E64700-0x0000000181E64F00
		internal void LoadAllCells(); // 0x0000000181E645B0-0x0000000181E64700
		private void ComputeCellGlobalInfo(); // 0x0000000181E5E480-0x0000000181E5E7C0
		internal void AddPendingSceneLoading(string sceneGUID, ProbeVolumeBakingSet bakingSet); // 0x0000000181E5C5D0-0x0000000181E5C9F0
		internal void AddPendingSceneRemoval(string sceneGUID); // 0x0000000181E5C9F0-0x0000000181E5CB60
		internal void RemovePendingScene(string sceneGUID, List<int> cellList); // 0x0000000181E67390-0x0000000181E67510
		private void PerformPendingIndexChangeAndInit(); // 0x0000000181E653C0-0x0000000181E65400
		internal void SetSubdivisionDimensions(float minBrickSize, int maxSubdiv, Vector3 offset); // 0x0000000181E682F0-0x0000000181E683E0
		private bool LoadCells(List<int> cellIndices); // 0x0000000181E64F00-0x0000000181E64FB0
		private void PerformPendingLoading(); // 0x0000000181E65400-0x0000000181E657E0
		private void PerformPendingDeletion(); // 0x0000000181E652B0-0x0000000181E653C0
		internal void ComputeEntryMinMax(ref IndirectionEntryInfo entryInfo, ReadOnlySpan<ProbeBrickIndex.Brick> bricks); // 0x0000000181E5EA20-0x0000000181E5EFA0
		internal static int GetNumberOfBricksAtSubdiv(IndirectionEntryInfo entryInfo); // 0x0000000181E62B40-0x0000000181E62C60
		public void PerformPendingOperations(); // 0x0000000181E657E0-0x0000000181E65830
		internal void InitializeGlobalIndirection(); // 0x0000000181E63C50-0x0000000181E63F20
		private void InitProbeReferenceVolume(); // 0x0000000181E63460-0x0000000181E63B90
		public RuntimeResources GetRuntimeResources(); // 0x0000000181E62D80-0x0000000181E630E0
		internal void SetMaxSubdivision(int maxSubdivision); // 0x0000000181E68210-0x0000000181E682D0
		internal static int CellSize(int subdivisionLevel); // 0x0000000181E5DAA0-0x0000000181E5DAB0
		internal float BrickSize(int subdivisionLevel); // 0x0000000181E5D9B0-0x0000000181E5D9C0
		internal float MinBrickSize(); // 0x0000000181E65020-0x0000000181E65030
		internal float MaxBrickSize(); // 0x0000000181E65000-0x0000000181E65020
		internal Vector3 ProbeOffset(); // 0x0000000181E65830-0x0000000181E65850
		internal int GetMaxSubdivision(); // 0x0000000181E62B30-0x0000000181E62B40
		internal int GetMaxSubdivision(float multiplier); // 0x0000000181E62AC0-0x0000000181E62B30
		internal float GetDistanceBetweenProbes(int subdivisionLevel); // 0x0000000181E61110-0x0000000181E61140
		internal float MinDistanceBetweenProbes(); // 0x0000000181E65030-0x0000000181E65060
		internal int GetGlobalIndirectionEntryMaxSubdiv(); // 0x000000018071E4A0-0x000000018071E4B0
		internal int GetEntrySubdivLevel(); // 0x0000000181E61170-0x0000000181E61190
		internal float GetEntrySize(); // 0x0000000181E61140-0x0000000181E61170
		public bool DataHasBeenLoaded(); // 0x0000000181E60440-0x0000000181E60470
		internal void Clear(); // 0x0000000181E5DEF0-0x0000000181E5E010
		private List<ProbeBrickPool.BrickChunkAlloc> GetSourceLocations(int count, int chunkSize, ProbeBrickPool.DataLocation dataLoc); // 0x0000000181E63130-0x0000000181E632D0
		private void UpdateDataLocationTexture<T>(Texture output, NativeArray<T> input)
			where T : struct;
		private void UpdateValidityTextureWithoutMask(Texture output, NativeArray<byte> input); // 0x0000000181E6DCA0-0x0000000181E6DE40
		private void UpdatePool(List<ProbeBrickPool.BrickChunkAlloc> chunkList, CellData.PerScenarioData data, NativeArray<byte> validityNeighMaskData, NativeArray<ushort> skyOcclusionL0L1Data, NativeArray<byte> skyShadingDirectionIndices, int chunkIndex, int poolIndex); // 0x0000000181E6CEC0-0x0000000181E6D490
		private void UpdatePool(CommandBuffer cmd, List<ProbeBrickPool.BrickChunkAlloc> chunkList, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, int poolIndex); // 0x0000000181E6CBC0-0x0000000181E6CEC0
		private void UpdateSharedData(List<ProbeBrickPool.BrickChunkAlloc> chunkList, NativeArray<byte> validityNeighMaskData, NativeArray<ushort> skyOcclusionData, NativeArray<byte> skyShadingDirectionIndices, int chunkIndex); // 0x0000000181E6D840-0x0000000181E6DCA0
		private bool AddBlendingBricks(Cell cell); // 0x0000000181E5B6C0-0x0000000181E5BFE0
		private bool ReservePoolChunks(int brickCount, List<ProbeBrickPool.BrickChunkAlloc> chunkList, bool ignoreErrorLog); // 0x0000000181E67A20-0x0000000181E67AD0
		private void ReleasePoolChunks(List<ProbeBrickPool.BrickChunkAlloc> chunkList); // 0x0000000181E66CF0-0x0000000181E66D30
		private void UpdatePoolAndIndex(Cell cell, CellStreamingScratchBuffer dataBuffer, CellStreamingScratchBufferLayout layout, int poolIndex, CommandBuffer cmd); // 0x0000000181E6C0C0-0x0000000181E6CBC0
		private bool AddBricks(Cell cell); // 0x0000000181E5BFE0-0x0000000181E5C2E0
		private void UpdateCellIndex(Cell cell); // 0x0000000181E69DD0-0x0000000181E69F00
		private void ReleaseBricks(Cell cell); // 0x0000000181E66BE0-0x0000000181E66CF0
		internal void UpdateConstantBuffer(CommandBuffer cmd, ProbeVolumeShadingParameters parameters); // 0x0000000181E6B120-0x0000000181E6B5E0
		private void DeinitProbeReferenceVolume(); // 0x0000000181E60980-0x0000000181E60E50
		private void CleanupLoadedData(); // 0x0000000181E5DAB0-0x0000000181E5DAC0
	}
}
