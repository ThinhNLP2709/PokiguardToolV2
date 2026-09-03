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
	internal class OrderedEnumerable<TElement, TKey> : OrderedEnumerable<TElement> // TypeDefIndex: 12011
	{
		// Fields
		internal OrderedEnumerable<TElement> parent;
		internal Func<TElement, TKey> keySelector;
		internal IComparer<TKey> comparer;
		internal bool descending;
	
		// Constructors
		internal OrderedEnumerable(IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
	
		// Methods
		internal override EnumerableSorter<TElement> GetEnumerableSorter(EnumerableSorter<TElement> next);
	}
}
