/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerFriend : MonoBehaviour // TypeDefIndex: 621
{
	// Fields
	public const string PANEL_KEY = "PanelFriend"; // Metadata: 0x0068B6D1
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
		add; // 0x000000018040E890-0x000000018040E960
		remove; // 0x000000018040E960-0x000000018040EA30
	}

	// Nested types
	public enum FriendTab // TypeDefIndex: 622
	{
		Friends = 0,
		Requests = 1,
		Search = 2,
		Suggest = 3
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 623
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
		static __c(); // 0x0000000180411210-0x0000000180411280
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FetchBadge_b__49_1(string err); // 0x00000001802EB6C0-0x00000001802EB6D0
		internal void _FetchRequests_b__52_1(string err); // 0x000000018040F730-0x000000018040F7A0
		internal void _DoSearch_b__53_1(string err); // 0x000000018040F6B0-0x000000018040F730
		internal void _FetchSuggestions_b__54_1(string err); // 0x000000018040F7A0-0x000000018040F810
		internal void _SendFriendRequest_b__59_1(string err); // 0x000000018040F910-0x000000018040F990
		internal void _SetPinned_b__70_1(string err); // 0x000000018040F990-0x000000018040FA10
		internal void _SendEnergyGift_b__71_1(string err); // 0x000000018040F890-0x000000018040F910
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass59_0 // TypeDefIndex: 624
	{
		// Fields
		public FriendSearchItemData target; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass59_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SendFriendRequest_b__0(string _); // 0x0000000180410070-0x0000000180410130
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass63_0 // TypeDefIndex: 625
	{
		// Fields
		public string successMessage; // 0x10
		public Action onDone; // 0x18

		// Constructors
		public __c__DisplayClass63_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PostAction_b__0(string _); // 0x0000000180410130-0x00000001804101D0
		internal void _PostAction_b__1(string err); // 0x00000001804101D0-0x0000000180410270
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass66_0 // TypeDefIndex: 626
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public FriendItemData friend; // 0x18
		public Action __9__6; // 0x20
		public Action __9__5; // 0x28
		public Action __9__8; // 0x30
		public Action __9__7; // 0x38

		// Constructors
		public __c__DisplayClass66_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OpenActionBox_b__0(); // 0x0000000180410600-0x0000000180410660
		internal void _OpenActionBox_b__1(); // 0x0000000180410660-0x00000001804106B0
		internal void _OpenActionBox_b__2(); // 0x00000001804106B0-0x00000001804106F0
		internal void _OpenActionBox_b__3(); // 0x00000001804106F0-0x0000000180410800
		internal void _OpenActionBox_b__5(); // 0x0000000180410910-0x0000000180410A40
		internal void _OpenActionBox_b__6(); // 0x0000000180410A40-0x0000000180410A80
		internal void _OpenActionBox_b__4(); // 0x0000000180410800-0x0000000180410910
		internal void _OpenActionBox_b__7(); // 0x0000000180410A80-0x0000000180410BB0
		internal void _OpenActionBox_b__8(); // 0x0000000180410A40-0x0000000180410A80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 627
	{
		// Fields
		public Action action; // 0x10

		// Constructors
		public __c__DisplayClass67_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WireActionButton_b__0(); // 0x0000000180410BE0-0x0000000180410C00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 628
	{
		// Fields
		public ManagerFriend __4__this; // 0x10
		public Action onYes; // 0x18

		// Constructors
		public __c__DisplayClass69_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShowConfirm_b__0(); // 0x0000000180410C00-0x0000000180410C60
		internal void _ShowConfirm_b__1(); // 0x0000000180410C60-0x0000000180410C90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0 // TypeDefIndex: 629
	{
		// Fields
		public bool pinned; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass70_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetPinned_b__0(string _); // 0x0000000180410C90-0x0000000180410D30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 630
	{
		// Fields
		public FriendItemData friend; // 0x10
		public ManagerFriend __4__this; // 0x18

		// Constructors
		public __c__DisplayClass71_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SendEnergyGift_b__0(string _); // 0x0000000180410D30-0x0000000180410DE0
	}

	// Constructors
	public ManagerFriend(); // 0x000000018040E7C0-0x000000018040E890

	// Methods
	private void Awake(); // 0x0000000180407FB0-0x0000000180407FD0
	private void OnEnable(); // 0x000000018040BE60-0x000000018040C060
	private void OnDisable(); // 0x000000018040BC50-0x000000018040BE60
	private void BindFromHierarchy(); // 0x0000000180407FD0-0x0000000180408DE0
	private void RewireAll(); // 0x000000018040CC70-0x000000018040D060
	public void OpenPanel(); // 0x000000018040C750-0x000000018040CAE0
	public void ClosePanel(); // 0x000000018040A050-0x000000018040A290
	private void FinishClose(); // 0x000000018040ADD0-0x000000018040AF30
	private void SelectTab(FriendTab tab); // 0x000000018040D060-0x000000018040D230
	private static void ApplyTabArt(Button tab, bool selected); // 0x0000000180407E10-0x0000000180407FB0
	private void FetchBadge(); // 0x000000018040A630-0x000000018040A830
	private void ApplyRequestDot(long pending); // 0x0000000180407D20-0x0000000180407E10
	private void FetchFriends(); // 0x000000018040A830-0x000000018040A9D0
	private void FetchRequests(); // 0x000000018040A9D0-0x000000018040ABD0
	private void DoSearch(); // 0x000000018040A380-0x000000018040A630
	private void FetchSuggestions(); // 0x000000018040ABD0-0x000000018040ADD0
	private void BuildFriendRows(FriendItemData[] list); // 0x0000000180408DE0-0x0000000180409560
	private void BuildRequestRows(FriendRequestsData data); // 0x0000000180409560-0x0000000180409930
	private int AddRequestRows(FriendRequestItemData[] rows); // 0x0000000180407A80-0x0000000180407D20
	private void BuildSearchRows(Transform content, FriendSearchItemData[] list, string emptyText); // 0x0000000180409930-0x0000000180409EE0
	private void SendFriendRequest(FriendSearchItemData target); // 0x000000018040D470-0x000000018040D6B0
	private void AcceptRequest(FriendRequestItemData req); // 0x0000000180407960-0x0000000180407A80
	private void DeclineRequest(FriendRequestItemData req); // 0x000000018040A290-0x000000018040A380
	private void CancelRequest(FriendRequestItemData req); // 0x0000000180409EE0-0x0000000180409FD0
	private void PostAction(string url, string successMessage, Action onDone); // 0x000000018040CAE0-0x000000018040CC70
	private void OpenChat(FriendItemData friend); // 0x000000018040C650-0x000000018040C750
	private void InviteToRoom(FriendItemData friend); // 0x000000018040BA40-0x000000018040BC50
	private void OpenActionBox(FriendItemData friend, RectTransform anchor); // 0x000000018040C060-0x000000018040C650
	private void WireActionButton(string nodeName, Action action); // 0x000000018040E670-0x000000018040E7C0
	private void CloseActionBox(); // 0x0000000180409FD0-0x000000018040A050
	private void ShowConfirm(string message, Action onYes); // 0x000000018040D910-0x000000018040DC60
	private void SetPinned(FriendItemData friend, bool pinned); // 0x000000018040D6B0-0x000000018040D910
	private void SendEnergyGift(FriendItemData friend); // 0x000000018040D230-0x000000018040D470
	private void HandleFriendPush(ChatMessageDTO m); // 0x000000018040B230-0x000000018040B610
	private void HandleFriendMsg(ChatMessageDTO m); // 0x000000018040AF30-0x000000018040B0D0
	private void HandleFriendOnline(ChatMessageDTO m); // 0x000000018040B0D0-0x000000018040B230
	private void HandlePresenceChanged(string username, bool online, bool busy); // 0x000000018040B7F0-0x000000018040BA40
	private void HandleInviteFailed(string target, string reason); // 0x000000018040B610-0x000000018040B7F0
	[CompilerGenerated]
	private void _RewireAll_b__43_0(); // 0x000000018040DFF0-0x000000018040E150
	[CompilerGenerated]
	private void _RewireAll_b__43_1(); // 0x000000018040E150-0x000000018040E2B0
	[CompilerGenerated]
	private void _RewireAll_b__43_2(); // 0x000000018040E2B0-0x000000018040E400
	[CompilerGenerated]
	private void _RewireAll_b__43_3(); // 0x000000018040E400-0x000000018040E560
	[CompilerGenerated]
	private void _RewireAll_b__43_4(FriendItemData f); // 0x000000018040E560-0x000000018040E600
	[CompilerGenerated]
	private void _RewireAll_b__43_5(string _); // 0x000000018040E600-0x000000018040E670
	[CompilerGenerated]
	private void _FetchBadge_b__49_0(FriendBadgeData badge); // 0x000000018040DD40-0x000000018040DDC0
	[CompilerGenerated]
	private void _FetchFriends_b__51_0(FriendItemData[] list); // 0x000000018040DDC0-0x000000018040DE50
	[CompilerGenerated]
	private void _FetchFriends_b__51_1(string err); // 0x000000018040DE50-0x000000018040DF20
	[CompilerGenerated]
	private void _FetchRequests_b__52_0(FriendRequestsData data); // 0x000000018040DF20-0x000000018040DF30
	[CompilerGenerated]
	private void _DoSearch_b__53_0(FriendSearchItemData[] list); // 0x000000018040DC80-0x000000018040DD40
	[CompilerGenerated]
	private void _FetchSuggestions_b__54_0(FriendSearchItemData[] list); // 0x000000018040DF30-0x000000018040DFF0
	[CompilerGenerated]
	private void _AcceptRequest_b__60_0(); // 0x000000018040DC60-0x000000018040DC80
	[CompilerGenerated]
	private void _DeclineRequest_b__61_0(); // 0x000000018040DC60-0x000000018040DC80
}

