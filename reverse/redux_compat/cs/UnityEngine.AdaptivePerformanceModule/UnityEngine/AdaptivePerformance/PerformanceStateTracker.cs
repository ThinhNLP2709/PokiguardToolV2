/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class PerformanceStateTracker // TypeDefIndex: 14151
	{
		// Fields
		private Queue<float> m_Samples; // 0x10
		private int m_SampleCapacity; // 0x18
		[CompilerGenerated]
		private float _Trend_k__BackingField; // 0x1C
	
		// Properties
		public float Trend { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
	
		// Constructors
		public PerformanceStateTracker(int sampleCapacity); // 0x0000000182144A20-0x0000000182144AB0
	
		// Methods
		public StateAction Update(); // 0x0000000182144710-0x0000000182144A20
		protected virtual float GetEffectiveTargetFrameRate(); // 0x0000000182135DC0-0x0000000182135E10
	}
}
