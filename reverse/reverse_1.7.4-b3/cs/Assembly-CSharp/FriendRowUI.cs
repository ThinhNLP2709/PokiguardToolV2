/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FriendRowUI : MonoBehaviour // TypeDefIndex: 707
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
	private const int NAME_MAX_CHARS = 14; // Metadata: 0x005EE638
	private FriendItemData _data; // 0x88
	private Vector3 _badgeBaseScale; // 0x90
	private int _badgeTweenId; // 0x9C

	// Properties
	public FriendItemData Data { get; } // 0x00000001802D8CD0-0x00000001802D8CE0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 708
	{
		// Fields
		public Action<FriendItemData> onChat; // 0x10
		public FriendRowUI __4__this; // 0x18
		public Action<FriendItemData> onInvite; // 0x20
		public Action<FriendItemData, RectTransform> onMore; // 0x28

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001804AE7E0-0x00000001804AE820
		internal void _Bind_b__1(); // 0x00000001804AE820-0x00000001804AE860
		internal void _Bind_b__2(); // 0x00000001804AE860-0x00000001804AE900
	}

	// Constructors
	public FriendRowUI(); // 0x00000001804AE500-0x00000001804AE580
	static FriendRowUI(); // 0x00000001804AE580-0x00000001804AE600

	// Methods
	private void Awake(); // 0x00000001804AB190-0x00000001804AB320
	private void AutoFindRefs(); // 0x00000001804AB320-0x00000001804AC350
	public void Bind(FriendItemData data, Action<FriendItemData> onChat, Action<FriendItemData> onInvite, Action<FriendItemData, RectTransform> onMore, bool chatEnabled); // 0x00000001804AC350-0x00000001804AD260
	public void SetPresence(bool online, bool busy); // 0x00000001804AD260-0x00000001804AD650
	public void SetUnread(int count, bool animate); // 0x00000001804AD650-0x00000001804AD8C0
	private void PulseBadge(); // 0x00000001804AD8C0-0x00000001804ADC00
	private void OnDisable(); // 0x00000001804ADC00-0x00000001804ADDE0
	public static void Rewire(Button btn, UnityAction action); // 0x00000001804ADDE0-0x00000001804ADF70
	public static string ShortName(string name); // 0x00000001804ADF70-0x00000001804AE070
	public static string FormatPower(long power); // 0x00000001804AE070-0x00000001804AE1E0
	public static string LastSeenText(string isoTime); // 0x00000001804AE1E0-0x00000001804AE500
	[CompilerGenerated]
	private void _PulseBadge_b__27_0(); // 0x00000001804AE600-0x00000001804AE7E0
}

