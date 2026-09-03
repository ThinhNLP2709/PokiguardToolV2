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
	[VolumeComponentMenu("Post-processing/Vignette")]
	public sealed class Vignette : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9546
	{
		// Fields
		[Tooltip("Vignette color.")]
		public ColorParameter color; // 0x38
		[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
		public Vector2Parameter center; // 0x40
		[Tooltip("Use the slider to set the strength of the Vignette effect.")]
		public ClampedFloatParameter intensity; // 0x48
		[Tooltip("Smoothness of the vignette borders.")]
		public ClampedFloatParameter smoothness; // 0x50
		[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
		public BoolParameter rounded; // 0x58
	
		// Constructors
		public Vignette(); // 0x0000000181F9FD30-0x0000000181F9FEF0
	
		// Methods
		public bool IsActive(); // 0x0000000181F88C90-0x0000000181F88CD0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
