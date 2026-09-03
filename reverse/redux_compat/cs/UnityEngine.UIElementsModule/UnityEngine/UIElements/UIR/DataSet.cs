/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class DataSet : IDisposable // TypeDefIndex: 5028
	{
		// Fields
		private static readonly MemoryLabel s_CpuMemoryLabel; // 0x00
		public readonly Utility.GPUBufferType bufferType; // 0x10
		public Utility.GPUBuffer gpuData; // 0x18
		public RawArray cpuData; // 0x20
		public GPUBufferAllocator allocator; // 0x40
		public List<Range> dirtyRanges; // 0x48
		private uint m_DirtyRangeMin; // 0x50
		private uint m_DirtyRangeMax; // 0x54
		private uint m_TotalDirtyCount; // 0x58
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x5C
	
		// Properties
		public uint totalDirtyCount { get; } // 0x000000018033D260-0x000000018033D270 
		public uint dirtyRangeMin { get; } // 0x000000018033D660-0x000000018033D670 
		public uint dirtyRangeMax { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001815D7D00-0x00000001815D7D10 0x0000000181EE3C70-0x0000000181EE3C80
	
		// Nested types
		public struct Range // TypeDefIndex: 5029
		{
			// Fields
			public uint start; // 0x00
			public uint count; // 0x04
		}
	
		// Constructors
		public DataSet(Utility.GPUBufferType bufferType, bool mapped, uint totalElemCount, uint elemStride); // 0x00000001823F5420-0x00000001823F56A0
		static DataSet(); // 0x00000001823F5390-0x00000001823F5420
	
		// Methods
		public void Dispose(); // 0x00000001823F52F0-0x00000001823F5360
		protected virtual void Dispose(bool disposing); // 0x00000001823F5220-0x00000001823F52F0
		public void AddDirtyRange(uint start, uint count); // 0x00000001823F4FC0-0x00000001823F5160
		public void ConsolidateRanges(float threshold = 0.9f /* Metadata: 0x006609BB */); // 0x00000001823F5160-0x00000001823F5220
		public void ResetDirtyRanges(); // 0x00000001823F5360-0x00000001823F5390
	}
}
