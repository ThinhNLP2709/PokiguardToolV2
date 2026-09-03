/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisplayInfo(name = "URP Global Settings Asset", order = 40002)]
	[DisplayName("URP")]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal class UniversalRenderPipelineGlobalSettings : RenderPipelineGlobalSettings<UniversalRenderPipelineGlobalSettings, UniversalRenderPipeline> // TypeDefIndex: 9472
	{
		// Fields
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal ShaderStrippingSetting m_ShaderStrippingSetting; // 0x20
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal URPShaderStrippingSetting m_URPShaderStrippingSetting; // 0x28
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal ShaderVariantLogLevel m_ShaderVariantLogLevel; // 0x30
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal bool m_ExportShaderVariants; // 0x34
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal bool m_StripDebugVariants; // 0x35
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal bool m_StripUnusedPostProcessingVariants; // 0x36
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal bool m_StripUnusedVariants; // 0x37
		[Obsolete("Keep for migration. #from(2023.2)")]
		[SerializeField]
		internal bool m_StripScreenCoordOverrideVariants; // 0x38
		[Obsolete("Please use stripRuntimeDebugShaders instead. #from(2023.1)")]
		public bool supportRuntimeDebugDisplay; // 0x39
		[SerializeField]
		private RenderPipelineGraphicsSettingsContainer m_Settings; // 0x40
		internal const int k_LastVersion = 11; // Metadata: 0x0069EB4B
		[FormerlySerializedAs("k_AssetVersion")]
		[SerializeField]
		internal int m_AssetVersion; // 0x48
		public const string defaultAssetName = "UniversalRenderPipelineGlobalSettings"; // Metadata: 0x0069EB4C
		[FormerlySerializedAs("m_DefaultVolumeProfile")]
		[Obsolete("Kept For Migration. #from(2023.3)", false)]
		[SerializeField]
		internal VolumeProfile m_ObsoleteDefaultVolumeProfile; // 0x50
		[Obsolete("Kept For Migration. #from(2023.3)", false)]
		[SerializeField]
		internal string[] m_RenderingLayerNames; // 0x58
		[SerializeField]
		private uint m_ValidRenderingLayers; // 0x60
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName0; // 0x68
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName1; // 0x70
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName2; // 0x78
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName3; // 0x80
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName4; // 0x88
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName5; // 0x90
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string lightLayerName6; // 0x98
		[Obsolete("This is obsolete, please use renderingLayerNames instead. #from(2022.2)")]
		public string lightLayerName7; // 0xA0
		[SerializeField]
		internal ProbeVolumeSceneData apvScenesData; // 0xA8
	
		// Properties
		[Obsolete("No longer used as Shader Prefiltering automatically strips out unused LOD Crossfade variants. Please use the LOD Crossfade setting in the URP Asset to disable the feature if not used. #from(2023.1)")]
		public bool stripUnusedLODCrossFadeVariants { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x00000001802E76C0-0x00000001802E76D0
		protected override List<IRenderPipelineGraphicsSettings> settingsList { get; } // 0x0000000181F9E020-0x0000000181F9E040 
		[Obsolete("This property is obsolete. Use RenderingLayerMask API and Tags & Layers project settings instead. #from(2022.2) #breakingFrom(2023.1)", true)]
		public string[] prefixedLightLayerNames { get; } // 0x0000000181F9DFE0-0x0000000181F9E020 
		[Obsolete("This is obsolete, please use renderingLayerMaskNames instead. #from(2022.2)")]
		public string[] lightLayerNames { get; } // 0x0000000181F9DFA0-0x0000000181F9DFE0 
	
		// Constructors
		public UniversalRenderPipelineGlobalSettings(); // 0x0000000181F9DE30-0x0000000181F9DFA0
	
		// Methods
		internal bool IsAtLastVersion(); // 0x0000000181F9DD70-0x0000000181F9DD80
		public override void Reset(); // 0x0000000181F9DE10-0x0000000181F9DE30
		internal static VolumeProfile GetOrCreateDefaultVolumeProfile(VolumeProfile defaultVolumeProfile); // 0x0000000180370C60-0x0000000180370C70
		internal void ResetRenderingLayerNames(); // 0x0000000181F9DD80-0x0000000181F9DE10
		internal ProbeVolumeSceneData GetOrCreateAPVSceneData(); // 0x0000000181F9DCD0-0x0000000181F9DD70
	}
}
