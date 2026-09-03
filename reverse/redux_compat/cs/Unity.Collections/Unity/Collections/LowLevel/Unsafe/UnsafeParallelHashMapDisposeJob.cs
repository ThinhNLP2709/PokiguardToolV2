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
	internal struct UnsafeParallelHashMapDisposeJob : IJob // TypeDefIndex: 11723
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeParallelHashMapData* Data; // 0x00
		public AllocatorManager.AllocatorHandle Allocator; // 0x08
	
		// Methods
		public void Execute(); // 0x0000000181CABD90-0x0000000181CABDD0
	}
}
