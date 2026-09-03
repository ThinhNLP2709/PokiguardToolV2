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
	public struct PerformanceMetrics // TypeDefIndex: 14169
	{
		// Fields
		[CompilerGenerated]
		private int _CurrentCpuLevel_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _CurrentGpuLevel_k__BackingField; // 0x04
		[CompilerGenerated]
		private PerformanceBottleneck _PerformanceBottleneck_k__BackingField; // 0x08
		[CompilerGenerated]
		private bool _CpuPerformanceBoost_k__BackingField; // 0x0C
		[CompilerGenerated]
		private bool _GpuPerformanceBoost_k__BackingField; // 0x0D
		[CompilerGenerated]
		private ClusterInfo _ClusterInfo_k__BackingField; // 0x10
		[CompilerGenerated]
		private float _CpuUtilization_k__BackingField; // 0x1C
		[CompilerGenerated]
		private float _GpuUtilization_k__BackingField; // 0x20
	
		// Properties
		public int CurrentCpuLevel { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int CurrentGpuLevel { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public PerformanceBottleneck PerformanceBottleneck { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public bool CpuPerformanceBoost { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000181D11B10-0x0000000181D11B20 0x000000018212F6B0-0x000000018212F6C0
		public bool GpuPerformanceBoost { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018212F690-0x000000018212F6A0 0x000000018212F6C0-0x000000018212F6D0
		public ClusterInfo ClusterInfo { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180719290-0x00000001807192B0 0x00000001807192B0-0x00000001807192C0
		public float CpuUtilization { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
		public float GpuUtilization { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000181CE2820-0x0000000181CE2830 0x0000000181CE28D0-0x0000000181CE28E0
	}
}
