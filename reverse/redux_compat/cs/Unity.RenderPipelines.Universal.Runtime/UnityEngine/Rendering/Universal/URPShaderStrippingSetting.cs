/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "Additional Shader Stripping Settings", Order = 40)]
	[ElementInfo(Order = 10)]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class URPShaderStrippingSetting : IRenderPipelineGraphicsSettings // TypeDefIndex: 9774
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[FormerlySerializedAs("m_StripUnusedPostProcessingVariants")]
		[SerializeField]
		[Tooltip("Controls whether to automatically strip post processing shader variants and resources based on VolumeProfile components. Stripping is done based on VolumeProfiles in project, their usage in scenes is not considered.")]
		private bool m_StripUnusedPostProcessingVariantsAndResources; // 0x14
		[SerializeField]
		[Tooltip("Controls whether to strip variants if the feature is disabled.")]
		private bool m_StripUnusedVariants; // 0x15
		[SerializeField]
		[Tooltip("Controls whether Screen Coordinates Override shader variants are automatically stripped.")]
		private bool m_StripScreenCoordOverrideVariants; // 0x16
		[SerializeField]
		[Tooltip("Controls whether unused 2D light shader variants are stripped based on scene analysis.")]
		private bool m_Strip2DUnusedVariants; // 0x17
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool stripUnusedPostProcessingVariants { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181FF45E0-0x0000000181FF4650
		public bool stripUnusedVariants { get; set; } // 0x000000018155D200-0x000000018155D210 0x0000000181FF4650-0x0000000181FF46C0
		public bool stripScreenCoordOverrideVariants { get; set; } // 0x0000000181F978F0-0x0000000181F97900 0x0000000181FF4570-0x0000000181FF45E0
		public bool strip2DUnusedVariants { get; set; } // 0x0000000181F978E0-0x0000000181F978F0 0x0000000181FF4500-0x0000000181FF4570
	
		// Nested types
		internal enum Version // TypeDefIndex: 9775
		{
			Initial = 0
		}
	
		// Constructors
		public URPShaderStrippingSetting(); // 0x0000000181FF44F0-0x0000000181FF4500
	}
}
