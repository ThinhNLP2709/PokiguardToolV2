namespace UnityEngine.InputSystem.XR;

[AddComponentMenu("XR/Tracked Pose Driver (Input System)")]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/TrackedInputDevices.html#tracked-pose-driver")]
public class TrackedPoseDriver : MonoBehaviour, ISerializationCallbackReceiver
{
	[Flags]
	private enum TrackingStates
	{
		None = 0,
		Position = 1,
		Rotation = 2,
	}

	internal enum TrackingType
	{
		RotationAndPosition = 0,
		RotationOnly = 1,
		PositionOnly = 2,
	}

	internal enum UpdateType
	{
		UpdateAndBeforeRender = 0,
		Update = 1,
		BeforeRender = 2,
	}

	[SerializeField]
	[Tooltip("Which Transform properties to update.")]
	private TrackingType m_TrackingType; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Updates the Transform properties after these phases of Input System event processing.")]
	private UpdateType m_UpdateType; //Field offset: 0x24
	[SerializeField]
	[Tooltip("Ignore Tracking State and always treat the input pose as valid.")]
	private bool m_IgnoreTrackingState; //Field offset: 0x28
	[SerializeField]
	[Tooltip("The input action to read the position value of a tracked device. Must be a Vector 3 control type.")]
	private InputActionProperty m_PositionInput; //Field offset: 0x30
	[SerializeField]
	[Tooltip("The input action to read the rotation value of a tracked device. Must be a Quaternion control type.")]
	private InputActionProperty m_RotationInput; //Field offset: 0x48
	[SerializeField]
	[Tooltip("The input action to read the tracking state value of a tracked device. Identifies if position and rotation have valid data. Must be an Integer control type.")]
	private InputActionProperty m_TrackingStateInput; //Field offset: 0x60
	private Vector3 m_CurrentPosition; //Field offset: 0x78
	private Quaternion m_CurrentRotation; //Field offset: 0x84
	private TrackingStates m_CurrentTrackingState; //Field offset: 0x94
	private bool m_RotationBound; //Field offset: 0x98
	private bool m_PositionBound; //Field offset: 0x99
	private bool m_TrackingStateBound; //Field offset: 0x9A
	private bool m_IsFirstUpdate; //Field offset: 0x9B
	[HideInInspector]
	[Obsolete]
	[SerializeField]
	private InputAction m_PositionAction; //Field offset: 0xA0
	[HideInInspector]
	[Obsolete]
	[SerializeField]
	private InputAction m_RotationAction; //Field offset: 0xA8

	public bool ignoreTrackingState
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public InputAction positionAction
	{
		 get { } //Length: 11
		 set { } //Length: 222
	}

	public InputActionProperty positionInput
	{
		 get { } //Length: 21
		 set { } //Length: 181
	}

	public InputAction rotationAction
	{
		 get { } //Length: 11
		 set { } //Length: 222
	}

	public InputActionProperty rotationInput
	{
		 get { } //Length: 21
		 set { } //Length: 181
	}

	public InputActionProperty trackingStateInput
	{
		 get { } //Length: 21
		 set { } //Length: 181
	}

	public TrackingType trackingType
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public UpdateType updateType
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public TrackedPoseDriver() { }

	protected override void Awake() { }

	private void BindActions() { }

	private void BindPosition() { }

	private void BindRotation() { }

	private void BindTrackingState() { }

	public bool get_ignoreTrackingState() { }

	public InputAction get_positionAction() { }

	public InputActionProperty get_positionInput() { }

	public InputAction get_rotationAction() { }

	public InputActionProperty get_rotationInput() { }

	public InputActionProperty get_trackingStateInput() { }

	public TrackingType get_trackingType() { }

	public UpdateType get_updateType() { }

	private static bool HasResolvedControl(InputAction action) { }

	protected override void OnBeforeRender() { }

	protected override void OnDestroy() { }

	private void OnDeviceChanged(InputDevice inputDevice, InputDeviceChange inputDeviceChange) { }

	protected void OnDisable() { }

	protected void OnEnable() { }

	private void OnPositionCanceled(CallbackContext context) { }

	private void OnPositionPerformed(CallbackContext context) { }

	private void OnRotationCanceled(CallbackContext context) { }

	private void OnRotationPerformed(CallbackContext context) { }

	private void OnTrackingStateCanceled(CallbackContext context) { }

	private void OnTrackingStatePerformed(CallbackContext context) { }

	protected override void OnUpdate() { }

	protected override void PerformUpdate() { }

	private void ReadTrackingState() { }

	private void ReadTrackingStateWithoutTrackingAction() { }

	private static void RenameAndEnable(InputAction action, string name) { }

	protected void Reset() { }

	public void set_ignoreTrackingState(bool value) { }

	public void set_positionAction(InputAction value) { }

	public void set_positionInput(InputActionProperty value) { }

	public void set_rotationAction(InputAction value) { }

	public void set_rotationInput(InputActionProperty value) { }

	public void set_trackingStateInput(InputActionProperty value) { }

	public void set_trackingType(TrackingType value) { }

	public void set_updateType(UpdateType value) { }

	protected override void SetLocalTransform(Vector3 newPosition, Quaternion newRotation) { }

	private void UnbindActions() { }

	private void UnbindPosition() { }

	private void UnbindRotation() { }

	private void UnbindTrackingState() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

	protected void UpdateCallback() { }

}

