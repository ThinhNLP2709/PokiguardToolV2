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
	internal abstract class OrderedEnumerable<TElement> : IOrderedEnumerable<TElement> // TypeDefIndex: 12009
	{
		// Fields
		internal IEnumerable<TElement> source;
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__1 : IEnumerator<TElement> // TypeDefIndex: 12010
		{
			// Fields
			private int __1__state;
			private TElement __2__current;
			public OrderedEnumerable<TElement> __4__this;
			private Buffer<TElement> _buffer_5__2;
			private int[] _map_5__3;
			private int _i_5__4;
	
			// Properties
			TElement IEnumerator<TElement>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__1(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
		}
	
		// Constructors
		protected OrderedEnumerable();
	
		// Methods
		[IteratorStateMachine(typeof(_GetEnumerator_d__1))]
		public IEnumerator<TElement> GetEnumerator();
		internal abstract EnumerableSorter<TElement> GetEnumerableSorter(EnumerableSorter<TElement> next);
		IEnumerator IEnumerable.GetEnumerator();
		IOrderedEnumerable<TElement> IOrderedEnumerable<TElement>.CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
	}
}
