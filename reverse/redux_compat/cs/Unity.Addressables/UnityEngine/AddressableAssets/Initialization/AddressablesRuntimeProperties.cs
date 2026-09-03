/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Initialization
{
	public static class AddressablesRuntimeProperties // TypeDefIndex: 14114
	{
		// Fields
		private static Stack<string> s_TokenStack; // 0x00
		private static Stack<int> s_TokenStartStack; // 0x08
		private static bool s_StaticStacksAreInUse; // 0x10
		private static Dictionary<string, string> s_CachedValues; // 0x18
	
		// Constructors
		static AddressablesRuntimeProperties(); // 0x0000000181C6F5F0-0x0000000181C6F760
	
		// Methods
		private static IEnumerable<Assembly> GetAssemblies(); // 0x0000000181C6F4F0-0x0000000181C6F500
		internal static int GetCachedValueCount(); // 0x0000000181C6F500-0x0000000181C6F560
		public static void SetPropertyValue(string name, string val); // 0x0000000181C6F560-0x0000000181C6F5F0
		public static void ClearCachedPropertyValues(); // 0x0000000181C6E890-0x0000000181C6E8F0
		public static string EvaluateProperty(string name); // 0x0000000181C6E8F0-0x0000000181C6EE90
		public static string EvaluateString(string inputString); // 0x0000000181C6F320-0x0000000181C6F420
		public static string EvaluateString(string inputString, char startDelimiter, char endDelimiter, Func<string, string> varFunc); // 0x0000000181C6F420-0x0000000181C6F4F0
		private static string EvaluateStringInternal(string inputString, char startDelimiter, char endDelimiter, Func<string, string> varFunc); // 0x0000000181C6EE90-0x0000000181C6F320
	}
}
