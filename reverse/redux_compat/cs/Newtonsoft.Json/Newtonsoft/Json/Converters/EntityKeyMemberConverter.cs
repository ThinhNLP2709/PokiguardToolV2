/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class EntityKeyMemberConverter : JsonConverter // TypeDefIndex: 10382
	{
		// Fields
		private const string EntityKeyMemberFullTypeName = "System.Data.EntityKeyMember"; // Metadata: 0x006A0F94
		private const string KeyPropertyName = "Key"; // Metadata: 0x006A0FB0
		private const string TypePropertyName = "Type"; // Metadata: 0x006A0FB4
		private const string ValuePropertyName = "Value"; // Metadata: 0x006A0FB9
		[Nullable(2)]
		private static ReflectionObject _reflectionObject; // 0x00
	
		// Constructors
		public EntityKeyMemberConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x000000018175BC60-0x000000018175BFC0
		private static void ReadAndAssertProperty(JsonReader reader, string propertyName); // 0x000000018175B8B0-0x000000018175B9D0
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x000000018175B9D0-0x000000018175BC60
		private static void EnsureReflectionObject(Type objectType); // 0x000000018175B7B0-0x000000018175B8B0
		public override bool CanConvert(Type objectType); // 0x000000018175B770-0x000000018175B7B0
	}
}
