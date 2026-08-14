namespace TMPro.Examples;

public class ObjectSpin : MonoBehaviour
{
	internal enum MotionType
	{
		Rotation = 0,
		SearchLight = 1,
		Translation = 2,
	}

	public MotionType Motion; //Field offset: 0x20
	public Vector3 TranslationDistance; //Field offset: 0x24
	public float TranslationSpeed; //Field offset: 0x30
	public float SpinSpeed; //Field offset: 0x34
	public int RotationRange; //Field offset: 0x38
	private Transform m_transform; //Field offset: 0x40
	private float m_time; //Field offset: 0x48
	private Vector3 m_prevPOS; //Field offset: 0x4C
	private Vector3 m_initial_Rotation; //Field offset: 0x58
	private Vector3 m_initial_Position; //Field offset: 0x64
	private Color32 m_lightColor; //Field offset: 0x70

	public ObjectSpin() { }

	private void Awake() { }

	private void Update() { }

}

