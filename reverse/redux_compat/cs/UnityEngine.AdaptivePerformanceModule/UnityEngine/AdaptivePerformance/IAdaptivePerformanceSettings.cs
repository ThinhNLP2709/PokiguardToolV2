/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public class IAdaptivePerformanceSettings : ScriptableObject // TypeDefIndex: 14189
	{
		// Fields
		[SerializeField]
		[Tooltip("Enable Logging in Devmode")]
		private bool m_Logging; // 0x18
		[SerializeField]
		[Tooltip("Automatic Performance Mode")]
		private bool m_AutomaticPerformanceModeEnabled; // 0x19
		[SerializeField]
		[Tooltip("Automatic Game Mode")]
		private bool m_AutomaticGameModeEnabled; // 0x1A
		[SerializeField]
		[Tooltip("Enables the CPU and GPU boost mode before engine startup to decrease startup time.")]
		private bool m_EnableBoostOnStartup; // 0x1B
		[Min(1f)]
		[SerializeField]
		[Tooltip("Logging Frequency (Development mode only)")]
		private int m_StatsLoggingFrequencyInFrames; // 0x1C
		[SerializeField]
		[Tooltip("Indexer Settings")]
		private AdaptivePerformanceIndexerSettings m_IndexerSettings; // 0x20
		[SerializeField]
		[Tooltip("Scaler Settings")]
		private AdaptivePerformanceScalerSettings m_ScalerSettings; // 0x28
		[SerializeField]
		private List<AdaptivePerformanceScaler> m_AddedScalerViaScan; // 0x30
		[SerializeReference]
		private AdaptivePerformanceScalerProfile m_ActiveScalerProfile; // 0x38
		[SerializeField]
		private AdaptivePerformanceScalerProfile[] m_scalerProfileList; // 0x40
		[SerializeField]
		internal int m_DefaultScalerProfilerIndex; // 0x48
		[SerializeField]
		private int k_AssetVersion; // 0x4C
	
		// Properties
		public bool logging { get; set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public bool automaticPerformanceMode { get; set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		public bool automaticGameMode { get; set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
		public bool enableBoostOnStartup { get; set; } // 0x0000000181DBEDC0-0x0000000181DBEDD0 0x0000000181DBEF90-0x0000000181DBEFA0
		public int statsLoggingFrequencyInFrames { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public AdaptivePerformanceIndexerSettings indexerSettings { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public AdaptivePerformanceScalerSettings scalerSettings { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public AdaptivePerformanceScalerProfile[] ScalerProfiles { get; } // 0x0000000180377940-0x0000000180377950 
		public AdaptivePerformanceScalerProfile ActiveScalerProfile { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[VisibleToOtherModules(new string[1] {"UnityEditor.AdaptivePerformanceModule" })]
		internal List<AdaptivePerformanceScaler> AddedScalerViaScan { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public int defaultScalerProfilerIndex { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0 // TypeDefIndex: 14190
		{
			// Fields
			public PropertyInfo property; // 0x10
	
			// Constructors
			public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ApplyScalerProfileToAllScalers_b__0(AdaptivePerformanceScaler s); // 0x0000000182145980-0x0000000182145A00
		}
	
		// Constructors
		public IAdaptivePerformanceSettings(); // 0x00000001821443C0-0x0000000182144500
	
		// Methods
		public void AddScalerProfileWithDefaultScalers(string name = "" /* Metadata: 0x006A95C9 */); // 0x0000000182143340-0x0000000182143530
		public void DeleteScalerProfileAt(int index); // 0x0000000182143C10-0x0000000182143D80
		public void LoadScalerProfile(string scalerProfileName); // 0x0000000182143F10-0x00000001821443B0
		private bool ApplyScalerProfileToAllScalers(); // 0x0000000182143530-0x0000000182143C10
		public string[] GetAvailableScalerProfiles(); // 0x0000000182143D80-0x0000000182143F10
		public void OnEnable(); // 0x00000001821443B0-0x00000001821443C0
	}
}
