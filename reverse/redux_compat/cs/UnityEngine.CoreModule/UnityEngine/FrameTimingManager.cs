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
	[StaticAccessor("GetUncheckedRealGfxDevice().GetFrameTimingManager()", StaticAccessorType.Dot)]
	public static class FrameTimingManager // TypeDefIndex: 7552
	{
		// Methods
		public static void CaptureFrameTimings(); // 0x000000018219DB70-0x000000018219DBA0
		public static uint GetLatestTimings(uint numFrames, FrameTiming[] timings); // 0x000000018219DBE0-0x000000018219DC70
		private static uint GetLatestTimings_Injected(uint numFrames, ref ManagedSpanWrapper timings); // 0x000000018219DBA0-0x000000018219DBE0
	}
}
