/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal static class MiscHelpers // TypeDefIndex: 6611
	{
		// Nested types
		[CompilerGenerated]
		private sealed class _EveryNth_d__1<TValue> : IEnumerable<TValue>, IEnumerator<TValue> // TypeDefIndex: 6612
		{
			// Fields
			private int __1__state;
			private TValue __2__current;
			private int __l__initialThreadId;
			private IEnumerable<TValue> enumerable;
			public IEnumerable<TValue> __3__enumerable;
			private int start;
			public int __3__start;
			private int n;
			public int __3__n;
			private int _index_5__2;
			private IEnumerator<TValue> __7__wrap2;
	
			// Properties
			TValue IEnumerator<TValue>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _EveryNth_d__1(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Extension methods
		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key);
		[IteratorStateMachine(typeof(_EveryNth_d__1<TValue>))]
		public static IEnumerable<TValue> EveryNth<TValue>(this IEnumerable<TValue> enumerable, int n, int start = 0 /* Metadata: 0x006991B5 */);
		public static int IndexOf<TValue>(this IEnumerable<TValue> enumerable, TValue value);
	}
}
