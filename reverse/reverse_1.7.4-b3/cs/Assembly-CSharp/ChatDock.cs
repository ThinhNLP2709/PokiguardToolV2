/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ChatDock : MonoBehaviour // TypeDefIndex: 476
{
	// Fields
	[CompilerGenerated]
	private static ChatDock _Instance_k__BackingField; // 0x00
	private const string ButtonPrefabPath = "Prefabs/UI/ChatDockButton"; // Metadata: 0x005EE0E7
	private const string ButtonPrefabPathPoky = "Prefabs/UI/ChatDockButton_Poky"; // Metadata: 0x005EE101
	public const string SKIN_KEY = "ChatDock"; // Metadata: 0x005EE120
	private const string RemoteAddressRoot = "UIPanels/"; // Metadata: 0x005EE129
	private static readonly Dictionary<string, GameObject> _remoteSkins; // 0x08
	private static bool _remoteWarned; // 0x10
	private static bool _prewarmDone; // 0x11
	private static readonly Vector2 BtnPosHubDefault; // 0x14
	private Canvas _canvas; // 0x20
	private RectTransform _btnRect; // 0x28
	private GameObject _badge; // 0x30
	private UnityEngine.UI.Text _badgeText; // 0x38
	private ChatDockDrag _drag; // 0x40
	private Vector2 _btnPosHub; // 0x48
	private Vector2 _btnPosMatch; // 0x50
	private bool _matchPosKnown; // 0x58
	private int _unreadWorld; // 0x5C
	private int _unreadTeam; // 0x60
	private int _unreadGuild; // 0x64
	private bool _sceneVisible; // 0x68
	private bool _suppressed; // 0x69
	private bool _inMatch; // 0x6A
	private bool _skinBehaviour; // 0x6B
	private Coroutine _watchCo; // 0x70
	private const float SuppressPollSeconds = 0.25f; // Metadata: 0x005EE133
	private const float MentionToastCooldown = 8f; // Metadata: 0x005EE137
	private float _lastMentionToastAt; // 0x78
	private int _badgeShown; // 0x7C

	// Properties
	public static ChatDock Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803844D0-0x0000000180384530 0x0000000180384530-0x00000001803845E0
	private bool FxEnabled { get; } // 0x0000000180388D30-0x0000000180388DB0 

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadRemoteSkin_d__32 : IEnumerator<object> // TypeDefIndex: 477
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string fileName; // 0x20
		private string _address_5__2; // 0x28
		private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__3; // 0x30
		private AsyncOperationHandle<GameObject> _loadHandle_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRemoteSkin_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018038AE20-0x000000018038AEA0
		private bool MoveNext(); // 0x000000018038AEA0-0x000000018038B9C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038B9C0-0x000000018038BA00
	}

	[CompilerGenerated]
	private sealed class _PrewarmRemoteSkins_d__30 : IEnumerator<object> // TypeDefIndex: 478
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatDock __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PrewarmRemoteSkins_d__30(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018038BA00-0x000000018038BB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038BB90-0x000000018038BBD0
	}

	[CompilerGenerated]
	private sealed class _WatchSuppression_d__49 : IEnumerator<object> // TypeDefIndex: 479
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatDock __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchSuppression_d__49(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x000000018038BBD0-0x000000018038BD40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038BD40-0x000000018038BD80
	}

	// Constructors
	public ChatDock(); // 0x000000018038A7D0-0x000000018038A880
	static ChatDock(); // 0x000000018038A880-0x000000018038A9B0

	// Methods
	public static void Ensure(); // 0x00000001803845E0-0x0000000180384A00
	[IteratorStateMachine(typeof(_PrewarmRemoteSkins_d__30))]
	private IEnumerator PrewarmRemoteSkins(); // 0x0000000180384A00-0x0000000180384AA0
	private static bool RemoteSkinEnabled(); // 0x0000000180384AA0-0x0000000180384B20
	[IteratorStateMachine(typeof(_LoadRemoteSkin_d__32))]
	private IEnumerator LoadRemoteSkin(string fileName); // 0x0000000180384B20-0x0000000180384BC0
	private static GameObject RemoteSkin(string resourcePath); // 0x0000000180384BC0-0x0000000180384CE0
	private static bool HasMissingScript(GameObject root); // 0x0000000180384CE0-0x0000000180384ED0
	private static void WarnRemoteOnce(string msg); // 0x0000000180384ED0-0x0000000180384FB0
	private static void ScrubLegacyChatUI(); // 0x0000000180384FB0-0x00000001803851B0
	public static void NotifyTabViewed(bool teamTab); // 0x00000001803851B0-0x0000000180385200
	public static void NotifyChannelViewed(int channel); // 0x0000000180385200-0x00000001803853B0
	private void Awake(); // 0x00000001803853B0-0x0000000180385610
	private void OnEnable(); // 0x0000000180385610-0x0000000180385D40
	private void OnDisable(); // 0x0000000180385D40-0x00000001803863E0
	private void OnDestroy(); // 0x00000001803863E0-0x0000000180386590
	private void HandleSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180386590-0x0000000180386840
	private void RefreshVisibilityForScene(string sceneName); // 0x0000000180386840-0x00000001803869C0
	public void SetSuppressed(bool suppressed); // 0x00000001803869C0-0x0000000180386A60
	public static void Suppress(bool suppressed); // 0x0000000180386A60-0x0000000180386BE0
	private void ApplyCanvasVisibility(); // 0x0000000180386BE0-0x0000000180386D30
	private void HandlePanelToggled(string panelKey, bool open); // 0x0000000180386D30-0x0000000180386D40
	[IteratorStateMachine(typeof(_WatchSuppression_d__49))]
	private IEnumerator WatchSuppression(); // 0x0000000180386D40-0x0000000180386DE0
	private void EvaluateSuppression(); // 0x0000000180386DE0-0x0000000180387160
	private static bool IsInRoom(); // 0x0000000180387160-0x0000000180387190
	private static bool IsDailyCheckInOpen(ManagerQuangTruong hub); // 0x0000000180387190-0x0000000180387290
	private void PlayReappearPop(); // 0x0000000180387290-0x0000000180387540
	private void HandleMatchEnter(MatchKind kind); // 0x0000000180387540-0x0000000180387890
	private void HandleMatchExit(MatchKind kind); // 0x0000000180387890-0x0000000180387AD0
	internal void NotifyDockMoved(string ctx, Vector2 pos); // 0x0000000180387AD0-0x0000000180387B80
	private void HandleRoomExited(string reasonOrRoomId); // 0x0000000180387B80-0x0000000180387B90
	private void HandleWorldIncoming(ChatMessageDTO m); // 0x0000000180387B90-0x0000000180387E20
	private void HandleTeamIncoming(ChatMessageDTO m); // 0x0000000180387E20-0x0000000180387EE0
	private void HandleTeamEmoteIncoming(ChatMessageDTO m); // 0x0000000180387EE0-0x0000000180387F60
	private void BumpTeamUnread(); // 0x0000000180387F60-0x0000000180388020
	private void HandleGuildIncoming(ChatMessageDTO m); // 0x0000000180388020-0x0000000180388200
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x0000000180388200-0x0000000180388280
	private void NoteMention(ChatMessageDTO m, bool viewing); // 0x0000000180388280-0x00000001803884E0
	private static string StripMarkup(string s); // 0x00000001803884E0-0x0000000180388560
	private static bool IsOwnMessage(string username); // 0x0000000180388560-0x0000000180388730
	private void RefreshBadge(); // 0x0000000180388730-0x00000001803889F0
	private void PlayBadgePop(); // 0x00000001803889F0-0x0000000180388D30
	internal static GameObject LoadChatPrefab(string legacyPath, string pokyPath); // 0x0000000180388DB0-0x0000000180389190
	private void BuildButton(); // 0x0000000180389190-0x0000000180389DC0
	public static GameObject BuildButtonHierarchy(Transform parent); // 0x0000000180389DC0-0x000000018038A7D0
	[CompilerGenerated]
	private void _PlayBadgePop_b__71_0(); // 0x000000018038A9B0-0x000000018038ABA0
	[CompilerGenerated]
	private void _BuildButton_b__75_0(); // 0x000000018038ABA0-0x000000018038AE20
}

