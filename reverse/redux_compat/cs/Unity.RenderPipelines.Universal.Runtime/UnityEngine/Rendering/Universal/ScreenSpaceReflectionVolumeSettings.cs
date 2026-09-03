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
	[DisplayInfo(name = "Screen Space Reflection")]
	[SupportedOnRenderPipeline(new Type[0])]
	[VolumeComponentMenu("Lighting/Screen Space Reflection")]
	public class ScreenSpaceReflectionVolumeSettings : VolumeComponent // TypeDefIndex: 9747
	{
		// Fields
		internal static readonly PerformancePresetValues[] k_PerformancePresets; // 0x00
		[Tooltip("The mode determining which objects to reflect using Screen Space Reflections. \'Opaques Only\' will only render opaque objects in reflections, while \'Opaques And Transparents\' will also render transparent objects in reflections.")]
		public EnumParameter<ReflectionMode> mode; // 0x38
		[Tooltip("Scales the overall contribution. A value of 0 disables the effect, 1 is full reflection strength.")]
		public ClampedFloatParameter reflectionStrength; // 0x40
		[Tooltip("Whether to clamp the reflected color to avoid very bright values causing issues.")]
		public BoolParameter clampReflectedColor; // 0x48
		[Tooltip("The maximum color value of reflected colors when clamping is enabled.")]
		public MinFloatParameter maxColorValue; // 0x50
		[Tooltip("The resolution to render Screen Space Reflections at. Lower values will yield better performance, but lower quality.")]
		public EnumParameter<Resolution> resolution; // 0x58
		[Tooltip("The method to use for upscaling the low resolution reflection texture. \'Bilateral\' is more expensive but produces sharper looking reflections.")]
		public EnumParameter<UpscalingMethod> upscalingMethod; // 0x60
		[Tooltip("Which method to use for ray marching when calculating hits. When set to \'Hierarchical\', Unity generates a depth pyramid and uses it for hierarchical marching. This is more accurate, but may be less performant on low-end devices.")]
		public EnumParameter<MarchingMethod> marchingMethod; // 0x68
		[Tooltip("Amount of binary search steps applied at the end of the ray to refine hit results, reducing stair-stepping artifacts and gaps in reflections caused by Linear marching, where initial steps may be imprecise and miss fine details.")]
		public MinIntParameter hitRefinementSteps; // 0x70
		[Tooltip("Multiplies the regular thickness to compute a finer value, used with additional refinement steps to achieve more precise hit detection.")]
		public ClampedFloatParameter finalThicknessMultiplier; // 0x78
		[Tooltip("Which technique to use for rendering rough/glossy reflections. Disabling will improve performance, but all reflections will be mirror-like. \'Gaussian Blur\' yields the highest quality, but is the most expensive.")]
		public EnumParameter<RoughReflectionsQuality> roughnessFilter; // 0x80
		[Tooltip("Controls how blurry rough reflections appear on a logarithmic scale. A value of 0 is neutral, negative values reduce blurriness, positive values increase it.")]
		public ClampedFloatParameter roughnessScale; // 0x88
		[Tooltip("The minimum amount of surface smoothness at which Screen Space Reflections are used. Higher values will result in less objects receiving Screen Space Reflections.")]
		public ClampedFloatParameter minimumSmoothness; // 0x90
		[Tooltip("The smoothness value at which the smoothness-controlled fade out starts. The fade is in the range [Min Smoothness, Smoothness Fade Start].")]
		public ClampedFloatParameter smoothnessFadeStart; // 0x98
		[Tooltip("How much to fade reflections based on the reflection normal.")]
		public ClampedFloatParameter normalFade; // 0xA0
		[Tooltip("The distance at which the reflection fades out near the edge of the screen.")]
		public ClampedFloatParameter screenEdgeFadeDistance; // 0xA8
		[Tooltip("Whether to use Screen Space Reflections to handle sky reflection. If you disable this property, pixels that reflect the sky will sample from nearby reflection probes, or the skybox.")]
		public BoolParameter reflectSky; // 0xB0
		[Tooltip("The maximum distance in world space units a ray can travel.")]
		public MinFloatParameter maxRayLength; // 0xB8
		[Tooltip("The fade distance in world space units before the maximum ray length. Only has an effect when using Linear marching method.")]
		public MinFloatParameter rayLengthFade; // 0xC0
		[Tooltip("The maximum amount of steps to take when tracing rays.")]
		public MinIntParameter maxRaySteps; // 0xC8
		[Tooltip("How close to the depth buffer a ray must be to be considered a hit. Higher values will result in less accurate reflections, but may help mitigate shimmering artifacts.")]
		public ClampedFloatParameter objectThickness; // 0xD0
		[Tooltip("Whether to use temporal filtering to stabilize reflections. Reduces flickering and temporal instability, but may introduce ghosting.")]
		public BoolParameter temporalFiltering; // 0xD8
		[Tooltip("Determines how much the history buffer is blended together with the current frame result. Higher values means more history contribution, which leads to more stable reflections with less flickering, but is also more prone to ghosting.")]
		public ClampedFloatParameter baseBlendFactor; // 0xE0
	
		// Properties
		[IsReadOnly]
		internal static ref PerformancePresetValues DefaultPreset { get; } // 0x0000000181FE2C80-0x0000000181FE2CF0 
	
		// Nested types
		public enum Resolution // TypeDefIndex: 9748
		{
			Full = 1,
			Half = 2,
			Quarter = 4
		}
	
		public enum UpscalingMethod // TypeDefIndex: 9749
		{
			Bilinear = 0,
			Bilateral = 1
		}
	
		public enum MarchingMethod // TypeDefIndex: 9750
		{
			Linear = 0,
			Hierarchical = 1
		}
	
		public enum RoughReflectionsQuality // TypeDefIndex: 9751
		{
			Disabled = 0,
			BoxBlur = 1,
			GaussianBlur = 2
		}
	
		public enum ReflectionMode // TypeDefIndex: 9752
		{
			Disabled = 0,
			OpaquesOnly = 1,
			OpaquesAndTransparents = 2
		}
	
		internal enum PerformancePreset // TypeDefIndex: 9753
		{
			Fast = 0,
			Balanced = 1,
			HighQuality = 2,
			BestQuality = 3,
			Custom = 4
		}
	
		internal struct PerformancePresetValues // TypeDefIndex: 9754
		{
			// Fields
			public Resolution resolution; // 0x00
			public UpscalingMethod upscalingMethod; // 0x04
			public MarchingMethod marchingMethod; // 0x08
			public int hitRefinementSteps; // 0x0C
			public float finalThicknessMultiplier; // 0x10
			public float maxRayLength; // 0x14
			public int maxRaySteps; // 0x18
			public float objectThickness; // 0x1C
		}
	
		// Constructors
		public ScreenSpaceReflectionVolumeSettings(); // 0x0000000181FE2630-0x0000000181FE2C80
		static ScreenSpaceReflectionVolumeSettings(); // 0x0000000181FE24C0-0x0000000181FE2630
	
		// Methods
		internal bool ShouldRenderTransparents(); // 0x0000000181FE2400-0x0000000181FE2440
		internal bool ShouldUseGaussianBlurRoughness(); // 0x0000000181FE2440-0x0000000181FE2480
		internal bool ShouldUseLinearMarching(); // 0x0000000181FE2480-0x0000000181FE24C0
	}
}
