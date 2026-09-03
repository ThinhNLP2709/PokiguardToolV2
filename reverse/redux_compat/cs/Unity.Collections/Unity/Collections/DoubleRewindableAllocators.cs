/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public struct DoubleRewindableAllocators : IDisposable // TypeDefIndex: 11493
	{
		// Fields
		private unsafe RewindableAllocator* Pointer; // 0x00
		private AllocatorHelper<RewindableAllocator> UpdateAllocatorHelper0; // 0x08
		private AllocatorHelper<RewindableAllocator> UpdateAllocatorHelper1; // 0x18
	
		// Properties
		public ref RewindableAllocator Allocator { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public bool IsCreated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		internal bool EnableBlockFree { get; set; } // 0x0000000181C8FDE0-0x0000000181C8FE00 0x0000000181C8FE00-0x0000000181C8FE50
	
		// Constructors
		public unsafe DoubleRewindableAllocators(AllocatorManager.AllocatorHandle backingAllocator, int initialSizeInBytes); // 0x0000000181C8FCC0-0x0000000181C8FDE0
	
		// Methods
		public void Update(); // 0x0000000181C8FC70-0x0000000181C8FCC0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckIsCreated(); // 0x0000000181C8FA90-0x0000000181C8FB00
		public void Initialize(AllocatorManager.AllocatorHandle backingAllocator, int initialSizeInBytes); // 0x0000000181C8FB60-0x0000000181C8FC70
		public void Dispose(); // 0x0000000181C8FB00-0x0000000181C8FB60
	}
}
