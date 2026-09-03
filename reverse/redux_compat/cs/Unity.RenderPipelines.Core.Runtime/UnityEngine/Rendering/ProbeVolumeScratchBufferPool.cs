/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ProbeVolumeScratchBufferPool // TypeDefIndex: 5619
	{
		// Fields
		[CompilerGenerated]
		private int _chunkSize_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _maxChunkCount_k__BackingField; // 0x14
		private int m_L0Size; // 0x18
		private int m_L1Size; // 0x1C
		private int m_ValiditySize; // 0x20
		private int m_ValidityLayerCount; // 0x24
		private int m_L2Size; // 0x28
		private int m_ProbeOcclusionSize; // 0x2C
		private int m_SkyOcclusionSize; // 0x30
		private int m_SkyShadingDirectionSize; // 0x34
		private int m_CurrentlyAllocatedChunkCount; // 0x38
		private List<ScratchBufferPool> m_Pools; // 0x40
		private Dictionary<int, ProbeReferenceVolume.CellStreamingScratchBufferLayout> m_Layouts; // 0x48
		private static int s_ChunkCount; // 0x00
	
		// Properties
		public int chunkSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int maxChunkCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int allocatedMemory { get; } // 0x0000000181E87F40-0x0000000181E87F50 
	
		// Nested types
		[DebuggerDisplay("ChunkCount = {chunkCount} ElementCount = {pool.Count}")]
		private class ScratchBufferPool : IComparable<ScratchBufferPool> // TypeDefIndex: 5620
		{
			// Fields
			public int chunkCount; // 0x10
			public Stack<ProbeReferenceVolume.CellStreamingScratchBuffer> pool; // 0x18
	
			// Constructors
			public ScratchBufferPool(int chunkCount); // 0x0000000181E88B70-0x0000000181E88C00
			private ScratchBufferPool(); // 0x0000000181E88C00-0x0000000181E88C80
	
			// Methods
			public int CompareTo(ScratchBufferPool other); // 0x0000000181E88B30-0x0000000181E88B70
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5621
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<ScratchBufferPool> __9__26_0; // 0x08
			public static Predicate<ScratchBufferPool> __9__27_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181E8A540-0x0000000181E8A5B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AllocateScratchBuffer_b__26_0(ScratchBufferPool o); // 0x0000000181E89F90-0x0000000181E89FE0
			internal bool _ReleaseScratchBuffer_b__27_0(ScratchBufferPool o); // 0x0000000181E8A070-0x0000000181E8A0C0
		}
	
		// Constructors
		public ProbeVolumeScratchBufferPool(ProbeVolumeBakingSet bakingSet, ProbeVolumeSHBands shBands); // 0x0000000181E87DD0-0x0000000181E87F40
	
		// Methods
		private ProbeReferenceVolume.CellStreamingScratchBufferLayout GetOrCreateScratchBufferLayout(int chunkCount); // 0x0000000181E87940-0x0000000181E87C60
		private ProbeReferenceVolume.CellStreamingScratchBuffer CreateScratchBuffer(int chunkCount, bool allocateGraphicsBuffers); // 0x0000000181E87780-0x0000000181E87940
		public bool AllocateScratchBuffer(int chunkCount, out ProbeReferenceVolume.CellStreamingScratchBuffer scratchBuffer, out ProbeReferenceVolume.CellStreamingScratchBufferLayout layout, bool allocateGraphicsBuffers); // 0x0000000181E871E0-0x0000000181E875F0
		public void ReleaseScratchBuffer(ProbeReferenceVolume.CellStreamingScratchBuffer scratchBuffer); // 0x0000000181E87C60-0x0000000181E87DD0
		public void Cleanup(); // 0x0000000181E875F0-0x0000000181E87780
	}
}
