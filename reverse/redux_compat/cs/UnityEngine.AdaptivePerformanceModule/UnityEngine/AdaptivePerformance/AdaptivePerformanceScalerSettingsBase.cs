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
	public class AdaptivePerformanceScalerSettingsBase // TypeDefIndex: 14188
	{
		// Fields
		[SerializeField]
		[Tooltip("Name of the scaler.")]
		private string m_Name; // 0x10
		[SerializeField]
		[Tooltip("Active")]
		private bool m_Enabled; // 0x18
		[SerializeField]
		[Tooltip("Scale to control the quality impact for the scaler. No quality change when 1, improved quality when >1, and lowered quality when <1.")]
		private float m_Scale; // 0x1C
		[SerializeField]
		[Tooltip("Visual impact the scaler has on the application. The higher the value, the more impact the scaler has on the visuals.")]
		private ScalerVisualImpact m_VisualImpact; // 0x20
		[SerializeField]
		[Tooltip("Application bottleneck that the scaler targets. The target selected has the most impact on the quality control of this scaler.")]
		private ScalerTarget m_Target; // 0x24
		[SerializeField]
		[Tooltip("Maximum level for the scaler. This is tied to the implementation of the scaler to divide the levels into concrete steps.")]
		private int m_MaxLevel; // 0x28
		[SerializeField]
		[Tooltip("Minimum value for the scale boundary.")]
		private float m_MinBound; // 0x2C
		[SerializeField]
		[Tooltip("Maximum value for the scale boundary.")]
		private float m_MaxBound; // 0x30
	
		// Properties
		public string name { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool enabled { get; set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public float scale { get; set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
		public ScalerVisualImpact visualImpact { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public ScalerTarget target { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int maxLevel { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public float minBound { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x000000018206CC90-0x000000018206CCA0
		public float maxBound { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
	
		// Constructors
		public AdaptivePerformanceScalerSettingsBase(); // 0x000000018213BE80-0x000000018213BF00
	}
}
