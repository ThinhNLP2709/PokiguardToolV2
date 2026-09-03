/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerFriend : MonoBehaviour // TypeDefIndex: 544
{
	// Fields
	public const string PANEL_KEY = "PanelFriend"; // Metadata: 0x0064C51E
	[CompilerGenerated]
	private static Action<FriendBadgeData> OnBadgeUpdated; // 0x00
	[Header("Khung ch\u00EDnh")]
	public GameObject panelRoot; // 0x20
	public GameObject window; // 0x28
	public CanvasGroup windowGroup; // 0x30
	public UnityEngine.UI.Text txtTitle; // 0x38
	public Button btnClose; // 0x40
	[Header("Th\u1EBB")]
	public Button tabFriends; // 0x48
	public Button tabRequests; // 0x50
	public Button tabSearch; // 0x58
	public Button tabSuggest; // 0x60
	public GameObject dotRequests; // 0x68
	public UnityEngine.UI.Text txtDotRequests; // 0x70
	[Header("Trang")]
	public GameObject pageFriends; // 0x78
	public GameObject pageRequests; // 0x80
	public GameObject pageSearch; // 0x88
	public GameObject pageSuggest; // 0x90
	[Header("Danh s\u00E1ch")]
	public Transform contentFriends; // 0x98
	public GameObject rowFriendTemplate; // 0xA0
	public UnityEngine.UI.Text txtEmpty; // 0xA8
	public Transform contentRequests; // 0xB0
	public GameObject rowRequestTemplate; // 0xB8
	public Transform contentSearch; // 0xC0
	public GameObject rowSearchTemplate; // 0xC8
	public Transform contentSuggest; // 0xD0
	public InputField inputSearch; // 0xD8
	public Button btnSearch; // 0xE0
	[Header("Khung con")]
	public FriendChatBox chatBox; // 0xE8
	public FriendProfileBox profileBox; // 0xF0
	public GameObject actionBox; // 0xF8
	public GameObject confirmBox; // 0x100
	private int _userId; // 0x108
	private FriendTab _tab; // 0x10C
	private bool _loading; // 0x110
	private readonly List<FriendRowUI> _friendRows; // 0x118
	private readonly Dictionary<long, FriendRowUI> _rowByUserId; // 0x120

	// Events
	public static event Action<FriendBadgeData> OnBadgeUpdated {
		add; // 0x00000001803A50B0-0x00000001803A5180
		remove; // 0x00000001803A5180-0x00000001803A5250
	}

	// Nested types
	public enum FriendTab // TypeDefIndex: 545
	{
		Friends = 0,
		Requests = 1,
		Search = 2,
		Suggest = 3
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 546
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__49_1; // 0x08
		public static Action<string> __9__52_1; // 0x10
		public static Action<string> __9__53_1; // 0x18
		public static Action<string> __9__54_1; // 0x20
		public static Action<string> __9__59_1; // 0x28
		public static Action<string> __9__70_1; // 0x30
		public static Action<string> __9__71_1; // 0x38

		// Constructors
		static __c(); // 0x00000001803A7910-0x00000001803A7980
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FetchBadge_b__49_1(string err); // 0x00000001802E76C0-0x00000001802E76D0
		internal void _FetchRequests_b__52_1(string err); // 0x00000001803A5F50-0x00000001803A5FC0
		internal void _DoSearch_b__53_1(string err); // 0x00000001803A5ED0-0x00000001803A5F50
		internal void _FetchSuggestions_b__54_1(string err); // 0x00000001803A5FC0-0x00000001803A6030
		internal void _SendFriendRequest_b__59_1(string err); // 0x00000001803A6130-0x00000001803A61B0
		internal void _SetPinned_b__70_1(string err); // 0x00000001803A61B0-0x00000001803A6230
		internal void _SendEnergyGift_b__71_1(string err); // 0x00000001803A60B0-0x00000001803A6130
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 547
	{
		// Fields
		public FriendSearchItemData target; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SendFriendRequest_b__0(string _); // 0x00000001803A6770-0x00000001803A6830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass63_0 // TypeDefIndex: 548
	{
		// Fields
		public string successMessage; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass63_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PostAction_b__0(string _); // 0x00000001803A6830-0x00000001803A68D0
		internal void _PostAction_b__1(string err); // 0x00000001803A68D0-0x00000001803A6970
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 549
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public FriendItemData friend; // 0x18
		public Action __9__6; // 0x20
		public Action __9__5; // 0x28
		public Action __9__8; // 0x30
		public Action __9__7; // 0x38

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OpenActionBox_b__0(); // 0x00000001803A6D00-0x00000001803A6D60
		internal void _OpenActionBox_b__1(); // 0x00000001803A6D60-0x00000001803A6DB0
		internal void _OpenActionBox_b__2(); // 0x00000001803A6DB0-0x00000001803A6DF0
		internal void _OpenActionBox_b__3(); // 0x00000001803A6DF0-0x00000001803A6F00
		internal void _OpenActionBox_b__5(); // 0x00000001803A7010-0x00000001803A7140
		internal void _OpenActionBox_b__6(); // 0x00000001803A7140-0x00000001803A7180
		internal void _OpenActionBox_b__4(); // 0x00000001803A6F00-0x00000001803A7010
		internal void _OpenActionBox_b__7(); // 0x00000001803A7180-0x00000001803A72B0
		internal void _OpenActionBox_b__8(); // 0x00000001803A7140-0x00000001803A7180
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 550
	{
		// Fields
		public Action action; // 0x10

		// Constructors
		public __c__DisplayClass67_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _WireActionButton_b__0(); // 0x00000001803A72E0-0x00000001803A7300
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 551
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public Action onYes; // 0x18

		// Constructors
		public __c__DisplayClass69_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ShowConfirm_b__0(); // 0x00000001803A7300-0x00000001803A7360
		internal void _ShowConfirm_b__1(); // 0x00000001803A7360-0x00000001803A7390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 552
	{
		// Fields
		public bool pinned; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass70_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetPinned_b__0(string _); // 0x00000001803A7390-0x00000001803A7430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 553
	{
		// Fields
		public FriendItemData friend; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass71_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SendEnergyGift_b__0(string _); // 0x00000001803A7430-0x00000001803A74E0
	}

	// Constructors
	public ManagerFriend(); // 0x00000001803A4FE0-0x00000001803A50B0

	// Methods
	private void Awake(); // 0x000000018039E7D0-0x000000018039E7F0
	private void OnEnable(); // 0x00000001803A2680-0x00000001803A2880
	private void OnDisable(); // 0x00000001803A2470-0x00000001803A2680
	private void BindFromHierarchy(); // 0x000000018039E7F0-0x000000018039F600
	private void RewireAll(); // 0x00000001803A3490-0x00000001803A3880
	public void OpenPanel(); // 0x00000001803A2F70-0x00000001803A3300
	public void ClosePanel(); // 0x00000001803A0870-0x00000001803A0AB0
	private void FinishClose(); // 0x00000001803A15F0-0x00000001803A1750
	private void SelectTab(FriendTab tab); // 0x00000001803A3880-0x00000001803A3A50
	private static void ApplyTabArt(Button tab, bool selected); // 0x000000018039E630-0x000000018039E7D0
	private void FetchBadge(); // 0x00000001803A0E50-0x00000001803A1050
	private void ApplyRequestDot(long pending); // 0x000000018039E540-0x000000018039E630
	private void FetchFriends(); // 0x00000001803A1050-0x00000001803A11F0
	private void FetchRequests(); // 0x00000001803A11F0-0x00000001803A13F0
	private void DoSearch(); // 0x00000001803A0BA0-0x00000001803A0E50
	private void FetchSuggestions(); // 0x00000001803A13F0-0x00000001803A15F0
	private void BuildFriendRows(FriendItemData[] list); // 0x000000018039F600-0x000000018039FD80
	private void BuildRequestRows(FriendRequestsData data); // 0x000000018039FD80-0x00000001803A0150
	private int AddRequestRows(FriendRequestItemData[] rows); // 0x000000018039E2A0-0x000000018039E540
	private void BuildSearchRows(Transform content, FriendSearchItemData[] list, string emptyText); // 0x00000001803A0150-0x00000001803A0700
	private void SendFriendRequest(FriendSearchItemData target); // 0x00000001803A3C90-0x00000001803A3ED0
	private void AcceptRequest(FriendRequestItemData req); // 0x000000018039E180-0x000000018039E2A0
	private void DeclineRequest(FriendRequestItemData req); // 0x00000001803A0AB0-0x00000001803A0BA0
	private void CancelRequest(FriendRequestItemData req); // 0x00000001803A0700-0x00000001803A07F0
	private void PostAction(string url, string successMessage, Action onDone); // 0x00000001803A3300-0x00000001803A3490
	private void OpenChat(FriendItemData friend); // 0x00000001803A2E70-0x00000001803A2F70
	private void InviteToRoom(FriendItemData friend); // 0x00000001803A2260-0x00000001803A2470
	private void OpenActionBox(FriendItemData friend, RectTransform anchor); // 0x00000001803A2880-0x00000001803A2E70
	private void WireActionButton(string nodeName, Action action); // 0x00000001803A4E90-0x00000001803A4FE0
	private void CloseActionBox(); // 0x00000001803A07F0-0x00000001803A0870
	private void ShowConfirm(string message, Action onYes); // 0x00000001803A4130-0x00000001803A4480
	private void SetPinned(FriendItemData friend, bool pinned); // 0x00000001803A3ED0-0x00000001803A4130
	private void SendEnergyGift(FriendItemData friend); // 0x00000001803A3A50-0x00000001803A3C90
	private void HandleFriendPush(ChatMessageDTO m); // 0x00000001803A1A50-0x00000001803A1E30
	private void HandleFriendMsg(ChatMessageDTO m); // 0x00000001803A1750-0x00000001803A18F0
	private void HandleFriendOnline(ChatMessageDTO m); // 0x00000001803A18F0-0x00000001803A1A50
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x00000001803A2010-0x00000001803A2260
	private void HandleInviteFailed(string target, string reason); // 0x00000001803A1E30-0x00000001803A2010
	[CompilerGenerated]
	private void _RewireAll_b__43_0(); // 0x00000001803A4810-0x00000001803A4970
	[CompilerGenerated]
	private void _RewireAll_b__43_1(); // 0x00000001803A4970-0x00000001803A4AD0
	[CompilerGenerated]
	private void _RewireAll_b__43_2(); // 0x00000001803A4AD0-0x00000001803A4C20
	[CompilerGenerated]
	private void _RewireAll_b__43_3(); // 0x00000001803A4C20-0x00000001803A4D80
	[CompilerGenerated]
	private void _RewireAll_b__43_4(FriendItemData f); // 0x00000001803A4D80-0x00000001803A4E20
	[CompilerGenerated]
	private void _RewireAll_b__43_5(string _); // 0x00000001803A4E20-0x00000001803A4E90
	[CompilerGenerated]
	private void _FetchBadge_b__49_0(FriendBadgeData badge); // 0x00000001803A4560-0x00000001803A45E0
	[CompilerGenerated]
	private void _FetchFriends_b__51_0(FriendItemData[] list); // 0x00000001803A45E0-0x00000001803A4670
	[CompilerGenerated]
	private void _FetchFriends_b__51_1(string err); // 0x00000001803A4670-0x00000001803A4740
	[CompilerGenerated]
	private void _FetchRequests_b__52_0(FriendRequestsData data); // 0x00000001803A4740-0x00000001803A4750
	[CompilerGenerated]
	private void _DoSearch_b__53_0(FriendSearchItemData[] list); // 0x00000001803A44A0-0x00000001803A4560
	[CompilerGenerated]
	private void _FetchSuggestions_b__54_0(FriendSearchItemData[] list); // 0x00000001803A4750-0x00000001803A4810
	[CompilerGenerated]
	private void _AcceptRequest_b__60_0(); // 0x00000001803A4480-0x00000001803A44A0
	[CompilerGenerated]
	private void _DeclineRequest_b__61_0(); // 0x00000001803A4480-0x00000001803A44A0
}

