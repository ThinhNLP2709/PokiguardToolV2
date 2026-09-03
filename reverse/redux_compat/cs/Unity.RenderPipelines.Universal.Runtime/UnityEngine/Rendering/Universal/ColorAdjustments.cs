/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	[VolumeComponentMenu("Post-processing/Color Adjustments")]
	public sealed class ColorAdjustments : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9517
	{
		// Fields
		[Tooltip("Adjusts the overall exposure of the scene in EV100. This is applied after HDR effect and right before tonemapping so it won\'t affect previous effects in the chain.")]
		public FloatParameter postExposure; // 0x38
		[Tooltip("Expands or shrinks the overall range of tonal values.")]
		public ClampedFloatParameter contrast; // 0x40
		[Tooltip("Tint the render by multiplying a color.")]
		public ColorParameter colorFilter; // 0x48
		[Tooltip("Shift the hue of all colors.")]
		public ClampedFloatParameter hueShift; // 0x50
		[Tooltip("Pushes the intensity of all colors.")]
		public ClampedFloatParameter saturation; // 0x58
	
		// Constructors
		public ColorAdjustments(); // 0x0000000181F8A650-0x0000000181F8A810
	
		// Methods
		public bool IsActive(); // 0x0000000181F8A550-0x0000000181F8A650
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
