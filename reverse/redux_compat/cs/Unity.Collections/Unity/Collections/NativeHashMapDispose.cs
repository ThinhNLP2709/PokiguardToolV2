/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	internal struct NativeHashMapDispose // TypeDefIndex: 11559
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeHashMap<int, int>* m_HashMapData; // 0x00
		internal AllocatorManager.AllocatorHandle m_Allocator; // 0x08
	
		// Methods
		internal void Dispose(); // 0x0000000181CA3060-0x0000000181CA30A0
	}
}
