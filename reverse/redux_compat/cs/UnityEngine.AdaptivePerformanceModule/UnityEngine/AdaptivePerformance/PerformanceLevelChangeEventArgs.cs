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
	public struct PerformanceLevelChangeEventArgs // TypeDefIndex: 14166
	{
		// Fields
		[CompilerGenerated]
		private int _CpuLevel_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _CpuLevelDelta_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _GpuLevel_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _GpuLevelDelta_k__BackingField; // 0x0C
		[CompilerGenerated]
		private PerformanceControlMode _PerformanceControlMode_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _ManualOverride_k__BackingField; // 0x14
	
		// Properties
		public int CpuLevel { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int CpuLevelDelta { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int GpuLevel { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int GpuLevelDelta { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public PerformanceControlMode PerformanceControlMode { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public bool ManualOverride { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
	}
}
