/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Data;
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
	public class DataTableConverter : JsonConverter // TypeDefIndex: 10375
	{
		// Constructors
		public DataTableConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181759500-0x0000000181759A90
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x0000000181759200-0x0000000181759500
		private static void CreateRow(JsonReader reader, DataTable dt, JsonSerializer serializer); // 0x0000000181758B70-0x0000000181759020
		private static Type GetColumnDataType(JsonReader reader); // 0x0000000181759020-0x0000000181759200
		public override bool CanConvert(Type valueType); // 0x0000000181758B00-0x0000000181758B70
	}
}
