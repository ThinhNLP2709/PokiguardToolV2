//Type is in global namespace

public class ChatDock : MonoBehaviour
{
	[CompilerGenerated]
	private static ChatDock <Instance>k__BackingField; //Field offset: 0x0
	private const string ButtonPrefabPath = "Prefabs/UI/ChatDockButton"; //Field offset: 0x0
	private const float MentionToastCooldown = 8; //Field offset: 0x0
	private static readonly Vector2 BtnPosHubDefault; //Field offset: 0x8
	private Canvas _canvas; //Field offset: 0x20
	private RectTransform _btnRect; //Field offset: 0x28
	private GameObject _badge; //Field offset: 0x30
	private Text _badgeText; //Field offset: 0x38
	private Vector2 _btnPosHub; //Field offset: 0x40
	private int _unreadWorld; //Field offset: 0x48
	private int _unreadTeam; //Field offset: 0x4C
	private float _lastMentionToastAt; //Field offset: 0x50

	public private static ChatDock Instance
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	private static ChatDock() { }

	public ChatDock() { }

	[CompilerGenerated]
	private void <BuildButton>b__35_0() { }

	private void Awake() { }

	private void BuildButton() { }

	public static GameObject BuildButtonHierarchy(Transform parent) { }

	private void BumpTeamUnread() { }

	public static void Ensure() { }

	[CompilerGenerated]
	public static ChatDock get_Instance() { }

	private void HandleMatchEnter(MatchKind kind) { }

	private void HandleMatchExit(MatchKind kind) { }

	private void HandleRoomExited(string reasonOrRoomId) { }

	private void HandleSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void HandleTeamEmoteIncoming(ChatMessageDTO m) { }

	private void HandleTeamIncoming(ChatMessageDTO m) { }

	private void HandleWorldIncoming(ChatMessageDTO m) { }

	private static bool IsOwnMessage(string username) { }

	private void NoteMention(ChatMessageDTO m, bool viewing) { }

	public static void NotifyTabViewed(bool teamTab) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void RefreshBadge() { }

	private void RefreshVisibilityForScene(string sceneName) { }

	private static void ScrubLegacyChatUI() { }

	[CompilerGenerated]
	private static void set_Instance(ChatDock value) { }

	private static string StripMarkup(string s) { }

}

