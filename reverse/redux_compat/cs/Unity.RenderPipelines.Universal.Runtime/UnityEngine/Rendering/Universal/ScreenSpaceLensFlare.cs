/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[DisplayInfo(name = "Screen Space Lens Flare")]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	[VolumeComponentMenu("Post-processing/Screen Space Lens Flare")]
	public class ScreenSpaceLensFlare : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9535
	{
		// Fields
		public MinFloatParameter intensity; // 0x38
		public ColorParameter tintColor; // 0x40
		[AdditionalProperty]
		public ClampedIntParameter bloomMip; // 0x48
		[Header("Flares")]
		public MinFloatParameter firstFlareIntensity; // 0x50
		public MinFloatParameter secondaryFlareIntensity; // 0x58
		public MinFloatParameter warpedFlareIntensity; // 0x60
		[AdditionalProperty]
		public Vector2Parameter warpedFlareScale; // 0x68
		public ClampedIntParameter samples; // 0x70
		[AdditionalProperty]
		public ClampedFloatParameter sampleDimmer; // 0x78
		public ClampedFloatParameter vignetteEffect; // 0x80
		public ClampedFloatParameter startingPosition; // 0x88
		public ClampedFloatParameter scale; // 0x90
		[Header("Streaks")]
		public MinFloatParameter streaksIntensity; // 0x98
		public ClampedFloatParameter streaksLength; // 0xA0
		public FloatParameter streaksOrientation; // 0xA8
		public ClampedFloatParameter streaksThreshold; // 0xB0
		[AdditionalProperty]
		[SerializeField]
		public ScreenSpaceLensFlareResolutionParameter resolution; // 0xB8
		[FormerlySerializedAs("chromaticAbberationIntensity")]
		[Header("Chromatic Aberration")]
		public ClampedFloatParameter chromaticAberrationIntensity; // 0xC0
	
		// Properties
		[Obsolete("chromaticAbberationIntensity has been renamed to chromaticAberrationIntensity. #from(6000.7) (UnityUpgradable) -> chromaticAberrationIntensity")]
		public ClampedFloatParameter chromaticAbberationIntensity { get; } // 0x00000001806CCB70-0x00000001806CCB80 
	
		// Constructors
		public ScreenSpaceLensFlare(); // 0x0000000181F97960-0x0000000181F97E60
	
		// Methods
		public bool IsActive(); // 0x0000000181F8A490-0x0000000181F8A4D0
		public bool IsStreaksActive(); // 0x0000000181F97920-0x0000000181F97960
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7840-0x00000001802E7850
	}
}
