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

public class CardUI : MonoBehaviour // TypeDefIndex: 1882
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
	private float pendingSince; // 0x4C
	private const float PENDING_QUIET_SEC = 2f; // Metadata: 0x0068DA1C
	internal int lastBuffUsedTurn; // 0x50
	internal bool hasUsedBuffThisTurn; // 0x54
	private int currentDotSkillActorNumber; // 0x58
	[Header("Placeholder Settings")]
	[Tooltip("Sprite hi\u1EC3n th\u1ECB khi card \u0111\u00E3 \u0111\u01B0\u1EE3c s\u1EED d\u1EE5ng")]
	public Sprite placeholderSprite; // 0x60
	[Tooltip("M\u00E0u c\u1EE7a placeholder (default: gray v\u1EDBi alpha 0.5)")]
	public Color placeholderColor; // 0x68
	private Sprite originalSprite; // 0x78
	private bool isPlaceholder; // 0x80
	[Header("Card Animation Settings")]
	[Tooltip("Th\u1EDDi gian hi\u1EC3n th\u1ECB card animation (gi\u00E2y)")]
	public float animationDuration; // 0x84
	[Tooltip("Scale c\u1EE7a card khi \u1EDF gi\u1EEFa m\u00E0n h\u00ECnh")]
	public float centerCardScale; // 0x88
	[Tooltip("K\u00EDch th\u01B0\u1EDBc card gi\u1EEFa m\u00E0n h\u00ECnh")]
	private Vector2 centerCardSize; // 0x8C
	[Header("Card Visual")]
	[Tooltip("Image object hi\u1EC3n th\u1ECB card (child object)")]
	public Image imgtCard; // 0x98
	private Canvas animationCanvas; // 0xA0
	private Image centerCardImage; // 0xA8
	[Header("Dot Skill Settings")]
	[Tooltip("Panel ch\u1EE9a 7 n\u00FAt m\u0169i t\u00EAn (t\u1EF1 \u0111\u1ED9ng t\u00ECm ho\u1EB7c t\u1EA1o)")]
	public Transform dotSkillPanel; // 0xB0
	[Tooltip("Prefab Image \u0111\u1EC3 hi\u1EC3n th\u1ECB m\u0169i t\u00EAn")]
	public GameObject arrowPrefab; // 0xB8
	[Tooltip("Th\u1EDDi gian cho ph\u00E9p ng\u01B0\u1EDDi ch\u01A1i g\u00F5 ph\u00EDm (gi\u00E2y)")]
	public float dotSkillDuration; // 0xC0
	[Header("Dot Skill Time Slider")]
	[Tooltip("Slider hi\u1EC3n th\u1ECB th\u1EDDi gian (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Slider timeSlider; // 0xC8
	[Tooltip("M\u00E0u slider khi c\u00F2n nhi\u1EC1u th\u1EDDi gian")]
	public Color sliderColorNormal; // 0xD0
	[CompilerGenerated]
	private static CardUI _ActiveDotSkillCard_k__BackingField; // 0x00
	[Tooltip("M\u00E0u slider khi s\u1EAFp h\u1EBFt th\u1EDDi gian")]
	public Color sliderColorWarning; // 0xE0
	[Range(0f, 1f)]
	[Tooltip("Ng\u01B0\u1EE1ng chuy\u1EC3n m\u00E0u c\u1EA3nh b\u00E1o (% th\u1EDDi gian c\u00F2n l\u1EA1i)")]
	public float warningThreshold; // 0xF0
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Text hi\u1EC3n th\u1ECB Perfect/Good/Bad (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public UnityEngine.UI.Text timingText; // 0xF8
	[Tooltip("M\u00E0u text Perfect")]
	public Color perfectColor; // 0x100
	[Tooltip("M\u00E0u text Good")]
	public Color goodColor; // 0x110
	[Tooltip("M\u00E0u text Bad")]
	public Color badColor; // 0x120
	[Header("Damage Multipliers")]
	[Range(1f, 3f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Perfect")]
	public float perfectMultiplier; // 0x130
	[Range(1f, 2f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Good")]
	public float goodMultiplier; // 0x134
	[Range(0.5f, 1f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n dame khi Bad")]
	public float badMultiplier; // 0x138
	private List<Image> currentArrows; // 0x140
	private string[] directions; // 0x148
	private int currentDotIndex; // 0x150
	private int correctDotCount; // 0x154
	private bool isDotSkillActive; // 0x158
	private float currentTimeValue; // 0x15C
	private float damageMultiplier; // 0x160
	private Dictionary<string, Sprite> blueArrows; // 0x168
	private Dictionary<string, Sprite> purpleArrows; // 0x170
	private bool hasFinishedDotSkill; // 0x178
	private const string QTE_ZONE_PREFIX = "QteZone_"; // Metadata: 0x0068DA20
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
	private const string AUDITION_TIMELINE_NAME = "AuditionTimeline"; // Metadata: 0x0068DA29
	private const string POKY_AUDITION_FRAME_NAME = "PokyAuditionFrame"; // Metadata: 0x0068DA3A
	private const string POKY_TIMELINE_BG = "Image/FriendUI/bgList"; // Metadata: 0x0068DA4C
	private const string POKY_PANEL_FRAME = "Image/FriendUI/bgPopupAlert"; // Metadata: 0x0068DA62
	private const string POKY_BTN_OK = "Image/Common/btnOk"; // Metadata: 0x0068DA7E
	private const string POKY_TIMELINE_PLATE = "Image/Common/Gameplay-bgDialog"; // Metadata: 0x0068DA91
	private const string POKY_AUDITION_RIBBON = "Image/Common/bar_ribbon1"; // Metadata: 0x0068DAB0
	private const string POKY_PERFECT_STAR = "Image/FriendUI/gold_star"; // Metadata: 0x0068DAC9
	private const string POKY_PERFECT_LINE = "Image/Common/linePower"; // Metadata: 0x0068DAE2
	private const string POKY_NEEDLE_CAP = "Image/Common/btnNextPet0001"; // Metadata: 0x0068DAF9
	private const string POKY_ELAPSED_COMET = "Image/Common/fullMana"; // Metadata: 0x0068DB15
	private const string POKY_NEEDLE_BALL = "Image/FriendUI/redDot"; // Metadata: 0x0068DB2B
	private const string DPAD_NEON_PREFIX = "DotSkillNeon/"; // Metadata: 0x0068DB41
	private const string POKY_BTN_SPACE = "Image/petK/btnkhamht"; // Metadata: 0x0068DB4F
	private const string VOLUME_ATLAS_PATH = "Image/petK/fframe"; // Metadata: 0x0068DB64
	private const string VOLUME_TRACK_SPRITE = "fframe_4"; // Metadata: 0x0068DB76
	private const string VOLUME_KNOB_SPRITE = "fframe_0"; // Metadata: 0x0068DB7F
	private const string AUDITION_BALL_NAME = "NeedleBall"; // Metadata: 0x0068DB88
	private const string AUDITION_JUDGE_NAME = "LiveJudgeText"; // Metadata: 0x0068DB93
	private const string AUDITION_FRAME_GLOW_NAME = "FrameGlow"; // Metadata: 0x0068DBA1
	private const string AUDITION_FRAME_CORE_NAME = "FrameCore"; // Metadata: 0x0068DBAB
	private const string AUDITION_RIBBON_NAME = "AuditionRibbon"; // Metadata: 0x0068DBB5
	private const string AUDITION_HIT_BURST_NAME = "ArrowHitBurst"; // Metadata: 0x0068DBC4
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
	private static readonly Color TimelineTrackVolume; // 0x118
	private static readonly Color TimelineTrackVolumePerfect; // 0x128
	private static readonly Color TimelineTrackLitPerfect; // 0x138
	private static readonly Color TimelineNeedleLit; // 0x148
	private static readonly Color TimelineNeedleOnLit; // 0x158
	private static readonly Color TimelineJudgePerfect; // 0x168
	private static readonly Color TimelineJudgeGood; // 0x178
	private static readonly Color AuditionFrameGlow; // 0x188
	private static readonly Color AuditionFrameCore; // 0x198
	private QteButtonSlot[] _qteBtnSlots; // 0x238
	private bool _qteBtnLayoutApplied; // 0x240
	private const string AUDITION_SCRIM_NAME = "AuditionScrim"; // Metadata: 0x0068DBD2
	private const float AuditionScrimAlpha = 0.62f; // Metadata: 0x0068DBE0
	private const float AuditionScrimFadeSec = 0.15f; // Metadata: 0x0068DBE4
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
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	[Tooltip("Panel ch\u1EE9a 8 toggle \u0111\u1EC3 ch\u1ECDn h\u00E0ng (n\u00EAn c\u00F3 Canvas sortingOrder cao)")]
	public GameObject mega1TogglePanel; // 0x380
	[Tooltip("8 Toggle t\u01B0\u01A1ng \u1EE9ng h\u00E0ng 0-7 (row 0 = h\u00E0ng d\u01B0\u1EDBi c\u00F9ng)")]
	public Toggle[] mega1RowToggles; // 0x388
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 h\u00E0ng \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x390
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x398
	private List<int> mega1SelectedRows; // 0x3A0
	private bool isMega1PanelOpen; // 0x3A8
	private Coroutine mega1WatchCoroutine; // 0x3B0
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x3B8
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x3C0
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x3C8
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x3D0
	private List<Toggle> _mega2Toggles; // 0x3D8
	private List<Animator> _mega2Animators; // 0x3E0
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x3E8
	private bool isMega2PanelOpen; // 0x3F0
	private bool isMegaIcarusSelectionMode; // 0x3F1
	private Coroutine mega2WatchCoroutine; // 0x3F8
	[Header("MEGA_ICARUS Card Settings (ch\u1ECDn t\u00E2m + b\u00E1n k\u00EDnh)")]
	[Tooltip("Panel ch\u1EE9a toggle \u0111\u1EC3 ch\u1ECDn t\u00E2m tr\u00EAn b\u00E0n (gi\u1ED1ng MEGA2 nh\u01B0ng ch\u1EC9 ch\u1ECDn 1 t\u00E2m)")]
	public GameObject megaIcarusTogglePanel; // 0x400
	[Tooltip("Toggle m\u1EABu \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle megaIcarusTogglePrefab; // 0x408
	[Tooltip("Text hi\u1EC3n th\u1ECB h\u01B0\u1EDBng d\u1EABn ch\u1ECDn t\u00E2m")]
	public UnityEngine.UI.Text megaIcarusSelectedCountText; // 0x410
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA_ICARUS")]
	public GameObject txtInfoMegaIcarus; // 0x418
	private List<Toggle> _megaIcarusToggles; // 0x420
	private List<Animator> _megaIcarusAnimators; // 0x428
	[TupleElementNames(new string[2] {"col", "row" })]
	private ValueTuple<int, int>? megaIcarusSelectedCenter; // 0x430
	private bool isMegaIcarusPanelOpen; // 0x43C
	private bool isMegaIcarusAutoSelected; // 0x43D
	private Coroutine megaIcarusWatchCoroutine; // 0x440
	[Tooltip("B\u00E1n k\u00EDnh m\u1EB7c \u0111\u1ECBnh c\u1EE7a Mega Icarus (s\u1ED1 \u00F4 t\u1EEB t\u00E2m)")]
	public int megaIcarusDefaultRadius; // 0x448
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x44C
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x450
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x460
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x470
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x474
	private static Sprite[] _volumeAtlasSprites; // 0x1A8
	private static readonly List<CardUI> _registry; // 0x1B0
	private string _elemTypeSrc; // 0x478
	private string _elemTypeUpper; // 0x480
	private int currentArrowSeed; // 0x488
	private readonly List<string> qtePresses; // 0x490
	private bool _qteArrowsFromServer; // 0x498
	private bool _isLegendEffectActive; // 0x499
	private Camera _matchCameraCache; // 0x4A0
	private GameObject _mega1AlignOwner; // 0x4A8
	private VerticalLayoutGroup _mega1Vlg; // 0x4B0
	private ContentSizeFitter _mega1Csf; // 0x4B8
	private RectTransform _mega1PanelRt; // 0x4C0
	private Canvas _mega1Canvas; // 0x4C8
	private RectTransform[] _mega1ToggleRt; // 0x4D0
	private RectTransform[] _mega1ToggleParentRt; // 0x4D8
	private const float SkillHintMinIntervalSec = 0.1f; // Metadata: 0x0068DBE8
	private static float _lastSkillHintAt; // 0x1B8
	private static readonly Dictionary<string, Dictionary<string, object>> _pendingSkillHints; // 0x1C0

	// Properties
	public bool IsActionPending { get; } // 0x00000001805F17F0-0x00000001805F1800 
	public static CardUI ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806D4EC0-0x00000001806D4F10 0x00000001806D4FA0-0x00000001806D5010
	private static float QteChallengeWaitSec { get; } // 0x00000001806D4F10-0x00000001806D4FA0 

	// Nested types
	private struct QteButtonSlot // TypeDefIndex: 1883
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

	private struct QteModalSlot // TypeDefIndex: 1884
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
	private sealed class __c__DisplayClass234_0 // TypeDefIndex: 1885
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass234_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseAuditionFrameGlow_b__0(float v); // 0x00000001806E5D40-0x00000001806E5DA0
		internal void _PulseAuditionFrameGlow_b__1(); // 0x00000001806E5DA0-0x00000001806E5E10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass239_0 // TypeDefIndex: 1886
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass239_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ReleaseAuditionScrim_b__0(float v); // 0x00000001806E5E10-0x00000001806E5F00
		internal void _ReleaseAuditionScrim_b__1(); // 0x00000001806E5F00-0x00000001806E5FC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass294_0 // TypeDefIndex: 1887
	{
		// Fields
		public Image cue; // 0x10
		public CardUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass294_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayArrowIntro_b__0(); // 0x00000001806E6090-0x00000001806E6160
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass295_0 // TypeDefIndex: 1888
	{
		// Fields
		public CardUI __4__this; // 0x10
		public string captured; // 0x18

		// Constructors
		public __c__DisplayClass295_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AttachArrowTapButton_b__0(); // 0x00000001806E6160-0x00000001806E6190
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass300_0 // TypeDefIndex: 1889
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass300_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnArrowHitBurst_b__0(); // 0x00000001806E6190-0x00000001806E6200
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass302_0 // TypeDefIndex: 1890
	{
		// Fields
		public Image arrow; // 0x10
		public Vector3 originalPos; // 0x18
		public CardUI __4__this; // 0x28

		// Constructors
		public __c__DisplayClass302_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ShakeArrowWrong_b__0(Color c); // 0x00000001806E6200-0x00000001806E62A0
		internal void _ShakeArrowWrong_b__1(); // 0x00000001806E62A0-0x00000001806E6490
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass310_0 // TypeDefIndex: 1891
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass310_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x00000001806E6490-0x00000001806E6570
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass335_0 // TypeDefIndex: 1892
	{
		// Fields
		public int idx; // 0x10
		public CardUI __4__this; // 0x18

		// Constructors
		public __c__DisplayClass335_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x00000001806E66F0-0x00000001806E6720
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass353_0 // TypeDefIndex: 1893
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass353_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x00000001806E6810-0x00000001806E6850
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass358_0 // TypeDefIndex: 1894
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass358_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x00000001806FA370-0x00000001806FA390
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass365_0 // TypeDefIndex: 1895
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUI __4__this; // 0x20

		// Constructors
		public __c__DisplayClass365_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupMegaIcarusPanelOnce_b__0(bool on); // 0x00000001806FA390-0x00000001806FA3D0
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__323 : IEnumerator<object> // TypeDefIndex: 1896
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BackgroundFlickerShake_d__323(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806F2770-0x00000001806F2D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F2D30-0x00000001806F2D70
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__311 : IEnumerator<object> // TypeDefIndex: 1897
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__311(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806F2D70-0x00000001806F2FF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F2FF0-0x00000001806F3030
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__351 : IEnumerator<object> // TypeDefIndex: 1898
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__351(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F3140-0x00000001806F3730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F3730-0x00000001806F3770
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__362 : IEnumerator<object> // TypeDefIndex: 1899
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _guardOff_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__362(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F3770-0x00000001806F4100
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F4100-0x00000001806F4140
	}

	[CompilerGenerated]
	private sealed class _ExecuteMegaIcarusDotDestruction_d__374 : IEnumerator<object> // TypeDefIndex: 1900
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private int _col_5__2; // 0x28
		private int _row_5__3; // 0x2C
		private float _guardOff_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMegaIcarusDotDestruction_d__374(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F4140-0x00000001806F4890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F4890-0x00000001806F48D0
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__280 : IEnumerator<object> // TypeDefIndex: 1901
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
		private bool _wasInPerfectZone_5__6; // 0x44
		private bool _wasInGoodZone_5__7; // 0x45
		private float _qteWait_5__8; // 0x48
		private int _finalDamage_5__9; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__280(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806F4BB0-0x00000001806F6790
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F6790-0x00000001806F67D0
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__255 : IEnumerator<object> // TypeDefIndex: 1902
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__255(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x00000001806F67D0-0x00000001806F6A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F6A50-0x00000001806F6A90
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__350 : IEnumerator<object> // TypeDefIndex: 1903
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__350(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F6A90-0x00000001806F6BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F6BB0-0x00000001806F6BF0
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__337 : IEnumerator<object> // TypeDefIndex: 1904
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__337(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F6BF0-0x00000001806F6F50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F6F50-0x00000001806F6F90
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__357 : IEnumerator<object> // TypeDefIndex: 1905
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__357(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F6F90-0x00000001806F73A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F73A0-0x00000001806F73E0
	}

	[CompilerGenerated]
	private sealed class _OpenMegaIcarusPanel_d__369 : IEnumerator<object> // TypeDefIndex: 1906
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenMegaIcarusPanel_d__369(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F73E0-0x00000001806F78C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F78C0-0x00000001806F7900
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__278 : IEnumerator<object> // TypeDefIndex: 1907
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__278(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F7900-0x00000001806F7D60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F7D60-0x00000001806F7DA0
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__277 : IEnumerator<object> // TypeDefIndex: 1908
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__277(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806F7DA0-0x00000001806F82B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F82B0-0x00000001806F82F0
	}

	[CompilerGenerated]
	private sealed class _PlayCardEffectAnimation_d__279 : IEnumerator<object> // TypeDefIndex: 1909
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		public int userActorNumber; // 0x28
		private Active _active_5__2; // 0x30
		private int _damage_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardEffectAnimation_d__279(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806F82F0-0x00000001806F90B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F90B0-0x00000001806F90F0
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__209 : IEnumerator<object> // TypeDefIndex: 1910
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__209(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F90F0-0x00000001806F9350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F9350-0x00000001806F9390
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__368 : IEnumerator<object> // TypeDefIndex: 1911
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__368(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F9390-0x00000001806F97B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F97B0-0x00000001806F97F0
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__208 : IEnumerator<object> // TypeDefIndex: 1912
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__208(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F97F0-0x00000001806F9B90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F9B90-0x00000001806F9BD0
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__359 : IEnumerator<object> // TypeDefIndex: 1913
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__359(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F9BD0-0x00000001806F9E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F9E50-0x00000001806F9E90
	}

	[CompilerGenerated]
	private sealed class _TriggerMegaIcarusExplosion_d__371 : IEnumerator<object> // TypeDefIndex: 1914
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUI __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMegaIcarusExplosion_d__371(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F9E90-0x00000001806FA040
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806FA040-0x00000001806FA080
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__349 : IEnumerator<object> // TypeDefIndex: 1915
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
		public _WaitForWsSkillResolution_d__349(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806FA500-0x00000001806FA740
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806FA740-0x00000001806FA880
	}

	// Constructors
	public CardUI(); // 0x00000001806D4870-0x00000001806D4EC0
	static CardUI(); // 0x00000001806D4490-0x00000001806D4870

	// Methods
	public void BeginPendingAction(); // 0x00000001806BE460-0x00000001806BE480
	public void ClearPendingAction(); // 0x00000001806C2310-0x00000001806C2320
	public static void ResetStaticState(); // 0x00000001806CE8E0-0x00000001806CE990
	public Image GetCenterCardImage(); // 0x0000000180319960-0x0000000180319970
	private void Start(); // 0x00000001806D2990-0x00000001806D2E40
	public static bool IsRowSkillType(string upperType); // 0x00000001806C9720-0x00000001806C9790
	public static bool IsGalaxySkillType(string upperType); // 0x00000001806C9400-0x00000001806C9440
	public static bool IsMegaIcarusType(string upperType); // 0x00000001806C96E0-0x00000001806C9720
	public static bool IsHealConvertSkillType(string upperType); // 0x00000001806C9530-0x00000001806C9570
	public int SkillCooldownLeft(); // 0x00000001806D1F40-0x00000001806D2060
	public static bool IsAuditionSkillType(string upperType); // 0x00000001806C9190-0x00000001806C9200
	private bool IsSkillCard(); // 0x00000001806C9790-0x00000001806C98D0
	private bool IsLocalSilenced(); // 0x00000001806C9570-0x00000001806C9630
	public int GetHandIndex(); // 0x00000001806C8650-0x00000001806C86F0
	public bool IsDownedBuffAssist(); // 0x00000001806C92C0-0x00000001806C9400
	public bool ValidateCardUsage(); // 0x00000001806D3990-0x00000001806D3ED0
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__208))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x00000001806D17F0-0x00000001806D1860
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__209))]
	private IEnumerator RestoreBackgroundColor(); // 0x00000001806CE990-0x00000001806CEA00
	private void SetupControlButtonListeners(); // 0x00000001806D0430-0x00000001806D07B0
	private void HideDotSkillUI(); // 0x00000001806C8E30-0x00000001806C9080
	private void ShowDotSkillUI(); // 0x00000001806D1860-0x00000001806D1BB0
	private void OnDestroy(); // 0x00000001806CA890-0x00000001806CAAF0
	private void CreateDotSkillPanel(); // 0x00000001806C4460-0x00000001806C4780
	private void ApplyQteArrowMetrics(); // 0x00000001806BD300-0x00000001806BD510
	private void CreateTimeSliderWithZones(); // 0x00000001806C4A20-0x00000001806C5200
	private void RemoveZonesFromSlider(); // 0x00000001806CDFC0-0x00000001806CE160
	private Transform GetQteZoneParent(); // 0x00000001806C8B10-0x00000001806C8C80
	private void ClearQteZones(Transform parent); // 0x00000001806C2320-0x00000001806C2430
	private void RebuildQteZones(); // 0x00000001806CD310-0x00000001806CD590
	private void CreateQteZone(Transform parent, float fromSec, float toSec, float total, Color color, string suffix, bool sendToBack); // 0x00000001806C4780-0x00000001806C4A20
	private static Sprite LoadVolumeSprite(string name); // 0x00000001806CA220-0x00000001806CA410
	private void BuildAuditionTimeline(); // 0x00000001806BEDE0-0x00000001806C0390
	private void BuildPerfectMarkers(RectTransform track, float total); // 0x00000001806C0390-0x00000001806C08B0
	private void BuildAuditionRibbon(Transform host, Vector2 panelPos, float panelH); // 0x00000001806BE830-0x00000001806BEDE0
	private void BuildAuditionJudgeText(RectTransform root); // 0x00000001806BE4F0-0x00000001806BE830
	private void PulseAuditionStar(bool on); // 0x00000001806CCE90-0x00000001806CD0A0
	private void CreateTimelineZone(RectTransform track, float fromSec, float toSec, float total, Color color, string nodeName); // 0x00000001806C5200-0x00000001806C54C0
	private void ResetAuditionNeedle(); // 0x00000001806CE420-0x00000001806CE660
	private void ReleaseAuditionTimeline(bool destroy); // 0x00000001806CDD20-0x00000001806CDFC0
	private void EnsurePokyAuditionFrame(); // 0x00000001806C6520-0x00000001806C69F0
	private static Image AddAuditionFrameLayer(RectTransform host, string nodeName, Sprite sprite, Color color, float pad); // 0x00000001806BC040-0x00000001806BC280
	private void PulseAuditionFrameGlow(); // 0x00000001806CCC30-0x00000001806CCE90
	private static void SetAuditionGlowAlpha(Image img, float a); // 0x00000001806CFD40-0x00000001806CFE20
	private void ApplyQteModalLayout(); // 0x00000001806BD930-0x00000001806BDEE0
	private void EnsureAuditionScrim(); // 0x00000001806C5BF0-0x00000001806C6040
	private void SetAuditionScrimAlpha(float a); // 0x00000001806CFE20-0x00000001806CFF20
	private void ReleaseAuditionScrim(bool immediate); // 0x00000001806CDAA0-0x00000001806CDD20
	private QteModalSlot CaptureQteModalNode(Transform node); // 0x00000001806C1160-0x00000001806C1330
	private void RestoreQteModalLayout(bool immediate); // 0x00000001806CEF50-0x00000001806CF110
	private void RestoreQteModalNode(ref QteModalSlot slot); // 0x00000001806CF110-0x00000001806CF340
	private void RaiseQteOverlayOrder(); // 0x00000001806CD140-0x00000001806CD310
	private static void RaiseQteButtonNode(Transform canvasT, Button btn); // 0x00000001806CD0A0-0x00000001806CD140
	private void ApplyQteButtonLayout(); // 0x00000001806BD510-0x00000001806BD930
	private void CaptureQteButton(int index, Button btn); // 0x00000001806C0D40-0x00000001806C1160
	private static void SkinDpadButton(Button btn, string dir); // 0x00000001806D2160-0x00000001806D2300
	private void PlaceDpadButton(Button btn, Vector2 pos, float size); // 0x00000001806CBFF0-0x00000001806CC1D0
	private void PlaceEnterButton(); // 0x00000001806CC1D0-0x00000001806CC660
	private void RestoreQteButtonLayout(); // 0x00000001806CEA00-0x00000001806CEF50
	private void CreateTimingText(); // 0x00000001806C54C0-0x00000001806C5950
	private void LoadDotSkillSprites(); // 0x00000001806CA040-0x00000001806CA220
	private GameObject CreateDefaultArrowPrefab(); // 0x00000001806C4310-0x00000001806C4460
	private void CreateAnimationCanvas(); // 0x00000001806C3C70-0x00000001806C4310
	[IteratorStateMachine(typeof(_HideCenterCard_d__255))]
	private IEnumerator HideCenterCard(); // 0x00000001806C8DC0-0x00000001806C8E30
	private void OnTurnStart(int entityIndex); // 0x00000001806CBD30-0x00000001806CBEA0
	public void MarkAsUsed(); // 0x00000001806CA410-0x00000001806CA680
	public void RevertOptimisticUse(); // 0x00000001806CF400-0x00000001806CF890
	public void SetCardData(CardData data); // 0x00000001806CFF20-0x00000001806D0370
	public CardData GetCardData(); // 0x00000001802FF660-0x00000001802FF670
	private void RegisterInLookup(); // 0x00000001806CD930-0x00000001806CDAA0
	public static CardUI FindByCardId(int cardId); // 0x00000001806C6B40-0x00000001806C6CD0
	public void AdoptSharedSkillRefs(CardUI src); // 0x00000001806BC280-0x00000001806BC7D0
	private static bool HasNoToggles(Toggle[] arr); // 0x00000001806C8D00-0x00000001806C8DC0
	private bool RequiresDotSkillUI(); // 0x00000001806CE160-0x00000001806CE200
	private bool ValidateDotSkillComponents(); // 0x00000001806D3ED0-0x00000001806D4210
	private string ElementTypeUpper(); // 0x00000001806C5B40-0x00000001806C5BF0
	private bool IsBuffCard(); // 0x00000001806C9200-0x00000001806C9230
	private bool IsAttackCard(); // 0x00000001806C9080-0x00000001806C9190
	private bool IsMega1Card(); // 0x00000001806C9630-0x00000001806C96E0
	private bool ValidateMega1CardUsage(); // 0x00000001806D4210-0x00000001806D4320
	public void RefreshCardButtonState(); // 0x00000001806CD920-0x00000001806CD930
	public bool IsDotSkillCard(); // 0x00000001806C9230-0x00000001806C92C0
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__277))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x00000001806CCA00-0x00000001806CCA70
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__278))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x00000001806CC990-0x00000001806CCA00
	[IteratorStateMachine(typeof(_PlayCardEffectAnimation_d__279))]
	public IEnumerator PlayCardEffectAnimation(int userActorNumber); // 0x00000001806CCA70-0x00000001806CCAF0
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__280))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x00000001806C8C80-0x00000001806C8D00
	private void ApplyServerQteWindow(); // 0x00000001806BDEE0-0x00000001806BE120
	private int CurrentQteElapsedMs(); // 0x00000001806C5AC0-0x00000001806C5B40
	private long? CurrentQteChallengeId(); // 0x00000001806C5950-0x00000001806C5AC0
	private int CalculateDotsToDestroy(); // 0x00000001806C08B0-0x00000001806C0A90
	private void SetLegendMultiplier(float multiplier); // 0x00000001806D0370-0x00000001806D0430
	private string GetLastTimingResult(); // 0x00000001806C86F0-0x00000001806C8860
	private string NormalizeArrowDir(string raw); // 0x00000001806CA6F0-0x00000001806CA890
	private void GenerateDotArrows(); // 0x00000001806C7660-0x00000001806C7F60
	private void PlayArrowIntro(); // 0x00000001806CC660-0x00000001806CC990
	private void AttachArrowTapButton(Image arrow, string dir); // 0x00000001806BE1F0-0x00000001806BE3F0
	private void ApplyArrowSize(Image arrow); // 0x00000001806BD230-0x00000001806BD300
	private void RefreshArrowCue(); // 0x00000001806CD590-0x00000001806CD920
	private Color ArrowRestColor(Image arrow); // 0x00000001806BE120-0x00000001806BE1F0
	private void PulseArrow(Image arrow); // 0x00000001806CCAF0-0x00000001806CCC30
	private void SpawnArrowHitBurst(RectTransform arrow); // 0x00000001806D2300-0x00000001806D2730
	private void RestoreShakenArrow(); // 0x00000001806CF340-0x00000001806CF400
	private void ShakeArrowWrong(Image arrow); // 0x00000001806D13E0-0x00000001806D17F0
	private void ClearDotArrows(); // 0x00000001806C1EC0-0x00000001806C2310
	private int CountMatchingDotsOnBoard(); // 0x00000001806C39B0-0x00000001806C3C70
	public void ResetCardVisual(); // 0x00000001806CE660-0x00000001806CE7C0
	private void OnEnterButtonPress(); // 0x00000001806CAB30-0x00000001806CABA0
	private void OnDirectionButtonPress(string direction); // 0x00000001806CAAF0-0x00000001806CAB30
	private void ShowTimingResult(); // 0x00000001806D1BB0-0x00000001806D1F40
	private void Update(); // 0x00000001806D3760-0x00000001806D3990
	private void CheckDotArrow(string dir); // 0x00000001806C18E0-0x00000001806C1EC0
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__311))]
	private IEnumerator BlinkEnterButton(); // 0x00000001806BE480-0x00000001806BE4F0
	private void ResetDotCombo(); // 0x00000001806CE7C0-0x00000001806CE8E0
	private string GetDirectionFromInput(); // 0x00000001806C7F60-0x00000001806C8090
	public void ConsumeCardCondition(int actorNumber); // 0x00000001806C3040-0x00000001806C36D0
	public string GetDisabledReason(); // 0x00000001806C8090-0x00000001806C8650
	private bool IsHandCurtainClosed(); // 0x00000001806C9440-0x00000001806C9530
	public bool CanUseCard(); // 0x00000001806C0A90-0x00000001806C0D40
	private bool CheckConditionUse(); // 0x00000001806C1330-0x00000001806C18E0
	private void UpdateCardVisual(); // 0x00000001806D3490-0x00000001806D35A0
	public void ConvertToPlaceholder(); // 0x00000001806C36D0-0x00000001806C39B0
	public static void ResetAllCardsForNewMatch(); // 0x00000001806CE200-0x00000001806CE420
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__323))]
	private IEnumerator BackgroundFlickerShake(); // 0x00000001806BE3F0-0x00000001806BE460
	private Camera GetMatchCamera(); // 0x00000001806C8860-0x00000001806C8B10
	private bool EnsureMega1AlignCache(); // 0x00000001806C6040-0x00000001806C6520
	private void LateUpdate(); // 0x00000001806C98D0-0x00000001806CA040
	private void SetupMega1PanelOnce(); // 0x00000001806D07B0-0x00000001806D0B80
	public void StartMega1Panel(); // 0x00000001806D2730-0x00000001806D27B0
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__337))]
	private IEnumerator OpenMega1Panel(); // 0x00000001806CBEA0-0x00000001806CBF10
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x00000001806CABA0-0x00000001806CAFC0
	private static void SendSkillHintSafe(Dictionary<string, object> payload); // 0x00000001806CFB80-0x00000001806CFD40
	private static string SkillHintKey(Dictionary<string, object> p); // 0x00000001806D2060-0x00000001806D2160
	private static void SendSkillHintNow(Dictionary<string, object> payload); // 0x00000001806CFA40-0x00000001806CFB80
	private static void FlushPendingSkillHints(); // 0x00000001806C6CD0-0x00000001806C6EF0
	private static void SendQteEventSafe(Dictionary<string, object> payload); // 0x00000001806CF900-0x00000001806CFA40
	private void UpdateMega1UI(); // 0x00000001806D35A0-0x00000001806D3760
	private void CloseMega1Panel(bool executeDestroy); // 0x00000001806C2430-0x00000001806C2630
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__349))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x0068DA14 */, float renderWaitSec = 14f /* Metadata: 0x0068DA18 */); // 0x00000001806D4320-0x00000001806D43A0
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__350))]
	private IEnumerator Mega1WatchTurnTime(); // 0x00000001806CA680-0x00000001806CA6F0
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__351))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x00000001806C69F0-0x00000001806C6A60
	private void AccumulateMega1WaveIntoDestroyedCountByTag(); // 0x00000001806BB990-0x00000001806BBD20
	private void SetupMega2PanelOnce(); // 0x00000001806D0B80-0x00000001806D0FB0
	private void AlignMega2TogglesToBoard(); // 0x00000001806BC7D0-0x00000001806BCD00
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x00000001806D43A0-0x00000001806D4490
	public void StartMega2Panel(); // 0x00000001806D27B0-0x00000001806D2830
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__357))]
	private IEnumerator OpenMega2Panel(); // 0x00000001806CBF10-0x00000001806CBF80
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x00000001806CAFC0-0x00000001806CB780
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__359))]
	private IEnumerator TriggerMega2Explosion(); // 0x00000001806D2E40-0x00000001806D2EB0
	private void CloseMega2Panel(bool executeDestroy); // 0x00000001806C2630-0x00000001806C29E0
	public void ForceCloseMega2Panel(); // 0x00000001806C6EF0-0x00000001806C72B0
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__362))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x00000001806C6A60-0x00000001806C6AD0
	private HashSet<ValueTuple<int, int>> Collect3x3Positions([TupleElementNames(new string[2] {"col", "row" })] List<ValueTuple<int, int>> dots, int W, int H); // 0x00000001806C2D40-0x00000001806C2F20
	private void AccumulateMega2WaveIntoDestroyedCountByTag(HashSet<ValueTuple<int, int>> positions); // 0x00000001806BBD20-0x00000001806BC040
	private void SetupMegaIcarusPanelOnce(); // 0x00000001806D0FB0-0x00000001806D13E0
	private void AlignMegaIcarusTogglesToBoard(); // 0x00000001806BCD00-0x00000001806BD230
	public void StartMegaIcarusPanel(); // 0x00000001806D2830-0x00000001806D2990
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__368))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x00000001806CF890-0x00000001806CF900
	[IteratorStateMachine(typeof(_OpenMegaIcarusPanel_d__369))]
	private IEnumerator OpenMegaIcarusPanel(); // 0x00000001806CBF80-0x00000001806CBFF0
	private void OnMegaIcarusToggleChanged(int col, int row, int idx, bool isOn); // 0x00000001806CB780-0x00000001806CBD30
	[IteratorStateMachine(typeof(_TriggerMegaIcarusExplosion_d__371))]
	private IEnumerator TriggerMegaIcarusExplosion(); // 0x00000001806D2EB0-0x00000001806D2F20
	private void CloseMegaIcarusPanel(bool executeDestroy); // 0x00000001806C29E0-0x00000001806C2D40
	public void ForceCloseMegaIcarusPanel(); // 0x00000001806C72B0-0x00000001806C7660
	[IteratorStateMachine(typeof(_ExecuteMegaIcarusDotDestruction_d__374))]
	private IEnumerator ExecuteMegaIcarusDotDestruction(); // 0x00000001806C6AD0-0x00000001806C6B40
	private HashSet<ValueTuple<int, int>> CollectRadiusPositions(int centerCol, int centerRow, int radius, int W, int H); // 0x00000001806C2F20-0x00000001806C3040
	[CompilerGenerated]
	private void _Start_b__196_0(); // 0x00000001806D30F0-0x00000001806D3490
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__210_0(); // 0x00000001806D2F30-0x00000001806D2FA0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__210_1(); // 0x00000001806D2FA0-0x00000001806D3010
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__210_2(); // 0x00000001806D3010-0x00000001806D3080
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__210_3(); // 0x00000001806D3080-0x00000001806D30F0
	[CompilerGenerated]
	private void _EnsureAuditionScrim_b__237_0(float v); // 0x00000001806D2F20-0x00000001806D2F30
}

