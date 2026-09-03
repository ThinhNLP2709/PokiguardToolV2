/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;

// Image 41: UnityEngine.UIModule.dll - Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15192-15207

namespace UnityEngine
{
	[IgnoredByDeepProfiler]
	[NativeHeader("Modules/UI/Canvas.h")]
	[StaticAccessor("UI::SystemProfilerApi", StaticAccessorType.DoubleColon)]
	public static class UISystemProfilerApi // TypeDefIndex: 15206
	{
		// Nested types
		public enum SampleType // TypeDefIndex: 15207
		{
			Layout = 0,
			Render = 1
		}
	
		// Methods
		public static void BeginSample(SampleType type); // 0x0000000182582350-0x0000000182582390
		public static void EndSample(SampleType type); // 0x0000000182582390-0x00000001825823D0
		public static void AddMarker(string name, Object obj); // 0x00000001825821F0-0x0000000182582350
		private static void AddMarker_Injected(ref ManagedSpanWrapper name, IntPtr obj); // 0x00000001825821A0-0x00000001825821F0
	}
}
