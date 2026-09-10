/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendRowUI : MonoBehaviour // TypeDefIndex: 616
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
	private const int NAME_MAX_CHARS = 14; // Metadata: 0x0068B6D0
	private FriendItemData _data; // 0x88
	private Vector3 _badgeBaseScale; // 0x90
	private int _badgeTweenId; // 0x9C

	// Properties
	public FriendItemData Data { get; } // 0x0000000180319920-0x0000000180319930 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 617
	{
		// Fields
		public Action<FriendItemData> onChat; // 0x10
		public FriendRowUI __4__this; // 0x18
		public Action<FriendItemData> onInvite; // 0x20
		public Action<FriendItemData, RectTransform> onMore; // 0x28

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018040FEC0-0x000000018040FF00
		internal void _Bind_b__1(); // 0x000000018040FF00-0x000000018040FF40
		internal void _Bind_b__2(); // 0x000000018040FF40-0x000000018040FFE0
	}

	// Constructors
	public FriendRowUI(); // 0x00000001803F4BD0-0x00000001803F4C10
	static FriendRowUI(); // 0x00000001803F4B50-0x00000001803F4BD0

	// Methods
	private void Awake(); // 0x00000001803F3410-0x00000001803F34C0
	private void AutoFindRefs(); // 0x00000001803F2DE0-0x00000001803F3410
	public void Bind(FriendItemData data, Action<FriendItemData> onChat, Action<FriendItemData> onInvite, Action<FriendItemData, RectTransform> onMore, bool chatEnabled); // 0x00000001803F34C0-0x00000001803F3EB0
	public void SetPresence(bool online, bool busy); // 0x00000001803F4610-0x00000001803F48E0
	public void SetUnread(int count, bool animate); // 0x00000001803F48E0-0x00000001803F4A10
	private void PulseBadge(); // 0x00000001803F42E0-0x00000001803F4540
	private void OnDisable(); // 0x00000001803F41D0-0x00000001803F42E0
	public static void Rewire(Button btn, UnityAction action); // 0x00000001803F4540-0x00000001803F4610
	public static string ShortName(string name); // 0x00000001803F4A10-0x00000001803F4AA0
	public static string FormatPower(long power); // 0x00000001803F3EB0-0x00000001803F3F90
	public static string LastSeenText(string isoTime); // 0x00000001803F3F90-0x00000001803F41D0
	[CompilerGenerated]
	private void _PulseBadge_b__27_0(); // 0x00000001803F4AA0-0x00000001803F4B50
}

