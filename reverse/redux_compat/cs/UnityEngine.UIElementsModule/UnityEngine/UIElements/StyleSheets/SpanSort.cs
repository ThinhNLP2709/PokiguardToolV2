/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.NullChecks, false)]
	internal static class SpanSort // TypeDefIndex: 5235
	{
		// Methods
		public static void Sort<T>(Span<T> span, RefComparison<T> comparison);
		private static void QuickSort<T>(Span<T> span, int lo, int hi, RefComparison<T> comparison);
		private static int Partition<T>(Span<T> span, int lo, int hi, RefComparison<T> comparison);
		private static void InsertionSort<T>(Span<T> span, int lo, int hi, RefComparison<T> comparison);
		private static void Swap<T>(Span<T> span, int a, int b);
	}
}
