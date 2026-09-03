/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	internal class ArraySortHelper<T> // TypeDefIndex: 3606
	{
		// Fields
		private static readonly ArraySortHelper<T> s_defaultArraySortHelper;
	
		// Properties
		public static ArraySortHelper<T> Default { get; }
	
		// Constructors
		public ArraySortHelper();
		static ArraySortHelper();
	
		// Methods
		public void Sort(T[] keys, int index, int length, IComparer<T> comparer);
		public int BinarySearch(T[] array, int index, int length, T value, IComparer<T> comparer);
		internal static void Sort(T[] keys, int index, int length, Comparison<T> comparer);
		internal static int InternalBinarySearch(T[] array, int index, int length, T value, IComparer<T> comparer);
		private static void SwapIfGreater(T[] keys, Comparison<T> comparer, int a, int b);
		private static void Swap(T[] a, int i, int j);
		internal static void IntrospectiveSort(T[] keys, int left, int length, Comparison<T> comparer);
		private static void IntroSort(T[] keys, int lo, int hi, int depthLimit, Comparison<T> comparer);
		private static int PickPivotAndPartition(T[] keys, int lo, int hi, Comparison<T> comparer);
		private static void Heapsort(T[] keys, int lo, int hi, Comparison<T> comparer);
		private static void DownHeap(T[] keys, int i, int n, int lo, Comparison<T> comparer);
		private static void InsertionSort(T[] keys, int lo, int hi, Comparison<T> comparer);
	}
}
