/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Internal.Cryptography
{
	internal static class OidLookup // TypeDefIndex: 8646
	{
		// Fields
		private static readonly ConcurrentDictionary<string, string> s_lateBoundOidToFriendlyName; // 0x00
		private static readonly ConcurrentDictionary<string, string> s_lateBoundFriendlyNameToOid; // 0x08
		private static readonly Dictionary<string, string> s_friendlyNameToOid; // 0x10
		private static readonly Dictionary<string, string> s_oidToFriendlyName; // 0x18
		private static readonly Dictionary<string, string> s_compatOids; // 0x20
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8647
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000181B55CC0-0x0000000181B55D30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _.cctor_b__10_0(KeyValuePair<string, string> kvp); // 0x0000000181B55CB0-0x0000000181B55CC0
			internal string _.cctor_b__10_1(KeyValuePair<string, string> kvp); // 0x0000000180691EA0-0x0000000180691EB0
		}
	
		// Constructors
		static OidLookup(); // 0x0000000181B53670-0x0000000181B550C0
	
		// Methods
		public static string ToFriendlyName(string oid, OidGroup oidGroup, bool fallBackToAllGroups); // 0x0000000181B532F0-0x0000000181B534C0
		public static string ToOid(string friendlyName, OidGroup oidGroup, bool fallBackToAllGroups); // 0x0000000181B534C0-0x0000000181B53670
		private static bool ShouldUseCache(OidGroup oidGroup); // 0x00000001802E7990-0x00000001802E79A0
		private static string NativeOidToFriendlyName(string oid, OidGroup oidGroup, bool fallBackToAllGroups); // 0x0000000181B52FA0-0x0000000181B532F0
		private static string NativeFriendlyNameToOid(string friendlyName, OidGroup oidGroup, bool fallBackToAllGroups); // 0x0000000181B52C50-0x0000000181B52FA0
	}
}
