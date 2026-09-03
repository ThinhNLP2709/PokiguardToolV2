/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ProbeBrickIndex // TypeDefIndex: 5545
	{
		// Fields
		private static readonly ProfilerMarker k_CreateProbeBrickIndex; // 0x00
		private static readonly ProfilerMarker k_ClearIndex; // 0x08
		internal const int kMaxSubdivisionLevels = 7; // Metadata: 0x006616D9
		internal const int kIndexChunkSize = 243; // Metadata: 0x006616DA
		internal const int kFailChunkIndex = -1; // Metadata: 0x006616DC
		internal const int kEmptyIndex = -2; // Metadata: 0x006616DD
		private BitArray m_IndexChunks; // 0x10
		private BitArray m_IndexChunksCopyForChecks; // 0x18
		private int m_ChunksCount; // 0x20
		private int m_AvailableChunkCount; // 0x24
		private ComputeBuffer m_PhysicalIndexBuffer; // 0x28
		private NativeArray<int> m_PhysicalIndexBufferData; // 0x30
		private ComputeBuffer m_DebugFragmentationBuffer; // 0x40
		private int[] m_DebugFragmentationData; // 0x48
		private bool m_NeedUpdateIndexComputeBuffer; // 0x50
		private int m_UpdateMinIndex; // 0x54
		private int m_UpdateMaxIndex; // 0x58
		[CompilerGenerated]
		private int _estimatedVMemCost_k__BackingField; // 0x5C
		[CompilerGenerated]
		private float _fragmentationRate_k__BackingField; // 0x60
		private Vector3Int m_CenterRS; // 0x64
	
		// Properties
		internal int estimatedVMemCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		internal float fragmentationRate { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181DB5660-0x0000000181DB5670
	
		// Nested types
		[Serializable]
		[DebuggerDisplay("Brick [{position}, {subdivisionLevel}]")]
		public struct Brick : IEquatable<Brick> // TypeDefIndex: 5546
		{
			// Fields
			public Vector3Int position; // 0x00
			public int subdivisionLevel; // 0x0C
	
			// Constructors
			internal Brick(Vector3Int position, int subdivisionLevel); // 0x0000000181E52DE0-0x0000000181E52E00
	
			// Methods
			public bool Equals(Brick other); // 0x0000000181E52AB0-0x0000000181E52B20
			public bool IntersectArea(Bounds boundInBricksToCheck); // 0x0000000181E52B20-0x0000000181E52DE0
		}
	
		public struct IndirectionEntryUpdateInfo // TypeDefIndex: 5547
		{
			// Fields
			public int firstChunkIndex; // 0x00
			public int numberOfChunks; // 0x04
			public int minSubdivInCell; // 0x08
			public Vector3Int minValidBrickIndexForCellAtMaxRes; // 0x0C
			public Vector3Int maxValidBrickIndexForCellAtMaxResPlusOne; // 0x18
			public Vector3Int entryPositionInBricksAtMaxRes; // 0x24
			public bool hasOnlyBiggerBricks; // 0x30
		}
	
		public struct CellIndexUpdateInfo // TypeDefIndex: 5548
		{
			// Fields
			public IndirectionEntryUpdateInfo[] entriesInfo; // 0x00
	
			// Methods
			public int GetNumberOfChunks(); // 0x0000000181E52E00-0x0000000181E52E60
		}
	
		// Constructors
		internal ProbeBrickIndex(ProbeVolumeTextureMemoryBudget memoryBudget); // 0x0000000181E574A0-0x0000000181E57760
		static ProbeBrickIndex(); // 0x0000000181E573F0-0x0000000181E574A0
	
		// Methods
		internal ComputeBuffer GetDebugFragmentationBuffer(); // 0x0000000180377940-0x0000000180377950
		private int SizeOfPhysicalIndexFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget); // 0x0000000181E571A0-0x0000000181E571D0
		public int GetRemainingChunkCount(); // 0x0000000180D17D10-0x0000000180D17D20
		internal void UploadIndexData(); // 0x0000000181E57370-0x0000000181E573F0
		private void UpdateDebugData(); // 0x0000000181E571D0-0x0000000181E57370
		internal void Clear(); // 0x0000000181E56360-0x0000000181E56480
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr); // 0x0000000181E56950-0x0000000181E56AC0
		internal void Cleanup(); // 0x0000000181E562C0-0x0000000181E56360
		internal void ComputeFragmentationRate(); // 0x0000000181E56480-0x0000000181E56500
		private int MergeIndex(int index, int size); // 0x0000000181E56F60-0x0000000181E56F80
		internal int GetNumberOfChunks(int brickCount); // 0x0000000181E568E0-0x0000000181E56950
		internal bool FindSlotsForEntries(ref IndirectionEntryUpdateInfo[] entriesInfo); // 0x0000000181E56500-0x0000000181E568E0
		internal bool ReserveChunks(IndirectionEntryUpdateInfo[] entriesInfo, bool ignoreErrorLog); // 0x0000000181E57060-0x0000000181E571A0
		internal static bool BrickOverlapEntry(Vector3Int brickMin, Vector3Int brickMax, Vector3Int entryMin, Vector3Int entryMax); // 0x0000000181E56280-0x0000000181E562C0
		private static int LocationToIndex(int x, int y, int z, Vector3Int sizeOfValid); // 0x0000000181E56AC0-0x0000000181E56AD0
		private void MarkBrickInPhysicalBuffer([IsReadOnly] in IndirectionEntryUpdateInfo entry, Vector3Int brickMin, Vector3Int brickMax, int brickSubdivLevel, int entrySubdivLevel, int idx); // 0x0000000181E56AD0-0x0000000181E56F60
		public void AddBricks(ProbeReferenceVolume.CellIndexInfo cellInfo, NativeArray<Brick> bricks, List<ProbeBrickPool.BrickChunkAlloc> allocations, int allocationSize, int poolWidth, int poolHeight); // 0x0000000181E55DD0-0x0000000181E56280
		public void RemoveBricks(ProbeReferenceVolume.CellIndexInfo cellInfo); // 0x0000000181E56F80-0x0000000181E57060
	}
}
