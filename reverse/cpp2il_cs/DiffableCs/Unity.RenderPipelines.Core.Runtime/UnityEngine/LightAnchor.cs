namespace UnityEngine;

[AddComponentMenu("Rendering/Light Anchor")]
[DisallowMultipleComponent]
[ExecuteInEditMode]
public class LightAnchor : MonoBehaviour
{
	private struct Axes
	{
		public Vector3 up; //Field offset: 0x0
		public Vector3 right; //Field offset: 0xC
		public Vector3 forward; //Field offset: 0x18

	}

	internal enum UpDirection
	{
		World = 0,
		Local = 1,
	}

	private const float k_ArcRadius = 5; //Field offset: 0x0
	private const float k_AxisLength = 10; //Field offset: 0x0
	internal const float k_MaxDistance = 10000; //Field offset: 0x0
	[Min(0)]
	[SerializeField]
	private float m_Distance; //Field offset: 0x20
	[SerializeField]
	private UpDirection m_FrameSpace; //Field offset: 0x24
	[SerializeField]
	private Transform m_AnchorPositionOverride; //Field offset: 0x28
	[SerializeField]
	private Vector3 m_AnchorPositionOffset; //Field offset: 0x30
	[SerializeField]
	private float m_Yaw; //Field offset: 0x3C
	[SerializeField]
	private float m_Pitch; //Field offset: 0x40
	[SerializeField]
	private float m_Roll; //Field offset: 0x44

	public Vector3 anchorPosition
	{
		 get { } //Length: 424
	}

	public Vector3 anchorPositionOffset
	{
		 get { } //Length: 19
		 set { } //Length: 16
	}

	public Transform anchorPositionOverride
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public float distance
	{
		 get { } //Length: 6
		 set { } //Length: 33
	}

	public UpDirection frameSpace
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float pitch
	{
		 get { } //Length: 6
		 set { } //Length: 77
	}

	public float roll
	{
		 get { } //Length: 6
		 set { } //Length: 77
	}

	public float yaw
	{
		 get { } //Length: 6
		 set { } //Length: 77
	}

	public LightAnchor() { }

	public Vector3 get_anchorPosition() { }

	public Vector3 get_anchorPositionOffset() { }

	public Transform get_anchorPositionOverride() { }

	public float get_distance() { }

	public UpDirection get_frameSpace() { }

	public float get_pitch() { }

	public float get_roll() { }

	public float get_yaw() { }

	private Axes GetWorldSpaceAxes(Camera camera, Vector3 anchor) { }

	public static float NormalizeAngleDegree(float angle) { }

	private void OnDrawGizmosSelected() { }

	public void set_anchorPositionOffset(Vector3 value) { }

	public void set_anchorPositionOverride(Transform value) { }

	public void set_distance(float value) { }

	public void set_frameSpace(UpDirection value) { }

	public void set_pitch(float value) { }

	public void set_roll(float value) { }

	public void set_yaw(float value) { }

	public void SynchronizeOnTransform(Camera camera) { }

	private void Update() { }

	private void UpdateTransform(Vector3 up, Vector3 right, Vector3 forward, Vector3 anchor) { }

	public void UpdateTransform(Camera camera, Vector3 anchor) { }

}

