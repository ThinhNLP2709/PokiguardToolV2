namespace UnityEngine.Rendering;

public sealed class LensFlareDataElementSRP
{
	public LensFlareDataSRP lensFlareDataSRP; //Field offset: 0x10
	public bool visible; //Field offset: 0x18
	public float position; //Field offset: 0x1C
	public Vector2 positionOffset; //Field offset: 0x20
	public float angularOffset; //Field offset: 0x28
	public Vector2 translationScale; //Field offset: 0x2C
	[Range(0, 1)]
	public float ringThickness; //Field offset: 0x34
	[Range(-1, 1)]
	public float hoopFactor; //Field offset: 0x38
	public float noiseAmplitude; //Field offset: 0x3C
	public int noiseFrequency; //Field offset: 0x40
	public float noiseSpeed; //Field offset: 0x44
	public float shapeCutOffSpeed; //Field offset: 0x48
	public float shapeCutOffRadius; //Field offset: 0x4C
	[FormerlySerializedAs("localIntensity")]
	[Min(0)]
	[SerializeField]
	private float m_LocalIntensity; //Field offset: 0x50
	public Texture lensFlareTexture; //Field offset: 0x58
	public float uniformScale; //Field offset: 0x60
	public Vector2 sizeXY; //Field offset: 0x64
	public bool allowMultipleElement; //Field offset: 0x6C
	[FormerlySerializedAs("count")]
	[Min(1)]
	[SerializeField]
	private int m_Count; //Field offset: 0x70
	public bool preserveAspectRatio; //Field offset: 0x74
	public float rotation; //Field offset: 0x78
	public SRPLensFlareColorType tintColorType; //Field offset: 0x7C
	public Color tint; //Field offset: 0x80
	public TextureGradient tintGradient; //Field offset: 0x90
	public SRPLensFlareBlendMode blendMode; //Field offset: 0x98
	public bool autoRotate; //Field offset: 0x9C
	public SRPLensFlareType flareType; //Field offset: 0xA0
	public bool modulateByLightColor; //Field offset: 0xA4
	[SerializeField]
	private bool isFoldOpened; //Field offset: 0xA5
	public SRPLensFlareDistribution distribution; //Field offset: 0xA8
	public float lengthSpread; //Field offset: 0xAC
	public AnimationCurve positionCurve; //Field offset: 0xB0
	public AnimationCurve scaleCurve; //Field offset: 0xB8
	public int seed; //Field offset: 0xC0
	public Gradient colorGradient; //Field offset: 0xC8
	[FormerlySerializedAs("intensityVariation")]
	[Range(0, 1)]
	[SerializeField]
	private float m_IntensityVariation; //Field offset: 0xD0
	public Vector2 positionVariation; //Field offset: 0xD4
	public float scaleVariation; //Field offset: 0xDC
	public float rotationVariation; //Field offset: 0xE0
	public bool enableRadialDistortion; //Field offset: 0xE4
	public Vector2 targetSizeDistortion; //Field offset: 0xE8
	public AnimationCurve distortionCurve; //Field offset: 0xF0
	public bool distortionRelativeToCenter; //Field offset: 0xF8
	[FormerlySerializedAs("fallOff")]
	[Range(0, 1)]
	[SerializeField]
	private float m_FallOff; //Field offset: 0xFC
	[FormerlySerializedAs("edgeOffset")]
	[Range(0, 1)]
	[SerializeField]
	private float m_EdgeOffset; //Field offset: 0x100
	[FormerlySerializedAs("sideCount")]
	[Min(3)]
	[SerializeField]
	private int m_SideCount; //Field offset: 0x104
	[FormerlySerializedAs("sdfRoundness")]
	[Range(0, 1)]
	[SerializeField]
	private float m_SdfRoundness; //Field offset: 0x108
	public bool inverseSDF; //Field offset: 0x10C
	public float uniformAngle; //Field offset: 0x110
	public AnimationCurve uniformAngleCurve; //Field offset: 0x118

	public int count
	{
		 get { } //Length: 4
		 set { } //Length: 16
	}

	public float edgeOffset
	{
		 get { } //Length: 9
		 set { } //Length: 39
	}

	public float fallOff
	{
		 get { } //Length: 9
		 set { } //Length: 39
	}

	public float intensityVariation
	{
		 get { } //Length: 9
		 set { } //Length: 18
	}

	public float localIntensity
	{
		 get { } //Length: 6
		 set { } //Length: 15
	}

	public float sdfRoundness
	{
		 get { } //Length: 9
		 set { } //Length: 39
	}

	public int sideCount
	{
		 get { } //Length: 7
		 set { } //Length: 19
	}

	public LensFlareDataElementSRP() { }

	public LensFlareDataElementSRP Clone() { }

	public int get_count() { }

	public float get_edgeOffset() { }

	public float get_fallOff() { }

	public float get_intensityVariation() { }

	public float get_localIntensity() { }

	public float get_sdfRoundness() { }

	public int get_sideCount() { }

	public void set_count(int value) { }

	public void set_edgeOffset(float value) { }

	public void set_fallOff(float value) { }

	public void set_intensityVariation(float value) { }

	public void set_localIntensity(float value) { }

	public void set_sdfRoundness(float value) { }

	public void set_sideCount(int value) { }

}

