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
	internal class ProbeVolumeGlobalSettings : IRenderPipelineGraphicsSettings // TypeDefIndex: 5613
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[SerializeField]
		[Tooltip("Enabling this will make APV baked data assets compatible with Addressables and Asset Bundles. This will also make Disk Streaming unavailable. After changing this setting, a clean rebuild may be required for data assets to be included in Adressables and Asset Bundles.")]
		private bool m_ProbeVolumeDisableStreamingAssets; // 0x14
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool probeVolumeDisableStreamingAssets { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181E857C0-0x0000000181E85830
	
		// Constructors
		public ProbeVolumeGlobalSettings(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
