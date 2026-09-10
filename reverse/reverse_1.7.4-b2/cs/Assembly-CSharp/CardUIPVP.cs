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

public class CardUIPVP : MonoBehaviour // TypeDefIndex: 175
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
	private bool _qteArrowsFromServer; // 0x158
	private bool isDotSkillActive; // 0x159
	private float currentTimeValue; // 0x15C
	private float damageMultiplier; // 0x160
	private Dictionary<string, Sprite> blueArrows; // 0x168
	private Dictionary<string, Sprite> purpleArrows; // 0x170
	private bool hasFinishedDotSkill; // 0x178
	private const string QTE_ZONE_PREFIX = "QteZone_"; // Metadata: 0x0068AB74
	private bool _qteForgiving; // 0x179
	private Image _qteShakeArrow; // 0x180
	private Vector3 _qteShakeHome; // 0x188
	private static readonly Color QteArrowIdle; // 0x08
	private static readonly Color QteArrowActive; // 0x18
	private static readonly Color QteArrowWrong; // 0x28
	private static readonly Color QteZoneGood; // 0x38
	private static readonly Color QteZonePerfect; // 0x48
	private static readonly Color QteSliderColorPerfect; // 0x58
	private bool _dotSkillPanelRuntimeCreated; // 0x194
	private const string AUDITION_TIMELINE_NAME = "AuditionTimeline"; // Metadata: 0x0068AB7D
	private const string POKY_AUDITION_FRAME_NAME = "PokyAuditionFrame"; // Metadata: 0x0068AB8E
	private const string POKY_TIMELINE_BG = "Image/FriendUI/bgList"; // Metadata: 0x0068ABA0
	private const string POKY_PANEL_FRAME = "Image/FriendUI/bgPopupAlert"; // Metadata: 0x0068ABB6
	private const string POKY_BTN_OK = "Image/Common/btnOk"; // Metadata: 0x0068ABD2
	private const string POKY_TIMELINE_PLATE = "Image/Common/Gameplay-bgDialog"; // Metadata: 0x0068ABE5
	private const string POKY_AUDITION_RIBBON = "Image/Common/bar_ribbon1"; // Metadata: 0x0068AC04
	private const string POKY_PERFECT_STAR = "Image/FriendUI/gold_star"; // Metadata: 0x0068AC1D
	private const string POKY_PERFECT_LINE = "Image/Common/linePower"; // Metadata: 0x0068AC36
	private const string POKY_NEEDLE_CAP = "Image/Common/btnNextPet0001"; // Metadata: 0x0068AC4D
	private const string POKY_ELAPSED_COMET = "Image/Common/fullMana"; // Metadata: 0x0068AC69
	private const string POKY_NEEDLE_BALL = "Image/FriendUI/redDot"; // Metadata: 0x0068AC7F
	private const string DPAD_NEON_PREFIX = "DotSkillNeon/"; // Metadata: 0x0068AC95
	private const string POKY_BTN_SPACE = "Image/petK/btnkhamht"; // Metadata: 0x0068ACA3
	private const string VOLUME_ATLAS_PATH = "Image/petK/fframe"; // Metadata: 0x0068ACB8
	private const string VOLUME_TRACK_SPRITE = "fframe_4"; // Metadata: 0x0068ACCA
	private const string VOLUME_KNOB_SPRITE = "fframe_0"; // Metadata: 0x0068ACD3
	private const string AUDITION_BALL_NAME = "NeedleBall"; // Metadata: 0x0068ACDC
	private const string AUDITION_JUDGE_NAME = "LiveJudgeText"; // Metadata: 0x0068ACE7
	private const string AUDITION_FRAME_GLOW_NAME = "FrameGlow"; // Metadata: 0x0068ACF5
	private const string AUDITION_FRAME_CORE_NAME = "FrameCore"; // Metadata: 0x0068ACFF
	private const string AUDITION_RIBBON_NAME = "AuditionRibbon"; // Metadata: 0x0068AD09
	private const string AUDITION_HIT_BURST_NAME = "ArrowHitBurst"; // Metadata: 0x0068AD18
	private RectTransform _auditionTimeline; // 0x198
	private RectTransform _auditionNeedle; // 0x1A0
	private Image _auditionNeedleImg; // 0x1A8
	private Image _auditionTrackImg; // 0x1B0
	private RectTransform _auditionComet; // 0x1B8
	private RectTransform _auditionStar; // 0x1C0
	private RectTransform _auditionRibbon; // 0x1C8
	private RectTransform _auditionNeedleBall; // 0x1D0
	private UnityEngine.UI.Text _auditionJudgeText; // 0x1D8
	private Color _auditionTrackIdleColor; // 0x1E0
	private Color _auditionTrackPerfectColor; // 0x1F0
	private Color _auditionNeedleIdleColor; // 0x200
	private Color _auditionNeedlePerfectColor; // 0x210
	private int _auditionStarTweenId; // 0x220
	private Image _frameGlowImg; // 0x228
	private bool _qteTimelineV2; // 0x230
	private bool _qteBtnLayoutV2; // 0x231
	private static readonly Color TimelineBg; // 0x68
	private static readonly Color TimelineTrackIdle; // 0x78
	private static readonly Color TimelineTrackPerfect; // 0x88
	private static readonly Color TimelineZoneGood; // 0x98
	private static readonly Color TimelineZonePerfect; // 0xA8
	private static readonly Color TimelineNeedleIdle; // 0xB8
	private static readonly Color TimelineNeedlePerfect; // 0xC8
	private static readonly Color TimelinePlateTint; // 0xD8
	private static readonly Color TimelineUnderlineTint; // 0xE8
	private static readonly Color TimelineCometTint; // 0xF8
	private static readonly Color TimelineTrackLit; // 0x108
	private static readonly Color TimelineTrackLitPerfect; // 0x118
	private static readonly Color TimelineTrackVolume; // 0x128
	private static readonly Color TimelineTrackVolumePerfect; // 0x138
	private static readonly Color TimelineNeedleLit; // 0x148
	private static readonly Color TimelineNeedleOnLit; // 0x158
	private static readonly Color TimelineJudgePerfect; // 0x168
	private static readonly Color TimelineJudgeGood; // 0x178
	private static readonly Color AuditionFrameGlow; // 0x188
	private static readonly Color AuditionFrameCore; // 0x198
	private QteButtonSlot[] _qteBtnSlots; // 0x238
	private bool _qteBtnLayoutApplied; // 0x240
	private const string AUDITION_SCRIM_NAME = "AuditionScrim"; // Metadata: 0x0068AD26
	private const float AuditionScrimAlpha = 0.62f; // Metadata: 0x0068AD34
	private const float AuditionScrimFadeSec = 0.15f; // Metadata: 0x0068AD38
	private Image _auditionScrim; // 0x248
	private QteModalSlot _qteModalPanelSlot; // 0x250
	private QteModalSlot _qteModalTextSlot; // 0x298
	private bool _qteModalApplied; // 0x2E0
	[Header("Control Buttons")]
	[Tooltip("N\u00FAt Up (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnUp; // 0x2E8
	[Tooltip("N\u00FAt Down (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnDown; // 0x2F0
	[Tooltip("N\u00FAt Left (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnLeft; // 0x2F8
	[Tooltip("N\u00FAt Right (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnRight; // 0x300
	[Tooltip("N\u00FAt Enter (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnEnter; // 0x308
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float perfectStartTime; // 0x310
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float perfectEndTime; // 0x314
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 2.5s")]
	public float goodStart1Time; // 0x318
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float goodEnd1Time; // 0x31C
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float goodStart2Time; // 0x320
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 4.2s")]
	public float goodEnd2Time; // 0x324
	private int timingBonus; // 0x328
	[Header("Timing Bonus (for ATTACK_LEGEND_)")]
	[Tooltip("Bonus correctCount khi Perfect (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int perfectBonus; // 0x32C
	[Tooltip("Bonus correctCount khi Good (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int goodBonus; // 0x330
	[Tooltip("Bonus correctCount khi Bad (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int badBonus; // 0x334
	[Tooltip("M\u00E0u text Perfect")]
	private Coroutine blinkCoroutine; // 0x338
	[Header("Legend Card Background Effects")]
	[Tooltip("\u1EA2nh n\u1EC1n c\u1EA7n \u00E1p d\u1EE5ng hi\u1EC7u \u1EE9ng")]
	public Image backgroundImage; // 0x340
	[Tooltip("M\u00E0u flash effect (default: tr\u1EAFng)")]
	public Color flashColor; // 0x348
	[Tooltip("S\u1ED1 l\u1EA7n flash")]
	public int flashCount; // 0x358
	[Tooltip("Th\u1EDDi gian m\u1ED7i l\u1EA7n flash (gi\u00E2y)")]
	public float flashDuration; // 0x35C
	[Tooltip("C\u01B0\u1EDDng \u0111\u1ED9 rung (shake magnitude)")]
	public float shakeMagnitude; // 0x360
	[Tooltip("Th\u1EDDi gian rung (gi\u00E2y)")]
	public float shakeDuration; // 0x364
	private Color originalBackgroundColor; // 0x368
	private bool isBackgroundEffectActive; // 0x378
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x379
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x37C
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x38C
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x39C
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x3A0
	private static Sprite[] _volumeAtlasSprites; // 0x1A8
	private static readonly List<CardUIPVP> _registry; // 0x1B0
	private string _elemTypeSrc; // 0x3A8
	private string _elemTypeUpper; // 0x3B0
	private int currentArrowSeed; // 0x3B8
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	public GameObject mega1TogglePanel; // 0x3C0
	public Toggle[] mega1RowToggles; // 0x3C8
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x3D0
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x3D8
	private List<int> mega1SelectedRows; // 0x3E0
	private bool isMega1PanelOpen; // 0x3E8
	private Coroutine mega1WatchCoroutine; // 0x3F0
	private Camera _matchCameraCache; // 0x3F8
	private bool _isLegendEffectActive; // 0x400
	private GameObject _mega1AlignOwner; // 0x408
	private VerticalLayoutGroup _mega1Vlg; // 0x410
	private ContentSizeFitter _mega1Csf; // 0x418
	private RectTransform _mega1PanelRt; // 0x420
	private Canvas _mega1Canvas; // 0x428
	private RectTransform[] _mega1ToggleRt; // 0x430
	private RectTransform[] _mega1ToggleParentRt; // 0x438
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x440
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x448
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x450
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x458
	private List<Toggle> _mega2Toggles; // 0x460
	private List<Animator> _mega2Animators; // 0x468
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x470
	private bool isMega2PanelOpen; // 0x478
	private bool isMegaIcarusSelectionMode; // 0x479
	private const int MegaIcarusRadius = 3; // Metadata: 0x0068AD3C
	private Coroutine mega2WatchCoroutine; // 0x480

	// Properties
	public static CardUIPVP ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180750060-0x00000001807500B0 0x0000000180750140-0x0000000180750290
	private static float QteChallengeWaitSec { get; } // 0x00000001807500B0-0x0000000180750140 

	// Nested types
	private struct QteButtonSlot // TypeDefIndex: 176
	{
		// Fields
		public Button btn; // 0x00
		public Transform parent; // 0x08
		public int siblingIndex; // 0x10
		public Vector2 anchorMin; // 0x14
		public Vector2 anchorMax; // 0x1C
		public Vector2 pivot; // 0x24
		public Vector2 anchoredPosition; // 0x2C
		public Vector2 sizeDelta; // 0x34
		public Vector3 localScale; // 0x3C
		public Quaternion localRotation; // 0x48
		public Image img; // 0x58
		public Sprite sprite; // 0x60
		public Image.Type imgType; // 0x68
		public bool preserveAspect; // 0x6C
		public Color imgColor; // 0x70
		public UnityEngine.UI.Text label; // 0x80
		public int labelFontSize; // 0x88
		public string labelText; // 0x90
	}

	private struct QteModalSlot // TypeDefIndex: 177
	{
		// Fields
		public Transform node; // 0x00
		public Transform parent; // 0x08
		public int siblingIndex; // 0x10
		public Vector2 anchorMin; // 0x14
		public Vector2 anchorMax; // 0x1C
		public Vector2 pivot; // 0x24
		public Vector2 anchoredPosition; // 0x2C
		public Vector2 sizeDelta; // 0x34
		public Vector3 localScale; // 0x3C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass197_0 // TypeDefIndex: 178
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass197_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseAuditionFrameGlow_b__0(float v); // 0x0000000180828F70-0x0000000180828FD0
		internal void _PulseAuditionFrameGlow_b__1(); // 0x0000000180828FD0-0x0000000180829040
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass202_0 // TypeDefIndex: 179
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass202_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ReleaseAuditionScrim_b__0(float v); // 0x0000000180829040-0x0000000180829130
		internal void _ReleaseAuditionScrim_b__1(); // 0x0000000180829130-0x00000001808291F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass250_0 // TypeDefIndex: 180
	{
		// Fields
		public Image cue; // 0x10
		public CardUIPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass250_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayArrowIntro_b__0(); // 0x00000001808291F0-0x00000001808292C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass251_0 // TypeDefIndex: 181
	{
		// Fields
		public CardUIPVP __4__this; // 0x10
		public string captured; // 0x18

		// Constructors
		public __c__DisplayClass251_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AttachArrowTapButton_b__0(); // 0x00000001808292C0-0x00000001808292F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass256_0 // TypeDefIndex: 182
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass256_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnArrowHitBurst_b__0(); // 0x00000001808292F0-0x0000000180829360
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass258_0 // TypeDefIndex: 183
	{
		// Fields
		public Image arrow; // 0x10
		public Vector3 originalPos; // 0x18
		public CardUIPVP __4__this; // 0x28

		// Constructors
		public __c__DisplayClass258_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakeArrowWrong_b__0(Color c); // 0x0000000180829360-0x0000000180829400
		internal void _ShakeArrowWrong_b__1(); // 0x0000000180829400-0x00000001808295F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass267_0 // TypeDefIndex: 184
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass267_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x00000001808295F0-0x00000001808296D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass287_0 // TypeDefIndex: 185
	{
		// Fields
		public int idx; // 0x10
		public CardUIPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass287_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x00000001808296D0-0x0000000180829700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass320_0 // TypeDefIndex: 186
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass320_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x0000000180829700-0x0000000180829740
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass327_0 // TypeDefIndex: 187
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass327_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x00000001806FA370-0x00000001806FA390
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__298 : IEnumerator<object> // TypeDefIndex: 188
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BackgroundFlickerShake_d__298(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180821D90-0x0000000180822350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822350-0x0000000180822390
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__268 : IEnumerator<object> // TypeDefIndex: 189
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__268(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180822390-0x0000000180822610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180822610-0x0000000180822650
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__295 : IEnumerator<object> // TypeDefIndex: 190
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__295(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180823450-0x00000001808236E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808236E0-0x0000000180823720
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__331 : IEnumerator<object> // TypeDefIndex: 191
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__331(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180823720-0x0000000180823C30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180823C30-0x0000000180823C70
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__241 : IEnumerator<object> // TypeDefIndex: 192
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
		private bool _wasInPerfectZone_5__6; // 0x44
		private bool _wasInGoodZone_5__7; // 0x45
		private float _qteWait_5__8; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__241(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180823C70-0x0000000180825130
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180825130-0x0000000180825170
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__218 : IEnumerator<object> // TypeDefIndex: 193
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__218(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x0000000180825170-0x00000001808253F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808253F0-0x0000000180825430
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__294 : IEnumerator<object> // TypeDefIndex: 194
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__294(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180825A60-0x0000000180825B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180825B80-0x0000000180825BC0
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__289 : IEnumerator<object> // TypeDefIndex: 195
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__289(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180825BC0-0x0000000180825F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180825F20-0x0000000180825F60
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__326 : IEnumerator<object> // TypeDefIndex: 196
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__326(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180825F60-0x0000000180826330
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180826330-0x0000000180826370
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__240 : IEnumerator<object> // TypeDefIndex: 197
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__240(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180826370-0x00000001808267D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808267D0-0x0000000180826810
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__239 : IEnumerator<object> // TypeDefIndex: 198
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__239(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180826810-0x0000000180826D20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180826D20-0x0000000180826D60
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__172 : IEnumerator<object> // TypeDefIndex: 199
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__172(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180827B50-0x0000000180827DB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180827DB0-0x0000000180827DF0
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__325 : IEnumerator<object> // TypeDefIndex: 200
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__325(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001808280E0-0x0000000180828370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180828370-0x00000001808283B0
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__171 : IEnumerator<object> // TypeDefIndex: 201
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__171(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180828630-0x00000001808289D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808289D0-0x0000000180828A10
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__328 : IEnumerator<object> // TypeDefIndex: 202
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__328(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180828A10-0x0000000180828C90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180828C90-0x0000000180828CD0
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__293 : IEnumerator<object> // TypeDefIndex: 203
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForWsSkillResolution_d__293(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180829900-0x0000000180829B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180829B40-0x0000000180829B80
	}

	// Constructors
	public CardUIPVP(); // 0x000000018074FA90-0x0000000180750060
	static CardUIPVP(); // 0x000000018074F730-0x000000018074FA90

	// Methods
	public static void ResetStaticState(); // 0x000000018074AB50-0x000000018074AC00
	public Image GetCenterCardImage(); // 0x0000000180319970-0x0000000180319980
	private void Start(); // 0x000000018074E140-0x000000018074E5F0
	private bool IsSkillCard(); // 0x0000000180746410-0x0000000180746520
	public int SkillCooldownLeft(); // 0x000000018074D7D0-0x000000018074D8F0
	private bool IsLocalSilenced(); // 0x0000000180746250-0x0000000180746320
	public int GetHandIndex(); // 0x0000000180745530-0x00000001807455D0
	public bool ValidateCardUsage(); // 0x000000018074F0D0-0x000000018074F280
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__171))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x000000018074D080-0x000000018074D0F0
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__172))]
	private IEnumerator RestoreBackgroundColor(); // 0x000000018074AC00-0x000000018074AC70
	private void SetupControlButtonListeners(); // 0x000000018074C0F0-0x000000018074C470
	private void HideDotSkillUI(); // 0x0000000180745D10-0x0000000180745F60
	private void ShowDotSkillUI(); // 0x000000018074D0F0-0x000000018074D440
	private void OnDestroy(); // 0x00000001807475A0-0x00000001807477C0
	private void CreateDotSkillPanel(); // 0x0000000180741A90-0x0000000180741DB0
	private void ApplyQteArrowMetrics(); // 0x000000018073B6B0-0x000000018073B8C0
	private void CreateTimeSliderWithZones(); // 0x0000000180742050-0x0000000180742830
	private void RemoveZonesFromSlider(); // 0x000000018074A240-0x000000018074A3E0
	private Transform GetQteZoneParent(); // 0x00000001807459F0-0x0000000180745B60
	private void ClearQteZones(Transform parent); // 0x00000001807402A0-0x00000001807403B0
	private void RebuildQteZones(); // 0x00000001807495A0-0x0000000180749820
	private void CreateQteZone(Transform parent, float fromSec, float toSec, float total, Color color, string suffix, bool sendToBack); // 0x0000000180741DB0-0x0000000180742050
	private static Sprite LoadVolumeSprite(string name); // 0x0000000180746F40-0x0000000180747130
	private void BuildAuditionTimeline(); // 0x000000018073D170-0x000000018073E720
	private void BuildPerfectMarkers(RectTransform track, float total); // 0x000000018073E720-0x000000018073EC40
	private void BuildAuditionRibbon(Transform host, Vector2 panelPos, float panelH); // 0x000000018073CBC0-0x000000018073D170
	private void BuildAuditionJudgeText(RectTransform root); // 0x000000018073C880-0x000000018073CBC0
	private void PulseAuditionStar(bool on); // 0x0000000180749120-0x0000000180749330
	private void CreateTimelineZone(RectTransform track, float fromSec, float toSec, float total, Color color, string nodeName); // 0x0000000180742830-0x0000000180742AF0
	private void ResetAuditionNeedle(); // 0x000000018074A6A0-0x000000018074A8E0
	private void ReleaseAuditionTimeline(bool destroy); // 0x0000000180749FA0-0x000000018074A240
	private void EnsurePokyAuditionFrame(); // 0x0000000180743B50-0x0000000180744020
	private static Image AddAuditionFrameLayer(RectTransform host, string nodeName, Sprite sprite, Color color, float pad); // 0x000000018073AA10-0x000000018073AC50
	private void PulseAuditionFrameGlow(); // 0x0000000180748EC0-0x0000000180749120
	private static void SetAuditionGlowAlpha(Image img, float a); // 0x000000018074BB60-0x000000018074BC40
	private void ApplyQteModalLayout(); // 0x000000018073BCE0-0x000000018073C290
	private void EnsureAuditionScrim(); // 0x0000000180743220-0x0000000180743670
	private void SetAuditionScrimAlpha(float a); // 0x000000018074BC40-0x000000018074BD40
	private void ReleaseAuditionScrim(bool immediate); // 0x0000000180749D20-0x0000000180749FA0
	private QteModalSlot CaptureQteModalNode(Transform node); // 0x000000018073F350-0x000000018073F520
	private void RestoreQteModalLayout(bool immediate); // 0x000000018074B1C0-0x000000018074B380
	private void RestoreQteModalNode(ref QteModalSlot slot); // 0x000000018074B380-0x000000018074B5B0
	private void RaiseQteOverlayOrder(); // 0x00000001807493D0-0x00000001807495A0
	private static void RaiseQteButtonNode(Transform canvasT, Button btn); // 0x0000000180749330-0x00000001807493D0
	private void ApplyQteButtonLayout(); // 0x000000018073B8C0-0x000000018073BCE0
	private void CaptureQteButton(int index, Button btn); // 0x000000018073EF30-0x000000018073F350
	private static void SkinDpadButton(Button btn, string dir); // 0x000000018074D8F0-0x000000018074DA90
	private void PlaceDpadButton(Button btn, Vector2 pos, float size); // 0x0000000180748300-0x00000001807484E0
	private void PlaceEnterButton(); // 0x00000001807484E0-0x0000000180748970
	private void RestoreQteButtonLayout(); // 0x000000018074AC70-0x000000018074B1C0
	private void CreateTimingText(); // 0x0000000180742AF0-0x0000000180742F80
	private void LoadDotSkillSprites(); // 0x0000000180746D60-0x0000000180746F40
	private GameObject CreateDefaultArrowPrefab(); // 0x0000000180741940-0x0000000180741A90
	private void CreateAnimationCanvas(); // 0x00000001807412A0-0x0000000180741940
	[IteratorStateMachine(typeof(_HideCenterCard_d__218))]
	private IEnumerator HideCenterCard(); // 0x0000000180745CA0-0x0000000180745D10
	private void OnTurnStart(int entityIndex); // 0x00000001807480B0-0x0000000180748220
	public void MarkAsUsed(); // 0x0000000180747130-0x0000000180747390
	public void RevertOptimisticUse(); // 0x000000018074B670-0x000000018074BAF0
	public void SetCardData(CardData data); // 0x000000018074BD40-0x000000018074C0F0
	public CardData GetCardData(); // 0x00000001802FF660-0x00000001802FF670
	private void RegisterInLookup(); // 0x0000000180749BB0-0x0000000180749D20
	public static CardUIPVP FindByCardId(int cardId); // 0x0000000180744100-0x0000000180744290
	public void AdoptSharedSkillRefs(CardUIPVP src); // 0x000000018073AC50-0x000000018073B0C0
	private static bool HasNoToggles(Toggle[] arr); // 0x0000000180745BE0-0x0000000180745CA0
	private bool RequiresDotSkillUI(); // 0x000000018074A3E0-0x000000018074A480
	private bool ValidateDotSkillComponents(); // 0x000000018074F280-0x000000018074F5C0
	private string ElementTypeUpper(); // 0x0000000180743170-0x0000000180743220
	private bool IsBuffCard(); // 0x00000001807460A0-0x00000001807460D0
	private bool IsAttackCard(); // 0x0000000180745F60-0x00000001807460A0
	private bool IsMega1Card(); // 0x0000000180746320-0x00000001807463B0
	private bool IsMega2Card(); // 0x00000001807463B0-0x0000000180746410
	public bool IsDotSkillCard(); // 0x00000001807460D0-0x0000000180746160
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__239))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x0000000180748D10-0x0000000180748D80
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__240))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x0000000180748CA0-0x0000000180748D10
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__241))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x0000000180745B60-0x0000000180745BE0
	private void ApplyServerQteWindow(); // 0x000000018073C290-0x000000018073C4D0
	private int CurrentQteElapsedMs(); // 0x00000001807430F0-0x0000000180743170
	private long? CurrentQteChallengeId(); // 0x0000000180742F80-0x00000001807430F0
	private int CalculateDotsToDestroy(); // 0x000000018073EC40-0x000000018073ED90
	private string GetLastTimingResult(); // 0x00000001807455D0-0x0000000180745740
	private string NormalizeArrowDir(string raw); // 0x0000000180747400-0x00000001807475A0
	private void GenerateDotArrows(); // 0x0000000180744650-0x0000000180744F40
	private void PlayArrowIntro(); // 0x0000000180748970-0x0000000180748CA0
	private void AttachArrowTapButton(Image arrow, string dir); // 0x000000018073C5A0-0x000000018073C7A0
	private void ApplyArrowSize(Image arrow); // 0x000000018073B5E0-0x000000018073B6B0
	private void RefreshArrowCue(); // 0x0000000180749820-0x0000000180749BB0
	private Color ArrowRestColor(Image arrow); // 0x000000018073C4D0-0x000000018073C5A0
	private void PulseArrow(Image arrow); // 0x0000000180748D80-0x0000000180748EC0
	private void SpawnArrowHitBurst(RectTransform arrow); // 0x000000018074DA90-0x000000018074DEC0
	private void RestoreShakenArrow(); // 0x000000018074B5B0-0x000000018074B670
	private void ShakeArrowWrong(Image arrow); // 0x000000018074CC70-0x000000018074D080
	private void ClearDotArrows(); // 0x000000018073FE50-0x00000001807402A0
	private int CountMatchingDotsOnBoard(); // 0x0000000180740FE0-0x00000001807412A0
	public void ResetCardVisual(); // 0x000000018074A8E0-0x000000018074AA30
	private void OnEnterButtonPress(); // 0x0000000180747800-0x0000000180747870
	private void OnDirectionButtonPress(string direction); // 0x00000001807477C0-0x0000000180747800
	private void ShowTimingResult(); // 0x000000018074D440-0x000000018074D7D0
	private void LateUpdate(); // 0x0000000180746CB0-0x0000000180746D60
	private void Update(); // 0x000000018074EEA0-0x000000018074F0D0
	private void CheckDotArrow(string dir); // 0x000000018073F870-0x000000018073FE50
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__268))]
	private IEnumerator BlinkEnterButton(); // 0x000000018073C810-0x000000018073C880
	private void ResetDotCombo(); // 0x000000018074AA30-0x000000018074AB50
	private string GetDirectionFromInput(); // 0x0000000180744F40-0x0000000180745070
	public void ConsumeCardCondition(int actorNumber); // 0x0000000180740960-0x0000000180740D10
	public string GetDisabledReason(); // 0x0000000180745070-0x0000000180745530
	private bool IsHandCurtainClosed(); // 0x0000000180746160-0x0000000180746250
	public bool CanUseCard(); // 0x000000018073ED90-0x000000018073EF30
	private bool CheckConditionUse(); // 0x000000018073F520-0x000000018073F870
	public void UpdateCardVisualPublic(); // 0x000000018074EBC0-0x000000018074EBD0
	private void UpdateCardVisual(); // 0x000000018074EBD0-0x000000018074ECE0
	public void ConvertToPlaceholder(); // 0x0000000180740D10-0x0000000180740FE0
	public static void ResetAllCardsForNewMatch(); // 0x000000018074A480-0x000000018074A6A0
	private void SetupMega1PanelOnce(); // 0x000000018074C470-0x000000018074C840
	public void StartMega1Panel(); // 0x000000018074DEC0-0x000000018074DF40
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__289))]
	private IEnumerator OpenMega1Panel(); // 0x0000000180748220-0x0000000180748290
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x0000000180747870-0x0000000180747B70
	private void UpdateMega1UI(); // 0x000000018074ECE0-0x000000018074EEA0
	private void CloseMega1Panel(bool executeDestroy); // 0x00000001807403B0-0x00000001807405B0
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__293))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x0068AB6C */, float renderWaitSec = 14f /* Metadata: 0x0068AB70 */); // 0x000000018074F5C0-0x000000018074F640
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__294))]
	private IEnumerator Mega1WatchTurnTime(); // 0x0000000180747390-0x0000000180747400
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__295))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x0000000180744020-0x0000000180744090
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__298))]
	private IEnumerator BackgroundFlickerShake(); // 0x000000018073C7A0-0x000000018073C810
	private Camera GetMatchCamera(); // 0x0000000180745740-0x00000001807459F0
	private bool EnsureMega1AlignCache(); // 0x0000000180743670-0x0000000180743B50
	private void LateUpdateMega1(); // 0x0000000180746520-0x0000000180746CB0
	private void SetupMega2PanelOnce(); // 0x000000018074C840-0x000000018074CC70
	private void AlignMega2TogglesToBoard(); // 0x000000018073B0C0-0x000000018073B5E0
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x000000018074F640-0x000000018074F730
	public void StartMega2Panel(); // 0x000000018074DF40-0x000000018074DFC0
	public void StartMegaIcarusPanel(); // 0x000000018074DFC0-0x000000018074E140
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__325))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x000000018074BAF0-0x000000018074BB60
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__326))]
	private IEnumerator OpenMega2Panel(); // 0x0000000180748290-0x0000000180748300
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x0000000180747B70-0x00000001807480B0
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__328))]
	private IEnumerator TriggerMega2Explosion(); // 0x000000018074E5F0-0x000000018074E660
	private void CloseMega2Panel(bool executeDestroy); // 0x00000001807405B0-0x0000000180740960
	public void ForceCloseMega2Panel(); // 0x0000000180744290-0x0000000180744650
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__331))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x0000000180744090-0x0000000180744100
	[CompilerGenerated]
	private void _Start_b__165_0(); // 0x000000018074E830-0x000000018074EBC0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__173_0(); // 0x000000018074E670-0x000000018074E6E0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__173_1(); // 0x000000018074E6E0-0x000000018074E750
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__173_2(); // 0x000000018074E750-0x000000018074E7C0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__173_3(); // 0x000000018074E7C0-0x000000018074E830
	[CompilerGenerated]
	private void _EnsureAuditionScrim_b__200_0(float v); // 0x000000018074E660-0x000000018074E670
}

