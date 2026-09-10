/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public static class PokyHomeLocalization // TypeDefIndex: 2210
	{
		// Fields
		private const string RES_PATH = "PokyHome/poky_lang"; // Metadata: 0x0068E1D5
		private static readonly Dictionary<string, string> BuildingKey; // 0x00
		private static Dictionary<string, string> _vi; // 0x08
	
		// Properties
		public static int Count { get; } // 0x0000000180783540-0x00000001807835A0 
	
		// Constructors
		static PokyHomeLocalization(); // 0x0000000180783200-0x0000000180783540
	
		// Methods
		public static void Reload(); // 0x0000000180783100-0x0000000180783180
		public static string Get(string key, string fallback); // 0x0000000180782B50-0x0000000180782C10
		public static string Format(string key, params object[] args); // 0x0000000180782A80-0x0000000180782B50
		public static string Building(string nodeName); // 0x0000000180782710-0x00000001807827D0
		public static string BuildingLangKey(string nodeName); // 0x0000000180782650-0x0000000180782710
		private static Dictionary<string, string> Ensure(); // 0x00000001807827D0-0x0000000180782A80
		private static void Parse(string json, Dictionary<string, string> into); // 0x0000000180782C10-0x0000000180782EA0
		private static int SkipWs(string s, int i); // 0x0000000180783180-0x0000000180783200
		private static string ReadString(string s, ref int i); // 0x0000000180782EA0-0x0000000180783100
	}
}
