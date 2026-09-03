/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "Lighting", Order = 20)]
	[SupportedOnRenderPipeline(new Type[0])]
	public class LightmapSamplingSettings : IRenderPipelineGraphicsSettings // TypeDefIndex: 5680
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[SerializeField]
		[Tooltip("Use Bicubic Lightmap Sampling. Enabling this will improve the appearance of lightmaps, but may worsen performance on lower end platforms.")]
		private bool m_UseBicubicLightmapSampling; // 0x14
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool useBicubicLightmapSampling { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E8FF70-0x0000000181E8FFE0
	
		// Constructors
		public LightmapSamplingSettings(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
