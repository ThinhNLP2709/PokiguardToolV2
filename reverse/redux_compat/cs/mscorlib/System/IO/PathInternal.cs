/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal static class PathInternal // TypeDefIndex: 3650
	{
		// Fields
		private static readonly bool s_isCaseSensitive; // 0x00
	
		// Properties
		internal static bool IsCaseSensitive { get; } // 0x00000001815B2580-0x00000001815B25D0 
	
		// Constructors
		static PathInternal(); // 0x00000001815B2540-0x00000001815B2580
	
		// Methods
		internal static bool IsValidDriveChar(char value); // 0x000000018139E3D0-0x000000018139E3F0
		internal static bool EndsWithPeriodOrSpace(string path); // 0x00000001815B1780-0x00000001815B17E0
		internal static string EnsureExtendedPrefixIfNeeded(string path); // 0x00000001815B17E0-0x00000001815B1960
		internal static string EnsureExtendedPrefix(string path); // 0x00000001815B1960-0x00000001815B1A70
		internal static bool IsDevice(ReadOnlySpan<char> path); // 0x00000001815B1FC0-0x00000001815B20D0
		internal static bool IsDeviceUNC(ReadOnlySpan<char> path); // 0x00000001815B1F10-0x00000001815B1FC0
		internal static bool IsExtended(ReadOnlySpan<char> path); // 0x00000001815B20D0-0x00000001815B2130
		internal static int GetRootLength(ReadOnlySpan<char> path); // 0x00000001815B1C40-0x00000001815B1F10
		internal static bool IsDirectorySeparator(char c); // 0x000000018139E300-0x000000018139E320
		internal static bool EndsInDirectorySeparator(ReadOnlySpan<char> path); // 0x00000001815B1700-0x00000001815B1780
		internal static bool StartsWithDirectorySeparator(ReadOnlySpan<char> path); // 0x00000001815B2190-0x00000001815B2210
		internal static string TrimEndingDirectorySeparator(string path); // 0x00000001815B2210-0x00000001815B23D0
		internal static ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path); // 0x00000001815B23D0-0x00000001815B2540
		internal static bool IsRoot(ReadOnlySpan<char> path); // 0x00000001815B2130-0x00000001815B2190
		private static bool GetIsCaseSensitive(); // 0x00000001815B1A70-0x00000001815B1C40
		public static bool IsPartiallyQualified(string path); // 0x00000001802E7840-0x00000001802E7850
	}
}
