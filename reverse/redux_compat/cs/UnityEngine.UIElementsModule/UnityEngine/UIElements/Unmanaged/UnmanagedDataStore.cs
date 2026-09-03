/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	internal struct UnmanagedDataStore : IDisposable // TypeDefIndex: 4990
	{
		// Fields
		private readonly MemoryLabel m_MemoryLabel; // 0x00
		[NativeDisableUnsafePtrRestriction]
		private unsafe Data* m_Data; // 0x10
	
		// Nested types
		private struct Data // TypeDefIndex: 4991
		{
			// Fields
			public int Capacity; // 0x00
			public int NextFreeIndex; // 0x04
			public int ComponentCount; // 0x08
			[NativeDisableUnsafePtrRestriction]
			public unsafe int* Versions; // 0x10
			[NativeDisableUnsafePtrRestriction]
			public unsafe int* FreeIndices; // 0x18
			[NativeDisableUnsafePtrRestriction]
			public unsafe ComponentDataStore* Components; // 0x20
		}
	
		// Constructors
		public unsafe UnmanagedDataStore(UnmanagedComponentType[] components, ReadOnlySpan<MemoryLabel> labels, byte** initialData, int initialCapacity, Allocator allocator); // 0x0000000182400440-0x00000001824007F0
	
		// Methods
		public void Dispose(); // 0x00000001823FFA90-0x00000001823FFC50
		public bool Exists([IsReadOnly] in UnmanagedDataHandle handle); // 0x00000001823FFC50-0x00000001823FFC90
		[IsReadOnly]
		internal unsafe void* GetComponentDataPtr(int index, int componentIndex); // 0x00000001823FFE50-0x00000001823FFEA0
		internal bool IsFree(int index); // 0x00000001823FFF10-0x00000001823FFF40
		public UnmanagedDataHandle Allocate(); // 0x00000001823FF9E0-0x00000001823FFA90
		public void Free([IsReadOnly] in UnmanagedDataHandle handle); // 0x00000001823FFC90-0x00000001823FFE50
		private void SetNextFreeIndex(int index, int value); // 0x0000000182400410-0x0000000182400440
		private int GetNextFreeIndex(int index); // 0x00000001823FFEA0-0x00000001823FFED0
		private void IncreaseCapacity(); // 0x00000001823FFED0-0x00000001823FFF10
		private void ResizeCapacity(int capacity); // 0x00000001823FFFF0-0x0000000182400410
		private static unsafe void* ResizeArray(void* fromPtr, long fromCount, long toCount, long size, int align, MemoryLabel label); // 0x00000001823FFF40-0x00000001823FFFF0
	}
}
