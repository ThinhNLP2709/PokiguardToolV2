/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class GpuUpdaterStaged : GpuUpdater // TypeDefIndex: 5067
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private static readonly ProfilerMarker s_MarkerGpuMappingFence; // 0x10
		private readonly Utility.GPUBufferType m_BufferType; // 0x18
		private readonly GpuBufferFlags m_StagingBufferFlags; // 0x1C
		private readonly int m_StagingElementStride; // 0x20
		private readonly uint[] m_SupportedBufferLengths; // 0x28
		[CompilerGenerated]
		private readonly StagingMode _stagingMode_k__BackingField; // 0x30
		private CircularRangeBuffer<GfxCopyBufferRange> m_GpuCopyRangesPool; // 0x38
		private CircularRangeBuffer<GfxUpdateBufferRange> m_UpdateRangesPool; // 0x40
		private CircularRangeBuffer<CpuCopyRange> m_CpuCopyRangesPool; // 0x48
		private List<StagingBufferInfo> m_StagingBuffers; // 0x50
		private List<StagingBufferInfo> m_AvailableStagingBuffers; // 0x58
		private List<DataSet> m_DirtyDataSets; // 0x60
		private int m_CurrentFrameIndex; // 0x68
		private int m_TotalDirtyCount; // 0x6C
		private int m_TotalCpuCopyRanges; // 0x70
		private JobHandle m_PendingCpuCopyJob; // 0x78
		private uint m_UpdateFence; // 0x88
		private PerFrameData[] m_FrameDataArray; // 0x90
		[NoAutoStaticsCleanup]
		private static readonly Comparison<DataSet> k_DataSetSort; // 0x18
	
		// Properties
		public StagingMode stagingMode { [CompilerGenerated] get; } // 0x000000018033D100-0x000000018033D110 
		private ref PerFrameData currentFrameData { get; } // 0x0000000182413D80-0x0000000182413DC0 
	
		// Nested types
		private struct CpuCopyRange // TypeDefIndex: 5068
		{
			// Fields
			public unsafe byte* srcPtr; // 0x00
			public unsafe byte* dstPtr; // 0x08
			public int byteSize; // 0x10
		}
	
		private struct CpuCopyJob : IJobFor // TypeDefIndex: 5069
		{
			// Fields
			[ReadOnly]
			public NativeSlice<CpuCopyRange> copyRanges; // 0x00
	
			// Methods
			public void Execute(int index); // 0x000000018240AE40-0x000000018240AE90
		}
	
		private struct PerFrameData // TypeDefIndex: 5070
		{
			// Fields
			public int gpuCopyRangesToFree; // 0x00
			public int gpuUpdateRangesToFree; // 0x04
			public int cpuCopyRangesToFree; // 0x08
		}
	
		private struct CopyInfo // TypeDefIndex: 5071
		{
			// Fields
			public unsafe void* srcCpuBuffer; // 0x00
			public Utility.GPUBuffer dstGpuBuffer; // 0x08
			public NativeSlice<GfxCopyBufferRange> pendingGpuCopies; // 0x10
		}
	
		private class StagingBufferInfo // TypeDefIndex: 5072
		{
			// Fields
			public int frameUsed; // 0x10
			public int usedCount; // 0x14
			public int capacity; // 0x18
			public RawArray cpuData; // 0x20
			public Utility.GPUBuffer gpuData; // 0x40
			public List<CopyInfo> pendingDataSets; // 0x48
	
			// Constructors
			public StagingBufferInfo(); // 0x000000018241E5E0-0x000000018241E660
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5073
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018241E7F0-0x000000018241E860
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _.cctor_b__45_0(DataSet a, DataSet b); // 0x000000018241E660-0x000000018241E690
		}
	
		// Constructors
		public GpuUpdaterStaged(Utility.GPUBufferType bufferType, StagingMode stagingMode, int elementStride); // 0x00000001824139C0-0x0000000182413D80
		static GpuUpdaterStaged(); // 0x0000000182413850-0x00000001824139C0
	
		// Methods
		public override void ProcessDataSet(DataSet dataSet); // 0x0000000182412840-0x0000000182412970
		public override void CompleteUpdate(); // 0x00000001824115C0-0x0000000182411E50
		private void GatherAvailableStagingBuffers(); // 0x0000000182412280-0x0000000182412470
		private static void AlignIndexRange(ref uint start, ref uint count); // 0x00000001824112D0-0x00000001824112F0
		private void PruneUnusedStagingBuffers(); // 0x0000000182412970-0x0000000182412A60
		private int FindSuitableBufferLength(int requiredLength); // 0x0000000182412220-0x0000000182412280
		private StagingBufferInfo FindOrAllocateBuffer(List<StagingBufferInfo> availableBuffers, int requiredLength); // 0x0000000182412050-0x0000000182412220
		private StagingBufferInfo AllocateStagingBuffer(int requiredLength); // 0x00000001824112F0-0x00000001824115C0
		private void PrepareCopyRanges(DataSet dataSet, StagingBufferInfo stagingBuffer); // 0x0000000182412470-0x0000000182412840
		private void UpdateStagingBuffersCpuData(List<StagingBufferInfo> stagingBuffers); // 0x0000000182412A60-0x0000000182412FE0
		private void UpdateStagingBuffersGpuData(List<StagingBufferInfo> stagingBuffers); // 0x00000001824135F0-0x0000000182413850
		private void UpdateStagingBuffersDirectly(List<StagingBufferInfo> stagingBuffers); // 0x0000000182412FE0-0x00000001824135F0
		public override void AdvanceFrame(); // 0x0000000182411170-0x00000001824112D0
		protected override void Dispose(bool disposing); // 0x0000000182411E50-0x0000000182412050
	}
}
