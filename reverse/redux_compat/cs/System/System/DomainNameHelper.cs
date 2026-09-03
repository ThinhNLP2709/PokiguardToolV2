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
	internal class DomainNameHelper // TypeDefIndex: 8677
	{
		// Methods
		internal static string ParseCanonicalName(string str, int start, int end, ref bool loopback); // 0x0000000181B5D2E0-0x0000000181B5D450
		internal static unsafe bool IsValid(char* name, ushort pos, ref int returnedEnd, ref bool notCanonical, bool notImplicitFile); // 0x0000000181B5D170-0x0000000181B5D2E0
		internal static unsafe bool IsValidByIri(char* name, ushort pos, ref int returnedEnd, ref bool notCanonical, bool notImplicitFile); // 0x0000000181B5CF60-0x0000000181B5D130
		internal static unsafe string IdnEquivalent(char* hostname, int start, int end, ref bool allAscii, ref bool atLeastOneValidIdn); // 0x0000000181B5CAA0-0x0000000181B5CD00
		internal static unsafe string IdnEquivalent(char* hostname, int start, int end, ref bool allAscii, ref string bidiStrippedHost); // 0x0000000181B5CD00-0x0000000181B5CE80
		private static bool IsIdnAce(string input, int index); // 0x0000000181B5CEB0-0x0000000181B5CF30
		private static unsafe bool IsIdnAce(char* input, int index); // 0x0000000181B5CF30-0x0000000181B5CF60
		internal static unsafe string UnicodeEquivalent(string idnHost, char* hostname, int start, int end); // 0x0000000181B5D450-0x0000000181B5D500
		internal static unsafe string UnicodeEquivalent(char* hostname, int start, int end, ref bool allAscii, ref bool atLeastOneValidIdn); // 0x0000000181B5D500-0x0000000181B5D970
		private static bool IsASCIILetterOrDigit(char character, ref bool notCanonical); // 0x0000000181B5CE80-0x0000000181B5CEB0
		private static bool IsValidDomainLabelCharacter(char character, ref bool notCanonical); // 0x0000000181B5D130-0x0000000181B5D170
	}
}
