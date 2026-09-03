/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Jobs
{
	public class EarlyInitHelpers // TypeDefIndex: 11424
	{
		// Fields
		[AutoStaticsCleanup]
		private static List<EarlyInitFunction> s_PendingDelegates; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both; // 0x08
	
		// Nested types
		public delegate void EarlyInitFunction(); // TypeDefIndex: 11425; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		public EarlyInitHelpers(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static EarlyInitHelpers(); // 0x0000000181C90350-0x0000000181C90400
	
		// Methods
		[OnCodeLoaded]
		private static void Initialize(); // 0x0000000181C90140-0x0000000181C90180
		public static void FlushEarlyInits(); // 0x0000000181C8FF90-0x0000000181C90140
		public static void AddEarlyInitFunction(EarlyInitFunction func); // 0x0000000181C8FE50-0x0000000181C8FF90
		public static void JobReflectionDataCreationFailed(Exception ex); // 0x0000000181C90180-0x0000000181C901F0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both(); // 0x0000000181C902E0-0x0000000181C90350
		[CompilerGenerated]
		internal static void Unity_Jobs_EarlyInitHelpers_Initialize_RegisterLifecycleMethod(); // 0x0000000181C901F0-0x0000000181C902E0
	}
}
