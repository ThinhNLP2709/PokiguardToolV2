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
	[VolumeComponentMenu("Post-processing/White Balance")]
	public sealed class WhiteBalance : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9547
	{
		// Fields
		[Tooltip("Sets the white balance to a custom color temperature.")]
		public ClampedFloatParameter temperature; // 0x38
		[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
		public ClampedFloatParameter tint; // 0x40
	
		// Constructors
		public WhiteBalance(); // 0x0000000181F9FF70-0x0000000181FA0040
	
		// Methods
		public bool IsActive(); // 0x0000000181F9FEF0-0x0000000181F9FF70
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
