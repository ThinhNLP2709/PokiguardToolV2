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
	[DefaultMember("Item")]
	public class Lookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>> // TypeDefIndex: 12002
	{
		// Fields
		private IEqualityComparer<TKey> comparer;
		private Grouping[] groupings;
		private Grouping lastGrouping;
		private int count;
	
		// Nested types
		internal class Grouping : IGrouping<TKey, TElement>, IList<TElement> // TypeDefIndex: 12003
		{
			// Fields
			internal TKey key;
			internal int hashCode;
			internal TElement[] elements;
			internal int count;
			internal Grouping<TKey, TElement> hashNext;
			internal Grouping<TKey, TElement> next;
	
			// Properties
			int ICollection<TElement>.Count { get; }
			bool ICollection<TElement>.IsReadOnly { get; }
			TElement IList<TElement>.this[int index] { get => default; set {} }
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetEnumerator_d__7 : IEnumerator<TElement> // TypeDefIndex: 12004
			{
				// Fields
				private int __1__state;
				private TElement __2__current;
				public Grouping<TKey, TElement> __4__this;
				private int _i_5__2;
	
				// Properties
				TElement IEnumerator<TElement>.Current { [DebuggerHidden] get; }
				object IEnumerator.Current { [DebuggerHidden] get; }
	
				// Constructors
				[DebuggerHidden]
				public _GetEnumerator_d__7(int __1__state);
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose();
				private bool MoveNext();
				[DebuggerHidden]
				void IEnumerator.Reset();
			}
	
			// Constructors
			public Grouping();
	
			// Methods
			internal void Add(TElement element);
			[IteratorStateMachine(typeof(_GetEnumerator_d__7))]
			public IEnumerator<TElement> GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			void ICollection<TElement>.Add(TElement item);
			void ICollection<TElement>.Clear();
			bool ICollection<TElement>.Contains(TElement item);
			void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex);
			bool ICollection<TElement>.Remove(TElement item);
			int IList<TElement>.IndexOf(TElement item);
			void IList<TElement>.Insert(int index, TElement item);
			void IList<TElement>.RemoveAt(int index);
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__12 : IEnumerator<IGrouping<TKey, TElement>> // TypeDefIndex: 12005
		{
			// Fields
			private int __1__state;
			private IGrouping<TKey, TElement> __2__current;
			public Lookup<TKey, TElement> __4__this;
			private Grouping<TKey, TElement> _g_5__2;
	
			// Properties
			IGrouping<TKey, TElement> IEnumerator<System.Linq.IGrouping<TKey,TElement>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__12(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
		}
	
		// Constructors
		private Lookup(IEqualityComparer<TKey> comparer);
	
		// Methods
		internal static Lookup<TKey, TElement> Create<TSource>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
		[IteratorStateMachine(typeof(_GetEnumerator_d__12))]
		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		internal int InternalGetHashCode(TKey key);
		internal Grouping GetGrouping(TKey key, bool create);
		private void Resize();
	}
}
