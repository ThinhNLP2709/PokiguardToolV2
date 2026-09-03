/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public class JObject : JContainer, IDictionary<string, JToken>, INotifyPropertyChanged, ICustomTypeDescriptor, INotifyPropertyChanging // TypeDefIndex: 10308
	{
		// Fields
		private readonly JPropertyKeyedCollection _properties; // 0x58
		[CompilerGenerated]
		[Nullable(2)]
		private PropertyChangedEventHandler PropertyChanged; // 0x60
		[CompilerGenerated]
		[Nullable(2)]
		private PropertyChangingEventHandler PropertyChanging; // 0x68
	
		// Properties
		protected override IList<JToken> ChildrenTokens { get; } // 0x00000001802F4000-0x00000001802F4010 
		public override JTokenType Type { get; } // 0x0000000180472790-0x00000001804727A0 
		[Nullable(2)]
		public override JToken this[object key] { get => default; set {} } // 0x0000000181741D00-0x0000000181741E00 0x00000001817420C0-0x00000001817421D0
		[Nullable(2)]
		public JToken this[string propertyName] { get => default; set {} } // 0x0000000181741E00-0x0000000181741E80 0x0000000181741FC0-0x00000001817420C0
		ICollection<string> System.Collections.Generic.IDictionary<System.String,Newtonsoft.Json.Linq.JToken>.Keys { get; } // 0x00000001817409F0-0x0000000181740A50 
		[Nullable(new byte[2] {1, 2 })]
		ICollection<JToken> System.Collections.Generic.IDictionary<System.String,Newtonsoft.Json.Linq.JToken>.Values { get; } // 0x0000000181740A50-0x0000000181740A90 
		bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Events
		[Nullable(2)]
		public event PropertyChangedEventHandler PropertyChanged {
			add; // 0x0000000181741BC0-0x0000000181741C60
			remove; // 0x0000000181741E80-0x0000000181741F20
		}
		[Nullable(2)]
		public event PropertyChangingEventHandler PropertyChanging {
			add; // 0x0000000181741C60-0x0000000181741D00
			remove; // 0x0000000181741F20-0x0000000181741FC0
		}
	
		// Nested types
		[Nullable(new byte[2] {0, 1 })]
		private class JObjectDynamicProxy : DynamicProxy<JObject> // TypeDefIndex: 10309
		{
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 10310
			{
				// Fields
				[Nullable(0)]
				public static readonly __c __9; // 0x00
				[Nullable(0)]
				public static Func<JProperty, string> __9__2_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181755070-0x00000001817550E0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				[NullableContext(0)]
				internal string _GetDynamicMemberNames_b__2_0(JProperty p); // 0x0000000181755020-0x0000000181755040
			}
	
			// Constructors
			public JObjectDynamicProxy(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override bool TryGetMember(JObject instance, GetMemberBinder binder, [Nullable(2)] out object result); // 0x000000018173EA40-0x000000018173EA90
			public override bool TrySetMember(JObject instance, SetMemberBinder binder, object value); // 0x000000018173EA90-0x000000018173EB60
			public override IEnumerable<string> GetDynamicMemberNames(JObject instance); // 0x000000018173E900-0x000000018173EA40
		}
	
		[CompilerGenerated]
		private struct __WriteToAsync_g__AwaitProperties_0_0_d : IAsyncStateMachine // TypeDefIndex: 10311
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JObject __4__this; // 0x28
			public int i; // 0x30
			[Nullable(0)]
			public JsonWriter Writer; // 0x38
			public CancellationToken CancellationToken; // 0x40
			[Nullable(new byte[2] {0, 1 })]
			public JsonConverter[] Converters; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181754BC0-0x0000000181754FC0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181754FC0-0x0000000181755020
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10312
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<JProperty, JToken> __9__31_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001817550E0-0x0000000181755150
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal JToken _PropertyValues_b__31_0(JProperty p); // 0x0000000181755040-0x0000000181755070
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__64 : IEnumerator<KeyValuePair<string, JToken>> // TypeDefIndex: 10313
		{
			// Fields
			private int __1__state; // 0x10
			[Nullable(new byte[3] {0, 1, 2 })]
			private KeyValuePair<string, JToken> __2__current; // 0x18
			[Nullable(0)]
			public JObject __4__this; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x30
	
			// Properties
			KeyValuePair<string, JToken> IEnumerator<System.Collections.Generic.KeyValuePair<System.String,Newtonsoft.Json.Linq.JToken>>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181751EE0-0x0000000181751F30 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__64(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181751F30-0x0000000181751FD0
			private bool MoveNext(); // 0x0000000181751C20-0x0000000181751EA0
			private void __m__Finally1(); // 0x0000000181751FD0-0x0000000181752020
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181751EA0-0x0000000181751EE0
		}
	
		[CompilerGenerated]
		private struct _LoadAsync_d__2 : IAsyncStateMachine // TypeDefIndex: 10314
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JObject> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x30
			[Nullable(0)]
			private JObject _o_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181752020-0x00000001817525D0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181752BB0-0x0000000181752C10
		}
	
		// Constructors
		public JObject(); // 0x0000000181741AD0-0x0000000181741BC0
		public JObject(JObject other); // 0x0000000181741920-0x00000001817419F0
		internal JObject(JObject other, [Nullable(2)] JsonCloneSettings settings); // 0x00000001817419F0-0x0000000181741AD0
		public JObject(params object[] content); // 0x0000000181741800-0x0000000181741920
		public JObject(object content); // 0x0000000181741800-0x0000000181741920
	
		// Methods
		public override Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x0000000181741510-0x00000001817416E0
		public static new Task<JObject> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x000000018173F780-0x000000018173F790
		public static new async Task<JObject> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x000000018173F650-0x000000018173F780
		internal override bool DeepEquals(JToken node); // 0x000000018173EDF0-0x000000018173EE80
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item); // 0x000000018173F320-0x000000018173F3C0
		[NullableContext(2)]
		internal override bool InsertItem(int index, JToken item, bool skipParentCheck, bool copyAnnotations); // 0x000000018173F3C0-0x000000018173F440
		internal override void ValidateToken(JToken o, [Nullable(2)] JToken existing); // 0x0000000181741230-0x0000000181741510
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings); // 0x000000018173F9A0-0x000000018173FD50
		private static bool IsNull(JToken token); // 0x000000018173F5C0-0x000000018173F650
		internal void InternalPropertyChanged(JProperty childProperty); // 0x000000018173F440-0x000000018173F590
		internal void InternalPropertyChanging(JProperty childProperty); // 0x000000018173F590-0x000000018173F5C0
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings); // 0x000000018173EBF0-0x000000018173ED00
		public IEnumerable<JProperty> Properties(); // 0x000000018173FFE0-0x0000000181740020
		public JProperty Property(string name); // 0x0000000181740360-0x0000000181740370
		public JProperty Property(string name, StringComparison comparison); // 0x0000000181740170-0x0000000181740360
		public JEnumerable<JToken> PropertyValues(); // 0x0000000181740020-0x0000000181740170
		public static new JObject Load(JsonReader reader); // 0x000000018173F790-0x000000018173F7A0
		public static new JObject Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x000000018173F7A0-0x000000018173F9A0
		public static new JObject Parse(string json); // 0x000000018173FE70-0x000000018173FE80
		public static new JObject Parse(string json, [Nullable(2)] JsonLoadSettings settings); // 0x000000018173FE80-0x000000018173FFE0
		public static new JObject FromObject(object o); // 0x000000018173EE80-0x000000018173F010
		public static new JObject FromObject(object o, JsonSerializer jsonSerializer); // 0x000000018173F010-0x000000018173F190
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters); // 0x00000001817416E0-0x0000000181741800
		[NullableContext(2)]
		public JToken GetValue(string propertyName); // 0x000000018173F2E0-0x000000018173F320
		[NullableContext(2)]
		public JToken GetValue(string propertyName, StringComparison comparison); // 0x000000018173F2A0-0x000000018173F2E0
		public bool TryGetValue(string propertyName, StringComparison comparison, [Nullable(2)] [NotNullWhen(true)] out JToken value); // 0x0000000181741040-0x0000000181741090
		public void Add(string propertyName, [Nullable(2)] JToken value); // 0x000000018173EB60-0x000000018173EBF0
		public bool ContainsKey(string propertyName); // 0x000000018173ED00-0x000000018173EDF0
		public bool Remove(string propertyName); // 0x0000000181740370-0x0000000181740410
		public bool TryGetValue(string propertyName, [Nullable(2)] [NotNullWhen(true)] out JToken value); // 0x0000000181741090-0x00000001817410F0
		void ICollection<KeyValuePair<string, JToken>>.Add([Nullable(new byte[3] {0, 1, 2 })] KeyValuePair<string, JToken> item); // 0x0000000181740410-0x0000000181740490
		void ICollection<KeyValuePair<string, JToken>>.Clear(); // 0x000000018171E750-0x000000018171E770
		bool ICollection<KeyValuePair<string, JToken>>.Contains([Nullable(new byte[3] {0, 1, 2 })] KeyValuePair<string, JToken> item); // 0x0000000181740490-0x00000001817404E0
		void ICollection<KeyValuePair<string, JToken>>.CopyTo([Nullable(new byte[4] {1, 0, 1, 2 })] KeyValuePair<string, JToken>[] array, int arrayIndex); // 0x00000001817404E0-0x0000000181740880
		bool ICollection<KeyValuePair<string, JToken>>.Remove([Nullable(new byte[3] {0, 1, 2 })] KeyValuePair<string, JToken> item); // 0x0000000181740880-0x00000001817409F0
		internal override int GetDeepHashCode(); // 0x000000018171EC20-0x000000018171EC30
		[IteratorStateMachine(typeof(_GetEnumerator_d__64))]
		public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator(); // 0x000000018173F190-0x000000018173F200
		protected virtual void OnPropertyChanged(string propertyName); // 0x000000018173FD50-0x000000018173FDE0
		protected virtual void OnPropertyChanging(string propertyName); // 0x000000018173FDE0-0x000000018173FE70
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(); // 0x0000000181740F10-0x0000000181740FC0
		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties([Nullable(new byte[2] {2, 1 })] Attribute[] attributes); // 0x0000000181740BD0-0x0000000181740F10
		AttributeCollection ICustomTypeDescriptor.GetAttributes(); // 0x0000000181740A90-0x0000000181740AE0
		[NullableContext(2)]
		string ICustomTypeDescriptor.GetClassName(); // 0x00000001802E7860-0x00000001802E7870
		[NullableContext(2)]
		string ICustomTypeDescriptor.GetComponentName(); // 0x00000001802E7860-0x00000001802E7870
		TypeConverter ICustomTypeDescriptor.GetConverter(); // 0x0000000181740AE0-0x0000000181740B30
		[NullableContext(2)]
		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent(); // 0x00000001802E7860-0x00000001802E7870
		[NullableContext(2)]
		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty(); // 0x00000001802E7860-0x00000001802E7870
		object ICustomTypeDescriptor.GetEditor(Type editorBaseType); // 0x00000001802E7860-0x00000001802E7870
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents([Nullable(new byte[2] {2, 1 })] Attribute[] attributes); // 0x0000000181740B30-0x0000000181740B80
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(); // 0x0000000181740B80-0x0000000181740BD0
		[NullableContext(2)]
		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd); // 0x0000000181740FC0-0x0000000181741040
		protected override DynamicMetaObject GetMetaObject(Expression parameter); // 0x000000018173F200-0x000000018173F2A0
		[CompilerGenerated]
		private async Task _WriteToAsync_g__AwaitProperties_0_0(Task task, int i, JsonWriter Writer, CancellationToken CancellationToken, JsonConverter[] Converters); // 0x00000001817410F0-0x0000000181741230
	}
}
