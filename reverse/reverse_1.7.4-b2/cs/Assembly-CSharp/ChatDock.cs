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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatDock : MonoBehaviour // TypeDefIndex: 422
{
	// Fields
	[CompilerGenerated]
	private static ChatDock _Instance_k__BackingField; // 0x00
	private const string ButtonPrefabPath = "Prefabs/UI/ChatDockButton"; // Metadata: 0x0068B1EA
	private const string ButtonPrefabPathPoky = "Prefabs/UI/ChatDockButton_Poky"; // Metadata: 0x0068B204
	public const string SKIN_KEY = "ChatDock"; // Metadata: 0x0068B223
	private const string RemoteAddressRoot = "UIPanels/"; // Metadata: 0x0068B22C
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
	private const float SuppressPollSeconds = 0.25f; // Metadata: 0x0068B236
	private const float MentionToastCooldown = 8f; // Metadata: 0x0068B23A
	private float _lastMentionToastAt; // 0x78
	private int _badgeShown; // 0x7C

	// Properties
	public static ChatDock Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803699E0-0x0000000180369A30 0x0000000180369A30-0x0000000180369AA0
	private bool FxEnabled { get; } // 0x0000000180369970-0x00000001803699E0 

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadRemoteSkin_d__32 : IEnumerator<object> // TypeDefIndex: 423
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string fileName; // 0x20
		private string _address_5__2; // 0x28
		private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__3; // 0x30
		private AsyncOperationHandle<GameObject> _loadHandle_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRemoteSkin_d__32(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180376840-0x0000000180376880
		private bool MoveNext(); // 0x0000000180375F80-0x0000000180376800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180376800-0x0000000180376840
	}

	[CompilerGenerated]
	private sealed class _PrewarmRemoteSkins_d__30 : IEnumerator<object> // TypeDefIndex: 424
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatDock __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PrewarmRemoteSkins_d__30(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180377AF0-0x0000000180377C30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377C30-0x0000000180377C70
	}

	[CompilerGenerated]
	private sealed class _WatchSuppression_d__49 : IEnumerator<object> // TypeDefIndex: 425
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatDock __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchSuppression_d__49(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180378E30-0x0000000180378F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180378F00-0x0000000180379030
	}

	// Constructors
	public ChatDock(); // 0x00000001803698F0-0x0000000180369970
	static ChatDock(); // 0x00000001803697C0-0x00000001803698F0

	// Methods
	public static void Ensure(); // 0x0000000180366420-0x0000000180366710
	[IteratorStateMachine(typeof(_PrewarmRemoteSkins_d__30))]
	private IEnumerator PrewarmRemoteSkins(); // 0x0000000180368BA0-0x0000000180368C10
	private static bool RemoteSkinEnabled(); // 0x0000000180368E00-0x0000000180368E70
	[IteratorStateMachine(typeof(_LoadRemoteSkin_d__32))]
	private IEnumerator LoadRemoteSkin(string fileName); // 0x0000000180367810-0x0000000180367880
	private static GameObject RemoteSkin(string resourcePath); // 0x0000000180368E70-0x0000000180368F70
	private static bool HasMissingScript(GameObject root); // 0x0000000180367320-0x0000000180367400
	private static void WarnRemoteOnce(string msg); // 0x0000000180369690-0x0000000180369750
	private static void ScrubLegacyChatUI(); // 0x0000000180368F70-0x0000000180369060
	public static void NotifyTabViewed(bool teamTab); // 0x0000000180367CA0-0x0000000180367E70
	public static void NotifyChannelViewed(int channel); // 0x0000000180367A70-0x0000000180367C20
	private void Awake(); // 0x00000001803655C0-0x0000000180365760
	private void OnEnable(); // 0x00000001803683C0-0x0000000180368820
	private void OnDisable(); // 0x0000000180367FA0-0x00000001803683C0
	private void OnDestroy(); // 0x0000000180367E70-0x0000000180367FA0
	private void HandleSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180366EE0-0x0000000180367050
	private void RefreshVisibilityForScene(string sceneName); // 0x0000000180368D20-0x0000000180368E00
	public void SetSuppressed(bool suppressed); // 0x0000000180369060-0x0000000180369250
	public static void Suppress(bool suppressed); // 0x00000001803692E0-0x0000000180369410
	private void ApplyCanvasVisibility(); // 0x0000000180365530-0x00000001803655C0
	private void HandlePanelToggled(string panelKey, bool open); // 0x0000000180366EC0-0x0000000180366ED0
	[IteratorStateMachine(typeof(_WatchSuppression_d__49))]
	private IEnumerator WatchSuppression(); // 0x0000000180369750-0x00000001803697C0
	private void EvaluateSuppression(); // 0x0000000180366710-0x0000000180366910
	private static bool IsInRoom(); // 0x0000000180367480-0x00000001803674B0
	private static bool IsDailyCheckInOpen(ManagerQuangTruong hub); // 0x0000000180367400-0x0000000180367480
	private void PlayReappearPop(); // 0x0000000180368A20-0x0000000180368BA0
	private void HandleMatchEnter(MatchKind kind); // 0x0000000180366AE0-0x0000000180366D30
	private void HandleMatchExit(MatchKind kind); // 0x0000000180366D30-0x0000000180366EC0
	internal void NotifyDockMoved(string ctx, Vector2 pos); // 0x0000000180367C20-0x0000000180367CA0
	private void HandleRoomExited(string reasonOrRoomId); // 0x0000000180366ED0-0x0000000180366EE0
	private void HandleWorldIncoming(ChatMessageDTO m); // 0x0000000180367180-0x0000000180367320
	private void HandleTeamIncoming(ChatMessageDTO m); // 0x00000001803670C0-0x0000000180367180
	private void HandleTeamEmoteIncoming(ChatMessageDTO m); // 0x0000000180367050-0x00000001803670C0
	private void BumpTeamUnread(); // 0x00000001803663A0-0x0000000180366420
	private void HandleGuildIncoming(ChatMessageDTO m); // 0x0000000180366910-0x0000000180366A70
	private void HandleGuildMembershipChanged(bool hasGuild); // 0x0000000180366A70-0x0000000180366AE0
	private void NoteMention(ChatMessageDTO m, bool viewing); // 0x0000000180367880-0x0000000180367A70
	private static string StripMarkup(string s); // 0x0000000180369250-0x00000001803692E0
	private static bool IsOwnMessage(string username); // 0x00000001803674B0-0x0000000180367570
	private void RefreshBadge(); // 0x0000000180368C10-0x0000000180368D20
	private void PlayBadgePop(); // 0x0000000180368820-0x0000000180368A20
	internal static GameObject LoadChatPrefab(string legacyPath, string pokyPath); // 0x0000000180367570-0x0000000180367810
	private void BuildButton(); // 0x0000000180365DD0-0x00000001803663A0
	public static GameObject BuildButtonHierarchy(Transform parent); // 0x0000000180365760-0x0000000180365DD0
	[CompilerGenerated]
	private void _PlayBadgePop_b__71_0(); // 0x0000000180369570-0x0000000180369690
	[CompilerGenerated]
	private void _BuildButton_b__75_0(); // 0x0000000180369410-0x0000000180369570
}

