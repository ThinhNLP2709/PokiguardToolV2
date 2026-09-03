/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties.Internal
{
	internal class ReflectedPropertyBagProvider // TypeDefIndex: 14596
	{
		// Fields
		private readonly MethodInfo m_CreatePropertyMethod; // 0x10
		private readonly MethodInfo m_CreatePropertyBagMethod; // 0x18
		private readonly MethodInfo m_CreateIndexedCollectionPropertyBagMethod; // 0x20
		private readonly MethodInfo m_CreateSetPropertyBagMethod; // 0x28
		private readonly MethodInfo m_CreateKeyValueCollectionPropertyBagMethod; // 0x30
		private readonly MethodInfo m_CreateKeyValuePairPropertyBagMethod; // 0x38
		private readonly MethodInfo m_CreateArrayPropertyBagMethod; // 0x40
		private readonly MethodInfo m_CreateListPropertyBagMethod; // 0x48
		private readonly MethodInfo m_CreateHashSetPropertyBagMethod; // 0x50
		private readonly MethodInfo m_CreateDictionaryPropertyBagMethod; // 0x58
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 14597
		{
			// Fields
			public static Predicate<Type> _0___IsValidPropertyType; // 0x00
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14598
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<MethodInfo, bool> __9__10_0; // 0x08
			public static Func<MemberInfo, int> __9__22_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001822E5220-0x00000001822E5290
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.ctor_b__10_0(MethodInfo x); // 0x00000001822E5050-0x00000001822E50D0
			internal int _GetPropertyMembers_b__22_0(MemberInfo x); // 0x0000000180A68E00-0x0000000180A68E30
		}
	
		[CompilerGenerated]
		private sealed class _GetPropertyMembers_d__22 : IEnumerable<MemberInfo>, IEnumerator<MemberInfo> // TypeDefIndex: 14599
		{
			// Fields
			private int __1__state; // 0x10
			private MemberInfo __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private Type type; // 0x28
			public Type __3__type; // 0x30
			private IEnumerator<MemberInfo> __7__wrap1; // 0x38
	
			// Properties
			MemberInfo IEnumerator<System.Reflection.MemberInfo>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetPropertyMembers_d__22(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001822E4E50-0x00000001822E4F30
			private bool MoveNext(); // 0x00000001822E45C0-0x00000001822E4D70
			private void __m__Finally1(); // 0x00000001822E4F30-0x00000001822E4F80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001822E4E10-0x00000001822E4E50
			[DebuggerHidden]
			IEnumerator<MemberInfo> IEnumerable<MemberInfo>.GetEnumerator(); // 0x00000001822E4D70-0x00000001822E4E10
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001822E4D70-0x00000001822E4E10
		}
	
		// Constructors
		public ReflectedPropertyBagProvider(); // 0x00000001822E2110-0x00000001822E2520
	
		// Methods
		public IPropertyBag CreatePropertyBag(Type type); // 0x00000001822E1D00-0x00000001822E1E50
		public IPropertyBag<TContainer> CreatePropertyBag<TContainer>();
		private void CreateProperty<TContainer, TValue>(IMemberInfo member, ReflectedPropertyBag<TContainer> propertyBag);
		private IPropertyBag<TList> CreateIndexedCollectionPropertyBag<TList, TElement>()
			where TList : IList<TElement>;
		private IPropertyBag<TSet> CreateSetPropertyBag<TSet, TValue>()
			where TSet : ISet<TValue>;
		private IPropertyBag<TDictionary> CreateKeyValueCollectionPropertyBag<TDictionary, TKey, TValue>()
			where TDictionary : IDictionary<TKey, TValue>;
		private IPropertyBag<KeyValuePair<TKey, TValue>> CreateKeyValuePairPropertyBag<TKey, TValue>();
		private IPropertyBag<TElement[]> CreateArrayPropertyBag<TElement>();
		private IPropertyBag<List<TElement>> CreateListPropertyBag<TElement>();
		private IPropertyBag<HashSet<TElement>> CreateHashSetPropertyBag<TElement>();
		private IPropertyBag<Dictionary<TKey, TValue>> CreateDictionaryPropertyBag<TKey, TValue>();
		[IteratorStateMachine(typeof(_GetPropertyMembers_d__22))]
		private static IEnumerable<MemberInfo> GetPropertyMembers(Type type); // 0x00000001822E1E50-0x00000001822E1ED0
		private static bool IsValidMember(MemberInfo memberInfo); // 0x00000001822E1ED0-0x00000001822E1FE0
		private static bool IsValidPropertyType(Type type); // 0x00000001822E1FE0-0x00000001822E2110
	}
}
