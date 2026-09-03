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
	internal class AdaptivePerformanceScalerEfficiencyTracker // TypeDefIndex: 14153
	{
		// Fields
		private AdaptivePerformanceScaler m_Scaler; // 0x10
		private float m_LastAverageGpuFrameTime; // 0x18
		private float m_LastAverageCpuFrameTime; // 0x1C
		private bool m_IsApplied; // 0x20
		private IAdaptivePerformance m_AP; // 0x28
	
		// Properties
		public bool IsRunning { get; } // 0x000000018213BAD0-0x000000018213BB20 
	
		// Constructors
		public AdaptivePerformanceScalerEfficiencyTracker(); // 0x000000018213BA20-0x000000018213BAD0
	
		// Methods
		public void Start(AdaptivePerformanceScaler scaler, bool isApply); // 0x000000018213B740-0x000000018213B8D0
		public void Stop(); // 0x000000018213B8D0-0x000000018213BA20
	}
}
