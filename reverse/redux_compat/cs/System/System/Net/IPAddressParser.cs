/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class IPAddressParser // TypeDefIndex: 9005
	{
		// Methods
		internal static IPAddress Parse(ReadOnlySpan<char> ipSpan, bool tryParse); // 0x0000000181BF0F30-0x0000000181BF1290
		internal static string IPv4AddressToString(uint address); // 0x0000000181BF0800-0x0000000181BF0860
		internal static void IPv4AddressToString(uint address, StringBuilder destination); // 0x0000000181BF0860-0x0000000181BF08D0
		private static unsafe int IPv4AddressToStringHelper(uint address, char* addressString); // 0x0000000181BF05B0-0x0000000181BF0800
		internal static string IPv6AddressToString(ushort[] address, uint scopeId); // 0x0000000181BF0D20-0x0000000181BF0D40
		internal static StringBuilder IPv6AddressToStringHelper(ushort[] address, uint scopeId); // 0x0000000181BF08D0-0x0000000181BF0D20
		private static unsafe void FormatIPv4AddressNumber(int number, char* addressString, ref int offset); // 0x0000000181BF04F0-0x0000000181BF05B0
		public static bool Ipv4StringToAddress(ReadOnlySpan<char> ipSpan, out long address); // 0x0000000181BF0D40-0x0000000181BF0E00
		public static unsafe bool Ipv6StringToAddress(ReadOnlySpan<char> ipSpan, ushort* numbers, int numbersLength, out uint scope); // 0x0000000181BF0E00-0x0000000181BF0F30
		private static void AppendSections(ushort[] address, int fromInclusive, int toExclusive, StringBuilder buffer); // 0x0000000181BF02C0-0x0000000181BF04A0
		private static void AppendHex(ushort value, StringBuilder buffer); // 0x0000000181BF0220-0x0000000181BF02C0
		private static uint ExtractIPv4Address(ushort[] address); // 0x0000000181BF04A0-0x0000000181BF04F0
		private static ushort Reverse(ushort number); // 0x00000001815A6F30-0x00000001815A6F40
	}
}
