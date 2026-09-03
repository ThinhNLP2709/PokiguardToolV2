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
	internal static class IPv4AddressHelper // TypeDefIndex: 8652
	{
		// Methods
		internal static int ParseHostNumber(ReadOnlySpan<char> str, int start, int end); // 0x0000000181B433E0-0x0000000181B434B0
		internal static unsafe bool IsValid(char* name, int start, ref int end, bool allowIPv6, bool notImplicitFile, bool unknownScheme); // 0x0000000181B42FD0-0x0000000181B43160
		private static unsafe bool ParseCanonical(ReadOnlySpan<char> name, byte* numbers, int start, int end); // 0x0000000181B43350-0x0000000181B433E0
		internal static unsafe bool IsValidCanonical(char* name, int start, ref int end, bool allowIPv6, bool notImplicitFile); // 0x0000000181B42E90-0x0000000181B42FD0
		internal static unsafe long ParseNonCanonical(char* name, int start, ref int end, bool notImplicitFile); // 0x0000000181B434B0-0x0000000181B43750
		internal static string ParseCanonicalName(string str, int start, int end, ref bool isLoopback); // 0x0000000181B43160-0x0000000181B43350
		private static unsafe bool Parse(string name, byte* numbers, int start, int end); // 0x0000000181B43750-0x0000000181B437E0
	}
}
