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

namespace System
{
	internal static class AppContextDefaultValues // TypeDefIndex: 2440
	{
		// Fields
		internal static readonly string SwitchEnforceJapaneseEraYearRanges; // 0x00
		internal static readonly string SwitchFormatJapaneseFirstYearAsANumber; // 0x08
		internal static readonly string SwitchEnforceLegacyJapaneseDateParsing; // 0x10
	
		// Constructors
		static AppContextDefaultValues(); // 0x000000018164A630-0x000000018164A720
	
		// Methods
		public static void PopulateDefaultValues(); // 0x00000001802E76C0-0x00000001802E76D0
		public static bool TryGetSwitchOverride(string switchName, out bool overrideValue); // 0x000000018164A620-0x000000018164A630
	}
}
