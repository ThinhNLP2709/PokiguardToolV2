/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class DevicePerformanceControlImpl : IDevicePerformanceControl // TypeDefIndex: 14138
	{
		// Fields
		private IDevicePerformanceLevelControl m_PerformanceLevelControl; // 0x10
		[CompilerGenerated]
		private PerformanceControlMode _PerformanceControlMode_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _CpuLevel_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _GpuLevel_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _CurrentCpuLevel_k__BackingField; // 0x24
		[CompilerGenerated]
		private int _CurrentGpuLevel_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _CpuPerformanceBoost_k__BackingField; // 0x2C
		[CompilerGenerated]
		private bool _GpuPerformanceBoost_k__BackingField; // 0x2D
	
		// Properties
		public PerformanceControlMode PerformanceControlMode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int MaxCpuPerformanceLevel { get; } // 0x0000000182142BE0-0x0000000182142C30 
		public int MaxGpuPerformanceLevel { get; } // 0x0000000182142C30-0x0000000182142C90 
		public int CpuLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public int GpuLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public int CurrentCpuLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int CurrentGpuLevel { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public bool CpuPerformanceBoost { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20770-0x0000000181B20780 0x0000000181B20790-0x0000000181B207A0
		public bool GpuPerformanceBoost { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20760-0x0000000181B20770 0x0000000181B20780-0x0000000181B20790
	
		// Constructors
		public DevicePerformanceControlImpl(IDevicePerformanceLevelControl performanceLevelControl); // 0x0000000182142B90-0x0000000182142BE0
	
		// Methods
		public bool Update(out PerformanceLevelChangeEventArgs changeArgs); // 0x0000000182142780-0x0000000182142B90
		private int ComputeDelta(int oldLevel, int newLevel); // 0x0000000182142760-0x0000000182142780
	}
}
