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
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchemaGenerator // TypeDefIndex: 10269
	{
		// Fields
		[CompilerGenerated]
		private UndefinedSchemaIdHandling _UndefinedSchemaIdHandling_k__BackingField; // 0x10
		private IContractResolver _contractResolver; // 0x18
		private JsonSchemaResolver _resolver; // 0x20
		private readonly IList<TypeSchema> _stack; // 0x28
		private JsonSchema _currentSchema; // 0x30
	
		// Properties
		public UndefinedSchemaIdHandling UndefinedSchemaIdHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public IContractResolver ContractResolver { get; set; } // 0x00000001817259D0-0x0000000181725A70 0x00000001802FAF70-0x00000001802FAF80
		private JsonSchema CurrentSchema { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		private class TypeSchema // TypeDefIndex: 10270
		{
			// Fields
			[CompilerGenerated]
			private readonly Type _Type_k__BackingField; // 0x10
			[CompilerGenerated]
			private readonly JsonSchema _Schema_k__BackingField; // 0x18
	
			// Properties
			public Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
			public JsonSchema Schema { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			public TypeSchema(Type type, JsonSchema schema); // 0x0000000181737AC0-0x0000000181737B60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 10271
		{
			// Fields
			public Type type; // 0x10
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GenerateInternal_b__0(TypeSchema tc); // 0x00000001817386E0-0x0000000181738740
		}
	
		// Constructors
		public JsonSchemaGenerator(); // 0x0000000181725950-0x00000001817259D0
	
		// Methods
		private void Push(TypeSchema typeSchema); // 0x0000000181725830-0x0000000181725950
		private TypeSchema Pop(); // 0x00000001817256C0-0x0000000181725830
		public JsonSchema Generate(Type type); // 0x0000000181725110-0x0000000181725190
		public JsonSchema Generate(Type type, JsonSchemaResolver resolver); // 0x00000001817250F0-0x0000000181725110
		public JsonSchema Generate(Type type, bool rootSchemaNullable); // 0x0000000181724FA0-0x0000000181725030
		public JsonSchema Generate(Type type, JsonSchemaResolver resolver, bool rootSchemaNullable); // 0x0000000181725030-0x00000001817250F0
		private string GetTitle(Type type); // 0x0000000181725480-0x0000000181725510
		private string GetDescription(Type type); // 0x0000000181725190-0x0000000181725290
		private string GetTypeId(Type type, bool explicitOnly); // 0x0000000181725510-0x0000000181725610
		private JsonSchema GenerateInternal(Type type, Required valueRequired, bool required); // 0x0000000181723970-0x0000000181724BE0
		private JsonSchemaType AddNullType(JsonSchemaType type, Required valueRequired); // 0x0000000181723940-0x0000000181723950
		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag); // 0x00000001814FA880-0x00000001814FA890
		private void GenerateObjectSchema(Type type, JsonObjectContract contract); // 0x0000000181724BE0-0x0000000181724FA0
		private void GenerateISerializableContract(Type type, JsonISerializableContract contract); // 0x0000000181723950-0x0000000181723970
		internal static bool HasFlag(JsonSchemaType? value, JsonSchemaType flag); // 0x0000000181725610-0x00000001817256C0
		private JsonSchemaType GetJsonSchemaType(Type type, Required valueRequired); // 0x0000000181725290-0x0000000181725480
	}
}
