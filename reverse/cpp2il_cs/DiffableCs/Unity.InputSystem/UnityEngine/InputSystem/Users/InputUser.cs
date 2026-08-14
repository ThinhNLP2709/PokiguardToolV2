namespace UnityEngine.InputSystem.Users;

public struct InputUser : IEquatable<InputUser>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static TypedRestore<GlobalState> <>9__88_0; //Field offset: 0x8
		public static Action <>9__88_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <SaveAndResetState>b__88_0(ref GlobalState state) { }

		internal void <SaveAndResetState>b__88_1() { }

	}

	private struct CompareDevicesByUserAccount : IComparer<InputDevice>
	{
		public InputUserAccountHandle platformUserAccountHandle; //Field offset: 0x0

		public override int Compare(InputDevice x, InputDevice y) { }

		private static Nullable<InputUserAccountHandle> GetUserAccountHandleForDevice(InputDevice device) { }

	}

	internal struct ControlSchemeChangeSyntax
	{
		internal int m_UserIndex; //Field offset: 0x0

		public ControlSchemeChangeSyntax AndPairRemainingDevices() { }

	}

	private struct GlobalState
	{
		internal int pairingStateVersion; //Field offset: 0x0
		internal uint lastUserId; //Field offset: 0x4
		internal int allUserCount; //Field offset: 0x8
		internal int allPairedDeviceCount; //Field offset: 0xC
		internal int allLostDeviceCount; //Field offset: 0x10
		internal InputUser[] allUsers; //Field offset: 0x18
		internal UserData[] allUserData; //Field offset: 0x20
		internal InputDevice[] allPairedDevices; //Field offset: 0x28
		internal InputDevice[] allLostDevices; //Field offset: 0x30
		internal InlinedArray<OngoingAccountSelection> ongoingAccountSelections; //Field offset: 0x38
		internal CallbackArray<Action`3<InputUser, InputUserChange, InputDevice>> onChange; //Field offset: 0x58
		internal CallbackArray<Action`2<InputControl, InputEventPtr>> onUnpairedDeviceUsed; //Field offset: 0xA8
		internal CallbackArray<Func`3<InputDevice, InputEventPtr, Boolean>> onPreFilterUnpairedDeviceUsed; //Field offset: 0xF8
		internal Action<Object, InputActionChange> actionChangeDelegate; //Field offset: 0x148
		internal Action<InputDevice, InputDeviceChange> onDeviceChangeDelegate; //Field offset: 0x150
		internal Action<InputEventPtr, InputDevice> onEventDelegate; //Field offset: 0x158
		internal bool onActionChangeHooked; //Field offset: 0x160
		internal bool onDeviceChangeHooked; //Field offset: 0x161
		internal bool onEventHooked; //Field offset: 0x162
		internal int listenForUnpairedDeviceActivity; //Field offset: 0x164

	}

	private struct OngoingAccountSelection
	{
		public InputDevice device; //Field offset: 0x0
		public uint userId; //Field offset: 0x8

	}

	private struct UserData
	{
		public Nullable<InputUserAccountHandle> platformUserAccountHandle; //Field offset: 0x0
		public string platformUserAccountName; //Field offset: 0x18
		public string platformUserAccountId; //Field offset: 0x20
		public int deviceCount; //Field offset: 0x28
		public int deviceStartIndex; //Field offset: 0x2C
		public IInputActionCollection actions; //Field offset: 0x30
		public Nullable<InputControlScheme> controlScheme; //Field offset: 0x38
		public MatchResult controlSchemeMatch; //Field offset: 0x58
		public int lostDeviceCount; //Field offset: 0xA8
		public int lostDeviceStartIndex; //Field offset: 0xAC
		public UserFlags flags; //Field offset: 0xB0

	}

	[Flags]
	public enum UserFlags
	{
		BindToAllDevices = 1,
		UserAccountSelectionInProgress = 2,
	}

	public const uint InvalidId = 0; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputUserOnChangeMarker; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputCheckForUnpairMarker; //Field offset: 0x8
	private static GlobalState s_GlobalState; //Field offset: 0x10
	private uint m_Id; //Field offset: 0x0

	public static event Action<InputUser, InputUserChange, InputDevice> onChange
	{
		 add { } //Length: 185
		 remove { } //Length: 185
	}

	public static event Func<InputDevice, InputEventPtr, Boolean> onPrefilterUnpairedDeviceActivity
	{
		 add { } //Length: 188
		 remove { } //Length: 188
	}

	public static event Action<InputControl, InputEventPtr> onUnpairedDeviceUsed
	{
		 add { } //Length: 238
		 remove { } //Length: 274
	}

	public IInputActionCollection actions
	{
		 get { } //Length: 140
	}

	public static ReadOnlyArray<InputUser> all
	{
		 get { } //Length: 130
	}

	public Nullable<InputControlScheme> controlScheme
	{
		 get { } //Length: 167
	}

	public MatchResult controlSchemeMatch
	{
		 get { } //Length: 206
	}

	public bool hasMissingRequiredDevices
	{
		 get { } //Length: 147
	}

	public uint id
	{
		 get { } //Length: 3
	}

	public int index
	{
		 get { } //Length: 472
	}

	public static int listenForUnpairedDeviceActivity
	{
		 get { } //Length: 81
		 set { } //Length: 328
	}

	public ReadOnlyArray<InputDevice> lostDevices
	{
		 get { } //Length: 204
	}

	public ReadOnlyArray<InputDevice> pairedDevices
	{
		 get { } //Length: 198
	}

	public Nullable<InputUserAccountHandle> platformUserAccountHandle
	{
		 get { } //Length: 169
	}

	public string platformUserAccountId
	{
		 get { } //Length: 140
	}

	public string platformUserAccountName
	{
		 get { } //Length: 140
	}

	public bool valid
	{
		 get { } //Length: 203
	}

	private static InputUser() { }

	public ControlSchemeChangeSyntax ActivateControlScheme(string schemeName) { }

	public ControlSchemeChangeSyntax ActivateControlScheme(InputControlScheme scheme) { }

	private void ActivateControlSchemeInternal(int userIndex, InputControlScheme scheme) { }

	public static void add_onChange(Action<InputUser, InputUserChange, InputDevice> value) { }

	public static void add_onPrefilterUnpairedDeviceActivity(Func<InputDevice, InputEventPtr, Boolean> value) { }

	public static void add_onUnpairedDeviceUsed(Action<InputControl, InputEventPtr> value) { }

	private static void AddDeviceToUser(int userIndex, InputDevice device, bool asLostDevice = false, bool dontUpdateControlScheme = false) { }

	private static int AddUser() { }

	public void AssociateActionsWithUser(IInputActionCollection actions) { }

	public static InputUser CreateUserWithoutPairedDevices() { }

	private static void DisposeAndResetGlobalState() { }

	public override bool Equals(InputUser other) { }

	public virtual bool Equals(object obj) { }

	internal void FindControlScheme(string schemeName, out InputControlScheme scheme) { }

	private static int FindLostDevice(InputDevice device, int startIndex = 0) { }

	public static Nullable<InputUser> FindUserByAccount(InputUserAccountHandle platformUserAccountHandle) { }

	public static Nullable<InputUser> FindUserPairedToDevice(InputDevice device) { }

	public IInputActionCollection get_actions() { }

	public static ReadOnlyArray<InputUser> get_all() { }

	public Nullable<InputControlScheme> get_controlScheme() { }

	public MatchResult get_controlSchemeMatch() { }

	public bool get_hasMissingRequiredDevices() { }

	public uint get_id() { }

	public int get_index() { }

	public static int get_listenForUnpairedDeviceActivity() { }

	public ReadOnlyArray<InputDevice> get_lostDevices() { }

	public ReadOnlyArray<InputDevice> get_pairedDevices() { }

	public Nullable<InputUserAccountHandle> get_platformUserAccountHandle() { }

	public string get_platformUserAccountId() { }

	public string get_platformUserAccountName() { }

	public bool get_valid() { }

	public virtual int GetHashCode() { }

	public static InputControlList<InputDevice> GetUnpairedInputDevices() { }

	public static int GetUnpairedInputDevices(ref InputControlList<InputDevice>& list) { }

	private static void HookIntoActionChange() { }

	private static void HookIntoDeviceChange() { }

	private static void HookIntoEvents() { }

	private static bool InitiateUserAccountSelection(int userIndex, InputDevice device, InputUserPairingOptions options) { }

	private static bool InitiateUserAccountSelectionAtPlatformLevel(InputDevice device) { }

	private static void Notify(int userIndex, InputUserChange change, InputDevice device) { }

	private static void OnActionChange(object obj, InputActionChange change) { }

	private static void OnDeviceChange(InputDevice device, InputDeviceChange change) { }

	private static void OnEvent(InputEventPtr eventPtr, InputDevice device) { }

	public static bool op_Equality(InputUser left, InputUser right) { }

	public static bool op_Inequality(InputUser left, InputUser right) { }

	public static InputUser PerformPairingWithDevice(InputDevice device, InputUser user = null, InputUserPairingOptions options = 0) { }

	private static long QueryPairedPlatformUserAccount(InputDevice device, out Nullable<InputUserAccountHandle>& platformAccountHandle, out string platformAccountName, out string platformAccountId) { }

	public static void remove_onChange(Action<InputUser, InputUserChange, InputDevice> value) { }

	public static void remove_onPrefilterUnpairedDeviceActivity(Func<InputDevice, InputEventPtr, Boolean> value) { }

	public static void remove_onUnpairedDeviceUsed(Action<InputControl, InputEventPtr> value) { }

	private static void RemoveDeviceFromUser(int userIndex, InputDevice device, bool asLostDevice = false) { }

	private static void RemoveLostDevicesForUser(int userIndex) { }

	private static void RemoveUser(int userIndex) { }

	internal static void ResetGlobals() { }

	internal static ISavedState SaveAndResetState() { }

	public static void set_listenForUnpairedDeviceActivity(int value) { }

	public virtual string ToString() { }

	private bool TryFindControlScheme(string schemeName, out InputControlScheme scheme) { }

	private static int TryFindUserIndex(InputDevice device) { }

	private static int TryFindUserIndex(uint userId) { }

	private static int TryFindUserIndex(InputUserAccountHandle platformHandle) { }

	private static void UnhookFromActionChange() { }

	private static void UnhookFromDeviceChange() { }

	private static void UnhookFromDeviceStateChange() { }

	public void UnpairDevice(InputDevice device) { }

	public void UnpairDevices() { }

	public void UnpairDevicesAndRemoveUser() { }

	private static void UpdateControlSchemeMatch(int userIndex, bool autoPairMissing = false) { }

	private static long UpdatePlatformUserAccount(int userIndex, InputDevice device) { }

}

