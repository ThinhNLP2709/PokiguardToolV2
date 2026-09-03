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
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public class DefaultContractResolver : IContractResolver // TypeDefIndex: 10194
	{
		// Fields
		private static readonly IContractResolver _instance; // 0x00
		private static readonly string[] BlacklistedTypeNames; // 0x08
		private static readonly JsonConverter[] BuiltInConverters; // 0x10
		private readonly DefaultJsonNameTable _nameTable; // 0x10
		private readonly ThreadSafeStore<Type, JsonContract> _contractCache; // 0x18
		[CompilerGenerated]
		private BindingFlags _DefaultMembersSearchFlags_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _SerializeCompilerGeneratedMembers_k__BackingField; // 0x24
		[CompilerGenerated]
		private bool _IgnoreSerializableInterface_k__BackingField; // 0x25
		[CompilerGenerated]
		private bool _IgnoreSerializableAttribute_k__BackingField; // 0x26
		[CompilerGenerated]
		private bool _IgnoreIsSpecifiedMembers_k__BackingField; // 0x27
		[CompilerGenerated]
		private bool _IgnoreShouldSerializeMembers_k__BackingField; // 0x28
		[CompilerGenerated]
		[Nullable(2)]
		private NamingStrategy _NamingStrategy_k__BackingField; // 0x30
	
		// Properties
		internal static IContractResolver Instance { get; } // 0x0000000181705FD0-0x0000000181706020 
		public bool DynamicCodeGeneration { get; } // 0x0000000181705F60-0x0000000181705FA0 
		[Obsolete("DefaultMembersSearchFlags is obsolete. To modify the members serialized inherit from DefaultContractResolver and override the GetSerializableMembers method instead.")]
		public BindingFlags DefaultMembersSearchFlags { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public bool SerializeCompilerGeneratedMembers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018153BC50-0x000000018153BC60 0x0000000181706050-0x0000000181706060
		public bool IgnoreSerializableInterface { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181705FC0-0x0000000181705FD0 0x0000000181706040-0x0000000181706050
		public bool IgnoreSerializableAttribute { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181705FB0-0x0000000181705FC0 0x0000000181706030-0x0000000181706040
		public bool IgnoreIsSpecifiedMembers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181705FA0-0x0000000181705FB0 0x0000000181706020-0x0000000181706030
		public bool IgnoreShouldSerializeMembers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		[Nullable(2)]
		public NamingStrategy NamingStrategy { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Nested types
		[NullableContext(0)]
		internal class EnumerableDictionaryWrapper<TEnumeratorKey, TEnumeratorValue> : IEnumerable<KeyValuePair<object, object>> // TypeDefIndex: 10195
		{
			// Fields
			[Nullable(new byte[4] {1, 0, 1, 1 })]
			private readonly IEnumerable<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetEnumerator_d__2 : IEnumerator<KeyValuePair<object, object>> // TypeDefIndex: 10196
			{
				// Fields
				private int __1__state;
				[Nullable(new byte[3] {0, 1, 1 })]
				private KeyValuePair<object, object> __2__current;
				public EnumerableDictionaryWrapper<TEnumeratorKey, TEnumeratorValue> __4__this;
				[Nullable(new byte[4] {0, 0, 1, 1 })]
				private IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> __7__wrap1;
	
				// Properties
				KeyValuePair<object, object> IEnumerator<System.Collections.Generic.KeyValuePair<System.Object,System.Object>>.Current { [DebuggerHidden] get; }
				object IEnumerator.Current { [DebuggerHidden] get; }
	
				// Constructors
				[DebuggerHidden]
				public _GetEnumerator_d__2(int __1__state);
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose();
				private bool MoveNext();
				private void __m__Finally1();
				[DebuggerHidden]
				void IEnumerator.Reset();
			}
	
			// Constructors
			public EnumerableDictionaryWrapper([Nullable(new byte[4] {1, 0, 1, 1 })] IEnumerable<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e);
	
			// Methods
			[IteratorStateMachine(typeof(_GetEnumerator_d__2))]
			public IEnumerator<KeyValuePair<object, object>> GetEnumerator();
			[NullableContext(1)]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10197
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<MemberInfo, bool> __9__40_0; // 0x08
			[Nullable(0)]
			public static Func<MemberInfo, bool> __9__40_1; // 0x10
			[Nullable(0)]
			public static Func<Type, IEnumerable<MemberInfo>> __9__44_0; // 0x18
			[Nullable(0)]
			public static Func<MemberInfo, bool> __9__44_1; // 0x20
			[Nullable(0)]
			public static Func<ConstructorInfo, bool> __9__47_0; // 0x28
			[Nullable(0)]
			public static Func<JsonProperty, int> __9__75_0; // 0x30
	
			// Constructors
			static __c(); // 0x000000018171E000-0x000000018171E070
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _GetSerializableMembers_b__40_0(MemberInfo m); // 0x000000018171D330-0x000000018171D3C0
			[NullableContext(0)]
			internal bool _GetSerializableMembers_b__40_1(MemberInfo m); // 0x000000018171D3C0-0x000000018171D430
			[NullableContext(0)]
			internal IEnumerable<MemberInfo> _GetExtensionDataMemberForType_b__44_0(Type baseType); // 0x000000018171CE50-0x000000018171CF30
			[NullableContext(0)]
			internal bool _GetExtensionDataMemberForType_b__44_1(MemberInfo m); // 0x000000018171CF30-0x000000018171D300
			[NullableContext(0)]
			internal bool _GetAttributeConstructor_b__47_0(ConstructorInfo c); // 0x000000018171CD60-0x000000018171CDD0
			[NullableContext(0)]
			internal int _CreateProperties_b__75_0(JsonProperty p); // 0x000000018171CD30-0x000000018171CD60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass42_0 // TypeDefIndex: 10198
		{
			// Fields
			[Nullable(0)]
			public NamingStrategy namingStrategy; // 0x10
	
			// Constructors
			public __c__DisplayClass42_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _CreateObjectContract_b__0(string s); // 0x000000018171D4C0-0x000000018171D4F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass45_0 // TypeDefIndex: 10199
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 2 })]
			public Func<object, object> getExtensionDataDictionary; // 0x10
			[Nullable(0)]
			public MemberInfo member; // 0x18
	
			// Constructors
			public __c__DisplayClass45_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass45_1 // TypeDefIndex: 10200
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 2 })]
			public Action<object, object> setExtensionDataDictionary; // 0x10
			[Nullable(new byte[2] {0, 1 })]
			public Func<object> createExtensionDataDictionary; // 0x18
			[Nullable(new byte[3] {0, 1, 2 })]
			public MethodCall<object, object> setExtensionDataDictionaryValue; // 0x20
			[Nullable(0)]
			public __c__DisplayClass45_0 CS___8__locals1; // 0x28
	
			// Constructors
			public __c__DisplayClass45_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SetExtensionDataDelegates_b__0(object o, string key, [Nullable(2)] object value); // 0x000000018171D8A0-0x000000018171DAF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass45_2 // TypeDefIndex: 10201
		{
			// Fields
			[Nullable(new byte[2] {0, 1 })]
			public ObjectConstructor<object> createEnumerableWrapper; // 0x10
			[Nullable(0)]
			public __c__DisplayClass45_0 CS___8__locals2; // 0x18
	
			// Constructors
			public __c__DisplayClass45_2(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IEnumerable<KeyValuePair<object, object>> _SetExtensionDataDelegates_b__1(object o); // 0x000000018171DAF0-0x000000018171DC20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass62_0 // TypeDefIndex: 10202
		{
			// Fields
			[Nullable(0)]
			public NamingStrategy namingStrategy; // 0x10
	
			// Constructors
			public __c__DisplayClass62_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _CreateDictionaryContract_b__0(string s); // 0x000000018171D4C0-0x000000018171D4F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 10203
		{
			// Fields
			[Nullable(0)]
			public NamingStrategy namingStrategy; // 0x10
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _CreateDynamicContract_b__0(string s); // 0x000000018171D4C0-0x000000018171D4F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass80_0 // TypeDefIndex: 10204
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 2 })]
			public MethodCall<object, object> shouldSerializeCall; // 0x10
	
			// Constructors
			public __c__DisplayClass80_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CreateShouldSerializeTest_b__0(object o); // 0x000000018171DE70-0x000000018171DF40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass81_0 // TypeDefIndex: 10205
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 1 })]
			public Func<object, object> specifiedPropertyGet; // 0x10
	
			// Constructors
			public __c__DisplayClass81_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _SetIsSpecifiedActions_b__0(object o); // 0x000000018171DF40-0x000000018171DF90
		}
	
		// Constructors
		public DefaultContractResolver(); // 0x0000000181705E60-0x0000000181705F60
		static DefaultContractResolver(); // 0x0000000181705870-0x0000000181705E60
	
		// Methods
		public virtual JsonContract ResolveContract(Type type); // 0x0000000181703F50-0x0000000181704010
		private static bool FilterMembers(MemberInfo member); // 0x0000000181700F30-0x0000000181701050
		protected virtual List<MemberInfo> GetSerializableMembers(Type objectType); // 0x0000000181702540-0x0000000181702EF0
		private bool ShouldSerializeEntityMember(MemberInfo memberInfo); // 0x00000001817054E0-0x0000000181705600
		protected virtual JsonObjectContract CreateObjectContract(Type objectType); // 0x00000001816FFA00-0x00000001817001F0
		private static void ThrowUnableToSerializeError(object o, StreamingContext context); // 0x00000001817057C0-0x0000000181705870
		private MemberInfo GetExtensionDataMemberForType(Type type); // 0x0000000181702110-0x00000001817022C0
		private static void SetExtensionDataDelegates(JsonObjectContract contract, MemberInfo member); // 0x00000001817040C0-0x0000000181704C00
		private ConstructorInfo GetAttributeConstructor(Type objectType); // 0x0000000181701050-0x0000000181701450
		private ConstructorInfo GetImmutableConstructor(Type objectType, JsonPropertyCollection memberProperties); // 0x00000001817022C0-0x00000001817024D0
		private ConstructorInfo GetParameterizedConstructor(Type objectType); // 0x00000001817024D0-0x0000000181702520
		protected virtual IList<JsonProperty> CreateConstructorParameters(ConstructorInfo constructor, JsonPropertyCollection memberProperties); // 0x00000001816FE660-0x00000001816FE880
		private JsonProperty MatchProperty(JsonPropertyCollection properties, string name, Type type); // 0x0000000181703BD0-0x0000000181703C60
		protected virtual JsonProperty CreatePropertyFromConstructorParameter([Nullable(2)] JsonProperty matchingMemberProperty, ParameterInfo parameterInfo); // 0x0000000181700710-0x00000001817009F0
		protected virtual JsonConverter ResolveContractConverter(Type objectType); // 0x0000000181703F00-0x0000000181703F50
		private Func<object> GetDefaultCreator(Type createdType); // 0x0000000181702070-0x0000000181702110
		private void InitializeContract(JsonContract contract); // 0x0000000181702EF0-0x00000001817031A0
		private void ResolveCallbackMethods(JsonContract contract, Type t); // 0x0000000181703C60-0x0000000181703F00
		private void GetCallbackMethodsForType(Type type, [Nullable(new byte[2] {2, 1 })] out List<SerializationCallback> onSerializing, [Nullable(new byte[2] {2, 1 })] out List<SerializationCallback> onSerialized, [Nullable(new byte[2] {2, 1 })] out List<SerializationCallback> onDeserializing, [Nullable(new byte[2] {2, 1 })] out List<SerializationCallback> onDeserialized, [Nullable(new byte[2] {2, 1 })] out List<SerializationErrorCallback> onError); // 0x0000000181701450-0x0000000181701DA0
		private static bool IsConcurrentOrObservableCollection(Type t); // 0x00000001817031A0-0x00000001817032E0
		private static bool ShouldSkipDeserialized(Type t); // 0x0000000181705600-0x00000001817056E0
		private static bool ShouldSkipSerializing(Type t); // 0x00000001817056E0-0x00000001817057C0
		private List<Type> GetClassHierarchyForType(Type type); // 0x0000000181701DA0-0x0000000181701F50
		protected virtual JsonDictionaryContract CreateDictionaryContract(Type objectType); // 0x00000001816FEDF0-0x00000001816FF360
		protected virtual JsonArrayContract CreateArrayContract(Type objectType); // 0x00000001816FE300-0x00000001816FE660
		protected virtual JsonPrimitiveContract CreatePrimitiveContract(Type objectType); // 0x00000001817001F0-0x0000000181700320
		protected virtual JsonLinqContract CreateLinqContract(Type objectType); // 0x00000001816FF920-0x00000001816FF9A0
		protected virtual JsonISerializableContract CreateISerializableContract(Type objectType); // 0x00000001816FF6D0-0x00000001816FF920
		protected virtual JsonDynamicContract CreateDynamicContract(Type objectType); // 0x00000001816FF360-0x00000001816FF6D0
		protected virtual JsonStringContract CreateStringContract(Type objectType); // 0x0000000181700EC0-0x0000000181700F30
		protected virtual JsonContract CreateContract(Type objectType); // 0x00000001816FE880-0x00000001816FEDF0
		internal static bool IsJsonPrimitiveType(Type t); // 0x0000000181703410-0x0000000181703470
		internal static bool IsIConvertible(Type t); // 0x00000001817032E0-0x0000000181703410
		internal static bool CanConvertToString(Type type); // 0x00000001816FE220-0x00000001816FE300
		private static bool IsValidCallback(MethodInfo method, ParameterInfo[] parameters, Type attributeType, [Nullable(2)] MethodInfo currentCallback, [Nullable(2)] ref Type prevAttributeType); // 0x0000000181703470-0x0000000181703BD0
		internal static string GetClrTypeFullName(Type type); // 0x0000000181701F50-0x0000000181702070
		protected virtual IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization); // 0x0000000181700320-0x0000000181700710
		internal virtual DefaultJsonNameTable GetNameTable(); // 0x0000000180377550-0x0000000180377560
		protected virtual IValueProvider CreateMemberValueProvider(MemberInfo member); // 0x00000001816FF9A0-0x00000001816FFA00
		protected virtual JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization); // 0x00000001817009F0-0x0000000181700C60
		private void SetPropertySettingsFromAttributes(JsonProperty property, object attributeProvider, string name, Type declaringType, MemberSerialization memberSerialization, out bool allowNonPublicAccess); // 0x0000000181704F00-0x00000001817054E0
		private Predicate<object> CreateShouldSerializeTest(MemberInfo member); // 0x0000000181700C60-0x0000000181700EC0
		private void SetIsSpecifiedActions(JsonProperty property, MemberInfo member, bool allowNonPublicAccess); // 0x0000000181704C00-0x0000000181704F00
		protected virtual string ResolvePropertyName(string propertyName); // 0x0000000181704090-0x00000001817040C0
		protected virtual string ResolveExtensionDataName(string extensionDataName); // 0x0000000181704060-0x0000000181704090
		protected virtual string ResolveDictionaryKey(string dictionaryKey); // 0x0000000181704010-0x0000000181704060
		public string GetResolvedPropertyName(string propertyName); // 0x0000000181702520-0x0000000181702540
	}
}
