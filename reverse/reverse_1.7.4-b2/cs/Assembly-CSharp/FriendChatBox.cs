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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendChatBox : MonoBehaviour // TypeDefIndex: 588
{
	// Fields
	private const int MAX_ROWS = 50; // Metadata: 0x0068B6C2
	private const int PAGE_SIZE = 30; // Metadata: 0x0068B6C3
	private static readonly Regex EMOTE_PATTERN; // 0x00
	private static readonly Regex IMG_PATTERN; // 0x08
	private const long IMAGE_TTL_MS = 86400000; // Metadata: 0x0068B6C4
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
	public FriendItemData CurrentFriend { get; } // 0x00000001803ED540-0x00000001803ED5D0 
	public bool IsOpen { get; } // 0x00000001803ED5D0-0x00000001803ED650 

	// Events
	public event Action OnClosed {
		add; // 0x00000001803ED3C0-0x00000001803ED470
		remove; // 0x00000001803ED650-0x00000001803ED700
	}
	public event Action<FriendItemData> OnMarkedRead {
		add; // 0x00000001803ED470-0x00000001803ED540
		remove; // 0x00000001803ED700-0x00000001803ED7D0
	}

	// Nested types
	[Serializable]
	private class ChatImageUploadEnvelope // TypeDefIndex: 589
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public ChatImageUploadData data; // 0x20

		// Constructors
		public ChatImageUploadEnvelope(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	private class ChatImageUploadData // TypeDefIndex: 590
	{
		// Fields
		public string id; // 0x10
		public int w; // 0x18
		public int h; // 0x1C
		public long expiresAt; // 0x20

		// Constructors
		public ChatImageUploadData(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 591
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__52_1; // 0x08
		public static Action<string> __9__56_1; // 0x10
		public static Action<string> __9__61_1; // 0x18

		// Constructors
		static __c(); // 0x00000001803F6B70-0x00000001803F6BE0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadFirstPage_b__52_1(string err); // 0x00000001803F5100-0x00000001803F5170
		internal void _MarkRead_b__56_1(string err); // 0x00000001803F5170-0x00000001803F51E0
		internal void _PickAndSendImage_b__61_1(string msg); // 0x00000001803F51E0-0x00000001803F5240
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 592
	{
		// Fields
		public FriendChatBox __4__this; // 0x10
		public FriendItemData friend; // 0x18

		// Constructors
		public __c__DisplayClass56_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _MarkRead_b__0(string _); // 0x00000001803F61F0-0x00000001803F6230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 593
	{
		// Fields
		public Transform capturedBubble; // 0x10
		public UnityEngine.UI.Text capturedText; // 0x18

		// Constructors
		public __c__DisplayClass68_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BindRowImage_b__0(); // 0x00000001803F6420-0x00000001803F6500
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 594
	{
		// Fields
		public string captured; // 0x10
		public FriendChatBox __4__this; // 0x18

		// Constructors
		public __c__DisplayClass75_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x00000001803F6500-0x00000001803F6610
	}

	// Constructors
	public FriendChatBox(); // 0x00000001803ED2F0-0x00000001803ED3C0
	static FriendChatBox(); // 0x00000001803ED180-0x00000001803ED2F0

	// Methods
	private void OnDisable(); // 0x00000001803EB520-0x00000001803EB540
	private void Awake(); // 0x00000001803E8D30-0x00000001803E8D40
	private void EnsureReady(); // 0x00000001803EAB50-0x00000001803EAEE0
	private void AutoFindRefs(); // 0x00000001803E86F0-0x00000001803E8D30
	public void Open(int userId, FriendItemData friend); // 0x00000001803EB780-0x00000001803EBBE0
	public void Close(); // 0x00000001803E9A20-0x00000001803E9B50
	public void SetPresence(bool online, bool busy); // 0x00000001803EC590-0x00000001803EC6D0
	private void LoadFirstPage(); // 0x00000001803EAEE0-0x00000001803EB100
	private void OnScrolled(Vector2 pos); // 0x00000001803EB540-0x00000001803EB780
	private void LoadOlder(); // 0x00000001803EB100-0x00000001803EB2D0
	private void RenderPage(FriendMessageData[] page, bool prepend); // 0x00000001803EBF30-0x00000001803EC110
	private void MarkRead(); // 0x00000001803EB2D0-0x00000001803EB520
	public void AppendRemote(ChatMessageDTO dto); // 0x00000001803E8530-0x00000001803E86F0
	private void SendCurrent(); // 0x00000001803EC3E0-0x00000001803EC490
	private void SendEmote(string emojiId); // 0x00000001803EC490-0x00000001803EC590
	private void EnsureAttachButton(); // 0x00000001803EA520-0x00000001803EAB50
	private void PickAndSendImage(); // 0x00000001803EBCC0-0x00000001803EBF30
	private void UploadImage(byte[] jpeg); // 0x00000001803ECF70-0x00000001803ED180
	private static string ParseUploadedId(string body); // 0x00000001803EBBE0-0x00000001803EBCC0
	private void SendContent(string content); // 0x00000001803EC1B0-0x00000001803EC3E0
	private GameObject CreateRow(FriendMessageData data); // 0x00000001803E9B50-0x00000001803EA520
	private void BindRowImage(GameObject row, Transform bubble, UnityEngine.UI.Text txtMessage, string imageId, string sentAt); // 0x00000001803E8D40-0x00000001803E8F90
	private static void AlignRow(GameObject row, bool mine); // 0x00000001803E82D0-0x00000001803E8410
	private static void AnimateNewRow(GameObject row); // 0x00000001803E8410-0x00000001803E8530
	private void TrimRows(); // 0x00000001803EC760-0x00000001803EC860
	private void ClearRows(); // 0x00000001803E9530-0x00000001803E9A20
	private void ScrollToBottom(); // 0x00000001803EC110-0x00000001803EC1B0
	private void ToggleEmojiTray(); // 0x00000001803EC6D0-0x00000001803EC760
	private void BuildEmojiTray(); // 0x00000001803E8F90-0x00000001803E9530
	[CompilerGenerated]
	private void _EnsureReady_b__47_0(string _); // 0x00000001803EC880-0x00000001803EC980
	[CompilerGenerated]
	private void _Close_b__50_0(); // 0x00000001803EC860-0x00000001803EC880
	[CompilerGenerated]
	private void _LoadFirstPage_b__52_0(FriendMessageData[] page); // 0x00000001803EC980-0x00000001803EC9C0
	[CompilerGenerated]
	private void _LoadOlder_b__54_0(FriendMessageData[] page); // 0x00000001803EC9C0-0x00000001803EC9F0
	[CompilerGenerated]
	private void _LoadOlder_b__54_1(string err); // 0x00000001803EC9F0-0x00000001803ECA70
	[CompilerGenerated]
	private void _PickAndSendImage_b__61_0(byte[] bytes, int w, int h); // 0x00000001803ECA70-0x00000001803ECA80
	[CompilerGenerated]
	private void _UploadImage_b__62_0(string body); // 0x00000001803ECD00-0x00000001803ECE80
	[CompilerGenerated]
	private void _UploadImage_b__62_1(string err); // 0x00000001803ECE80-0x00000001803ECF70
	[CompilerGenerated]
	private void _SendContent_b__66_0(FriendMessageData saved); // 0x00000001803ECA80-0x00000001803ECC10
	[CompilerGenerated]
	private void _SendContent_b__66_1(string err); // 0x00000001803ECC10-0x00000001803ECD00
}

