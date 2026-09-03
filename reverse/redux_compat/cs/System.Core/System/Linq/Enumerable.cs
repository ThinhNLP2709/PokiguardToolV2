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
	public static class Enumerable // TypeDefIndex: 11978
	{
		// Nested types
		private abstract class Iterator<TSource> : IEnumerable<TSource>, IEnumerator<TSource> // TypeDefIndex: 11979
		{
			// Fields
			private int threadId;
			internal int state;
			internal TSource current;
	
			// Properties
			public TSource Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Iterator();
	
			// Methods
			public abstract Iterator<TSource> Clone();
			public virtual void Dispose();
			public IEnumerator<TSource> GetEnumerator();
			public abstract bool MoveNext();
			public abstract IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
			public abstract IEnumerable<TSource> Where(Func<TSource, bool> predicate);
			IEnumerator IEnumerable.GetEnumerator();
			void IEnumerator.Reset();
		}
	
		private class WhereEnumerableIterator<TSource> : Iterator<TSource> // TypeDefIndex: 11980
		{
			// Fields
			private IEnumerable<TSource> source;
			private Func<TSource, bool> predicate;
			private IEnumerator<TSource> enumerator;
	
			// Constructors
			public WhereEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate);
	
			// Methods
			public override Iterator<TSource> Clone();
			public override void Dispose();
			public override bool MoveNext();
			public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
			public override IEnumerable<TSource> Where(Func<TSource, bool> predicate);
		}
	
		private class WhereArrayIterator<TSource> : Iterator<TSource> // TypeDefIndex: 11981
		{
			// Fields
			private TSource[] source;
			private Func<TSource, bool> predicate;
			private int index;
	
			// Constructors
			public WhereArrayIterator(TSource[] source, Func<TSource, bool> predicate);
	
			// Methods
			public override Iterator<TSource> Clone();
			public override bool MoveNext();
			public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
			public override IEnumerable<TSource> Where(Func<TSource, bool> predicate);
		}
	
		private class WhereListIterator<TSource> : Iterator<TSource> // TypeDefIndex: 11982
		{
			// Fields
			private List<TSource> source;
			private Func<TSource, bool> predicate;
			private List<TSource> enumerator;
	
			// Constructors
			public WhereListIterator(List<TSource> source, Func<TSource, bool> predicate);
	
			// Methods
			public override Iterator<TSource> Clone();
			public override bool MoveNext();
			public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
			public override IEnumerable<TSource> Where(Func<TSource, bool> predicate);
		}
	
		private class WhereSelectEnumerableIterator<TSource, TResult> : Iterator<TResult> // TypeDefIndex: 11983
		{
			// Fields
			private IEnumerable<TSource> source;
			private Func<TSource, bool> predicate;
			private Func<TSource, TResult> selector;
			private IEnumerator<TSource> enumerator;
	
			// Constructors
			public WhereSelectEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector);
	
			// Methods
			public override Iterator<TResult> Clone();
			public override void Dispose();
			public override bool MoveNext();
			public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector);
			public override IEnumerable<TResult> Where(Func<TResult, bool> predicate);
		}
	
		private class WhereSelectArrayIterator<TSource, TResult> : Iterator<TResult> // TypeDefIndex: 11984
		{
			// Fields
			private TSource[] source;
			private Func<TSource, bool> predicate;
			private Func<TSource, TResult> selector;
			private int index;
	
			// Constructors
			public WhereSelectArrayIterator(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector);
	
			// Methods
			public override Iterator<TResult> Clone();
			public override bool MoveNext();
			public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector);
			public override IEnumerable<TResult> Where(Func<TResult, bool> predicate);
		}
	
		private class WhereSelectListIterator<TSource, TResult> : Iterator<TResult> // TypeDefIndex: 11985
		{
			// Fields
			private List<TSource> source;
			private Func<TSource, bool> predicate;
			private Func<TSource, TResult> selector;
			private List<TSource> enumerator;
	
			// Constructors
			public WhereSelectListIterator(List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector);
	
			// Methods
			public override Iterator<TResult> Clone();
			public override bool MoveNext();
			public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector);
			public override IEnumerable<TResult> Where(Func<TResult, bool> predicate);
		}
	
		[CompilerGenerated]
		private sealed class _SelectIterator_d__5<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult> // TypeDefIndex: 11986
		{
			// Fields
			private int __1__state;
			private TResult __2__current;
			private int __l__initialThreadId;
			private IEnumerable<TSource> source;
			public IEnumerable<TSource> __3__source;
			private Func<TSource, int, TResult> selector;
			public Func<TSource, int, TResult> __3__selector;
			private int _index_5__2;
			private IEnumerator<TSource> __7__wrap2;
	
			// Properties
			TResult IEnumerator<TResult>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _SelectIterator_d__5(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0<TSource> // TypeDefIndex: 11987
		{
			// Fields
			public Func<TSource, bool> predicate1;
			public Func<TSource, bool> predicate2;
	
			// Constructors
			public __c__DisplayClass6_0();
	
			// Methods
			internal bool _CombinePredicates_b__0(TSource x);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0<TSource, TMiddle, TResult> // TypeDefIndex: 11988
		{
			// Fields
			public Func<TMiddle, TResult> selector2;
			public Func<TSource, TMiddle> selector1;
	
			// Constructors
			public __c__DisplayClass7_0();
	
			// Methods
			internal TResult _CombineSelectors_b__0(TSource x);
		}
	
		[CompilerGenerated]
		private sealed class _SelectManyIterator_d__17<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult> // TypeDefIndex: 11989
		{
			// Fields
			private int __1__state;
			private TResult __2__current;
			private int __l__initialThreadId;
			private IEnumerable<TSource> source;
			public IEnumerable<TSource> __3__source;
			private Func<TSource, IEnumerable<TResult>> selector;
			public Func<TSource, IEnumerable<TResult>> __3__selector;
			private IEnumerator<TSource> __7__wrap1;
			private IEnumerator<TResult> __7__wrap2;
	
			// Properties
			TResult IEnumerator<TResult>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _SelectManyIterator_d__17(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			private void __m__Finally2();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _SkipIterator_d__31<TSource> : IEnumerable<TSource>, IEnumerator<TSource> // TypeDefIndex: 11990
		{
			// Fields
			private int __1__state;
			private TSource __2__current;
			private int __l__initialThreadId;
			private IEnumerable<TSource> source;
			public IEnumerable<TSource> __3__source;
			private int count;
			public int __3__count;
			private IEnumerator<TSource> _e_5__2;
	
			// Properties
			TSource IEnumerator<TSource>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _SkipIterator_d__31(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _DistinctIterator_d__68<TSource> : IEnumerable<TSource>, IEnumerator<TSource> // TypeDefIndex: 11991
		{
			// Fields
			private int __1__state;
			private TSource __2__current;
			private int __l__initialThreadId;
			private IEqualityComparer<TSource> comparer;
			public IEqualityComparer<TSource> __3__comparer;
			private IEnumerable<TSource> source;
			public IEnumerable<TSource> __3__source;
			private Set<TSource> _set_5__2;
			private IEnumerator<TSource> __7__wrap2;
	
			// Properties
			TSource IEnumerator<TSource>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _DistinctIterator_d__68(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _UnionIterator_d__71<TSource> : IEnumerable<TSource>, IEnumerator<TSource> // TypeDefIndex: 11992
		{
			// Fields
			private int __1__state;
			private TSource __2__current;
			private int __l__initialThreadId;
			private IEqualityComparer<TSource> comparer;
			public IEqualityComparer<TSource> __3__comparer;
			private IEnumerable<TSource> first;
			public IEnumerable<TSource> __3__first;
			private IEnumerable<TSource> second;
			public IEnumerable<TSource> __3__second;
			private Set<TSource> _set_5__2;
			private IEnumerator<TSource> __7__wrap2;
	
			// Properties
			TSource IEnumerator<TSource>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _UnionIterator_d__71(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			private void __m__Finally2();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _ReverseIterator_d__79<TSource> : IEnumerable<TSource>, IEnumerator<TSource> // TypeDefIndex: 11993
		{
			// Fields
			private int __1__state;
			private TSource __2__current;
			private int __l__initialThreadId;
			private IEnumerable<TSource> source;
			public IEnumerable<TSource> __3__source;
			private Buffer<TSource> _buffer_5__2;
			private int _i_5__3;
	
			// Properties
			TSource IEnumerator<TSource>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _ReverseIterator_d__79(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _OfTypeIterator_d__97<TResult> : IEnumerable<TResult>, IEnumerator<TResult> // TypeDefIndex: 11994
		{
			// Fields
			private int __1__state;
			private TResult __2__current;
			private int __l__initialThreadId;
			private IEnumerable source;
			public IEnumerable __3__source;
			private IEnumerator __7__wrap1;
	
			// Properties
			TResult IEnumerator<TResult>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _OfTypeIterator_d__97(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _CastIterator_d__99<TResult> : IEnumerable<TResult>, IEnumerator<TResult> // TypeDefIndex: 11995
		{
			// Fields
			private int __1__state;
			private TResult __2__current;
			private int __l__initialThreadId;
			private IEnumerable source;
			public IEnumerable __3__source;
			private IEnumerator __7__wrap1;
	
			// Properties
			TResult IEnumerator<TResult>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _CastIterator_d__99(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _RangeIterator_d__115 : IEnumerable<int>, IEnumerator<int> // TypeDefIndex: 11996
		{
			// Fields
			private int __1__state; // 0x10
			private int __2__current; // 0x14
			private int __l__initialThreadId; // 0x18
			private int start; // 0x1C
			public int __3__start; // 0x20
			private int count; // 0x24
			public int __3__count; // 0x28
			private int _i_5__2; // 0x2C
	
			// Properties
			int IEnumerator<System.Int32>.Current { [DebuggerHidden] get; } // 0x0000000180A5E110-0x0000000180A5E120 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001817A6C30-0x00000001817A7070 
	
			// Constructors
			[DebuggerHidden]
			public _RangeIterator_d__115(int __1__state); // 0x0000000180A5E820-0x0000000180A5E850
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001817A6B10-0x00000001817A6B50
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001817A6BF0-0x00000001817A6C30
			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator(); // 0x00000001817A6B50-0x00000001817A6BF0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817A6B50-0x00000001817A6BF0
		}
	
		// Methods
		[IteratorStateMachine(typeof(_SelectIterator_d__5<TSource, TResult>))]
		private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
		private static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> predicate1, Func<TSource, bool> predicate2);
		private static Func<TSource, TResult> CombineSelectors<TSource, TMiddle, TResult>(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2);
		[IteratorStateMachine(typeof(_SelectManyIterator_d__17<TSource, TResult>))]
		private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
		[IteratorStateMachine(typeof(_SkipIterator_d__31<TSource>))]
		private static IEnumerable<TSource> SkipIterator<TSource>(IEnumerable<TSource> source, int count);
		[IteratorStateMachine(typeof(_DistinctIterator_d__68<TSource>))]
		private static IEnumerable<TSource> DistinctIterator<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer);
		[IteratorStateMachine(typeof(_UnionIterator_d__71<TSource>))]
		private static IEnumerable<TSource> UnionIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
		[IteratorStateMachine(typeof(_ReverseIterator_d__79<TSource>))]
		private static IEnumerable<TSource> ReverseIterator<TSource>(IEnumerable<TSource> source);
		[IteratorStateMachine(typeof(_OfTypeIterator_d__97<TResult>))]
		private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source);
		[IteratorStateMachine(typeof(_CastIterator_d__99<TResult>))]
		private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source);
		public static IEnumerable<int> Range(int start, int count); // 0x000000018178C970-0x000000018178CA30
		[IteratorStateMachine(typeof(_RangeIterator_d__115))]
		private static IEnumerable<int> RangeIterator(int start, int count); // 0x000000018178C8F0-0x000000018178C970
		public static IEnumerable<TResult> Empty<TResult>();
	
		// Extension methods
		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
		public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
		public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
		public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer);
		public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
		public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source);
		public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
		public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
		public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);
		public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source);
		public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
		public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source);
		public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source);
		public static TSource First<TSource>(this IEnumerable<TSource> source);
		public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source);
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static TSource Last<TSource>(this IEnumerable<TSource> source);
		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source);
		public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static TSource Single<TSource>(this IEnumerable<TSource> source);
		public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source);
		public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index);
		public static bool Any<TSource>(this IEnumerable<TSource> source);
		public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static int Count<TSource>(this IEnumerable<TSource> source);
		public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
		public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);
		public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
		public static int Max(this IEnumerable<int> source); // 0x000000018178C630-0x000000018178C8F0
		public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
	}
}
