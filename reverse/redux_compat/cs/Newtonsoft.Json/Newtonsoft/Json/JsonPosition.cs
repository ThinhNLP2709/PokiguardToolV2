/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	internal struct JsonPosition // TypeDefIndex: 9982
	{
		// Fields
		private static readonly char[] SpecialCharacters; // 0x00
		internal JsonContainerType Type; // 0x00
		internal int Position; // 0x04
		[Nullable(2)]
		internal string PropertyName; // 0x08
		internal bool HasIndex; // 0x10
	
		// Constructors
		public JsonPosition(JsonContainerType type); // 0x000000018169C590-0x000000018169C610
		static JsonPosition(); // 0x000000018169C500-0x000000018169C590
	
		// Methods
		internal int CalculateLength(); // 0x000000018169C040-0x000000018169C0E0
		[NullableContext(2)]
		internal void WriteTo([Nullable(1)] StringBuilder sb, ref StringWriter writer, ref char[] buffer); // 0x000000018169C2F0-0x000000018169C500
		internal static bool TypeHasIndex(JsonContainerType type); // 0x000000018169C2E0-0x000000018169C2F0
		internal static string BuildPath(List<JsonPosition> positions, JsonPosition? currentPosition); // 0x000000018169BBF0-0x000000018169C040
		internal static string FormatMessage([Nullable(2)] IJsonLineInfo lineInfo, string path, string message); // 0x000000018169C0E0-0x000000018169C2E0
	}
}
