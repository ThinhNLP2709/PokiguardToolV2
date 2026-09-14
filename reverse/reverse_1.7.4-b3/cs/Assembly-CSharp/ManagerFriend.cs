/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerFriend : MonoBehaviour // TypeDefIndex: 712
{
	// Fields
	public const string PANEL_KEY = "PanelFriend"; // Metadata: 0x005EE639
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
		add; // 0x00000001804B0BE0-0x00000001804B0D10
		remove; // 0x00000001804B0D10-0x00000001804B0E40
	}

	// Nested types
	public enum FriendTab // TypeDefIndex: 713
	{
		Friends = 0,
		Requests = 1,
		Search = 2,
		Suggest = 3
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 714
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
		static __c(); // 0x00000001804BC550-0x00000001804BC5F0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchBadge_b__49_1(string err); // 0x000000018028A320-0x000000018028A330
		internal void _FetchRequests_b__52_1(string err); // 0x00000001804BC5F0-0x00000001804BC670
		internal void _DoSearch_b__53_1(string err); // 0x00000001804BC670-0x00000001804BC700
		internal void _FetchSuggestions_b__54_1(string err); // 0x00000001804BC700-0x00000001804BC780
		internal void _SendFriendRequest_b__59_1(string err); // 0x00000001804BC780-0x00000001804BC810
		internal void _SetPinned_b__70_1(string err); // 0x00000001804BC810-0x00000001804BC8A0
		internal void _SendEnergyGift_b__71_1(string err); // 0x00000001804BC8A0-0x00000001804BC930
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 715
	{
		// Fields
		public FriendSearchItemData target; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SendFriendRequest_b__0(string _); // 0x00000001804BC930-0x00000001804BCA00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass63_0 // TypeDefIndex: 716
	{
		// Fields
		public string successMessage; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass63_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PostAction_b__0(string _); // 0x00000001804BCA00-0x00000001804BCAA0
		internal void _PostAction_b__1(string err); // 0x00000001804BCAA0-0x00000001804BCB50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 717
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public FriendItemData friend; // 0x18
		public Action __9__6; // 0x20
		public Action __9__5; // 0x28
		public Action __9__8; // 0x30
		public Action __9__7; // 0x38

		// Constructors
		public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OpenActionBox_b__0(); // 0x00000001804BCB50-0x00000001804BCBB0
		internal void _OpenActionBox_b__1(); // 0x00000001804BCBB0-0x00000001804BCC00
		internal void _OpenActionBox_b__2(); // 0x00000001804BCC00-0x00000001804BCC40
		internal void _OpenActionBox_b__3(); // 0x00000001804BCC40-0x00000001804BCDC0
		internal void _OpenActionBox_b__5(); // 0x00000001804BCDC0-0x00000001804BD030
		internal void _OpenActionBox_b__6(); // 0x00000001804BD030-0x00000001804BD070
		internal void _OpenActionBox_b__4(); // 0x00000001804BD070-0x00000001804BD1F0
		internal void _OpenActionBox_b__7(); // 0x00000001804BD1F0-0x00000001804BD460
		internal void _OpenActionBox_b__8(); // 0x00000001804BD030-0x00000001804BD070
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 718
	{
		// Fields
		public Action action; // 0x10

		// Constructors
		public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WireActionButton_b__0(); // 0x0000000180335B30-0x0000000180335B50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 719
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public Action onYes; // 0x18

		// Constructors
		public __c__DisplayClass69_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShowConfirm_b__0(); // 0x00000001804BD460-0x00000001804BD500
		internal void _ShowConfirm_b__1(); // 0x00000001804BD500-0x00000001804BD590
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 720
	{
		// Fields
		public bool pinned; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass70_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetPinned_b__0(string _); // 0x00000001804BD590-0x00000001804BD650
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 721
	{
		// Fields
		public FriendItemData friend; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass71_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SendEnergyGift_b__0(string _); // 0x00000001804BD650-0x00000001804BD720
	}

	// Constructors
	public ManagerFriend(); // 0x00000001804BBE60-0x00000001804BC010

	// Methods
	private void Awake(); // 0x00000001804B0E40-0x00000001804B0E60
	private void OnEnable(); // 0x00000001804B0E60-0x00000001804B1210
	private void OnDisable(); // 0x00000001804B1210-0x00000001804B15D0
	private void BindFromHierarchy(); // 0x00000001804B15D0-0x00000001804B30C0
	private void RewireAll(); // 0x00000001804B30C0-0x00000001804B38A0
	public void OpenPanel(); // 0x00000001804B38A0-0x00000001804B3F90
	public void ClosePanel(); // 0x00000001804B3F90-0x00000001804B4130
	private void FinishClose(); // 0x00000001804B4130-0x00000001804B43A0
	private void SelectTab(FriendTab tab); // 0x00000001804B43A0-0x00000001804B4870
	private static void ApplyTabArt(Button tab, bool selected); // 0x00000001804B4870-0x00000001804B4CA0
	private void FetchBadge(); // 0x00000001804B4CA0-0x00000001804B4F50
	private void ApplyRequestDot(long pending); // 0x00000001804B4F50-0x00000001804B5200
	private void FetchFriends(); // 0x00000001804B5200-0x00000001804B5460
	private void FetchRequests(); // 0x00000001804B5460-0x00000001804B57F0
	private void DoSearch(); // 0x00000001804B57F0-0x00000001804B5CD0
	private void FetchSuggestions(); // 0x00000001804B5CD0-0x00000001804B6060
	private void BuildFriendRows(FriendItemData[] list); // 0x00000001804B6060-0x00000001804B6D70
	private void BuildRequestRows(FriendRequestsData data); // 0x00000001804B6D70-0x00000001804B7380
	private int AddRequestRows(FriendRequestItemData[] rows); // 0x00000001804B7380-0x00000001804B76D0
	private void BuildSearchRows(Transform content, FriendSearchItemData[] list, string emptyText); // 0x00000001804B76D0-0x00000001804B8010
	private void SendFriendRequest(FriendSearchItemData target); // 0x00000001804B8010-0x00000001804B8380
	private void AcceptRequest(FriendRequestItemData req); // 0x00000001804B8380-0x00000001804B85B0
	private void DeclineRequest(FriendRequestItemData req); // 0x00000001804B85B0-0x00000001804B87B0
	private void CancelRequest(FriendRequestItemData req); // 0x00000001804B87B0-0x00000001804B89B0
	private void PostAction(string url, string successMessage, Action onDone); // 0x00000001804B89B0-0x00000001804B8C60
	private void OpenChat(FriendItemData friend); // 0x00000001804B8C60-0x00000001804B8DE0
	private void InviteToRoom(FriendItemData friend); // 0x00000001804B8DE0-0x00000001804B9070
	private void OpenActionBox(FriendItemData friend, RectTransform anchor); // 0x00000001804B9070-0x00000001804B9D50
	private void WireActionButton(string nodeName, Action action); // 0x00000001804B9D50-0x00000001804B9F40
	private void CloseActionBox(); // 0x00000001804B9F40-0x00000001804BA090
	private void ShowConfirm(string message, Action onYes); // 0x00000001804BA090-0x00000001804BA770
	private void SetPinned(FriendItemData friend, bool pinned); // 0x00000001804BA770-0x00000001804BAC10
	private void SendEnergyGift(FriendItemData friend); // 0x00000001804BAC10-0x00000001804BB0F0
	private void HandleFriendPush(ChatMessageDTO m); // 0x00000001804BB0F0-0x00000001804BB6A0
	private void HandleFriendMsg(ChatMessageDTO m); // 0x00000001804BB6A0-0x00000001804BB8D0
	private void HandleFriendOnline(ChatMessageDTO m); // 0x00000001804BB8D0-0x00000001804BBA50
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x00000001804BBA50-0x00000001804BBDF0
	private void HandleInviteFailed(string target, string reason); // 0x00000001804BBDF0-0x00000001804BBE60
	[CompilerGenerated]
	private void _RewireAll_b__43_0(); // 0x00000001804BC010-0x00000001804BC020
	[CompilerGenerated]
	private void _RewireAll_b__43_1(); // 0x00000001804BC020-0x00000001804BC030
	[CompilerGenerated]
	private void _RewireAll_b__43_2(); // 0x00000001804BC030-0x00000001804BC040
	[CompilerGenerated]
	private void _RewireAll_b__43_3(); // 0x00000001804BC040-0x00000001804BC050
	[CompilerGenerated]
	private void _RewireAll_b__43_4(FriendItemData f); // 0x00000001804BC050-0x00000001804BC0F0
	[CompilerGenerated]
	private void _RewireAll_b__43_5(string _); // 0x00000001804BC0F0-0x00000001804BC170
	[CompilerGenerated]
	private void _FetchBadge_b__49_0(FriendBadgeData badge); // 0x00000001804BC170-0x00000001804BC1F0
	[CompilerGenerated]
	private void _FetchFriends_b__51_0(FriendItemData[] list); // 0x00000001804BC1F0-0x00000001804BC290
	[CompilerGenerated]
	private void _FetchFriends_b__51_1(string err); // 0x00000001804BC290-0x00000001804BC380
	[CompilerGenerated]
	private void _FetchRequests_b__52_0(FriendRequestsData data); // 0x00000001804BC380-0x00000001804BC390
	[CompilerGenerated]
	private void _DoSearch_b__53_0(FriendSearchItemData[] list); // 0x00000001804BC390-0x00000001804BC460
	[CompilerGenerated]
	private void _FetchSuggestions_b__54_0(FriendSearchItemData[] list); // 0x00000001804BC460-0x00000001804BC530
	[CompilerGenerated]
	private void _AcceptRequest_b__60_0(); // 0x00000001804BC530-0x00000001804BC550
	[CompilerGenerated]
	private void _DeclineRequest_b__61_0(); // 0x00000001804BC530-0x00000001804BC550
}

