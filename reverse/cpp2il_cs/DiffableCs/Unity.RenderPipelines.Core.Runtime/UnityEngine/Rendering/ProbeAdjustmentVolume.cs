namespace UnityEngine.Rendering;

[AddComponentMenu("Rendering/Probe Adjustment Volume")]
[ExecuteAlways]
public class ProbeAdjustmentVolume : MonoBehaviour, ISerializationCallbackReceiver
{
	internal enum Mode
	{
		InvalidateProbes = 0,
		OverrideValidityThreshold = 1,
		ApplyVirtualOffset = 2,
		OverrideVirtualOffsetSettings = 3,
		OverrideSkyDirection = 4,
		OverrideSampleCount = 5,
		OverrideRenderingLayerMask = 6,
		IntensityScale = 99,
	}

	internal enum RenderingLayerMaskOperation
	{
		Override = 0,
		Add = 1,
		Remove = 2,
	}

	internal enum Shape
	{
		Box = 0,
		Sphere = 1,
	}

	private enum Version
	{
		Initial = 0,
		Mode = 1,
		Count = 2,
	}

	[Tooltip("Select the shape used for this Probe Adjustment Volume.")]
	public Shape shape; //Field offset: 0x20
	[Min(0)]
	[Tooltip("Modify the size of this Probe Adjustment Volume. This is unaffected by the GameObject's Transform's Scale property.")]
	public Vector3 size; //Field offset: 0x24
	[Min(0)]
	[Tooltip("Modify the radius of this Probe Adjustment Volume. This is unaffected by the GameObject's Transform's Scale property.")]
	public float radius; //Field offset: 0x30
	public Mode mode; //Field offset: 0x34
	[Range(0.0001, 2)]
	[Tooltip("A multiplier applied to the intensity of probes covered by this Probe Adjustment Volume.")]
	public float intensityScale; //Field offset: 0x38
	[Range(0, 0.95)]
	public float overriddenDilationThreshold; //Field offset: 0x3C
	public Vector3 virtualOffsetRotation; //Field offset: 0x40
	[Min(0)]
	public float virtualOffsetDistance; //Field offset: 0x4C
	[Range(0, 1)]
	[Tooltip("Determines how far Unity pushes a probe out of geometry after a ray hit.")]
	public float geometryBias; //Field offset: 0x50
	[Range(0, 0.95)]
	public float virtualOffsetThreshold; //Field offset: 0x54
	[Range(-0.05, 0)]
	[Tooltip("Distance from the probe position used to determine the origin of the sampling ray.")]
	public float rayOriginBias; //Field offset: 0x58
	[Tooltip("The direction for sampling the ambient probe in worldspace when using the Sky Visibility feature.")]
	public Vector3 skyDirection; //Field offset: 0x5C
	internal Vector3 skyShadingDirectionRotation; //Field offset: 0x68
	[Logarithmic(1, 1024)]
	[Tooltip("Number of samples for direct lighting computations.")]
	public int directSampleCount; //Field offset: 0x74
	[Logarithmic(1, 8192)]
	[Tooltip("Number of samples for indirect lighting computations. This includes environment samples.")]
	public int indirectSampleCount; //Field offset: 0x78
	[Min(0)]
	[Tooltip("Multiplier for the number of samples specified above.")]
	public int sampleCountMultiplier; //Field offset: 0x7C
	[Min(0)]
	[Tooltip("Maximum number of bounces for indirect lighting.")]
	public int maxBounces; //Field offset: 0x80
	[Logarithmic(1, 8192)]
	public int skyOcclusionSampleCount; //Field offset: 0x84
	[Range(0, 5)]
	public int skyOcclusionMaxBounces; //Field offset: 0x88
	public RenderingLayerMaskOperation renderingLayerMaskOperation; //Field offset: 0x8C
	public byte renderingLayerMask; //Field offset: 0x90
	[SerializeField]
	private Version version; //Field offset: 0x94
	[Obsolete("Use mode")]
	public bool invalidateProbes; //Field offset: 0x98
	[Obsolete("Use mode")]
	public bool overrideDilationThreshold; //Field offset: 0x99

	public ProbeAdjustmentVolume() { }

	private void Awake() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

