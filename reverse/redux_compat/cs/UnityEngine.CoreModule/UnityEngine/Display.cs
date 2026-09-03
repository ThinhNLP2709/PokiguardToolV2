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

namespace UnityEngine
{
	[NativeHeader("Runtime/Graphics/DisplayManager.h")]
	[UsedByNativeCode]
	public class Display // TypeDefIndex: 7538
	{
		// Fields
		internal IntPtr nativeDisplay; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		public static Display[] displays; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static Display _mainDisplay; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static int m_ActiveEditorGameViewTarget; // 0x10
		[CompilerGenerated]
		private static DisplaysUpdatedDelegate onDisplaysUpdated; // 0x18
	
		// Properties
		public int renderingWidth { get; } // 0x000000018219D980-0x000000018219DA00 
		public int renderingHeight { get; } // 0x000000018219D900-0x000000018219D980 
		public int systemWidth { get; } // 0x000000018219DAF0-0x000000018219DB70 
		public int systemHeight { get; } // 0x000000018219DA70-0x000000018219DAF0 
		public bool requiresSrgbBlitToBackbuffer { get; } // 0x000000018219DA00-0x000000018219DA70 
		public static Display main { get; } // 0x000000018219D8B0-0x000000018219D900 
	
		// Nested types
		public delegate void DisplaysUpdatedDelegate(); // TypeDefIndex: 7539; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		internal Display(); // 0x000000018219D870-0x000000018219D8B0
		internal Display(IntPtr nativeDisplay); // 0x000000018219D840-0x000000018219D870
		static Display(); // 0x000000018219D6B0-0x000000018219D840
	
		// Methods
		public static Vector3 RelativeMouseAt(Vector3 inputMouseCoordinates); // 0x000000018219D5A0-0x000000018219D670
		[RequiredByNativeCode]
		internal static void RecreateDisplayList(IntPtr[] nativeDisplay); // 0x000000018219D390-0x000000018219D540
		[RequiredByNativeCode]
		internal static void FireDisplaysUpdated(); // 0x000000018219D260-0x000000018219D2D0
		[FreeFunction("UnityDisplayManager_DisplaySystemResolution")]
		private static void GetSystemExtImpl(IntPtr nativeDisplay, out int w, out int h); // 0x000000018219D330-0x000000018219D390
		[FreeFunction("UnityDisplayManager_DisplayRenderingResolution")]
		private static void GetRenderingExtImpl(IntPtr nativeDisplay, out int w, out int h); // 0x000000018219D2D0-0x000000018219D330
		[FreeFunction("UnityDisplayManager_RelativeMouseAt")]
		private static int RelativeMouseAtImpl(int x, int y, out int rx, out int ry); // 0x000000018219D540-0x000000018219D5A0
		[FreeFunction("UnityDisplayManager_RequiresSRGBBlitToBackbuffer")]
		private static bool RequiresSrgbBlitToBackbufferImpl(IntPtr nativeDisplay); // 0x000000018219D670-0x000000018219D6B0
	}
}
