/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class ProbeVolumeBakingSet : ScriptableObject, ISerializationCallbackReceiver // TypeDefIndex: 5601
	{
		// Fields
		[SerializeField]
		internal bool singleSceneMode; // 0x18
		[SerializeField]
		internal bool dialogNoProbeVolumeInSetShown; // 0x19
		[SerializeField]
		internal ProbeVolumeBakingProcessSettings settings; // 0x1C
		[SerializeField]
		private List<string> m_SceneGUIDs; // 0x50
		[FormerlySerializedAs("scenesToNotBake")]
		[Obsolete("This is now contained in the SceneBakeData structure. #from(2023.3)")]
		[SerializeField]
		internal List<string> obsoleteScenesToNotBake; // 0x58
		[FormerlySerializedAs("lightingScenarios")]
		[SerializeField]
		internal List<string> m_LightingScenarios; // 0x60
		[SerializeField]
		internal SerializedDictionary<int, ProbeReferenceVolume.CellDesc> cellDescs; // 0x68
		internal Dictionary<int, ProbeReferenceVolume.CellData> cellDataMap; // 0x70
		private List<int> m_TotalIndexList; // 0x78
		[SerializeField]
		private List<SerializedPerSceneCellList> m_SerializedPerSceneCellList; // 0x80
		internal Dictionary<string, List<int>> perSceneCellLists; // 0x88
		[SerializeField]
		internal ProbeVolumeStreamableAsset cellSharedDataAsset; // 0x90
		[SerializeField]
		internal SerializedDictionary<string, PerScenarioDataInfo> scenarios; // 0x98
		[SerializeField]
		internal ProbeVolumeStreamableAsset cellBricksDataAsset; // 0xA0
		[SerializeField]
		internal ProbeVolumeStreamableAsset cellSupportDataAsset; // 0xA8
		[SerializeField]
		internal int chunkSizeInBricks; // 0xB0
		[SerializeField]
		internal Vector3Int maxCellPosition; // 0xB4
		[SerializeField]
		internal Vector3Int minCellPosition; // 0xC0
		[SerializeField]
		internal Bounds globalBounds; // 0xCC
		[SerializeField]
		internal int bakedSimplificationLevels; // 0xE4
		[SerializeField]
		internal float bakedMinDistanceBetweenProbes; // 0xE8
		[SerializeField]
		internal bool bakedProbeOcclusion; // 0xEC
		[SerializeField]
		internal int bakedSkyOcclusionValue; // 0xF0
		[SerializeField]
		internal int bakedSkyShadingDirectionValue; // 0xF4
		[SerializeField]
		internal Vector3 bakedProbeOffset; // 0xF8
		[SerializeField]
		internal int bakedMaskCount; // 0x104
		[SerializeField]
		internal uint4 bakedLayerMasks; // 0x108
		[SerializeField]
		internal int maxSHChunkCount; // 0x118
		[SerializeField]
		internal int L0ChunkSize; // 0x11C
		[SerializeField]
		internal int L1ChunkSize; // 0x120
		[SerializeField]
		internal int L2TextureChunkSize; // 0x124
		[SerializeField]
		internal int ProbeOcclusionChunkSize; // 0x128
		[SerializeField]
		internal int sharedValidityMaskChunkSize; // 0x12C
		[SerializeField]
		internal int sharedSkyOcclusionL0L1ChunkSize; // 0x130
		[SerializeField]
		internal int sharedSkyShadingDirectionIndicesChunkSize; // 0x134
		[SerializeField]
		internal int sharedDataChunkSize; // 0x138
		[SerializeField]
		internal int supportPositionChunkSize; // 0x13C
		[SerializeField]
		internal int supportValidityChunkSize; // 0x140
		[SerializeField]
		internal int supportTouchupChunkSize; // 0x144
		[SerializeField]
		internal int supportLayerMaskChunkSize; // 0x148
		[SerializeField]
		internal int supportOffsetsChunkSize; // 0x14C
		[SerializeField]
		internal int supportDataChunkSize; // 0x150
		[SerializeField]
		internal string lightingScenario; // 0x158
		private string m_OtherScenario; // 0x160
		private float m_ScenarioBlendingFactor; // 0x168
		private ReadCommandArray m_ReadCommandArray; // 0x170
		private NativeArray<ReadCommand> m_ReadCommandBuffer; // 0x180
		private Stack<NativeArray<byte>> m_ReadOperationScratchBuffers; // 0x190
		private List<int> m_PrunedIndexList; // 0x198
		private List<int> m_PrunedScenarioIndexList; // 0x1A0
		internal const int k_MaxSkyOcclusionBakingSamples = 8192; // Metadata: 0x00661730
		[SerializeField]
		private Version version; // 0x1A8
		[SerializeField]
		internal bool freezePlacement; // 0x1AC
		[SerializeField]
		public Vector3 probeOffset; // 0x1B0
		[Range(2f, 5f)]
		public int simplificationLevels; // 0x1BC
		[Min(0.1f)]
		public float minDistanceBetweenProbes; // 0x1C0
		public LayerMask renderersLayerMask; // 0x1C4
		[Min(0f)]
		public float minRendererVolumeSize; // 0x1C8
		public bool skyOcclusion; // 0x1CC
		[Logarithmic(1, 8192)]
		public int skyOcclusionBakingSamples; // 0x1D0
		[Range(0f, 5f)]
		public int skyOcclusionBakingBounces; // 0x1D4
		[Range(0f, 1f)]
		public float skyOcclusionAverageAlbedo; // 0x1D8
		public bool skyOcclusionBackFaceCulling; // 0x1DC
		public bool skyOcclusionShadingDirection; // 0x1DD
		[SerializeField]
		internal bool useRenderingLayers; // 0x1DE
		[SerializeField]
		internal ProbeLayerMask[] renderingLayerMasks; // 0x1E0
		private bool m_HasSupportData; // 0x1E8
		private bool m_SharedDataIsValid; // 0x1E9
		private bool m_UseStreamingAsset; // 0x1EA
	
		// Properties
		internal bool hasDilation { get; } // 0x0000000181E84B00-0x0000000181E84B20 
		public IReadOnlyList<string> sceneGUIDs { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public IReadOnlyList<string> lightingScenarios { get; } // 0x0000000180333260-0x0000000180333490 
		internal bool bakedSkyOcclusion { get; set; } // 0x0000000181E84A50-0x0000000181E84A60 0x0000000181E84B50-0x0000000181E84B60
		internal bool bakedSkyShadingDirection { get; set; } // 0x0000000181E84A60-0x0000000181E84A70 0x0000000181E84B60-0x0000000181E84B70
		internal string otherScenario { get; } // 0x00000001819746D0-0x00000001819746E0 
		internal float scenarioBlendingFactor { get; } // 0x0000000181C4BDE0-0x0000000181C4BDF0 
		public int cellSizeInBricks { get; } // 0x0000000181E84A70-0x0000000181E84AA0 
		public int maxSubdivision { get; } // 0x0000000181E84B20-0x0000000181E84B30 
		public float minBrickSize { get; } // 0x0000000181E84B30-0x0000000181E84B50 
		public float cellSizeInMeters { get; } // 0x0000000181E84AA0-0x0000000181E84B00 
	
		// Nested types
		internal enum Version // TypeDefIndex: 5602
		{
			Initial = 0,
			RemoveProbeVolumeSceneData = 1,
			AssetsAlwaysReferenced = 2
		}
	
		[Serializable]
		internal class PerScenarioDataInfo // TypeDefIndex: 5603
		{
			// Fields
			public int sceneHash; // 0x10
			public ProbeVolumeStreamableAsset cellDataAsset; // 0x18
			public ProbeVolumeStreamableAsset cellOptionalDataAsset; // 0x20
			public ProbeVolumeStreamableAsset cellProbeOcclusionDataAsset; // 0x28
			private bool m_HasValidData; // 0x30
	
			// Constructors
			public PerScenarioDataInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Initialize(ProbeVolumeSHBands shBands); // 0x0000000181E80190-0x0000000181E80200
			public bool IsValid(); // 0x0000000181E80200-0x0000000181E80230
			public bool HasValidData(ProbeVolumeSHBands shBands); // 0x00000001802E8950-0x00000001802E8960
			public bool ComputeHasValidData(ProbeVolumeSHBands shBands); // 0x0000000181E80120-0x0000000181E80190
		}
	
		[Serializable]
		internal struct CellCounts // TypeDefIndex: 5604
		{
			// Fields
			public int bricksCount; // 0x00
			public int chunksCount; // 0x04
	
			// Methods
			public void Add(CellCounts o); // 0x0000000181E75730-0x0000000181E75740
		}
	
		[Serializable]
		private struct SerializedPerSceneCellList // TypeDefIndex: 5605
		{
			// Fields
			public string sceneGUID; // 0x00
			public List<int> cellList; // 0x08
		}
	
		[Serializable]
		internal struct ProbeLayerMask // TypeDefIndex: 5606
		{
			// Fields
			public RenderingLayerMask mask; // 0x00
			public string name; // 0x08
		}
	
		// Constructors
		public ProbeVolumeBakingSet(); // 0x0000000181E84600-0x0000000181E84A50
	
		// Methods
		internal uint4 ComputeRegionMasks(); // 0x0000000181E80E30-0x0000000181E80F30
		internal static int GetCellSizeInBricks(int simplificationLevels); // 0x0000000181E81250-0x0000000181E81280
		internal static int GetMaxSubdivision(int simplificationLevels); // 0x0000000181E812C0-0x0000000181E812D0
		internal static float GetMinBrickSize(float minDistanceBetweenProbes); // 0x0000000181E812D0-0x0000000181E812F0
		private void OnValidate(); // 0x0000000181E81E40-0x0000000181E81FB0
		private void OnEnable(); // 0x0000000181E81C70-0x0000000181E81E40
		internal void Migrate(); // 0x0000000181E81B30-0x0000000181E81C70
		private bool ComputeHasValidSharedData(); // 0x0000000181E80DE0-0x0000000181E80E30
		internal bool HasValidSharedData(); // 0x0000000181E816D0-0x0000000181E816E0
		internal bool CheckCompatibleCellLayout(); // 0x0000000181E80970-0x0000000181E809F0
		private bool ComputeHasSupportData(); // 0x0000000181E80D90-0x0000000181E80DE0
		internal bool HasSupportData(); // 0x0000000181E816C0-0x0000000181E816D0
		public bool HasBakedData(string scenario = null); // 0x0000000181E81370-0x0000000181E814D0
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181E83FE0-0x0000000181E843C0
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181E843C0-0x0000000181E84600
		internal void Initialize(bool useStreamingAsset); // 0x0000000181E816E0-0x0000000181E81B30
		internal void Cleanup(); // 0x0000000181E809F0-0x0000000181E80D90
		internal void SetActiveScenario(string scenario, bool verbose = true /* Metadata: 0x0066172F */); // 0x0000000181E83D80-0x0000000181E83FE0
		internal void BlendLightingScenario(string otherScenario, float blendingFactor); // 0x0000000181E80630-0x0000000181E80970
		internal int GetBakingHashCode(); // 0x0000000181E80FA0-0x0000000181E81150
		private static int AlignUp16(int count); // 0x0000000181E80600-0x0000000181E80630
		private NativeArray<T> GetSubArray<T>(NativeArray<byte> input, int count, ref int offset)
			where T : struct;
		private NativeArray<byte> RequestScratchBuffer(int size); // 0x0000000181E82330-0x0000000181E82440
		private bool FileExists(string path); // 0x0000000181E80F30-0x0000000181E80FA0
		private NativeArray<T> LoadStreambleAssetData<T>(ProbeVolumeStreamableAsset asset, List<int> cellIndices)
			where T : struct;
		private void ReleaseStreamableAssetData<T>(NativeArray<T> buffer)
			where T : struct;
		internal void PruneCellIndexList(List<int> cellIndices, List<int> prunedIndexList); // 0x0000000181E82120-0x0000000181E822A0
		private void PruneCellIndexListForScenario(List<int> cellIndices, PerScenarioDataInfo scenarioData, List<int> prunedIndexList); // 0x0000000181E81FB0-0x0000000181E82120
		internal List<int> GetSceneCellIndexList(string sceneGUID); // 0x0000000181E812F0-0x0000000181E81370
		private bool ResolveAllCellData(); // 0x0000000181E82440-0x0000000181E82480
		internal bool ResolveCellData(List<int> cellIndices); // 0x0000000181E82480-0x0000000181E82870
		private void ResolveSharedCellData(List<int> cellIndices, NativeArray<ProbeBrickIndex.Brick> bricksData, NativeArray<byte> cellSharedData, NativeArray<byte> cellSupportData); // 0x0000000181E83600-0x0000000181E83D80
		internal bool ResolveSharedCellData(List<int> cellIndices); // 0x0000000181E833E0-0x0000000181E83600
		internal bool ResolvePerScenarioCellData(List<int> cellIndices); // 0x0000000181E82870-0x0000000181E82DE0
		internal bool ResolvePerScenarioCellData(NativeArray<byte> cellData, NativeArray<byte> cellOptionalData, NativeArray<byte> cellProbeOcclusionData, string scenario, List<int> cellIndices); // 0x0000000181E82DE0-0x0000000181E833E0
		internal void ReleaseCell(int cellIndex); // 0x0000000181E822A0-0x0000000181E82330
		internal ProbeReferenceVolume.CellDesc GetCellDesc(int cellIndex); // 0x0000000181E811D0-0x0000000181E81250
		internal ProbeReferenceVolume.CellData GetCellData(int cellIndex); // 0x0000000181E81150-0x0000000181E811D0
		internal int GetChunkGPUMemory(ProbeVolumeSHBands shBands); // 0x0000000181E81280-0x0000000181E812C0
		internal bool HasSameSceneGUIDs(ProbeVolumeBakingSet other); // 0x0000000181E814D0-0x0000000181E816C0
	}
}
