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

public class CardUIPVP : MonoBehaviour // TypeDefIndex: 161
{
	// Fields
	private CardData cardData; // 0x20
	public Button btn; // 0x28
	private BoardPVP board; // 0x30
	private ActivePVP active; // 0x38
	private bool hasUsedThisMatch; // 0x40
	private bool hasUsedThisTurn; // 0x41
	private int lastTurnUsed; // 0x44
	internal int lastBuffUsedTurn; // 0x48
	internal bool hasUsedBuffThisTurn; // 0x4C
	private int currentDotSkillActorNumber; // 0x50
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
	private static CardUIPVP _ActiveDotSkillCard_k__BackingField; // 0x00
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
	private readonly List<string> qtePresses; // 0x150
	private bool isDotSkillActive; // 0x158
	private float currentTimeValue; // 0x15C
	private float damageMultiplier; // 0x160
	private Dictionary<string, Sprite> blueArrows; // 0x168
	private Dictionary<string, Sprite> purpleArrows; // 0x170
	private bool hasFinishedDotSkill; // 0x178
	[Header("Control Buttons")]
	[Tooltip("N\u00FAt Up (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnUp; // 0x180
	[Tooltip("N\u00FAt Down (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnDown; // 0x188
	[Tooltip("N\u00FAt Left (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnLeft; // 0x190
	[Tooltip("N\u00FAt Right (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnRight; // 0x198
	[Tooltip("N\u00FAt Enter (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnEnter; // 0x1A0
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float perfectStartTime; // 0x1A8
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float perfectEndTime; // 0x1AC
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 2.5s")]
	public float goodStart1Time; // 0x1B0
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float goodEnd1Time; // 0x1B4
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float goodStart2Time; // 0x1B8
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 4.2s")]
	public float goodEnd2Time; // 0x1BC
	private int timingBonus; // 0x1C0
	[Header("Timing Bonus (for ATTACK_LEGEND_)")]
	[Tooltip("Bonus correctCount khi Perfect (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int perfectBonus; // 0x1C4
	[Tooltip("Bonus correctCount khi Good (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int goodBonus; // 0x1C8
	[Tooltip("Bonus correctCount khi Bad (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int badBonus; // 0x1CC
	[Tooltip("M\u00E0u text Perfect")]
	private Coroutine blinkCoroutine; // 0x1D0
	[Header("Legend Card Background Effects")]
	[Tooltip("\u1EA2nh n\u1EC1n c\u1EA7n \u00E1p d\u1EE5ng hi\u1EC7u \u1EE9ng")]
	public Image backgroundImage; // 0x1D8
	[Tooltip("M\u00E0u flash effect (default: tr\u1EAFng)")]
	public Color flashColor; // 0x1E0
	[Tooltip("S\u1ED1 l\u1EA7n flash")]
	public int flashCount; // 0x1F0
	[Tooltip("Th\u1EDDi gian m\u1ED7i l\u1EA7n flash (gi\u00E2y)")]
	public float flashDuration; // 0x1F4
	[Tooltip("C\u01B0\u1EDDng \u0111\u1ED9 rung (shake magnitude)")]
	public float shakeMagnitude; // 0x1F8
	[Tooltip("Th\u1EDDi gian rung (gi\u00E2y)")]
	public float shakeDuration; // 0x1FC
	private Color originalBackgroundColor; // 0x200
	private bool isBackgroundEffectActive; // 0x210
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x211
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x214
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x224
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x234
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x238
	private string _elemTypeSrc; // 0x240
	private string _elemTypeUpper; // 0x248
	private int currentArrowSeed; // 0x250
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	public GameObject mega1TogglePanel; // 0x258
	public Toggle[] mega1RowToggles; // 0x260
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x268
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x270
	private List<int> mega1SelectedRows; // 0x278
	private bool isMega1PanelOpen; // 0x280
	private Coroutine mega1WatchCoroutine; // 0x288
	private Camera _matchCameraCache; // 0x290
	private bool _isLegendEffectActive; // 0x298
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x2A0
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x2A8
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x2B0
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x2B8
	private List<Toggle> _mega2Toggles; // 0x2C0
	private List<Animator> _mega2Animators; // 0x2C8
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x2D0
	private bool isMega2PanelOpen; // 0x2D8
	private bool isMegaIcarusSelectionMode; // 0x2D9
	private const int MegaIcarusRadius = 3; // Metadata: 0x0064C036
	private Coroutine mega2WatchCoroutine; // 0x2E0

	// Properties
	public static CardUIPVP ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180621A80-0x0000000180621AC0 0x0000000180621AC0-0x0000000180621B20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass135_0 // TypeDefIndex: 162
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass135_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x0000000180691F20-0x0000000180692000
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass135_1 // TypeDefIndex: 163
	{
		// Fields
		public Vector3 originalPos; // 0x10
		public __c__DisplayClass135_0 CS___8__locals1; // 0x20

		// Constructors
		public __c__DisplayClass135_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _CheckDotArrow_b__1(); // 0x0000000180692000-0x00000001806920B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass154_0 // TypeDefIndex: 164
	{
		// Fields
		public int idx; // 0x10
		public CardUIPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass154_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x00000001806920B0-0x00000001806920E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass179_0 // TypeDefIndex: 165
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass179_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x00000001806920E0-0x0000000180692120
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass186_0 // TypeDefIndex: 166
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass186_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x00000001805C0440-0x00000001805C0460
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__165 : IEnumerator<object> // TypeDefIndex: 167
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
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
		public _BackgroundFlickerShake_d__165(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018068C010-0x000000018068C5D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068C5D0-0x000000018068C610
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__136 : IEnumerator<object> // TypeDefIndex: 168
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__136(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018068C610-0x000000018068C870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068C870-0x000000018068C8B0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__162 : IEnumerator<object> // TypeDefIndex: 169
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__162(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068CA40-0x000000018068CCB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068CCB0-0x000000018068CCF0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__190 : IEnumerator<object> // TypeDefIndex: 170
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__190(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068CCF0-0x000000018068D1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068D1D0-0x000000018068D210
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__119 : IEnumerator<object> // TypeDefIndex: 171
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		public int userActorNumber; // 0x28
		private string _elementType_5__2; // 0x30
		private bool __pausedTurnForSkill_5__3; // 0x38
		private float _timeLeft_5__4; // 0x3C
		private float _totalTime_5__5; // 0x40
		private float _qteWait_5__6; // 0x44

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__119(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018068D210-0x000000018068DE20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068DE20-0x000000018068DE60
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__99 : IEnumerator<object> // TypeDefIndex: 172
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private GameObject _centerObj_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30
		private float _fadeDuration_5__4; // 0x38
		private float _t_5__5; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__99(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
		private bool MoveNext(); // 0x000000018068DE60-0x000000018068E0E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068E0E0-0x000000018068E120
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__161 : IEnumerator<object> // TypeDefIndex: 173
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__161(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068F8E0-0x000000018068FA00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068FA00-0x000000018068FA40
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__156 : IEnumerator<object> // TypeDefIndex: 174
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__156(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068FC20-0x000000018068FF80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068FF80-0x000000018068FFC0
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__185 : IEnumerator<object> // TypeDefIndex: 175
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__185(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018068FFC0-0x0000000180690390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690390-0x00000001806903D0
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__118 : IEnumerator<object> // TypeDefIndex: 176
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__118(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806903D0-0x0000000180690830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690830-0x0000000180690870
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__117 : IEnumerator<object> // TypeDefIndex: 177
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__117(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180690870-0x0000000180690D80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180690D80-0x0000000180690DC0
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__87 : IEnumerator<object> // TypeDefIndex: 178
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__87(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180690DC0-0x0000000180691020
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691020-0x0000000180691060
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__184 : IEnumerator<object> // TypeDefIndex: 179
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__184(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180691060-0x00000001806912F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806912F0-0x0000000180691330
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__86 : IEnumerator<object> // TypeDefIndex: 180
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__86(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806915A0-0x0000000180691940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691940-0x0000000180691980
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__187 : IEnumerator<object> // TypeDefIndex: 181
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__187(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180691980-0x0000000180691C00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691C00-0x0000000180691C40
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__160 : IEnumerator<object> // TypeDefIndex: 182
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
		public _WaitForWsSkillResolution_d__160(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180693070-0x00000001806932B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806932B0-0x0000000180693360
	}

	// Constructors
	public CardUIPVP(); // 0x0000000180621560-0x0000000180621A80

	// Methods
	public static void ResetStaticState(); // 0x000000018061E230-0x000000018061E280
	public Image GetCenterCardImage(); // 0x00000001805B5990-0x00000001805B59A0
	private void Start(); // 0x000000018061FFC0-0x0000000180620470
	private bool IsSkillCard(); // 0x000000018061BE50-0x000000018061BF40
	public int SkillCooldownLeft(); // 0x000000018061FC20-0x000000018061FD40
	private bool IsLocalSilenced(); // 0x000000018061BCE0-0x000000018061BD90
	public int GetHandIndex(); // 0x000000018061B270-0x000000018061B310
	public bool ValidateCardUsage(); // 0x0000000180620F00-0x00000001806210B0
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__86))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x000000018061F580-0x000000018061F5F0
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__87))]
	private IEnumerator RestoreBackgroundColor(); // 0x000000018061E280-0x000000018061E2F0
	private void SetupControlButtonListeners(); // 0x000000018061EA00-0x000000018061ED80
	private void HideDotSkillUI(); // 0x000000018061B8E0-0x000000018061BB10
	private void ShowDotSkillUI(); // 0x000000018061F5F0-0x000000018061F890
	private void OnDestroy(); // 0x000000018061CE30-0x000000018061CFA0
	private void CreateDotSkillPanel(); // 0x0000000180619040-0x0000000180619360
	private void CreateTimeSliderWithZones(); // 0x0000000180619360-0x0000000180619B40
	private void RemoveZonesFromSlider(); // 0x000000018061DB90-0x000000018061DD00
	private void CreateTimingText(); // 0x0000000180619B40-0x0000000180619FD0
	private void LoadDotSkillSprites(); // 0x000000018061C810-0x000000018061C9F0
	private GameObject CreateDefaultArrowPrefab(); // 0x0000000180618F70-0x0000000180619040
	private void CreateAnimationCanvas(); // 0x00000001806188D0-0x0000000180618F70
	[IteratorStateMachine(typeof(_HideCenterCard_d__99))]
	private IEnumerator HideCenterCard(); // 0x000000018061B870-0x000000018061B8E0
	private void OnTurnStart(int entityIndex); // 0x000000018061D890-0x000000018061D9D0
	public void MarkAsUsed(); // 0x000000018061C9F0-0x000000018061CC20
	public void RevertOptimisticUse(); // 0x000000018061E2F0-0x000000018061E740
	public void SetCardData(CardData data); // 0x000000018061E7B0-0x000000018061EA00
	public CardData GetCardData(); // 0x00000001802F8630-0x00000001802F8640
	public void AdoptSharedSkillRefs(CardUIPVP src); // 0x0000000180615E30-0x0000000180616270
	private static bool HasNoToggles(Toggle[] arr); // 0x000000018061B7B0-0x000000018061B870
	private bool RequiresDotSkillUI(); // 0x000000018061DD00-0x000000018061DDA0
	private bool ValidateDotSkillComponents(); // 0x00000001806210B0-0x00000001806213F0
	private string ElementTypeUpper(); // 0x000000018061A050-0x000000018061A100
	private bool IsBuffCard(); // 0x000000018061BC20-0x000000018061BC50
	private bool IsAttackCard(); // 0x000000018061BB10-0x000000018061BC20
	private bool IsMega1Card(); // 0x000000018061BD90-0x000000018061BDF0
	private bool IsMega2Card(); // 0x000000018061BDF0-0x000000018061BE50
	public bool IsDotSkillCard(); // 0x000000018061BC50-0x000000018061BCE0
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__117))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x000000018061DB20-0x000000018061DB90
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__118))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x000000018061DAB0-0x000000018061DB20
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__119))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x000000018061B730-0x000000018061B7B0
	private void ApplyServerQteWindow(); // 0x0000000180616790-0x00000001806169D0
	private int CurrentQteElapsedMs(); // 0x0000000180619FD0-0x000000018061A050
	private int CalculateDotsToDestroy(); // 0x0000000180616AB0-0x0000000180616C00
	private string GetLastTimingResult(); // 0x000000018061B310-0x000000018061B480
	private string NormalizeArrowDir(string raw); // 0x000000018061CC90-0x000000018061CE30
	private void GenerateDotArrows(); // 0x000000018061A5A0-0x000000018061AE30
	private void ClearDotArrows(); // 0x0000000180617730-0x0000000180617A00
	private int CountMatchingDotsOnBoard(); // 0x0000000180618610-0x00000001806188D0
	public void ResetCardVisual(); // 0x000000018061DFC0-0x000000018061E110
	private void OnEnterButtonPress(); // 0x000000018061CFE0-0x000000018061D050
	private void OnDirectionButtonPress(string direction); // 0x000000018061CFA0-0x000000018061CFE0
	private void ShowTimingResult(); // 0x000000018061F890-0x000000018061FC20
	private void LateUpdate(); // 0x000000018061C760-0x000000018061C810
	private void Update(); // 0x0000000180620CD0-0x0000000180620F00
	private void CheckDotArrow(string dir); // 0x0000000180617080-0x0000000180617730
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__136))]
	private IEnumerator BlinkEnterButton(); // 0x0000000180616A40-0x0000000180616AB0
	private void ResetDotCombo(); // 0x000000018061E110-0x000000018061E230
	private string GetDirectionFromInput(); // 0x000000018061AE30-0x000000018061AF60
	public void ConsumeCardCondition(int actorNumber); // 0x0000000180617FB0-0x0000000180618340
	public string GetDisabledReason(); // 0x000000018061AF60-0x000000018061B270
	public bool CanUseCard(); // 0x0000000180616C00-0x0000000180616D70
	private bool CheckConditionUse(); // 0x0000000180616D70-0x0000000180617080
	public void UpdateCardVisualPublic(); // 0x00000001806209F0-0x0000000180620A00
	private void UpdateCardVisual(); // 0x0000000180620A00-0x0000000180620B10
	public void ConvertToPlaceholder(); // 0x0000000180618340-0x0000000180618610
	public static void ResetAllCardsForNewMatch(); // 0x000000018061DDA0-0x000000018061DFC0
	private void SetupMega1PanelOnce(); // 0x000000018061ED80-0x000000018061F150
	public void StartMega1Panel(); // 0x000000018061FD40-0x000000018061FDC0
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__156))]
	private IEnumerator OpenMega1Panel(); // 0x000000018061D9D0-0x000000018061DA40
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x000000018061D050-0x000000018061D350
	private void UpdateMega1UI(); // 0x0000000180620B10-0x0000000180620CD0
	private void CloseMega1Panel(bool executeDestroy); // 0x0000000180617A00-0x0000000180617C00
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__160))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x0064C02E */, float renderWaitSec = 14f /* Metadata: 0x0064C032 */); // 0x00000001806213F0-0x0000000180621470
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__161))]
	private IEnumerator Mega1WatchTurnTime(); // 0x000000018061CC20-0x000000018061CC90
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__162))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x000000018061A100-0x000000018061A170
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__165))]
	private IEnumerator BackgroundFlickerShake(); // 0x00000001806169D0-0x0000000180616A40
	private Camera GetMatchCamera(); // 0x000000018061B480-0x000000018061B730
	private void LateUpdateMega1(); // 0x000000018061BF40-0x000000018061C760
	private void SetupMega2PanelOnce(); // 0x000000018061F150-0x000000018061F580
	private void AlignMega2TogglesToBoard(); // 0x0000000180616270-0x0000000180616790
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x0000000180621470-0x0000000180621560
	public void StartMega2Panel(); // 0x000000018061FDC0-0x000000018061FE40
	public void StartMegaIcarusPanel(); // 0x000000018061FE40-0x000000018061FFC0
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__184))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x000000018061E740-0x000000018061E7B0
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__185))]
	private IEnumerator OpenMega2Panel(); // 0x000000018061DA40-0x000000018061DAB0
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x000000018061D350-0x000000018061D890
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__187))]
	private IEnumerator TriggerMega2Explosion(); // 0x0000000180620470-0x00000001806204E0
	private void CloseMega2Panel(bool executeDestroy); // 0x0000000180617C00-0x0000000180617FB0
	public void ForceCloseMega2Panel(); // 0x000000018061A1E0-0x000000018061A5A0
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__190))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x000000018061A170-0x000000018061A1E0
	[CompilerGenerated]
	private void _Start_b__80_0(); // 0x00000001806206A0-0x00000001806209F0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__88_0(); // 0x00000001806204E0-0x0000000180620550
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__88_1(); // 0x0000000180620550-0x00000001806205C0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__88_2(); // 0x00000001806205C0-0x0000000180620630
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__88_3(); // 0x0000000180620630-0x00000001806206A0
}

