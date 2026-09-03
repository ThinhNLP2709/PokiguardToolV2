/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class UniversalRenderPipelineDebugDisplaySettings : DebugDisplaySettings<UniversalRenderPipelineDebugDisplaySettings> // TypeDefIndex: 9398
	{
		// Fields
		[CompilerGenerated]
		private DebugDisplaySettingsCommon _commonSettings_k__BackingField; // 0x18
		[CompilerGenerated]
		private DebugDisplaySettingsMaterial _materialSettings_k__BackingField; // 0x20
		[CompilerGenerated]
		private DebugDisplaySettingsRendering _renderingSettings_k__BackingField; // 0x28
		[CompilerGenerated]
		private DebugDisplaySettingsLighting _lightingSettings_k__BackingField; // 0x30
		[CompilerGenerated]
		private DebugDisplaySettingsVolume _volumeSettings_k__BackingField; // 0x38
		[CompilerGenerated]
		private DebugDisplaySettingsStats _displayStats_k__BackingField; // 0x40
		[CompilerGenerated]
		private DebugDisplayGPUResidentDrawer _gpuResidentDrawerSettings_k__BackingField; // 0x48
	
		// Properties
		private DebugDisplaySettingsCommon commonSettings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public DebugDisplaySettingsMaterial materialSettings { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public DebugDisplaySettingsRendering renderingSettings { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public DebugDisplaySettingsLighting lightingSettings { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public DebugDisplaySettingsVolume volumeSettings { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		internal DebugDisplaySettingsStats displayStats { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		internal DebugDisplayGPUResidentDrawer gpuResidentDrawerSettings { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public override bool IsPostProcessingAllowed { get; } // 0x0000000181F86190-0x0000000181F86400 
	
		// Constructors
		public UniversalRenderPipelineDebugDisplaySettings(); // 0x0000000181F86130-0x0000000181F86190
	
		// Methods
		public override void Reset(); // 0x0000000181F85DA0-0x0000000181F86050
		internal void UpdateDisplayStats(); // 0x0000000181F86050-0x0000000181F86090
		internal void UpdateMaterials(); // 0x0000000181F86090-0x0000000181F86130
	}
}
