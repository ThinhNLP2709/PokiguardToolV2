/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class JsonSerializerInternalWriter : JsonSerializerInternalBase // TypeDefIndex: 10244
	{
		// Fields
		[Nullable(2)]
		private Type _rootType; // 0x38
		private int _rootLevel; // 0x40
		private readonly List<object> _serializeStack; // 0x48
	
		// Constructors
		public JsonSerializerInternalWriter(JsonSerializer serializer); // 0x00000001817323C0-0x0000000181732450
	
		// Methods
		[NullableContext(2)]
		public void Serialize([Nullable(1)] JsonWriter jsonWriter, object value, Type objectType); // 0x00000001817308A0-0x0000000181730CE0
		private JsonSerializerProxy GetInternalSerializer(); // 0x000000018172B1C0-0x000000018172B290
		[NullableContext(2)]
		private JsonContract GetContractSafe(object value); // 0x000000018172B0D0-0x000000018172B150
		private JsonContract GetContract(object value); // 0x000000018172B150-0x000000018172B1C0
		private void SerializePrimitive(JsonWriter writer, object value, JsonPrimitiveContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract containerContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172FDC0-0x00000001817300B0
		[NullableContext(2)]
		private void SerializeValue([Nullable(1)] JsonWriter writer, object value, JsonContract valueContract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty); // 0x0000000181730160-0x00000001817308A0
		[NullableContext(2)]
		private bool? ResolveIsReference([Nullable(1)] JsonContract contract, JsonProperty property, JsonContainerContract collectionContract, JsonProperty containerProperty); // 0x000000018172BF30-0x000000018172BF80
		[NullableContext(2)]
		private bool ShouldWriteReference(object value, JsonProperty property, JsonContract valueContract, JsonContainerContract collectionContract, JsonProperty containerProperty); // 0x0000000181731000-0x00000001817311A0
		[NullableContext(2)]
		private bool ShouldWriteProperty(object memberValue, JsonObjectContract containerContract, [Nullable(1)] JsonProperty property); // 0x0000000181730F50-0x0000000181731000
		[NullableContext(2)]
		private bool CheckForCircularReference([Nullable(1)] JsonWriter writer, object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty); // 0x000000018172AD00-0x000000018172B0D0
		private void WriteReference(JsonWriter writer, object value); // 0x0000000181731B60-0x0000000181731D50
		private string GetReference(JsonWriter writer, object value); // 0x000000018172B7C0-0x000000018172B960
		internal static bool TryConvertToString(object value, Type type, [Nullable(2)] [NotNullWhen(true)] out string s); // 0x00000001817313A0-0x0000000181731630
		private void SerializeString(JsonWriter writer, object value, JsonStringContract contract); // 0x00000001817300B0-0x0000000181730160
		private void OnSerializing(JsonWriter writer, JsonContract contract, object value); // 0x000000018172BDC0-0x000000018172BF30
		private void OnSerialized(JsonWriter writer, JsonContract contract, object value); // 0x000000018172BC50-0x000000018172BDC0
		private void SerializeObject(JsonWriter writer, object value, JsonObjectContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172F2E0-0x000000018172FDC0
		private bool CalculatePropertyValues(JsonWriter writer, object value, JsonContainerContract contract, [Nullable(2)] JsonProperty member, JsonProperty property, [Nullable(2)] [NotNullWhen(true)] out JsonContract memberContract, [Nullable(2)] out object memberValue); // 0x000000018172A4D0-0x000000018172AD00
		private void WriteObjectStart(JsonWriter writer, object value, JsonContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x0000000181731630-0x00000001817319B0
		private bool HasCreatorParameter([Nullable(2)] JsonContainerContract contract, JsonProperty property); // 0x000000018172B9E0-0x000000018172BA90
		private void WriteReferenceIdProperty(JsonWriter writer, Type type, object value); // 0x00000001817319B0-0x0000000181731B60
		private void WriteTypeProperty(JsonWriter writer, Type type); // 0x00000001817321E0-0x00000001817323C0
		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag); // 0x00000001814FA880-0x00000001814FA890
		private bool HasFlag(PreserveReferencesHandling value, PreserveReferencesHandling flag); // 0x00000001814FA880-0x00000001814FA890
		private bool HasFlag(TypeNameHandling value, TypeNameHandling flag); // 0x00000001814FA880-0x00000001814FA890
		private void SerializeConvertable(JsonWriter writer, JsonConverter converter, object value, JsonContract contract, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172BF80-0x000000018172C3B0
		private void SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172E6F0-0x000000018172ECC0
		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172F0E0-0x000000018172F2E0
		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, [Nullable(2)] JsonProperty member, int initialDepth, int[] indices); // 0x000000018172ECC0-0x000000018172F0E0
		private bool WriteStartArray(JsonWriter writer, object values, JsonArrayContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract containerContract, [Nullable(2)] JsonProperty containerProperty); // 0x0000000181731D50-0x00000001817321E0
		private void SerializeISerializable(JsonWriter writer, ISerializable value, JsonISerializableContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172DD10-0x000000018172E6F0
		private void SerializeDynamic(JsonWriter writer, IDynamicMetaObjectProvider value, JsonDynamicContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172CE10-0x000000018172DD10
		[NullableContext(2)]
		private bool ShouldWriteDynamicProperty(object memberValue); // 0x0000000181730EA0-0x0000000181730F50
		[NullableContext(2)]
		private bool ShouldWriteType(TypeNameHandling typeNameHandlingFlag, [Nullable(1)] JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty); // 0x00000001817311A0-0x00000001817313A0
		private void SerializeDictionary(JsonWriter writer, IDictionary values, JsonDictionaryContract contract, [Nullable(2)] JsonProperty member, [Nullable(2)] JsonContainerContract collectionContract, [Nullable(2)] JsonProperty containerProperty); // 0x000000018172C3B0-0x000000018172CE10
		private string GetPropertyName(JsonWriter writer, object name, JsonContract contract, out bool escape); // 0x000000018172B290-0x000000018172B7C0
		private void HandleError(JsonWriter writer, int initialDepth); // 0x000000018172B960-0x000000018172B9E0
		private bool ShouldSerialize(JsonWriter writer, JsonProperty property, object target); // 0x0000000181730CE0-0x0000000181730EA0
		private bool IsSpecified(JsonWriter writer, JsonProperty property, object target); // 0x000000018172BA90-0x000000018172BC50
	}
}
