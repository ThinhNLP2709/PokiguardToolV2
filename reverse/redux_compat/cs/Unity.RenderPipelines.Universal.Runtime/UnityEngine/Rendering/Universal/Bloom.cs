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
	[VolumeComponentMenu("Post-processing/Bloom")]
	public sealed class Bloom : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9464
	{
		// Fields
		[Obsolete("This is obsolete, please use maxIterations instead. #from(2022.2) #breakingFrom(2023.1)", true)]
		[Tooltip("The number of final iterations to skip in the effect processing sequence.")]
		public ClampedIntParameter skipIterations; // 0x38
		[Header("Bloom")]
		[Tooltip("Filters out pixels under this level of brightness. Value is in gamma-space.")]
		public MinFloatParameter threshold; // 0x40
		[Tooltip("Strength of the bloom filter.")]
		public MinFloatParameter intensity; // 0x48
		[Tooltip("Set the radius of the bloom effect.")]
		public ClampedFloatParameter scatter; // 0x50
		[Tooltip("Set the maximum intensity that Unity uses to calculate Bloom. If pixels in your Scene are more intense than this, URP renders them at their current intensity, but uses this intensity value for the purposes of Bloom calculations.")]
		public MinFloatParameter clamp; // 0x58
		[Tooltip("Use the color picker to select a color for the Bloom effect to tint to.")]
		public ColorParameter tint; // 0x60
		[Tooltip("Use bicubic sampling instead of bilinear sampling for the upsampling passes. This is slightly more expensive but helps getting smoother visuals.")]
		public BoolParameter highQualityFiltering; // 0x68
		[Tooltip("Set the filtering algorithm for the Bloom effect.")]
		public BloomFilterModeParameter filter; // 0x70
		[AdditionalProperty]
		[Tooltip("The starting resolution that this effect begins processing.")]
		public DownscaleParameter downscale; // 0x78
		[AdditionalProperty]
		[Tooltip("The maximum number of iterations in the effect processing sequence.")]
		public ClampedIntParameter maxIterations; // 0x80
		[Header("Lens Dirt")]
		[Tooltip("Dirtiness texture to add smudges or dust to the bloom effect.")]
		public TextureParameter dirtTexture; // 0x88
		[Tooltip("Amount of dirtiness.")]
		public MinFloatParameter dirtIntensity; // 0x90
	
		// Constructors
		public Bloom(); // 0x0000000181F88CD0-0x0000000181F89040
	
		// Methods
		public bool IsActive(); // 0x0000000181F88C90-0x0000000181F88CD0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7840-0x00000001802E7850
	}
}
