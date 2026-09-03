/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ChatDock : MonoBehaviour // TypeDefIndex: 372
{
	// Fields
	[CompilerGenerated]
	private static ChatDock _Instance_k__BackingField; // 0x00
	private const string ButtonPrefabPath = "Prefabs/UI/ChatDockButton"; // Metadata: 0x0064C232
	private const string ButtonPrefabPathPoky = "Prefabs/UI/ChatDockButton_Poky"; // Metadata: 0x0064C24C
	public const string SKIN_KEY = "ChatDock"; // Metadata: 0x0064C26B
	private static readonly Vector2 BtnPosHubDefault; // 0x08
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
	private bool _sceneVisible; // 0x64
	private bool _suppressed; // 0x65
	private bool _inMatch; // 0x66
	private bool _skinBehaviour; // 0x67
	private Coroutine _watchCo; // 0x68
	private const float SuppressPollSeconds = 0.25f; // Metadata: 0x0064C274
	private const float MentionToastCooldown = 8f; // Metadata: 0x0064C278
	private float _lastMentionToastAt; // 0x70

	// Properties
	public static ChatDock Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031A280-0x000000018031A2D0 0x000000018031A2D0-0x000000018031A340

	// Nested types
	[CompilerGenerated]
	private sealed class _WatchSuppression_d__37 : IEnumerator<object> // TypeDefIndex: 373
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatDock __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchSuppression_d__37(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180332EF0-0x0000000180332FC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180332FC0-0x0000000180333000
	}

	// Constructors
	public ChatDock(); // 0x000000018031A200-0x000000018031A280
	static ChatDock(); // 0x000000018031A1B0-0x000000018031A200

	// Methods
	public static void Ensure(); // 0x0000000180317910-0x0000000180317B90
	private static void ScrubLegacyChatUI(); // 0x0000000180319BA0-0x0000000180319C90
	public static void NotifyTabViewed(bool teamTab); // 0x0000000180318AC0-0x0000000180318C90
	private void Awake(); // 0x0000000180316AE0-0x0000000180316C80
	private void OnEnable(); // 0x00000001803192F0-0x0000000180319860
	private void OnDisable(); // 0x0000000180318DC0-0x00000001803192F0
	private void OnDestroy(); // 0x0000000180318C90-0x0000000180318DC0
	private void HandleSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180318170-0x00000001803182C0
	private void RefreshVisibilityForScene(string sceneName); // 0x0000000180319AD0-0x0000000180319BA0
	public void SetSuppressed(bool suppressed); // 0x0000000180319C90-0x0000000180319E40
	public static void Suppress(bool suppressed); // 0x0000000180319ED0-0x000000018031A000
	private void ApplyCanvasVisibility(); // 0x0000000180316A50-0x0000000180316AE0
	private void HandlePanelToggled(string panelKey, bool open); // 0x0000000180318150-0x0000000180318160
	[IteratorStateMachine(typeof(_WatchSuppression_d__37))]
	private IEnumerator WatchSuppression(); // 0x000000018031A140-0x000000018031A1B0
	private void EvaluateSuppression(); // 0x0000000180317B90-0x0000000180317D90
	private static bool IsInRoom(); // 0x0000000180318620-0x0000000180318650
	private static bool IsDailyCheckInOpen(ManagerQuangTruong hub); // 0x00000001803185A0-0x0000000180318620
	private void PlayReappearPop(); // 0x0000000180319860-0x00000001803199E0
	private void HandleMatchEnter(MatchKind kind); // 0x0000000180317D90-0x0000000180317FC0
	private void HandleMatchExit(MatchKind kind); // 0x0000000180317FC0-0x0000000180318150
	internal void NotifyDockMoved(string ctx, Vector2 pos); // 0x0000000180318A40-0x0000000180318AC0
	private void HandleRoomExited(string reasonOrRoomId); // 0x0000000180318160-0x0000000180318170
	private void HandleWorldIncoming(ChatMessageDTO m); // 0x0000000180318420-0x00000001803185A0
	private void HandleTeamIncoming(ChatMessageDTO m); // 0x0000000180318360-0x0000000180318420
	private void HandleTeamEmoteIncoming(ChatMessageDTO m); // 0x00000001803182C0-0x0000000180318360
	private void BumpTeamUnread(); // 0x00000001803178C0-0x0000000180317910
	private void NoteMention(ChatMessageDTO m, bool viewing); // 0x0000000180318880-0x0000000180318A40
	private static string StripMarkup(string s); // 0x0000000180319E40-0x0000000180319ED0
	private static bool IsOwnMessage(string username); // 0x0000000180318650-0x0000000180318710
	private void RefreshBadge(); // 0x00000001803199E0-0x0000000180319AD0
	internal static GameObject LoadChatPrefab(string legacyPath, string pokyPath); // 0x0000000180318710-0x0000000180318880
	private void BuildButton(); // 0x00000001803172F0-0x00000001803178C0
	public static GameObject BuildButtonHierarchy(Transform parent); // 0x0000000180316C80-0x00000001803172F0
	[CompilerGenerated]
	private void _BuildButton_b__57_0(); // 0x000000018031A000-0x000000018031A140
}

