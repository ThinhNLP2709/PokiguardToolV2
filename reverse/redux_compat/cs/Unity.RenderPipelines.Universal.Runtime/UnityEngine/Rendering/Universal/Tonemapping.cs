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
	[VolumeComponentMenu("Post-processing/Tonemapping")]
	public sealed class Tonemapping : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9542
	{
		// Fields
		[Tooltip("Select a tonemapping algorithm to use for the color grading process.")]
		public TonemappingModeParameter mode; // 0x38
		[AdditionalProperty]
		[Tooltip("Specifies the range reduction mode used when HDR output is enabled and Neutral tonemapping is enabled.")]
		public NeutralRangeReductionModeParameter neutralHDRRangeReductionMode; // 0x40
		[Tooltip("Use the ACES preset for HDR displays.")]
		public HDRACESPresetParameter acesPreset; // 0x48
		[Tooltip("Specify how much hue to preserve. Values closer to 0 are likely to preserve hue. As values get closer to 1, Unity doesn\'t correct hue shifts.")]
		public ClampedFloatParameter hueShiftAmount; // 0x50
		[Tooltip("Enable to use values detected from the output device as paper white. When enabled, output images might differ between SDR and HDR. For best accuracy, set this value manually.")]
		public BoolParameter detectPaperWhite; // 0x58
		[Tooltip("The reference brightness of a paper white surface. This property determines the maximum brightness of UI. The brightness of the scene is scaled relative to this value. The value is in nits.")]
		public ClampedFloatParameter paperWhite; // 0x60
		[Tooltip("Enable to use the minimum and maximum brightness values detected from the output device. For best accuracy, considering calibrating these values manually.")]
		public BoolParameter detectBrightnessLimits; // 0x68
		[Tooltip("The minimum brightness of the screen (in nits). This value is assumed to be 0.005f with ACES Tonemap.")]
		public ClampedFloatParameter minNits; // 0x70
		[Tooltip("The maximum brightness of the screen (in nits). This value is defined by the preset when using ACES Tonemap.")]
		public ClampedFloatParameter maxNits; // 0x78
	
		// Constructors
		public Tonemapping(); // 0x0000000181F99750-0x0000000181F999D0
	
		// Methods
		public bool IsActive(); // 0x0000000181F99720-0x0000000181F99750
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
