//Type is in global namespace

public class Display_InvitableUser : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public bool done; //Field offset: 0x10
		public List<OnlineUserInfoDTO> wsResult; //Field offset: 0x18

		public <>c__DisplayClass24_0() { }

		internal void <LoadUsersAndWatch>b__0(List<OnlineUserInfoDTO> list) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public Display_InvitableUser <>4__this; //Field offset: 0x10
		public string targetName; //Field offset: 0x18
		public Button capturedBtn; //Field offset: 0x20

		public <>c__DisplayClass25_0() { }

		internal void <CreateItem>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <LoadUsersAndWatch>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private <>c__DisplayClass24_0 <>8__1; //Field offset: 0x20
		public Display_InvitableUser <>4__this; //Field offset: 0x28
		private UserInfoEntry[] <entries>5__2; //Field offset: 0x30
		private Action<List`1<OnlineUserInfoDTO>> <onResp>5__3; //Field offset: 0x38
		private float <deadline>5__4; //Field offset: 0x40
		private UnityWebRequest <req>5__5; //Field offset: 0x48

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <LoadUsersAndWatch>d__24(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RefreshDebounced>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Display_InvitableUser <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RefreshDebounced>d__21(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class UserInfoEntry
	{
		public string username; //Field offset: 0x10
		public string name; //Field offset: 0x18
		public int lever; //Field offset: 0x20
		public long avtId; //Field offset: 0x28
		public bool online; //Field offset: 0x30
		public bool busy; //Field offset: 0x31
		public int weaponImageId; //Field offset: 0x34
		public string weaponRarity; //Field offset: 0x38

		public UserInfoEntry() { }

	}

	private const float REFRESH_DEBOUNCE_DELAY = 1; //Field offset: 0x0
	[Header("UI References")]
	[SerializeField]
	private GameObject userOnlineContainer; //Field offset: 0x20
	[SerializeField]
	private GameObject invitableUserPrefab; //Field offset: 0x28
	[SerializeField]
	private InputField searchInputField; //Field offset: 0x30
	[SerializeField]
	private Text searchStatusText; //Field offset: 0x38
	private readonly Dictionary<String, GameObject> _itemsByUsername; //Field offset: 0x40
	private readonly Dictionary<String, String> _displayNames; //Field offset: 0x48
	private readonly Dictionary<String, Boolean> _onlineState; //Field offset: 0x50
	private Coroutine _refreshDebounce; //Field offset: 0x58
	private bool _subscribed; //Field offset: 0x60

	private string ApiUrl
	{
		private get { } //Length: 102
	}

	private static bool UseWsOnlineUsers
	{
		private get { } //Length: 63
	}

	public Display_InvitableUser() { }

	private void ApplyFilter(string keyword) { }

	private void ApplyPresenceToItem(GameObject go, bool online, bool busy) { }

	private static Transform ChildByName(Transform root, string name, int legacyIndex) { }

	private void ClearAllUI() { }

	private void CreateItem(UserInfoEntry e) { }

	private string get_ApiUrl() { }

	private static bool get_UseWsOnlineUsers() { }

	[IteratorStateMachine(typeof(<LoadUsersAndWatch>d__24))]
	private IEnumerator LoadUsersAndWatch() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnInviteFailed(string target, string friendly) { }

	private void OnOnlineListSnapshot(UserPresenceDTO[] users) { }

	private void OnPresenceChanged(string username, bool online, bool busy) { }

	private void OnSearchChanged(string input) { }

	private static UserInfoEntry[] ParseUsersWithInfo(string json) { }

	[IteratorStateMachine(typeof(<RefreshDebounced>d__21))]
	private IEnumerator RefreshDebounced() { }

	public void RefreshUserOnline() { }

	private bool SendInvite(string targetUsername) { }

	private void ShowStatus(string msg) { }

	private void SubscribePresence() { }

	private void UnsubscribePresence() { }

}

