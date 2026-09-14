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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TeamChatPanel : MonoBehaviour // TypeDefIndex: 566
{
	// Fields
	private const string PREFAB_PATH = "Prefabs/UI/TeamChatPanel"; // Metadata: 0x005EF70D
	private const string PREFAB_PATH_POKY = "Prefabs/UI/TeamChatPanel_Poky"; // Metadata: 0x005EF726
	private const int MaxRows = 50; // Metadata: 0x005EF744
	private const float WindowW = 420f; // Metadata: 0x005EF745
	private const float WindowH = 300f; // Metadata: 0x005EF749
	private const float TrayH = 160f; // Metadata: 0x005EF74D
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
	private const float OpenFxSeconds = 0.16f; // Metadata: 0x005EF751
	private const float OpenFxFromScale = 0.92f; // Metadata: 0x005EF755
	private const float CloseFxSeconds = 0.08f; // Metadata: 0x005EF759
	private const float CloseFxToScale = 0.95f; // Metadata: 0x005EF75D
	private const float TrayFxSeconds = 0.12f; // Metadata: 0x005EF761
	private const float TrayFxFromScaleY = 0.85f; // Metadata: 0x005EF765
	private const float RowFadeSeconds = 0.15f; // Metadata: 0x005EF769
	private const string FLAG_CHAT_IMAGE = "chat.image"; // Metadata: 0x005EF76D
	private bool _sendingImage; // 0x1CC
	private GameObject _btnAttach; // 0x1D0
	private Coroutine _imageEchoWatch; // 0x1D8
	private string _pendingImageId; // 0x1E0
	private static readonly Color DotOnline; // 0x08
	private static readonly Color DotOffline; // 0x18
	private readonly List<DotEntry> _dots; // 0x1E8
	private const int DotPruneThreshold = 120; // Metadata: 0x005EF778
	private string _placeholderBackup; // 0x1F0
	private bool _placeholderSwapped; // 0x1F8
	private const float TimeColumnWidth = 38f; // Metadata: 0x005EF77A
	private const int InputMaxChars = 120; // Metadata: 0x005EF77E
	private const int ReplyNameMaxChars = 16; // Metadata: 0x005EF780
	private const float MentionBgAlpha = 0.12f; // Metadata: 0x005EF781
	private const float MentionPulseAlpha = 0.34f; // Metadata: 0x005EF785
	private static readonly string[] ReactEmojiIds; // 0x28
	private const float PickerCellSize = 44f; // Metadata: 0x005EF789
	private const float PickerCellGap = 4f; // Metadata: 0x005EF78D
	private const float PickerPad = 5f; // Metadata: 0x005EF791
	private const float PickerGapAboveRow = 4f; // Metadata: 0x005EF795
	private const float PickerFxSeconds = 0.15f; // Metadata: 0x005EF799
	private const float PickerFxFromScale = 0.9f; // Metadata: 0x005EF79D
	private const float ChipW = 40f; // Metadata: 0x005EF7A1
	private const float ChipH = 22f; // Metadata: 0x005EF7A5
	private const float ChipIconSize = 16f; // Metadata: 0x005EF7A9
	private const float ChipPopFromScale = 1.15f; // Metadata: 0x005EF7AD
	private const float ChipPopSeconds = 0.16f; // Metadata: 0x005EF7B1
	private const int RowPruneThreshold = 240; // Metadata: 0x005EF7B5
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
	public static TeamChatPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803EEC20-0x00000001803EEC80 0x00000001803EEC80-0x00000001803EED30
	public static bool IsViewingTeam { get; } // 0x00000001803EED30-0x00000001803EED80 
	public static bool IsViewingWorld { get; } // 0x00000001803EED80-0x00000001803EEDD0 
	public static bool IsViewingGuild { get; } // 0x00000001803EEDD0-0x00000001803EEE20 
	private bool _teamTabActive { get; } // 0x00000001803EF020-0x00000001803EF030 

	// Nested types
	public enum ChatChannel // TypeDefIndex: 567
	{
		World = 0,
		Team = 1,
		Guild = 2
	}

	private struct DotEntry // TypeDefIndex: 568
	{
		// Fields
		public string User; // 0x00
		public Image Dot; // 0x08
	}

	[Serializable]
	private class ChatImageUploadEnvelope // TypeDefIndex: 569
	{
		// Fields
		public string message; // 0x10
		public ChatImageUploadData data; // 0x18

		// Constructors
		public ChatImageUploadEnvelope(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class ChatImageUploadData // TypeDefIndex: 570
	{
		// Fields
		public string id; // 0x10
		public int w; // 0x18
		public int h; // 0x1C

		// Constructors
		public ChatImageUploadData(); // 0x000000018028A320-0x000000018028A330
	}

	private struct RowEntry // TypeDefIndex: 571
	{
		// Fields
		public long MsgId; // 0x00
		public GameObject Row; // 0x08
		public ChatMessageDTO Dto; // 0x10
		public string Scope; // 0x18
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 572
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__133_1; // 0x08

		// Constructors
		static __c(); // 0x000000018040C6F0-0x000000018040C790
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PickAndSendImage_b__133_1(string msg); // 0x000000018040C790-0x000000018040C7F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass134_0 // TypeDefIndex: 573
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public int w; // 0x18
		public int h; // 0x1C

		// Constructors
		public __c__DisplayClass134_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UploadAndSend_b__0(string body); // 0x000000018040C7F0-0x000000018040C830
		internal void _UploadAndSend_b__1(string err); // 0x000000018040C830-0x000000018040C900
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 574
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string target; // 0x18

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MakeNameClickable_b__0(); // 0x000000018040C900-0x000000018040C930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass164_0 // TypeDefIndex: 575
	{
		// Fields
		public Image bg; // 0x10

		// Constructors
		public __c__DisplayClass164_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseMentionBg_b__0(float a); // 0x000000018040C930-0x000000018040CAB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 576
	{
		// Fields
		public UnityEngine.UI.Text captured; // 0x10
		public GameObject capturedRow; // 0x18

		// Constructors
		public __c__DisplayClass168_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindRowImage_b__0(); // 0x000000018040CAB0-0x000000018040CD70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass205_0 // TypeDefIndex: 577
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public long msgId; // 0x18
		public string id; // 0x20
		public string scope; // 0x28

		// Constructors
		public __c__DisplayClass205_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildChip_b__0(); // 0x000000018040CD70-0x000000018040CDB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass211_0 // TypeDefIndex: 578
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string id; // 0x18

		// Constructors
		public __c__DisplayClass211_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildPickerCell_b__0(); // 0x000000018040CDB0-0x000000018040CDF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass222_0 // TypeDefIndex: 579
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass222_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x000000018040CDF0-0x000000018040CE20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass93_0 // TypeDefIndex: 580
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass93_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindFromHierarchy_b__5(); // 0x000000018040CDF0-0x000000018040CE20
	}

	[CompilerGenerated]
	private sealed class _PlaceCaretAtEndNextFrame_d__159 : IEnumerator<object> // TypeDefIndex: 581
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018040CE20-0x000000018040D140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040D140-0x000000018040D180
	}

	[CompilerGenerated]
	private sealed class _WatchImageEcho_d__139 : IEnumerator<object> // TypeDefIndex: 582
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018040D180-0x000000018040D380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040D380-0x000000018040D3C0
	}

	// Constructors
	public TeamChatPanel(); // 0x000000018040B940-0x000000018040BC70
	static TeamChatPanel(); // 0x000000018040BC70-0x000000018040BEA0

	// Methods
	private static bool IsViewing(ChatChannel c); // 0x00000001803EEE20-0x00000001803EF020
	private bool ReadFxFlag(); // 0x00000001803EF030-0x00000001803EF180
	public static void Toggle(Transform canvasParent); // 0x00000001803EF180-0x00000001803EF630
	public static void CloseIfOpen(); // 0x00000001803EF630-0x00000001803EF810
	public static void SetTeamTabDot(bool on); // 0x00000001803EF810-0x00000001803EFAB0
	public static void SetGuildTabDot(bool on); // 0x00000001803EFAB0-0x00000001803EFD50
	private static TeamChatPanel CreateUnder(Transform canvasParent); // 0x00000001803EFD50-0x00000001803F0080
	private void Awake(); // 0x00000001803F0080-0x00000001803F07B0
	private void ApplyFxGate(); // 0x00000001803F07B0-0x00000001803F0950
	private void BindFromHierarchy(); // 0x00000001803F0950-0x00000001803F3230
	private static void EnsureScrollRaycast(ScrollRect scroll); // 0x00000001803F3230-0x00000001803F3420
	private static void Rewire(Transform node, UnityAction action); // 0x00000001803F3420-0x00000001803F3690
	private void OnEnable(); // 0x00000001803F3690-0x00000001803F3D40
	private void OnDisable(); // 0x00000001803F3D40-0x00000001803F4540
	private void OnDestroy(); // 0x00000001803F4540-0x00000001803F46F0
	private void OnOpened(); // 0x00000001803F46F0-0x00000001803F47D0
	private void RequestPresenceSnapshot(); // 0x00000001803F47D0-0x00000001803F48E0
	private void HandlePresenceChanged(); // 0x00000001803F48E0-0x00000001803F48F0
	private void RegisterDot(string username, Image dot); // 0x00000001803F48F0-0x00000001803F4CB0
	private void RefreshAllDots(); // 0x00000001803F4CB0-0x00000001803F4EA0
	private void PruneDots(); // 0x00000001803F4EA0-0x00000001803F5040
	private static void ApplyDotColor(Image dot, string username); // 0x00000001803F5040-0x00000001803F52C0
	private void PlayOpenFx(); // 0x00000001803F52C0-0x00000001803F5650
	private void BeginClose(); // 0x00000001803F5650-0x00000001803F5B50
	private void FinishClose(); // 0x00000001803F5B50-0x00000001803F5BF0
	private void CancelCloseFx(); // 0x00000001803F5BF0-0x00000001803F5DC0
	private void RestoreWindowFx(); // 0x00000001803F5DC0-0x00000001803F6030
	private CanvasGroup EnsureWindowGroup(); // 0x00000001803F6030-0x00000001803F62E0
	private static bool IsInRoom(); // 0x0000000180387310-0x0000000180387340
	private void HandleRoomEntered(string roomId); // 0x00000001803F62E0-0x00000001803F6300
	private void HandleRoomExited(string reasonOrRoomId); // 0x00000001803F6300-0x00000001803F63B0
	private void RefreshTeamTabVisibility(); // 0x00000001803F63B0-0x00000001803F6670
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x00000001803F6670-0x00000001803F6730
	private void HandleTeamMessage(ChatMessageDTO m); // 0x00000001803F6730-0x00000001803F6810
	private void HandleTeamEmote(ChatMessageDTO m); // 0x00000001803F6810-0x00000001803F6920
	private void HandleWorldMessage(ChatMessageDTO m); // 0x00000001803F6920-0x00000001803F6B40
	private void HandleConnectionChanged(bool connected); // 0x00000001803F6B40-0x00000001803F6C20
	private void HandleGuildMessage(ChatMessageDTO m); // 0x00000001803F6C20-0x00000001803F6DC0
	private void RebuildFromHistory(); // 0x00000001803F6DC0-0x00000001803F6DF0
	private void RebuildGuild(); // 0x00000001803F6DF0-0x00000001803F7270
	private void RebuildTeam(); // 0x00000001803F7270-0x00000001803F7750
	private void RebuildWorld(); // 0x00000001803F7750-0x00000001803F7CA0
	private static void ClearChildren(Transform t); // 0x00000001803F7CA0-0x00000001803F7FD0
	private void SendCurrent(); // 0x00000001803F7FD0-0x00000001803F8510
	private void SendEmote(string emojiId); // 0x00000001803F8510-0x00000001803F8770
	private Transform EnsureAttachButton(); // 0x00000001803F8770-0x00000001803F98B0
	private void ApplyAttachVisibility(); // 0x00000001803F98B0-0x00000001803F9AC0
	private static string ChatText(string prop, string fallback); // 0x00000001803F9AC0-0x00000001803F9B60
	private static float ThumbPx(); // 0x00000001803F9B60-0x00000001803F9CD0
	private void PickAndSendImage(); // 0x00000001803F9CD0-0x00000001803FA020
	private void UploadAndSend(byte[] jpeg, int w, int h); // 0x00000001803FA020-0x00000001803FA320
	private void SetImageSendingState(bool sending); // 0x00000001803FA320-0x00000001803FA930
	private void OnUploadDone(string body, int w, int h); // 0x00000001803FA930-0x00000001803FAF10
	[IteratorStateMachine(typeof(_WatchImageEcho_d__139))]
	private IEnumerator WatchImageEcho(string id); // 0x00000001803FAF10-0x00000001803FB020
	private void NoteImageEcho(ChatMessageDTO m); // 0x00000001803FB020-0x00000001803FB0E0
	private static string UploadErrorText(string err); // 0x00000001803FB0E0-0x00000001803FB940
	private void SelectTab(bool team); // 0x00000001803FB940-0x00000001803FB960
	private void SelectChannel(ChatChannel channel); // 0x00000001803FB960-0x00000001803FC0F0
	private ScrollRect ScrollOf(ChatChannel c); // 0x00000001803FC0F0-0x00000001803FC110
	private bool GuildChannelOn(); // 0x00000001803FC110-0x00000001803FC190
	private void ApplyTabVisual(Image img, UnityEngine.UI.Text label, GameObject selectedNode, Sprite baseSprite, Color baseImgColor, Color baseLabelColor, bool selected); // 0x00000001803FC190-0x00000001803FC7D0
	private static Color Dim(Color c, float f); // 0x00000001803FC7D0-0x00000001803FC800
	private static string FormatChatTime(string ts, bool fallbackNow); // 0x00000001803FC800-0x00000001803FCA80
	private static string ReplyPrefix(string username); // 0x00000001803FCA80-0x00000001803FCAE0
	private void MakeNameClickable(UnityEngine.UI.Text nameText, string username); // 0x00000001803FCAE0-0x00000001803FCFA0
	private void BeginReply(string username); // 0x00000001803FCFA0-0x00000001803FD900
	[IteratorStateMachine(typeof(_PlaceCaretAtEndNextFrame_d__159))]
	private IEnumerator PlaceCaretAtEndNextFrame(); // 0x00000001803FD900-0x00000001803FD9A0
	private void CancelReply(bool stripPrefix); // 0x00000001803FD9A0-0x00000001803FDEE0
	private static string ShortName(string s); // 0x00000001803FDEE0-0x00000001803FDFB0
	private void EnsureReplyChip(); // 0x00000001803FDFB0-0x00000001803FEA50
	public static bool MentionsMe(string message); // 0x00000001803FEA50-0x00000001803FEC90
	private static void PulseMentionBg(GameObject owner, Image bg); // 0x00000001803FEC90-0x00000001803FEF70
	private void AppendRow(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803FEF70-0x00000001803FFA80
	private static void TrimRows(Transform content); // 0x00000001803FFA80-0x00000001803FFD40
	private void AppendRowFromTemplate(Transform content, string username, string message, string emojiId, string timeText, ChatMessageDTO dto); // 0x00000001803FFD40-0x0000000180400CE0
	private void BindRowImage(GameObject row, UnityEngine.UI.Text txtMsg, ChatMessageDTO dto); // 0x0000000180400CE0-0x0000000180401220
	private static void BindRowImageTapOwner(GameObject row); // 0x0000000180401220-0x0000000180401580
	private void PlayRowFadeIn(GameObject row); // 0x0000000180401580-0x0000000180401820
	private static bool IsOwnMessage(string username); // 0x0000000180401820-0x00000001804019F0
	private static void ScrollToBottom(ScrollRect scroll); // 0x00000001804019F0-0x0000000180401BA0
	private string ScopeOf(Transform content); // 0x0000000180401BA0-0x0000000180401EE0
	private void AttachReact(GameObject row, ChatMessageDTO dto, Transform content); // 0x0000000180401EE0-0x0000000180402640
	private static void EnsureRowRaycast(GameObject row); // 0x0000000180402640-0x00000001804027A0
	private void PruneRows(); // 0x00000001804027A0-0x0000000180402950
	private void HandleChatReact(ChatMessageDTO dto); // 0x0000000180402950-0x0000000180402BF0
	private void RefreshRowChips(GameObject row, ChatMessageDTO dto, string scope, bool pulse); // 0x0000000180402BF0-0x0000000180403180
	private Transform EnsureChipsContainer(GameObject row); // 0x0000000180403180-0x0000000180403540
	private GameObject BuildChip(Transform parent, string emojiId, int count, bool mine, long msgId, string scope); // 0x0000000180403540-0x0000000180404010
	private static Sprite FirstFrameOf(string emojiId); // 0x0000000180404010-0x0000000180404090
	private void PopChip(GameObject chip); // 0x0000000180404090-0x0000000180404340
	private void SendReact(long msgId, string emojiId, string scope); // 0x0000000180404340-0x0000000180404690
	private void OpenReactPicker(ChatRowLongPress source); // 0x0000000180404690-0x0000000180404A30
	private void EnsureReactPicker(); // 0x0000000180404A30-0x00000001804056D0
	private void BuildPickerCell(Transform parent, string emojiId); // 0x00000001804056D0-0x0000000180405E80
	private void PositionPickerAbove(RectTransform rowRect); // 0x0000000180405E80-0x00000001804064D0
	private Camera PickerCamera(); // 0x00000001804064D0-0x0000000180406750
	private void PlayPickerFx(); // 0x0000000180406750-0x0000000180406A30
	private void CloseReactPicker(); // 0x0000000180406A30-0x0000000180406E30
	private void BuildRuntimeUI(); // 0x0000000180406E30-0x0000000180408F30
	private void ToggleEmojiTray(); // 0x0000000180408F30-0x00000001804090E0
	private void ShowEmojiTray(); // 0x00000001804090E0-0x00000001804094E0
	private void HideEmojiTray(); // 0x00000001804094E0-0x00000001804096E0
	private void RestoreTrayFx(); // 0x00000001804096E0-0x0000000180409960
	private CanvasGroup EnsureTrayGroup(); // 0x0000000180409960-0x0000000180409BF0
	private void BuildEmojiTray(Transform windowT); // 0x0000000180409BF0-0x000000018040A9C0
	private Image CreateTab(Transform parent, string name, string label, Vector2 pos, out UnityEngine.UI.Text labelText); // 0x000000018040A9C0-0x000000018040AE90
	private ScrollRect CreateScroll(Transform parent, string name); // 0x000000018040AE90-0x000000018040B570
	private UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color); // 0x000000018040B570-0x000000018040B880
	private static void StretchFull(RectTransform rect, float padX = 0f /* Metadata: 0x005EF705 */, float padY = 0f /* Metadata: 0x005EF709 */); // 0x000000018040B880-0x000000018040B940
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_0(); // 0x000000018040BEA0-0x000000018040BEB0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_1(); // 0x000000018040BEB0-0x000000018040BEC0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_2(); // 0x000000018040BEC0-0x000000018040BED0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_3(string _); // 0x000000018040BED0-0x000000018040BF50
	[CompilerGenerated]
	private void _BindFromHierarchy_b__93_4(); // 0x000000018040BF50-0x000000018040BF60
	[CompilerGenerated]
	private void _PickAndSendImage_b__133_0(byte[] bytes, int w, int h); // 0x000000018040BF60-0x000000018040BF70
	[CompilerGenerated]
	private void _EnsureReplyChip_b__162_0(); // 0x000000018040BF50-0x000000018040BF60
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_0(); // 0x000000018040BF70-0x000000018040BF90
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_1(); // 0x000000018040BF90-0x000000018040BFB0
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__216_2(string _); // 0x000000018040BFB0-0x000000018040C150
}

