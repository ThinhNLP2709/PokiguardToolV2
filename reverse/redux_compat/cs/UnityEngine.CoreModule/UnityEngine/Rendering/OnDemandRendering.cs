/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[RequiredByNativeCode]
	public class OnDemandRendering // TypeDefIndex: 8316
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static int m_RenderFrameInterval; // 0x00
	
		// Properties
		public static bool willCurrentFrameRender { get; } // 0x000000018224AEB0-0x000000018224AF50 
		public static int renderFrameInterval { get; } // 0x000000018224AE60-0x000000018224AEB0 
		public static int effectiveRenderFrameRate { get; } // 0x000000018224ADF0-0x000000018224AE60 
	
		// Constructors
		static OnDemandRendering(); // 0x000000018224ADB0-0x000000018224ADF0
	
		// Methods
		[RequiredByNativeCode]
		internal static void GetRenderFrameInterval(out int frameInterval); // 0x000000018224AD20-0x000000018224ADB0
		[FreeFunction]
		internal static float GetEffectiveRenderFrameRate(); // 0x000000018224ACF0-0x000000018224AD20
	}
}
