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
	public class JsonReaderException : JsonException // TypeDefIndex: 9991
	{
		// Fields
		[CompilerGenerated]
		private readonly int _LineNumber_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly int _LinePosition_k__BackingField; // 0x94
		[CompilerGenerated]
		[Nullable(2)]
		private readonly string _Path_k__BackingField; // 0x98
	
		// Properties
		public int LineNumber { [CompilerGenerated] get; } // 0x000000018169CBC0-0x000000018169CBD0 
		public int LinePosition { [CompilerGenerated] get; } // 0x000000018033D1E0-0x000000018033D1F0 
		[Nullable(2)]
		public string Path { [NullableContext(2)] [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public JsonReaderException(); // 0x00000001815FE7B0-0x00000001815FE7E0
		public JsonReaderException(string message); // 0x00000001813FDE30-0x00000001813FDE70
		public JsonReaderException(string message, Exception innerException); // 0x00000001813FDED0-0x00000001813FDF70
		public JsonReaderException(SerializationInfo info, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
		public JsonReaderException(string message, string path, int lineNumber, int linePosition, [Nullable(2)] Exception innerException); // 0x000000018169CB30-0x000000018169CBC0
	
		// Methods
		internal static JsonReaderException Create(JsonReader reader, string message); // 0x000000018169CB20-0x000000018169CB30
		internal static JsonReaderException Create(JsonReader reader, string message, [Nullable(2)] Exception ex); // 0x000000018169C980-0x000000018169CB20
		internal static JsonReaderException Create([Nullable(2)] IJsonLineInfo lineInfo, string path, string message, [Nullable(2)] Exception ex); // 0x000000018169C840-0x000000018169C980
	}
}
