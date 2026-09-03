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
	[VolumeComponentMenu("Post-processing/Split Toning")]
	public sealed class SplitToning : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9538
	{
		// Fields
		[Tooltip("The color to use for shadows.")]
		public ColorParameter shadows; // 0x38
		[Tooltip("The color to use for highlights.")]
		public ColorParameter highlights; // 0x40
		[Tooltip("Balance between the colors in the highlights and shadows.")]
		public ClampedFloatParameter balance; // 0x48
	
		// Constructors
		public SplitToning(); // 0x0000000181F98B00-0x0000000181F98C50
	
		// Methods
		public bool IsActive(); // 0x0000000181F98A60-0x0000000181F98B00
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
