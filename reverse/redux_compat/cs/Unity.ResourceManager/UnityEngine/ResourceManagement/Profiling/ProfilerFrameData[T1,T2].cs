/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Profiling
{
	internal class ProfilerFrameData<T1, T2> // TypeDefIndex: 13785
	{
		// Fields
		private Dictionary<T1, T2> m_Data;
		private T2[] m_Array;
		private uint m_Version;
		private uint m_ArrayVersion;
	
		// Properties
		internal Dictionary<T1, T2> Data { get; }
		public T2[] Values { get; }
		public T2 this[T1 key] { get => default; set {} }
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Enumerate_d__17 : IEnumerable<KeyValuePair<T1, T2>>, IEnumerator<KeyValuePair<T1, T2>> // TypeDefIndex: 13786
		{
			// Fields
			private int __1__state;
			private KeyValuePair<T1, T2> __2__current;
			private int __l__initialThreadId;
			public ProfilerFrameData<T1, T2> __4__this;
			private Dictionary<T1, T2> __7__wrap1;
	
			// Properties
			KeyValuePair<T1, T2> IEnumerator<System.Collections.Generic.KeyValuePair<T1,T2>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _Enumerate_d__17(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<KeyValuePair<T1, T2>> IEnumerable<KeyValuePair<T1, T2>>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public ProfilerFrameData();
		public ProfilerFrameData(int count);
	
		// Methods
		public bool Add(T1 key, T2 value);
		internal bool Remove(T1 key);
		public bool TryGetValue(T1 key, out ref T2 value);
		public bool ContainsKey(T1 key);
		[IteratorStateMachine(typeof(_Enumerate_d__17))]
		public IEnumerable<KeyValuePair<T1, T2>> Enumerate();
	}
}
