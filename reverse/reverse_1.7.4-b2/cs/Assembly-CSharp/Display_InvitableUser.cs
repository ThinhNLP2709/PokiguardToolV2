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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class Display_InvitableUser : MonoBehaviour, IHubSuspendable // TypeDefIndex: 25
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
	private const float REFRESH_DEBOUNCE_DELAY = 1f; // Metadata: 0x0068A95D
	private bool _subscribed; // 0x60
	private Source _source; // 0x64
	private readonly List<string> _order; // 0x68
	private readonly List<GameObject> _matched; // 0x70
	private int _page; // 0x78
	private InvitePagerUI _pager; // 0x80
	private Coroutine _loadRoutine; // 0x88
	private const string SUFFIX_BUSY = " (\u0111ang b\u1EADn)"; // Metadata: 0x0068A961
	private const string SUFFIX_OFFLINE = " (ngo\u1EA1i tuy\u1EBFn)"; // Metadata: 0x0068A970

	// Properties
	private string ApiUrl { get; } // 0x00000001802FACF0-0x00000001802FAD60 
	private int PageSize { get; } // 0x00000001802FAD90-0x00000001802FAE60 
	public Source CurrentSource { get; } // 0x00000001802FAD60-0x00000001802FAD70 
	private bool KeepOffline { get; } // 0x00000001802FAD80-0x00000001802FAD90 
	public static bool ForceGuildSource { get; } // 0x00000001802FAD70-0x00000001802FAD80 
	private static bool UseWsOnlineUsers { get; } // 0x00000001802FAE60-0x00000001802FAEA0 

	// Nested types
	public enum Source // TypeDefIndex: 26
	{
		Online = 0,
		Friends = 1,
		Guild = 2
	}

	[Serializable]
	private class UserInfoEntry // TypeDefIndex: 27
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

		// Constructors
		public UserInfoEntry(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass45_0 // TypeDefIndex: 28
	{
		// Fields
		public FriendItemData[] friends; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass45_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadFriends_b__0(FriendItemData[] list); // 0x0000000180316FE0-0x0000000180317080
		internal void _LoadFriends_b__1(string err); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass46_0 // TypeDefIndex: 29
	{
		// Fields
		public GuildDetailData detail; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass46_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadGuildMembers_b__0(GuildDetailData d); // 0x0000000180317090-0x00000001803170A0
		internal void _LoadGuildMembers_b__1(string err); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 30
	{
		// Fields
		public bool done; // 0x10
		public List<OnlineUserInfoDTO> wsResult; // 0x18

		// Constructors
		public __c__DisplayClass47_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadUsersAndWatch_b__0(List<OnlineUserInfoDTO> list); // 0x00000001803170A0-0x00000001803170C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass49_0 // TypeDefIndex: 31
	{
		// Fields
		public Display_InvitableUser __4__this; // 0x10
		public string targetName; // 0x18
		public Button capturedBtn; // 0x20

		// Constructors
		public __c__DisplayClass49_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CreateItem_b__0(); // 0x00000001803170C0-0x0000000180317170
	}

	[CompilerGenerated]
	private sealed class _LoadFriends_d__45 : IEnumerator<object> // TypeDefIndex: 32
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20
		private __c__DisplayClass45_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadFriends_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180315230-0x0000000180315720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180315720-0x0000000180315760
	}

	[CompilerGenerated]
	private sealed class _LoadGuildMembers_d__46 : IEnumerator<object> // TypeDefIndex: 33
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20
		private __c__DisplayClass46_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadGuildMembers_d__46(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180315790-0x0000000180315DC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180315DC0-0x0000000180315E00
	}

	[CompilerGenerated]
	private sealed class _LoadUsersAndWatch_d__47 : IEnumerator<object> // TypeDefIndex: 34
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass47_0 __8__1; // 0x20
		public Display_InvitableUser __4__this; // 0x28
		private UserInfoEntry[] _entries_5__2; // 0x30
		private Action<List<OnlineUserInfoDTO>> _onResp_5__3; // 0x38
		private float _deadline_5__4; // 0x40
		private UnityWebRequest _req_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadUsersAndWatch_d__47(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180316AA0-0x0000000180316B00
		private bool MoveNext(); // 0x0000000180315F40-0x0000000180316A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180316A60-0x0000000180316AA0
	}

	[CompilerGenerated]
	private sealed class _RefreshDebounced_d__42 : IEnumerator<object> // TypeDefIndex: 35
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshDebounced_d__42(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180316E70-0x0000000180316F80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180316F80-0x0000000180316FC0
	}

	// Constructors
	public Display_InvitableUser(); // 0x00000001802FAA40-0x00000001802FACF0

	// Methods
	public void SetSource(Source source); // 0x00000001802FA4D0-0x00000001802FA590
	private void ReloadCurrent(); // 0x00000001802FA0F0-0x00000001802FA240
	private void OnEnable(); // 0x00000001802F8C60-0x00000001802F8E80
	private void OnDisable(); // 0x00000001802F8B10-0x00000001802F8C60
	private void EnsurePager(); // 0x00000001802F85B0-0x00000001802F88B0
	private void GoToPage(int delta); // 0x00000001802F88B0-0x00000001802F89C0
	public void OnHubSuspend(); // 0x00000001802F8EC0-0x00000001802F8F00
	public void OnHubResume(); // 0x00000001802F8E80-0x00000001802F8EC0
	public void RefreshUserOnline(); // 0x00000001802FA0E0-0x00000001802FA0F0
	private void SubscribePresence(); // 0x00000001802FA660-0x00000001802FA840
	private void UnsubscribePresence(); // 0x00000001802FA860-0x00000001802FAA40
	private void OnPresenceChanged(string username, bool online, bool busy); // 0x00000001802F91C0-0x00000001802F9730
	private void OnOnlineListSnapshot(UserPresenceDTO[] users); // 0x00000001802F8FA0-0x00000001802F91C0
	private void OnInviteFailed(string target, string friendly); // 0x00000001802F8F00-0x00000001802F8FA0
	private void ShowStatus(string msg); // 0x00000001802FA590-0x00000001802FA660
	[IteratorStateMachine(typeof(_RefreshDebounced_d__42))]
	private IEnumerator RefreshDebounced(); // 0x00000001802FA070-0x00000001802FA0E0
	[IteratorStateMachine(typeof(_LoadFriends_d__45))]
	private IEnumerator LoadFriends(); // 0x00000001802F89C0-0x00000001802F8A30
	[IteratorStateMachine(typeof(_LoadGuildMembers_d__46))]
	private IEnumerator LoadGuildMembers(); // 0x00000001802F8A30-0x00000001802F8AA0
	[IteratorStateMachine(typeof(_LoadUsersAndWatch_d__47))]
	private IEnumerator LoadUsersAndWatch(); // 0x00000001802F8AA0-0x00000001802F8B10
	private static int CompareForDisplay(UserInfoEntry a, UserInfoEntry b); // 0x00000001802F7CF0-0x00000001802F7DD0
	private void CreateItem(UserInfoEntry e); // 0x00000001802F7DD0-0x00000001802F85B0
	private static Transform ChildByName(Transform root, string name, int legacyIndex); // 0x00000001802F7990-0x00000001802F7AD0
	private void ApplyPresenceToItem(GameObject go, bool online, bool busy); // 0x00000001802F73C0-0x00000001802F7720
	private void OnSearchChanged(string input); // 0x00000001802F9730-0x00000001802F9790
	private void ApplyFilter(string keyword); // 0x00000001802F6C40-0x00000001802F73C0
	private static string BuildTotalLabel(Source source, bool noFilter, int onlineCount, int totalCount, int visibleCount); // 0x00000001802F7720-0x00000001802F7990
	private bool SendInvite(string targetUsername); // 0x00000001802FA240-0x00000001802FA4D0
	private void ClearAllUI(); // 0x00000001802F7AD0-0x00000001802F7CF0
	private static UserInfoEntry[] ParseUsersWithInfo(string json); // 0x00000001802F9790-0x00000001802FA070
	[CompilerGenerated]
	private void _EnsurePager_b__31_0(); // 0x00000001802FA840-0x00000001802FA850
	[CompilerGenerated]
	private void _EnsurePager_b__31_1(); // 0x00000001802FA850-0x00000001802FA860
}

