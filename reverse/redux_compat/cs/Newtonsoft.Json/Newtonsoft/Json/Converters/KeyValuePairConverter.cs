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
	public class KeyValuePairConverter : JsonConverter // TypeDefIndex: 10386
	{
		// Fields
		private const string KeyName = "Key"; // Metadata: 0x006A0FE6
		private const string ValueName = "Value"; // Metadata: 0x006A0FEA
		private static readonly ThreadSafeStore<Type, ReflectionObject> ReflectionObjectPerType; // 0x00
	
		// Constructors
		public KeyValuePairConverter(); // 0x00000001802F4070-0x00000001802F4080
		static KeyValuePairConverter(); // 0x0000000181769C50-0x0000000181769D20
	
		// Methods
		private static ReflectionObject InitializeReflectionObject(Type t); // 0x0000000181769350-0x0000000181769550
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x00000001817699C0-0x0000000181769C50
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x0000000181769550-0x00000001817699C0
		public override bool CanConvert(Type objectType); // 0x0000000181769270-0x0000000181769350
	}
}
