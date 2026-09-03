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
	[Serializable]
	public sealed class LensFlareDataElementSRP // TypeDefIndex: 5646
	{
		// Fields
		public LensFlareDataSRP lensFlareDataSRP; // 0x10
		public bool visible; // 0x18
		public float position; // 0x1C
		public Vector2 positionOffset; // 0x20
		public float angularOffset; // 0x28
		public Vector2 translationScale; // 0x2C
		[Range(0f, 1f)]
		public float ringThickness; // 0x34
		[Range(-1f, 1f)]
		public float hoopFactor; // 0x38
		public float noiseAmplitude; // 0x3C
		public int noiseFrequency; // 0x40
		public float noiseSpeed; // 0x44
		public float shapeCutOffSpeed; // 0x48
		public float shapeCutOffRadius; // 0x4C
		[FormerlySerializedAs("localIntensity")]
		[Min(0f)]
		[SerializeField]
		private float m_LocalIntensity; // 0x50
		public Texture lensFlareTexture; // 0x58
		public float uniformScale; // 0x60
		public Vector2 sizeXY; // 0x64
		public bool allowMultipleElement; // 0x6C
		[FormerlySerializedAs("count")]
		[Min(1f)]
		[SerializeField]
		private int m_Count; // 0x70
		public bool preserveAspectRatio; // 0x74
		public float rotation; // 0x78
		public SRPLensFlareColorType tintColorType; // 0x7C
		public Color tint; // 0x80
		public TextureGradient tintGradient; // 0x90
		public SRPLensFlareBlendMode blendMode; // 0x98
		public bool autoRotate; // 0x9C
		public SRPLensFlareType flareType; // 0xA0
		public bool modulateByLightColor; // 0xA4
		[SerializeField]
		private bool isFoldOpened; // 0xA5
		public SRPLensFlareDistribution distribution; // 0xA8
		public float lengthSpread; // 0xAC
		public AnimationCurve positionCurve; // 0xB0
		public AnimationCurve scaleCurve; // 0xB8
		public int seed; // 0xC0
		public Gradient colorGradient; // 0xC8
		[FormerlySerializedAs("intensityVariation")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_IntensityVariation; // 0xD0
		public Vector2 positionVariation; // 0xD4
		public float scaleVariation; // 0xDC
		public float rotationVariation; // 0xE0
		public bool enableRadialDistortion; // 0xE4
		public Vector2 targetSizeDistortion; // 0xE8
		public AnimationCurve distortionCurve; // 0xF0
		public bool distortionRelativeToCenter; // 0xF8
		[FormerlySerializedAs("fallOff")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_FallOff; // 0xFC
		[FormerlySerializedAs("edgeOffset")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_EdgeOffset; // 0x100
		[FormerlySerializedAs("sideCount")]
		[Min(3f)]
		[SerializeField]
		private int m_SideCount; // 0x104
		[FormerlySerializedAs("sdfRoundness")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SdfRoundness; // 0x108
		public bool inverseSDF; // 0x10C
		public float uniformAngle; // 0x110
		public AnimationCurve uniformAngleCurve; // 0x118
	
		// Properties
		public float localIntensity { get; set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000181E8FE90-0x0000000181E8FEA0
		public int count { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000181E8FE30-0x0000000181E8FE40
		public float intensityVariation { get; set; } // 0x0000000180CC3C20-0x0000000180CC3C30 0x0000000181E8FE80-0x0000000181E8FE90
		public float fallOff { get; set; } // 0x0000000181E8FE00-0x0000000181E8FE10 0x0000000181E8FE60-0x0000000181E8FE80
		public float edgeOffset { get; set; } // 0x0000000181E8FDF0-0x0000000181E8FE00 0x0000000181E8FE40-0x0000000181E8FE60
		public int sideCount { get; set; } // 0x0000000181E8FE20-0x0000000181E8FE30 0x0000000181E8FEC0-0x0000000181E8FEE0
		public float sdfRoundness { get; set; } // 0x0000000181E8FE10-0x0000000181E8FE20 0x0000000181E8FEA0-0x0000000181E8FEC0
	
		// Constructors
		public LensFlareDataElementSRP(); // 0x0000000181E8F480-0x0000000181E8FDF0
	
		// Methods
		public LensFlareDataElementSRP Clone(); // 0x0000000181E8EDC0-0x0000000181E8F480
	}
}
