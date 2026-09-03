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
	[VolumeComponentMenu("Post-processing/Depth Of Field")]
	public sealed class DepthOfField : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9521
	{
		// Fields
		[Tooltip("Use \"Gaussian\" for a faster but non physical depth of field; \"Bokeh\" for a more realistic but slower depth of field.")]
		public DepthOfFieldModeParameter mode; // 0x38
		[Tooltip("The distance at which the blurring will start.")]
		public MinFloatParameter gaussianStart; // 0x40
		[Tooltip("The distance at which the blurring will reach its maximum radius.")]
		public MinFloatParameter gaussianEnd; // 0x48
		[Tooltip("The maximum radius of the gaussian blur. Values above 1 may show under-sampling artifacts.")]
		public ClampedFloatParameter gaussianMaxRadius; // 0x50
		[Tooltip("Use higher quality sampling to reduce flickering and improve the overall blur smoothness.")]
		public BoolParameter highQualitySampling; // 0x58
		[Tooltip("The distance to the point of focus.")]
		public MinFloatParameter focusDistance; // 0x60
		[Tooltip("The ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
		public ClampedFloatParameter aperture; // 0x68
		[Tooltip("The distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
		public ClampedFloatParameter focalLength; // 0x70
		[Tooltip("The number of aperture blades.")]
		public ClampedIntParameter bladeCount; // 0x78
		[Tooltip("The curvature of aperture blades. The smaller the value is, the more visible aperture blades are. A value of 1 will make the bokeh perfectly circular.")]
		public ClampedFloatParameter bladeCurvature; // 0x80
		[Tooltip("The rotation of aperture blades in degrees.")]
		public ClampedFloatParameter bladeRotation; // 0x88
	
		// Constructors
		public DepthOfField(); // 0x0000000181F8C3E0-0x0000000181F8C720
	
		// Methods
		public bool IsActive(); // 0x0000000181F8C360-0x0000000181F8C3E0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7840-0x00000001802E7850
	}
}
