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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchemaResolver // TypeDefIndex: 10277
	{
		// Fields
		[CompilerGenerated]
		private IList<JsonSchema> _LoadedSchemas_k__BackingField; // 0x10
	
		// Properties
		public IList<JsonSchema> LoadedSchemas { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 10278
		{
			// Fields
			public string reference; // 0x10
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetSchema_b__0(JsonSchema s); // 0x0000000181738770-0x00000001817387A0
			internal bool _GetSchema_b__1(JsonSchema s); // 0x00000001817387A0-0x00000001817387D0
		}
	
		// Constructors
		public JsonSchemaResolver(); // 0x0000000181727CE0-0x0000000181727D60
	
		// Methods
		public virtual JsonSchema GetSchema(string reference); // 0x0000000181727BB0-0x0000000181727CE0
	}
}
