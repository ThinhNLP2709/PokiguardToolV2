/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class NativeSortExtension // TypeDefIndex: 11613
	{
		// Fields
		private const int k_IntrosortSizeThreshold = 16; // Metadata: 0x006A1C45
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public struct DefaultComparer<T> : IComparer<T> // TypeDefIndex: 11614
			where T : IComparable<T>
		{
			// Methods
			public int Compare(T x, T y);
		}
	
		private struct SortIndicesComparer<T, U> : IComparer<int> // TypeDefIndex: 11615
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>
		{
			// Fields
			internal unsafe T* data;
			internal U comp;
	
			// Methods
			public int Compare(int x, int y);
		}
	
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe int BinarySearch<T>(T* ptr, int length, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static unsafe int BinarySearch<T, U>(T* ptr, int length, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe void Sort<T>(T* ptr, int length)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static unsafe void Sort<T, U>(T* ptr, int length, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe SortJob<T, DefaultComparer<T>> SortJob<T>(T* ptr, int length)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static unsafe SortJob<T, U> SortJob<T, U>(T* ptr, int length, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		internal static unsafe void IntroSort<T, U>(void* array, int length, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		internal static unsafe void IntroSort_R<T, U>(void* array, int lo, int hi, int depth, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void InsertionSort<T, U>(void* array, int lo, int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe int Partition<T, U>(void* array, int lo, int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void HeapSort<T, U>(void* array, int lo, int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void Heapify<T, U>(void* array, int i, int n, int lo, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void Swap<T>(void* array, int lhs, int rhs)
			where T : struct;
		private static unsafe void SwapIfGreaterWithItems<T, U>(void* array, int lhs, int rhs, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void IntroSortStruct<T, U>(void* array, int length, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void IntroSortStruct_R<T, U>(void* array, [IsReadOnly] in int lo, [IsReadOnly] in int _hi, int depth, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void InsertionSortStruct<T, U>(void* array, [IsReadOnly] in int lo, [IsReadOnly] in int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe int PartitionStruct<T, U>(void* array, [IsReadOnly] in int lo, [IsReadOnly] in int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void HeapSortStruct<T, U>(void* array, [IsReadOnly] in int lo, [IsReadOnly] in int hi, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void HeapifyStruct<T, U>(void* array, int i, int n, [IsReadOnly] in int lo, U comp)
			where T : struct
			where U : IComparer<T>;
		private static unsafe void SwapStruct<T>(void* array, int lhs, int rhs)
			where T : struct;
		private static unsafe void SwapIfGreaterWithItemsStruct<T, U>(void* array, int lhs, int rhs, U comp)
			where T : struct
			where U : IComparer<T>;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckStrideMatchesSize<T>(int stride)
			where T : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static unsafe void CheckComparer<T, U>(T* array, int length, U comp)
			where T : struct
			where U : IComparer<T>;
	
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this NativeArray<T> array, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this NativeArray<T> container, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this NativeArray<T> container, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this NativeArray<T> container, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this NativeList<T> container, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this NativeList<T> container, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this UnsafeList<T> container, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this UnsafeList<T> container, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this ReadOnlySpan<T> roSpan, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this ReadOnlySpan<T> roSpan, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int BinarySearch<T>(this NativeSlice<T> container, T value)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static int BinarySearch<T, U>(this NativeSlice<T> container, T value, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this Span<T> span)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void Sort<T, U>(this Span<T> span, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJob<T, DefaultComparer<T>> SortJob<T>(this Span<T> span)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJob<T, U> SortJob<T, U>(this Span<T> span, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this NativeArray<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void Sort<T, U>(this NativeArray<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJob<T, DefaultComparer<T>> SortJob<T>(this NativeArray<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJob<T, U> SortJob<T, U>(this NativeArray<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this NativeList<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void Sort<T, U>(this NativeList<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void SortIndices<T, U>(this Span<int> indices, ReadOnlySpan<T> values, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void SortIndices<T>(this Span<int> indices, ReadOnlySpan<T> values)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJob<T, DefaultComparer<T>> SortJob<T>(this NativeList<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJob<T, U> SortJob<T, U>(this NativeList<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJobDefer<T, DefaultComparer<T>> SortJobDefer<T>(this NativeList<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJobDefer<T, U> SortJobDefer<T, U>(this NativeList<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this UnsafeList<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void Sort<T, U>(this UnsafeList<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJob<T, DefaultComparer<T>> SortJob<T>(this UnsafeList<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJob<T, U> SortJob<T, U>(this UnsafeList<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this NativeSlice<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static void Sort<T, U>(this NativeSlice<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static SortJob<T, DefaultComparer<T>> SortJob<T>(this NativeSlice<T> container)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(DefaultComparer<int>) })]
		public static SortJob<T, U> SortJob<T, U>(this NativeSlice<T> container, U comp)
			where T : struct
			where U : IComparer<T>;
	}
}
