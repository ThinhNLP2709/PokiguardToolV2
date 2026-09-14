/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class Display_InvitableUser : MonoBehaviour, IHubSuspendable // TypeDefIndex: 28
{
	// Fields
	[Header("UI References")]
	[SerializeField]
	private GameObject userOnlineContainer; // 0x20
	[SerializeField]
	private GameObject invitableUserPrefab; // 0x28
	[SerializeField]
	private InputField searchInputField; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text searchStatusText; // 0x38
	private readonly Dictionary<string, GameObject> _itemsByUsername; // 0x40
	private readonly Dictionary<string, string> _displayNames; // 0x48
	private readonly Dictionary<string, bool> _onlineState; // 0x50
	private Coroutine _refreshDebounce; // 0x58
	private const float REFRESH_DEBOUNCE_DELAY = 1f; // Metadata: 0x005ED5B3
	private bool _subscribed; // 0x60
	private Source _source; // 0x64
	private readonly List<string> _order; // 0x68
	private readonly List<GameObject> _matched; // 0x70
	private int _page; // 0x78
	private InvitePagerUI _pager; // 0x80
	private Coroutine _loadRoutine; // 0x88
	private const string SUFFIX_BUSY = " (\u0111ang b\u1EADn)"; // Metadata: 0x005ED5B7
	private const string SUFFIX_OFFLINE = " (ngo\u1EA1i tuy\u1EBFn)"; // Metadata: 0x005ED5C6

	// Properties
	private string ApiUrl { get; } // 0x00000001802ADF80-0x00000001802AE000 
	private int PageSize { get; } // 0x00000001802AE000-0x00000001802AE260 
	public Source CurrentSource { get; } // 0x00000001802AE260-0x00000001802AE270 
	private bool KeepOffline { get; } // 0x00000001802AE570-0x00000001802AE580 
	private static bool UseWsOnlineUsers { get; } // 0x00000001802B08C0-0x00000001802B0910 

	// Nested types
	public enum Source // TypeDefIndex: 29
	{
		Online = 0,
		Friends = 1
	}

	[Serializable]
	private class UserInfoEntry // TypeDefIndex: 30
	{
		// Fields
		public string username; // 0x10
		public string name; // 0x18
		public string display; // 0x20
		public int lever; // 0x28
		public long avtId; // 0x30
		public bool online; // 0x38
		public bool busy; // 0x39
		public int weaponImageId; // 0x3C
		public string weaponRarity; // 0x40
		public string avatarLayers; // 0x48
		public int vipLevel; // 0x50

		// Constructors
		public UserInfoEntry(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass43_0 // TypeDefIndex: 31
	{
		// Fields
		public FriendItemData[] friends; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass43_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadFriends_b__0(FriendItemData[] list); // 0x00000001802B4EA0-0x00000001802B4F80
		internal void _LoadFriends_b__1(string err); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass44_0 // TypeDefIndex: 32
	{
		// Fields
		public bool done; // 0x10
		public List<OnlineUserInfoDTO> wsResult; // 0x18

		// Constructors
		public __c__DisplayClass44_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadUsersAndWatch_b__0(List<OnlineUserInfoDTO> list); // 0x00000001802B4FE0-0x00000001802B5040
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass46_0 // TypeDefIndex: 33
	{
		// Fields
		public Display_InvitableUser __4__this; // 0x10
		public string targetName; // 0x18
		public Button capturedBtn; // 0x20

		// Constructors
		public __c__DisplayClass46_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CreateItem_b__0(); // 0x00000001802B5040-0x00000001802B51C0
	}

	[CompilerGenerated]
	private sealed class _LoadFriends_d__43 : IEnumerator<object> // TypeDefIndex: 34
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20
		private __c__DisplayClass43_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadFriends_d__43(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001802B5230-0x00000001802B5A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802B5A80-0x00000001802B5AC0
	}

	[CompilerGenerated]
	private sealed class _LoadUsersAndWatch_d__44 : IEnumerator<object> // TypeDefIndex: 35
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass44_0 __8__1; // 0x20
		public Display_InvitableUser __4__this; // 0x28
		private UserInfoEntry[] _entries_5__2; // 0x30
		private Action<List<OnlineUserInfoDTO>> _onResp_5__3; // 0x38
		private float _deadline_5__4; // 0x40
		private UnityWebRequest _req_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadUsersAndWatch_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B5AC0-0x00000001802B5C20
		private bool MoveNext(); // 0x00000001802B5C20-0x00000001802B6AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802B6AF0-0x00000001802B6B30
	}

	[CompilerGenerated]
	private sealed class _RefreshDebounced_d__40 : IEnumerator<object> // TypeDefIndex: 36
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshDebounced_d__40(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802B6B40-0x00000001802B6D40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802B6D40-0x00000001802B6D80
	}

	// Constructors
	public Display_InvitableUser(); // 0x00000001802B44E0-0x00000001802B48B0

	// Methods
	public void SetSource(Source source); // 0x00000001802AE270-0x00000001802AE3C0
	private void ReloadCurrent(); // 0x00000001802AE3C0-0x00000001802AE570
	private void OnEnable(); // 0x00000001802AE580-0x00000001802AE8E0
	private void OnDisable(); // 0x00000001802AE8E0-0x00000001802AEB90
	private void EnsurePager(); // 0x00000001802AEB90-0x00000001802AF0A0
	private void GoToPage(int delta); // 0x00000001802AF0A0-0x00000001802AF3D0
	public void OnHubSuspend(); // 0x00000001802AF3D0-0x00000001802AF450
	public void OnHubResume(); // 0x00000001802AF450-0x00000001802AF4E0
	public void RefreshUserOnline(); // 0x00000001802AF4E0-0x00000001802AF4F0
	private void SubscribePresence(); // 0x00000001802AF4F0-0x00000001802AF9D0
	private void UnsubscribePresence(); // 0x00000001802AF9D0-0x00000001802AFEB0
	private void OnPresenceChanged(string username, bool online, bool busy); // 0x00000001802AFEB0-0x00000001802B0300
	private void OnOnlineListSnapshot(UserPresenceDTO[] users); // 0x00000001802B0300-0x00000001802B0630
	private void OnInviteFailed(string target, string friendly); // 0x00000001802B0630-0x00000001802B06E0
	private void ShowStatus(string msg); // 0x00000001802B06E0-0x00000001802B0820
	[IteratorStateMachine(typeof(_RefreshDebounced_d__40))]
	private IEnumerator RefreshDebounced(); // 0x00000001802B0820-0x00000001802B08C0
	[IteratorStateMachine(typeof(_LoadFriends_d__43))]
	private IEnumerator LoadFriends(); // 0x00000001802B0910-0x00000001802B09B0
	[IteratorStateMachine(typeof(_LoadUsersAndWatch_d__44))]
	private IEnumerator LoadUsersAndWatch(); // 0x00000001802B09B0-0x00000001802B0A50
	private static int CompareForDisplay(UserInfoEntry a, UserInfoEntry b); // 0x00000001802B0A50-0x00000001802B0BD0
	private void CreateItem(UserInfoEntry e); // 0x00000001802B0BD0-0x00000001802B1970
	private static Transform ChildByName(Transform root, string name, int legacyIndex); // 0x00000001802B1970-0x00000001802B1E80
	private void ApplyPresenceToItem(GameObject go, bool online, bool busy); // 0x00000001802B1E80-0x00000001802B24B0
	private void OnSearchChanged(string input); // 0x00000001802B24B0-0x00000001802B2510
	private void ApplyFilter(string keyword); // 0x00000001802B2510-0x00000001802B3230
	private static string BuildTotalLabel(Source source, bool noFilter, int onlineCount, int totalCount, int visibleCount); // 0x00000001802B3230-0x00000001802B3400
	private bool SendInvite(string targetUsername); // 0x00000001802B3400-0x00000001802B3840
	private void ClearAllUI(); // 0x00000001802B3840-0x00000001802B3B40
	private static UserInfoEntry[] ParseUsersWithInfo(string json); // 0x00000001802B3B40-0x00000001802B44E0
	[CompilerGenerated]
	private void _EnsurePager_b__29_0(); // 0x00000001802B48B0-0x00000001802B48C0
	[CompilerGenerated]
	private void _EnsurePager_b__29_1(); // 0x00000001802B48C0-0x00000001802B49D0
}

