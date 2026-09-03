/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal struct Memory // TypeDefIndex: 11549
	{
		// Fields
		internal const long k_MaximumRamSizeInBytes = 1099511627776; // Metadata: 0x006A1C0C
	
		// Nested types
		[GenerateTestsForBurstCompatibility]
		internal struct Unmanaged // TypeDefIndex: 11550
		{
			// Nested types
			[GenerateTestsForBurstCompatibility]
			internal struct Array // TypeDefIndex: 11551
			{
				// Methods
				private static bool IsCustom(AllocatorManager.AllocatorHandle allocator); // 0x0000000181C89240-0x0000000181C89250
				private static unsafe void* CustomResize(void* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator, long size, int align); // 0x0000000181CA0DF0-0x0000000181CA0EC0
				internal static unsafe void* Resize(void* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator, long size, int align); // 0x0000000181CA1140-0x0000000181CA1190
				internal static unsafe void* Resize(void* oldPointer, long oldCount, long newCount, MemoryLabel label, long size, int align); // 0x0000000181CA10F0-0x0000000181CA1140
				private static unsafe void* Resize(void* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator, MemoryLabel label, long size, int align); // 0x0000000181CA0EC0-0x0000000181CA10F0
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe T* Resize<T>(T* oldPointer, long oldCount, long newCount, AllocatorManager.AllocatorHandle allocator)
					where T : struct;
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe T* Resize<T>(T* oldPointer, long oldCount, long newCount, MemoryLabel label)
					where T : struct;
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe T* Allocate<T>(long count, AllocatorManager.AllocatorHandle allocator)
					where T : struct;
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe T* Allocate<T>(long count, MemoryLabel label)
					where T : struct;
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe void Free<T>(T* pointer, long count, AllocatorManager.AllocatorHandle allocator)
					where T : struct;
				[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
				internal static unsafe void Free<T>(T* pointer, long count, MemoryLabel label)
					where T : struct;
			}
	
			// Methods
			internal static unsafe void* Allocate(long size, int align, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAA2A0-0x0000000181CAA2E0
			internal static unsafe void* Allocate(long size, int align, MemoryLabel label); // 0x0000000181CAA260-0x0000000181CAA2A0
			internal static unsafe void Free(void* pointer, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAA330-0x0000000181CAA380
			internal static unsafe void Free(void* pointer, MemoryLabel label); // 0x0000000181CAA2E0-0x0000000181CAA330
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe T* Allocate<T>(AllocatorManager.AllocatorHandle allocator)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe T* Allocate<T>(MemoryLabel label)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe void Free<T>(T* pointer, AllocatorManager.AllocatorHandle allocator)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe void Free<T>(T* pointer, MemoryLabel label)
				where T : struct;
		}
	
		[GenerateTestsForBurstCompatibility]
		internal struct Array // TypeDefIndex: 11552
		{
			// Methods
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe void Set<T>(T* pointer, long count, T t = default)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe void Clear<T>(T* pointer, long count)
				where T : struct;
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			internal static unsafe void Copy<T>(T* dest, T* src, long count)
				where T : struct;
		}
	
		// Methods
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckByteCountIsReasonable(long size); // 0x0000000181CA26C0-0x0000000181CA27E0
		[GenerateTestsForBurstCompatibility]
		internal static MemoryLabel CreateLabel(FixedString32Bytes category, FixedString64Bytes name, Allocator allocator = Allocator.Persistent /* Metadata: 0x006A1C0B */); // 0x0000000181CA27E0-0x0000000181CA2830
	}
}
