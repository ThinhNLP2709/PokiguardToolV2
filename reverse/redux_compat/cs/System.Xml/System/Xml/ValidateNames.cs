/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal static class ValidateNames // TypeDefIndex: 6865
	{
		// Fields
		private static XmlCharType xmlCharType; // 0x00
	
		// Constructors
		static ValidateNames(); // 0x0000000181A966B0-0x0000000181A96710
	
		// Methods
		internal static int ParseNmtoken(string s, int offset); // 0x0000000181A96050-0x0000000181A96130
		internal static int ParseNmtokenNoNamespaces(string s, int offset); // 0x0000000181A95F60-0x0000000181A96050
		internal static int ParseNameNoNamespaces(string s, int offset); // 0x0000000181A95E30-0x0000000181A95F60
		internal static bool IsNameNoNamespaces(string s); // 0x0000000181A95C70-0x0000000181A95CE0
		internal static int ParseNCName(string s, int offset); // 0x0000000181A95D30-0x0000000181A95E30
		internal static int ParseNCName(string s); // 0x0000000181A95CE0-0x0000000181A95D30
		internal static int ParseQName(string s, int offset, out int colonOffset); // 0x0000000181A962C0-0x0000000181A96380
		internal static void ParseQNameThrow(string s, out string prefix, out string localName); // 0x0000000181A96130-0x0000000181A962C0
		internal static void ThrowInvalidName(string s, int offsetStartChar, int offsetBadChar); // 0x0000000181A964D0-0x0000000181A966B0
		internal static Exception GetInvalidNameException(string s, int offsetStartChar, int offsetBadChar); // 0x0000000181A95A10-0x0000000181A95C70
		internal static void SplitQName(string name, out string prefix, out string lname); // 0x0000000181A96380-0x0000000181A964D0
	}
}
