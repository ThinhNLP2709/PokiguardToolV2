/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public struct GlobalDynamicResolutionSettings // TypeDefIndex: 5376
	{
		// Fields
		public bool enabled; // 0x00
		public bool useMipBias; // 0x01
		[Obsolete("Obsolete, use advancedUpscalerNames list instead.")]
		public List<AdvancedUpscalers> advancedUpscalersByPriority; // 0x08
		public List<string> advancedUpscalerNames; // 0x10
		public uint DLSSPerfQualitySetting; // 0x18
		public DynamicResolutionHandler.UpsamplerScheduleType DLSSInjectionPoint; // 0x1C
		public DynamicResolutionHandler.UpsamplerScheduleType TAAUInjectionPoint; // 0x20
		public DynamicResolutionHandler.UpsamplerScheduleType STPInjectionPoint; // 0x24
		public DynamicResolutionHandler.UpsamplerScheduleType defaultInjectionPoint; // 0x28
		public bool DLSSUseOptimalSettings; // 0x2C
		[Range(0f, 1f)]
		public float DLSSSharpness; // 0x30
		public uint DLSSRenderPresetForQuality; // 0x34
		public uint DLSSRenderPresetForBalanced; // 0x38
		public uint DLSSRenderPresetForPerformance; // 0x3C
		public uint DLSSRenderPresetForUltraPerformance; // 0x40
		public uint DLSSRenderPresetForDLAA; // 0x44
		public bool FSR2EnableSharpness; // 0x48
		[Range(0f, 1f)]
		public float FSR2Sharpness; // 0x4C
		public bool FSR2UseOptimalSettings; // 0x50
		public uint FSR2QualitySetting; // 0x54
		public DynamicResolutionHandler.UpsamplerScheduleType FSR2InjectionPoint; // 0x58
		public bool fsrOverrideSharpness; // 0x5C
		[Range(0f, 1f)]
		public float fsrSharpness; // 0x60
		public float maxPercentage; // 0x64
		public float minPercentage; // 0x68
		public DynamicResolutionType dynResType; // 0x6C
		public DynamicResUpscaleFilter upsampleFilter; // 0x6D
		public bool forceResolution; // 0x6E
		public float forcedPercentage; // 0x70
		public float lowResTransparencyMinimumThreshold; // 0x74
		public float rayTracingHalfResThreshold; // 0x78
		public float lowResSSGIMinimumThreshold; // 0x7C
		public float lowResVolumetricCloudsMinimumThreshold; // 0x80
		[Obsolete("Obsolete, used only for data migration. Use the advancedUpscalersByPriority list instead to add the proper supported advanced upscaler by priority. #from(2023.3)", true)]
		public bool enableDLSS; // 0x84
	
		// Methods
		public static GlobalDynamicResolutionSettings NewDefault(); // 0x0000000181E4AAF0-0x0000000181E4AC90
	}
}
