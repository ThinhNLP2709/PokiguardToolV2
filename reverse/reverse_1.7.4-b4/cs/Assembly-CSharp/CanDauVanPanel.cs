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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class CanDauVanPanel : MonoBehaviour // TypeDefIndex: 428
{
	// Fields
	public const string N_ROOT = "[CanDauVanPanel]"; // Metadata: 0x005EF2B5
	public const int SORT_ORDER = 400; // Metadata: 0x005EF2C6
	public const float BG_X = 0f; // Metadata: 0x005EF2C8
	public const float BG_Y = 0f; // Metadata: 0x005EF2CC
	public const float BG_W = 1774f; // Metadata: 0x005EF2D0
	public const float BG_H = 887f; // Metadata: 0x005EF2D4
	public const float BG_ASPECT = 2f; // Metadata: 0x005EF2D8
	public const float VP_X = 0f; // Metadata: 0x005EF2DC
	public const float VP_Y = 128f; // Metadata: 0x005EF2E0
	public const float VP_W = 1774f; // Metadata: 0x005EF2E4
	public const float VP_H = 600f; // Metadata: 0x005EF2E8
	public const float MAP_H = 600f; // Metadata: 0x005EF2EC
	public const float HUD_X = 24f; // Metadata: 0x005EF2F0
	public const float HUD_Y = 16f; // Metadata: 0x005EF2F4
	public const float HUD_W = 300f; // Metadata: 0x005EF2F8
	public const float HUD_H = 64f; // Metadata: 0x005EF2FC
	public const float HUD_ICON = 56f; // Metadata: 0x005EF300
	public const float HUD_ICON_X = 8f; // Metadata: 0x005EF304
	public const float HUD_TXT_X = 72f; // Metadata: 0x005EF308
	public const float HUD_TXT_W = 150f; // Metadata: 0x005EF30C
	public const float HUD_PLUS_X = 236f; // Metadata: 0x005EF310
	public const float HUD_FONT = 36f; // Metadata: 0x005EF314
	public const float PLQ_X = 687f; // Metadata: 0x005EF318
	public const float PLQ_Y = -10f; // Metadata: 0x005EF31C
	public const float PLQ_W = 400f; // Metadata: 0x005EF320
	public const float PLQ_H = 125f; // Metadata: 0x005EF324
	public const float PLQ_FONT = 34f; // Metadata: 0x005EF328
	public const float PLQ_TXT_X = 109f; // Metadata: 0x005EF32C
	public const float PLQ_TXT_Y = 32f; // Metadata: 0x005EF330
	public const float PLQ_TXT_W = 180f; // Metadata: 0x005EF334
	public const float PLQ_TXT_H = 64f; // Metadata: 0x005EF338
	public const float PLQ_TXT_CX = 199f; // Metadata: 0x005EF33C
	public const float PLQ_TXT_CY = 64f; // Metadata: 0x005EF340
	public const float HEARTS_X = 1100f; // Metadata: 0x005EF344
	public const float HEARTS_Y = 40f; // Metadata: 0x005EF348
	public const float HEARTS_W = 200f; // Metadata: 0x005EF34C
	public const float HEARTS_H = 44f; // Metadata: 0x005EF350
	public const float HEART = 44f; // Metadata: 0x005EF354
	public const float HEART_STEP = 48f; // Metadata: 0x005EF358
	public const int HEART_MAX = 4; // Metadata: 0x005EF35C
	public const float MARQ_X = 400f; // Metadata: 0x005EF35D
	public const float MARQ_Y = 112f; // Metadata: 0x005EF361
	public const float MARQ_W = 974f; // Metadata: 0x005EF365
	public const float MARQ_H = 44f; // Metadata: 0x005EF369
	public const float MARQ_FONT = 22f; // Metadata: 0x005EF36D
	public const float MARQ_SPEED = 90f; // Metadata: 0x005EF371
	public const float MARQ_PAD_LEFT = 12f; // Metadata: 0x005EF375
	public const float DICE0_X = 771f; // Metadata: 0x005EF379
	public const float DICE1_X = 907f; // Metadata: 0x005EF37D
	public const float DICE_Y = 170f; // Metadata: 0x005EF381
	public const float DICE = 96f; // Metadata: 0x005EF385
	public const float DOT = 18f; // Metadata: 0x005EF389
	public const float DOT_GAP = 26f; // Metadata: 0x005EF38D
	public const float RING = 200f; // Metadata: 0x005EF391
	public const float ROLL_X = 737f; // Metadata: 0x005EF395
	public const float ROLL_Y = 158f; // Metadata: 0x005EF399
	public const float ROLL_W = 300f; // Metadata: 0x005EF39D
	public const float ROLL_H = 120f; // Metadata: 0x005EF3A1
	public const float GUIDE_X = 1585f; // Metadata: 0x005EF3A5
	public const float GUIDE_Y = 15f; // Metadata: 0x005EF3A9
	public const float GUIDE_W = 78f; // Metadata: 0x005EF3AD
	public const float GUIDE_H = 78f; // Metadata: 0x005EF3B1
	public const float TRAY_X = 270f; // Metadata: 0x005EF3B5
	public const float TRAY_Y = 740f; // Metadata: 0x005EF3B9
	public const float CLOSE_X = 1680f; // Metadata: 0x005EF3BD
	public const float CLOSE_Y = 14f; // Metadata: 0x005EF3C1
	public const float CLOSE_W = 80f; // Metadata: 0x005EF3C5
	public const float CLOSE_H = 80f; // Metadata: 0x005EF3C9
	public const float HIT = 96f; // Metadata: 0x005EF3CD
	public const float HERO_W = 120f; // Metadata: 0x005EF3D1
	public const float HERO_H = 150f; // Metadata: 0x005EF3D5
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
	public static bool IsOpen { get; } // 0x00000001803455B0-0x0000000180345800 
	internal RectTransform MapContent { get; } // 0x0000000180345800-0x0000000180345810 
	internal RectTransform Hero { get; } // 0x0000000180345810-0x0000000180345820 
	internal CanDauVanTray Tray { get; } // 0x0000000180345820-0x0000000180345830 
	internal CanDauVanGiftPopup GiftPopup { get; } // 0x0000000180345830-0x0000000180345840 
	internal CanDauVanBuyDialog BuyDialog { get; } // 0x0000000180345840-0x0000000180345850 
	internal CanDauVanGuideDrawer GuideDrawer { get; } // 0x0000000180345850-0x0000000180345860 
	internal bool Busy { get; } // 0x0000000180345860-0x0000000180345870 
	private bool Loop { get; } // 0x000000018034E0D0-0x000000018034E110 
	private bool KeepPos { get; } // 0x000000018034E110-0x000000018034E150 

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
		internal void _RunMarqueePass_b__0(float x); // 0x0000000180356090-0x00000001803561A0
		internal void _RunMarqueePass_b__1(); // 0x00000001803561A0-0x0000000180356410
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
		internal void _PlayRoll_b__0(); // 0x0000000180356410-0x0000000180356440
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
		internal void _HopAlong_b__0(); // 0x0000000180356440-0x0000000180356480
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
		internal void _Land_b__0(); // 0x0000000180356480-0x00000001803566E0
		internal void _Land_b__1(); // 0x00000001803566E0-0x0000000180356720
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
		internal void _FlyToTray_b__0(); // 0x0000000180356720-0x00000001803568D0
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
		internal void _EndRound_b__3(); // 0x00000001803568D0-0x0000000180356B10
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
		private bool MoveNext(); // 0x0000000180356B10-0x0000000180356DD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180356DD0-0x0000000180356E10
	}

	// Constructors
	public CanDauVanPanel(); // 0x0000000180355610-0x0000000180355A10
	static CanDauVanPanel(); // 0x0000000180355A10-0x0000000180355B90

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void RegisterOpener(); // 0x0000000180345870-0x00000001803459C0
	public static bool Open(); // 0x00000001803459C0-0x00000001803461C0
	public static void CloseIfOpen(); // 0x00000001803461C0-0x0000000180346300
	public void Close(); // 0x0000000180346300-0x0000000180346C70
	private void SetShown(bool on); // 0x0000000180346C70-0x0000000180346F90
	private void OnDisable(); // 0x0000000180346F90-0x00000001803470C0
	private void OnDestroy(); // 0x00000001803470C0-0x0000000180347310
	private void OnRectTransformDimensionsChange(); // 0x0000000180347310-0x0000000180347400
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180347400-0x0000000180347410
	private bool AliveUi(); // 0x0000000180347410-0x00000001803475F0
	private static bool ConfigEnabled(); // 0x00000001803475F0-0x0000000180347640
	private static CanDauVanPanel Build(); // 0x0000000180347640-0x0000000180347E00
	private void BuildBody(RectTransform root); // 0x0000000180347E00-0x0000000180349AA0
	internal void ApplyBleed(bool force); // 0x0000000180349AA0-0x000000018034A260
	private Vector2 RootSize(); // 0x000000018034A260-0x000000018034A5F0
	private static void Place(RectTransform rt, float x, float y, float w, float h); // 0x000000018034A5F0-0x000000018034A730
	private void BuildHero(); // 0x000000018034A730-0x000000018034AC20
	private void BuildHud(); // 0x000000018034AC20-0x000000018034B220
	private void BuildPlaque(); // 0x000000018034B220-0x000000018034B6D0
	private RectTransform BuildDie(int n, float x); // 0x000000018034B6D0-0x000000018034BDF0
	private static void Hit(RectTransform button, float w, float h); // 0x000000018034BDF0-0x000000018034BFC0
	private void BindStatics(CanDauVanTheme theme); // 0x000000018034BFC0-0x000000018034C860
	private static Sprite RealOrProcedural(CanDauVanTheme theme, string name); // 0x000000018034C860-0x000000018034C9D0
	private static Sprite SkyGradient(); // 0x000000018034C9D0-0x000000018034D090
	internal void RenderState(CanDauVanState s); // 0x000000018034D090-0x000000018034D900
	private static CanDauVanTile Blank(int idx); // 0x000000018034D900-0x000000018034DAA0
	private void BuildTrack(CanDauVanState s); // 0x000000018034DAA0-0x000000018034E090
	internal CanDauVanTileView TileViewAt(int idx); // 0x000000018034E090-0x000000018034E0D0
	private void LayoutRing(int lo); // 0x000000018034E150-0x000000018034E920
	private void SiblingLast(int idx, int len); // 0x000000018034E920-0x000000018034EAB0
	private void SiblingFirst(int idx); // 0x000000018034EAB0-0x000000018034EC30
	private void CenterRing(int step); // 0x000000018034EC30-0x000000018034EC80
	private void RebaseRing(); // 0x000000018034EC80-0x000000018034EE70
	private void RenderHud(); // 0x000000018034EE70-0x000000018034F540
	private void RenderMarquee(); // 0x000000018034F540-0x000000018034F8F0
	private void PlaceHero(int step); // 0x000000018034F8F0-0x000000018034FD60
	private bool HasRealHero(); // 0x000000018034FD60-0x000000018034FEA0
	private void SetLitOnly(int idx); // 0x000000018034FEA0-0x00000001803500E0
	internal void ScrollTo(int step, bool animated); // 0x00000001803500E0-0x00000001803501C0
	private void ScrollCamera(int step, bool animated, float dur, LeanTweenType ease, Action onDone); // 0x00000001803501C0-0x0000000180350620
	private void ShowDice(int[] dice); // 0x0000000180350620-0x0000000180350A10
	private void StartMarquee(); // 0x0000000180350A10-0x0000000180350CA0
	private void RunMarqueePass(RectTransform rt, float from, float to, float w); // 0x0000000180350CA0-0x0000000180350F80
	private void StopMarquee(); // 0x0000000180350F80-0x0000000180351130
	private void StartTick(); // 0x0000000180351130-0x00000001803512B0
	private void StopTick(); // 0x00000001803512B0-0x0000000180351330
	[IteratorStateMachine(typeof(_TickLoop_d__206))]
	private IEnumerator TickLoop(); // 0x0000000180351330-0x00000001803513D0
	private void TickOnce(); // 0x00000001803513D0-0x0000000180351510
	private long NowMs(); // 0x0000000180351510-0x00000001803515A0
	private void RequestState(); // 0x00000001803515A0-0x0000000180351700
	private void Refresh(); // 0x0000000180351700-0x0000000180351720
	private void OnState(CanDauVanState s); // 0x0000000180351720-0x00000001803517F0
	private void OnStateError(string err); // 0x00000001803517F0-0x00000001803518B0
	private void OnRollTap(); // 0x00000001803518B0-0x0000000180351D70
	private void TryPlay(); // 0x0000000180351D70-0x0000000180351E00
	private void OnRollOk(CanDauVanRollResult r); // 0x0000000180351E00-0x0000000180352080
	private void OnRollErr(string err); // 0x0000000180352080-0x00000001803522E0
	private void RestoreDice(); // 0x00000001803522E0-0x00000001803523E0
	internal void PlayRoll(CanDauVanRollResult r, bool instant); // 0x00000001803523E0-0x00000001803529D0
	private void ApplyRollLocal(CanDauVanRollResult r); // 0x00000001803529D0-0x0000000180352AF0
	private void HopAlong(int[] path, int i, Action done); // 0x0000000180352AF0-0x0000000180352F90
	private void Land(CanDauVanRollResult r, int to); // 0x0000000180352F90-0x00000001803533E0
	private void FlyToTray(CanDauVanRollResult r, int to, bool revealed); // 0x00000001803533E0-0x0000000180353C70
	private void Finish(CanDauVanRollResult r, int to, bool revealed); // 0x0000000180353C70-0x0000000180353FA0
	private void Release(); // 0x0000000180353FA0-0x0000000180354040
	private void EndRound(bool instant); // 0x0000000180354040-0x00000001803542C0
	private Vector2 ToFxLocal(Vector3 world); // 0x00000001803542C0-0x0000000180354470
	internal void OpenBuy(); // 0x0000000180354470-0x0000000180354700
	private void OnBuyConfirm(int qty); // 0x0000000180354700-0x0000000180354960
	private void OnBuyOk(CanDauVanBuyResult r); // 0x0000000180354960-0x0000000180354C80
	private void OnBuyErr(string err); // 0x0000000180354C80-0x0000000180354EF0
	internal void OpenGuide(); // 0x0000000180354EF0-0x00000001803550C0
	public static float FontOf(float raw); // 0x00000001803550C0-0x0000000180355280
	public static string Fmt(string tpl, params object[] args); // 0x0000000180355280-0x0000000180355490
	private static void Notice(string message); // 0x0000000180355490-0x0000000180355610
	[CompilerGenerated]
	private void _OnRollTap_b__213_0(); // 0x0000000180355B90-0x0000000180355C20
	[CompilerGenerated]
	private void _EndRound_b__225_0(); // 0x0000000180355C20-0x0000000180355D80
	[CompilerGenerated]
	private void _EndRound_b__225_1(); // 0x0000000180355D80-0x0000000180355E70
	[CompilerGenerated]
	private void _EndRound_b__225_2(); // 0x0000000180355E70-0x0000000180356090
}

