/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class JsonSerializerInternalReader : JsonSerializerInternalBase // TypeDefIndex: 10239
	{
		// Nested types
		[NullableContext(0)]
		internal enum PropertyPresence // TypeDefIndex: 10240
		{
			None = 0,
			Null = 1,
			Value = 2
		}
	
		[Nullable(0)]
		[NullableContext(2)]
		internal class CreatorPropertyContext // TypeDefIndex: 10241
		{
			// Fields
			[Nullable(1)]
			public readonly string Name; // 0x10
			public JsonProperty Property; // 0x18
			public JsonProperty ConstructorProperty; // 0x20
			public PropertyPresence? Presence; // 0x28
			public object Value; // 0x30
			public bool Used; // 0x38
	
			// Constructors
			[NullableContext(1)]
			public CreatorPropertyContext(string name); // 0x00000001803855F0-0x0000000180385630
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10242
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<JsonProperty, string> __9__38_0; // 0x08
			[Nullable(new byte[3] {0, 0, 1 })]
			public static Func<JsonProperty, string> __9__38_2; // 0x10
			[Nullable(0)]
			public static Func<JsonProperty, JsonProperty> __9__42_0; // 0x18
			[Nullable(0)]
			public static Func<JsonProperty, PropertyPresence> __9__42_1; // 0x20
	
			// Constructors
			static __c(); // 0x0000000181738920-0x0000000181738990
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal string _CreateObjectUsingCreatorWithParameters_b__38_0(JsonProperty p); // 0x000000018170CD90-0x000000018170CDB0
			[NullableContext(0)]
			internal string _CreateObjectUsingCreatorWithParameters_b__38_2(JsonProperty p); // 0x000000018170CD90-0x000000018170CDB0
			[NullableContext(0)]
			internal JsonProperty _PopulateObject_b__42_0(JsonProperty m); // 0x0000000180A68C50-0x0000000180A68C60
			[NullableContext(0)]
			internal PropertyPresence _PopulateObject_b__42_1(JsonProperty m); // 0x00000001802E7860-0x00000001802E7870
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass38_0 // TypeDefIndex: 10243
		{
			// Fields
			[Nullable(0)]
			public JsonProperty property; // 0x10
	
			// Constructors
			public __c__DisplayClass38_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _CreateObjectUsingCreatorWithParameters_b__1(CreatorPropertyContext p); // 0x0000000181738750-0x0000000181738770
		}
	
		// Constructors
		public JsonSerializerInternalReader(JsonSerializer serializer); // 0x000000018170DB80-0x000000018170DC50
	
		// Methods
		public void Populate(JsonReader reader, object target); // 0x0000000181717E40-0x0000000181718430
		[NullableContext(2)]
		private JsonContract GetContractSafe(Type type); // 0x0000000181714F40-0x0000000181714FE0
		private JsonContract GetContract(Type type); // 0x0000000181714FE0-0x0000000181715040
		[NullableContext(2)]
		public object Deserialize([Nullable(1)] JsonReader reader, Type objectType, bool checkAdditionalContent); // 0x00000001817140E0-0x0000000181714440
		private JsonSerializerProxy GetInternalSerializer(); // 0x0000000181715220-0x0000000181715290
		[NullableContext(2)]
		private JToken CreateJToken([Nullable(1)] JsonReader reader, JsonContract contract); // 0x000000018170FE70-0x00000001817101F0
		private JToken CreateJObject(JsonReader reader); // 0x000000018170FB50-0x000000018170FE70
		[NullableContext(2)]
		private object CreateValueInternal([Nullable(1)] JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue); // 0x00000001817138B0-0x0000000181713DA0
		[NullableContext(2)]
		private static bool CoerceEmptyStringToNull(Type objectType, JsonContract contract, [Nullable(1)] string s); // 0x000000018170E800-0x000000018170E8B0
		internal string GetExpectedDescription(JsonContract contract); // 0x0000000181715120-0x0000000181715220
		[NullableContext(2)]
		private JsonConverter GetConverter(JsonContract contract, JsonConverter memberConverter, JsonContainerContract containerContract, JsonProperty containerProperty); // 0x0000000181715040-0x0000000181715120
		[NullableContext(2)]
		private object CreateObject([Nullable(1)] JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue); // 0x0000000181712A90-0x00000001817138B0
		[NullableContext(2)]
		private bool ReadMetadataPropertiesToken([Nullable(1)] JTokenReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue, out object newValue, out string id); // 0x00000001817184F0-0x0000000181718C00
		[NullableContext(2)]
		private bool ReadMetadataProperties([Nullable(1)] JsonReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue, out object newValue, out string id); // 0x0000000181718C00-0x0000000181719290
		[NullableContext(2)]
		private void ResolveTypeName([Nullable(1)] JsonReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, [Nullable(1)] string qualifiedTypeName); // 0x0000000181719C60-0x000000018171A1C0
		private JsonArrayContract EnsureArrayContract(JsonReader reader, Type objectType, JsonContract contract); // 0x00000001817148B0-0x0000000181714A70
		[NullableContext(2)]
		private object CreateList([Nullable(1)] JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, object existingValue, string id); // 0x00000001817101F0-0x0000000181710AB0
		[NullableContext(2)]
		private bool HasNoDefinedType(JsonContract contract); // 0x0000000181715310-0x00000001817153B0
		[NullableContext(2)]
		private object EnsureType([Nullable(1)] JsonReader reader, object value, [Nullable(1)] CultureInfo culture, JsonContract contract, Type targetType); // 0x0000000181714A70-0x0000000181714F40
		private bool SetPropertyValue(JsonProperty property, [Nullable(2)] JsonConverter propertyConverter, [Nullable(2)] JsonContainerContract containerContract, [Nullable(2)] JsonProperty containerProperty, JsonReader reader, object target); // 0x000000018171A400-0x000000018171A890
		[NullableContext(2)]
		private bool CalculatePropertyDetails([Nullable(1)] JsonProperty property, ref JsonConverter propertyConverter, JsonContainerContract containerContract, JsonProperty containerProperty, [Nullable(1)] JsonReader reader, [Nullable(1)] object target, out bool useExistingValue, out object currentValue, out JsonContract propertyContract, out bool gottenCurrentValue, out bool ignoredValue); // 0x000000018170E0A0-0x000000018170E6F0
		private void AddReference(JsonReader reader, string id, object value); // 0x000000018170DDC0-0x000000018170E0A0
		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag); // 0x00000001814FA880-0x00000001814FA890
		[NullableContext(2)]
		private bool ShouldSetPropertyValue([Nullable(1)] JsonProperty property, JsonObjectContract contract, object value); // 0x000000018171AA50-0x000000018171AB70
		private IList CreateNewList(JsonReader reader, JsonArrayContract contract, out bool createdFromNonDefaultCreator); // 0x0000000181710D90-0x0000000181711100
		private IDictionary CreateNewDictionary(JsonReader reader, JsonDictionaryContract contract, out bool createdFromNonDefaultCreator); // 0x0000000181710AB0-0x0000000181710D90
		private void OnDeserializing(JsonReader reader, JsonContract contract, object value); // 0x0000000181715560-0x0000000181715710
		private void OnDeserialized(JsonReader reader, JsonContract contract, object value); // 0x00000001817153B0-0x0000000181715560
		private object PopulateDictionary(IDictionary dictionary, JsonReader reader, JsonDictionaryContract contract, [Nullable(2)] JsonProperty containerProperty, [Nullable(2)] string id); // 0x0000000181715710-0x0000000181716290
		private object PopulateMultidimensionalArray(IList list, JsonReader reader, JsonArrayContract contract, [Nullable(2)] JsonProperty containerProperty, [Nullable(2)] string id); // 0x00000001817168A0-0x00000001817170E0
		private void ThrowUnexpectedEndException(JsonReader reader, JsonContract contract, [Nullable(2)] object currentObject, string message); // 0x000000018171AB70-0x000000018171AC80
		private object PopulateList(IList list, JsonReader reader, JsonArrayContract contract, [Nullable(2)] JsonProperty containerProperty, [Nullable(2)] string id); // 0x0000000181716290-0x00000001817168A0
		private object CreateISerializable(JsonReader reader, JsonISerializableContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] string id); // 0x000000018170F390-0x000000018170FB50
		internal object CreateISerializableItem(JToken token, Type type, JsonISerializableContract contract, [Nullable(2)] JsonProperty member); // 0x000000018170F1F0-0x000000018170F390
		private object CreateDynamic(JsonReader reader, JsonDynamicContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] string id); // 0x000000018170E8B0-0x000000018170F1F0
		private object CreateObjectUsingCreatorWithParameters(JsonReader reader, JsonObjectContract contract, [Nullable(2)] JsonProperty containerProperty, ObjectConstructor<object> creator, [Nullable(2)] string id); // 0x00000001817113E0-0x0000000181712A90
		private object DeserializeConvertable(JsonConverter converter, JsonReader reader, Type objectType, [Nullable(2)] object existingValue); // 0x0000000181713DA0-0x00000001817140E0
		private List<CreatorPropertyContext> ResolvePropertyAndCreatorValues(JsonObjectContract contract, [Nullable(2)] JsonProperty containerProperty, JsonReader reader, Type objectType); // 0x0000000181719290-0x0000000181719C60
		public object CreateNewObject(JsonReader reader, JsonObjectContract objectContract, [Nullable(2)] JsonProperty containerMember, [Nullable(2)] JsonProperty containerProperty, [Nullable(2)] string id, out bool createdFromNonDefaultCreator); // 0x0000000181711100-0x00000001817113E0
		private object PopulateObject(object newObject, JsonReader reader, JsonObjectContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] string id); // 0x00000001817170E0-0x0000000181717E40
		private bool ShouldDeserialize(JsonReader reader, JsonProperty property, object target); // 0x000000018171A890-0x000000018171AA50
		private bool CheckPropertyName(JsonReader reader, string memberName); // 0x000000018170E6F0-0x000000018170E800
		private void SetExtensionData(JsonObjectContract contract, [Nullable(2)] JsonProperty member, JsonReader reader, string memberName, object o); // 0x000000018171A1C0-0x000000018171A2F0
		private object ReadExtensionDataValue(JsonObjectContract contract, [Nullable(2)] JsonProperty member, JsonReader reader); // 0x0000000181718430-0x00000001817184F0
		private void EndProcessProperty(object newObject, JsonReader reader, JsonObjectContract contract, int initialDepth, JsonProperty property, PropertyPresence presence, bool setDefaultValue); // 0x0000000181714440-0x00000001817148B0
		private void SetPropertyPresence(JsonReader reader, JsonProperty property, [Nullable(new byte[2] {2, 1 })] Dictionary<JsonProperty, PropertyPresence> requiredProperties); // 0x000000018171A2F0-0x000000018171A400
		private void HandleError(JsonReader reader, bool readPastError, int initialDepth); // 0x0000000181715290-0x0000000181715310
	}
}
