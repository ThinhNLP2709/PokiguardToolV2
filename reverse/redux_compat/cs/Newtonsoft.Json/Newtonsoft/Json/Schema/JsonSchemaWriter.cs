/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaWriter // TypeDefIndex: 10280
	{
		// Fields
		private readonly JsonWriter _writer; // 0x10
		private readonly JsonSchemaResolver _resolver; // 0x18
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10281
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<JsonSchemaType, bool> __9__7_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001817388B0-0x0000000181738920
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _WriteType_b__7_0(JsonSchemaType v); // 0x0000000181738200-0x0000000181738210
		}
	
		// Constructors
		public JsonSchemaWriter(JsonWriter writer, JsonSchemaResolver resolver); // 0x00000001817299B0-0x0000000181729A30
	
		// Methods
		private void ReferenceOrWriteSchema(JsonSchema schema); // 0x0000000181727D60-0x0000000181727E80
		public void WriteSchema(JsonSchema schema); // 0x0000000181728430-0x0000000181729590
		private void WriteSchemaDictionaryIfNotNull(JsonWriter writer, string propertyName, IDictionary<string, JsonSchema> properties); // 0x00000001817281B0-0x0000000181728430
		private void WriteItems(JsonSchema schema); // 0x0000000181727E80-0x0000000181728150
		private void WriteType(string propertyName, JsonWriter writer, JsonSchemaType type); // 0x0000000181729590-0x00000001817299B0
		private void WritePropertyIfNotNull(JsonWriter writer, string propertyName, object value); // 0x0000000181728150-0x00000001817281B0
	}
}
