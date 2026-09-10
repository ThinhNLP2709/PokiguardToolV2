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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class TurnAnnouncer // TypeDefIndex: 531
{
	// Fields
	public const string BlockReason = "\u0110ang th\u00F4ng b\u00E1o l\u01B0\u1EE3t \u2014 ch\u1EDD m\u1ED9t ch\u00FAt"; // Metadata: 0x0068B501
	public const string BOSS_SENTINEL = "__BOSS__"; // Metadata: 0x0068B531
	public const string UI_KEY = "match.turnAnnounce"; // Metadata: 0x0068B53A
	public const string SPRITE_PLATE_SELF = "Image/MatchUI/turn_plate_self"; // Metadata: 0x0068B54D
	public const string SPRITE_PLATE_OTHER = "Image/MatchUI/turn_plate_other"; // Metadata: 0x0068B56B
	public const string SPRITE_BG = "Image/MatchUI/turn_announce_bg"; // Metadata: 0x0068B58A
	public const string SPRITE_GLOW = "Image/MatchUI/turn_announce_glow"; // Metadata: 0x0068B5A9
	public const string SPRITE_AVATAR_MASK = "Image/MatchUI/turn_announce_avatar_mask"; // Metadata: 0x0068B5CA
	public const int SORT_ORDER = 520; // Metadata: 0x0068B5F2
	public const float HARD_BLOCK_SEC = 3f; // Metadata: 0x0068B5F4
	private const float BOSS_DOT_STEP = 0.32f; // Metadata: 0x0068B5F8
	private const float FLASH_SEC = 0.25f; // Metadata: 0x0068B5FC
	private const float FLASH_ALPHA = 0.35f; // Metadata: 0x0068B600
	private const float SLIDE_PX = 40f; // Metadata: 0x0068B604
	private const float BOX_WIDTH_RATIO = 0.36f; // Metadata: 0x0068B608
	private const float AVATAR_SIZE = 34f; // Metadata: 0x0068B60C
	private const float GLOW_MARGIN = 7f; // Metadata: 0x0068B610
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
	public static bool IsBlockingInput { get; } // 0x00000001803D3870-0x00000001803D38F0 
	public static bool Enabled { get; } // 0x00000001803D37C0-0x00000001803D3870 
	public static bool IsShowing { get; } // 0x00000001803D38F0-0x00000001803D3970 

	// Nested types
	public enum Kind // TypeDefIndex: 532
	{
		Self = 0,
		Other = 1,
		Boss = 2
	}

	public struct View // TypeDefIndex: 533
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
		public bool IsAlive { get; } // 0x00000001803D6060-0x00000001803D60F0 
	}

	private class Runner : MonoBehaviour // TypeDefIndex: 534
	{
		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0

		// Methods
		private void Update(); // 0x00000001803CBDB0-0x00000001803CBE30
		private void OnDestroy(); // 0x00000001803CBC50-0x00000001803CBDB0
	}

	[CompilerGenerated]
	private sealed class _PlayRoutine_d__46 : IEnumerator<object> // TypeDefIndex: 535
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__46(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803D47E0-0x00000001803D4810
		private bool MoveNext(); // 0x00000001803D3B50-0x00000001803D47A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803D47A0-0x00000001803D47E0
	}

	// Constructors
	static TurnAnnouncer(); // 0x00000001803D3730-0x00000001803D37C0

	// Methods
	public static void Announce(string matchId, int turnNumber, string turnUsername, bool isBoss, bool isLocal, int announceHoldMs); // 0x00000001803CE8E0-0x00000001803CEFE0
	public static void HideNow(); // 0x00000001803D1880-0x00000001803D1910
	public static void ResetForMatchExit(); // 0x00000001803D2810-0x00000001803D28A0
	private static void BeginBlock(float durationSec); // 0x00000001803D0170-0x00000001803D0210
	private static void EndBlock(bool reopen); // 0x00000001803D0DA0-0x00000001803D0F30
	[IteratorStateMachine(typeof(_PlayRoutine_d__46))]
	private static IEnumerator PlayRoutine(float holdSec, bool minimal, Kind kind); // 0x00000001803D2790-0x00000001803D2810
	private static float EaseOutBack(float k); // 0x00000001803D0D60-0x00000001803D0DA0
	private static void EnsureHold(float sec); // 0x00000001803D0F30-0x00000001803D1040
	private static void SetFlashAlpha(View v, float a); // 0x00000001803D2F70-0x00000001803D30A0
	private static void StopRoutine(); // 0x00000001803D30A0-0x00000001803D3190
	private static void HideNode(); // 0x00000001803D17D0-0x00000001803D1880
	private static bool IsMinimalTier(); // 0x00000001803D1910-0x00000001803D19E0
	private static float ResolveHoldSec(int announceHoldMs); // 0x00000001803D2E20-0x00000001803D2EF0
	public static void ApplyVisual(View v, Kind kind, string displayName, Sprite avatarSprite, string avatarLayers = null); // 0x00000001803CF5F0-0x00000001803D0170
	private static string Str(string slot, string legacyProp, string def); // 0x00000001803D3190-0x00000001803D3270
	private static string SafeFormat(string fmt, string arg); // 0x00000001803D2EF0-0x00000001803D2F70
	private static void BuildBossDots(string baseText); // 0x00000001803D0210-0x00000001803D0420
	private static string ResolveDisplayName(string username, bool isBoss); // 0x00000001803D2BD0-0x00000001803D2E20
	private static Sprite ResolveAvatar(string username); // 0x00000001803D29F0-0x00000001803D2BD0
	private static string ResolveAvatarLayers(string username); // 0x00000001803D28A0-0x00000001803D29F0
	public static void ApplySprites(View v); // 0x00000001803CEFE0-0x00000001803CF5F0
	private static void TryUpgradeSprites(); // 0x00000001803D3350-0x00000001803D33F0
	private static Sprite Upgrade(Sprite cur, string path); // 0x00000001803D3600-0x00000001803D3730
	private static bool EnsureNode(); // 0x00000001803D1040-0x00000001803D14E0
	public static View BuildView(Transform parent); // 0x00000001803D0420-0x00000001803D0D60
	private static void Layout(View v, bool withAvatar, bool hasSub); // 0x00000001803D19E0-0x00000001803D2130
	private static void StretchFull(RectTransform r, float margin); // 0x00000001803D3270-0x00000001803D3350
	private static Image NewImage(RectTransform parent, string name, bool sliced = true /* Metadata: 0x0068B500 */); // 0x00000001803D2130-0x00000001803D2400
	private static UnityEngine.UI.Text NewText(RectTransform parent, string name, bool bold); // 0x00000001803D2400-0x00000001803D2790
	private static void EnsureSubscriptions(); // 0x00000001803D14E0-0x00000001803D1710
	private static void Unsubscribe(); // 0x00000001803D33F0-0x00000001803D3600
	private static void HandleMatchStart(ChatMessageDTO m); // 0x00000001803D1790-0x00000001803D17D0
	private static void HandleMatchResync(ChatMessageDTO m); // 0x00000001803D1750-0x00000001803D1790
	private static void HandleGameOver(string winner); // 0x00000001803D1710-0x00000001803D1750
}

