/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/ScreenManager.h")]
	[NativeHeader("Runtime/Graphics/WindowLayout.h")]
	[StaticAccessor("GetScreenManager()", StaticAccessorType.Dot)]
	public sealed class Screen // TypeDefIndex: 7545
	{
		// Properties
		public static int width { [NativeMethod(Name = "GetWidth", IsThreadSafe = true)] get; } // 0x00000001821BFC40-0x00000001821BFC70 
		public static int height { [NativeMethod(Name = "GetHeight", IsThreadSafe = true)] get; } // 0x00000001821BFB90-0x00000001821BFBC0 
		public static float dpi { [NativeName("GetDPI")] get; } // 0x00000001821BFB30-0x00000001821BFB60 
		public static ScreenOrientation orientation { get; } // 0x00000001821BF910-0x00000001821BF940 
		public static Resolution currentResolution { get; } // 0x00000001821BFAF0-0x00000001821BFB30 
		public static bool fullScreen { [NativeName("IsFullscreen")] get; } // 0x00000001821BFB60-0x00000001821BFB90 
		public static Rect safeArea { get; } // 0x00000001821BFC00-0x00000001821BFC40 
		public static int msaaSamples { get; } // 0x00000001821BF8E0-0x00000001821BF910 
		public static int currentBackbufferMSAASamples { get; } // 0x00000001821BF8B0-0x00000001821BF8E0 
	
		// Methods
		private static ScreenOrientation GetScreenOrientation(); // 0x00000001821BF910-0x00000001821BF940
		[NativeName("RequestResolution")]
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, RefreshRate preferredRefreshRate); // 0x00000001821BF9E0-0x00000001821BFA40
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode); // 0x00000001821BFA40-0x00000001821BFAB0
		[NativeName("SetRequestedMSAASamples")]
		public static void SetMSAASamples(int numSamples); // 0x00000001821BF940-0x00000001821BF980
		[NativeName("GetRequestedMSAASamples")]
		private static int GetMSAASamples(); // 0x00000001821BF8E0-0x00000001821BF910
		[NativeName("GetCurrentBackbufferMSAASamples")]
		private static int GetCurrentBackbufferMSAASamplesInternal(); // 0x00000001821BF8B0-0x00000001821BF8E0
		private static void get_currentResolution_Injected(); // 0x00000001821BFAB0-0x00000001821BFAF0
		private static void get_safeArea_Injected(); // 0x00000001821BFBC0-0x00000001821BFC00
		private static void SetResolution_Injected(int width, int height, FullScreenMode fullscreenMode, in RefreshRate preferredRefreshRate); // 0x00000001821BF980-0x00000001821BF9E0
	}
}
