/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public static class AdaptivePerformanceProfilerStats // TypeDefIndex: 14192
	{
		// Fields
		public static readonly ProfilerCategory AdaptivePerformanceProfilerCategory; // 0x00
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> CurrentCPUMarker; // 0x08
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> AvgCPUMarker; // 0x18
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> CurrentGPUMarker; // 0x28
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> AvgGPUMarker; // 0x38
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<int> CurrentCPULevelMarker; // 0x48
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<int> CurrentGPULevelMarker; // 0x58
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> CurrentFrametimeMarker; // 0x68
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> AvgFrametimeMarker; // 0x78
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<int> WarningLevelMarker; // 0x88
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> TemperatureLevelMarker; // 0x98
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> TemperatureTrendMarker; // 0xA8
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<int> BottleneckMarker; // 0xB8
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<int> PerformanceModeMarker; // 0xC8
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> CpuUtilizationMarker; // 0xD8
		[NoAutoStaticsCleanup]
		public static CustomProfilerMarker<float> GpuUtilizationMarker; // 0xE8
		public static readonly Guid kAdaptivePerformanceProfilerModuleGuid; // 0xF8
		public static readonly int kScalerDataTag; // 0x108
		[NoAutoStaticsCleanup]
		private static List<ScalerInfo> scalerInfos; // 0x110
		[NoAutoStaticsCleanup]
		private static Dictionary<string, int> scalerInfosIndex; // 0x118
	
		// Nested types
		[IsReadOnly]
		public struct CustomProfilerMarker<T> // TypeDefIndex: 14193
			where T : struct
		{
			// Fields
			private readonly ProfilerMarker m_Marker;
			private readonly byte m_Type;
	
			// Constructors
			public CustomProfilerMarker(string name, ProfilerMarkerDataUnit dataUnit);
	
			// Methods
			public void Sample(T value);
			private static byte GetProfilerMarkerDataType();
		}
	
		public struct ScalerInfo // TypeDefIndex: 14194
		{
			// Fields
			public unsafe fixed /* 0x00000000-0x00000000 */ byte scalerName[0]; // 0x00
			public uint enabled; // 0x140
			public int overrideLevel; // 0x144
			public int currentLevel; // 0x148
			public int maxLevel; // 0x14C
			public float scale; // 0x150
			public uint applied; // 0x154
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _scalerName_e__FixedBuffer // TypeDefIndex: 14195
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
		}
	
		// Constructors
		static AdaptivePerformanceProfilerStats(); // 0x000000018213A9D0-0x000000018213AF80
	
		// Methods
		public static void EmitScalerDataToProfilerStream(string scalerName, bool enabled, int overrideLevel, int currentLevel, float scale, bool applied, int maxLevel); // 0x000000018213A3B0-0x000000018213A940
		public static void FlushScalerDataToProfilerStream(); // 0x000000018213A940-0x000000018213A9D0
	}
}
