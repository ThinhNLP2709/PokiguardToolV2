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
	[VolumeComponentMenu("Post-processing/Channel Mixer")]
	public sealed class ChannelMixer : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9515
	{
		// Fields
		[Tooltip("Modify influence of the red channel in the overall mix.")]
		public ClampedFloatParameter redOutRedIn; // 0x38
		[Tooltip("Modify influence of the green channel in the overall mix.")]
		public ClampedFloatParameter redOutGreenIn; // 0x40
		[Tooltip("Modify influence of the blue channel in the overall mix.")]
		public ClampedFloatParameter redOutBlueIn; // 0x48
		[Tooltip("Modify influence of the red channel in the overall mix.")]
		public ClampedFloatParameter greenOutRedIn; // 0x50
		[Tooltip("Modify influence of the green channel in the overall mix.")]
		public ClampedFloatParameter greenOutGreenIn; // 0x58
		[Tooltip("Modify influence of the blue channel in the overall mix.")]
		public ClampedFloatParameter greenOutBlueIn; // 0x60
		[Tooltip("Modify influence of the red channel in the overall mix.")]
		public ClampedFloatParameter blueOutRedIn; // 0x68
		[Tooltip("Modify influence of the green channel in the overall mix.")]
		public ClampedFloatParameter blueOutGreenIn; // 0x70
		[Tooltip("Modify influence of the blue channel in the overall mix.")]
		public ClampedFloatParameter blueOutBlueIn; // 0x78
	
		// Constructors
		public ChannelMixer(); // 0x0000000181F8A1F0-0x0000000181F8A490
	
		// Methods
		public bool IsActive(); // 0x0000000181F8A030-0x0000000181F8A1F0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
