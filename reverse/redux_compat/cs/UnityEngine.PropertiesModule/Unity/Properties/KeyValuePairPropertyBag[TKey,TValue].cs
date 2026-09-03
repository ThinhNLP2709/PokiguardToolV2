/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public class KeyValuePairPropertyBag<TKey, TValue> : PropertyBag<KeyValuePair<TKey, TValue>>, INamedProperties<KeyValuePair<TKey, TValue>> // TypeDefIndex: 14490
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly DelegateProperty<KeyValuePair<TKey, TValue>, TKey> s_KeyProperty;
		[NoAutoStaticsCleanup]
		private static readonly DelegateProperty<KeyValuePair<TKey, TValue>, TValue> s_ValueProperty;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14491
		{
			// Fields
			public static readonly __c<TKey, TValue> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal TKey _.cctor_b__7_0(ref KeyValuePair<TKey, TValue> container);
			internal TValue _.cctor_b__7_1(ref KeyValuePair<TKey, TValue> container);
		}
	
		[CompilerGenerated]
		private sealed class _GetPropertiesEnumerable_d__4 : IEnumerable<IProperty<KeyValuePair<TKey, TValue>>>, IEnumerator<IProperty<KeyValuePair<TKey, TValue>>> // TypeDefIndex: 14492
		{
			// Fields
			private int __1__state;
			private IProperty<KeyValuePair<TKey, TValue>> __2__current;
			private int __l__initialThreadId;
	
			// Properties
			IProperty<KeyValuePair<TKey, TValue>> IEnumerator<Unity.Properties.IProperty<System.Collections.Generic.KeyValuePair<TKey,TValue>>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetPropertiesEnumerable_d__4(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<IProperty<KeyValuePair<TKey, TValue>>> IEnumerable<IProperty<KeyValuePair<TKey, TValue>>>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public KeyValuePairPropertyBag();
		static KeyValuePairPropertyBag();
	
		// Methods
		public override PropertyCollection<KeyValuePair<TKey, TValue>> GetProperties();
		public override PropertyCollection<KeyValuePair<TKey, TValue>> GetProperties(ref KeyValuePair<TKey, TValue> container);
		[IteratorStateMachine(typeof(_GetPropertiesEnumerable_d__4))]
		private static IEnumerable<IProperty<KeyValuePair<TKey, TValue>>> GetPropertiesEnumerable();
		public bool TryGetProperty(ref KeyValuePair<TKey, TValue> container, string name, out IProperty<KeyValuePair<TKey, TValue>> property);
	}
}
