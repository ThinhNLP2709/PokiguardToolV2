/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	public static class Debugger // TypeDefIndex: 13500
	{
		// Fields
		private static int _logPriority; // 0x00
		private const string _LogPrefix = "<color=#0099bc><b>DOTWEEN \u25BA </b></color>"; // Metadata: 0x006A7AA2
	
		// Properties
		public static int logPriority { get; } // 0x00000001807205A0-0x00000001807205E0 
	
		// Nested types
		internal static class Sequence // TypeDefIndex: 13501
		{
			// Methods
			public static void LogAddToNullSequence(); // 0x0000000180729D40-0x0000000180729D80
			public static void LogAddToInactiveSequence(); // 0x0000000180729CC0-0x0000000180729D00
			public static void LogAddToLockedSequence(); // 0x0000000180729D00-0x0000000180729D40
			public static void LogAddNullTween(); // 0x0000000180729C80-0x0000000180729CC0
			public static void LogAddInactiveTween(Tween t); // 0x0000000180729C40-0x0000000180729C80
			public static void LogAddAlreadySequencedTween(Tween t); // 0x0000000180729C00-0x0000000180729C40
		}
	
		// Methods
		public static void Log(object message); // 0x00000001807203C0-0x00000001807204B0
		public static void LogWarning(object message, Tween t = null); // 0x0000000180720230-0x00000001807203C0
		public static void LogError(object message, Tween t = null); // 0x000000018071FAD0-0x000000018071FC60
		public static void LogSafeModeCapturedError(object message, Tween t = null); // 0x000000018071FF50-0x0000000180720150
		public static void LogReport(object message); // 0x000000018071FE70-0x000000018071FF50
		public static void LogSafeModeReport(object message); // 0x0000000180720150-0x0000000180720230
		public static void LogInvalidTween(Tween t); // 0x000000018071FC60-0x000000018071FCA0
		public static void LogNestedTween(Tween t); // 0x000000018071FD50-0x000000018071FD90
		public static void LogNullTween(Tween t); // 0x000000018071FDD0-0x000000018071FE10
		public static void LogNonPathTween(Tween t); // 0x000000018071FD90-0x000000018071FDD0
		public static void LogMissingMaterialProperty(string propertyName); // 0x000000018071FCA0-0x000000018071FCF0
		public static void LogMissingMaterialProperty(int propertyId); // 0x000000018071FCF0-0x000000018071FD50
		public static void LogRemoveActiveTweenError(string errorInfo, Tween t); // 0x000000018071FE10-0x000000018071FE70
		public static void LogAddActiveTweenError(string errorInfo, Tween t); // 0x000000018071FA70-0x000000018071FAD0
		public static void SetLogPriority(LogBehaviour logBehaviour); // 0x00000001807204B0-0x0000000180720510
		public static bool ShouldLogSafeModeCapturedError(); // 0x0000000180720510-0x00000001807205A0
		private static string GetDebugDataMessage(Tween t); // 0x000000018071FA20-0x000000018071FA70
		private static void AddDebugDataToMessage(ref string message, Tween t); // 0x000000018071F850-0x000000018071FA20
	}
}
