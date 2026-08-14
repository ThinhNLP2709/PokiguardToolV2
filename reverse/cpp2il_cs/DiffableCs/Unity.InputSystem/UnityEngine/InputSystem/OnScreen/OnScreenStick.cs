namespace UnityEngine.InputSystem.OnScreen;

[AddComponentMenu("Input/On-Screen Stick")]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/OnScreen.html#on-screen-sticks")]
public class OnScreenStick : OnScreenControl, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	internal enum Behaviour
	{
		RelativePositionWithStaticOrigin = 0,
		ExactPositionWithStaticOrigin = 1,
		ExactPositionWithDynamicOrigin = 2,
	}

	private const string kDynamicOriginClickable = "DynamicOriginClickable"; //Field offset: 0x0
	[FormerlySerializedAs("movementRange")]
	[Min(0)]
	[SerializeField]
	private float m_MovementRange; //Field offset: 0x38
	[Min(0)]
	[SerializeField]
	[Tooltip("Defines the circular region where the onscreen control may have it's origin placed.")]
	private float m_DynamicOriginRange; //Field offset: 0x3C
	[InputControl(layout = "Vector2")]
	[SerializeField]
	private string m_ControlPath; //Field offset: 0x40
	[SerializeField]
	[Tooltip("Choose how the onscreen stick will move relative to it's origin and the press position.\n\nRelativePositionWithStaticOrigin: The control's center of origin is fixed. The control will begin un-actuated at it's centered position and then move relative to the pointer or finger motion.\n\nExactPositionWithStaticOrigin: The control's center of origin is fixed. The stick will immediately jump to the exact position of the click or touch and begin tracking motion from there.\n\nExactPositionWithDynamicOrigin: The control's center of origin is determined by the initial press position. The stick will begin un-actuated at this center position and then track the current pointer or finger position.")]
	private Behaviour m_Behaviour; //Field offset: 0x48
	[SerializeField]
	[Tooltip("Set this to true to prevent cancellation of pointer events due to device switching. Cancellation will appear as the stick jumping back and forth between the pointer position and the stick center.")]
	private bool m_UseIsolatedInputActions; //Field offset: 0x4C
	[SerializeField]
	[Tooltip("The action that will be used to detect pointer down events on the stick control. Note that if no bindings are set, default ones will be provided.")]
	private InputAction m_PointerDownAction; //Field offset: 0x50
	[SerializeField]
	[Tooltip("The action that will be used to detect pointer movement on the stick control. Note that if no bindings are set, default ones will be provided.")]
	private InputAction m_PointerMoveAction; //Field offset: 0x58
	private Vector3 m_StartPos; //Field offset: 0x60
	private Vector2 m_PointerDownPos; //Field offset: 0x6C
	private List<RaycastResult> m_RaycastResults; //Field offset: 0x78
	private PointerEventData m_PointerEventData; //Field offset: 0x80
	private TouchControl m_TouchControl; //Field offset: 0x88
	private bool m_IsIsolationActive; //Field offset: 0x90

	public Behaviour behaviour
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	protected virtual string controlPathInternal
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public float dynamicOriginRange
	{
		 get { } //Length: 6
		 set { } //Length: 270
	}

	public float movementRange
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public bool useIsolatedInputActions
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public OnScreenStick() { }

	private void BeginInteraction(Vector2 pointerPosition, Camera uiCamera) { }

	private void DrawGizmoCircle(Vector2 center, float radius) { }

	private void EndInteraction() { }

	public Behaviour get_behaviour() { }

	protected virtual string get_controlPathInternal() { }

	public float get_dynamicOriginRange() { }

	public float get_movementRange() { }

	public bool get_useIsolatedInputActions() { }

	private Camera GetCameraFromCanvas() { }

	private void MoveStick(Vector2 pointerPosition, Camera uiCamera) { }

	private void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	private void OnDrawGizmosSelected() { }

	private void OnPointerChanged(CallbackContext ctx) { }

	private void OnPointerDown(CallbackContext ctx) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	private void OnPointerMove(CallbackContext ctx) { }

	private void OnPointerUp(CallbackContext ctx) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	public void set_behaviour(Behaviour value) { }

	protected virtual void set_controlPathInternal(string value) { }

	public void set_dynamicOriginRange(float value) { }

	public void set_movementRange(float value) { }

	public void set_useIsolatedInputActions(bool value) { }

	private void Start() { }

	private void UpdateDynamicOriginClickableArea() { }

}

