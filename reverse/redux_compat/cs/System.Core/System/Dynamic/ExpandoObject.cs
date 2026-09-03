/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	public sealed class ExpandoObject : IDynamicMetaObjectProvider, IDictionary<string, object>, INotifyPropertyChanged // TypeDefIndex: 12565
	{
		// Fields
		private static readonly MethodInfo s_expandoTryGetValue; // 0x00
		private static readonly MethodInfo s_expandoTrySetValue; // 0x08
		private static readonly MethodInfo s_expandoTryDeleteValue; // 0x10
		private static readonly MethodInfo s_expandoPromoteClass; // 0x18
		private static readonly MethodInfo s_expandoCheckVersion; // 0x20
		internal readonly object LockObject; // 0x10
		private ExpandoData _data; // 0x18
		private int _count; // 0x20
		internal static readonly object Uninitialized; // 0x28
		private PropertyChangedEventHandler _propertyChanged; // 0x28
	
		// Properties
		internal ExpandoClass Class { get; } // 0x0000000181777F30-0x0000000181777F50 
		ICollection<string> System.Collections.Generic.IDictionary<System.String,System.Object>.Keys { get; } // 0x00000001817EE9F0-0x00000001817EEA50 
		ICollection<object> System.Collections.Generic.IDictionary<System.String,System.Object>.Values { get; } // 0x00000001817EEA50-0x00000001817EEAB0 
		object System.Collections.Generic.IDictionary<System.String,System.Object>.this[string key] { get => default; set {} } // 0x00000001817EE980-0x00000001817EE9F0 0x00000001817EEAB0-0x00000001817EEB40
		int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		private sealed class KeyCollectionDebugView // TypeDefIndex: 12566
		{
		}
	
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(KeyCollectionDebugView))]
		private class KeyCollection : ICollection<string> // TypeDefIndex: 12567
		{
			// Fields
			private readonly ExpandoObject _expando; // 0x10
			private readonly int _expandoVersion; // 0x18
			private readonly int _expandoCount; // 0x1C
			private readonly ExpandoData _expandoData; // 0x20
	
			// Properties
			public int Count { get; } // 0x00000001817F1500-0x00000001817F1570 
			public bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetEnumerator_d__15 : IEnumerator<string> // TypeDefIndex: 12568
			{
				// Fields
				private int __1__state; // 0x10
				private string __2__current; // 0x18
				public KeyCollection __4__this; // 0x20
				private int _i_5__2; // 0x28
				private int _n_5__3; // 0x2C
	
				// Properties
				string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
				// Constructors
				[DebuggerHidden]
				public _GetEnumerator_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
				private bool MoveNext(); // 0x000000018180DC40-0x000000018180DDC0
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x000000018180DE00-0x000000018180DE40
			}
	
			// Constructors
			internal KeyCollection(ExpandoObject expando); // 0x00000001817F13F0-0x00000001817F1500
	
			// Methods
			private void CheckVersion(); // 0x00000001817F0E70-0x00000001817F0EE0
			public void Add(string item); // 0x00000001817F0E40-0x00000001817F0E70
			public void Clear(); // 0x00000001817F0EE0-0x00000001817F0F10
			public bool Contains(string item); // 0x00000001817F0F10-0x00000001817F1060
			public void CopyTo(string[] array, int arrayIndex); // 0x00000001817F1060-0x00000001817F1350
			public bool Remove(string item); // 0x00000001817F13C0-0x00000001817F13F0
			[IteratorStateMachine(typeof(_GetEnumerator_d__15))]
			public IEnumerator<string> GetEnumerator(); // 0x00000001817F1350-0x00000001817F13C0
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817F1350-0x00000001817F13C0
		}
	
		private sealed class ValueCollectionDebugView // TypeDefIndex: 12569
		{
		}
	
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ValueCollectionDebugView))]
		private class ValueCollection : ICollection<object> // TypeDefIndex: 12570
		{
			// Fields
			private readonly ExpandoObject _expando; // 0x10
			private readonly int _expandoVersion; // 0x18
			private readonly int _expandoCount; // 0x1C
			private readonly ExpandoData _expandoData; // 0x20
	
			// Properties
			public int Count { get; } // 0x000000018180E940-0x000000018180F140 
			public bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetEnumerator_d__15 : IEnumerator<object> // TypeDefIndex: 12571
			{
				// Fields
				private int __1__state; // 0x10
				private object __2__current; // 0x18
				public ValueCollection __4__this; // 0x20
				private ExpandoData _data_5__2; // 0x28
				private int _i_5__3; // 0x30
	
				// Properties
				object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
				// Constructors
				[DebuggerHidden]
				public _GetEnumerator_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
				private bool MoveNext(); // 0x000000018180DA80-0x000000018180DC40
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x000000018180DDC0-0x000000018180DE00
			}
	
			// Constructors
			internal ValueCollection(ExpandoObject expando); // 0x00000001817F13F0-0x00000001817F1500
	
			// Methods
			private void CheckVersion(); // 0x000000018180E2E0-0x000000018180E350
			public void Add(object item); // 0x000000018180E2B0-0x000000018180E2E0
			public void Clear(); // 0x000000018180E350-0x000000018180E380
			public bool Contains(object item); // 0x000000018180E380-0x000000018180E540
			public void CopyTo(object[] array, int arrayIndex); // 0x000000018180E540-0x000000018180E8A0
			public bool Remove(object item); // 0x000000018180E910-0x000000018180E940
			[IteratorStateMachine(typeof(_GetEnumerator_d__15))]
			public IEnumerator<object> GetEnumerator(); // 0x000000018180E8A0-0x000000018180E910
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018180E8A0-0x000000018180E910
		}
	
		private class MetaExpando : DynamicMetaObject // TypeDefIndex: 12572
		{
			// Properties
			public new ExpandoObject Value { get; } // 0x0000000181806B50-0x0000000181806BB0 
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass3_0 // TypeDefIndex: 12573
			{
				// Fields
				public InvokeMemberBinder binder; // 0x10
				public DynamicMetaObject[] args; // 0x18
	
				// Constructors
				public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal DynamicMetaObject _BindInvokeMember_b__0(DynamicMetaObject value); // 0x000000018180E100-0x000000018180E140
			}
	
			[CompilerGenerated]
			private sealed class _GetDynamicMemberNames_d__6 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 12574
			{
				// Fields
				private int __1__state; // 0x10
				private string __2__current; // 0x18
				private int __l__initialThreadId; // 0x20
				public MetaExpando __4__this; // 0x28
				private ExpandoData _expandoData_5__2; // 0x30
				private ExpandoClass _klass_5__3; // 0x38
				private int _i_5__4; // 0x40
	
				// Properties
				string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
				// Constructors
				[DebuggerHidden]
				public _GetDynamicMemberNames_d__6(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
				private bool MoveNext(); // 0x000000018180D7C0-0x000000018180D9A0
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x000000018180DA40-0x000000018180DA80
				[DebuggerHidden]
				IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x000000018180D9A0-0x000000018180DA40
				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator(); // 0x000000018180D9A0-0x000000018180DA40
			}
	
			// Constructors
			public MetaExpando(Expression expression, ExpandoObject value); // 0x0000000181806A90-0x0000000181806B50
	
			// Methods
			private DynamicMetaObject BindGetOrInvokeMember(DynamicMetaObjectBinder binder, string name, bool ignoreCase, DynamicMetaObject fallback, Func<DynamicMetaObject, DynamicMetaObject> fallbackInvoke); // 0x00000001818058D0-0x0000000181805FE0
			public override DynamicMetaObject BindGetMember(GetMemberBinder binder); // 0x00000001818057F0-0x00000001818058D0
			public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args); // 0x0000000181805FE0-0x0000000181806180
			public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value); // 0x0000000181806180-0x0000000181806760
			public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder); // 0x0000000181805420-0x00000001818057F0
			[IteratorStateMachine(typeof(_GetDynamicMemberNames_d__6))]
			public override IEnumerable<string> GetDynamicMemberNames(); // 0x0000000181806890-0x0000000181806910
			private DynamicMetaObject AddDynamicTestAndDefer(DynamicMetaObjectBinder binder, ExpandoClass klass, ExpandoClass originalClass, DynamicMetaObject succeeds); // 0x0000000181805100-0x0000000181805420
			private ExpandoClass GetClassEnsureIndex(string name, bool caseInsensitive, ExpandoObject obj, out ExpandoClass klass, out int index); // 0x0000000181806760-0x0000000181806890
			private Expression GetLimitedSelf(); // 0x0000000181806910-0x0000000181806A40
			private BindingRestrictions GetRestrictions(); // 0x0000000181806A40-0x0000000181806A90
		}
	
		private class ExpandoData // TypeDefIndex: 12575
		{
			// Fields
			internal static ExpandoData Empty; // 0x00
			internal readonly ExpandoClass Class; // 0x10
			private readonly object[] _dataArray; // 0x18
			private int _version; // 0x20
	
			// Properties
			internal object this[int index] { get => default; set {} } // 0x00000001814EA230-0x00000001814EA260 0x0000000181803440-0x00000001818034C0
			internal int Version { get; } // 0x0000000180C4F680-0x0000000180C4F690 
			internal int Length { get; } // 0x00000001814EA450-0x00000001814EA470 
	
			// Constructors
			private ExpandoData(); // 0x0000000181803310-0x00000001818033E0
			internal ExpandoData(ExpandoClass klass, object[] data, int version); // 0x00000001818033E0-0x0000000181803440
			static ExpandoData(); // 0x00000001818031F0-0x0000000181803310
	
			// Methods
			internal ExpandoData UpdateClass(ExpandoClass newClass); // 0x0000000181802F30-0x00000001818031F0
			private static int GetAlignedSize(int len); // 0x0000000181802F20-0x0000000181802F30
		}
	
		[CompilerGenerated]
		private sealed class _GetExpandoEnumerator_d__51 : IEnumerator<KeyValuePair<string, object>> // TypeDefIndex: 12576
		{
			// Fields
			private int __1__state; // 0x10
			private KeyValuePair<string, object> __2__current; // 0x18
			public ExpandoObject __4__this; // 0x28
			public int version; // 0x30
			public ExpandoData data; // 0x38
			private int _i_5__2; // 0x40
	
			// Properties
			KeyValuePair<string, object> IEnumerator<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018180E050-0x000000018180E0A0 
	
			// Constructors
			[DebuggerHidden]
			public _GetExpandoEnumerator_d__51(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018180DE40-0x000000018180E010
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018180E010-0x000000018180E050
		}
	
		// Constructors
		public ExpandoObject(); // 0x00000001817EF690-0x00000001817EF730
		static ExpandoObject(); // 0x00000001817EF420-0x00000001817EF690
	
		// Methods
		internal bool TryGetValue(object indexClass, int index, string name, bool ignoreCase, out object value); // 0x00000001817EEF50-0x00000001817EF0A0
		internal void TrySetValue(object indexClass, int index, object value, string name, bool ignoreCase, bool add); // 0x00000001817EF0A0-0x00000001817EF420
		internal bool TryDeleteValue(object indexClass, int index, string name, bool ignoreCase, object deleteValue); // 0x00000001817EEC70-0x00000001817EEF50
		internal bool IsDeletedMember(int index); // 0x00000001817EDED0-0x00000001817EDF70
		private ExpandoData PromoteClassCore(ExpandoClass oldClass, ExpandoClass newClass); // 0x00000001817EDF70-0x00000001817EDFC0
		internal void PromoteClass(object oldClass, object newClass); // 0x00000001817EDFC0-0x00000001817EE150
		DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter); // 0x00000001817EEB70-0x00000001817EEBE0
		private void TryAddMember(string key, object value); // 0x00000001817EEBE0-0x00000001817EEC70
		private bool TryGetValueForKey(string key, out object value); // 0x00000001817EE950-0x00000001817EE980
		private bool ExpandoContainsKey(string key); // 0x00000001817EDE00-0x00000001817EDE30
		void IDictionary<string, object>.Add(string key, object value); // 0x00000001817EE7C0-0x00000001817EE7D0
		bool IDictionary<string, object>.ContainsKey(string key); // 0x00000001817EE7D0-0x00000001817EE8A0
		bool IDictionary<string, object>.Remove(string key); // 0x00000001817EE8A0-0x00000001817EE950
		bool IDictionary<string, object>.TryGetValue(string key, out object value); // 0x00000001817EE950-0x00000001817EE980
		void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item); // 0x00000001817EE150-0x00000001817EE160
		void ICollection<KeyValuePair<string, object>>.Clear(); // 0x00000001817EE160-0x00000001817EE3F0
		bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item); // 0x00000001817EE3F0-0x00000001817EE450
		void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex); // 0x00000001817EE450-0x00000001817EE790
		bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item); // 0x00000001817EE790-0x00000001817EE7C0
		IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator(); // 0x00000001817EEB40-0x00000001817EEB70
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817EEB40-0x00000001817EEB70
		[IteratorStateMachine(typeof(_GetExpandoEnumerator_d__51))]
		private IEnumerator<KeyValuePair<string, object>> GetExpandoEnumerator(ExpandoData data, int version); // 0x00000001817EDE30-0x00000001817EDED0
	}
}
