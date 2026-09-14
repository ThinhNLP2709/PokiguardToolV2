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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class TeamChatPanel : MonoBehaviour // TypeDefIndex: 565
{
	// Fields
	private const string PREFAB_PATH = "Prefabs/UI/TeamChatPanel"; // Metadata: 0x005EE33C
	private const string PREFAB_PATH_POKY = "Prefabs/UI/TeamChatPanel_Poky"; // Metadata: 0x005EE355
	private const int MaxRows = 50; // Metadata: 0x005EE373
	private const float WindowW = 420f; // Metadata: 0x005EE374
	private const float WindowH = 300f; // Metadata: 0x005EE378
	private const float TrayH = 160f; // Metadata: 0x005EE37C
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
	private const float OpenFxSeconds = 0.16f; // Metadata: 0x005EE380
	private const float OpenFxFromScale = 0.92f; // Metadata: 0x005EE384
	private const float CloseFxSeconds = 0.08f; // Metadata: 0x005EE388
	private const float CloseFxToScale = 0.95f; // Metadata: 0x005EE38C
	private const float TrayFxSeconds = 0.12f; // Metadata: 0x005EE390
	private const float TrayFxFromScaleY = 0.85f; // Metadata: 0x005EE394
	private const float RowFadeSeconds = 0.15f; // Metadata: 0x005EE398
	private const string FLAG_CHAT_IMAGE = "chat.image"; // Metadata: 0x005EE39C
	private bool _sendingImage; // 0x1CC
	private GameObject _btnAttach; // 0x1D0
	private Coroutine _imageEchoWatch; // 0x1D8
	private string _pendingImageId; // 0x1E0
	private static readonly Color DotOnline; // 0x08
	private static readonly Color DotOffline; // 0x18
	private readonly List<DotEntry> _dots; // 0x1E8
	private const int DotPruneThreshold = 120; // Metadata: 0x005EE3A7
	private string _placeholderBackup; // 0x1F0
	private bool _placeholderSwapped; // 0x1F8
	private const float TimeColumnWidth = 38f; // Metadata: 0x005EE3A9
	private const int InputMaxChars = 120; // Metadata: 0x005EE3AD
	private const int ReplyNameMaxChars = 16; // Metadata: 0x005EE3AF
	private const float MentionBgAlpha = 0.12f; // Metadata: 0x005EE3B0
	private const float MentionPulseAlpha = 0.34f; // Metadata: 0x005EE3B4
	private static readonly string[] ReactEmojiIds; // 0x28
	private const float PickerCellSize = 44f; // Metadata: 0x005EE3B8
	private const float PickerCellGap = 4f; // Metadata: 0x005EE3BC
	private const float PickerPad = 5f; // Metadata: 0x005EE3C0
	private const float PickerGapAboveRow = 4f; // Metadata: 0x005EE3C4
	private const float PickerFxSeconds = 0.15f; // Metadata: 0x005EE3C8
	private const float PickerFxFromScale = 0.9f; // Metadata: 0x005EE3CC
	private const float ChipW = 40f; // Metadata: 0x005EE3D0
	private const float ChipH = 22f; // Metadata: 0x005EE3D4
	private const float ChipIconSize = 16f; // Metadata: 0x005EE3D8
	private const float ChipPopFromScale = 1.15f; // Metadata: 0x005EE3DC
	private const float ChipPopSeconds = 0.16f; // Metadata: 0x005EE3E0
	private const int RowPruneThreshold = 240; // Metadata: 0x005EE3E4
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
	public static TeamChatPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803EDEE0-0x00000001803EDF40 0x00000001803EDF40-0x00000001803EDFF0
	public static bool IsViewingTeam { get; } // 0x00000001803EDFF0-0x00000001803EE040 
	public static bool IsViewingWorld { get; } // 0x00000001803EE040-0x00000001803EE090 
	public static bool IsViewingGuild { get; } // 0x00000001803EE090-0x00000001803EE0E0 
	private bool _teamTabActive { get; } // 0x00000001803EE2E0-0x00000001803EE2F0 

	// Nested types
	public enum ChatChannel // TypeDefIndex: 566
	{
		World = 0,
		Team = 1,
		Guild = 2
	}

	private struct DotEntry // TypeDefIndex: 567
	{
		// Fields
		public string User; // 0x00
		public Image Dot; // 0x08
	}

	[Serializable]
	private class ChatImageUploadEnvelope // TypeDefIndex: 568
	{
		// Fields
		public string message; // 0x10
		public ChatImageUploadData data; // 0x18

		// Constructors
		public ChatImageUploadEnvelope(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class ChatImageUploadData // TypeDefIndex: 569
	{
		// Fields
		public string id; // 0x10
		public int w; // 0x18
		public int h; // 0x1C

		// Constructors
		public ChatImageUploadData(); // 0x000000018028A320-0x000000018028A330
	}

	private struct RowEntry // TypeDefIndex: 570
	{
		// Fields
		public long MsgId; // 0x00
		public GameObject Row; // 0x08
		public ChatMessageDTO Dto; // 0x10
		public string Scope; // 0x18
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 571
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__133_1; // 0x08

		// Constructors
		static __c(); // 0x000000018040B990-0x000000018040BA30
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PickAndSendImage_b__133_1(string msg); // 0x000000018040BA30-0x000000018040BA90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 572
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public int w; // 0x18
		public int h; // 0x1C

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UploadAndSend_b__0(string body); // 0x000000018040BA90-0x000000018040BAD0
		internal void _UploadAndSend_b__1(string err); // 0x000000018040BAD0-0x000000018040BBA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 573
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string target; // 0x18

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MakeNameClickable_b__0(); // 0x000000018040BBA0-0x000000018040BBD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 574
	{
		// Fields
		public Image bg; // 0x10

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseMentionBg_b__0(float a); // 0x000000018040BBD0-0x000000018040BD50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 575
	{
		// Fields
		public UnityEngine.UI.Text captured; // 0x10
		public GameObject capturedRow; // 0x18

		// Constructors
		public __c__DisplayClass168_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindRowImage_b__0(); // 0x000000018040BD50-0x000000018040C010
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass205_0 // TypeDefIndex: 576
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public long msgId; // 0x18
		public string id; // 0x20
		public string scope; // 0x28

		// Constructors
		public __c__DisplayClass205_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildChip_b__0(); // 0x000000018040C010-0x000000018040C050
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass211_0 // TypeDefIndex: 577
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string id; // 0x18

		// Constructors
		public __c__DisplayClass211_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildPickerCell_b__0(); // 0x000000018040C050-0x000000018040C090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass222_0 // TypeDefIndex: 578
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass222_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x000000018040C090-0x000000018040C0C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass93_0 // TypeDefIndex: 579
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass93_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindFromHierarchy_b__5(); // 0x000000018040C090-0x000000018040C0C0
	}

	[CompilerGenerated]
	private sealed class _PlaceCaretAtEndNextFrame_d__159 : IEnumerator<object> // TypeDefIndex: 580
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TeamChatPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlaceCaretAtEndNextFrame_d__159(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018040C0C0-0x000000018040C3E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040C3E0-0x000000018040C420
	}

	[CompilerGenerated]
	private sealed class _WatchImageEcho_d__139 : IEnumerator<object> // TypeDefIndex: 581
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TeamChatPanel __4__this; // 0x20
		public string id; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchImageEcho_d__139(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018040C420-0x000000018040C620
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040C620-0x000000018040C660
	}

	// Constructors
	public TeamChatPanel(); // 0x000000018040ABE0-0x000000018040AF10
	static TeamChatPanel(); // 0x000000018040AF10-0x000000018040B140

	// Methods
	private static bool IsViewing(ChatChannel c); // 0x00000001803EE0E0-0x00000001803EE2E0
	private bool ReadFxFlag(); // 0x00000001803EE2F0-0x00000001803EE440
	public static void Toggle(Transform canvasParent); // 0x00000001803EE440-0x00000001803EE8F0
	public static void CloseIfOpen(); // 0x00000001803EE8F0-0x00000001803EEAD0
	public static void SetTeamTabDot(bool on); // 0x00000001803EEAD0-0x00000001803EED70
	public static void SetGuildTabDot(bool on); // 0x00000001803EED70-0x00000001803EF010
	private static TeamChatPanel CreateUnder(Transform canvasParent); // 0x00000001803EF010-0x00000001803EF340
	private void Awake(); // 0x00000001803EF340-0x00000001803EFA70
	private void ApplyFxGate(); // 0x00000001803EFA70-0x00000001803EFC10
	private void BindFromHierarchy(); // 0x00000001803EFC10-0x00000001803F24F0
	private static void EnsureScrollRaycast(ScrollRect scroll); // 0x00000001803F24F0-0x00000001803F26E0
	private static void Rewire(Transform node, UnityAction action); // 0x00000001803F26E0-0x00000001803F2950
	private void OnEnable(); // 0x00000001803F2950-0x00000001803F3000
	private void OnDisable(); // 0x00000001803F3000-0x00000001803F3800
	private void OnDestroy(); // 0x00000001803F3800-0x00000001803F39B0
	private void OnOpened(); // 0x00000001803F39B0-0x00000001803F3A90
	private void RequestPresenceSnapshot(); // 0x00000001803F3A90-0x00000001803F3BA0
	private void HandlePresenceChanged(); // 0x00000001803F3BA0-0x00000001803F3BB0
	private void RegisterDot(string username, Image dot); // 0x00000001803F3BB0-0x00000001803F3F70
	private void RefreshAllDots(); // 0x00000001803F3F70-0x00000001803F4160
	private void PruneDots(); // 0x00000001803F4160-0x00000001803F4300
	private static void ApplyDotColor(Image dot, string username); // 0x00000001803F4300-0x00000001803F4580
	private void PlayOpenFx(); // 0x00000001803F4580-0x00000001803F4910
	private void BeginClose(); // 0x00000001803F4910-0x00000001803F4E10
	private void FinishClose(); // 0x00000001803F4E10-0x00000001803F4EB0
	private void CancelCloseFx(); // 0x00000001803F4EB0-0x00000001803F5080
	private void RestoreWindowFx(); // 0x00000001803F5080-0x00000001803F52F0
	private CanvasGroup EnsureWindowGroup(); // 0x00000001803F52F0-0x00000001803F55A0
	private static bool IsInRoom(); // 0x0000000180387160-0x0000000180387190
	private void HandleRoomEntered(string roomId); // 0x00000001803F55A0-0x00000001803F55C0
	private void HandleRoomExited(string reasonOrRoomId); // 0x00000001803F55C0-0x00000001803F5670
	private void RefreshTeamTabVisibility(); // 0x00000001803F5670-0x00000001803F5930
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x00000001803F5930-0x00000001803F59F0
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803F59F0-0x00000001803F5AD0
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803F5AD0-0x00000001803F5BE0
	private void HandleWorldMessage(ChatMessageDTO m); // 0x00000001803F5BE0-0x00000001803F5E00
	private void HandleConnectionChanged(bool connected); // 0x00000001803F5E00-0x00000001803F5EE0
	private void HandleGuildMessage(ChatMessageDTO m); // 0x00000001803F5EE0-0x00000001803F6080
	private void RebuildFromHistory(); // 0x00000001803F6080-0x00000001803F60B0
	private void RebuildGuild(); // 0x00000001803F60B0-0x00000001803F6530
	private void RebuildTeam(); // 0x00000001803F6530-0x00000001803F6A10
	private void RebuildWorld(); // 0x00000001803F6A10-0x00000001803F6F60
	private static void ClearChildren(Transform t); // 0x00000001803F6F60-0x00000001803F7290
	private void SendCurrent(); // 0x00000001803F7290-0x00000001803F77D0
	private void SendEmote(string emojiId); // 0x00000001803F77D0-0x00000001803F7A30
	private Transform EnsureAttachButton(); // 0x00000001803F7A30-0x00000001803F8B70
	private void ApplyAttachVisibility(); // 0x00000001803F8B70-0x00000001803F8D80
	private static string ChatText(string prop, string fallback); // 0x00000001803F8D80-0x00000001803F8E20
	private static float ThumbPx(); // 0x00000001803F8E20-0x00000001803F8F90
	private void PickAndSendImage(); // 0x00000001803F8F90-0x00000001803F92E0
	private void UploadAndSend(byte[] jpeg, int w, int h); // 0x00000001803F92E0-0x00000001803F95C0
	private void SetImageSendingState(bool sending); // 0x00000001803F95C0-0x00000001803F9BD0
	private void OnUploadDone(string body, int w, int h); // 0x00000001803F9BD0-0x00000001803FA1B0
	[IteratorStateMachine(typeof(_WatchImageEcho_d__139))]
	private IEnumerator WatchImageEcho(string id); // 0x00000001803FA1B0-0x00000001803FA2C0
	private void NoteImageEcho(ChatMessageDTO m); // 0x00000001803FA2C0-0x00000001803FA380
	private static string UploadErrorText(string err); // 0x00000001803FA380-0x00000001803FABE0
	private void SelectTab(bool team); // 0x00000001803FABE0-0x00000001803FAC00
	private void SelectChannel(ChatChannel channel); // 0x00000001803FAC00-0x00000001803FB390
	private ScrollRect ScrollOf(ChatChannel c); // 0x00000001803FB390-0x00000001803FB3B0
	private bool GuildChannelOn(); // 0x00000001803FB3B0-0x00000001803FB430
	private void ApplyTabVisual(Image img, UnityEngine.UI.Text label, GameObject selectedNode, Sprite baseSprite, Color baseImgColor, Color baseLabelColor, bool selected); // 0x00000001803FB430-0x00000001803FBA70
	private static Color Dim(Color c, float f); // 0x00000001803FBA70-0x00000001803FBAA0
	private static string FormatChatTime(string ts, bool fallbackNow); // 0x00000001803FBAA0-0x00000001803FBD20
	private static string ReplyPrefix(string username); // 0x00000001803FBD20-0x00000001803FBD80
	private void MakeNameClickable(UnityEngine.UI.Text nameText, string username); // 0x00000001803FBD80-0x00000001803FC240
	private void BeginReply(string username); // 0x00000001803FC240-0x00000001803FCBA0
	[IteratorStateMachine(typeof(_PlaceCaretAtEndNextFrame_d__159))]
	private IEnumerator PlaceCaretAtEndNextFrame(); // 0x00000001803FCBA0-0x00000001803FCC40
	private void CancelReply(bool stripPrefix); // 0x00000001803FCC40-0x00000001803FD180
	private static string ShortName(string s); // 0x00000001803FD180-0x00000001803FD250
	private void EnsureReplyChip(); // 0x00000001803FD250-0x00000001803FDCF0
	public static bool MentionsMe(string message); // 0x00000001803FDCF0-0x00000001803FDF30
	private static void PulseMentionBg(GameObject owner, Image bg); // 0x00000001803FDF30-0x00000001803FE210
	private void AppendRow(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803FE210-0x00000001803FED20
	private static void TrimRows(Transform content); // 0x00000001803FED20-0x00000001803FEFE0
	private void AppendRowFromTemplate(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803FEFE0-0x00000001803FFF80
	private void BindRowImage(GameObject row, UnityEngine.UI.Text txtMsg, ChatMessageDTO dto); // 0x00000001803FFF80-0x00000001804004C0
	private static void BindRowImageTapOwner(GameObject row); // 0x00000001804004C0-0x0000000180400820
	private void PlayRowFadeIn(GameObject row); // 0x0000000180400820-0x0000000180400AC0
	private static bool IsOwnMessage(string username); // 0x0000000180400AC0-0x0000000180400C90
	private static void ScrollToBottom(ScrollRect scroll); // 0x0000000180400C90-0x0000000180400E40
	private string ScopeOf(Transform content); // 0x0000000180400E40-0x0000000180401180
	private void AttachReact(GameObject row, ChatMessageDTO dto, Transform content); // 0x0000000180401180-0x00000001804018E0
	private static void EnsureRowRaycast(GameObject row); // 0x00000001804018E0-0x0000000180401A40
	private void PruneRows(); // 0x0000000180401A40-0x0000000180401BF0
	private void HandleChatReact(ChatMessageDTO dto); // 0x0000000180401BF0-0x0000000180401E90
	private void RefreshRowChips(GameObject row, ChatMessageDTO dto, string scope, bool pulse); // 0x0000000180401E90-0x0000000180402420
	private Transform EnsureChipsContainer(GameObject row); // 0x0000000180402420-0x00000001804027E0
	private GameObject BuildChip(Transform parent, string emojiId, int count, bool mine, long msgId, string scope); // 0x00000001804027E0-0x00000001804032B0
	private static Sprite FirstFrameOf(string emojiId); // 0x00000001804032B0-0x0000000180403330
	private void PopChip(GameObject chip); // 0x0000000180403330-0x00000001804035E0
	private void SendReact(long msgId, string emojiId, string scope); // 0x00000001804035E0-0x0000000180403930
	private void OpenReactPicker(ChatRowLongPress source); // 0x0000000180403930-0x0000000180403CD0
	private void EnsureReactPicker(); // 0x0000000180403CD0-0x0000000180404970
	private void BuildPickerCell(Transform parent, string emojiId); // 0x0000000180404970-0x0000000180405120
	private void PositionPickerAbove(RectTransform rowRect); // 0x0000000180405120-0x0000000180405770
	private Camera PickerCamera(); // 0x0000000180405770-0x00000001804059F0
	private void PlayPickerFx(); // 0x00000001804059F0-0x0000000180405CD0
	private void CloseReactPicker(); // 0x0000000180405CD0-0x00000001804060D0
	private void BuildRuntimeUI(); // 0x00000001804060D0-0x00000001804081D0
	private void ToggleEmojiTray(); // 0x00000001804081D0-0x0000000180408380
	private void ShowEmojiTray(); // 0x0000000180408380-0x0000000180408780
	private void HideEmojiTray(); // 0x0000000180408780-0x0000000180408980
	private void RestoreTrayFx(); // 0x0000000180408980-0x0000000180408C00
	private CanvasGroup EnsureTrayGroup(); // 0x0000000180408C00-0x0000000180408E90
	private void BuildEmojiTray(Transform windowT); // 0x0000000180408E90-0x0000000180409C60
	private Image CreateTab(Transform parent, string name, string label, Vector2 pos, out UnityEngine.UI.Text labelText); // 0x0000000180409C60-0x000000018040A130
	private ScrollRect CreateScroll(Transform parent, string name); // 0x000000018040A130-0x000000018040A810
	private UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color); // 0x000000018040A810-0x000000018040AB20
	private static void StretchFull(RectTransform rect, float padX = 0f /* Metadata: 0x005EE334 */, float padY = 0f /* Metadata: 0x005EE338 */); // 0x000000018040AB20-0x000000018040ABE0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_0(); // 0x000000018040B140-0x000000018040B150
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_1(); // 0x000000018040B150-0x000000018040B160
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_2(); // 0x000000018040B160-0x000000018040B170
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_3(string _); // 0x000000018040B170-0x000000018040B1F0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_4(); // 0x000000018040B1F0-0x000000018040B200
	[CompilerGenerated]
	private void _PickAndSendImage_b__133_0(byte[] bytes, int w, int h); // 0x000000018040B200-0x000000018040B210
	[CompilerGenerated]
	private void _EnsureReplyChip_b__162_0(); // 0x000000018040B1F0-0x000000018040B200
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_0(); // 0x000000018040B210-0x000000018040B230
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_1(); // 0x000000018040B230-0x000000018040B250
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_2(string _); // 0x000000018040B250-0x000000018040B3F0
}

