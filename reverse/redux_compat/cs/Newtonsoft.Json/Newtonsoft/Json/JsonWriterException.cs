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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Serializable]
	[Nullable(0)]
	[NullableContext(1)]
	public class JsonWriterException : JsonException // TypeDefIndex: 10074
	{
		// Fields
		[CompilerGenerated]
		[Nullable(2)]
		private readonly string _Path_k__BackingField; // 0x90
	
		// Properties
		[Nullable(2)]
		public string Path { [NullableContext(2)] [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
		// Constructors
		public JsonWriterException(); // 0x00000001816F43E0-0x00000001816F43F0
		public JsonWriterException(string message); // 0x00000001816F43F0-0x00000001816F4400
		public JsonWriterException(string message, Exception innerException); // 0x00000001816F4390-0x00000001816F43A0
		public JsonWriterException(SerializationInfo info, StreamingContext context); // 0x000000018148BDC0-0x000000018148BDE0
		public JsonWriterException(string message, string path, [Nullable(2)] Exception innerException); // 0x00000001816F43A0-0x00000001816F43E0
	
		// Methods
		internal static JsonWriterException Create(JsonWriter writer, string message, [Nullable(2)] Exception ex); // 0x00000001816F42B0-0x00000001816F4390
		internal static JsonWriterException Create(string path, string message, [Nullable(2)] Exception ex); // 0x00000001816F41F0-0x00000001816F42B0
	}
}
