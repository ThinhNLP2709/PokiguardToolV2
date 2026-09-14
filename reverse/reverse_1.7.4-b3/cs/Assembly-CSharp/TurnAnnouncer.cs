/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class TurnAnnouncer // TypeDefIndex: 584
{
	// Fields
	private static readonly Color FALLBACK_BG; // 0x00
	private static Runner _runner; // 0x10
	private static Transform _canvasRoot; // 0x18
	private static View _view; // 0x20
	private static Coroutine _co; // 0x78
	private static bool _blocking; // 0x80
	private static float _blockDeadline; // 0x84
	private static string _lastKey; // 0x88
	private static WaitForSecondsRealtime _hold; // 0x90
	private static Sprite _spBg; // 0x98
	private static Sprite _spGlow; // 0xA0
	private static Sprite _spMask; // 0xA8
	private static Sprite _spPlateSelf; // 0xB0
	private static Sprite _spPlateOther; // 0xB8
	private static readonly string[] _bossDots; // 0xC0
	private static string _bossDotsBase; // 0xC8
	private static MatchService _subscribedMs; // 0xD0

	// Properties
	public static bool IsBlockingInput { get; } // 0x00000001804112D0-0x0000000180411390 
	public static bool Enabled { get; } // 0x0000000180411390-0x00000001804114E0 

	// Nested types
	public enum Kind // TypeDefIndex: 585
	{
		Self = 0,
		Other = 1,
		Boss = 2
	}

	public struct View // TypeDefIndex: 586
	{
		// Fields
		public GameObject root; // 0x00
		public RectTransform rect; // 0x08
		public CanvasGroup group; // 0x10
		public Image glow; // 0x18
		public Image bg; // 0x20
		public Image flash; // 0x28
		public GameObject avatarHolder; // 0x30
		public Image avatarMask; // 0x38
		public Image avatar; // 0x40
		public UnityEngine.UI.Text title; // 0x48
		public UnityEngine.UI.Text sub; // 0x50

		// Properties
		public bool IsAlive { get; } // 0x00000001804187A0-0x00000001804189D0 
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 587
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0

		// Methods
		private void Update(); // 0x00000001804189D0-0x0000000180418A90
		private void OnDestroy(); // 0x0000000180418A90-0x0000000180418DA0
	}

	[CompilerGenerated]
	private sealed class _PlayRoutine_d__46 : IEnumerator<object> // TypeDefIndex: 588
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool minimal; // 0x20
		public float holdSec; // 0x24
		public Kind kind; // 0x28
		private View _v_5__2; // 0x30
		private float _yHome_5__3; // 0x88
		private float _spent_5__4; // 0x8C
		private float _rest_5__5; // 0x90
		private float _pop_5__6; // 0x94
		private float _t_5__7; // 0x98
		private int _phase_5__8; // 0x9C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__46(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180418DA0-0x0000000180418DD0
		private bool MoveNext(); // 0x0000000180418DD0-0x0000000180419CA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180419CA0-0x0000000180419CE0
	}

	// Constructors
	static TurnAnnouncer(); // 0x00000001804186C0-0x00000001804187A0

	// Methods
	public static void Announce(string matchId, int turnNumber, string turnUsername, bool isBoss, bool isLocal, int announceHoldMs); // 0x00000001804114E0-0x0000000180411C30
	public static void HideNow(); // 0x0000000180411C30-0x0000000180411D00
	public static void ResetForMatchExit(); // 0x0000000180411D00-0x0000000180411DD0
	private static void BeginBlock(float durationSec); // 0x0000000180411DD0-0x0000000180411EB0
	private static void EndBlock(bool reopen); // 0x0000000180411EB0-0x0000000180411FC0
	[IteratorStateMachine(typeof(_PlayRoutine_d__46))]
	private static IEnumerator PlayRoutine(float holdSec, bool minimal, Kind kind); // 0x0000000180411FC0-0x0000000180412030
	private static float EaseOutBack(float k); // 0x0000000180335340-0x0000000180335380
	private static void EnsureHold(float sec); // 0x0000000180412030-0x0000000180412190
	private static void SetFlashAlpha(View v, float a); // 0x0000000180412190-0x0000000180412350
	private static void StopRoutine(); // 0x0000000180412350-0x0000000180412510
	private static void HideNode(); // 0x0000000180412510-0x0000000180412670
	private static bool IsMinimalTier(); // 0x0000000180412670-0x0000000180412750
	private static float ResolveHoldSec(int announceHoldMs); // 0x0000000180412750-0x0000000180412830
	public static void ApplyVisual(View v, Kind kind, string displayName, Sprite avatarSprite, string avatarLayers = null); // 0x0000000180412830-0x00000001804136A0
	private static string Str(string slot, string legacyProp, string def); // 0x00000001804136A0-0x0000000180413790
	private static string SafeFormat(string fmt, string arg); // 0x0000000180413790-0x0000000180413880
	private static void BuildBossDots(string baseText); // 0x0000000180413880-0x0000000180413AE0
	private static string ResolveDisplayName(string username, bool isBoss); // 0x0000000180413AE0-0x0000000180413DE0
	private static Sprite ResolveAvatar(string username); // 0x0000000180413DE0-0x00000001804140D0
	private static string ResolveAvatarLayers(string username); // 0x00000001804140D0-0x00000001804142A0
	public static void ApplySprites(View v); // 0x00000001804142A0-0x0000000180415160
	private static void TryUpgradeSprites(); // 0x0000000180415160-0x0000000180415200
	private static Sprite Upgrade(Sprite cur, string path); // 0x0000000180415200-0x0000000180415490
	private static bool EnsureNode(); // 0x0000000180415490-0x0000000180415C30
	public static View BuildView(Transform parent); // 0x0000000180415C30-0x0000000180416B10
	private static void Layout(View v, bool withAvatar, bool hasSub); // 0x0000000180416B10-0x0000000180417540
	private static void StretchFull(RectTransform r, float margin); // 0x0000000180417540-0x0000000180417620
	private static Image NewImage(RectTransform parent, string name, bool sliced = true /* Metadata: 0x005EE3E9 */); // 0x0000000180417620-0x0000000180417990
	private static UnityEngine.UI.Text NewText(RectTransform parent, string name, bool bold); // 0x0000000180417990-0x0000000180417F20
	private static void EnsureSubscriptions(); // 0x0000000180417F20-0x0000000180418230
	private static void Unsubscribe(); // 0x0000000180418230-0x00000001804185D0
	private static void HandleMatchStart(ChatMessageDTO m); // 0x00000001804185D0-0x0000000180418620
	private static void HandleMatchResync(ChatMessageDTO m); // 0x0000000180418620-0x0000000180418670
	private static void HandleGameOver(string winner); // 0x0000000180418670-0x00000001804186C0
}

