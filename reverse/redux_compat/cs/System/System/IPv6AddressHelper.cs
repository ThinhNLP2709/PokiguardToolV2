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
	internal static class IPv6AddressHelper // TypeDefIndex: 8653
	{
		// Methods
		internal static ValueTuple<int, int> FindCompressionRange(ReadOnlySpan<ushort> numbers); // 0x0000000181B437E0-0x0000000181B43890
		internal static bool ShouldHaveIpv4Embedded(ReadOnlySpan<ushort> numbers); // 0x0000000181B44B60-0x0000000181B44C40
		internal static unsafe bool IsValidStrict(char* name, int start, ref int end); // 0x0000000181B43C60-0x0000000181B43FD0
		internal static unsafe void Parse(ReadOnlySpan<char> address, ushort* numbers, int start, ref string scopeId); // 0x0000000181B44700-0x0000000181B44B60
		internal static string ParseCanonicalName(string str, int start, ref bool isLoopback, ref string scopeId); // 0x0000000181B43FF0-0x0000000181B44700
		private static bool IsLoopback(ReadOnlySpan<ushort> numbers); // 0x0000000181B43B80-0x0000000181B43C60
		private static unsafe bool InternalIsValid(char* name, int start, ref int end, bool validateStrictAddress); // 0x0000000181B43890-0x0000000181B43B80
		internal static unsafe bool IsValid(char* name, int start, ref int end); // 0x0000000181B43FD0-0x0000000181B43FF0
	}
}
