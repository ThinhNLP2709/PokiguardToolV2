/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	public static class PokyHomeLocalization // TypeDefIndex: 1883
	{
		// Fields
		private const string RES_PATH = "PokyHome/poky_lang"; // Metadata: 0x0064DD55
		private static readonly Dictionary<string, string> BuildingKey; // 0x00
		private static Dictionary<string, string> _vi; // 0x08
	
		// Properties
		public static int Count { get; } // 0x000000018062EBF0-0x000000018062EC50 
	
		// Constructors
		static PokyHomeLocalization(); // 0x000000018062E8B0-0x000000018062EBF0
	
		// Methods
		public static void Reload(); // 0x000000018062E7B0-0x000000018062E830
		public static string Get(string key, string fallback); // 0x000000018062E200-0x000000018062E2C0
		public static string Format(string key, params object[] args); // 0x000000018062E130-0x000000018062E200
		public static string Building(string nodeName); // 0x000000018062DDC0-0x000000018062DE80
		public static string BuildingLangKey(string nodeName); // 0x000000018062DD00-0x000000018062DDC0
		private static Dictionary<string, string> Ensure(); // 0x000000018062DE80-0x000000018062E130
		private static void Parse(string json, Dictionary<string, string> into); // 0x000000018062E2C0-0x000000018062E550
		private static int SkipWs(string s, int i); // 0x000000018062E830-0x000000018062E8B0
		private static string ReadString(string s, ref int i); // 0x000000018062E550-0x000000018062E7B0
	}
}
