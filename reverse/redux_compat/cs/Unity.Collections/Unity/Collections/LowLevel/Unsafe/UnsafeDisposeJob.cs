/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[BurstCompile]
	internal struct UnsafeDisposeJob : IJob // TypeDefIndex: 11697
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe void* Ptr; // 0x00
		public AllocatorManager.AllocatorHandle Allocator; // 0x08
	
		// Methods
		public void Execute(); // 0x0000000181CABD10-0x0000000181CABD70
	}
}
