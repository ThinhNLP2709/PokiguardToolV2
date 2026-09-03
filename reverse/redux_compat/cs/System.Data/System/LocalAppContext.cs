/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System
{
	internal class LocalAppContext // TypeDefIndex: 11186
	{
		// Fields
		private static bool s_isDisableCachingInitialized; // 0x00
		private static bool s_disableCaching; // 0x01
		private static object s_syncObject; // 0x08
	
		// Properties
		private static bool DisableCaching { get; } // 0x0000000181861060-0x00000001818611A0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11187
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<bool> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181861420-0x0000000181861490
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _get_DisableCaching_b__6_0(); // 0x00000001818613B0-0x0000000181861420
		}
	
		// Methods
		internal static bool GetCachedSwitchValue(string switchName, ref int switchValue); // 0x0000000181861040-0x0000000181861060
		private static bool GetCachedSwitchValueInternal(string switchName, ref int switchValue); // 0x0000000181860EA0-0x0000000181861040
	}
}
