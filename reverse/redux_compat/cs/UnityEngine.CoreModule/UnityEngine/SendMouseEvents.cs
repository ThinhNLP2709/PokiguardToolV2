/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.InputModule" })]
	internal class SendMouseEvents // TypeDefIndex: 7836
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_MouseUsed; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly HitInfo[] m_LastHit; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly HitInfo[] m_MouseDownHit; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly HitInfo[] m_CurrentHit; // 0x18
		[AutoStaticsCleanupOnCodeReload]
		private static Camera[] m_Cameras; // 0x20
		[AutoStaticsCleanupOnCodeReload]
		public static Func<KeyValuePair<int, Vector2>> s_GetMouseState; // 0x28
		[AutoStaticsCleanupOnCodeReload]
		private static Vector2 s_MousePosition; // 0x30
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_MouseButtonPressedThisFrame; // 0x38
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_MouseButtonIsPressed; // 0x39
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x40
	
		// Nested types
		private struct HitInfo // TypeDefIndex: 7837
		{
			// Fields
			public GameObject target; // 0x00
			public Camera camera; // 0x08
	
			// Methods
			public void SendMessage(string name); // 0x0000000182205E20-0x0000000182205E50
			public static implicit operator bool(HitInfo exists); // 0x0000000182205E50-0x0000000182205EC0
			public static bool Compare(HitInfo lhs, HitInfo rhs); // 0x0000000182205DA0-0x0000000182205E20
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 7838
		{
			// Fields
			public static Action _0___ResetHitArrays; // 0x00
		}
	
		// Constructors
		static SendMouseEvents(); // 0x0000000182212480-0x00000001822126F0
	
		// Methods
		private static void ResetHitArrays(); // 0x0000000182211770-0x0000000182211890
		private static void ResetHitInfoArray(HitInfo[] array); // 0x0000000182211890-0x00000001822118E0
		private static void UpdateMouse(); // 0x00000001822122B0-0x0000000182212380
		[RequiredByNativeCode]
		[VisibleToOtherModules(new string[1] {"UnityEngine.InputModule" })]
		internal static void SetMouse(bool pressed, bool pressedThisFrame, float positionX, float positionY); // 0x00000001822120B0-0x0000000182212160
		[RequiredByNativeCode]
		private static void SetMouseMoved(); // 0x0000000182212060-0x00000001822120B0
		[RequiredByNativeCode]
		[VisibleToOtherModules(new string[1] {"UnityEngine.InputModule" })]
		internal static void DoSendMouseEvents(int skipRTCameras); // 0x0000000182210BC0-0x0000000182211770
		private static void SendEvents(int i, HitInfo hit); // 0x00000001822118E0-0x0000000182212060
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182212380-0x0000000182212480
		[CompilerGenerated]
		internal static void UnityEngine_SendMouseEvents_ResetHitArrays_RegisterLifecycleMethod(); // 0x0000000182212160-0x00000001822122B0
	}
}
