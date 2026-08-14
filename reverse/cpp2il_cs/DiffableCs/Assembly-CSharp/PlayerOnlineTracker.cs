//Type is in global namespace

public class PlayerOnlineTracker : MonoBehaviour
{
	[CompilerGenerated]
	private static PlayerOnlineTracker <Instance>k__BackingField; //Field offset: 0x0
	internal string myUsername; //Field offset: 0x20
	internal bool manualBusy; //Field offset: 0x28

	public bool InAnyMatch
	{
		 get { } //Length: 33
	}

	public bool InMatchScene
	{
		 get { } //Length: 7
	}

	public bool InPVPScene
	{
		 get { } //Length: 7
	}

	internal static PlayerOnlineTracker Instance
	{
		[CompilerGenerated]
		internal get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public PlayerOnlineTracker() { }

	private void Awake() { }

	public bool get_InAnyMatch() { }

	public bool get_InMatchScene() { }

	public bool get_InPVPScene() { }

	[CompilerGenerated]
	internal static PlayerOnlineTracker get_Instance() { }

	public static int GetInviteListBusyState() { }

	private void HandlePause() { }

	private void HandleResume() { }

	public void Logout() { }

	private void OnApplicationQuit() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnMatchHostEnterExit(MatchKind kind) { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void ResetReturnToRoomFlags() { }

	[CompilerGenerated]
	private static void set_Instance(PlayerOnlineTracker value) { }

	public void SetManualBusy(bool busy) { }

	public void SetUsernameAndGoOnline(string username) { }

	private void SyncBusyToChat() { }

	private void TryReportOffline() { }

}

