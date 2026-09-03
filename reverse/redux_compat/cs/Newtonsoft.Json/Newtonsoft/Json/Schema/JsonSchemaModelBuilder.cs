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
	internal class JsonSchemaModelBuilder // TypeDefIndex: 10273
	{
		// Fields
		private JsonSchemaNodeCollection _nodes; // 0x10
		private Dictionary<JsonSchemaNode, JsonSchemaModel> _nodeModels; // 0x18
		private JsonSchemaNode _node; // 0x20
	
		// Constructors
		public JsonSchemaModelBuilder(); // 0x0000000181726D10-0x0000000181726DE0
	
		// Methods
		public JsonSchemaModel Build(JsonSchema schema); // 0x0000000181726C10-0x0000000181726D10
		public JsonSchemaNode AddSchema(JsonSchemaNode existingNode, JsonSchema schema); // 0x0000000181725F70-0x00000001817265C0
		public void AddProperties(IDictionary<string, JsonSchema> source, IDictionary<string, JsonSchemaNode> target); // 0x0000000181725C10-0x0000000181725DF0
		public void AddProperty(IDictionary<string, JsonSchemaNode> target, string propertyName, JsonSchema schema); // 0x0000000181725DF0-0x0000000181725F70
		public void AddItem(JsonSchemaNode parentNode, int index, JsonSchema schema); // 0x0000000181725AF0-0x0000000181725C10
		public void AddAdditionalProperties(JsonSchemaNode parentNode, JsonSchema schema); // 0x0000000181725AB0-0x0000000181725AF0
		public void AddAdditionalItems(JsonSchemaNode parentNode, JsonSchema schema); // 0x0000000181725A70-0x0000000181725AB0
		private JsonSchemaModel BuildNodeModel(JsonSchemaNode node); // 0x00000001817265C0-0x0000000181726C10
	}
}
