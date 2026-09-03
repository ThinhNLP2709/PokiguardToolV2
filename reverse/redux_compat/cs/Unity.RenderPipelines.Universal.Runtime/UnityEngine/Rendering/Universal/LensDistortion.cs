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
	[VolumeComponentMenu("Post-processing/Lens Distortion")]
	public sealed class LensDistortion : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9526
	{
		// Fields
		[Tooltip("Total distortion amount.")]
		public ClampedFloatParameter intensity; // 0x38
		[Tooltip("Intensity multiplier on X axis. Set it to 0 to disable distortion on this axis.")]
		public ClampedFloatParameter xMultiplier; // 0x40
		[Tooltip("Intensity multiplier on Y axis. Set it to 0 to disable distortion on this axis.")]
		public ClampedFloatParameter yMultiplier; // 0x48
		[Tooltip("Distortion center point. 0.5,0.5 is center of the screen.")]
		public Vector2Parameter center; // 0x50
		[Tooltip("Controls global screen scaling for the distortion effect. Use this to hide the screen borders when using high \"Intensity.\"")]
		public ClampedFloatParameter scale; // 0x58
	
		// Constructors
		public LensDistortion(); // 0x0000000181F91F70-0x0000000181F92120
	
		// Methods
		public bool IsActive(); // 0x0000000181F91EC0-0x0000000181F91F70
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7840-0x00000001802E7850
	}
}
