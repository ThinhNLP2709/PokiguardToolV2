/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FriendChatBox : MonoBehaviour // TypeDefIndex: 680
{
	// Fields
	private const int MAX_ROWS = 50; // Metadata: 0x005EE62A
	private const int PAGE_SIZE = 30; // Metadata: 0x005EE62B
	private static readonly Regex EMOTE_PATTERN; // 0x00
	private static readonly Regex IMG_PATTERN; // 0x08
	private const long IMAGE_TTL_MS = 86400000; // Metadata: 0x005EE62C
	private bool _sendingImage; // 0x20
	private GameObject _btnAttach; // 0x28
	[SerializeField]
	private GameObject boxRoot; // 0x30
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x38
	[SerializeField]
	private Button btnBack; // 0x40
	[SerializeField]
	private Image imgAvatar; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x50
	[SerializeField]
	private Image statusDot; // 0x58
	[SerializeField]
	private ScrollRect scrollMsg; // 0x60
	[SerializeField]
	private Transform contentMsg; // 0x68
	[SerializeField]
	private GameObject rowTemplate; // 0x70
	[SerializeField]
	private InputField input; // 0x78
	[SerializeField]
	private Button btnSend; // 0x80
	[SerializeField]
	private Button btnEmoji; // 0x88
	[SerializeField]
	private GameObject emojiTray; // 0x90
	private static readonly Color DOT_ONLINE; // 0x10
	private static readonly Color DOT_BUSY; // 0x20
	private static readonly Color DOT_OFFLINE; // 0x30
	private static readonly Color BUBBLE_MINE; // 0x40
	private static readonly Color BUBBLE_THEIRS; // 0x50
	private int _userId; // 0x98
	private FriendItemData _friend; // 0xA0
	private long _oldestId; // 0xA8
	private bool _loadingOlder; // 0xB0
	private bool _sending; // 0xB1
	private bool _reachedTop; // 0xB2
	private float _nextLoadOlderAt; // 0xB4
	private readonly HashSet<long> _seenIds; // 0xB8
	private readonly List<GameObject> _rows; // 0xC0
	[CompilerGenerated]
	private Action OnClosed; // 0xC8
	[CompilerGenerated]
	private Action<FriendItemData> OnMarkedRead; // 0xD0
	private bool _ready; // 0xD8

	// Properties
	public FriendItemData CurrentFriend { get; } // 0x0000000180496EF0-0x0000000180496F20 
	public bool IsOpen { get; } // 0x0000000180496F20-0x0000000180497070 

	// Events
	public event Action OnClosed {
		add; // 0x0000000180497070-0x0000000180497170
		remove; // 0x0000000180497170-0x0000000180497270
	}
	public event Action<FriendItemData> OnMarkedRead {
		add; // 0x0000000180497270-0x0000000180497390
		remove; // 0x0000000180497390-0x00000001804974B0
	}

	// Nested types
	[Serializable]
	private class ChatImageUploadEnvelope // TypeDefIndex: 681
	{
		// Fields
		public ChatImageUploadData data; // 0x10

		// Constructors
		public ChatImageUploadEnvelope(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class ChatImageUploadData // TypeDefIndex: 682
	{
		// Fields
		public string id; // 0x10

		// Constructors
		public ChatImageUploadData(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 683
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__52_1; // 0x08
		public static Action<string> __9__56_1; // 0x10
		public static Action<string> __9__61_1; // 0x18

		// Constructors
		static __c(); // 0x00000001804A00B0-0x00000001804A0150
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadFirstPage_b__52_1(string err); // 0x00000001804A0150-0x00000001804A01D0
		internal void _MarkRead_b__56_1(string err); // 0x00000001804A01D0-0x00000001804A0250
		internal void _PickAndSendImage_b__61_1(string msg); // 0x00000001804A0250-0x00000001804A02B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 684
	{
		// Fields
		public FriendChatBox __4__this; // 0x10
		public FriendItemData friend; // 0x18

		// Constructors
		public __c__DisplayClass56_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _MarkRead_b__0(string _); // 0x00000001804A02B0-0x00000001804A02F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 685
	{
		// Fields
		public Transform capturedBubble; // 0x10
		public UnityEngine.UI.Text capturedText; // 0x18

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindRowImage_b__0(); // 0x00000001804A02F0-0x00000001804A0570
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 686
	{
		// Fields
		public string captured; // 0x10
		public FriendChatBox __4__this; // 0x18

		// Constructors
		public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x00000001804A0570-0x00000001804A05A0
	}

	// Constructors
	public FriendChatBox(); // 0x000000018049F1D0-0x000000018049F380
	static FriendChatBox(); // 0x000000018049F380-0x000000018049F5A0

	// Methods
	private void OnDisable(); // 0x0000000180496ED0-0x0000000180496EF0
	private void Awake(); // 0x00000001804974B0-0x00000001804974C0
	private void EnsureReady(); // 0x00000001804974C0-0x0000000180497AE0
	private void AutoFindRefs(); // 0x0000000180497AE0-0x0000000180498B10
	public void Open(int userId, FriendItemData friend); // 0x0000000180498B10-0x0000000180499170
	public void Close(); // 0x0000000180499170-0x0000000180499400
	public void SetPresence(bool online, bool busy); // 0x0000000180499400-0x00000001804995D0
	private void LoadFirstPage(); // 0x00000001804995D0-0x00000001804998B0
	private void OnScrolled(Vector2 pos); // 0x00000001804998B0-0x0000000180499930
	private void LoadOlder(); // 0x0000000180499930-0x0000000180499BB0
	private void RenderPage(FriendMessageData[] page, bool prepend); // 0x0000000180499BB0-0x0000000180499E20
	private void MarkRead(); // 0x0000000180499E20-0x000000018049A2B0
	public void AppendRemote(ChatMessageDTO dto); // 0x000000018049A2B0-0x000000018049A520
	private void SendCurrent(); // 0x000000018049A520-0x000000018049A650
	private void SendEmote(string emojiId); // 0x000000018049A650-0x000000018049A830
	private void EnsureAttachButton(); // 0x000000018049A830-0x000000018049B7F0
	private void PickAndSendImage(); // 0x000000018049B7F0-0x000000018049BB20
	private void UploadImage(byte[] jpeg); // 0x000000018049BB20-0x000000018049BE70
	private static string ParseUploadedId(string body); // 0x000000018049BE70-0x000000018049BF50
	private void SendContent(string content); // 0x000000018049BF50-0x000000018049C3F0
	private GameObject CreateRow(FriendMessageData data); // 0x000000018049C3F0-0x000000018049D3B0
	private void BindRowImage(GameObject row, Transform bubble, UnityEngine.UI.Text txtMessage, string imageId, string sentAt); // 0x000000018049D3B0-0x000000018049D720
	private static void AlignRow(GameObject row, bool mine); // 0x000000018049D720-0x000000018049D990
	private static void AnimateNewRow(GameObject row); // 0x000000018049D990-0x000000018049DC00
	private void TrimRows(); // 0x000000018049DC00-0x000000018049DDF0
	private void ClearRows(); // 0x000000018049DDF0-0x000000018049E670
	private void ScrollToBottom(); // 0x000000018049E670-0x000000018049E7B0
	private void ToggleEmojiTray(); // 0x000000018049E7B0-0x000000018049E970
	private void BuildEmojiTray(); // 0x000000018049E970-0x000000018049F1D0
	[CompilerGenerated]
	private void _EnsureReady_b__47_0(string _); // 0x000000018049F5A0-0x000000018049F730
	[CompilerGenerated]
	private void _Close_b__50_0(); // 0x000000018049F730-0x000000018049F750
	[CompilerGenerated]
	private void _LoadFirstPage_b__52_0(FriendMessageData[] page); // 0x000000018049F750-0x000000018049F790
	[CompilerGenerated]
	private void _LoadOlder_b__54_0(FriendMessageData[] page); // 0x000000018049F790-0x000000018049F7C0
	[CompilerGenerated]
	private void _LoadOlder_b__54_1(string err); // 0x000000018049F7C0-0x000000018049F850
	[CompilerGenerated]
	private void _PickAndSendImage_b__61_0(byte[] bytes, int w, int h); // 0x000000018049F850-0x000000018049F860
	[CompilerGenerated]
	private void _UploadImage_b__62_0(string body); // 0x000000018049F860-0x000000018049FB00
	[CompilerGenerated]
	private void _UploadImage_b__62_1(string err); // 0x000000018049FB00-0x000000018049FC70
	[CompilerGenerated]
	private void _SendContent_b__66_0(FriendMessageData saved); // 0x000000018049FC70-0x000000018049FF30
	[CompilerGenerated]
	private void _SendContent_b__66_1(string err); // 0x000000018049FF30-0x00000001804A00B0
}

