namespace UnityEngine.Rendering;

[AddComponentMenu("Rendering/Adaptive Probe Volume")]
[ExecuteAlways]
public class ProbeVolume : MonoBehaviour
{
	internal enum Mode
	{
		Global = 0,
		Scene = 1,
		Local = 2,
	}

	private enum Version
	{
		Initial = 0,
		LocalMode = 1,
		InvertOverrideLevels = 2,
		Count = 3,
	}

	[Tooltip("When set to Global this Probe Volume considers all renderers with Contribute Global Illumination enabled. Local only considers renderers in the scene.\nThis list updates every time the Scene is saved or the lighting is baked.")]
	public Mode mode; //Field offset: 0x20
	public Vector3 size; //Field offset: 0x24
	[HideInInspector]
	[Min(0)]
	public bool overrideRendererFilters; //Field offset: 0x30
	[HideInInspector]
	[Min(0)]
	public float minRendererVolumeSize; //Field offset: 0x34
	public LayerMask objectLayerMask; //Field offset: 0x38
	[HideInInspector]
	public int lowestSubdivLevelOverride; //Field offset: 0x3C
	[HideInInspector]
	public int highestSubdivLevelOverride; //Field offset: 0x40
	[HideInInspector]
	public bool overridesSubdivLevels; //Field offset: 0x44
	[SerializeField]
	internal bool mightNeedRebaking; //Field offset: 0x45
	[SerializeField]
	internal Matrix4x4 cachedTransform; //Field offset: 0x48
	[SerializeField]
	internal int cachedHashCode; //Field offset: 0x88
	[HideInInspector]
	[Tooltip("Whether Unity should fill empty space between renderers with bricks at the highest subdivision level.")]
	public bool fillEmptySpaces; //Field offset: 0x8C
	[SerializeField]
	private Version version; //Field offset: 0x90
	[Obsolete("Use mode instead")]
	[SerializeField]
	public bool globalVolume; //Field offset: 0x94

	public ProbeVolume() { }

	private void Awake() { }

}

