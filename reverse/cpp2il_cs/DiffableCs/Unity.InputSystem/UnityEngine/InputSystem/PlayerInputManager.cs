namespace UnityEngine.InputSystem;

[AddComponentMenu("Input/Player Input Manager")]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/PlayerInputManager.html")]
public class PlayerInputManager : MonoBehaviour
{
	internal class PlayerJoinedEvent : UnityEvent<PlayerInput>
	{

		public PlayerJoinedEvent() { }

	}

	internal class PlayerLeftEvent : UnityEvent<PlayerInput>
	{

		public PlayerLeftEvent() { }

	}

	public const string PlayerJoinedMessage = "OnPlayerJoined"; //Field offset: 0x0
	public const string PlayerLeftMessage = "OnPlayerLeft"; //Field offset: 0x0
	[CompilerGenerated]
	private static PlayerInputManager <instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	internal PlayerNotifications m_NotificationBehavior; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Set a limit for the maximum number of players who are able to join.")]
	internal int m_MaxPlayerCount; //Field offset: 0x24
	[SerializeField]
	internal bool m_AllowJoining; //Field offset: 0x28
	[SerializeField]
	internal PlayerJoinBehavior m_JoinBehavior; //Field offset: 0x2C
	[SerializeField]
	internal PlayerJoinedEvent m_PlayerJoinedEvent; //Field offset: 0x30
	[SerializeField]
	internal PlayerLeftEvent m_PlayerLeftEvent; //Field offset: 0x38
	[SerializeField]
	internal InputActionProperty m_JoinAction; //Field offset: 0x40
	[SerializeField]
	internal GameObject m_PlayerPrefab; //Field offset: 0x58
	[SerializeField]
	internal bool m_SplitScreen; //Field offset: 0x60
	[SerializeField]
	internal bool m_MaintainAspectRatioInSplitScreen; //Field offset: 0x61
	[SerializeField]
	[Tooltip("Explicitly set a fixed number of screens or otherwise allow the screen to be divided automatically to best fit the number of players.")]
	internal int m_FixedNumberOfSplitScreens; //Field offset: 0x64
	[SerializeField]
	internal Rect m_SplitScreenRect; //Field offset: 0x68
	private bool m_JoinActionDelegateHooked; //Field offset: 0x78
	private bool m_UnpairedDeviceUsedDelegateHooked; //Field offset: 0x79
	private Action<CallbackContext> m_JoinActionDelegate; //Field offset: 0x80
	private Action<InputControl, InputEventPtr> m_UnpairedDeviceUsedDelegate; //Field offset: 0x88
	private CallbackArray<Action`1<PlayerInput>> m_PlayerJoinedCallbacks; //Field offset: 0x90
	private CallbackArray<Action`1<PlayerInput>> m_PlayerLeftCallbacks; //Field offset: 0xE0

	public event Action<PlayerInput> onPlayerJoined
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public event Action<PlayerInput> onPlayerLeft
	{
		 add { } //Length: 153
		 remove { } //Length: 153
	}

	public int fixedNumberOfSplitScreens
	{
		 get { } //Length: 4
	}

	public private static PlayerInputManager instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public InputActionProperty joinAction
	{
		 get { } //Length: 21
		 set { } //Length: 167
	}

	public PlayerJoinBehavior joinBehavior
	{
		 get { } //Length: 4
		 set { } //Length: 71
	}

	public bool joiningEnabled
	{
		 get { } //Length: 5
	}

	public bool maintainAspectRatioInSplitScreen
	{
		 get { } //Length: 5
	}

	public int maxPlayerCount
	{
		 get { } //Length: 4
	}

	internal static String[] messages
	{
		internal get { } //Length: 155
	}

	public PlayerNotifications notificationBehavior
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public int playerCount
	{
		 get { } //Length: 77
	}

	public PlayerJoinedEvent playerJoinedEvent
	{
		 get { } //Length: 138
	}

	public PlayerLeftEvent playerLeftEvent
	{
		 get { } //Length: 138
	}

	public GameObject playerPrefab
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool splitScreen
	{
		 get { } //Length: 5
		 set { } //Length: 646
	}

	public Rect splitScreenArea
	{
		 get { } //Length: 11
	}

	public PlayerInputManager() { }

	public void add_onPlayerJoined(Action<PlayerInput> value) { }

	public void add_onPlayerLeft(Action<PlayerInput> value) { }

	private bool CheckIfPlayerCanJoin(int playerIndex = -1) { }

	public void DisableJoining() { }

	public void EnableJoining() { }

	public int get_fixedNumberOfSplitScreens() { }

	[CompilerGenerated]
	public static PlayerInputManager get_instance() { }

	public InputActionProperty get_joinAction() { }

	public PlayerJoinBehavior get_joinBehavior() { }

	public bool get_joiningEnabled() { }

	public bool get_maintainAspectRatioInSplitScreen() { }

	public int get_maxPlayerCount() { }

	internal static String[] get_messages() { }

	public PlayerNotifications get_notificationBehavior() { }

	public int get_playerCount() { }

	public PlayerJoinedEvent get_playerJoinedEvent() { }

	public PlayerLeftEvent get_playerLeftEvent() { }

	public GameObject get_playerPrefab() { }

	public bool get_splitScreen() { }

	public Rect get_splitScreenArea() { }

	private bool IsDeviceUsableWithPlayerActions(InputDevice device) { }

	public PlayerInput JoinPlayer(int playerIndex = -1, int splitScreenIndex = -1, string controlScheme = null, InputDevice pairWithDevice = null) { }

	public PlayerInput JoinPlayer(int playerIndex = -1, int splitScreenIndex = -1, string controlScheme = null, InputDevice[] pairWithDevices) { }

	public void JoinPlayerFromAction(CallbackContext context) { }

	public void JoinPlayerFromActionIfNotAlreadyJoined(CallbackContext context) { }

	internal void JoinPlayerFromUI() { }

	internal void NotifyPlayerJoined(PlayerInput player) { }

	internal void NotifyPlayerLeft(PlayerInput player) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr) { }

	public void remove_onPlayerJoined(Action<PlayerInput> value) { }

	public void remove_onPlayerLeft(Action<PlayerInput> value) { }

	[CompilerGenerated]
	private static void set_instance(PlayerInputManager value) { }

	public void set_joinAction(InputActionProperty value) { }

	public void set_joinBehavior(PlayerJoinBehavior value) { }

	public void set_notificationBehavior(PlayerNotifications value) { }

	public void set_playerPrefab(GameObject value) { }

	public void set_splitScreen(bool value) { }

	private void UpdateSplitScreen() { }

	private void ValidateInputActionAsset() { }

}

