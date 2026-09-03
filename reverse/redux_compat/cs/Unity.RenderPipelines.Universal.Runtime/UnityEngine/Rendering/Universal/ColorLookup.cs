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
	[VolumeComponentMenu("Post-processing/Color Lookup")]
	public sealed class ColorLookup : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9519
	{
		// Fields
		[Tooltip("A 2D Lookup Texture (LUT) to use for color grading.")]
		public TextureParameter texture; // 0x38
		[Tooltip("How much of the lookup texture will contribute to the color grading effect.")]
		public ClampedFloatParameter contribution; // 0x40
	
		// Constructors
		public ColorLookup(); // 0x0000000181F8BC50-0x0000000181F8BD10
	
		// Methods
		public bool IsActive(); // 0x0000000181F8B960-0x0000000181F8B9B0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
		public bool ValidateLUT(); // 0x0000000181F8B9B0-0x0000000181F8BC50
	}
}
