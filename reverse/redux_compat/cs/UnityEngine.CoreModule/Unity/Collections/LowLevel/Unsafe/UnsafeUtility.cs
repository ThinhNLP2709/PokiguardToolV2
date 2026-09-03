/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections.LowLevel.Unsafe
{
	[NativeHeader("ManagedKernel/Unsafe/UnsafeUtility.bindings.h")]
	[StaticAccessor("UnsafeUtility", StaticAccessorType.DoubleColon)]
	public static class UnsafeUtility // TypeDefIndex: 7453
	{
		// Nested types
		internal struct TypeFlagsCache<T> // TypeDefIndex: 7454
		{
			// Fields
			internal static readonly int flags;
	
			// Constructors
			static TypeFlagsCache();
	
			// Methods
			[BurstDiscard]
			private static void Init(ref int flags);
		}
	
		// Methods
		public static bool IsBlittable<T>()
			where T : struct;
		[BurstAuthorizedExternalMethod]
		[NativeMethod(IsThreadSafe = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.AIModule" })]
		internal static int LeakRecord(IntPtr handle, LeakCategory category, int callstacksToSkip); // 0x000000018219B480-0x000000018219B4D0
		[BurstAuthorizedExternalMethod]
		[NativeMethod(IsThreadSafe = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.AIModule" })]
		internal static int LeakErase(IntPtr handle, LeakCategory category); // 0x000000018219B440-0x000000018219B480
		public static unsafe void* MallocTracked(long size, int alignment, Allocator allocator, int callstacksToSkip); // 0x000000018219B550-0x000000018219B5C0
		public static unsafe void* MallocTracked(long size, int alignment, MemoryLabel label, int callstacksToSkip); // 0x000000018219B4D0-0x000000018219B550
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		internal static unsafe void* MallocTracked(long size, int alignment, Allocator allocator, int callstacksToSkip, IntPtr label); // 0x000000018219B5C0-0x000000018219B620
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void FreeTracked(void* memory, Allocator allocator); // 0x000000018219AF10-0x000000018219AF50
		public static unsafe void FreeTracked(void* memory, MemoryLabel label); // 0x000000018219AEC0-0x000000018219AF10
		public static unsafe void* Malloc(long size, int alignment, Allocator allocator); // 0x000000018219B6F0-0x000000018219B750
		public static unsafe void* Malloc(long size, int alignment, MemoryLabel label); // 0x000000018219B680-0x000000018219B6F0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		private static unsafe void* Malloc(long size, int alignment, Allocator allocator, IntPtr label); // 0x000000018219B620-0x000000018219B680
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static unsafe void* Realloc(void* memory, long size, int alignment, MemoryLabel label); // 0x000000018219BA60-0x000000018219BAE0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		private static unsafe void* Realloc(void* memory, long size, int alignment, Allocator allocator, IntPtr label); // 0x000000018219B9F0-0x000000018219BA60
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void Free(void* memory, Allocator allocator); // 0x000000018219AFA0-0x000000018219AFE0
		public static unsafe void Free(void* memory, MemoryLabel label); // 0x000000018219AF50-0x000000018219AFA0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void MemCpy(void* destination, void* source, long size); // 0x000000018219B8D0-0x000000018219B930
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void MemCpyReplicate(void* destination, void* source, int size, int count); // 0x000000018219B800-0x000000018219B870
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void MemCpyStride(void* destination, int destinationStride, void* source, int sourceStride, int elementSize, int count); // 0x000000018219B870-0x000000018219B8D0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void MemMove(void* destination, void* source, long size); // 0x000000018219B930-0x000000018219B990
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe void MemSet(void* destination, byte value, long size); // 0x000000018219B990-0x000000018219B9F0
		public static unsafe void MemClear(void* destination, long size); // 0x000000018219B750-0x000000018219B7A0
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		public static unsafe int MemCmp(void* ptr1, void* ptr2, long size); // 0x000000018219B7A0-0x000000018219B800
		[NativeMethod(IsThreadSafe = true)]
		public static int SizeOf(Type type); // 0x000000018219BAE0-0x000000018219BB20
		[NativeMethod(IsThreadSafe = true)]
		public static bool IsBlittable(Type type); // 0x000000018219B400-0x000000018219B440
		[NativeMethod(IsThreadSafe = true)]
		internal static int GetScriptingTypeFlags(Type type); // 0x000000018219B2F0-0x000000018219B330
		private static bool IsBlittableValueType(Type t); // 0x000000018219B3B0-0x000000018219B400
		private static string GetReasonForTypeNonBlittableImpl(Type t, string name); // 0x000000018219B0E0-0x000000018219B2F0
		internal static bool IsArrayBlittable(Array arr); // 0x000000018219B330-0x000000018219B3B0
		internal static bool IsGenericListBlittable<T>()
			where T : struct;
		internal static string GetReasonForArrayNonBlittable(Array arr); // 0x000000018219B070-0x000000018219B0E0
		internal static string GetReasonForGenericListNonBlittable<T>()
			where T : struct;
		public static bool IsUnmanaged<T>();
		[VisibleToOtherModules(new string[1] {"UnityEngine.ImageConversionModule" })]
		internal static Span<byte> GetByteSpanFromArray(Array array, int arraySize, int elementSize); // 0x000000018219AFE0-0x000000018219B070
		[VisibleToOtherModules(new string[1] {"UnityEngine.AdaptivePerformanceModule" })]
		internal static Span<byte> GetByteSpanFromList<T>(List<T> list)
			where T : struct;
		public static unsafe void CopyPtrToStructure<T>(void* ptr, out ref T output)
			where T : struct;
		public static unsafe void CopyStructureToPtr<T>(ref ref T input, void* ptr)
			where T : struct;
		public static unsafe T ReadArrayElement<T>(void* source, int index);
		public static unsafe T ReadArrayElementWithStride<T>(void* source, int index, int stride);
		public static unsafe void WriteArrayElement<T>(void* destination, int index, T value);
		public static unsafe void WriteArrayElementWithStride<T>(void* destination, int index, int stride, T value);
		public static unsafe void* AddressOf<T>(ref ref T output)
			where T : struct;
		public static int SizeOf<T>()
			where T : struct;
		public static int AlignOf<T>()
			where T : struct;
		public static ref ref T As<U, T>(ref ref U from);
		internal static T As<T>(object from)
			where T : class;
		public static unsafe ref ref T AsRef<T>(void* ptr)
			where T : struct;
		public static unsafe ref ref T ArrayElementAsRef<T>(void* ptr, int index)
			where T : struct;
		public static int EnumToInt<T>(T enumValue)
			where T : struct, IConvertible;
		public static bool EnumEquals<T>(T lhs, T rhs)
			where T : struct, IConvertible;
		internal static ref ref T Add<T>(ref ref T source, int elementOffset)
			where T : struct;
	}
}
