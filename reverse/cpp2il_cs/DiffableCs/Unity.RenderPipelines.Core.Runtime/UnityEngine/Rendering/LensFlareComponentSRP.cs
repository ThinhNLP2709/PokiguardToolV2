namespace UnityEngine.Rendering;

[AddComponentMenu("Rendering/Lens Flare (SRP)")]
[ExecuteAlways]
public sealed class LensFlareComponentSRP : MonoBehaviour
{
	private enum Version
	{
		Initial = 0,
	}

	private static float sCelestialAngularRadius; //Field offset: 0x0
	[SerializeField]
	private LensFlareDataSRP m_LensFlareData; //Field offset: 0x20
	[SerializeField]
	private Version version; //Field offset: 0x28
	[Min(0)]
	public float intensity; //Field offset: 0x2C
	[Min(1E-05)]
	public float maxAttenuationDistance; //Field offset: 0x30
	[Min(1E-05)]
	public float maxAttenuationScale; //Field offset: 0x34
	public AnimationCurve distanceAttenuationCurve; //Field offset: 0x38
	public AnimationCurve scaleByDistanceCurve; //Field offset: 0x40
	public bool attenuationByLightShape; //Field offset: 0x48
	public AnimationCurve radialScreenAttenuationCurve; //Field offset: 0x50
	public bool useOcclusion; //Field offset: 0x58
	[Obsolete("Replaced by environmentOcclusion.")]
	public bool useBackgroundCloudOcclusion; //Field offset: 0x59
	[FormerlySerializedAs("volumetricCloudOcclusion")]
	[FormerlySerializedAs("useFogOpacityOcclusion")]
	public bool environmentOcclusion; //Field offset: 0x5A
	[Obsolete("Replaced by environmentOcclusion.")]
	public bool useWaterOcclusion; //Field offset: 0x5B
	[Min(0)]
	public float occlusionRadius; //Field offset: 0x5C
	[Range(1, 64)]
	public uint sampleCount; //Field offset: 0x60
	public float occlusionOffset; //Field offset: 0x64
	[Min(0)]
	public float scale; //Field offset: 0x68
	public bool allowOffScreen; //Field offset: 0x6C
	[Obsolete("Please use environmentOcclusion instead.")]
	public bool volumetricCloudOcclusion; //Field offset: 0x6D
	public TextureCurve occlusionRemapCurve; //Field offset: 0x70
	public Light lightOverride; //Field offset: 0x78

	public LensFlareDataSRP lensFlareData
	{
		 get { } //Length: 5
		 set { } //Length: 237
	}

	private static LensFlareComponentSRP() { }

	public LensFlareComponentSRP() { }

	private void Awake() { }

	public float celestialProjectedOcclusionRadius(Camera mainCam) { }

	public LensFlareDataSRP get_lensFlareData() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnValidate() { }

	public void set_lensFlareData(LensFlareDataSRP value) { }

}

