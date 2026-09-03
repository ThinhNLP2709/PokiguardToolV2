/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaNode // TypeDefIndex: 10274
	{
		// Fields
		[CompilerGenerated]
		private readonly string _Id_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly ReadOnlyCollection<JsonSchema> _Schemas_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly Dictionary<string, JsonSchemaNode> _Properties_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly Dictionary<string, JsonSchemaNode> _PatternProperties_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly List<JsonSchemaNode> _Items_k__BackingField; // 0x30
		[CompilerGenerated]
		private JsonSchemaNode _AdditionalProperties_k__BackingField; // 0x38
		[CompilerGenerated]
		private JsonSchemaNode _AdditionalItems_k__BackingField; // 0x40
	
		// Properties
		public string Id { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public ReadOnlyCollection<JsonSchema> Schemas { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Dictionary<string, JsonSchemaNode> Properties { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public Dictionary<string, JsonSchemaNode> PatternProperties { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public List<JsonSchemaNode> Items { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
		public JsonSchemaNode AdditionalProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public JsonSchemaNode AdditionalItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10275
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<JsonSchema, string> __9__26_0; // 0x08
			public static Func<string, string> __9__26_1; // 0x10
	
			// Constructors
			static __c(); // 0x00000001817387D0-0x0000000181738840
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _GetId_b__26_0(JsonSchema s); // 0x00000001817381C0-0x00000001817381E0
			internal string _GetId_b__26_1(string id); // 0x0000000180A68C50-0x0000000180A68C60
		}
	
		// Constructors
		public JsonSchemaNode(JsonSchema schema); // 0x0000000181727780-0x0000000181727950
		private JsonSchemaNode(JsonSchemaNode source, JsonSchema schema); // 0x0000000181727950-0x0000000181727BB0
	
		// Methods
		public JsonSchemaNode Combine(JsonSchema schema); // 0x00000001817274D0-0x0000000181727540
		public static string GetId(IEnumerable<JsonSchema> schemata); // 0x0000000181727540-0x0000000181727780
	}
}
