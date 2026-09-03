/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal static class APLog // TypeDefIndex: 14134
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static bool enabled; // 0x00
		[NoAutoStaticsCleanup]
		public static readonly StringBuilder s_LogBuilder; // 0x08
		private static readonly string s_AdaptivePerformancePrefix; // 0x10
	
		// Constructors
		static APLog(); // 0x000000018212FA20-0x000000018212FAF0
	
		// Methods
		public static void Debug(string format, params object[] args); // 0x000000018212F850-0x000000018212F900
		public static void LogMessage(string format, params object[] args); // 0x000000018212F900-0x000000018212F9A0
		public static bool ShouldLog(); // 0x000000018212F9A0-0x000000018212FA20
	}
}
