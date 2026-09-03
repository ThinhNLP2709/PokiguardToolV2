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
	internal class ArraySortHelper<TKey, TValue> // TypeDefIndex: 3607
	{
		// Fields
		private static readonly ArraySortHelper<TKey, TValue> s_defaultArraySortHelper;
	
		// Properties
		public static ArraySortHelper<TKey, TValue> Default { get; }
	
		// Constructors
		public ArraySortHelper();
		static ArraySortHelper();
	
		// Methods
		public void Sort(TKey[] keys, TValue[] values, int index, int length, IComparer<TKey> comparer);
		private static void SwapIfGreaterWithItems(TKey[] keys, TValue[] values, IComparer<TKey> comparer, int a, int b);
		private static void Swap(TKey[] keys, TValue[] values, int i, int j);
		internal static void IntrospectiveSort(TKey[] keys, TValue[] values, int left, int length, IComparer<TKey> comparer);
		private static void IntroSort(TKey[] keys, TValue[] values, int lo, int hi, int depthLimit, IComparer<TKey> comparer);
		private static int PickPivotAndPartition(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer);
		private static void Heapsort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer);
		private static void DownHeap(TKey[] keys, TValue[] values, int i, int n, int lo, IComparer<TKey> comparer);
		private static void InsertionSort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer);
	}
}
