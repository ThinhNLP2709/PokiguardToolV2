/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Serializable]
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchemaException : JsonException // TypeDefIndex: 10268
	{
		// Fields
		[CompilerGenerated]
		private readonly int _LineNumber_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly int _LinePosition_k__BackingField; // 0x94
		[CompilerGenerated]
		private readonly string _Path_k__BackingField; // 0x98
	
		// Properties
		public int LineNumber { [CompilerGenerated] get; } // 0x000000018169CBC0-0x000000018169CBD0 
		public int LinePosition { [CompilerGenerated] get; } // 0x000000018033D1E0-0x000000018033D1F0 
		public string Path { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public JsonSchemaException(); // 0x00000001816F43E0-0x00000001816F43F0
		public JsonSchemaException(string message); // 0x00000001816F43F0-0x00000001816F4400
		public JsonSchemaException(string message, Exception innerException); // 0x00000001816F4390-0x00000001816F43A0
		public JsonSchemaException(SerializationInfo info, StreamingContext context); // 0x000000018148BDC0-0x000000018148BDE0
		internal JsonSchemaException(string message, Exception innerException, string path, int lineNumber, int linePosition); // 0x00000001817238F0-0x0000000181723940
	}
}
