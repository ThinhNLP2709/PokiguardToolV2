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
	[VolumeComponentMenu("Post-processing/Motion Blur")]
	public sealed class MotionBlur : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9530
	{
		// Fields
		[Tooltip("The motion blur technique to use. If you don\'t need object motion blur, CameraOnly will result in better performance.")]
		public MotionBlurModeParameter mode; // 0x38
		[Tooltip("The quality of the effect. Lower presets will result in better performance at the expense of visual quality.")]
		public MotionBlurQualityParameter quality; // 0x40
		[Tooltip("The strength of the motion blur filter. Acts as a multiplier for velocities.")]
		public ClampedFloatParameter intensity; // 0x48
		[Tooltip("Sets the maximum length, as a fraction of the screen\'s full resolution, that the velocity resulting from Camera rotation can have. Lower values will improve performance.")]
		public ClampedFloatParameter clamp; // 0x50
	
		// Constructors
		public MotionBlur(); // 0x0000000181F95DA0-0x0000000181F95EE0
	
		// Methods
		public bool IsActive(); // 0x0000000181F88C90-0x0000000181F88CD0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7840-0x00000001802E7850
	}
}
