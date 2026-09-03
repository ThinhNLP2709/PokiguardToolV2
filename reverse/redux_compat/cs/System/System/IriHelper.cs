/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	internal static class IriHelper // TypeDefIndex: 8658
	{
		// Methods
		internal static bool CheckIriUnicodeRange(char unicode, bool isQuery); // 0x0000000181B453C0-0x0000000181B45420
		internal static bool CheckIriUnicodeRange(char highSurr, char lowSurr, ref bool surrogatePair, bool isQuery); // 0x0000000181B44E50-0x0000000181B453C0
		internal static bool CheckIsReserved(char ch, UriComponents component); // 0x0000000181B45420-0x0000000181B45530
		internal static unsafe string EscapeUnescapeIri(char* pInput, int start, int end, UriComponents component); // 0x0000000181B45530-0x0000000181B45E30
	}
}
