/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct Sorting // TypeDefIndex: 9509
	{
		// Fields
		public static readonly ProfilingSampler s_QuickSortSampler; // 0x00
		public static readonly ProfilingSampler s_InsertionSortSampler; // 0x08
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass4_0<T> // TypeDefIndex: 9510
		{
			// Fields
			public T[] data;
		}
	
		// Constructors
		static Sorting(); // 0x0000000181F98980-0x0000000181F98A60
	
		// Methods
		public static void QuickSort<T>(T[] data, Func<T, T, int> compare);
		public static void QuickSort<T>(T[] data, int start, int end, Func<T, T, int> compare);
		private static T Median3Pivot<T>(T[] data, int start, int pivot, int end, Func<T, T, int> compare);
		private static int Partition<T>(T[] data, int start, int end, Func<T, T, int> compare);
		public static void InsertionSort<T>(T[] data, Func<T, T, int> compare);
		public static void InsertionSort<T>(T[] data, int start, int end, Func<T, T, int> compare);
		[CompilerGenerated]
		internal static void _Median3Pivot_g__Swap_4_0<T>(int a, int b, ref __c__DisplayClass4_0<T> param_00011e8f);
	}
}
