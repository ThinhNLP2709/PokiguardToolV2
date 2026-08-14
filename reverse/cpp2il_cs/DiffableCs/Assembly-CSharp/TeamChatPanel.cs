//Type is in global namespace

public class TeamChatPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public string id; //Field offset: 0x10
		public TeamChatPanel <>4__this; //Field offset: 0x18

		public <>c__DisplayClass51_0() { }

		internal void <BindFromHierarchy>b__5() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass81_0
	{
		public TeamChatPanel <>4__this; //Field offset: 0x10
		public string target; //Field offset: 0x18

		public <>c__DisplayClass81_0() { }

		internal void <MakeNameClickable>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass88_0
	{
		public Image bg; //Field offset: 0x10

		public <>c__DisplayClass88_0() { }

		internal void <PulseMentionBg>b__0(float a) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass95_0
	{
		public string id; //Field offset: 0x10
		public TeamChatPanel <>4__this; //Field offset: 0x18

		public <>c__DisplayClass95_0() { }

		internal void <BuildEmojiTray>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <PlaceCaretAtEndNextFrame>d__83 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TeamChatPanel <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <PlaceCaretAtEndNextFrame>d__83(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const string PREFAB_PATH = "Prefabs/UI/TeamChatPanel"; //Field offset: 0x0
	private const int ReplyNameMaxChars = 16; //Field offset: 0x0
	private const int InputMaxChars = 120; //Field offset: 0x0
	private const float TimeColumnWidth = 38; //Field offset: 0x0
	private const float MentionBgAlpha = 0.12; //Field offset: 0x0
	private const float MentionPulseAlpha = 0.34; //Field offset: 0x0
	private const float WindowH = 300; //Field offset: 0x0
	private const float WindowW = 420; //Field offset: 0x0
	private const int MaxRows = 50; //Field offset: 0x0
	private const float TrayH = 160; //Field offset: 0x0
	[CompilerGenerated]
	private static TeamChatPanel <Instance>k__BackingField; //Field offset: 0x0
	private RectTransform _window; //Field offset: 0x20
	private Transform _contentTeam; //Field offset: 0x28
	private Transform _contentWorld; //Field offset: 0x30
	private ScrollRect _scrollTeam; //Field offset: 0x38
	private ScrollRect _scrollWorld; //Field offset: 0x40
	private InputField _input; //Field offset: 0x48
	private GameObject _emojiTray; //Field offset: 0x50
	private GameObject _tabTeamGO; //Field offset: 0x58
	private Image _tabTeamImg; //Field offset: 0x60
	private Image _tabWorldImg; //Field offset: 0x68
	private Text _tabTeamLabel; //Field offset: 0x70
	private Text _tabWorldLabel; //Field offset: 0x78
	private GameObject _tabTeamDot; //Field offset: 0x80
	private bool _teamTabActive; //Field offset: 0x88
	[Header("Tab chọn/không chọn (tuỳ chọn — để trống thì giữ nguyên art trong prefab)")]
	[SerializeField]
	[Tooltip("Sprite tab ĐANG chọn. Chỉ dùng khi tab KHÔNG có node con 'selected'.")]
	private Sprite tabSpriteActive; //Field offset: 0x90
	[SerializeField]
	[Tooltip("Sprite tab KHÔNG chọn. Chỉ dùng khi tab KHÔNG có node con 'selected'.")]
	private Sprite tabSpriteInactive; //Field offset: 0x98
	private GameObject _tabTeamSelectedNode; //Field offset: 0xA0
	private GameObject _tabWorldSelectedNode; //Field offset: 0xA8
	private Sprite _tabTeamBaseSprite; //Field offset: 0xB0
	private Sprite _tabWorldBaseSprite; //Field offset: 0xB8
	private Color _tabTeamBaseImgColor; //Field offset: 0xC0
	private Color _tabWorldBaseImgColor; //Field offset: 0xD0
	private Color _tabTeamBaseLabelColor; //Field offset: 0xE0
	private Color _tabWorldBaseLabelColor; //Field offset: 0xF0
	private GameObject _rowTemplate; //Field offset: 0x100
	private string _replyTarget; //Field offset: 0x108
	private GameObject _replyChipGO; //Field offset: 0x110
	private Text _replyChipText; //Field offset: 0x118
	private Vector3 _replyChipBaseScale; //Field offset: 0x120
	private Coroutine _caretCoroutine; //Field offset: 0x130
	private bool _isRebuilding; //Field offset: 0x138
	private Font _fontName; //Field offset: 0x140
	private Font _fontBody; //Field offset: 0x148

	public private static TeamChatPanel Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public static bool IsViewingTeam
	{
		 get { } //Length: 273
	}

	public static bool IsViewingWorld
	{
		 get { } //Length: 276
	}

	public TeamChatPanel() { }

	[CompilerGenerated]
	private void <BindFromHierarchy>b__51_0() { }

	[CompilerGenerated]
	private void <BindFromHierarchy>b__51_1() { }

	[CompilerGenerated]
	private void <BindFromHierarchy>b__51_2() { }

	[CompilerGenerated]
	private void <BindFromHierarchy>b__51_3(string _) { }

	[CompilerGenerated]
	private void <BindFromHierarchy>b__51_4() { }

	[CompilerGenerated]
	private void <BuildRuntimeUI>b__93_0() { }

	[CompilerGenerated]
	private void <BuildRuntimeUI>b__93_1() { }

	[CompilerGenerated]
	private void <BuildRuntimeUI>b__93_2() { }

	[CompilerGenerated]
	private void <BuildRuntimeUI>b__93_3(string _) { }

	[CompilerGenerated]
	private void <EnsureReplyChip>b__86_0() { }

	private void AppendRow(Transform content, string username, string message, string emojiId, string timeText) { }

	private void AppendRowFromTemplate(Transform content, string username, string message, string emojiId, string timeText) { }

	private void ApplyTabVisual(Image img, Text label, GameObject selectedNode, Sprite baseSprite, Color baseImgColor, Color baseLabelColor, bool selected) { }

	private void Awake() { }

	private void BeginReply(string username) { }

	private void BindFromHierarchy() { }

	private void BuildEmojiTray(Transform windowT) { }

	private void BuildRuntimeUI() { }

	private void CancelReply(bool stripPrefix) { }

	private static void ClearChildren(Transform t) { }

	public static void CloseIfOpen() { }

	private ScrollRect CreateScroll(Transform parent, string name) { }

	private Image CreateTab(Transform parent, string name, string label, Vector2 pos, out Text labelText) { }

	private Text CreateText(Transform parent, string name, string content, Font font, int size, Color color) { }

	private static TeamChatPanel CreateUnder(Transform canvasParent) { }

	private static Color Dim(Color c, float f) { }

	private void EnsureReplyChip() { }

	private static string FormatChatTime(string ts, bool fallbackNow) { }

	[CompilerGenerated]
	public static TeamChatPanel get_Instance() { }

	public static bool get_IsViewingTeam() { }

	public static bool get_IsViewingWorld() { }

	private void HandleConnectionChanged(bool connected) { }

	private void HandleRoomEntered(string roomId) { }

	private void HandleRoomExited(string reasonOrRoomId) { }

	private void HandleTeamEmote(ChatMessageDTO m) { }

	private void HandleTeamMessage(ChatMessageDTO m) { }

	private void HandleWorldMessage(ChatMessageDTO m) { }

	private static bool IsInRoom() { }

	private void MakeNameClickable(Text nameText, string username) { }

	public static bool MentionsMe(string message) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnOpened() { }

	[IteratorStateMachine(typeof(<PlaceCaretAtEndNextFrame>d__83))]
	private IEnumerator PlaceCaretAtEndNextFrame() { }

	private static void PulseMentionBg(GameObject owner, Image bg) { }

	private void RebuildFromHistory() { }

	private void RebuildTeam() { }

	private void RebuildWorld() { }

	private void RefreshTeamTabVisibility() { }

	private static string ReplyPrefix(string username) { }

	private static void Rewire(Transform node, UnityAction action) { }

	private static void ScrollToBottom(ScrollRect scroll) { }

	private void SelectTab(bool team) { }

	private void SendCurrent() { }

	private void SendEmote(string emojiId) { }

	[CompilerGenerated]
	private static void set_Instance(TeamChatPanel value) { }

	public static void SetTeamTabDot(bool on) { }

	private static string ShortName(string s) { }

	private static void StretchFull(RectTransform rect, float padX = 0, float padY = 0) { }

	public static void Toggle(Transform canvasParent) { }

	private void ToggleEmojiTray() { }

	private static void TrimRows(Transform content) { }

}

