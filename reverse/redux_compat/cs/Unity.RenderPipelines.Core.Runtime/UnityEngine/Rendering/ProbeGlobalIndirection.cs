/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ProbeGlobalIndirection // TypeDefIndex: 5553
	{
		// Fields
		private const int kUintPerEntry = 3; // Metadata: 0x006616ED
		[CompilerGenerated]
		private int _estimatedVMemCost_k__BackingField; // 0x10
		internal const int kEntryMaxSubdivLevel = 3; // Metadata: 0x006616EE
		private ComputeBuffer m_IndexOfIndicesBuffer; // 0x18
		private uint[] m_IndexOfIndicesData; // 0x20
		private int m_CellSizeInMinBricks; // 0x28
		private Vector3Int m_EntriesCount; // 0x2C
		private Vector3Int m_EntryMin; // 0x38
		private Vector3Int m_EntryMax; // 0x44
		private bool m_NeedUpdateComputeBuffer; // 0x50
	
		// Properties
		internal int estimatedVMemCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		private int entrySizeInBricks { get; } // 0x0000000181E5B690-0x0000000181E5B6C0 
		internal int entriesPerCellDimension { get; } // 0x0000000181E5B650-0x0000000181E5B690 
	
		// Nested types
		internal struct IndexMetaData // TypeDefIndex: 5554
		{
			// Fields
			private static readonly uint[] s_PackedValues; // 0x00
			internal Vector3Int minLocalIdx; // 0x00
			internal Vector3Int maxLocalIdxPlusOne; // 0x0C
			internal int firstChunkIndex; // 0x18
			internal int minSubdiv; // 0x1C
	
			// Constructors
			static IndexMetaData(); // 0x0000000181E53DA0-0x0000000181E53E10
	
			// Methods
			internal void Pack(out uint[] vals); // 0x0000000181E53BA0-0x0000000181E53DA0
		}
	
		// Constructors
		internal ProbeGlobalIndirection(Vector3Int cellMin, Vector3Int cellMax, int cellSizeInMinBricks); // 0x0000000181E5B340-0x0000000181E5B650
	
		// Methods
		internal void GetMinMaxEntry(out Vector3Int minEntry, out Vector3Int maxEntry); // 0x0000000181E5AD10-0x0000000181E5AD40
		internal Vector3Int GetGlobalIndirectionDimension(); // 0x0000000181E5ACF0-0x0000000181E5AD10
		internal Vector3Int GetGlobalIndirectionMinEntry(); // 0x0000000181D8BE50-0x0000000181D8BE70
		private int GetFlatIndex(Vector3Int normalizedPos); // 0x0000000181E5AA50-0x0000000181E5AA70
		internal int GetFlatIdxForEntry(Vector3Int entryPosition); // 0x0000000181E5A9D0-0x0000000181E5AA50
		internal int[] GetFlatIndicesForCell(Vector3Int cellPosition); // 0x0000000181E5AA70-0x0000000181E5ACF0
		internal void UpdateCell(ProbeReferenceVolume.CellIndexInfo cellInfo); // 0x0000000181E5AE50-0x0000000181E5B340
		internal void MarkEntriesAsUnloaded(int[] entriesFlatIndices); // 0x0000000181E5AD90-0x0000000181E5AE20
		internal void PushComputeData(); // 0x0000000181E5AE20-0x0000000181E5AE50
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr); // 0x0000000181E5AD40-0x0000000181E5AD90
		internal void Cleanup(); // 0x0000000181E5A960-0x0000000181E5A9D0
	}
}
