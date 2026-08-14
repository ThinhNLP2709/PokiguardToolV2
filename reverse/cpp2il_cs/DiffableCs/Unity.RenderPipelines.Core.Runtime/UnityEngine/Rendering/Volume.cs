namespace UnityEngine.Rendering;

[AddComponentMenu("Miscellaneous/Volume")]
[ExecuteAlways]
public class Volume : MonoBehaviour, IVolume
{
	[FormerlySerializedAs("isGlobal")]
	[SerializeField]
	private bool m_IsGlobal; //Field offset: 0x20
	[Delayed]
	public float priority; //Field offset: 0x24
	public float blendDistance; //Field offset: 0x28
	[Range(0, 1)]
	public float weight; //Field offset: 0x2C
	public VolumeProfile sharedProfile; //Field offset: 0x30
	internal List<Collider> m_Colliders; //Field offset: 0x38
	private int m_PreviousLayer; //Field offset: 0x40
	private float m_PreviousPriority; //Field offset: 0x44
	private VolumeProfile m_InternalProfile; //Field offset: 0x48

	public override List<Collider> colliders
	{
		 get { } //Length: 5
	}

	public override bool isGlobal
	{
		 get { } //Length: 5
		 set { } //Length: 1011
	}

	public VolumeProfile profile
	{
		 get { } //Length: 688
		 set { } //Length: 13
	}

	internal VolumeProfile profileRef
	{
		internal get { } //Length: 113
	}

	public Volume() { }

	public override List<Collider> get_colliders() { }

	public override bool get_isGlobal() { }

	public VolumeProfile get_profile() { }

	internal VolumeProfile get_profileRef() { }

	public bool HasInstantiatedProfile() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnValidate() { }

	public override void set_isGlobal(bool value) { }

	public void set_profile(VolumeProfile value) { }

	private void Update() { }

	internal void UpdateLayer() { }

	internal void UpdatePriority() { }

}

