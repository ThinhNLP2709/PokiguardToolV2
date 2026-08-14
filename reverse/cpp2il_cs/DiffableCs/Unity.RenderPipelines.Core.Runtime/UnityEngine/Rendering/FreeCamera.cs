namespace UnityEngine.Rendering;

public class FreeCamera : MonoBehaviour
{
	private const float k_MouseSensitivityMultiplier = 0.01; //Field offset: 0x0
	public float m_LookSpeedController; //Field offset: 0x20
	public float m_LookSpeedMouse; //Field offset: 0x24
	public float m_MoveSpeed; //Field offset: 0x28
	public float m_MoveSpeedIncrement; //Field offset: 0x2C
	public float m_Turbo; //Field offset: 0x30
	private InputAction lookAction; //Field offset: 0x38
	private InputAction moveAction; //Field offset: 0x40
	private InputAction speedAction; //Field offset: 0x48
	private InputAction yMoveAction; //Field offset: 0x50
	private float inputRotateAxisX; //Field offset: 0x58
	private float inputRotateAxisY; //Field offset: 0x5C
	private float inputChangeSpeed; //Field offset: 0x60
	private float inputVertical; //Field offset: 0x64
	private float inputHorizontal; //Field offset: 0x68
	private float inputYAxis; //Field offset: 0x6C
	private bool leftShiftBoost; //Field offset: 0x70
	private bool leftShift; //Field offset: 0x71
	private bool fire1; //Field offset: 0x72

	public FreeCamera() { }

	private void OnEnable() { }

	private void RegisterInputs() { }

	private void Update() { }

	private void UpdateInputs() { }

}

