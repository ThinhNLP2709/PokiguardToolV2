/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AddComponentMenu("Rendering/Lens Flare (SRP)")]
	[ExecuteAlways]
	public sealed class LensFlareComponentSRP : MonoBehaviour // TypeDefIndex: 5640
	{
		// Fields
		[SerializeField]
		private LensFlareDataSRP m_LensFlareData; // 0x20
		[SerializeField]
		private Version version; // 0x28
		[Min(0f)]
		public float intensity; // 0x2C
		[Min(1E-05f)]
		public float maxAttenuationDistance; // 0x30
		[Min(1E-05f)]
		public float maxAttenuationScale; // 0x34
		public AnimationCurve distanceAttenuationCurve; // 0x38
		public AnimationCurve scaleByDistanceCurve; // 0x40
		public bool attenuationByLightShape; // 0x48
		public AnimationCurve radialScreenAttenuationCurve; // 0x50
		public bool useOcclusion; // 0x58
		[NonSerialized]
		[Obsolete("Replaced by environmentOcclusion. #from(6000.0)")]
		public bool useBackgroundCloudOcclusion; // 0x59
		[FormerlySerializedAs("volumetricCloudOcclusion")]
		[FormerlySerializedAs("useFogOpacityOcclusion")]
		public bool environmentOcclusion; // 0x5A
		[NonSerialized]
		[Obsolete("Replaced by environmentOcclusion. #from(6000.0)")]
		public bool useWaterOcclusion; // 0x5B
		[Min(0f)]
		public float occlusionRadius; // 0x5C
		[Range(1f, 64f)]
		public uint sampleCount; // 0x60
		public float occlusionOffset; // 0x64
		[Min(0f)]
		public float scale; // 0x68
		public bool allowOffScreen; // 0x6C
		[NonSerialized]
		[Obsolete("Please use environmentOcclusion instead. #from(6000.0)")]
		public bool volumetricCloudOcclusion; // 0x6D
		private const float sCelestialAngularRadius = 0.057595868f; // Metadata: 0x00661758
		public TextureCurve occlusionRemapCurve; // 0x70
		public Light lightOverride; // 0x78
	
		// Properties
		public LensFlareDataSRP lensFlareData { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181E8ECD0-0x0000000181E8EDC0
	
		// Nested types
		private enum Version // TypeDefIndex: 5641
		{
			Initial = 0
		}
	
		// Constructors
		public LensFlareComponentSRP(); // 0x0000000181E8E880-0x0000000181E8EC40
	
		// Methods
		public float celestialProjectedOcclusionRadius(Camera mainCam); // 0x0000000181E8EC40-0x0000000181E8ECD0
		private void OnEnable(); // 0x0000000181E8E6C0-0x0000000181E8E790
		private void OnDisable(); // 0x0000000181E8E660-0x0000000181E8E6C0
		private void OnValidate(); // 0x0000000181E8E790-0x0000000181E8E880
		private void OnDestroy(); // 0x0000000181E8E640-0x0000000181E8E660
	}
}
