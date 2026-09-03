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
	[VolumeComponentMenu("Post-processing/Film Grain")]
	public sealed class FilmGrain : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9524
	{
		// Fields
		[Tooltip("The type of grain to use. You can select a preset or provide your own texture by selecting Custom.")]
		public FilmGrainLookupParameter type; // 0x38
		[Tooltip("Use the slider to set the strength of the Film Grain effect.")]
		public ClampedFloatParameter intensity; // 0x40
		[Tooltip("Controls the noisiness response curve based on scene luminance. Higher values mean less noise in light areas.")]
		public ClampedFloatParameter response; // 0x48
		[Tooltip("A tileable texture to use for the grain. The neutral value is 0.5 where no grain is applied.")]
		public NoInterpTextureParameter texture; // 0x50
	
		// Constructors
		public FilmGrain(); // 0x0000000181F8FE50-0x0000000181F8FF90
	
		// Methods
		public bool IsActive(); // 0x0000000181F8FD80-0x0000000181F8FE50
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
