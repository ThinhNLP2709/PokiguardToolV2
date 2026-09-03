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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class ValidationEventArgs : EventArgs // TypeDefIndex: 10283
	{
		// Fields
		private readonly JsonSchemaException _ex; // 0x10
	
		// Properties
		public JsonSchemaException Exception { get; } // 0x0000000180377550-0x0000000180377560 
		public string Path { get; } // 0x0000000181738F30-0x0000000181739090 
		public string Message { get; } // 0x0000000181738F00-0x0000000181738F30 
	
		// Constructors
		internal ValidationEventArgs(JsonSchemaException ex); // 0x0000000181738E70-0x0000000181738F00
	}
}
