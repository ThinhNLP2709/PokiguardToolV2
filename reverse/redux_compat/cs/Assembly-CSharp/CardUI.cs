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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class CardUI : MonoBehaviour // TypeDefIndex: 1618
{
	// Fields
	private CardData cardData; // 0x20
	public Button btn; // 0x28
	private Board board; // 0x30
	private Active active; // 0x38
	private bool hasUsedThisMatch; // 0x40
	private bool hasUsedThisTurn; // 0x41
	private int lastTurnUsed; // 0x44
	private bool isActionPending; // 0x48
	internal int lastBuffUsedTurn; // 0x4C
	internal bool hasUsedBuffThisTurn; // 0x50
	private int currentDotSkillActorNumber; // 0x54
	[Header("Placeholder Settings")]
	[Tooltip("Sprite hi\u1EC3n th\u1ECB khi card \u0111\u00E3 \u0111\u01B0\u1EE3c s\u1EED d\u1EE5ng")]
	public Sprite placeholderSprite; // 0x58
	[Tooltip("M\u00E0u c\u1EE7a placeholder (default: gray v\u1EDBi alpha 0.5)")]
	public Color placeholderColor; // 0x60
	private Sprite originalSprite; // 0x70
	private bool isPlaceholder; // 0x78
	[Header("Card Animation Settings")]
	[Tooltip("Th\u1EDDi gian hi\u1EC3n th\u1ECB card animation (gi\u00E2y)")]
	public float animationDuration; // 0x7C
	[Tooltip("Scale c\u1EE7a card khi \u1EDF gi\u1EEFa m\u00E0n h\u00ECnh")]
	public float centerCardScale; // 0x80
	[Tooltip("K\u00EDch th\u01B0\u1EDBc card gi\u1EEFa m\u00E0n h\u00ECnh")]
	private Vector2 centerCardSize; // 0x84
	[Header("Card Visual")]
	[Tooltip("Image object hi\u1EC3n th\u1ECB card (child object)")]
	public Image imgtCard; // 0x90
	private Canvas animationCanvas; // 0x98
	private Image centerCardImage; // 0xA0
	[Header("Dot Skill Settings")]
	[Tooltip("Panel ch\u1EE9a 7 n\u00FAt m\u0169i t\u00EAn (t\u1EF1 \u0111\u1ED9ng t\u00ECm ho\u1EB7c t\u1EA1o)")]
	public Transform dotSkillPanel; // 0xA8
	[Tooltip("Prefab Image \u0111\u1EC3 hi\u1EC3n th\u1ECB m\u0169i t\u00EAn")]
	public GameObject arrowPrefab; // 0xB0
	[Tooltip("Th\u1EDDi gian cho ph\u00E9p ng\u01B0\u1EDDi ch\u01A1i g\u00F5 ph\u00EDm (gi\u00E2y)")]
	public float dotSkillDuration; // 0xB8
	[Header("Dot Skill Time Slider")]
	[Tooltip("Slider hi\u1EC3n th\u1ECB th\u1EDDi gian (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Slider timeSlider; // 0xC0
	[Tooltip("M\u00E0u slider khi c\u00F2n nhi\u1EC1u th\u1EDDi gian")]
	public Color sliderColorNormal; // 0xC8
	[CompilerGenerated]
	private static CardUI _ActiveDotSkillCard_k__BackingField; // 0x00
	[Tooltip("M\u00E0u slider khi s\u1EAFp h\u1EBFt th\u1EDDi gian")]
	public Color sliderColorWarning; // 0xD8
	[Range(0f, 1f)]
	[Tooltip("Ng\u01B0\u1EE1ng chuy\u1EC3n m\u00E0u c\u1EA3nh b\u00E1o (% th\u1EDDi gian c\u00F2n l\u1EA1i)")]
	public float warningThreshold; // 0xE8
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Text hi\u1EC3n th\u1ECB Perfect/Good/Bad (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public UnityEngine.UI.Text timingText; // 0xF0
	[Tooltip("M\u00E0u text Perfect")]
	public Color perfectColor; // 0xF8
	[Tooltip("M\u00E0u text Good")]
	public Color goodColor; // 0x108
	[Tooltip("M\u00E0u text Bad")]
	public Color badColor; // 0x118
	[Header("Damage Multipliers")]
	[Range(1f, 3f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Perfect")]
	public float perfectMultiplier; // 0x128
	[Range(1f, 2f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Good")]
	public float goodMultiplier; // 0x12C
	[Range(0.5f, 1f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Bad")]
	public float badMultiplier; // 0x130
	private List<Image> currentArrows; // 0x138
	private string[] directions; // 0x140
	private int currentDotIndex; // 0x148
	private int correctDotCount; // 0x14C
	private bool isDotSkillActive; // 0x150
	private float currentTimeValue; // 0x154
	private float damageMultiplier; // 0x158
	private Dictionary<string, Sprite> blueArrows; // 0x160
	private Dictionary<string, Sprite> purpleArrows; // 0x168
	private bool hasFinishedDotSkill; // 0x170
	[Header("Control Buttons")]
	[Tooltip("N\u00FAt Up (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnUp; // 0x178
	[Tooltip("N\u00FAt Down (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnDown; // 0x180
	[Tooltip("N\u00FAt Left (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnLeft; // 0x188
	[Tooltip("N\u00FAt Right (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnRight; // 0x190
	[Tooltip("N\u00FAt Enter (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnEnter; // 0x198
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float perfectStartTime; // 0x1A0
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float perfectEndTime; // 0x1A4
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 2.5s")]
	public float goodStart1Time; // 0x1A8
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float goodEnd1Time; // 0x1AC
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float goodStart2Time; // 0x1B0
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 4.2s")]
	public float goodEnd2Time; // 0x1B4
	private int timingBonus; // 0x1B8
	[Header("Timing Bonus (for ATTACK_LEGEND_)")]
	[Tooltip("Bonus correctCount khi Perfect (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int perfectBonus; // 0x1BC
	[Tooltip("Bonus correctCount khi Good (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int goodBonus; // 0x1C0
	[Tooltip("Bonus correctCount khi Bad (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int badBonus; // 0x1C4
	[Tooltip("M\u00E0u text Perfect")]
	private Coroutine blinkCoroutine; // 0x1C8
	[Header("Legend Card Background Effects")]
	[Tooltip("\u1EA2nh n\u1EC1n c\u1EA7n \u00E1p d\u1EE5ng hi\u1EC7u \u1EE9ng")]
	public Image backgroundImage; // 0x1D0
	[Tooltip("M\u00E0u flash effect (default: tr\u1EAFng)")]
	public Color flashColor; // 0x1D8
	[Tooltip("S\u1ED1 l\u1EA7n flash")]
	public int flashCount; // 0x1E8
	[Tooltip("Th\u1EDDi gian m\u1ED7i l\u1EA7n flash (gi\u00E2y)")]
	public float flashDuration; // 0x1EC
	[Tooltip("C\u01B0\u1EDDng \u0111\u1ED9 rung (shake magnitude)")]
	public float shakeMagnitude; // 0x1F0
	[Tooltip("Th\u1EDDi gian rung (gi\u00E2y)")]
	public float shakeDuration; // 0x1F4
	private Color originalBackgroundColor; // 0x1F8
	private bool isBackgroundEffectActive; // 0x208
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	[Tooltip("Panel ch\u1EE9a 8 toggle \u0111\u1EC3 ch\u1ECDn h\u00E0ng (n\u00EAn c\u00F3 Canvas sortingOrder cao)")]
	public GameObject mega1TogglePanel; // 0x210
	[Tooltip("8 Toggle t\u01B0\u01A1ng \u1EE9ng h\u00E0ng 0-7 (row 0 = h\u00E0ng d\u01B0\u1EDBi c\u00F9ng)")]
	public Toggle[] mega1RowToggles; // 0x218
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 h\u00E0ng \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x220
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x228
	private List<int> mega1SelectedRows; // 0x230
	private bool isMega1PanelOpen; // 0x238
	private Coroutine mega1WatchCoroutine; // 0x240
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x248
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x250
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x258
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x260
	private List<Toggle> _mega2Toggles; // 0x268
	private List<Animator> _mega2Animators; // 0x270
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x278
	private bool isMega2PanelOpen; // 0x280
	private bool isMegaIcarusSelectionMode; // 0x281
	private Coroutine mega2WatchCoroutine; // 0x288
	[Header("MEGA_ICARUS Card Settings (ch\u1ECDn t\u00E2m + b\u00E1n k\u00EDnh)")]
	[Tooltip("Panel ch\u1EE9a toggle \u0111\u1EC3 ch\u1ECDn t\u00E2m tr\u00EAn b\u00E0n (gi\u1ED1ng MEGA2 nh\u01B0ng ch\u1EC9 ch\u1ECDn 1 t\u00E2m)")]
	public GameObject megaIcarusTogglePanel; // 0x290
	[Tooltip("Toggle m\u1EABu \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle megaIcarusTogglePrefab; // 0x298
	[Tooltip("Text hi\u1EC3n th\u1ECB h\u01B0\u1EDBng d\u1EABn ch\u1ECDn t\u00E2m")]
	public UnityEngine.UI.Text megaIcarusSelectedCountText; // 0x2A0
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA_ICARUS")]
	public GameObject txtInfoMegaIcarus; // 0x2A8
	private List<Toggle> _megaIcarusToggles; // 0x2B0
	private List<Animator> _megaIcarusAnimators; // 0x2B8
	[TupleElementNames(new string[2] {"col", "row" })]
	private ValueTuple<int, int>? megaIcarusSelectedCenter; // 0x2C0
	private bool isMegaIcarusPanelOpen; // 0x2CC
	private bool isMegaIcarusAutoSelected; // 0x2CD
	private Coroutine megaIcarusWatchCoroutine; // 0x2D0
	[Tooltip("B\u00E1n k\u00EDnh m\u1EB7c \u0111\u1ECBnh c\u1EE7a Mega Icarus (s\u1ED1 \u00F4 t\u1EEB t\u00E2m)")]
	public int megaIcarusDefaultRadius; // 0x2D8
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x2DC
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x2E0
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x2F0
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x300
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x304
	private string _elemTypeSrc; // 0x308
	private string _elemTypeUpper; // 0x310
	private int currentArrowSeed; // 0x318
	private readonly List<string> qtePresses; // 0x320
	private bool _isLegendEffectActive; // 0x328
	private Camera _matchCameraCache; // 0x330

	// Properties
	public bool IsActionPending { get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
	public static CardUI ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805BDF30-0x00000001805BDF70 0x00000001805BDF70-0x00000001805BDFD0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass176_0 // TypeDefIndex: 1619
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass176_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x00000001805C0240-0x00000001805C0320
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass176_1 // TypeDefIndex: 1620
	{
		// Fields
		public Vector3 originalPos; // 0x10
		public __c__DisplayClass176_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass176_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckDotArrow_b__1(); // 0x00000001805C0320-0x00000001805C03D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass192_0 // TypeDefIndex: 1621
	{
		// Fields
		public int idx; // 0x10
		public CardUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass192_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x00000001805C03D0-0x00000001805C0400
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass204_0 // TypeDefIndex: 1622
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass204_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x00000001805C0400-0x00000001805C0440
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 1623
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass209_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x00000001805C0440-0x00000001805C0460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass216_0 // TypeDefIndex: 1624
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass216_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupMegaIcarusPanelOnce_b__0(bool on); // 0x00000001805C0460-0x00000001805C04A0
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__188 : IEnumerator<object> // TypeDefIndex: 1625
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private RectTransform _rt_5__2; // 0x28
		private Vector2 _origPos_5__3; // 0x30
		private Color _origColor_5__4; // 0x38
		private Color _darkColor_5__5; // 0x48
		private float _shakeDuration_5__6; // 0x58
		private float _t_5__7; // 0x5C
		private float _restDuration_5__8; // 0x60
		private float _restElapsed_5__9; // 0x64

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BackgroundFlickerShake_d__188(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805BEA40-0x00000001805BF000
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BF000-0x00000001805BF040
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__177 : IEnumerator<object> // TypeDefIndex: 1626
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__177(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805CD4E0-0x00000001805CD740
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CD740-0x00000001805CD780
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__202 : IEnumerator<object> // TypeDefIndex: 1627
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__202(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805CD890-0x00000001805CDE60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CDE60-0x00000001805CDEA0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__213 : IEnumerator<object> // TypeDefIndex: 1628
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__213(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805CDEA0-0x00000001805CE810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CE810-0x00000001805CE850
	}

	[CompilerGenerated]
	private sealed class _ExecuteMegaIcarusDotDestruction_d__225 : IEnumerator<object> // TypeDefIndex: 1629
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private int _col_5__2; // 0x28
		private int _row_5__3; // 0x2C
		private float _guardOff_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMegaIcarusDotDestruction_d__225(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805CE850-0x00000001805CEF70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CEF70-0x00000001805CEFB0
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__159 : IEnumerator<object> // TypeDefIndex: 1630
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		public int userActorNumber; // 0x28
		private string _elementType_5__2; // 0x30
		private bool __pausedTurnForSkill_5__3; // 0x38
		private float _timeLeft_5__4; // 0x3C
		private float _totalTime_5__5; // 0x40
		private float _qteWait_5__6; // 0x44
		private int _finalDamage_5__7; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__159(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805CF430-0x00000001805D0700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D0700-0x00000001805D0740
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__137 : IEnumerator<object> // TypeDefIndex: 1631
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private GameObject _centerObj_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _fadeDuration_5__4; // 0x38
		private float _t_5__5; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__137(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
		private bool MoveNext(); // 0x00000001805D0740-0x00000001805D09C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D09C0-0x00000001805D0A00
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__201 : IEnumerator<object> // TypeDefIndex: 1632
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__201(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D0A00-0x00000001805D0B20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D0B20-0x00000001805D0B60
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__194 : IEnumerator<object> // TypeDefIndex: 1633
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__194(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D0B60-0x00000001805D0EC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D0EC0-0x00000001805D0F00
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__208 : IEnumerator<object> // TypeDefIndex: 1634
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__208(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D0F00-0x00000001805D1310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D1310-0x00000001805D1350
	}

	[CompilerGenerated]
	private sealed class _OpenMegaIcarusPanel_d__220 : IEnumerator<object> // TypeDefIndex: 1635
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenMegaIcarusPanel_d__220(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D1350-0x00000001805D1830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D1830-0x00000001805D1870
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__157 : IEnumerator<object> // TypeDefIndex: 1636
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__157(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D1870-0x00000001805D1CD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D1CD0-0x00000001805D1D10
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__156 : IEnumerator<object> // TypeDefIndex: 1637
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__156(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805D1D10-0x00000001805D2220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D2220-0x00000001805D2260
	}

	[CompilerGenerated]
	private sealed class _PlayCardEffectAnimation_d__158 : IEnumerator<object> // TypeDefIndex: 1638
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		public int userActorNumber; // 0x28
		private Active _active_5__2; // 0x30
		private int _damage_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardEffectAnimation_d__158(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805D2260-0x00000001805D3020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D3020-0x00000001805D3060
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__125 : IEnumerator<object> // TypeDefIndex: 1639
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__125(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D3060-0x00000001805D32C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D32C0-0x00000001805D3300
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__219 : IEnumerator<object> // TypeDefIndex: 1640
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__219(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D3300-0x00000001805D3700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D3700-0x00000001805D3740
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__124 : IEnumerator<object> // TypeDefIndex: 1641
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__124(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D3740-0x00000001805D3AE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D3AE0-0x00000001805D3B20
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__210 : IEnumerator<object> // TypeDefIndex: 1642
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__210(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D3B20-0x00000001805D3DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D3DA0-0x00000001805D3DE0
	}

	[CompilerGenerated]
	private sealed class _TriggerMegaIcarusExplosion_d__222 : IEnumerator<object> // TypeDefIndex: 1643
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMegaIcarusExplosion_d__222(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805D3DE0-0x00000001805D3F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D3F90-0x00000001805D3FD0
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__200 : IEnumerator<object> // TypeDefIndex: 1644
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float resWaitSec; // 0x20
		public float renderWaitSec; // 0x24
		private MatchService _ms_5__2; // 0x28
		private float _waited_5__3; // 0x30
		private float _rendering_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForWsSkillResolution_d__200(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805D4480-0x00000001805D46C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D46C0-0x00000001805D4800
	}

	// Constructors
	public CardUI(); // 0x00000001805BD990-0x00000001805BDF30

	// Methods
	public void BeginPendingAction(); // 0x00000001805B03B0-0x00000001805B03C0
	public void ClearPendingAction(); // 0x00000001805B17E0-0x00000001805B17F0
	public static void ResetStaticState(); // 0x00000001805B9A90-0x00000001805B9AE0
	public Image GetCenterCardImage(); // 0x00000001805B5990-0x00000001805B59A0
	private void Start(); // 0x00000001805BBF90-0x00000001805BC440
	public static bool IsRowSkillType(string upperType); // 0x00000001805B6D30-0x00000001805B6DA0
	public static bool IsGalaxySkillType(string upperType); // 0x00000001805B6B50-0x00000001805B6B90
	public static bool IsMegaIcarusType(string upperType); // 0x00000001805B6CF0-0x00000001805B6D30
	public static bool IsHealConvertSkillType(string upperType); // 0x00000001805B6B90-0x00000001805B6BD0
	public int SkillCooldownLeft(); // 0x00000001805BBC10-0x00000001805BBD30
	public static bool IsAuditionSkillType(string upperType); // 0x00000001805B68E0-0x00000001805B6950
	private bool IsSkillCard(); // 0x00000001805B6DA0-0x00000001805B6EC0
	private bool IsLocalSilenced(); // 0x00000001805B6BD0-0x00000001805B6C70
	public int GetHandIndex(); // 0x00000001805B5F50-0x00000001805B5FF0
	public bool IsDownedBuffAssist(); // 0x00000001805B6A10-0x00000001805B6B50
	public bool ValidateCardUsage(); // 0x00000001805BCF40-0x00000001805BD400
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__124))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x00000001805BB570-0x00000001805BB5E0
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__125))]
	private IEnumerator RestoreBackgroundColor(); // 0x00000001805B9AE0-0x00000001805B9B50
	private void SetupControlButtonListeners(); // 0x00000001805BA5C0-0x00000001805BA940
	private void HideDotSkillUI(); // 0x00000001805B65C0-0x00000001805B67F0
	private void ShowDotSkillUI(); // 0x00000001805BB5E0-0x00000001805BB880
	private void OnDestroy(); // 0x00000001805B7CD0-0x00000001805B7E40
	private void CreateDotSkillPanel(); // 0x00000001805B3770-0x00000001805B3A90
	private void CreateTimeSliderWithZones(); // 0x00000001805B3A90-0x00000001805B4270
	private void RemoveZonesFromSlider(); // 0x00000001805B93E0-0x00000001805B9550
	private void CreateTimingText(); // 0x00000001805B4270-0x00000001805B4700
	private void LoadDotSkillSprites(); // 0x00000001805B7690-0x00000001805B7870
	private GameObject CreateDefaultArrowPrefab(); // 0x00000001805B36A0-0x00000001805B3770
	private void CreateAnimationCanvas(); // 0x00000001805B3000-0x00000001805B36A0
	[IteratorStateMachine(typeof(_HideCenterCard_d__137))]
	private IEnumerator HideCenterCard(); // 0x00000001805B6550-0x00000001805B65C0
	private void OnTurnStart(int entityIndex); // 0x00000001805B8FD0-0x00000001805B9120
	public void MarkAsUsed(); // 0x00000001805B7870-0x00000001805B7AC0
	public void RevertOptimisticUse(); // 0x00000001805B9B50-0x00000001805B9FC0
	public void SetCardData(CardData data); // 0x00000001805BA2B0-0x00000001805BA500
	public CardData GetCardData(); // 0x00000001802F8630-0x00000001802F8640
	public void AdoptSharedSkillRefs(CardUI src); // 0x00000001805AF180-0x00000001805AF6A0
	private static bool HasNoToggles(Toggle[] arr); // 0x00000001805B6490-0x00000001805B6550
	private bool RequiresDotSkillUI(); // 0x00000001805B9550-0x00000001805B95F0
	private bool ValidateDotSkillComponents(); // 0x00000001805BD400-0x00000001805BD740
	private string ElementTypeUpper(); // 0x00000001805B4780-0x00000001805B4830
	private bool IsBuffCard(); // 0x00000001805B6950-0x00000001805B6980
	private bool IsAttackCard(); // 0x00000001805B67F0-0x00000001805B68E0
	private bool IsMega1Card(); // 0x00000001805B6C70-0x00000001805B6CF0
	private bool ValidateMega1CardUsage(); // 0x00000001805BD740-0x00000001805BD820
	public void RefreshCardButtonState(); // 0x00000001805B93D0-0x00000001805B93E0
	public bool IsDotSkillCard(); // 0x00000001805B6980-0x00000001805B6A10
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__156))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x00000001805B92E0-0x00000001805B9350
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__157))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x00000001805B9270-0x00000001805B92E0
	[IteratorStateMachine(typeof(_PlayCardEffectAnimation_d__158))]
	public IEnumerator PlayCardEffectAnimation(int userActorNumber); // 0x00000001805B9350-0x00000001805B93D0
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__159))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x00000001805B6410-0x00000001805B6490
	private void ApplyServerQteWindow(); // 0x00000001805B0100-0x00000001805B0340
	private int CurrentQteElapsedMs(); // 0x00000001805B4700-0x00000001805B4780
	private int CalculateDotsToDestroy(); // 0x00000001805B0430-0x00000001805B0610
	private void SetLegendMultiplier(float multiplier); // 0x00000001805BA500-0x00000001805BA5C0
	private string GetLastTimingResult(); // 0x00000001805B5FF0-0x00000001805B6160
	private string NormalizeArrowDir(string raw); // 0x00000001805B7B30-0x00000001805B7CD0
	private void GenerateDotArrows(); // 0x00000001805B50F0-0x00000001805B5990
	private void ClearDotArrows(); // 0x00000001805B14D0-0x00000001805B17E0
	private int CountMatchingDotsOnBoard(); // 0x00000001805B2D40-0x00000001805B3000
	public void ResetCardVisual(); // 0x00000001805B9810-0x00000001805B9970
	private void OnEnterButtonPress(); // 0x00000001805B7E80-0x00000001805B7EF0
	private void OnDirectionButtonPress(string direction); // 0x00000001805B7E40-0x00000001805B7E80
	private void ShowTimingResult(); // 0x00000001805BB880-0x00000001805BBC10
	private void Update(); // 0x00000001805BCD10-0x00000001805BCF40
	private void CheckDotArrow(string dir); // 0x00000001805B0E20-0x00000001805B14D0
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__177))]
	private IEnumerator BlinkEnterButton(); // 0x00000001805B03C0-0x00000001805B0430
	private void ResetDotCombo(); // 0x00000001805B9970-0x00000001805B9A90
	private string GetDirectionFromInput(); // 0x00000001805B59A0-0x00000001805B5AD0
	public void ConsumeCardCondition(int actorNumber); // 0x00000001805B2400-0x00000001805B2A70
	public string GetDisabledReason(); // 0x00000001805B5AD0-0x00000001805B5F50
	public bool CanUseCard(); // 0x00000001805B0610-0x00000001805B0890
	private bool CheckConditionUse(); // 0x00000001805B0890-0x00000001805B0E20
	private void UpdateCardVisual(); // 0x00000001805BCA40-0x00000001805BCB50
	public void ConvertToPlaceholder(); // 0x00000001805B2A70-0x00000001805B2D40
	public static void ResetAllCardsForNewMatch(); // 0x00000001805B95F0-0x00000001805B9810
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__188))]
	private IEnumerator BackgroundFlickerShake(); // 0x00000001805B0340-0x00000001805B03B0
	private Camera GetMatchCamera(); // 0x00000001805B6160-0x00000001805B6410
	private void LateUpdate(); // 0x00000001805B6EC0-0x00000001805B7690
	private void SetupMega1PanelOnce(); // 0x00000001805BA940-0x00000001805BAD10
	public void StartMega1Panel(); // 0x00000001805BBD30-0x00000001805BBDB0
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__194))]
	private IEnumerator OpenMega1Panel(); // 0x00000001805B9120-0x00000001805B9190
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x00000001805B7EF0-0x00000001805B82C0
	private static void SendSkillHintSafe(Dictionary<string, object> payload); // 0x00000001805BA170-0x00000001805BA2B0
	private static void SendQteEventSafe(Dictionary<string, object> payload); // 0x00000001805BA030-0x00000001805BA170
	private void UpdateMega1UI(); // 0x00000001805BCB50-0x00000001805BCD10
	private void CloseMega1Panel(bool executeDestroy); // 0x00000001805B17F0-0x00000001805B19F0
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__200))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x0064D7E7 */, float renderWaitSec = 14f /* Metadata: 0x0064D7EB */); // 0x00000001805BD820-0x00000001805BD8A0
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__201))]
	private IEnumerator Mega1WatchTurnTime(); // 0x00000001805B7AC0-0x00000001805B7B30
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__202))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x00000001805B4830-0x00000001805B48A0
	private void AccumulateMega1WaveIntoDestroyedCountByTag(); // 0x00000001805AEAD0-0x00000001805AEE60
	private void SetupMega2PanelOnce(); // 0x00000001805BAD10-0x00000001805BB140
	private void AlignMega2TogglesToBoard(); // 0x00000001805AF6A0-0x00000001805AFBD0
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x00000001805BD8A0-0x00000001805BD990
	public void StartMega2Panel(); // 0x00000001805BBDB0-0x00000001805BBE30
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__208))]
	private IEnumerator OpenMega2Panel(); // 0x00000001805B9190-0x00000001805B9200
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x00000001805B82C0-0x00000001805B8A50
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__210))]
	private IEnumerator TriggerMega2Explosion(); // 0x00000001805BC440-0x00000001805BC4B0
	private void CloseMega2Panel(bool executeDestroy); // 0x00000001805B19F0-0x00000001805B1DA0
	public void ForceCloseMega2Panel(); // 0x00000001805B4980-0x00000001805B4D40
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__213))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x00000001805B48A0-0x00000001805B4910
	private HashSet<ValueTuple<int, int>> Collect3x3Positions([TupleElementNames(new string[2] {"col", "row" })] List<ValueTuple<int, int>> dots, int W, int H); // 0x00000001805B2100-0x00000001805B22E0
	private void AccumulateMega2WaveIntoDestroyedCountByTag(HashSet<ValueTuple<int, int>> positions); // 0x00000001805AEE60-0x00000001805AF180
	private void SetupMegaIcarusPanelOnce(); // 0x00000001805BB140-0x00000001805BB570
	private void AlignMegaIcarusTogglesToBoard(); // 0x00000001805AFBD0-0x00000001805B0100
	public void StartMegaIcarusPanel(); // 0x00000001805BBE30-0x00000001805BBF90
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__219))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x00000001805B9FC0-0x00000001805BA030
	[IteratorStateMachine(typeof(_OpenMegaIcarusPanel_d__220))]
	private IEnumerator OpenMegaIcarusPanel(); // 0x00000001805B9200-0x00000001805B9270
	private void OnMegaIcarusToggleChanged(int col, int row, int idx, bool isOn); // 0x00000001805B8A50-0x00000001805B8FD0
	[IteratorStateMachine(typeof(_TriggerMegaIcarusExplosion_d__222))]
	private IEnumerator TriggerMegaIcarusExplosion(); // 0x00000001805BC4B0-0x00000001805BC520
	private void CloseMegaIcarusPanel(bool executeDestroy); // 0x00000001805B1DA0-0x00000001805B2100
	public void ForceCloseMegaIcarusPanel(); // 0x00000001805B4D40-0x00000001805B50F0
	[IteratorStateMachine(typeof(_ExecuteMegaIcarusDotDestruction_d__225))]
	private IEnumerator ExecuteMegaIcarusDotDestruction(); // 0x00000001805B4910-0x00000001805B4980
	private HashSet<ValueTuple<int, int>> CollectRadiusPositions(int centerCol, int centerRow, int radius, int W, int H); // 0x00000001805B22E0-0x00000001805B2400
	[CompilerGenerated]
	private void _Start_b__112_0(); // 0x00000001805BC6E0-0x00000001805BCA40
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__126_0(); // 0x00000001805BC520-0x00000001805BC590
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__126_1(); // 0x00000001805BC590-0x00000001805BC600
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__126_2(); // 0x00000001805BC600-0x00000001805BC670
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__126_3(); // 0x00000001805BC670-0x00000001805BC6E0
}

