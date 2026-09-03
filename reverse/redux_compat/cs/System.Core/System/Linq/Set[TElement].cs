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
	internal class Set<TElement> // TypeDefIndex: 12006
	{
		// Fields
		private int[] buckets;
		private Slot[] slots;
		private int count;
		private int freeList;
		private IEqualityComparer<TElement> comparer;
	
		// Nested types
		internal struct Slot // TypeDefIndex: 12007
		{
			// Fields
			internal int hashCode;
			internal TElement value;
			internal int next;
		}
	
		// Constructors
		public Set(IEqualityComparer<TElement> comparer);
	
		// Methods
		public bool Add(TElement value);
		private bool Find(TElement value, bool add);
		private void Resize();
		internal int InternalGetHashCode(TElement value);
	}
}
