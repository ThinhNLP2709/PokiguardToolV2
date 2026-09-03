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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class RegexConverter : JsonConverter // TypeDefIndex: 10387
	{
		// Fields
		private const string PatternName = "Pattern"; // Metadata: 0x006A0FF0
		private const string OptionsName = "Options"; // Metadata: 0x006A0FF8
	
		// Constructors
		public RegexConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x000000018176AD10-0x000000018176AF20
		private bool HasFlag(RegexOptions options, RegexOptions flag); // 0x00000001814FA880-0x00000001814FA890
		private void WriteBson(BsonWriter writer, Regex regex); // 0x000000018176AA00-0x000000018176AB30
		private void WriteJson(JsonWriter writer, Regex regex, JsonSerializer serializer); // 0x000000018176AB30-0x000000018176AD10
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x000000018176A400-0x000000018176A5F0
		private object ReadRegexString(JsonReader reader); // 0x000000018176A8A0-0x000000018176AA00
		private Regex ReadRegexObject(JsonReader reader, JsonSerializer serializer); // 0x000000018176A5F0-0x000000018176A8A0
		public override bool CanConvert(Type objectType); // 0x000000018176A320-0x000000018176A3B0
		private bool IsRegex(Type objectType); // 0x000000018176A3B0-0x000000018176A400
	}
}
