/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq
{
	internal class GroupedEnumerable<TSource, TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>> // TypeDefIndex: 12008
	{
		// Fields
		private IEnumerable<TSource> source;
		private Func<TSource, TKey> keySelector;
		private Func<TSource, TElement> elementSelector;
		private IEqualityComparer<TKey> comparer;
	
		// Constructors
		public GroupedEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
	
		// Methods
		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
