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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class Display_InvitableUser : MonoBehaviour, IHubSuspendable // TypeDefIndex: 20
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
	private const float REFRESH_DEBOUNCE_DELAY = 1f; // Metadata: 0x0064BF44
	private bool _subscribed; // 0x60
	private Source _source; // 0x64
	private Coroutine _loadRoutine; // 0x68
	private const string SUFFIX_BUSY = " (\u0111ang b\u1EADn)"; // Metadata: 0x0064BF48
	private const string SUFFIX_OFFLINE = " (ngo\u1EA1i tuy\u1EBFn)"; // Metadata: 0x0064BF57

	// Properties
	private string ApiUrl { get; } // 0x00000001802F1FB0-0x00000001802F2020 
	public Source CurrentSource { get; } // 0x00000001802F2020-0x00000001802F2030 
	private static bool UseWsOnlineUsers { get; } // 0x00000001802F2030-0x00000001802F2070 

	// Nested types
	public enum Source // TypeDefIndex: 21
	{
		Online = 0,
		Friends = 1
	}

	[Serializable]
	private class UserInfoEntry // TypeDefIndex: 22
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

		// Constructors
		public UserInfoEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 23
	{
		// Fields
		public FriendItemData[] friends; // 0x10
		public string error; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadFriends_b__0(FriendItemData[] list); // 0x00000001802FAED0-0x00000001802FAF70
		internal void _LoadFriends_b__1(string err); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 24
	{
		// Fields
		public bool done; // 0x10
		public List<OnlineUserInfoDTO> wsResult; // 0x18

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadUsersAndWatch_b__0(List<OnlineUserInfoDTO> list); // 0x00000001802FB060-0x00000001802FB080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass35_0 // TypeDefIndex: 25
	{
		// Fields
		public Display_InvitableUser __4__this; // 0x10
		public string targetName; // 0x18
		public Button capturedBtn; // 0x20

		// Constructors
		public __c__DisplayClass35_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CreateItem_b__0(); // 0x00000001802FB080-0x00000001802FB130
	}

	[CompilerGenerated]
	private sealed class _LoadFriends_d__33 : IEnumerator<object> // TypeDefIndex: 26
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20
		private __c__DisplayClass33_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadFriends_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001802F9870-0x00000001802F9D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802F9D50-0x00000001802F9D90
	}

	[CompilerGenerated]
	private sealed class _LoadUsersAndWatch_d__34 : IEnumerator<object> // TypeDefIndex: 27
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private __c__DisplayClass34_0 __8__1; // 0x20
		public Display_InvitableUser __4__this; // 0x28
		private UserInfoEntry[] _entries_5__2; // 0x30
		private Action<List<OnlineUserInfoDTO>> _onResp_5__3; // 0x38
		private float _deadline_5__4; // 0x40
		private UnityWebRequest _req_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadUsersAndWatch_d__34(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FA8B0-0x00000001802FA910
		private bool MoveNext(); // 0x00000001802F9DC0-0x00000001802FA870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FA870-0x00000001802FA8B0
	}

	[CompilerGenerated]
	private sealed class _RefreshDebounced_d__30 : IEnumerator<object> // TypeDefIndex: 28
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Display_InvitableUser __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshDebounced_d__30(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802FAA10-0x00000001802FAB20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FAB20-0x00000001802FAB60
	}

	// Constructors
	public Display_InvitableUser(); // 0x00000001802F1D90-0x00000001802F1FB0

	// Methods
	public void SetSource(Source source); // 0x00000001802F1600-0x00000001802F16C0
	private void ReloadCurrent(); // 0x00000001802F1250-0x00000001802F1310
	private void OnEnable(); // 0x00000001802EFE30-0x00000001802F0020
	private void OnDisable(); // 0x00000001802EFCE0-0x00000001802EFE30
	public void OnHubSuspend(); // 0x00000001802F0060-0x00000001802F00A0
	public void OnHubResume(); // 0x00000001802F0020-0x00000001802F0060
	public void RefreshUserOnline(); // 0x00000001802F1240-0x00000001802F1250
	private void SubscribePresence(); // 0x00000001802F1790-0x00000001802F1A90
	private void UnsubscribePresence(); // 0x00000001802F1A90-0x00000001802F1D90
	private void OnPresenceChanged(string username, bool online, bool busy); // 0x00000001802F0360-0x00000001802F08D0
	private void OnOnlineListSnapshot(UserPresenceDTO[] users); // 0x00000001802F0140-0x00000001802F0360
	private void OnInviteFailed(string target, string friendly); // 0x00000001802F00A0-0x00000001802F0140
	private void ShowStatus(string msg); // 0x00000001802F16C0-0x00000001802F1790
	[IteratorStateMachine(typeof(_RefreshDebounced_d__30))]
	private IEnumerator RefreshDebounced(); // 0x00000001802F11D0-0x00000001802F1240
	[IteratorStateMachine(typeof(_LoadFriends_d__33))]
	private IEnumerator LoadFriends(); // 0x00000001802EFC00-0x00000001802EFC70
	[IteratorStateMachine(typeof(_LoadUsersAndWatch_d__34))]
	private IEnumerator LoadUsersAndWatch(); // 0x00000001802EFC70-0x00000001802EFCE0
	private void CreateItem(UserInfoEntry e); // 0x00000001802EF4D0-0x00000001802EFC00
	private static Transform ChildByName(Transform root, string name, int legacyIndex); // 0x00000001802EF1D0-0x00000001802EF310
	private void ApplyPresenceToItem(GameObject go, bool online, bool busy); // 0x00000001802EEE70-0x00000001802EF1D0
	private void OnSearchChanged(string input); // 0x00000001802F08D0-0x00000001802F0920
	private void ApplyFilter(string keyword); // 0x00000001802EE930-0x00000001802EEE70
	private bool SendInvite(string targetUsername); // 0x00000001802F1310-0x00000001802F1600
	private void ClearAllUI(); // 0x00000001802EF310-0x00000001802EF4D0
	private static UserInfoEntry[] ParseUsersWithInfo(string json); // 0x00000001802F0920-0x00000001802F11D0
}

