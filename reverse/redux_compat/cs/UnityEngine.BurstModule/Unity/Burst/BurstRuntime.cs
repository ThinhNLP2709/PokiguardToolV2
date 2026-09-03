/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	public static class BurstRuntime // TypeDefIndex: 15010
	{
		// Nested types
		private struct HashCode64<T> // TypeDefIndex: 15011
		{
			// Fields
			public static readonly long Value;
	
			// Constructors
			static HashCode64();
		}
	
		// Methods
		public static long GetHashCode64<T>();
		internal static long HashStringWithFNV1A64(string text); // 0x000000018216FFC0-0x0000000182170050
		internal static unsafe void RuntimeLog(byte* message, int logType, byte* fileName, int lineNumber); // 0x0000000182170120-0x0000000182170190
		internal static void PreventRequiredAttributeStrip(); // 0x00000001821700B0-0x0000000182170120
		[RequiredByNativeCode(Optional = true)]
		internal static unsafe void Log(byte* message, int logType, byte* fileName, int lineNumber); // 0x0000000182170050-0x00000001821700B0
	}
}
