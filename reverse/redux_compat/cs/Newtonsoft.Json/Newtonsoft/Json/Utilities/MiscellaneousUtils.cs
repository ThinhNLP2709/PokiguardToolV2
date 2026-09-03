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
using System.Text.RegularExpressions;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class MiscellaneousUtils // TypeDefIndex: 10168
	{
		// Methods
		[Conditional("DEBUG")]
		[NullableContext(2)]
		public static void Assert([DoesNotReturnIf(false)] bool condition, string message = null); // 0x00000001802E76C0-0x00000001802E76D0
		[NullableContext(2)]
		public static bool ValueEquals(object objA, object objB); // 0x00000001816F4F80-0x00000001816F52D0
		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string paramName, object actualValue, string message); // 0x00000001816F4B50-0x00000001816F4C20
		public static string ToString([Nullable(2)] object value); // 0x00000001816F4EF0-0x00000001816F4F80
		public static int ByteArrayCompare(byte[] a1, byte[] a2); // 0x00000001816F4AB0-0x00000001816F4B50
		public static string GetPrefix(string qualifiedName); // 0x00000001816F4CE0-0x00000001816F4DA0
		public static string GetLocalName(string qualifiedName); // 0x00000001816F4C20-0x00000001816F4CE0
		public static void GetQualifiedNameParts(string qualifiedName, [Nullable(2)] out string prefix, out string localName); // 0x00000001816F4DA0-0x00000001816F4E60
		internal static RegexOptions GetRegexOptions(string optionsText); // 0x00000001816F4E60-0x00000001816F4EF0
	}
}
