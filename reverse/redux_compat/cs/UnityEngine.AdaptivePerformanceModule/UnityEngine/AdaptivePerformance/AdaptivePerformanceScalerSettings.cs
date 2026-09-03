/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	[Serializable]
	public class AdaptivePerformanceScalerSettings // TypeDefIndex: 14187
	{
		// Fields
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the application update rate using Application.TargetFramerate")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveFramerate; // 0x10
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the resolution of all render targets that allow dynamic resolution.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveResolution; // 0x18
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer for adjusting at what distance LODs are switched.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveLOD; // 0x20
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the size of the palette used for color grading in URP.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveLut; // 0x28
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the level of antialiasing.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveMSAA; // 0x30
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the number of shadow cascades to be used.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowCascade; // 0x38
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change the distance at which shadows are rendered.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowDistance; // 0x40
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the resolution of shadow maps.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowmapResolution; // 0x48
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to adjust the quality of shadows.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowQuality; // 0x50
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change if objects in the scene are sorted by depth before rendering to reduce overdraw.")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveSorting; // 0x58
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to disable transparent objects rendering")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveTransparency; // 0x60
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change the view distance")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveViewDistance; // 0x68
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change physics properties")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptivePhysics; // 0x70
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change decal properties")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveDecals; // 0x78
		[SerializeField]
		[Tooltip("Settings for a scaler used by the Indexer to change the layer culling distance")]
		private AdaptivePerformanceScalerSettingsBase m_AdaptiveLayerCulling; // 0x80
		private AdaptivePerformanceScalerSettingsBase[] m_DefaultScalerSettings; // 0x88
		private ReadOnlyCollection<AdaptivePerformanceScalerSettingsBase> m_ReadOnlyDefaultScalerSettings; // 0x90
		[NoAutoStaticsCleanup]
		internal static readonly List<Type> k_DefaultScalerNames; // 0x00
	
		// Properties
		public AdaptivePerformanceScalerSettingsBase AdaptiveFramerate { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public AdaptivePerformanceScalerSettingsBase AdaptiveResolution { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		[Obsolete("AdaptiveBatching is obsolete.", true)]
		public AdaptivePerformanceScalerSettingsBase AdaptiveBatching { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
		public AdaptivePerformanceScalerSettingsBase AdaptiveLOD { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public AdaptivePerformanceScalerSettingsBase AdaptiveLut { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public AdaptivePerformanceScalerSettingsBase AdaptiveMSAA { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		[Obsolete("AdaptiveShadowCascades has been renamed. Please use AdaptiveShadowCascade. (UnityUpgradable) -> AdaptiveShadowCascade", false)]
		public AdaptivePerformanceScalerSettingsBase AdaptiveShadowCascades { get; } // 0x00000001803272A0-0x00000001803272B0 
		public AdaptivePerformanceScalerSettingsBase AdaptiveShadowCascade { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public AdaptivePerformanceScalerSettingsBase AdaptiveShadowDistance { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public AdaptivePerformanceScalerSettingsBase AdaptiveShadowmapResolution { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public AdaptivePerformanceScalerSettingsBase AdaptiveShadowQuality { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public AdaptivePerformanceScalerSettingsBase AdaptiveSorting { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		public AdaptivePerformanceScalerSettingsBase AdaptiveTransparency { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public AdaptivePerformanceScalerSettingsBase AdaptiveViewDistance { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public AdaptivePerformanceScalerSettingsBase AdaptivePhysics { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public AdaptivePerformanceScalerSettingsBase AdaptiveDecals { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public AdaptivePerformanceScalerSettingsBase AdaptiveLayerCulling { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public IReadOnlyList<AdaptivePerformanceScalerSettingsBase> DefaultScalerSettings { get; } // 0x000000018213D8B0-0x000000018213D920 
	
		// Constructors
		public AdaptivePerformanceScalerSettings(); // 0x000000018213D0E0-0x000000018213D8B0
		static AdaptivePerformanceScalerSettings(); // 0x000000018213C9E0-0x000000018213D0E0
	
		// Methods
		public void ApplySettings(AdaptivePerformanceScalerSettings settings); // 0x000000018213BF50-0x000000018213C440
		private void ApplySettingsBase(AdaptivePerformanceScalerSettingsBase destination, AdaptivePerformanceScalerSettingsBase sources); // 0x000000018213BF00-0x000000018213BF50
		private void SyncDefaultScalerSettings(); // 0x000000018213C440-0x000000018213C9E0
	}
}
