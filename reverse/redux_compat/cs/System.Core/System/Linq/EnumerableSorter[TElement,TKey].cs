/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq
{
	internal class EnumerableSorter<TElement, TKey> : EnumerableSorter<TElement> // TypeDefIndex: 12013
	{
		// Fields
		internal Func<TElement, TKey> keySelector;
		internal IComparer<TKey> comparer;
		internal bool descending;
		internal EnumerableSorter<TElement> next;
		internal TKey[] keys;
	
		// Constructors
		internal EnumerableSorter(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending, EnumerableSorter<TElement> next);
	
		// Methods
		internal override void ComputeKeys(TElement[] elements, int count);
		internal override int CompareKeys(int index1, int index2);
	}
}
