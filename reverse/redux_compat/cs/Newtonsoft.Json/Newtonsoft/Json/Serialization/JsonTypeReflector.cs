/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
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
	internal static class JsonTypeReflector // TypeDefIndex: 10247
	{
		// Fields
		private static bool? _dynamicCodeGeneration; // 0x00
		private static bool? _fullyTrusted; // 0x02
		public const string IdPropertyName = "$id"; // Metadata: 0x006A0D8A
		public const string RefPropertyName = "$ref"; // Metadata: 0x006A0D8E
		public const string TypePropertyName = "$type"; // Metadata: 0x006A0D93
		public const string ValuePropertyName = "$value"; // Metadata: 0x006A0D99
		public const string ArrayValuesPropertyName = "$values"; // Metadata: 0x006A0DA0
		public const string ShouldSerializePrefix = "ShouldSerialize"; // Metadata: 0x006A0DA8
		public const string SpecifiedPostfix = "Specified"; // Metadata: 0x006A0DB8
		public const string ConcurrentDictionaryTypeName = "System.Collections.Concurrent.ConcurrentDictionary`2"; // Metadata: 0x006A0DC2
		[Nullable(new byte[6] {1, 1, 1, 2, 1, 1 })]
		private static readonly ThreadSafeStore<Type, Func<object[], object>> CreatorCache; // 0x08
		[Nullable(new byte[3] {1, 1, 2 })]
		private static readonly ThreadSafeStore<Type, Type> AssociatedMetadataTypesCache; // 0x10
		[Nullable(2)]
		private static ReflectionObject _metadataTypeAttributeReflectionObject; // 0x18
	
		// Properties
		public static bool DynamicCodeGeneration { get; } // 0x0000000181734430-0x00000001817344C0 
		public static bool FullyTrusted { get; } // 0x00000001817344C0-0x0000000181734590 
		public static ReflectionDelegateFactory ReflectionDelegateFactory { get; } // 0x0000000181734590-0x0000000181734620 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10248
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<object, Type> __9__22_1; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181738840-0x00000001817388B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal Type _GetCreator_b__22_1(object param); // 0x0000000181738150-0x00000001817381C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 10249
		{
			// Fields
			[Nullable(0)]
			public Type type; // 0x10
			[Nullable(new byte[2] {0, 1 })]
			public Func<object> defaultConstructor; // 0x18
	
			// Constructors
			public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _GetCreator_b__0([Nullable(new byte[2] {2, 1 })] object[] parameters); // 0x0000000181738320-0x00000001817386E0
		}
	
		// Constructors
		static JsonTypeReflector(); // 0x00000001817342C0-0x0000000181734430
	
		// Methods
		public static T GetCachedAttribute<T>(object attributeProvider)
			where T : Attribute;
		public static bool CanTypeDescriptorConvertString(Type type, out TypeConverter typeConverter); // 0x0000000181733290-0x0000000181733460
		public static DataContractAttribute GetDataContractAttribute(Type type); // 0x0000000181733C20-0x0000000181733CE0
		public static DataMemberAttribute GetDataMemberAttribute(MemberInfo memberInfo); // 0x0000000181733CE0-0x0000000181733F20
		public static MemberSerialization GetObjectMemberSerialization(Type objectType, bool ignoreSerializableAttribute); // 0x0000000181734030-0x00000001817341E0
		public static JsonConverter GetJsonConverter(object attributeProvider); // 0x0000000181733F20-0x0000000181734030
		public static JsonConverter CreateJsonConverterInstance(Type converterType, [Nullable(new byte[2] {2, 1 })] object[] args); // 0x0000000181733460-0x0000000181733550
		public static NamingStrategy CreateNamingStrategyInstance(Type namingStrategyType, [Nullable(new byte[2] {2, 1 })] object[] args); // 0x0000000181733550-0x0000000181733640
		public static NamingStrategy GetContainerNamingStrategy(JsonContainerAttribute containerAttribute); // 0x0000000181733910-0x0000000181733AB0
		private static Func<object[], object> GetCreator(Type type); // 0x0000000181733AB0-0x0000000181733C20
		private static Type GetAssociatedMetadataType(Type type); // 0x0000000181733890-0x0000000181733910
		private static Type GetAssociateMetadataTypeFromAttribute(Type type); // 0x0000000181733640-0x0000000181733890
		private static T GetAttribute<T>(Type type)
			where T : Attribute;
		private static T GetAttribute<T>(MemberInfo memberInfo)
			where T : Attribute;
		public static bool IsNonSerializable(object provider); // 0x00000001817341E0-0x0000000181734250
		public static bool IsSerializable(object provider); // 0x0000000181734250-0x00000001817342C0
		public static T GetAttribute<T>(object provider)
			where T : Attribute;
	}
}
