/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	public struct UnsafeParallelHashMapBucketData // TypeDefIndex: 11712
	{
		// Fields
		public readonly unsafe byte* values; // 0x00
		public readonly unsafe byte* keys; // 0x08
		public readonly unsafe byte* next; // 0x10
		public readonly unsafe byte* buckets; // 0x18
		public readonly int bucketCapacityMask; // 0x20
	
		// Constructors
		internal unsafe UnsafeParallelHashMapBucketData(byte* v, byte* k, byte* n, byte* b, int bcm); // 0x0000000181CABD70-0x0000000181CABD90
	}
}
