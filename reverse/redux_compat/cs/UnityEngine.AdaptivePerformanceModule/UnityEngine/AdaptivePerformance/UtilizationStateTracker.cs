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
	internal class UtilizationStateTracker // TypeDefIndex: 14152
	{
		// Fields
		private readonly Func<float> m_ReadUtilization; // 0x10
		[CompilerGenerated]
		private float _DecreaseThreshold_k__BackingField; // 0x18
		[CompilerGenerated]
		private float _FastDecreaseThreshold_k__BackingField; // 0x1C
		[CompilerGenerated]
		private float _IncreaseThreshold_k__BackingField; // 0x20
	
		// Properties
		public float DecreaseThreshold { [CompilerGenerated] get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
		public float FastDecreaseThreshold { [CompilerGenerated] get; } // 0x0000000181CE2A30-0x0000000181CE2A40 
		public float IncreaseThreshold { [CompilerGenerated] get; } // 0x0000000181CE2820-0x0000000181CE2830 
	
		// Constructors
		public UtilizationStateTracker(Func<float> readUtilization); // 0x0000000182145AE0-0x0000000182145B30
	
		// Methods
		public StateAction Update(); // 0x0000000182145A70-0x0000000182145AE0
	}
}
