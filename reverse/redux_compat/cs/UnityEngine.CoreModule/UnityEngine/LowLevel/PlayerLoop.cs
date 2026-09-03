/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LowLevel
{
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	public class PlayerLoop // TypeDefIndex: 8013
	{
		// Methods
		public static PlayerLoopSystem GetCurrentPlayerLoop(); // 0x000000018224D9D0-0x000000018224DA40
		public static void SetPlayerLoop(PlayerLoopSystem loop); // 0x000000018224DFF0-0x000000018224E0E0
		private static int PlayerLoopSystemToInternal(PlayerLoopSystem sys, ref List<PlayerLoopSystemInternal> internalSys); // 0x000000018224DD00-0x000000018224DFB0
		private static PlayerLoopSystem InternalToPlayerLoopSystem(PlayerLoopSystemInternal[] internalSys, ref int offset); // 0x000000018224DA40-0x000000018224DD00
		[NativeMethod(IsFreeFunction = true)]
		private static PlayerLoopSystemInternal[] GetCurrentPlayerLoopInternal(); // 0x000000018224D9A0-0x000000018224D9D0
		[NativeMethod(IsFreeFunction = true)]
		private static void SetPlayerLoopInternal(PlayerLoopSystemInternal[] loop); // 0x000000018224DFB0-0x000000018224DFF0
	}
}
