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
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaBuilder // TypeDefIndex: 10265
	{
		// Fields
		private readonly IList<JsonSchema> _stack; // 0x10
		private readonly JsonSchemaResolver _resolver; // 0x18
		private readonly IDictionary<string, JsonSchema> _documentSchemas; // 0x20
		private JsonSchema _currentSchema; // 0x28
		private JObject _rootSchema; // 0x30
	
		// Properties
		private JsonSchema CurrentSchema { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 10266
		{
			// Fields
			public JsonSchemaType type; // 0x10
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _MapType_b__0(KeyValuePair<string, JsonSchemaType> kv); // 0x0000000181738740-0x0000000181738750
		}
	
		// Constructors
		public JsonSchemaBuilder(JsonSchemaResolver resolver); // 0x0000000181723620-0x0000000181723700
	
		// Methods
		private void Push(JsonSchema value); // 0x0000000181722950-0x0000000181722A20
		private JsonSchema Pop(); // 0x0000000181720270-0x0000000181720330
		internal JsonSchema Read(JsonReader reader); // 0x0000000181722A20-0x0000000181722B40
		private string UnescapeReference(string reference); // 0x0000000181723570-0x0000000181723620
		private JsonSchema ResolveReferences(JsonSchema schema); // 0x0000000181722B40-0x0000000181723570
		private JsonSchema BuildSchema(JToken token); // 0x000000018171FAF0-0x000000018171FFE0
		private void ProcessSchemaProperties(JObject schemaObject); // 0x0000000181721460-0x0000000181722530
		private void ProcessExtends(JToken token); // 0x00000001817208B0-0x0000000181720C00
		private void ProcessEnum(JToken token); // 0x00000001817204F0-0x00000001817208B0
		private void ProcessAdditionalProperties(JToken token); // 0x0000000181720410-0x00000001817204F0
		private void ProcessAdditionalItems(JToken token); // 0x0000000181720330-0x0000000181720410
		private IDictionary<string, JsonSchema> ProcessProperties(JToken token); // 0x0000000181721010-0x0000000181721460
		private void ProcessItems(JToken token); // 0x0000000181720C00-0x0000000181721010
		private JsonSchemaType? ProcessType(JToken token); // 0x0000000181722530-0x0000000181722950
		internal static JsonSchemaType MapType(string type); // 0x00000001817200F0-0x0000000181720270
		internal static string MapType(JsonSchemaType type); // 0x000000018171FFE0-0x00000001817200F0
	}
}
