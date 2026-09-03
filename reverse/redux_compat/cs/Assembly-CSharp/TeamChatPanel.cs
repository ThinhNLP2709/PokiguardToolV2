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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TeamChatPanel : MonoBehaviour // TypeDefIndex: 443
{
	// Fields
	private const string PREFAB_PATH = "Prefabs/UI/TeamChatPanel"; // Metadata: 0x0064C3DA
	private const string PREFAB_PATH_POKY = "Prefabs/UI/TeamChatPanel_Poky"; // Metadata: 0x0064C3F3
	private const int MaxRows = 50; // Metadata: 0x0064C411
	private const float WindowW = 420f; // Metadata: 0x0064C412
	private const float WindowH = 300f; // Metadata: 0x0064C416
	private const float TrayH = 160f; // Metadata: 0x0064C41A
	[CompilerGenerated]
	private static TeamChatPanel _Instance_k__BackingField; // 0x00
	private RectTransform _window; // 0x20
	private Transform _contentTeam; // 0x28
	private Transform _contentWorld; // 0x30
	private ScrollRect _scrollTeam; // 0x38
	private ScrollRect _scrollWorld; // 0x40
	private InputField _input; // 0x48
	private GameObject _emojiTray; // 0x50
	private GameObject _tabTeamGO; // 0x58
	private Image _tabTeamImg; // 0x60
	private Image _tabWorldImg; // 0x68
	private UnityEngine.UI.Text _tabTeamLabel; // 0x70
	private UnityEngine.UI.Text _tabWorldLabel; // 0x78
	private GameObject _tabTeamDot; // 0x80
	private bool _teamTabActive; // 0x88
	[Header("Tab ch\u1ECDn/kh\u00F4ng ch\u1ECDn (tu\u1EF3 ch\u1ECDn \u2014 \u0111\u1EC3 tr\u1ED1ng th\u00EC gi\u1EEF nguy\u00EAn art trong prefab)")]
	[SerializeField]
	[Tooltip("Sprite tab \u0110ANG ch\u1ECDn. Ch\u1EC9 d\u00F9ng khi tab KH\u00D4NG c\u00F3 node con \'selected\'.")]
	private Sprite tabSpriteActive; // 0x90
	[SerializeField]
	[Tooltip("Sprite tab KH\u00D4NG ch\u1ECDn. Ch\u1EC9 d\u00F9ng khi tab KH\u00D4NG c\u00F3 node con \'selected\'.")]
	private Sprite tabSpriteInactive; // 0x98
	private GameObject _tabTeamSelectedNode; // 0xA0
	private GameObject _tabWorldSelectedNode; // 0xA8
	private Sprite _tabTeamBaseSprite; // 0xB0
	private Sprite _tabWorldBaseSprite; // 0xB8
	private Color _tabTeamBaseImgColor; // 0xC0
	private Color _tabWorldBaseImgColor; // 0xD0
	private Color _tabTeamBaseLabelColor; // 0xE0
	private Color _tabWorldBaseLabelColor; // 0xF0
	private GameObject _rowTemplate; // 0x100
	private string _replyTarget; // 0x108
	private GameObject _replyChipGO; // 0x110
	private UnityEngine.UI.Text _replyChipText; // 0x118
	private Vector3 _replyChipBaseScale; // 0x120
	private Coroutine _caretCoroutine; // 0x130
	private bool _isRebuilding; // 0x138
	private Font _fontName; // 0x140
	private Font _fontBody; // 0x148
	private const float TimeColumnWidth = 38f; // Metadata: 0x0064C41E
	private const int InputMaxChars = 120; // Metadata: 0x0064C422
	private const int ReplyNameMaxChars = 16; // Metadata: 0x0064C424
	private const float MentionBgAlpha = 0.12f; // Metadata: 0x0064C425
	private const float MentionPulseAlpha = 0.34f; // Metadata: 0x0064C429

	// Properties
	public static TeamChatPanel Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180354860-0x00000001803548A0 0x0000000180354AE0-0x0000000180354B40
	public static bool IsViewingTeam { get; } // 0x00000001803548A0-0x00000001803549C0 
	public static bool IsViewingWorld { get; } // 0x00000001803549C0-0x0000000180354AE0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 444
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BindFromHierarchy_b__5(); // 0x000000018035BDF0-0x000000018035BE20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass82_0 // TypeDefIndex: 445
	{
		// Fields
		public TeamChatPanel __4__this; // 0x10
		public string target; // 0x18

		// Constructors
		public __c__DisplayClass82_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _MakeNameClickable_b__0(); // 0x000000018035BE20-0x000000018035BE50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass89_0 // TypeDefIndex: 446
	{
		// Fields
		public Image bg; // 0x10

		// Constructors
		public __c__DisplayClass89_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PulseMentionBg_b__0(float a); // 0x000000018035BE50-0x000000018035BF40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 447
	{
		// Fields
		public string id; // 0x10
		public TeamChatPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass96_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x000000018035BDF0-0x000000018035BE20
	}

	[CompilerGenerated]
	private sealed class _PlaceCaretAtEndNextFrame_d__84 : IEnumerator<object> // TypeDefIndex: 448
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TeamChatPanel __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlaceCaretAtEndNextFrame_d__84(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180356D10-0x0000000180356EB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180356EB0-0x0000000180356EF0
	}

	// Constructors
	public TeamChatPanel(); // 0x0000000180354800-0x0000000180354860

	// Methods
	public static void Toggle(Transform canvasParent); // 0x0000000180354210-0x0000000180354610
	public static void CloseIfOpen(); // 0x0000000180350BC0-0x0000000180350CF0
	public static void SetTeamTabDot(bool on); // 0x0000000180353E50-0x0000000180353FC0
	private static TeamChatPanel CreateUnder(Transform canvasParent); // 0x00000001803515B0-0x0000000180351740
	private void Awake(); // 0x000000018034CC60-0x000000018034CE70
	private void BindFromHierarchy(); // 0x000000018034D3D0-0x000000018034E5F0
	private static void Rewire(Transform node, UnityAction action); // 0x0000000180353780-0x00000001803538B0
	private void OnEnable(); // 0x0000000180352BA0-0x0000000180352E30
	private void OnDisable(); // 0x00000001803528D0-0x0000000180352BA0
	private void OnDestroy(); // 0x0000000180352800-0x00000001803528D0
	private void OnOpened(); // 0x0000000180352E30-0x0000000180352E90
	private static bool IsInRoom(); // 0x0000000180318620-0x0000000180318650
	private void HandleRoomEntered(string roomId); // 0x0000000180351FF0-0x0000000180352010
	private void HandleRoomExited(string reasonOrRoomId); // 0x0000000180352010-0x0000000180352090
	private void RefreshTeamTabVisibility(); // 0x0000000180353690-0x0000000180353730
	private void HandleTeamMessage(ChatMessageDTO m); // 0x0000000180352160-0x00000001803521E0
	private void HandleTeamEmote(ChatMessageDTO m); // 0x0000000180352090-0x0000000180352160
	private void HandleWorldMessage(ChatMessageDTO m); // 0x00000001803521E0-0x0000000180352330
	private void HandleConnectionChanged(bool connected); // 0x0000000180351FB0-0x0000000180351FF0
	private void RebuildFromHistory(); // 0x00000001803530A0-0x00000001803530C0
	private void RebuildTeam(); // 0x00000001803530C0-0x0000000180353390
	private void RebuildWorld(); // 0x0000000180353390-0x0000000180353690
	private static void ClearChildren(Transform t); // 0x0000000180350AF0-0x0000000180350BC0
	private void SendCurrent(); // 0x0000000180353BB0-0x0000000180353D10
	private void SendEmote(string emojiId); // 0x0000000180353D10-0x0000000180353E50
	private void SelectTab(bool team); // 0x0000000180353970-0x0000000180353BB0
	private void ApplyTabVisual(Image img, UnityEngine.UI.Text label, GameObject selectedNode, Sprite baseSprite, Color baseImgColor, Color baseLabelColor, bool selected); // 0x000000018034CA10-0x000000018034CC60
	private static Color Dim(Color c, float f); // 0x0000000180351740-0x0000000180351770
	private static string FormatChatTime(string ts, bool fallbackNow); // 0x0000000180351E00-0x0000000180351FB0
	private static string ReplyPrefix(string username); // 0x0000000180353730-0x0000000180353780
	private void MakeNameClickable(UnityEngine.UI.Text nameText, string username); // 0x0000000180352330-0x0000000180352640
	private void BeginReply(string username); // 0x000000018034CE70-0x000000018034D3D0
	[IteratorStateMachine(typeof(_PlaceCaretAtEndNextFrame_d__84))]
	private IEnumerator PlaceCaretAtEndNextFrame(); // 0x0000000180352E90-0x0000000180352F00
	private void CancelReply(bool stripPrefix); // 0x0000000180350870-0x0000000180350AF0
	private static string ShortName(string s); // 0x0000000180353FC0-0x00000001803540A0
	private void EnsureReplyChip(); // 0x0000000180351770-0x0000000180351E00
	public static bool MentionsMe(string message); // 0x0000000180352640-0x0000000180352800
	private static void PulseMentionBg(GameObject owner, Image bg); // 0x0000000180352F00-0x00000001803530A0
	private void AppendRow(Transform content, string username, string message, string emojiId, string timeText); // 0x000000018034C240-0x000000018034CA10
	private static void TrimRows(Transform content); // 0x0000000180354610-0x00000001803546C0
	private void AppendRowFromTemplate(Transform content, string username, string message, string emojiId, string timeText); // 0x000000018034BCC0-0x000000018034C240
	private static void ScrollToBottom(ScrollRect scroll); // 0x00000001803538B0-0x0000000180353970
	private void BuildRuntimeUI(); // 0x000000018034EE80-0x0000000180350870
	private void ToggleEmojiTray(); // 0x0000000180354160-0x0000000180354210
	private void BuildEmojiTray(Transform windowT); // 0x000000018034E5F0-0x000000018034EE80
	private Image CreateTab(Transform parent, string name, string label, Vector2 pos, out UnityEngine.UI.Text labelText); // 0x00000001803510B0-0x0000000180351420
	private ScrollRect CreateScroll(Transform parent, string name); // 0x0000000180350CF0-0x00000001803510B0
	private UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color); // 0x0000000180351420-0x00000001803515B0
	private static void StretchFull(RectTransform rect, float padX = 0f /* Metadata: 0x0064C3D2 */, float padY = 0f /* Metadata: 0x0064C3D6 */); // 0x00000001803540A0-0x0000000180354160
	[CompilerGenerated]
	private void _BindFromHierarchy_b__52_0(); // 0x00000001803546C0-0x00000001803546F0
	[CompilerGenerated]
	private void _BindFromHierarchy_b__52_1(); // 0x00000001803546F0-0x0000000180354700
	[CompilerGenerated]
	private void _BindFromHierarchy_b__52_2(); // 0x0000000180354700-0x0000000180354710
	[CompilerGenerated]
	private void _BindFromHierarchy_b__52_3(string _); // 0x0000000180354710-0x0000000180354780
	[CompilerGenerated]
	private void _BindFromHierarchy_b__52_4(); // 0x0000000180354780-0x0000000180354790
	[CompilerGenerated]
	private void _EnsureReplyChip_b__87_0(); // 0x0000000180354780-0x0000000180354790
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__94_0(); // 0x00000001803546C0-0x00000001803546F0
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__94_1(); // 0x0000000180354700-0x0000000180354710
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__94_2(); // 0x00000001803546F0-0x0000000180354700
	[CompilerGenerated]
	private void _BuildRuntimeUI_b__94_3(string _); // 0x0000000180354790-0x0000000180354800
}

