/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "Lighting", Order = 21)]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class URPReflectionProbeSettings : IRenderPipelineGraphicsSettings // TypeDefIndex: 9305
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int version; // 0x10
		[SerializeField]
		[Tooltip("Use ReflectionProbe rotation. Enabling this will improve the appearance of reflections when the ReflectionProbe isn\'t axis aligned, but may worsen performance on lower end platforms.")]
		private bool useReflectionProbeRotation; // 0x14
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool UseReflectionProbeRotation { get; } // 0x0000000181102980-0x0000000181102990 
	
		// Constructors
		public URPReflectionProbeSettings(); // 0x0000000181F624B0-0x0000000181F624D0
	}
}
