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

namespace System.Linq.Expressions.Interpreter
{
	internal class HybridReferenceDictionary<TKey, TValue> // TypeDefIndex: 12533
		where TKey : class
	{
		// Fields
		private KeyValuePair<TKey, TValue>[] _keysAndValues;
		private Dictionary<TKey, TValue> _dict;
	
		// Properties
		public TValue this[TKey key] { get => default; set {} }
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetEnumeratorWorker_d__7 : IEnumerator<KeyValuePair<TKey, TValue>> // TypeDefIndex: 12534
		{
			// Fields
			private int __1__state;
			private KeyValuePair<TKey, TValue> __2__current;
			public HybridReferenceDictionary<TKey, TValue> __4__this;
			private int _i_5__2;
	
			// Properties
			KeyValuePair<TKey, TValue> IEnumerator<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumeratorWorker_d__7(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
		}
	
		// Constructors
		public HybridReferenceDictionary();
	
		// Methods
		public bool TryGetValue(TKey key, out ref TValue value);
		public void Remove(TKey key);
		public bool ContainsKey(TKey key);
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
		[IteratorStateMachine(typeof(_GetEnumeratorWorker_d__7))]
		private IEnumerator<KeyValuePair<TKey, TValue>> GetEnumeratorWorker();
	}
}
