/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Input/TimeManager.h")]
	[StaticAccessor("GetTimeManager()", StaticAccessorType.Dot)]
	public class Time // TypeDefIndex: 7826
	{
		// Properties
		[NativeProperty("CurTime")]
		public static float time { get; } // 0x000000018221E8A0-0x000000018221E8D0 
		[NativeProperty("CurTime")]
		public static double timeAsDouble { get; } // 0x000000018221E7C0-0x000000018221E7F0 
		[NativeProperty("CurTimeRational")]
		public static RationalTime timeAsRational { get; } // 0x000000018221E830-0x000000018221E870 
		public static float deltaTime { get; } // 0x000000018221E640-0x000000018221E670 
		public static float unscaledTime { get; } // 0x000000018221E900-0x000000018221E930 
		public static float fixedUnscaledTime { get; } // 0x000000018221E6A0-0x000000018221E6D0 
		public static float unscaledDeltaTime { get; } // 0x000000018221E8D0-0x000000018221E900 
		public static float fixedDeltaTime { get; set; } // 0x000000018221E670-0x000000018221E6A0 0x000000018221E930-0x000000018221E970
		public static float smoothDeltaTime { get; } // 0x000000018221E790-0x000000018221E7C0 
		public static float timeScale { get; set; } // 0x000000018221E870-0x000000018221E8A0 0x000000018221E970-0x000000018221E9B0
		public static int frameCount { get; } // 0x000000018221E6D0-0x000000018221E700 
		[NativeProperty("RenderFrameCount")]
		public static int renderedFrameCount { get; } // 0x000000018221E760-0x000000018221E790 
		[NativeProperty("Realtime")]
		public static float realtimeSinceStartup { get; } // 0x000000018221E730-0x000000018221E760 
		[NativeProperty("Realtime")]
		public static double realtimeSinceStartupAsDouble { get; } // 0x000000018221E700-0x000000018221E730 
	
		// Methods
		private static void get_timeAsRational_Injected(); // 0x000000018221E7F0-0x000000018221E830
	}
}
