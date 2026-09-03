/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DisplayInfo(name = "Adaptive Probe Volumes Options")]
	[SupportedOnRenderPipeline(new Type[0])]
	[VolumeComponentMenu("Lighting/Adaptive Probe Volumes Options")]
	public sealed class ProbeVolumesOptions : VolumeComponent // TypeDefIndex: 5626
	{
		// Fields
		[Tooltip("The overridden normal bias to be applied to the world position when sampling the Adaptive Probe Volumes data structure. Unit is meters.")]
		public ClampedFloatParameter normalBias; // 0x38
		[Tooltip("A bias alongside the view vector to be applied to the world position when sampling the Adaptive Probe Volumes data structure. Unit is meters.")]
		public ClampedFloatParameter viewBias; // 0x40
		[Tooltip("Whether to scale the bias for Adaptive Probe Volumes by the minimum distance between probes.")]
		public BoolParameter scaleBiasWithMinProbeDistance; // 0x48
		[Tooltip("Noise to be applied to the sampling position. It can hide seams issues between subdivision levels, but introduces noise.")]
		public ClampedFloatParameter samplingNoise; // 0x50
		[Tooltip("Whether to animate the noise when TAA is enabled. It can potentially remove the visible noise patterns.")]
		public BoolParameter animateSamplingNoise; // 0x58
		[Tooltip("Method used to reduce leaks. Currently available modes are crude, but cheap methods.")]
		public APVLeakReductionModeParameter leakReductionMode; // 0x60
		[Obsolete("This parameter isn\'t used anymore. #from(6000.0)")]
		public ClampedFloatParameter minValidDotProductValue; // 0x68
		[Tooltip("When enabled, reflection probe normalization can only decrease the reflection intensity.")]
		public BoolParameter occlusionOnlyReflectionNormalization; // 0x70
		[AdditionalProperty]
		[Tooltip("Global probe volumes weight. Allows for fading out probe volumes influence falling back to ambient probe.")]
		public ClampedFloatParameter intensityMultiplier; // 0x78
		[AdditionalProperty]
		[Tooltip("Multiplier applied on the sky lighting when using sky occlusion.")]
		public ClampedFloatParameter skyOcclusionIntensityMultiplier; // 0x80
		[AdditionalProperty]
		[Tooltip("Offset applied at runtime to probe positions in world space.\nThis is not considered while baking.")]
		public Vector3Parameter worldOffset; // 0x88
	
		// Constructors
		public ProbeVolumesOptions(); // 0x0000000181E88690-0x0000000181E889C0
	}
}
