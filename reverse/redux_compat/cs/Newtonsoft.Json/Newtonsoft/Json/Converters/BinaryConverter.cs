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
	public class BinaryConverter : JsonConverter // TypeDefIndex: 10371
	{
		// Fields
		private const string BinaryTypeName = "System.Data.Linq.Binary"; // Metadata: 0x006A0F68
		private const string BinaryToArrayName = "ToArray"; // Metadata: 0x006A0F80
		[Nullable(2)]
		private static ReflectionObject _reflectionObject; // 0x00
	
		// Constructors
		public BinaryConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181756C40-0x0000000181756CB0
		private byte[] GetByteArray(object value); // 0x0000000181756320-0x0000000181756550
		private static void EnsureReflectionObject(Type t); // 0x0000000181756180-0x0000000181756320
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x00000001817567C0-0x0000000181756C40
		private byte[] ReadByteArray(JsonReader reader); // 0x0000000181756550-0x00000001817567C0
		public override bool CanConvert(Type objectType); // 0x00000001817560B0-0x0000000181756180
	}
}
