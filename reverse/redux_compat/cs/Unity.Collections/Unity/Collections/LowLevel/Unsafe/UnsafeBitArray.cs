/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
	[DebuggerTypeProxy(typeof(UnsafeBitArrayDebugView))]
	[GenerateTestsForBurstCompatibility]
	public struct UnsafeBitArray : INativeDisposable // TypeDefIndex: 11684
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public unsafe ulong* Ptr; // 0x00
		public int Length; // 0x08
		public int Capacity; // 0x0C
		public AllocatorManager.AllocatorHandle Allocator; // 0x10
		public const int MaxCapacity = 2147483584; // Metadata: 0x006A1D13
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public bool IsEmpty { [IsReadOnly] get; } // 0x0000000180D11420-0x0000000180D11440 
	
		// Nested types
		public struct ReadOnly // TypeDefIndex: 11685
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public readonly unsafe ulong* Ptr; // 0x00
			public readonly int Length; // 0x08
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
			public bool IsEmpty { [IsReadOnly] get; } // 0x0000000180D11420-0x0000000180D11440 
	
			// Constructors
			internal unsafe ReadOnly(ulong* ptr, int length); // 0x0000000180CB6EA0-0x0000000180CB6EB0
	
			// Methods
			[IsReadOnly]
			public ulong GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1D18 */); // 0x0000000181CA5270-0x0000000181CA52A0
			[IsReadOnly]
			public bool IsSet(int pos); // 0x0000000181CA52A0-0x0000000181CA52B0
			[IsReadOnly]
			public int Find(int pos, int numBits); // 0x0000000181CA5240-0x0000000181CA5270
			[IsReadOnly]
			public int Find(int pos, int count, int numBits); // 0x0000000181CA5220-0x0000000181CA5240
			[IsReadOnly]
			public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1D19 */); // 0x0000000181CA5310-0x0000000181CA5340
			[IsReadOnly]
			public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1D1A */); // 0x0000000181CA52E0-0x0000000181CA5310
			[IsReadOnly]
			public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1D1B */); // 0x0000000181CA52B0-0x0000000181CA52E0
			[IsReadOnly]
			public int CountBits(int pos, int numBits = 1 /* Metadata: 0x006A1D1C */); // 0x0000000181CA4C80-0x0000000181CA4CB0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void CheckArgs(int pos, int numBits); // 0x0000000181CA4AA0-0x0000000181CA4B90
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void CheckArgsPosCount(int begin, int count, int numBits); // 0x0000000181CA4740-0x0000000181CA4930
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			[IsReadOnly]
			private void CheckArgsUlong(int pos, int numBits); // 0x0000000181CA4930-0x0000000181CA4AA0
		}
	
		// Constructors
		public unsafe UnsafeBitArray(void* ptr, int sizeInBytes, AllocatorManager.AllocatorHandle allocator = default); // 0x0000000181CABC70-0x0000000181CABC90
		public unsafe UnsafeBitArray(int numBits, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1D0B */); // 0x0000000181CABC90-0x0000000181CABD10
	
		// Methods
		internal static unsafe UnsafeBitArray* Alloc(AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAAAA0-0x0000000181CAAAF0
		internal static unsafe void Free(UnsafeBitArray* data, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAB6B0-0x0000000181CAB730
		private void Realloc(int capacityInBits); // 0x0000000181CAB730-0x0000000181CAB810
		public void Resize(int numBits, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1D0C */); // 0x0000000181CAB810-0x0000000181CAB880
		public void SetCapacity(int capacityInBits); // 0x0000000181CABAA0-0x0000000181CABB80
		public void TrimExcess(); // 0x0000000181CABC60-0x0000000181CABC70
		public void Dispose(); // 0x0000000181CAB520-0x0000000181CAB5A0
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CAB5A0-0x0000000181CAB6B0
		public void Clear(); // 0x0000000181CAB1A0-0x0000000181CAB1E0
		public static unsafe void Set(ulong* ptr, int pos, bool value); // 0x0000000181CABB80-0x0000000181CABBF0
		public void Set(int pos, bool value); // 0x0000000181CABBF0-0x0000000181CABC60
		public void SetBits(int pos, bool value, int numBits); // 0x0000000181CAB990-0x0000000181CABAA0
		public void SetBits(int pos, ulong value, int numBits = 1 /* Metadata: 0x006A1D0D */); // 0x0000000181CAB880-0x0000000181CAB990
		public ulong GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1D0E */); // 0x0000000181CA5270-0x0000000181CA52A0
		public bool IsSet(int pos); // 0x0000000181CA52A0-0x0000000181CA52B0
		internal void CopyUlong(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits); // 0x0000000181CAB1E0-0x0000000181CAB240
		public void Copy(int dstPos, int srcPos, int numBits); // 0x0000000181CAB4F0-0x0000000181CAB520
		public void Copy(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits); // 0x0000000181CAB240-0x0000000181CAB4F0
		public int Find(int pos, int numBits); // 0x0000000181CA5240-0x0000000181CA5270
		public int Find(int pos, int count, int numBits); // 0x0000000181CA5220-0x0000000181CA5240
		public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1D0F */); // 0x0000000181CA5310-0x0000000181CA5340
		public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1D10 */); // 0x0000000181CA52E0-0x0000000181CA5310
		public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1D11 */); // 0x0000000181CA52B0-0x0000000181CA52E0
		public int CountBits(int pos, int numBits = 1 /* Metadata: 0x006A1D12 */); // 0x0000000181CA4C80-0x0000000181CA4CB0
		public ReadOnly AsReadOnly(); // 0x0000000180743780-0x00000001807437A0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckSizeMultipleOf8(int sizeInBytes); // 0x0000000181CAB0F0-0x0000000181CAB1A0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckArgs(int pos, int numBits); // 0x0000000181CAB000-0x0000000181CAB0F0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckArgsPosCount(int begin, int count, int numBits); // 0x0000000181CAACA0-0x0000000181CAAE90
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckArgsUlong(int pos, int numBits); // 0x0000000181CAAE90-0x0000000181CAB000
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckArgsCopy(ref UnsafeBitArray dstBitArray, int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits); // 0x0000000181CAAAF0-0x0000000181CAACA0
	}
}
