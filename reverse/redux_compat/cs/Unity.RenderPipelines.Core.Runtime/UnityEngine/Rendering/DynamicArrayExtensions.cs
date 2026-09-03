/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class DynamicArrayExtensions // TypeDefIndex: 5365
	{
		// Methods
		private static int Partition<T>(Span<T> data, int left, int right)
			where T : IComparable<T>, new();
		private static void QuickSort<T>(Span<T> data, int left, int right)
			where T : IComparable<T>, new();
		private static int Partition<T>(Span<T> data, int left, int right, DynamicArray<T> comparer)
			where T : new();
		private static void QuickSort<T>(Span<T> data, int left, int right, DynamicArray<T> comparer)
			where T : new();
	
		// Extension methods
		public static void QuickSort<T>(this DynamicArray<T> array)
			where T : IComparable<T>, new();
		public static void QuickSort<T>(this DynamicArray<T> array, DynamicArray<T> comparer)
			where T : new();
	}
}
