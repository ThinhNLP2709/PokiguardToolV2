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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ChatDock : MonoBehaviour // TypeDefIndex: 476
{
	// Fields
	[CompilerGenerated]
	private static ChatDock _Instance_k__BackingField; // 0x00
	private const string ButtonPrefabPath = "Prefabs/UI/ChatDockButton"; // Metadata: 0x005EF4B7
	private const string ButtonPrefabPathPoky = "Prefabs/UI/ChatDockButton_Poky"; // Metadata: 0x005EF4D1
	public const string SKIN_KEY = "ChatDock"; // Metadata: 0x005EF4F0
	private const string RemoteAddressRoot = "UIPanels/"; // Metadata: 0x005EF4F9
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
	private const float SuppressPollSeconds = 0.25f; // Metadata: 0x005EF503
	private const float MentionToastCooldown = 8f; // Metadata: 0x005EF507
	private float _lastMentionToastAt; // 0x78
	private int _badgeShown; // 0x7C

	// Properties
	public static ChatDock Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180384680-0x00000001803846E0 0x00000001803846E0-0x0000000180384790
	private bool FxEnabled { get; } // 0x0000000180388EE0-0x0000000180388F60 

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
		void IDisposable.Dispose(); // 0x000000018038AFD0-0x000000018038B050
		private bool MoveNext(); // 0x000000018038B050-0x000000018038BB70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038BB70-0x000000018038BBB0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018038BBB0-0x000000018038BD40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038BD40-0x000000018038BD80
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
		private bool MoveNext(); // 0x000000018038BD80-0x000000018038BEF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018038BEF0-0x000000018038BF30
	}

	// Constructors
	public ChatDock(); // 0x000000018038A980-0x000000018038AA30
	static ChatDock(); // 0x000000018038AA30-0x000000018038AB60

	// Methods
	public static void Ensure(); // 0x0000000180384790-0x0000000180384BB0
	[IteratorStateMachine(typeof(_PrewarmRemoteSkins_d__30))]
	private IEnumerator PrewarmRemoteSkins(); // 0x0000000180384BB0-0x0000000180384C50
	private static bool RemoteSkinEnabled(); // 0x0000000180384C50-0x0000000180384CD0
	[IteratorStateMachine(typeof(_LoadRemoteSkin_d__32))]
	private IEnumerator LoadRemoteSkin(string fileName); // 0x0000000180384CD0-0x0000000180384D70
	private static GameObject RemoteSkin(string resourcePath); // 0x0000000180384D70-0x0000000180384E90
	private static bool HasMissingScript(GameObject root); // 0x0000000180384E90-0x0000000180385080
	private static void WarnRemoteOnce(string msg); // 0x0000000180385080-0x0000000180385160
	private static void ScrubLegacyChatUI(); // 0x0000000180385160-0x0000000180385360
	public static void NotifyTabViewed(bool teamTab); // 0x0000000180385360-0x00000001803853B0
	public static void NotifyChannelViewed(int channel); // 0x00000001803853B0-0x0000000180385560
	private void Awake(); // 0x0000000180385560-0x00000001803857C0
	private void OnEnable(); // 0x00000001803857C0-0x0000000180385EF0
	private void OnDisable(); // 0x0000000180385EF0-0x0000000180386590
	private void OnDestroy(); // 0x0000000180386590-0x0000000180386740
	private void HandleSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180386740-0x00000001803869F0
	private void RefreshVisibilityForScene(string sceneName); // 0x00000001803869F0-0x0000000180386B70
	public void SetSuppressed(bool suppressed); // 0x0000000180386B70-0x0000000180386C10
	public static void Suppress(bool suppressed); // 0x0000000180386C10-0x0000000180386D90
	private void ApplyCanvasVisibility(); // 0x0000000180386D90-0x0000000180386EE0
	private void HandlePanelToggled(string panelKey, bool open); // 0x0000000180386EE0-0x0000000180386EF0
	[IteratorStateMachine(typeof(_WatchSuppression_d__49))]
	private IEnumerator WatchSuppression(); // 0x0000000180386EF0-0x0000000180386F90
	private void EvaluateSuppression(); // 0x0000000180386F90-0x0000000180387310
	private static bool IsInRoom(); // 0x0000000180387310-0x0000000180387340
	private static bool IsDailyCheckInOpen(ManagerQuangTruong hub); // 0x0000000180387340-0x0000000180387440
	private void PlayReappearPop(); // 0x0000000180387440-0x00000001803876F0
	private void HandleMatchEnter(MatchKind kind); // 0x00000001803876F0-0x0000000180387A40
	private void HandleMatchExit(MatchKind kind); // 0x0000000180387A40-0x0000000180387C80
	internal void NotifyDockMoved(string ctx, Vector2 pos); // 0x0000000180387C80-0x0000000180387D30
	private void HandleRoomExited(string reasonOrRoomId); // 0x0000000180387D30-0x0000000180387D40
	private void HandleWorldIncoming(ChatMessageDTO m); // 0x0000000180387D40-0x0000000180387FD0
	private void HandleTeamIncoming(ChatMessageDTO m); // 0x0000000180387FD0-0x0000000180388090
	private void HandleTeamEmoteIncoming(ChatMessageDTO m); // 0x0000000180388090-0x0000000180388110
	private void BumpTeamUnread(); // 0x0000000180388110-0x00000001803881D0
	private void HandleGuildIncoming(ChatMessageDTO m); // 0x00000001803881D0-0x00000001803883B0
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x00000001803883B0-0x0000000180388430
	private void NoteMention(ChatMessageDTO m, bool viewing); // 0x0000000180388430-0x0000000180388690
	private static string StripMarkup(string s); // 0x0000000180388690-0x0000000180388710
	private static bool IsOwnMessage(string username); // 0x0000000180388710-0x00000001803888E0
	private void RefreshBadge(); // 0x00000001803888E0-0x0000000180388BA0
	private void PlayBadgePop(); // 0x0000000180388BA0-0x0000000180388EE0
	internal static GameObject LoadChatPrefab(string legacyPath, string pokyPath); // 0x0000000180388F60-0x0000000180389340
	private void BuildButton(); // 0x0000000180389340-0x0000000180389F70
	public static GameObject BuildButtonHierarchy(Transform parent); // 0x0000000180389F70-0x000000018038A980
	[CompilerGenerated]
	private void _PlayBadgePop_b__71_0(); // 0x000000018038AB60-0x000000018038AD50
	[CompilerGenerated]
	private void _BuildButton_b__75_0(); // 0x000000018038AD50-0x000000018038AFD0
}

