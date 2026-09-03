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
	[Serializable]
	public class AdaptivePerformanceIndexerSettings // TypeDefIndex: 14185
	{
		// Fields
		[SerializeField]
		[Tooltip("Active")]
		private bool m_Active; // 0x10
		[Min(0f)]
		[SerializeField]
		[Tooltip("Thermal Action Delay")]
		private float m_ThermalActionDelay; // 0x14
		[Min(0f)]
		[SerializeField]
		[Tooltip("Performance Action Delay")]
		private float m_PerformanceActionDelay; // 0x18
	
		// Properties
		public bool active { get; } // 0x00000001805625D0-0x00000001805625E0 
		public float thermalActionDelay { get; } // 0x0000000181120AA0-0x0000000181120AB0 
		public float performanceActionDelay { get; } // 0x00000001806CB0A0-0x00000001806CB0B0 
	
		// Constructors
		public AdaptivePerformanceIndexerSettings(); // 0x0000000182131A10-0x0000000182131A30
	}
}
