namespace TMPro.Examples;

public class CameraController : MonoBehaviour
{
	internal enum CameraModes
	{
		Follow = 0,
		Isometric = 1,
		Free = 2,
	}

	private const string event_FollowDistance = "Slider - Camera Zoom"; //Field offset: 0x0
	private const string event_SmoothingValue = "Slider - Smoothing Value"; //Field offset: 0x0
	private Transform cameraTransform; //Field offset: 0x20
	private Transform dummyTarget; //Field offset: 0x28
	public Transform CameraTarget; //Field offset: 0x30
	public float FollowDistance; //Field offset: 0x38
	public float MaxFollowDistance; //Field offset: 0x3C
	public float MinFollowDistance; //Field offset: 0x40
	public float ElevationAngle; //Field offset: 0x44
	public float MaxElevationAngle; //Field offset: 0x48
	public float MinElevationAngle; //Field offset: 0x4C
	public float OrbitalAngle; //Field offset: 0x50
	public CameraModes CameraMode; //Field offset: 0x54
	public bool MovementSmoothing; //Field offset: 0x58
	public bool RotationSmoothing; //Field offset: 0x59
	private bool previousSmoothing; //Field offset: 0x5A
	public float MovementSmoothingValue; //Field offset: 0x5C
	public float RotationSmoothingValue; //Field offset: 0x60
	public float MoveSensitivity; //Field offset: 0x64
	private Vector3 currentVelocity; //Field offset: 0x68
	private Vector3 desiredPosition; //Field offset: 0x74
	private float mouseX; //Field offset: 0x80
	private float mouseY; //Field offset: 0x84
	private Vector3 moveVector; //Field offset: 0x88
	private float mouseWheel; //Field offset: 0x94

	public CameraController() { }

	private void Awake() { }

	private void GetPlayerInput() { }

	private void LateUpdate() { }

	private void Start() { }

}

