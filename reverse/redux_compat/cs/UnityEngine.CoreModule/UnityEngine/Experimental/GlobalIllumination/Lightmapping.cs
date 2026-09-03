/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.GlobalIllumination
{
	public static class Lightmapping // TypeDefIndex: 8221
	{
		// Fields
		[NoAutoStaticsCleanup]
		[RequiredByNativeCode]
		private static readonly RequestLightsDelegate s_DefaultDelegate; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		[RequiredByNativeCode]
		private static RequestLightsDelegate s_RequestLightsDelegate; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Nested types
		public delegate void RequestLightsDelegate(Light[] requests, NativeArray<LightDataGI> lightsOutput); // TypeDefIndex: 8222; 0x0000000180A71070-0x0000000180A710A0
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8223
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182254370-0x00000001822543E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__9_0(Light[] requests, NativeArray<LightDataGI> lightsOutput); // 0x0000000182253D30-0x0000000182254370
		}
	
		// Constructors
		static Lightmapping(); // 0x000000018224A1A0-0x000000018224A440
	
		// Methods
		[RequiredByNativeCode]
		public static void SetDelegate(RequestLightsDelegate del); // 0x000000018224A080-0x000000018224A120
		[RequiredByNativeCode]
		public static RequestLightsDelegate GetDelegate(); // 0x0000000182249EF0-0x0000000182249F40
		[RequiredByNativeCode]
		public static void ResetDelegate(); // 0x000000018224A010-0x000000018224A080
		[RequiredByNativeCode]
		internal static void RequestLights(Light[] lights, IntPtr outLightsPtr, int outLightsCount); // 0x0000000182249F40-0x000000018224A010
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018224A120-0x000000018224A1A0
	}
}
