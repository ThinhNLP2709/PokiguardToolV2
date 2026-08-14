namespace UnityEngine.InputSystem.UI;

[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/UISupport.html#setting-up-ui-input")]
public class InputSystemUIInputModule : BaseInputModule
{
	internal enum CursorLockBehavior
	{
		OutsideScreen = 0,
		ScreenCenter = 1,
	}

	private struct InputActionReferenceState
	{
		public int refCount; //Field offset: 0x0
		public bool enabledByInputModule; //Field offset: 0x4

	}

	private const float kClickSpeed = 0.3; //Field offset: 0x0
	private const float kSmallestScrollDeltaPerTick = 1E-05; //Field offset: 0x0
	private static DefaultInputActions defaultActions; //Field offset: 0x0
	private static Dictionary<InputAction, InputActionReferenceState> s_InputActionReferenceCounts; //Field offset: 0x8
	[FormerlySerializedAs("m_RepeatDelay")]
	[SerializeField]
	[Tooltip("The Initial delay (in seconds) between an initial move action and a repeated move action.")]
	private float m_MoveRepeatDelay; //Field offset: 0x58
	[FormerlySerializedAs("m_RepeatRate")]
	[SerializeField]
	[Tooltip("The speed (in seconds) that the move action repeats itself once repeating (max 1 per frame).")]
	private float m_MoveRepeatRate; //Field offset: 0x5C
	[Tooltip("Scales the Eventsystem.DragThreshold, for tracked devices, to make selection easier.")]
	private float m_TrackedDeviceDragThresholdMultiplier; //Field offset: 0x60
	[SerializeField]
	[Tooltip("Transform representing the real world origin for tracking devices. When using the XR Interaction Toolkit, this should be pointing to the XR Rig's Transform.")]
	private Transform m_XRTrackingOrigin; //Field offset: 0x68
	[HideInInspector]
	[SerializeField]
	private InputActionAsset m_ActionsAsset; //Field offset: 0x70
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_PointAction; //Field offset: 0x78
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_MoveAction; //Field offset: 0x80
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_SubmitAction; //Field offset: 0x88
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_CancelAction; //Field offset: 0x90
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_LeftClickAction; //Field offset: 0x98
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_MiddleClickAction; //Field offset: 0xA0
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_RightClickAction; //Field offset: 0xA8
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_ScrollWheelAction; //Field offset: 0xB0
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_TrackedDevicePositionAction; //Field offset: 0xB8
	[HideInInspector]
	[SerializeField]
	private InputActionReference m_TrackedDeviceOrientationAction; //Field offset: 0xC0
	[SerializeField]
	private bool m_DeselectOnBackgroundClick; //Field offset: 0xC8
	[SerializeField]
	private UIPointerBehavior m_PointerBehavior; //Field offset: 0xCC
	[HideInInspector]
	[SerializeField]
	internal CursorLockBehavior m_CursorLockBehavior; //Field offset: 0xD0
	[SerializeField]
	private float m_ScrollDeltaPerTick; //Field offset: 0xD4
	private bool m_ActionsHooked; //Field offset: 0xD8
	private bool m_NeedToPurgeStalePointers; //Field offset: 0xD9
	private Action<CallbackContext> m_OnPointDelegate; //Field offset: 0xE0
	private Action<CallbackContext> m_OnMoveDelegate; //Field offset: 0xE8
	private Action<CallbackContext> m_OnSubmitCancelDelegate; //Field offset: 0xF0
	private Action<CallbackContext> m_OnLeftClickDelegate; //Field offset: 0xF8
	private Action<CallbackContext> m_OnRightClickDelegate; //Field offset: 0x100
	private Action<CallbackContext> m_OnMiddleClickDelegate; //Field offset: 0x108
	private Action<CallbackContext> m_OnScrollWheelDelegate; //Field offset: 0x110
	private Action<CallbackContext> m_OnTrackedDevicePositionDelegate; //Field offset: 0x118
	private Action<CallbackContext> m_OnTrackedDeviceOrientationDelegate; //Field offset: 0x120
	private Action<Object> m_OnControlsChangedDelegate; //Field offset: 0x128
	private int m_CurrentPointerId; //Field offset: 0x130
	private int m_CurrentPointerIndex; //Field offset: 0x134
	internal UIPointerType m_CurrentPointerType; //Field offset: 0x138
	internal InlinedArray<Int32> m_PointerIds; //Field offset: 0x140
	internal InlinedArray<PointerModel> m_PointerStates; //Field offset: 0x150
	private NavigationModel m_NavigationState; //Field offset: 0x380
	private SubmitCancelModel m_SubmitCancelState; //Field offset: 0x3A8
	private GameObject m_LocalMultiPlayerRoot; //Field offset: 0x3B8

	public InputActionAsset actionsAsset
	{
		 get { } //Length: 5
		 set { } //Length: 1717
	}

	public InputActionReference cancel
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public CursorLockBehavior cursorLockBehavior
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	public bool deselectOnBackgroundClick
	{
		 get { } //Length: 8
		 set { } //Length: 7
	}

	private bool explictlyIgnoreFocus
	{
		private get { } //Length: 82
	}

	public InputActionReference leftClick
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	internal GameObject localMultiPlayerRoot
	{
		internal get { } //Length: 8
		internal set { } //Length: 19
	}

	public InputActionReference middleClick
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public InputActionReference move
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public float moveRepeatDelay
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public float moveRepeatRate
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public InputActionReference point
	{
		 get { } //Length: 5
		 set { } //Length: 50
	}

	public UIPointerBehavior pointerBehavior
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	[Obsolete("'repeatDelay' has been obsoleted; use 'moveRepeatDelay' instead. (UnityUpgradable) -> moveRepeatDelay", False)]
	public float repeatDelay
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	[Obsolete("'repeatRate' has been obsoleted; use 'moveRepeatRate' instead. (UnityUpgradable) -> moveRepeatRate", False)]
	public float repeatRate
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public InputActionReference rightClick
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public float scrollDeltaPerTick
	{
		 get { } //Length: 9
		 set { } //Length: 9
	}

	public InputActionReference scrollWheel
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	internal bool sendPointerHoverToParent
	{
		internal get { } //Length: 5
		internal set { } //Length: 4
	}

	private bool shouldIgnoreFocus
	{
		private get { } //Length: 166
	}

	public InputActionReference submit
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public float trackedDeviceDragThresholdMultiplier
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public InputActionReference trackedDeviceOrientation
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	public InputActionReference trackedDevicePosition
	{
		 get { } //Length: 8
		 set { } //Length: 53
	}

	[Obsolete("'trackedDeviceSelect' has been obsoleted; use 'leftClick' instead.", True)]
	public InputActionReference trackedDeviceSelect
	{
		 get { } //Length: 62
		 set { } //Length: 62
	}

	public Transform xrTrackingOrigin
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	private static InputSystemUIInputModule() { }

	public InputSystemUIInputModule() { }

	public virtual void ActivateModule() { }

	private int AllocatePointer(int pointerId, int displayIndex, int touchId, UIPointerType pointerType, InputControl control, InputDevice device, InputControl touchControl = null) { }

	public void AssignDefaultActions() { }

	protected virtual void Awake() { }

	private bool CheckForRemovedDevice(ref CallbackContext context) { }

	public virtual Vector2 ConvertPointerEventScrollDeltaToTicks(Vector2 scrollDelta) { }

	public virtual int ConvertUIToolkitPointerId(PointerEventData sourcePointerData) { }

	private void DisableAllActions() { }

	private void EnableAllActions() { }

	private void EnableInputAction(InputActionReference inputActionReference) { }

	private void FilterPointerStatesByType() { }

	public InputActionAsset get_actionsAsset() { }

	public InputActionReference get_cancel() { }

	public CursorLockBehavior get_cursorLockBehavior() { }

	public bool get_deselectOnBackgroundClick() { }

	private bool get_explictlyIgnoreFocus() { }

	public InputActionReference get_leftClick() { }

	internal GameObject get_localMultiPlayerRoot() { }

	public InputActionReference get_middleClick() { }

	public InputActionReference get_move() { }

	public float get_moveRepeatDelay() { }

	public float get_moveRepeatRate() { }

	public InputActionReference get_point() { }

	public UIPointerBehavior get_pointerBehavior() { }

	public float get_repeatDelay() { }

	public float get_repeatRate() { }

	public InputActionReference get_rightClick() { }

	public float get_scrollDeltaPerTick() { }

	public InputActionReference get_scrollWheel() { }

	internal bool get_sendPointerHoverToParent() { }

	private bool get_shouldIgnoreFocus() { }

	public InputActionReference get_submit() { }

	public float get_trackedDeviceDragThresholdMultiplier() { }

	public InputActionReference get_trackedDeviceOrientation() { }

	public InputActionReference get_trackedDevicePosition() { }

	public InputActionReference get_trackedDeviceSelect() { }

	public Transform get_xrTrackingOrigin() { }

	private int GetDisplayIndexFor(InputControl control) { }

	public RaycastResult GetLastRaycastResult(int pointerOrTouchId) { }

	private PointerModel GetPointerStateForIndex(int index) { }

	private int GetPointerStateIndexFor(int pointerOrTouchId) { }

	private int GetPointerStateIndexFor(InputControl control, bool createIfNotExists = true) { }

	private int GetPointerStateIndexFor(ref CallbackContext context) { }

	private bool HasNoActions() { }

	private static bool HaveControlForDevice(InputDevice device, InputActionReference actionReference) { }

	private void HookActions() { }

	private bool IgnoreNextClick(ref CallbackContext context, bool wasPressed) { }

	private bool IsMoveAllowed(AxisEventData eventData) { }

	public virtual bool IsPointerOverGameObject(int pointerOrTouchId) { }

	private void OnControlsChanged(object obj) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	private void OnLeftClickCallback(CallbackContext context) { }

	private void OnMiddleClickCallback(CallbackContext context) { }

	private void OnMoveCallback(CallbackContext context) { }

	private void OnPointCallback(CallbackContext context) { }

	private void OnRightClickCallback(CallbackContext context) { }

	private void OnScrollCallback(CallbackContext context) { }

	private void OnSubmitCancelCallback(CallbackContext context) { }

	private void OnTrackedDeviceOrientationCallback(CallbackContext context) { }

	private void OnTrackedDevicePositionCallback(CallbackContext context) { }

	private RaycastResult PerformRaycast(ExtendedPointerEventData eventData) { }

	private bool PointerShouldIgnoreTransform(Transform t) { }

	public virtual void Process() { }

	internal void ProcessNavigation(ref NavigationModel navigationState) { }

	private void ProcessPointer(ref PointerModel state) { }

	private void ProcessPointerButton(ref ButtonState button, PointerEventData eventData) { }

	private void ProcessPointerButtonDrag(ref ButtonState button, ExtendedPointerEventData eventData) { }

	private void ProcessPointerMovement(ExtendedPointerEventData eventData, GameObject currentPointerTarget) { }

	private void ProcessPointerMovement(ref PointerModel pointer, ExtendedPointerEventData eventData) { }

	private static void ProcessPointerScroll(ref PointerModel pointer, PointerEventData eventData) { }

	private void PurgeStalePointers() { }

	private bool RemovePointerAtIndex(int index) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	private static void ResetDefaultActions() { }

	private void ResetPointers() { }

	private bool SendPointerExitEventsAndRemovePointer(int index) { }

	public void set_actionsAsset(InputActionAsset value) { }

	public void set_cancel(InputActionReference value) { }

	public void set_cursorLockBehavior(CursorLockBehavior value) { }

	public void set_deselectOnBackgroundClick(bool value) { }

	public void set_leftClick(InputActionReference value) { }

	internal void set_localMultiPlayerRoot(GameObject value) { }

	public void set_middleClick(InputActionReference value) { }

	public void set_move(InputActionReference value) { }

	public void set_moveRepeatDelay(float value) { }

	public void set_moveRepeatRate(float value) { }

	public void set_point(InputActionReference value) { }

	public void set_pointerBehavior(UIPointerBehavior value) { }

	public void set_repeatDelay(float value) { }

	public void set_repeatRate(float value) { }

	public void set_rightClick(InputActionReference value) { }

	public void set_scrollDeltaPerTick(float value) { }

	public void set_scrollWheel(InputActionReference value) { }

	internal void set_sendPointerHoverToParent(bool value) { }

	public void set_submit(InputActionReference value) { }

	public void set_trackedDeviceDragThresholdMultiplier(float value) { }

	public void set_trackedDeviceOrientation(InputActionReference value) { }

	public void set_trackedDevicePosition(InputActionReference value) { }

	public void set_trackedDeviceSelect(InputActionReference value) { }

	public void set_xrTrackingOrigin(Transform value) { }

	private static void SetActionCallback(InputActionReference actionReference, Action<CallbackContext> callback, bool install) { }

	private void SetActionCallbacks(bool install) { }

	private void SwapAction(ref InputActionReference property, InputActionReference newValue, bool actionsHooked, Action<CallbackContext> actionCallback) { }

	private void TryDisableInputAction(InputActionReference inputActionReference, bool isComponentDisabling = false) { }

	public void UnassignActions() { }

	private void UnhookActions() { }

	private InputActionReference UpdateReferenceForNewAsset(InputActionReference actionReference) { }

}

