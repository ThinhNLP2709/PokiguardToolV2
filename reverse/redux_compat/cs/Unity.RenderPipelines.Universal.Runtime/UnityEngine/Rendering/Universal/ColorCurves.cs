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
	[VolumeComponentMenu("Post-processing/Color Curves")]
	public sealed class ColorCurves : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9518
	{
		// Fields
		[Tooltip("Affects the luminance across the whole image.")]
		public TextureCurveParameter master; // 0x38
		[Tooltip("Affects the red channel intensity across the whole image.")]
		public TextureCurveParameter red; // 0x40
		[Tooltip("Affects the green channel intensity across the whole image.")]
		public TextureCurveParameter green; // 0x48
		[Tooltip("Affects the blue channel intensity across the whole image.")]
		public TextureCurveParameter blue; // 0x50
		[Tooltip("Shifts the input hue (x-axis) according to the output hue (y-axis).")]
		public TextureCurveParameter hueVsHue; // 0x58
		[Tooltip("Adjusts saturation (y-axis) according to the input hue (x-axis).")]
		public TextureCurveParameter hueVsSat; // 0x60
		[Tooltip("Adjusts saturation (y-axis) according to the input saturation (x-axis).")]
		public TextureCurveParameter satVsSat; // 0x68
		[Tooltip("Adjusts saturation (y-axis) according to the input luminance (x-axis).")]
		public TextureCurveParameter lumVsSat; // 0x70
	
		// Constructors
		public ColorCurves(); // 0x0000000181F8A810-0x0000000181F8AF90
	
		// Methods
		public bool IsActive(); // 0x00000001802E7990-0x00000001802E79A0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
