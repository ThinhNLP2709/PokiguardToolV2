/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class AutoPerformanceLevelController // TypeDefIndex: 14135
	{
		// Fields
		private IDevicePerformanceControl m_PerfControl; // 0x10
		private IPerformanceStatus m_PerfStats; // 0x18
		private IThermalStatus m_ThermalStats; // 0x20
		private float m_LastChangeTimeStamp; // 0x28
		private float m_LastGpuLevelRaiseTimeStamp; // 0x2C
		private float m_LastCpuLevelRaiseTimeStamp; // 0x30
		private float m_TargetFrameRateHitTimestamp; // 0x34
		private float m_BottleneckUnknownTimestamp; // 0x38
		private bool m_TriedToResolveUnknownBottleneck; // 0x3C
		private bool m_Enabled; // 0x3D
		private string m_FeatureName; // 0x40
		[CompilerGenerated]
		private float _TargetFrameTime_k__BackingField; // 0x48
		[CompilerGenerated]
		private float _AllowedCpuActiveTimeRatio_k__BackingField; // 0x4C
		[CompilerGenerated]
		private float _AllowedGpuActiveTimeRatio_k__BackingField; // 0x50
		[CompilerGenerated]
		private float _GpuLevelBounceAvoidanceThreshold_k__BackingField; // 0x54
		[CompilerGenerated]
		private float _CpuLevelBounceAvoidanceThreshold_k__BackingField; // 0x58
		[CompilerGenerated]
		private float _UpdateInterval_k__BackingField; // 0x5C
		[CompilerGenerated]
		private float _MinTargetFrameRateHitTime_k__BackingField; // 0x60
		[CompilerGenerated]
		private float _MaxTemperatureLevel_k__BackingField; // 0x64
		[CompilerGenerated]
		private float _MinCpuUtilizationLevel_k__BackingField; // 0x68
		[CompilerGenerated]
		private float _MinGpuUtilizationLevel_k__BackingField; // 0x6C
		[CompilerGenerated]
		private float _FastLowerCpuUtilizationLevel_k__BackingField; // 0x70
		[CompilerGenerated]
		private float _FastLowerGpuUtilizationLevel_k__BackingField; // 0x74
	
		// Properties
		public float TargetFrameTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018047EDF0-0x000000018047EE00 0x0000000181D8BEF0-0x0000000181D8BF00
		public float AllowedCpuActiveTimeRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC50-0x0000000181D8CC60 0x0000000182141FB0-0x0000000182141FC0
		public float AllowedGpuActiveTimeRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000182141FC0-0x0000000182141FD0
		public float GpuLevelBounceAvoidanceThreshold { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x00000001820CF470-0x00000001820CF480
		public float CpuLevelBounceAvoidanceThreshold { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181DB54E0-0x0000000181DB54F0
		public float UpdateInterval { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 0x0000000181DB54F0-0x0000000181DB5500
		public float MinTargetFrameRateHitTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181DB5660-0x0000000181DB5670
		public float MaxTemperatureLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182141FA0-0x0000000182141FB0 0x0000000182141FF0-0x0000000182142000
		public float MinCpuUtilizationLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C245B0-0x0000000180C245C0 0x0000000180C24770-0x0000000180C24780
		public float MinGpuUtilizationLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C24480-0x0000000180C24490 0x0000000180C245C0-0x0000000180C245D0
		public float FastLowerCpuUtilizationLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F7C310-0x0000000181F7C320 0x0000000182141FE0-0x0000000182141FF0
		public float FastLowerGpuUtilizationLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F63F10-0x0000000181F63F20 0x0000000181F64900-0x0000000181F64910
		public bool Enabled { get; set; } // 0x0000000182141F90-0x0000000182141FA0 0x0000000182141FD0-0x0000000182141FE0
	
		// Constructors
		public AutoPerformanceLevelController(IDevicePerformanceControl perfControl, IPerformanceStatus perfStat, IThermalStatus thermalStat); // 0x0000000182141DC0-0x0000000182141F90
	
		// Methods
		public void Update(); // 0x0000000182141D90-0x0000000182141DC0
		public void Override(int requestedCpuLevel, int requestedGpuLevel); // 0x0000000182141370-0x0000000182141450
		private void UpdateImpl(float timestamp); // 0x0000000182141730-0x0000000182141D90
		private void OnBottleneckChange(PerformanceBottleneckChangeEventArgs ev); // 0x0000000182141320-0x0000000182141370
		private void RaiseGpuLevel(float timestamp); // 0x00000001821415C0-0x0000000182141730
		private void RaiseCpuLevel(float timestamp); // 0x0000000182141450-0x00000001821415C0
		private void LowerCpuLevel(float timestamp); // 0x0000000182141040-0x00000001821411B0
		private void LowerGpuLevel(float timestamp); // 0x00000001821411B0-0x0000000182141320
		private bool AllowLowerCpuLevel(float timestamp); // 0x00000001821406C0-0x0000000182140800
		private bool AllowLowerGpuLevel(float timestamp); // 0x0000000182140800-0x0000000182140940
		private bool AllowRaiseLevels(); // 0x0000000182140E00-0x0000000182141040
		private bool AllowRaiseCpuLevel(); // 0x0000000182140940-0x0000000182140BA0
		private bool AllowRaiseGpuLevel(); // 0x0000000182140BA0-0x0000000182140E00
		[CompilerGenerated]
		private void _.ctor_b__59_0(PerformanceBottleneckChangeEventArgs ev); // 0x0000000182141320-0x0000000182141370
	}
}
