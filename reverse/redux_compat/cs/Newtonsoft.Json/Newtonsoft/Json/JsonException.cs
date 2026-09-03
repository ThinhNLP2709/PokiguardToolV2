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
	public class JsonException : Exception // TypeDefIndex: 9976
	{
		// Constructors
		public JsonException(); // 0x00000001815FE7B0-0x00000001815FE7E0
		public JsonException(string message); // 0x00000001813FDE30-0x00000001813FDE70
		public JsonException(string message, [Nullable(2)] Exception innerException); // 0x00000001813FDED0-0x00000001813FDF70
		public JsonException(SerializationInfo info, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
	
		// Methods
		internal static JsonException Create(IJsonLineInfo lineInfo, string path, string message); // 0x000000018169BA50-0x000000018169BB00
	}
}
