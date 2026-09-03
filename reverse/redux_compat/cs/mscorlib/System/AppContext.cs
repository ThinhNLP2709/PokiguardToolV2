/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	public static class AppContext // TypeDefIndex: 2402
	{
		// Fields
		private static readonly Dictionary<string, SwitchValueState> s_switchMap; // 0x00
		private static bool s_defaultsInitialized; // 0x08
	
		// Nested types
		[Flags]
		private enum SwitchValueState // TypeDefIndex: 2403
		{
			HasFalseValue = 1,
			HasTrueValue = 2,
			HasLookedForOverride = 4,
			UnknownValue = 8
		}
	
		// Constructors
		static AppContext(); // 0x000000018162B700-0x000000018162B7A0
	
		// Methods
		private static void InitializeDefaultSwitchValues(); // 0x000000018162B1B0-0x000000018162B2F0
		public static bool TryGetSwitch(string switchName, out bool isEnabled); // 0x000000018162B2F0-0x000000018162B700
	}
}
