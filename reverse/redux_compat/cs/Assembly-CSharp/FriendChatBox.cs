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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendChatBox : MonoBehaviour // TypeDefIndex: 514
{
	// Fields
	private const int MAX_ROWS = 50; // Metadata: 0x0064C517
	private const int PAGE_SIZE = 30; // Metadata: 0x0064C518
	private static readonly Regex EMOTE_PATTERN; // 0x00
	[SerializeField]
	private GameObject boxRoot; // 0x20
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x28
	[SerializeField]
	private Button btnBack; // 0x30
	[SerializeField]
	private Image imgAvatar; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x40
	[SerializeField]
	private Image statusDot; // 0x48
	[SerializeField]
	private ScrollRect scrollMsg; // 0x50
	[SerializeField]
	private Transform contentMsg; // 0x58
	[SerializeField]
	private GameObject rowTemplate; // 0x60
	[SerializeField]
	private InputField input; // 0x68
	[SerializeField]
	private Button btnSend; // 0x70
	[SerializeField]
	private Button btnEmoji; // 0x78
	[SerializeField]
	private GameObject emojiTray; // 0x80
	private static readonly Color DOT_ONLINE; // 0x08
	private static readonly Color DOT_BUSY; // 0x18
	private static readonly Color DOT_OFFLINE; // 0x28
	private static readonly Color BUBBLE_MINE; // 0x38
	private static readonly Color BUBBLE_THEIRS; // 0x48
	private int _userId; // 0x88
	private FriendItemData _friend; // 0x90
	private long _oldestId; // 0x98
	private bool _loadingOlder; // 0xA0
	private bool _sending; // 0xA1
	private bool _reachedTop; // 0xA2
	private float _nextLoadOlderAt; // 0xA4
	private readonly HashSet<long> _seenIds; // 0xA8
	private readonly List<GameObject> _rows; // 0xB0
	[CompilerGenerated]
	private Action OnClosed; // 0xB8
	[CompilerGenerated]
	private Action<FriendItemData> OnMarkedRead; // 0xC0
	private bool _ready; // 0xC8

	// Properties
	public FriendItemData CurrentFriend { get; } // 0x0000000180384470-0x0000000180384500 
	public bool IsOpen { get; } // 0x0000000180384500-0x0000000180384580 

	// Events
	public event Action OnClosed {
		add; // 0x00000001803842F0-0x00000001803843A0
		remove; // 0x0000000180384580-0x0000000180384630
	}
	public event Action<FriendItemData> OnMarkedRead {
		add; // 0x00000001803843A0-0x0000000180384470
		remove; // 0x0000000180384630-0x0000000180384700
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 515
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__48_1; // 0x08
		public static Action<string> __9__52_1; // 0x10

		// Constructors
		static __c(); // 0x000000018038E250-0x000000018038E2C0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadFirstPage_b__48_1(string err); // 0x000000018038CAB0-0x000000018038CB20
		internal void _MarkRead_b__52_1(string err); // 0x000000018038CB20-0x000000018038CB90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 516
	{
		// Fields
		public FriendChatBox __4__this; // 0x10
		public FriendItemData friend; // 0x18

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _MarkRead_b__0(string _); // 0x000000018038D9B0-0x000000018038D9F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass64_0 // TypeDefIndex: 517
	{
		// Fields
		public string captured; // 0x10
		public FriendChatBox __4__this; // 0x18

		// Constructors
		public __c__DisplayClass64_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildEmojiTray_b__0(); // 0x000000018038DBE0-0x000000018038DCF0
	}

	// Constructors
	public FriendChatBox(); // 0x0000000180384220-0x00000001803842F0
	static FriendChatBox(); // 0x0000000180384110-0x0000000180384220

	// Methods
	private void OnDisable(); // 0x0000000180382CF0-0x0000000180382D00
	private void Awake(); // 0x0000000180380F80-0x0000000180380F90
	private void EnsureReady(); // 0x0000000180382330-0x00000001803826B0
	private void AutoFindRefs(); // 0x0000000180380960-0x0000000180380F80
	public void Open(int userId, FriendItemData friend); // 0x0000000180382F40-0x0000000180383360
	public void Close(); // 0x0000000180381A20-0x0000000180381B40
	public void SetPresence(bool online, bool busy); // 0x00000001803839C0-0x0000000180383B00
	private void LoadFirstPage(); // 0x00000001803826B0-0x00000001803828D0
	private void OnScrolled(Vector2 pos); // 0x0000000180382D00-0x0000000180382F40
	private void LoadOlder(); // 0x00000001803828D0-0x0000000180382AA0
	private void RenderPage(FriendMessageData[] page, bool prepend); // 0x0000000180383360-0x0000000180383540
	private void MarkRead(); // 0x0000000180382AA0-0x0000000180382CF0
	public void AppendRemote(ChatMessageDTO dto); // 0x00000001803807A0-0x0000000180380960
	private void SendCurrent(); // 0x0000000180383810-0x00000001803838C0
	private void SendEmote(string emojiId); // 0x00000001803838C0-0x00000001803839C0
	private void SendContent(string content); // 0x00000001803835E0-0x0000000180383810
	private GameObject CreateRow(FriendMessageData data); // 0x0000000180381B40-0x0000000180382330
	private static void AlignRow(GameObject row, bool mine); // 0x0000000180380540-0x0000000180380680
	private static void AnimateNewRow(GameObject row); // 0x0000000180380680-0x00000001803807A0
	private void TrimRows(); // 0x0000000180383B90-0x0000000180383C90
	private void ClearRows(); // 0x0000000180381530-0x0000000180381A20
	private void ScrollToBottom(); // 0x0000000180383540-0x00000001803835E0
	private void ToggleEmojiTray(); // 0x0000000180383B00-0x0000000180383B90
	private void BuildEmojiTray(); // 0x0000000180380F90-0x0000000180381530
	[CompilerGenerated]
	private void _EnsureReady_b__43_0(string _); // 0x0000000180383CB0-0x0000000180383DB0
	[CompilerGenerated]
	private void _Close_b__46_0(); // 0x0000000180383C90-0x0000000180383CB0
	[CompilerGenerated]
	private void _LoadFirstPage_b__48_0(FriendMessageData[] page); // 0x0000000180383DB0-0x0000000180383DF0
	[CompilerGenerated]
	private void _LoadOlder_b__50_0(FriendMessageData[] page); // 0x0000000180383DF0-0x0000000180383E20
	[CompilerGenerated]
	private void _LoadOlder_b__50_1(string err); // 0x0000000180383E20-0x0000000180383EA0
	[CompilerGenerated]
	private void _SendContent_b__56_0(FriendMessageData saved); // 0x0000000180383EA0-0x0000000180384030
	[CompilerGenerated]
	private void _SendContent_b__56_1(string err); // 0x0000000180384030-0x0000000180384110
}

