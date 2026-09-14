/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public static class PokyHomeLocalization // TypeDefIndex: 2653
	{
		// Fields
		private static readonly Dictionary<string, string> BuildingKey; // 0x00
		private static Dictionary<string, string> _vi; // 0x08
	
		// Constructors
		static PokyHomeLocalization(); // 0x0000000180C31AC0-0x0000000180C31F60
	
		// Methods
		public static string Get(string key, string fallback); // 0x0000000180C30E90-0x0000000180C30F50
		public static string Format(string key, params object[] args); // 0x0000000180C30F50-0x0000000180C310B0
		private static Dictionary<string, string> Ensure(); // 0x0000000180C310B0-0x0000000180C31410
		private static void Parse(string json, Dictionary<string, string> into); // 0x0000000180C31410-0x0000000180C316D0
		private static int SkipWs(string s, int i); // 0x0000000180C316D0-0x0000000180C317F0
		private static string ReadString(string s, ref int i); // 0x0000000180C317F0-0x0000000180C31AC0
	}
}
