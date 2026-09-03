/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
	[GenerateTestsForBurstCompatibility]
	public struct UnsafeText : INativeDisposable, IUTF8Bytes, INativeList<byte> // TypeDefIndex: 11753
	{
		// Fields
		internal UntypedUnsafeList m_UntypedListData; // 0x00
		public const int MaxCapacity = 2147483646; // Metadata: 0x006A1D54
	
		// Properties
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000181CAD060-0x0000000181CAD070 
		public bool IsEmpty { [IsReadOnly] get; } // 0x0000000181CAD070-0x0000000181CAD090 
		public byte this[int index] { get => default; set {} } // 0x0000000180BF0D10-0x0000000180BF0D20 0x0000000180BF0D70-0x0000000180BF0D80
		public int Capacity { [IsReadOnly] get; set; } // 0x0000000181CAD040-0x0000000181CAD060 0x0000000181CAD090-0x0000000181CAD0A0
		public int Length { [IsReadOnly] get; set; } // 0x00000001808AA130-0x00000001808AA140 0x0000000181CAD0A0-0x0000000181CAD0D0
	
		// Constructors
		public UnsafeText(int capacity, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CACFD0-0x0000000181CAD040
	
		// Methods
		internal static unsafe UnsafeText* Alloc(AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAAAA0-0x0000000181CAAAF0
		internal static unsafe void Free(UnsafeText* data); // 0x0000000181CACE30-0x0000000181CACEB0
		public void Dispose(); // 0x0000000181CACDE0-0x0000000181CACDF0
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CACDF0-0x0000000181CACE30
		public ref byte ElementAt(int index); // 0x00000001808BACC0-0x00000001808BACD0
		public void Clear(); // 0x0000000181CACDB0-0x0000000181CACDE0
		public unsafe byte* GetUnsafePtr(); // 0x00000001808BADD0-0x00000001808BADE0
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1D53 */); // 0x0000000181CACFA0-0x0000000181CACFD0
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public override string ToString(); // 0x0000000181CACF40-0x0000000181CACFA0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckIndexInRange(int index); // 0x0000000181CACC70-0x0000000181CACDB0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowCopyError(CopyError error, string source); // 0x0000000181CACEB0-0x0000000181CACF40
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckCapacityInRange(int value, int length); // 0x0000000181CACB40-0x0000000181CACC70
	}
}
