/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TeamChatPanel : MonoBehaviour // TypeDefIndex: 512
{
	// Fields
	private const string PREFAB_PATH = "Prefabs/UI/TeamChatPanel"; // Metadata: 0x0068B453
	private const string PREFAB_PATH_POKY = "Prefabs/UI/TeamChatPanel_Poky"; // Metadata: 0x0068B46C
	private const int MaxRows = 50; // Metadata: 0x0068B48A
	private const float WindowW = 420f; // Metadata: 0x0068B48B
	private const float WindowH = 300f; // Metadata: 0x0068B48F
	private const float TrayH = 160f; // Metadata: 0x0068B493
	[CompilerGenerated]
	private static TeamChatPanel _Instance_k__BackingField; // 0x00
	private RectTransform _window; // 0x20
	private Transform _contentTeam; // 0x28
	private Transform _contentWorld; // 0x30
	private Transform _contentGuild; // 0x38
	private ScrollRect _scrollTeam; // 0x40
	private ScrollRect _scrollWorld; // 0x48
	private ScrollRect _scrollGuild; // 0x50
	private InputField _input; // 0x58
	private GameObject _emojiTray; // 0x60
	private GameObject _tabTeamGO; // 0x68
	private GameObject _tabGuildGO; // 0x70
	private Image _tabTeamImg; // 0x78
	private Image _tabWorldImg; // 0x80
	private Image _tabGuildImg; // 0x88
	private UnityEngine.UI.Text _tabTeamLabel; // 0x90
	private UnityEngine.UI.Text _tabWorldLabel; // 0x98
	private UnityEngine.UI.Text _tabGuildLabel; // 0xA0
	private GameObject _tabTeamDot; // 0xA8
	private GameObject _tabGuildDot; // 0xB0
	private ChatChannel _channel; // 0xB8
	private bool _guildChannelAvailable; // 0xBC
	[Header("Tab ch\u1ECDn/kh\u00F4ng ch\u1ECDn (tu\u1EF3 ch\u1ECDn \u2014 \u0111\u1EC3 tr\u1ED1ng th\u00EC gi\u1EEF nguy\u00EAn art trong prefab)")]
	[SerializeField]
	[Tooltip("Sprite tab \u0110ANG ch\u1ECDn. Ch\u1EC9 d\u00F9ng khi tab KH\u00D4NG c\u00F3 node con \'selected\'.")]
	private Sprite tabSpriteActive; // 0xC0
	[SerializeField]
	[Tooltip("Sprite tab KH\u00D4NG ch\u1ECDn. Ch\u1EC9 d\u00F9ng khi tab KH\u00D4NG c\u00F3 node con \'selected\'.")]
	private Sprite tabSpriteInactive; // 0xC8
	private GameObject _tabTeamSelectedNode; // 0xD0
	private GameObject _tabWorldSelectedNode; // 0xD8
	private GameObject _tabGuildSelectedNode; // 0xE0
	private Sprite _tabTeamBaseSprite; // 0xE8
	private Sprite _tabWorldBaseSprite; // 0xF0
	private Sprite _tabGuildBaseSprite; // 0xF8
	private Color _tabTeamBaseImgColor; // 0x100
	private Color _tabWorldBaseImgColor; // 0x110
	private Color _tabGuildBaseImgColor; // 0x120
	private Color _tabTeamBaseLabelColor; // 0x130
	private Color _tabWorldBaseLabelColor; // 0x140
	private Color _tabGuildBaseLabelColor; // 0x150
	private GameObject _rowTemplate; // 0x160
	private string _replyTarget; // 0x168
	private GameObject _replyChipGO; // 0x170
	private UnityEngine.UI.Text _replyChipText; // 0x178
	private Vector3 _replyChipBaseScale; // 0x180
	private Coroutine _caretCoroutine; // 0x190
	private bool _isRebuilding; // 0x198
	private Font _fontName; // 0x1A0
	private Font _fontBody; // 0x1A8
	private bool _fxOn; // 0x1B0
	private bool _closing; // 0x1B1
	private Vector3 _windowBaseScale; // 0x1B4
	private Vector3 _trayBaseScale; // 0x1C0
	private const float OpenFxSeconds = 0.16f; // Metadata: 0x0068B497
	private const float OpenFxFromScale = 0.92f; // Metadata: 0x0068B49B
	private const float CloseFxSeconds = 0.08f; // Metadata: 0x0068B49F
	private const float CloseFxToScale = 0.95f; // Metadata: 0x0068B4A3
	private const float TrayFxSeconds = 0.12f; // Metadata: 0x0068B4A7
	private const float TrayFxFromScaleY = 0.85f; // Metadata: 0x0068B4AB
	private const float RowFadeSeconds = 0.15f; // Metadata: 0x0068B4AF
	private const string FLAG_CHAT_IMAGE = "chat.image"; // Metadata: 0x0068B4B3
	private bool _sendingImage; // 0x1CC
	private GameObject _btnAttach; // 0x1D0
	private Coroutine _imageEchoWatch; // 0x1D8
	private string _pendingImageId; // 0x1E0
	private static readonly Color DotOnline; // 0x08
	private static readonly Color DotOffline; // 0x18
	private readonly List<DotEntry> _dots; // 0x1E8
	private const int DotPruneThreshold = 120; // Metadata: 0x0068B4BE
	private string _placeholderBackup; // 0x1F0
	private bool _placeholderSwapped; // 0x1F8
	private const float TimeColumnWidth = 38f; // Metadata: 0x0068B4C0
	private const int InputMaxChars = 120; // Metadata: 0x0068B4C4
	private const int ReplyNameMaxChars = 16; // Metadata: 0x0068B4C6
	private const float MentionBgAlpha = 0.12f; // Metadata: 0x0068B4C7
	private const float MentionPulseAlpha = 0.34f; // Metadata: 0x0068B4CB
	private static readonly string[] ReactEmojiIds; // 0x28
	private const float PickerCellSize = 44f; // Metadata: 0x0068B4CF
	private const float PickerCellGap = 4f; // Metadata: 0x0068B4D3
	private const float PickerPad = 5f; // Metadata: 0x0068B4D7
	private const float PickerGapAboveRow = 4f; // Metadata: 0x0068B4DB
	private const float PickerFxSeconds = 0.15f; // Metadata: 0x0068B4DF
	private const float PickerFxFromScale = 0.9f; // Metadata: 0x0068B4E3
	private const float ChipW = 40f; // Metadata: 0x0068B4E7
	private const float ChipH = 22f; // Metadata: 0x0068B4EB
	private const float ChipIconSize = 16f; // Metadata: 0x0068B4EF
	private const float ChipPopFromScale = 1.15f; // Metadata: 0x0068B4F3
	private const float ChipPopSeconds = 0.16f; // Metadata: 0x0068B4F7
	private const int RowPruneThreshold = 240; // Metadata: 0x0068B4FB
	private static readonly Color ChipBgColor; // 0x30
	private static readonly Color ChipBgMineColor; // 0x40
	private static readonly Color ChipCountColor; // 0x50
	private static readonly Color CyanAccent; // 0x60
	private readonly List<RowEntry> _rowsById; // 0x200
	private GameObject _reactPicker; // 0x208
	private RectTransform _reactPickerRect; // 0x210
	private RectTransform _reactPickerBar; // 0x218
	private Vector3 _reactPickerBarBaseScale; // 0x220
	private long _pickerMsgId; // 0x230
	private string _pickerScope; // 0x238

	// Properties
	public static TeamChatPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BC580-0x00000001803BC5D0 0x00000001803BC6D0-0x00000001803BC740
	public static bool IsViewingTeam { get; } // 0x00000001803BC620-0x00000001803BC670 
	public static bool IsViewingWorld { get; } // 0x00000001803BC670-0x00000001803BC6C0 
	public static bool IsViewingGuild { get; } // 0x00000001803BC5D0-0x00000001803BC620 
	private bool _teamTabActive { get; } // 0x00000001803BC6C0-0x00000001803BC6D0 

	// Nested types
	public enum ChatChannel // TypeDefIndex: 513
	{
		World = 0,
		Team = 1,
		Guild = 2
	}

	private struct DotEntry // TypeDefIndex: 514
	{
		// Fields
		public string User; // 0x00
		public Image Dot; // 0x08
	}

	[Serializable]
	private class ChatImageUploadEnvelope // TypeDefIndex: 515
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public ChatImageUploadData data; // 0x20

		// Constructors
		public ChatImageUploadEnvelope(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	private class ChatImageUploadData // TypeDefIndex: 516
	{
		// Fields
		public string id; // 0x10
		public int w; // 0x18
		public int h; // 0x1C
		public long expiresAt; // 0x20

		// Constructors
		public ChatImageUploadData(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	private struct RowEntry // TypeDefIndex: 517
	{
		// Fields
		public long MsgId; // 0x00
		public GameObject Row; // 0x08
		public ChatMessageDTO Dto; // 0x10
		public string Scope; // 0x18
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 518
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__133_1; // 0x08

		// Constructors
		static __c(); // 0x00000001803D4C90-0x00000001803D4D00
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PickAndSendImage_b__133_1(string msg); // 0x00000001803D4810-0x00000001803D4870
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 519
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public int w; // 0x18
		public int h; // 0x1C

		// Constructors
		public __c__DisplayClass134_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UploadAndSend_b__0(string body); // 0x00000001803D4870-0x00000001803D48B0
		internal void _UploadAndSend_b__1(string err); // 0x00000001803D48B0-0x00000001803D4970
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 520
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string target; // 0x18

		// Constructors
		public __c__DisplayClass157_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _MakeNameClickable_b__0(); // 0x00000001803D4970-0x00000001803D49A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 521
	{
		// Fields
		public Image bg; // 0x10

		// Constructors
		public __c__DisplayClass164_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseMentionBg_b__0(float a); // 0x00000001803D49A0-0x00000001803D4A90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 522
	{
		// Fields
		public UnityEngine.UI.Text captured; // 0x10
		public GameObject capturedRow; // 0x18

		// Constructors
		public __c__DisplayClass168_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BindRowImage_b__0(); // 0x00000001803D4A90-0x00000001803D4BE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass205_0 // TypeDefIndex: 523
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public long msgId; // 0x18
		public string id; // 0x20
		public string scope; // 0x28

		// Constructors
		public __c__DisplayClass205_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildChip_b__0(); // 0x00000001803D4BE0-0x00000001803D4C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass211_0 // TypeDefIndex: 524
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string id; // 0x18

		// Constructors
		public __c__DisplayClass211_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildPickerCell_b__0(); // 0x00000001803D4C20-0x00000001803D4C60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass222_0 // TypeDefIndex: 525
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass222_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x00000001803D4C60-0x00000001803D4C90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass93_0 // TypeDefIndex: 526
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass93_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BindFromHierarchy_b__5(); // 0x00000001803D4C60-0x00000001803D4C90
	}

	[CompilerGenerated]
	private sealed class _PlaceCaretAtEndNextFrame_d__159 : IEnumerator<object> // TypeDefIndex: 527
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TeamChatPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlaceCaretAtEndNextFrame_d__159(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803D3970-0x00000001803D3B10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D3B10-0x00000001803D3B50
	}

	[CompilerGenerated]
	private sealed class _WatchImageEcho_d__139 : IEnumerator<object> // TypeDefIndex: 528
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TeamChatPanel __4__this; // 0x20
		public string id; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchImageEcho_d__139(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803D4D00-0x00000001803D4E40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D4E40-0x00000001803D4E80
	}

	// Constructors
	public TeamChatPanel(); // 0x00000001803BC3E0-0x00000001803BC580
	static TeamChatPanel(); // 0x00000001803BC1E0-0x00000001803BC3E0

	// Methods
	private static bool IsViewing(ChatChannel c); // 0x00000001803B5EE0-0x00000001803B6080
	private bool ReadFxFlag(); // 0x00000001803B89A0-0x00000001803B8A50
	public static void Toggle(Transform canvasParent); // 0x00000001803BB670-0x00000001803BBB40
	public static void CloseIfOpen(); // 0x00000001803B27C0-0x00000001803B2950
	public static void SetTeamTabDot(bool on); // 0x00000001803BAE60-0x00000001803BB020
	public static void SetGuildTabDot(bool on); // 0x00000001803BA8E0-0x00000001803BAAA0
	private static TeamChatPanel CreateUnder(Transform canvasParent); // 0x00000001803B33A0-0x00000001803B3530
	private void Awake(); // 0x00000001803ACA40-0x00000001803ACD60
	private void ApplyFxGate(); // 0x00000001803AC150-0x00000001803AC250
	private void BindFromHierarchy(); // 0x00000001803AD5B0-0x00000001803AEDA0
	private static void EnsureScrollRaycast(ScrollRect scroll); // 0x00000001803B4E40-0x00000001803B4F30
	private static void Rewire(Transform node, UnityAction action); // 0x00000001803B9DF0-0x00000001803B9F20
	private void OnEnable(); // 0x00000001803B6B40-0x00000001803B6EF0
	private void OnDisable(); // 0x00000001803B6720-0x00000001803B6B40
	private void OnDestroy(); // 0x00000001803B65F0-0x00000001803B6720
	private void OnOpened(); // 0x00000001803B6EF0-0x00000001803B6FC0
	private void RequestPresenceSnapshot(); // 0x00000001803B9B10-0x00000001803B9C10
	private void HandlePresenceChanged(); // 0x00000001803B57D0-0x00000001803B5920
	private void RegisterDot(string username, Image dot); // 0x00000001803B9890-0x00000001803B9AC0
	private void RefreshAllDots(); // 0x00000001803B57D0-0x00000001803B5920
	private void PruneDots(); // 0x00000001803B8640-0x00000001803B8720
	private static void ApplyDotColor(Image dot, string username); // 0x00000001803ABFB0-0x00000001803AC150
	private void PlayOpenFx(); // 0x00000001803B7AC0-0x00000001803B7CC0
	private void BeginClose(); // 0x00000001803ACD60-0x00000001803AD010
	private void FinishClose(); // 0x00000001803B5130-0x00000001803B5190
	private void CancelCloseFx(); // 0x00000001803B22C0-0x00000001803B23B0
	private void RestoreWindowFx(); // 0x00000001803B9D10-0x00000001803B9DF0
	private CanvasGroup EnsureWindowGroup(); // 0x00000001803B5020-0x00000001803B5130
	private static bool IsInRoom(); // 0x0000000180367480-0x00000001803674B0
	private void HandleRoomEntered(string roomId); // 0x00000001803B5920-0x00000001803B5940
	private void HandleRoomExited(string reasonOrRoomId); // 0x00000001803B5940-0x00000001803B59C0
	private void RefreshTeamTabVisibility(); // 0x00000001803B9790-0x00000001803B9890
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x00000001803B5630-0x00000001803B56C0
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803B5AC0-0x00000001803B5BA0
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803B59C0-0x00000001803B5AC0
	private void HandleWorldMessage(ChatMessageDTO m); // 0x00000001803B5BA0-0x00000001803B5D50
	private void HandleConnectionChanged(bool connected); // 0x00000001803B55A0-0x00000001803B5630
	private void HandleGuildMessage(ChatMessageDTO m); // 0x00000001803B56C0-0x00000001803B57D0
	private void RebuildFromHistory(); // 0x00000001803B8A50-0x00000001803B8A80
	private void RebuildGuild(); // 0x00000001803B8A80-0x00000001803B8DB0
	private void RebuildTeam(); // 0x00000001803B8DB0-0x00000001803B9100
	private void RebuildWorld(); // 0x00000001803B9100-0x00000001803B9480
	private static void ClearChildren(Transform t); // 0x00000001803B26F0-0x00000001803B27C0
	private void SendCurrent(); // 0x00000001803BA4C0-0x00000001803BA640
	private void SendEmote(string emojiId); // 0x00000001803BA640-0x00000001803BA7B0
	private Transform EnsureAttachButton(); // 0x00000001803B3560-0x00000001803B3D80
	private void ApplyAttachVisibility(); // 0x00000001803ABEC0-0x00000001803ABFB0
	private static string ChatText(string prop, string fallback); // 0x00000001803B2650-0x00000001803B26F0
	private static float ThumbPx(); // 0x00000001803BB4A0-0x00000001803BB5A0
	private void PickAndSendImage(); // 0x00000001803B76C0-0x00000001803B7950
	private void UploadAndSend(byte[] jpeg, int w, int h); // 0x00000001803BBD50-0x00000001803BBF40
	private void SetImageSendingState(bool sending); // 0x00000001803BAAA0-0x00000001803BAE60
	private void OnUploadDone(string body, int w, int h); // 0x00000001803B6FC0-0x00000001803B73A0
	[IteratorStateMachine(typeof(_WatchImageEcho_d__139))]
	private IEnumerator WatchImageEcho(string id); // 0x00000001803BC150-0x00000001803BC1E0
	private void NoteImageEcho(ChatMessageDTO m); // 0x00000001803B6550-0x00000001803B65F0
	private static string UploadErrorText(string err); // 0x00000001803BBF40-0x00000001803BC150
	private void SelectTab(bool team); // 0x00000001803BA4A0-0x00000001803BA4C0
	private void SelectChannel(ChatChannel channel); // 0x00000001803BA100-0x00000001803BA4A0
	private ScrollRect ScrollOf(ChatChannel c); // 0x00000001803BA020-0x00000001803BA040
	private bool GuildChannelOn(); // 0x00000001803B53B0-0x00000001803B53D0
	private void ApplyTabVisual(Image img, UnityEngine.UI.Text label, GameObject selectedNode, Sprite baseSprite, Color baseImgColor, Color baseLabelColor, bool selected); // 0x00000001803AC250-0x00000001803AC4F0
	private static Color Dim(Color c, float f); // 0x00000001803B3530-0x00000001803B3560
	private static string FormatChatTime(string ts, bool fallbackNow); // 0x00000001803B5200-0x00000001803B53B0
	private static string ReplyPrefix(string username); // 0x00000001803B9AC0-0x00000001803B9B10
	private void MakeNameClickable(UnityEngine.UI.Text nameText, string username); // 0x00000001803B6080-0x00000001803B6390
	private void BeginReply(string username); // 0x00000001803AD010-0x00000001803AD5B0
	[IteratorStateMachine(typeof(_PlaceCaretAtEndNextFrame_d__159))]
	private IEnumerator PlaceCaretAtEndNextFrame(); // 0x00000001803B7A50-0x00000001803B7AC0
	private void CancelReply(bool stripPrefix); // 0x00000001803B23B0-0x00000001803B2650
	private static string ShortName(string s); // 0x00000001803BB020-0x00000001803BB100
	private void EnsureReplyChip(); // 0x00000001803B46C0-0x00000001803B4D70
	public static bool MentionsMe(string message); // 0x00000001803B6390-0x00000001803B6550
	private static void PulseMentionBg(GameObject owner, Image bg); // 0x00000001803B8800-0x00000001803B89A0
	private void AppendRow(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803AB520-0x00000001803ABEC0
	private static void TrimRows(Transform content); // 0x00000001803BBB40-0x00000001803BBBF0
	private void AppendRowFromTemplate(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803AACF0-0x00000001803AB520
	private void BindRowImage(GameObject row, UnityEngine.UI.Text txtMsg, ChatMessageDTO dto); // 0x00000001803AEEE0-0x00000001803AF2B0
	private static void BindRowImageTapOwner(GameObject row); // 0x00000001803AEDA0-0x00000001803AEEE0
	private void PlayRowFadeIn(GameObject row); // 0x00000001803B7E60-0x00000001803B7FD0
	private static bool IsOwnMessage(string username); // 0x00000001803B5E20-0x00000001803B5EE0
	private static void ScrollToBottom(ScrollRect scroll); // 0x00000001803BA040-0x00000001803BA100
	private string ScopeOf(Transform content); // 0x00000001803B9F20-0x00000001803BA020
	private void AttachReact(GameObject row, ChatMessageDTO dto, Transform content); // 0x00000001803AC4F0-0x00000001803ACA40
	private static void EnsureRowRaycast(GameObject row); // 0x00000001803B4D70-0x00000001803B4E40
	private void PruneRows(); // 0x00000001803B8720-0x00000001803B8800
	private void HandleChatReact(ChatMessageDTO dto); // 0x00000001803B53D0-0x00000001803B55A0
	private void RefreshRowChips(GameObject row, ChatMessageDTO dto, string scope, bool pulse); // 0x00000001803B9480-0x00000001803B9790
	private Transform EnsureChipsContainer(GameObject row); // 0x00000001803B3D80-0x00000001803B3FA0
	private GameObject BuildChip(Transform parent, string emojiId, int count, bool mine, long msgId, string scope); // 0x00000001803AF2B0-0x00000001803AFA40
	private static Sprite FirstFrameOf(string emojiId); // 0x00000001803B5190-0x00000001803B5200
	private void PopChip(GameObject chip); // 0x00000001803B7FD0-0x00000001803B8170
	private void SendReact(long msgId, string emojiId, string scope); // 0x00000001803BA7B0-0x00000001803BA8E0
	private void OpenReactPicker(ChatRowLongPress source); // 0x00000001803B73A0-0x00000001803B76C0
	private void EnsureReactPicker(); // 0x00000001803B3FA0-0x00000001803B46C0
	private void BuildPickerCell(Transform parent, string emojiId); // 0x00000001803B02D0-0x00000001803B0890
	private void PositionPickerAbove(RectTransform rowRect); // 0x00000001803B8170-0x00000001803B8640
	private Camera PickerCamera(); // 0x00000001803B7950-0x00000001803B7A50
	private void PlayPickerFx(); // 0x00000001803B7CC0-0x00000001803B7E60
	private void CloseReactPicker(); // 0x00000001803B2950-0x00000001803B2AC0
	private void BuildRuntimeUI(); // 0x00000001803B0890-0x00000001803B22C0
	private void ToggleEmojiTray(); // 0x00000001803BB5A0-0x00000001803BB670
	private void ShowEmojiTray(); // 0x00000001803BB100-0x00000001803BB3E0
	private void HideEmojiTray(); // 0x00000001803B5D50-0x00000001803B5E20
	private void RestoreTrayFx(); // 0x00000001803B9C10-0x00000001803B9D10
	private CanvasGroup EnsureTrayGroup(); // 0x00000001803B4F30-0x00000001803B5020
	private void BuildEmojiTray(Transform windowT); // 0x00000001803AFA40-0x00000001803B02D0
	private Image CreateTab(Transform parent, string name, string label, Vector2 pos, out UnityEngine.UI.Text labelText); // 0x00000001803B2E80-0x00000001803B3210
	private ScrollRect CreateScroll(Transform parent, string name); // 0x00000001803B2AC0-0x00000001803B2E80
	private UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color); // 0x00000001803B3210-0x00000001803B33A0
	private static void StretchFull(RectTransform rect, float padX = 0f /* Metadata: 0x0068B44B */, float padY = 0f /* Metadata: 0x0068B44F */); // 0x00000001803BB3E0-0x00000001803BB4A0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_0(); // 0x00000001803BBBF0-0x00000001803BBC00
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_1(); // 0x00000001803BBC00-0x00000001803BBC10
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_2(); // 0x00000001803BBC10-0x00000001803BBC20
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_3(string _); // 0x00000001803BBC20-0x00000001803BBC90
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_4(); // 0x00000001803BBC90-0x00000001803BBCA0
	[CompilerGenerated]
	private void _PickAndSendImage_b__133_0(byte[] bytes, int w, int h); // 0x00000001803BBD50-0x00000001803BBF40
	[CompilerGenerated]
	private void _EnsureReplyChip_b__162_0(); // 0x00000001803BBC90-0x00000001803BBCA0
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_0(); // 0x00000001803BBCA0-0x00000001803BBCC0
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_1(); // 0x00000001803BBCC0-0x00000001803BBCE0
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_2(string _); // 0x00000001803BBCE0-0x00000001803BBD50
}

