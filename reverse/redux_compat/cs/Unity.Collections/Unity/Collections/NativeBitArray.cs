/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	public struct NativeBitArray : INativeDisposable // TypeDefIndex: 11555
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeBitArray* m_BitArray; // 0x00
		internal AllocatorManager.AllocatorHandle m_Allocator; // 0x08
		public const int MaxCapacity = 2147483584; // Metadata: 0x006A1C1E
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180C339C0-0x0000000180C339E0 
		public bool IsEmpty { [IsReadOnly] get; } // 0x0000000181CA3040-0x0000000181CA3060 
		public int Length { [IsReadOnly] get; } // 0x00000001814331A0-0x00000001814331C0 
		public int Capacity { [IsReadOnly] get; } // 0x0000000181CA3020-0x0000000181CA3040 
	
		// Nested types
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly // TypeDefIndex: 11556
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal UnsafeBitArray.ReadOnly m_BitArray; // 0x00
	
			// Properties
			public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
			public bool IsEmpty { [IsReadOnly] get; } // 0x0000000180D11420-0x0000000180D11440 
			public int Length { [IsReadOnly] get; } // 0x0000000180732D20-0x0000000180732D30 
	
			// Constructors
			internal ReadOnly(ref NativeBitArray data); // 0x0000000181CA53A0-0x0000000181CA53D0
	
			// Methods
			[IsReadOnly]
			public ulong GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1C23 */); // 0x0000000181CA5270-0x0000000181CA52A0
			[IsReadOnly]
			public bool IsSet(int pos); // 0x0000000181CA52A0-0x0000000181CA52B0
			[IsReadOnly]
			public int Find(int pos, int numBits); // 0x0000000181CA5240-0x0000000181CA5270
			[IsReadOnly]
			public int Find(int pos, int count, int numBits); // 0x0000000181CA5220-0x0000000181CA5240
			[IsReadOnly]
			public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1C24 */); // 0x0000000181CA5310-0x0000000181CA5340
			[IsReadOnly]
			public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1C25 */); // 0x0000000181CA52E0-0x0000000181CA5310
			[IsReadOnly]
			public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1C26 */); // 0x0000000181CA52B0-0x0000000181CA52E0
			[IsReadOnly]
			public int CountBits(int pos, int numBits = 1 /* Metadata: 0x006A1C27 */); // 0x0000000181CA4C80-0x0000000181CA4CB0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[IsReadOnly]
			private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public unsafe NativeBitArray(int numBits, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C16 */); // 0x0000000181CA2E90-0x0000000181CA3020
	
		// Methods
		public void Resize(int numBits, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory /* Metadata: 0x006A1C17 */); // 0x0000000181CA2CC0-0x0000000181CA2D30
		public void SetCapacity(int capacityInBits); // 0x0000000181CA2D70-0x0000000181CA2D80
		public void TrimExcess(); // 0x0000000181CA2E80-0x0000000181CA2E90
		public void Dispose(); // 0x0000000181CA2B90-0x0000000181CA2C30
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CA2A90-0x0000000181CA2B90
		public void Clear(); // 0x0000000181CA29D0-0x0000000181CA2A10
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public NativeArray<T> AsNativeArray<T>()
			where T : struct;
		public void Set(int pos, bool value); // 0x0000000181CA2D80-0x0000000181CA2DF0
		public void SetBits(int pos, bool value, int numBits); // 0x0000000181CA2D30-0x0000000181CA2D50
		public void SetBits(int pos, ulong value, int numBits = 1 /* Metadata: 0x006A1C18 */); // 0x0000000181CA2D50-0x0000000181CA2D70
		public ulong GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1C19 */); // 0x0000000181CA2C80-0x0000000181CA2CB0
		public bool IsSet(int pos); // 0x0000000181CA2CB0-0x0000000181CA2CC0
		public void Copy(int dstPos, int srcPos, int numBits); // 0x0000000181CA2A30-0x0000000181CA2A60
		public void Copy(int dstPos, ref NativeBitArray srcBitArray, int srcPos, int numBits); // 0x0000000181CA2A10-0x0000000181CA2A30
		public int Find(int pos, int numBits); // 0x0000000181CA2C30-0x0000000181CA2C60
		public int Find(int pos, int count, int numBits); // 0x0000000181CA2C60-0x0000000181CA2C80
		public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1C1A */); // 0x0000000181CA2E50-0x0000000181CA2E80
		public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1C1B */); // 0x0000000181CA2E20-0x0000000181CA2E50
		public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1C1C */); // 0x0000000181CA2DF0-0x0000000181CA2E20
		public int CountBits(int pos, int numBits = 1 /* Metadata: 0x006A1C1D */); // 0x0000000181CA2A60-0x0000000181CA2A90
		public ReadOnly AsReadOnly(); // 0x0000000181CA29A0-0x0000000181CA29D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckReadBounds<T>()
			where T : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
