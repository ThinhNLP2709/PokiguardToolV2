/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendRowUI : MonoBehaviour // TypeDefIndex: 539
{
	// Fields
	[SerializeField]
	private Image imgAvatar; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtPower; // 0x38
	[SerializeField]
	private Image statusDot; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtStatus; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtIntimacy; // 0x50
	[SerializeField]
	private GameObject pinIcon; // 0x58
	[SerializeField]
	private Button btnChat; // 0x60
	[SerializeField]
	private GameObject badgeMsg; // 0x68
	[SerializeField]
	private UnityEngine.UI.Text txtBadgeCount; // 0x70
	[SerializeField]
	private Button btnInvite; // 0x78
	[SerializeField]
	private Button btnMore; // 0x80
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_BUSY; // 0x10
	private static readonly Color DOT_OFFLINE; // 0x20
	private const int NAME_MAX_CHARS = 14; // Metadata: 0x0064C51D
	private FriendItemData _data; // 0x88
	private Vector3 _badgeBaseScale; // 0x90
	private int _badgeTweenId; // 0x9C

	// Properties
	public FriendItemData Data { get; } // 0x000000018038B8A0-0x000000018038B8B0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 540
	{
		// Fields
		public Action<FriendItemData> onChat; // 0x10
		public FriendRowUI __4__this; // 0x18
		public Action<FriendItemData> onInvite; // 0x20
		public Action<FriendItemData, RectTransform> onMore; // 0x28

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018038D3D0-0x000000018038D410
		internal void _Bind_b__1(); // 0x000000018038D410-0x000000018038D450
		internal void _Bind_b__2(); // 0x000000018038D450-0x000000018038D4F0
	}

	// Constructors
	public FriendRowUI(); // 0x000000018038B860-0x000000018038B8A0
	static FriendRowUI(); // 0x000000018038B7E0-0x000000018038B860

	// Methods
	private void Awake(); // 0x000000018038A160-0x000000018038A210
	private void AutoFindRefs(); // 0x0000000180389B30-0x000000018038A160
	public void Bind(FriendItemData data, Action<FriendItemData> onChat, Action<FriendItemData> onInvite, Action<FriendItemData, RectTransform> onMore, bool chatEnabled); // 0x000000018038A210-0x000000018038AB40
	public void SetPresence(bool online, bool busy); // 0x000000018038B2A0-0x000000018038B570
	public void SetUnread(int count, bool animate); // 0x000000018038B570-0x000000018038B6A0
	private void PulseBadge(); // 0x000000018038AF70-0x000000018038B1D0
	private void OnDisable(); // 0x000000018038AE60-0x000000018038AF70
	public static void Rewire(Button btn, UnityAction action); // 0x000000018038B1D0-0x000000018038B2A0
	public static string ShortName(string name); // 0x000000018038B6A0-0x000000018038B730
	public static string FormatPower(long power); // 0x000000018038AB40-0x000000018038AC20
	public static string LastSeenText(string isoTime); // 0x000000018038AC20-0x000000018038AE60
	[CompilerGenerated]
	private void _PulseBadge_b__27_0(); // 0x000000018038B730-0x000000018038B7E0
}

