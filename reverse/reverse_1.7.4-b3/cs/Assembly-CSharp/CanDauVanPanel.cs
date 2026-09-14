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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class CanDauVanPanel : MonoBehaviour // TypeDefIndex: 428
{
	// Fields
	public const string N_ROOT = "[CanDauVanPanel]"; // Metadata: 0x005EDEE5
	public const int SORT_ORDER = 400; // Metadata: 0x005EDEF6
	public const float BG_X = 0f; // Metadata: 0x005EDEF8
	public const float BG_Y = 0f; // Metadata: 0x005EDEFC
	public const float BG_W = 1774f; // Metadata: 0x005EDF00
	public const float BG_H = 887f; // Metadata: 0x005EDF04
	public const float BG_ASPECT = 2f; // Metadata: 0x005EDF08
	public const float VP_X = 0f; // Metadata: 0x005EDF0C
	public const float VP_Y = 128f; // Metadata: 0x005EDF10
	public const float VP_W = 1774f; // Metadata: 0x005EDF14
	public const float VP_H = 600f; // Metadata: 0x005EDF18
	public const float MAP_H = 600f; // Metadata: 0x005EDF1C
	public const float HUD_X = 24f; // Metadata: 0x005EDF20
	public const float HUD_Y = 16f; // Metadata: 0x005EDF24
	public const float HUD_W = 300f; // Metadata: 0x005EDF28
	public const float HUD_H = 64f; // Metadata: 0x005EDF2C
	public const float HUD_ICON = 56f; // Metadata: 0x005EDF30
	public const float HUD_ICON_X = 8f; // Metadata: 0x005EDF34
	public const float HUD_TXT_X = 72f; // Metadata: 0x005EDF38
	public const float HUD_TXT_W = 150f; // Metadata: 0x005EDF3C
	public const float HUD_PLUS_X = 236f; // Metadata: 0x005EDF40
	public const float HUD_FONT = 36f; // Metadata: 0x005EDF44
	public const float PLQ_X = 687f; // Metadata: 0x005EDF48
	public const float PLQ_Y = -10f; // Metadata: 0x005EDF4C
	public const float PLQ_W = 400f; // Metadata: 0x005EDF50
	public const float PLQ_H = 125f; // Metadata: 0x005EDF54
	public const float PLQ_FONT = 34f; // Metadata: 0x005EDF58
	public const float PLQ_TXT_X = 109f; // Metadata: 0x005EDF5C
	public const float PLQ_TXT_Y = 32f; // Metadata: 0x005EDF60
	public const float PLQ_TXT_W = 180f; // Metadata: 0x005EDF64
	public const float PLQ_TXT_H = 64f; // Metadata: 0x005EDF68
	public const float PLQ_TXT_CX = 199f; // Metadata: 0x005EDF6C
	public const float PLQ_TXT_CY = 64f; // Metadata: 0x005EDF70
	public const float HEARTS_X = 1100f; // Metadata: 0x005EDF74
	public const float HEARTS_Y = 40f; // Metadata: 0x005EDF78
	public const float HEARTS_W = 200f; // Metadata: 0x005EDF7C
	public const float HEARTS_H = 44f; // Metadata: 0x005EDF80
	public const float HEART = 44f; // Metadata: 0x005EDF84
	public const float HEART_STEP = 48f; // Metadata: 0x005EDF88
	public const int HEART_MAX = 4; // Metadata: 0x005EDF8C
	public const float MARQ_X = 400f; // Metadata: 0x005EDF8D
	public const float MARQ_Y = 112f; // Metadata: 0x005EDF91
	public const float MARQ_W = 974f; // Metadata: 0x005EDF95
	public const float MARQ_H = 44f; // Metadata: 0x005EDF99
	public const float MARQ_FONT = 22f; // Metadata: 0x005EDF9D
	public const float MARQ_SPEED = 90f; // Metadata: 0x005EDFA1
	public const float MARQ_PAD_LEFT = 12f; // Metadata: 0x005EDFA5
	public const float DICE0_X = 771f; // Metadata: 0x005EDFA9
	public const float DICE1_X = 907f; // Metadata: 0x005EDFAD
	public const float DICE_Y = 170f; // Metadata: 0x005EDFB1
	public const float DICE = 96f; // Metadata: 0x005EDFB5
	public const float DOT = 18f; // Metadata: 0x005EDFB9
	public const float DOT_GAP = 26f; // Metadata: 0x005EDFBD
	public const float RING = 200f; // Metadata: 0x005EDFC1
	public const float ROLL_X = 737f; // Metadata: 0x005EDFC5
	public const float ROLL_Y = 158f; // Metadata: 0x005EDFC9
	public const float ROLL_W = 300f; // Metadata: 0x005EDFCD
	public const float ROLL_H = 120f; // Metadata: 0x005EDFD1
	public const float GUIDE_X = 1585f; // Metadata: 0x005EDFD5
	public const float GUIDE_Y = 15f; // Metadata: 0x005EDFD9
	public const float GUIDE_W = 78f; // Metadata: 0x005EDFDD
	public const float GUIDE_H = 78f; // Metadata: 0x005EDFE1
	public const float TRAY_X = 270f; // Metadata: 0x005EDFE5
	public const float TRAY_Y = 740f; // Metadata: 0x005EDFE9
	public const float CLOSE_X = 1680f; // Metadata: 0x005EDFED
	public const float CLOSE_Y = 14f; // Metadata: 0x005EDFF1
	public const float CLOSE_W = 80f; // Metadata: 0x005EDFF5
	public const float CLOSE_H = 80f; // Metadata: 0x005EDFF9
	public const float HIT = 96f; // Metadata: 0x005EDFFD
	public const float HERO_W = 120f; // Metadata: 0x005EE001
	public const float HERO_H = 150f; // Metadata: 0x005EE005
	public static readonly Color MARQUEE_TEXT; // 0x00
	private static readonly int[] DEFAULT_DICE; // 0x10
	private static CanDauVanPanel _instance; // 0x18
	private Canvas _canvas; // 0x20
	private GraphicRaycaster _raycaster; // 0x28
	private CanvasGroup _group; // 0x30
	private RectTransform _content; // 0x38
	private long _builtConfigVersion; // 0x40
	private Image _imgBg; // 0x48
	private RectTransform _mapViewport; // 0x50
	private RectTransform _mapContent; // 0x58
	private RectTransform _fxAnchor; // 0x60
	private RectTransform _heroRt; // 0x68
	private Image _heroImg; // 0x70
	private Sprite _heroIdle; // 0x78
	private Sprite _heroJump; // 0x80
	private RectTransform _hudRt; // 0x88
	private RectTransform _plqRt; // 0x90
	private RectTransform _heartsRt; // 0x98
	private RectTransform _marqRt; // 0xA0
	private RectTransform _guideRt; // 0xA8
	private RectTransform _trayRt; // 0xB0
	private RectTransform _closeRt; // 0xB8
	private float _bleedX; // 0xC0
	private float _bleedY; // 0xC4
	private Vector2 _bleedFor; // 0xC8
	private int _heroStep; // 0xD0
	private int _ringLo; // 0xD4
	private Image _hudPill; // 0xD8
	private Image _icTicket; // 0xE0
	private Image _btnPlusImg; // 0xE8
	private Image _plaque; // 0xF0
	private Image _marqueeBg; // 0xF8
	private Image _guideIcon; // 0x100
	private UnityEngine.UI.Text _txtTickets; // 0x108
	private UnityEngine.UI.Text _txtRolls; // 0x110
	private UnityEngine.UI.Text _txtMarquee; // 0x118
	private readonly Image[] _hearts; // 0x120
	private readonly RectTransform[] _dice; // 0x128
	private readonly Image[] _diceFace; // 0x130
	private readonly RectTransform[] _diceRing; // 0x138
	private Button _btnRoll; // 0x140
	private Button _btnClose; // 0x148
	private CanDauVanTray _tray; // 0x150
	private CanDauVanGiftPopup _gift; // 0x158
	private CanDauVanBuyDialog _buy; // 0x160
	private CanDauVanGuideDrawer _guide; // 0x168
	private CanDauVanTileView[] _tiles; // 0x170
	private int _builtTrackLen; // 0x178
	private string _boundPrefix; // 0x180
	private CanDauVanState _state; // 0x188
	private CanDauVanState _deferred; // 0x190
	private CanDauVanState _lastNoticed; // 0x198
	private CanDauVanStrings _str; // 0x1A0
	private CanDauVanTheme _theme; // 0x1A8
	private bool _busy; // 0x1B0
	private bool _diceDone; // 0x1B1
	private CanDauVanRollResult _pendingRoll; // 0x1B8
	private int[] _lastDice; // 0x1C0
	private int _litIdx; // 0x1C8
	private int _marqueeId; // 0x1CC
	private int _camId; // 0x1D0
	private Coroutine _tick; // 0x1D8
	private bool _refetching; // 0x1E0
	private bool _endRefreshed; // 0x1E1
	private bool _startRefreshed; // 0x1E2
	private long _serverMs; // 0x1E8
	private float _syncAt; // 0x1F0
	private static Sprite _sky; // 0x20

	// Properties
	public static bool IsOpen { get; } // 0x0000000180345490-0x00000001803456E0 
	internal RectTransform MapContent { get; } // 0x00000001803456E0-0x00000001803456F0 
	internal RectTransform Hero { get; } // 0x00000001803456F0-0x0000000180345700 
	internal CanDauVanTray Tray { get; } // 0x0000000180345700-0x0000000180345710 
	internal CanDauVanGiftPopup GiftPopup { get; } // 0x0000000180345710-0x0000000180345720 
	internal CanDauVanBuyDialog BuyDialog { get; } // 0x0000000180345720-0x0000000180345730 
	internal CanDauVanGuideDrawer GuideDrawer { get; } // 0x0000000180345730-0x0000000180345740 
	internal bool Busy { get; } // 0x0000000180345740-0x0000000180345750 
	private bool Loop { get; } // 0x000000018034DFB0-0x000000018034DFF0 
	private bool KeepPos { get; } // 0x000000018034DFF0-0x000000018034E030 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass202_0 // TypeDefIndex: 429
	{
		// Fields
		public RectTransform rt; // 0x10
		public CanDauVanPanel __4__this; // 0x18
		public float w; // 0x20

		// Constructors
		public __c__DisplayClass202_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RunMarqueePass_b__0(float x); // 0x0000000180355E80-0x0000000180355F90
		internal void _RunMarqueePass_b__1(); // 0x0000000180355F90-0x0000000180356200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass218_0 // TypeDefIndex: 430
	{
		// Fields
		public CanDauVanPanel __4__this; // 0x10
		public CanDauVanRollResult r; // 0x18
		public int to; // 0x20

		// Constructors
		public __c__DisplayClass218_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayRoll_b__0(); // 0x0000000180356200-0x0000000180356230
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass220_0 // TypeDefIndex: 431
	{
		// Fields
		public CanDauVanPanel __4__this; // 0x10
		public int[] path; // 0x18
		public int i; // 0x20
		public Action done; // 0x28

		// Constructors
		public __c__DisplayClass220_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _HopAlong_b__0(); // 0x0000000180356230-0x0000000180356270
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass221_0 // TypeDefIndex: 432
	{
		// Fields
		public CanDauVanPanel __4__this; // 0x10
		public CanDauVanRollResult r; // 0x18
		public int to; // 0x20
		public CanDauVanRandomShard shard; // 0x28
		public Action __9__1; // 0x30

		// Constructors
		public __c__DisplayClass221_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Land_b__0(); // 0x0000000180356270-0x00000001803564D0
		internal void _Land_b__1(); // 0x00000001803564D0-0x0000000180356510
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass222_0 // TypeDefIndex: 433
	{
		// Fields
		public Image fly; // 0x10
		public CanDauVanPanel __4__this; // 0x18
		public CanDauVanRollResult r; // 0x20
		public int to; // 0x28
		public bool revealed; // 0x2C

		// Constructors
		public __c__DisplayClass222_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlyToTray_b__0(); // 0x0000000180356510-0x00000001803566C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass225_0 // TypeDefIndex: 434
	{
		// Fields
		public int home; // 0x10
		public CanDauVanPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass225_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EndRound_b__3(); // 0x00000001803566C0-0x0000000180356900
	}

	[CompilerGenerated]
	private sealed class _TickLoop_d__206 : IEnumerator<object> // TypeDefIndex: 435
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CanDauVanPanel __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TickLoop_d__206(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180356900-0x0000000180356BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180356BC0-0x0000000180356C00
	}

	// Constructors
	public CanDauVanPanel(); // 0x0000000180355400-0x0000000180355800
	static CanDauVanPanel(); // 0x0000000180355800-0x0000000180355980

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x0000000180345750-0x00000001803458A0
	public static bool Open(); // 0x00000001803458A0-0x00000001803460A0
	public static void CloseIfOpen(); // 0x00000001803460A0-0x00000001803461E0
	public void Close(); // 0x00000001803461E0-0x0000000180346B50
	private void SetShown(bool on); // 0x0000000180346B50-0x0000000180346E70
	private void OnDisable(); // 0x0000000180346E70-0x0000000180346FA0
	private void OnDestroy(); // 0x0000000180346FA0-0x00000001803471F0
	private void OnRectTransformDimensionsChange(); // 0x00000001803471F0-0x00000001803472E0
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001803472E0-0x00000001803472F0
	private bool AliveUi(); // 0x00000001803472F0-0x00000001803474D0
	private static bool ConfigEnabled(); // 0x00000001803474D0-0x0000000180347520
	private static CanDauVanPanel Build(); // 0x0000000180347520-0x0000000180347CE0
	private void BuildBody(RectTransform root); // 0x0000000180347CE0-0x0000000180349980
	internal void ApplyBleed(bool force); // 0x0000000180349980-0x000000018034A140
	private Vector2 RootSize(); // 0x000000018034A140-0x000000018034A4D0
	private static void Place(RectTransform rt, float x, float y, float w, float h); // 0x000000018034A4D0-0x000000018034A610
	private void BuildHero(); // 0x000000018034A610-0x000000018034AB00
	private void BuildHud(); // 0x000000018034AB00-0x000000018034B100
	private void BuildPlaque(); // 0x000000018034B100-0x000000018034B5B0
	private RectTransform BuildDie(int n, float x); // 0x000000018034B5B0-0x000000018034BCD0
	private static void Hit(RectTransform button, float w, float h); // 0x000000018034BCD0-0x000000018034BEA0
	private void BindStatics(CanDauVanTheme theme); // 0x000000018034BEA0-0x000000018034C740
	private static Sprite RealOrProcedural(CanDauVanTheme theme, string name); // 0x000000018034C740-0x000000018034C8B0
	private static Sprite SkyGradient(); // 0x000000018034C8B0-0x000000018034CF70
	internal void RenderState(CanDauVanState s); // 0x000000018034CF70-0x000000018034D7E0
	private static CanDauVanTile Blank(int idx); // 0x000000018034D7E0-0x000000018034D980
	private void BuildTrack(CanDauVanState s); // 0x000000018034D980-0x000000018034DF70
	internal CanDauVanTileView TileViewAt(int idx); // 0x000000018034DF70-0x000000018034DFB0
	private void LayoutRing(int lo); // 0x000000018034E030-0x000000018034E800
	private void SiblingLast(int idx, int len); // 0x000000018034E800-0x000000018034E990
	private void SiblingFirst(int idx); // 0x000000018034E990-0x000000018034EB10
	private void CenterRing(int step); // 0x000000018034EB10-0x000000018034EB60
	private void RebaseRing(); // 0x000000018034EB60-0x000000018034ED50
	private void RenderHud(); // 0x000000018034ED50-0x000000018034F420
	private void RenderMarquee(); // 0x000000018034F420-0x000000018034F7D0
	private void PlaceHero(int step); // 0x000000018034F7D0-0x000000018034FC40
	private bool HasRealHero(); // 0x000000018034FC40-0x000000018034FD80
	private void SetLitOnly(int idx); // 0x000000018034FD80-0x000000018034FFC0
	internal void ScrollTo(int step, bool animated); // 0x000000018034FFC0-0x00000001803500A0
	private void ScrollCamera(int step, bool animated, float dur, LeanTweenType ease, Action onDone); // 0x00000001803500A0-0x0000000180350500
	private void ShowDice(int[] dice); // 0x0000000180350500-0x00000001803508F0
	private void StartMarquee(); // 0x00000001803508F0-0x0000000180350B80
	private void RunMarqueePass(RectTransform rt, float from, float to, float w); // 0x0000000180350B80-0x0000000180350E60
	private void StopMarquee(); // 0x0000000180350E60-0x0000000180351010
	private void StartTick(); // 0x0000000180351010-0x0000000180351190
	private void StopTick(); // 0x0000000180351190-0x0000000180351210
	[IteratorStateMachine(typeof(_TickLoop_d__206))]
	private IEnumerator TickLoop(); // 0x0000000180351210-0x00000001803512B0
	private void TickOnce(); // 0x00000001803512B0-0x00000001803513F0
	private long NowMs(); // 0x00000001803513F0-0x0000000180351480
	private void RequestState(); // 0x0000000180351480-0x00000001803515E0
	private void Refresh(); // 0x00000001803515E0-0x0000000180351600
	private void OnState(CanDauVanState s); // 0x0000000180351600-0x00000001803516B0
	private void OnStateError(string err); // 0x00000001803516B0-0x0000000180351740
	private void OnRollTap(); // 0x0000000180351740-0x0000000180351C00
	private void TryPlay(); // 0x0000000180351C00-0x0000000180351C90
	private void OnRollOk(CanDauVanRollResult r); // 0x0000000180351C90-0x0000000180351EF0
	private void OnRollErr(string err); // 0x0000000180351EF0-0x0000000180352120
	private void RestoreDice(); // 0x0000000180352120-0x0000000180352220
	internal void PlayRoll(CanDauVanRollResult r, bool instant); // 0x0000000180352220-0x0000000180352810
	private void ApplyRollLocal(CanDauVanRollResult r); // 0x0000000180352810-0x0000000180352930
	private void HopAlong(int[] path, int i, Action done); // 0x0000000180352930-0x0000000180352DD0
	private void Land(CanDauVanRollResult r, int to); // 0x0000000180352DD0-0x0000000180353220
	private void FlyToTray(CanDauVanRollResult r, int to, bool revealed); // 0x0000000180353220-0x0000000180353AB0
	private void Finish(CanDauVanRollResult r, int to, bool revealed); // 0x0000000180353AB0-0x0000000180353DE0
	private void Release(); // 0x0000000180353DE0-0x0000000180353E80
	private void EndRound(bool instant); // 0x0000000180353E80-0x0000000180354100
	private Vector2 ToFxLocal(Vector3 world); // 0x0000000180354100-0x00000001803542B0
	internal void OpenBuy(); // 0x00000001803542B0-0x0000000180354540
	private void OnBuyConfirm(int qty); // 0x0000000180354540-0x00000001803547A0
	private void OnBuyOk(CanDauVanBuyResult r); // 0x00000001803547A0-0x0000000180354AA0
	private void OnBuyErr(string err); // 0x0000000180354AA0-0x0000000180354CE0
	internal void OpenGuide(); // 0x0000000180354CE0-0x0000000180354EB0
	public static float FontOf(float raw); // 0x0000000180354EB0-0x0000000180355070
	public static string Fmt(string tpl, params object[] args); // 0x0000000180355070-0x0000000180355280
	private static void Notice(string message); // 0x0000000180355280-0x0000000180355400
	[CompilerGenerated]
	private void _OnRollTap_b__213_0(); // 0x0000000180355980-0x0000000180355A10
	[CompilerGenerated]
	private void _EndRound_b__225_0(); // 0x0000000180355A10-0x0000000180355B70
	[CompilerGenerated]
	private void _EndRound_b__225_1(); // 0x0000000180355B70-0x0000000180355C60
	[CompilerGenerated]
	private void _EndRound_b__225_2(); // 0x0000000180355C60-0x0000000180355E80
}

