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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class VersionConverter : JsonConverter // TypeDefIndex: 10390
	{
		// Constructors
		public VersionConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181776F70-0x0000000181777040
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x0000000181776D40-0x0000000181776F70
		public override bool CanConvert(Type objectType); // 0x0000000181776CF0-0x0000000181776D40
	}
}
