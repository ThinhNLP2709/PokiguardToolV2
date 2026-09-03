/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	internal sealed class LowLevelListWithIList<T> : LowLevelList<T>, IList<T> // TypeDefIndex: 3603
	{
		// Properties
		bool ICollection<T>.IsReadOnly { get; }
	
		// Nested types
		private struct Enumerator : IEnumerator<T> // TypeDefIndex: 3604
		{
			// Fields
			private LowLevelListWithIList<T> _list;
			private int _index;
			private int _version;
			private T _current;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(LowLevelListWithIList<T> list);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			private bool MoveNextRare();
			void IEnumerator.Reset();
		}
	
		// Constructors
		public LowLevelListWithIList();
		public LowLevelListWithIList(int capacity);
	
		// Methods
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
