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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class TurnAnnouncer // TypeDefIndex: 585
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
	public static bool IsBlockingInput { get; } // 0x0000000180412030-0x00000001804120F0 
	public static bool Enabled { get; } // 0x00000001804120F0-0x0000000180412240 

	// Nested types
	public enum Kind // TypeDefIndex: 586
	{
		Self = 0,
		Other = 1,
		Boss = 2
	}

	public struct View // TypeDefIndex: 587
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
		public bool IsAlive { get; } // 0x0000000180419500-0x0000000180419730 
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 588
	{
		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0

		// Methods
		private void Update(); // 0x0000000180419730-0x00000001804197F0
		private void OnDestroy(); // 0x00000001804197F0-0x0000000180419B00
	}

	[CompilerGenerated]
	private sealed class _PlayRoutine_d__46 : IEnumerator<object> // TypeDefIndex: 589
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
		void IDisposable.Dispose(); // 0x0000000180419B00-0x0000000180419B30
		private bool MoveNext(); // 0x0000000180419B30-0x000000018041AA00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018041AA00-0x000000018041AA40
	}

	// Constructors
	static TurnAnnouncer(); // 0x0000000180419420-0x0000000180419500

	// Methods
	public static void Announce(string matchId, int turnNumber, string turnUsername, bool isBoss, bool isLocal, int announceHoldMs); // 0x0000000180412240-0x0000000180412990
	public static void HideNow(); // 0x0000000180412990-0x0000000180412A60
	public static void ResetForMatchExit(); // 0x0000000180412A60-0x0000000180412B30
	private static void BeginBlock(float durationSec); // 0x0000000180412B30-0x0000000180412C10
	private static void EndBlock(bool reopen); // 0x0000000180412C10-0x0000000180412D20
	[IteratorStateMachine(typeof(_PlayRoutine_d__46))]
	private static IEnumerator PlayRoutine(float holdSec, bool minimal, Kind kind); // 0x0000000180412D20-0x0000000180412D90
	private static float EaseOutBack(float k); // 0x0000000180335460-0x00000001803354A0
	private static void EnsureHold(float sec); // 0x0000000180412D90-0x0000000180412EF0
	private static void SetFlashAlpha(View v, float a); // 0x0000000180412EF0-0x00000001804130B0
	private static void StopRoutine(); // 0x00000001804130B0-0x0000000180413270
	private static void HideNode(); // 0x0000000180413270-0x00000001804133D0
	private static bool IsMinimalTier(); // 0x00000001804133D0-0x00000001804134B0
	private static float ResolveHoldSec(int announceHoldMs); // 0x00000001804134B0-0x0000000180413590
	public static void ApplyVisual(View v, Kind kind, string displayName, Sprite avatarSprite, string avatarLayers = null); // 0x0000000180413590-0x0000000180414400
	private static string Str(string slot, string legacyProp, string def); // 0x0000000180414400-0x00000001804144F0
	private static string SafeFormat(string fmt, string arg); // 0x00000001804144F0-0x00000001804145E0
	private static void BuildBossDots(string baseText); // 0x00000001804145E0-0x0000000180414840
	private static string ResolveDisplayName(string username, bool isBoss); // 0x0000000180414840-0x0000000180414B40
	private static Sprite ResolveAvatar(string username); // 0x0000000180414B40-0x0000000180414E30
	private static string ResolveAvatarLayers(string username); // 0x0000000180414E30-0x0000000180415000
	public static void ApplySprites(View v); // 0x0000000180415000-0x0000000180415EC0
	private static void TryUpgradeSprites(); // 0x0000000180415EC0-0x0000000180415F60
	private static Sprite Upgrade(Sprite cur, string path); // 0x0000000180415F60-0x00000001804161F0
	private static bool EnsureNode(); // 0x00000001804161F0-0x0000000180416990
	public static View BuildView(Transform parent); // 0x0000000180416990-0x0000000180417870
	private static void Layout(View v, bool withAvatar, bool hasSub); // 0x0000000180417870-0x00000001804182A0
	private static void StretchFull(RectTransform r, float margin); // 0x00000001804182A0-0x0000000180418380
	private static Image NewImage(RectTransform parent, string name, bool sliced = true /* Metadata: 0x005EF7BA */); // 0x0000000180418380-0x00000001804186F0
	private static UnityEngine.UI.Text NewText(RectTransform parent, string name, bool bold); // 0x00000001804186F0-0x0000000180418C80
	private static void EnsureSubscriptions(); // 0x0000000180418C80-0x0000000180418F90
	private static void Unsubscribe(); // 0x0000000180418F90-0x0000000180419330
	private static void HandleMatchStart(ChatMessageDTO m); // 0x0000000180419330-0x0000000180419380
	private static void HandleMatchResync(ChatMessageDTO m); // 0x0000000180419380-0x00000001804193D0
	private static void HandleGameOver(string winner); // 0x00000001804193D0-0x0000000180419420
}

