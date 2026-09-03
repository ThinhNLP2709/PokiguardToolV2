/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class NativeArrayExtensions // TypeDefIndex: 11553
	{
		// Nested types
		public struct NativeArrayStaticId<T> // TypeDefIndex: 11554
			where T : struct
		{
			// Fields
			internal static readonly SharedStatic<int> s_staticSafetyId;
	
			// Constructors
			static NativeArrayStaticId();
		}
	
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static unsafe bool Contains<T, U>(T* ptr, int length, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static unsafe int IndexOf<T, U>(T* ptr, int length, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static int IndexOf<T, U>(ReadOnlySpan<T> roSpan, U value)
			where T : struct, IEquatable<U>;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckReinterpretSize<T, U>(ref NativeArray<T> array)
			where T : struct
			where U : struct;
	
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Contains<T, U>(this NativeArray<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static int IndexOf<T, U>(this NativeArray<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Contains<T, U>(this NativeArray<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static int IndexOf<T, U>(this NativeArray<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Contains<T, U>(this NativeList<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static int IndexOf<T, U>(this NativeList<T> container, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static bool Contains<T, U>(this ReadOnlySpan<T> roSpan, U value)
			where T : struct, IEquatable<U>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void CopyFrom<T>(this ref NativeArray<T> container, NativeList<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void CopyFrom<T>(this ref NativeArray<T> container, [IsReadOnly] in NativeHashSet<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void CopyFrom<T>(this ref NativeArray<T> container, [IsReadOnly] in UnsafeHashSet<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static NativeArray<U> Reinterpret<T, U>(this NativeArray<T> array)
			where T : struct
			where U : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static bool ArraysEqual<T>(this NativeArray<T> container, NativeArray<T> other)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static void Initialize<T>(this ref NativeArray<T> array, int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C14 */)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(AllocatorManager.AllocatorHandle) })]
		internal static void Initialize<T, U>(this ref NativeArray<T> array, int length, ref ref U allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C15 */)
			where T : struct
			where U : struct, AllocatorManager.IAllocator;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static void DisposeCheckAllocator<T>(this ref NativeArray<T> array)
			where T : struct;
	}
}
