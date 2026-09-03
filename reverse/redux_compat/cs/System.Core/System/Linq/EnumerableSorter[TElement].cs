/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq
{
	internal abstract class EnumerableSorter<TElement> // TypeDefIndex: 12012
	{
		// Constructors
		protected EnumerableSorter();
	
		// Methods
		internal abstract void ComputeKeys(TElement[] elements, int count);
		internal abstract int CompareKeys(int index1, int index2);
		internal int[] Sort(TElement[] elements, int count);
		private void QuickSort(int[] map, int left, int right);
	}
}
