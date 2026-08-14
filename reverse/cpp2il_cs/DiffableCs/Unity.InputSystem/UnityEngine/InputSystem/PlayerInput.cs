namespace UnityEngine.InputSystem;

[AddComponentMenu("Input/Player Input")]
[DisallowMultipleComponent]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/PlayerInput.html")]
public class PlayerInput : MonoBehaviour
{
	internal class ActionEvent : UnityEvent<CallbackContext>
	{
		[SerializeField]
		private string m_ActionId; //Field offset: 0x30
		[SerializeField]
		private string m_ActionName; //Field offset: 0x38

		public string actionId
		{
			 get { } //Length: 5
		}

		public string actionName
		{
			 get { } //Length: 5
		}

		public ActionEvent() { }

		public ActionEvent(InputAction action) { }

		public ActionEvent(Guid actionGUID, string name = null) { }

		public string get_actionId() { }

		public string get_actionName() { }

	}

	internal class ControlsChangedEvent : UnityEvent<PlayerInput>
	{

		public ControlsChangedEvent() { }

	}

	internal class DeviceLostEvent : UnityEvent<PlayerInput>
	{

		public DeviceLostEvent() { }

	}

	internal class DeviceRegainedEvent : UnityEvent<PlayerInput>
	{

		public DeviceRegainedEvent() { }

	}

	public const string DeviceLostMessage = "OnDeviceLost"; //Field offset: 0x0
	public const string DeviceRegainedMessage = "OnDeviceRegained"; //Field offset: 0x0
	public const string ControlsChangedMessage = "OnControlsChanged"; //Field offset: 0x0
	internal static int s_AllActivePlayersCount; //Field offset: 0x0
	internal static PlayerInput[] s_AllActivePlayers; //Field offset: 0x8
	private static Action<InputUser, InputUserChange, InputDevice> s_UserChangeDelegate; //Field offset: 0x10
	private static int s_InitPairWithDevicesCount; //Field offset: 0x18
	private static InputDevice[] s_InitPairWithDevices; //Field offset: 0x20
	private static int s_InitPlayerIndex; //Field offset: 0x28
	private static int s_InitSplitScreenIndex; //Field offset: 0x2C
	private static string s_InitControlScheme; //Field offset: 0x30
	internal static bool s_DestroyIfDeviceSetupUnsuccessful; //Field offset: 0x38
	private int m_AllMapsHashCode; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Input actions associated with the player.")]
	internal InputActionAsset m_Actions; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Determine how notifications should be sent when an input-related event associated with the player happens.")]
	internal PlayerNotifications m_NotificationBehavior; //Field offset: 0x30
	[SerializeField]
	[Tooltip("UI InputModule that should have it's input actions synchronized to this PlayerInput's actions.")]
	internal InputSystemUIInputModule m_UIInputModule; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Event that is triggered when the PlayerInput loses a paired device (e.g. its battery runs out).")]
	internal DeviceLostEvent m_DeviceLostEvent; //Field offset: 0x40
	[SerializeField]
	internal DeviceRegainedEvent m_DeviceRegainedEvent; //Field offset: 0x48
	[SerializeField]
	internal ControlsChangedEvent m_ControlsChangedEvent; //Field offset: 0x50
	[SerializeField]
	internal ActionEvent[] m_ActionEvents; //Field offset: 0x58
	[SerializeField]
	internal bool m_NeverAutoSwitchControlSchemes; //Field offset: 0x60
	[SerializeField]
	internal string m_DefaultControlScheme; //Field offset: 0x68
	[SerializeField]
	internal string m_DefaultActionMap; //Field offset: 0x70
	[SerializeField]
	internal int m_SplitScreenIndex; //Field offset: 0x78
	[SerializeField]
	[Tooltip("Reference to the player's view camera. Note that this is only required when using split-screen and/or per-player UIs. Otherwise it is safe to leave this property uninitialized.")]
	internal Camera m_Camera; //Field offset: 0x80
	private InputValue m_InputValueObject; //Field offset: 0x88
	internal InputActionMap m_CurrentActionMap; //Field offset: 0x90
	private int m_PlayerIndex; //Field offset: 0x98
	private bool m_InputActive; //Field offset: 0x9C
	private bool m_Enabled; //Field offset: 0x9D
	internal bool m_ActionsInitialized; //Field offset: 0x9E
	private Dictionary<String, String> m_ActionMessageNames; //Field offset: 0xA0
	private InputUser m_InputUser; //Field offset: 0xA8
	private Action<CallbackContext> m_ActionTriggeredDelegate; //Field offset: 0xB0
	private CallbackArray<Action`1<PlayerInput>> m_DeviceLostCallbacks; //Field offset: 0xB8
	private CallbackArray<Action`1<PlayerInput>> m_DeviceRegainedCallbacks; //Field offset: 0x108
	private CallbackArray<Action`1<PlayerInput>> m_ControlsChangedCallbacks; //Field offset: 0x158
	private CallbackArray<Action`1<CallbackContext>> m_ActionTriggeredCallbacks; //Field offset: 0x1A8
	private Action<InputControl, InputEventPtr> m_UnpairedDeviceUsedDelegate; //Field offset: 0x1F8
	private Func<InputDevice, InputEventPtr, Boolean> m_PreFilterUnpairedDeviceUsedDelegate; //Field offset: 0x200
	private bool m_OnUnpairedDeviceUsedHooked; //Field offset: 0x208
	private Action<InputDevice, InputDeviceChange> m_DeviceChangeDelegate; //Field offset: 0x210
	private bool m_OnDeviceChangeHooked; //Field offset: 0x218

	public event Action<CallbackContext> onActionTriggered
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public event Action<PlayerInput> onControlsChanged
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public event Action<PlayerInput> onDeviceLost
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public event Action<PlayerInput> onDeviceRegained
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public ReadOnlyArray<ActionEvent> actionEvents
	{
		 get { } //Length: 87
		 set { } //Length: 124
	}

	public InputActionAsset actions
	{
		 get { } //Length: 69
		 set { } //Length: 319
	}

	[Obsolete("Use inputIsActive instead.")]
	public bool active
	{
		 get { } //Length: 8
	}

	public static ReadOnlyArray<PlayerInput> all
	{
		 get { } //Length: 129
	}

	public Camera camera
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public ControlsChangedEvent controlsChangedEvent
	{
		 get { } //Length: 138
	}

	public InputActionMap currentActionMap
	{
		 get { } //Length: 8
		 set { } //Length: 125
	}

	public string currentControlScheme
	{
		 get { } //Length: 176
	}

	public string defaultActionMap
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string defaultControlScheme
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public DeviceLostEvent deviceLostEvent
	{
		 get { } //Length: 138
	}

	public DeviceRegainedEvent deviceRegainedEvent
	{
		 get { } //Length: 138
	}

	public ReadOnlyArray<InputDevice> devices
	{
		 get { } //Length: 164
	}

	public bool hasMissingRequiredDevices
	{
		 get { } //Length: 249
	}

	public bool inputIsActive
	{
		 get { } //Length: 8
	}

	public static bool isSinglePlayer
	{
		 get { } //Length: 261
	}

	public bool neverAutoSwitchControlSchemes
	{
		 get { } //Length: 5
		 set { } //Length: 53
	}

	public PlayerNotifications notificationBehavior
	{
		 get { } //Length: 4
		 set { } //Length: 69
	}

	public int playerIndex
	{
		 get { } //Length: 7
	}

	public int splitScreenIndex
	{
		 get { } //Length: 4
	}

	public InputSystemUIInputModule uiInputModule
	{
		 get { } //Length: 5
		 set { } //Length: 373
	}

	public InputUser user
	{
		 get { } //Length: 7
	}

	private static PlayerInput() { }

	public PlayerInput() { }

	public void ActivateInput() { }

	public void add_onActionTriggered(Action<CallbackContext> value) { }

	public void add_onControlsChanged(Action<PlayerInput> value) { }

	public void add_onDeviceLost(Action<PlayerInput> value) { }

	public void add_onDeviceRegained(Action<PlayerInput> value) { }

	private void AssignPlayerIndex() { }

	private void AssignUserAndDevices() { }

	private void CacheMessageNames() { }

	private void ClearCaches() { }

	private void CopyActionAssetAndApplyBindingOverrides() { }

	public void DeactivateInput() { }

	public void DebugLogAction(CallbackContext context) { }

	private static PlayerInput DoInstantiate(GameObject prefab) { }

	public static PlayerInput FindFirstPairedToDevice(InputDevice device) { }

	public ReadOnlyArray<ActionEvent> get_actionEvents() { }

	public InputActionAsset get_actions() { }

	public bool get_active() { }

	public static ReadOnlyArray<PlayerInput> get_all() { }

	public Camera get_camera() { }

	public ControlsChangedEvent get_controlsChangedEvent() { }

	public InputActionMap get_currentActionMap() { }

	public string get_currentControlScheme() { }

	public string get_defaultActionMap() { }

	public string get_defaultControlScheme() { }

	public DeviceLostEvent get_deviceLostEvent() { }

	public DeviceRegainedEvent get_deviceRegainedEvent() { }

	public ReadOnlyArray<InputDevice> get_devices() { }

	public bool get_hasMissingRequiredDevices() { }

	public bool get_inputIsActive() { }

	public static bool get_isSinglePlayer() { }

	public bool get_neverAutoSwitchControlSchemes() { }

	public PlayerNotifications get_notificationBehavior() { }

	public int get_playerIndex() { }

	public int get_splitScreenIndex() { }

	public InputSystemUIInputModule get_uiInputModule() { }

	public InputUser get_user() { }

	public TDevice GetDevice() { }

	public static PlayerInput GetPlayerByIndex(int playerIndex) { }

	private void HandleControlsChanged() { }

	private void HandleDeviceLost() { }

	private void HandleDeviceRegained() { }

	private bool HaveBindingForDevice(InputDevice device) { }

	private void InitializeActions() { }

	private void InstallOnActionTriggeredHook() { }

	public static PlayerInput Instantiate(GameObject prefab, int playerIndex = -1, string controlScheme = null, int splitScreenIndex = -1, InputDevice[] pairWithDevices) { }

	public static PlayerInput Instantiate(GameObject prefab, int playerIndex = -1, string controlScheme = null, int splitScreenIndex = -1, InputDevice pairWithDevice = null) { }

	private void OnActionTriggered(CallbackContext context) { }

	private void OnDeviceChange(InputDevice device, InputDeviceChange change) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private static bool OnPreFilterUnpairedDeviceUsed(InputDevice device, InputEventPtr eventPtr) { }

	private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr) { }

	private static void OnUserChange(InputUser user, InputUserChange change, InputDevice device) { }

	[Obsolete("Use DeactivateInput instead.")]
	public void PassivateInput() { }

	public void remove_onActionTriggered(Action<CallbackContext> value) { }

	public void remove_onControlsChanged(Action<PlayerInput> value) { }

	public void remove_onDeviceLost(Action<PlayerInput> value) { }

	public void remove_onDeviceRegained(Action<PlayerInput> value) { }

	public void set_actionEvents(ReadOnlyArray<ActionEvent> value) { }

	public void set_actions(InputActionAsset value) { }

	public void set_camera(Camera value) { }

	public void set_currentActionMap(InputActionMap value) { }

	public void set_defaultActionMap(string value) { }

	public void set_defaultControlScheme(string value) { }

	public void set_neverAutoSwitchControlSchemes(bool value) { }

	public void set_notificationBehavior(PlayerNotifications value) { }

	public void set_uiInputModule(InputSystemUIInputModule value) { }

	private void StartListeningForDeviceChanges() { }

	private void StartListeningForUnpairedDeviceActivity() { }

	private void StopListeningForDeviceChanges() { }

	private void StopListeningForUnpairedDeviceActivity() { }

	private void SwitchControlSchemeInternal(ref InputControlScheme controlScheme, InputDevice[] devices) { }

	public void SwitchCurrentActionMap(string mapNameOrId) { }

	public void SwitchCurrentControlScheme(string controlScheme, InputDevice[] devices) { }

	public bool SwitchCurrentControlScheme(InputDevice[] devices) { }

	private bool TryToActivateControlScheme(InputControlScheme controlScheme) { }

	private void UnassignUserAndDevices() { }

	private void UninitializeActions() { }

	private void UninstallOnActionTriggeredHook() { }

	private void UpdateDelegates() { }

}

