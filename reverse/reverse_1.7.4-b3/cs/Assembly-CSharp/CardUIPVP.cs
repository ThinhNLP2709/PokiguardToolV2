/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokiGuard.Audition;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class CardUIPVP : MonoBehaviour, IAuditionHost // TypeDefIndex: 175
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
	private bool _auditionV3; // 0xD8
	private int _auditionV3ElapsedMs; // 0xDC
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
	private readonly List<string> qtePresses; // 0x158
	private bool _qteArrowsFromServer; // 0x160
	private bool isDotSkillActive; // 0x161
	private float currentTimeValue; // 0x164
	private float damageMultiplier; // 0x168
	private Dictionary<string, Sprite> blueArrows; // 0x170
	private Dictionary<string, Sprite> purpleArrows; // 0x178
	private bool hasFinishedDotSkill; // 0x180
	private const string QTE_ZONE_PREFIX = "QteZone_"; // Metadata: 0x005ED79F
	private bool _qteForgiving; // 0x181
	private Image _qteShakeArrow; // 0x188
	private Vector3 _qteShakeHome; // 0x190
	private static readonly Color QteArrowIdle; // 0x08
	private static readonly Color QteArrowActive; // 0x18
	private static readonly Color QteArrowWrong; // 0x28
	private static readonly Color QteZoneGood; // 0x38
	private static readonly Color QteZonePerfect; // 0x48
	private static readonly Color QteSliderColorPerfect; // 0x58
	private bool _dotSkillPanelRuntimeCreated; // 0x19C
	private const string AUDITION_TIMELINE_NAME = "AuditionTimeline"; // Metadata: 0x005ED7A8
	private const string POKY_AUDITION_FRAME_NAME = "PokyAuditionFrame"; // Metadata: 0x005ED7B9
	private const string POKY_TIMELINE_BG = "Image/FriendUI/bgList"; // Metadata: 0x005ED7CB
	private const string POKY_PANEL_FRAME = "Image/FriendUI/bgPopupAlert"; // Metadata: 0x005ED7E1
	private const string POKY_BTN_OK = "Image/Common/btnOk"; // Metadata: 0x005ED7FD
	private const string POKY_TIMELINE_PLATE = "Image/Common/Gameplay-bgDialog"; // Metadata: 0x005ED810
	private const string POKY_AUDITION_RIBBON = "Image/Common/bar_ribbon1"; // Metadata: 0x005ED82F
	private const string POKY_PERFECT_STAR = "Image/FriendUI/gold_star"; // Metadata: 0x005ED848
	private const string POKY_PERFECT_LINE = "Image/Common/linePower"; // Metadata: 0x005ED861
	private const string POKY_NEEDLE_CAP = "Image/Common/btnNextPet0001"; // Metadata: 0x005ED878
	private const string POKY_ELAPSED_COMET = "Image/Common/fullMana"; // Metadata: 0x005ED894
	private const string POKY_NEEDLE_BALL = "Image/FriendUI/redDot"; // Metadata: 0x005ED8AA
	private const string DPAD_NEON_PREFIX = "DotSkillNeon/"; // Metadata: 0x005ED8C0
	private const string POKY_BTN_SPACE = "Image/petK/btnkhamht"; // Metadata: 0x005ED8CE
	private const string VOLUME_ATLAS_PATH = "Image/petK/fframe"; // Metadata: 0x005ED8E3
	private const string VOLUME_TRACK_SPRITE = "fframe_4"; // Metadata: 0x005ED8F5
	private const string VOLUME_KNOB_SPRITE = "fframe_0"; // Metadata: 0x005ED8FE
	private const string AUDITION_BALL_NAME = "NeedleBall"; // Metadata: 0x005ED907
	private const string AUDITION_JUDGE_NAME = "LiveJudgeText"; // Metadata: 0x005ED912
	private const string AUDITION_FRAME_GLOW_NAME = "FrameGlow"; // Metadata: 0x005ED920
	private const string AUDITION_FRAME_CORE_NAME = "FrameCore"; // Metadata: 0x005ED92A
	private const string AUDITION_RIBBON_NAME = "AuditionRibbon"; // Metadata: 0x005ED934
	private const string AUDITION_HIT_BURST_NAME = "ArrowHitBurst"; // Metadata: 0x005ED943
	private RectTransform _auditionTimeline; // 0x1A0
	private RectTransform _auditionNeedle; // 0x1A8
	private Image _auditionNeedleImg; // 0x1B0
	private Image _auditionTrackImg; // 0x1B8
	private RectTransform _auditionComet; // 0x1C0
	private RectTransform _auditionStar; // 0x1C8
	private RectTransform _auditionRibbon; // 0x1D0
	private RectTransform _auditionNeedleBall; // 0x1D8
	private UnityEngine.UI.Text _auditionJudgeText; // 0x1E0
	private Color _auditionTrackIdleColor; // 0x1E8
	private Color _auditionTrackPerfectColor; // 0x1F8
	private Color _auditionNeedleIdleColor; // 0x208
	private Color _auditionNeedlePerfectColor; // 0x218
	private int _auditionStarTweenId; // 0x228
	private Image _frameGlowImg; // 0x230
	private bool _qteTimelineV2; // 0x238
	private bool _qteBtnLayoutV2; // 0x239
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
	private QteButtonSlot[] _qteBtnSlots; // 0x240
	private bool _qteBtnLayoutApplied; // 0x248
	private const string AUDITION_SCRIM_NAME = "AuditionScrim"; // Metadata: 0x005ED951
	private const float AuditionScrimAlpha = 0.62f; // Metadata: 0x005ED95F
	private const float AuditionScrimFadeSec = 0.15f; // Metadata: 0x005ED963
	private Image _auditionScrim; // 0x250
	private QteModalSlot _qteModalPanelSlot; // 0x258
	private QteModalSlot _qteModalTextSlot; // 0x2A0
	private bool _qteModalApplied; // 0x2E8
	[Header("Control Buttons")]
	[Tooltip("N\u00FAt Up (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnUp; // 0x2F0
	[Tooltip("N\u00FAt Down (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnDown; // 0x2F8
	[Tooltip("N\u00FAt Left (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnLeft; // 0x300
	[Tooltip("N\u00FAt Right (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnRight; // 0x308
	[Tooltip("N\u00FAt Enter (t\u1EF1 \u0111\u1ED9ng t\u1EA1o n\u1EBFu null)")]
	public Button btnEnter; // 0x310
	[Header("Timing Zones on Time Slider")]
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float perfectStartTime; // 0x318
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Perfect (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float perfectEndTime; // 0x31C
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 2.5s")]
	public float goodStart1Time; // 0x320
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good \u0111\u1EA7u ti\u00EAn (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.0s")]
	public float goodEnd1Time; // 0x324
	[Tooltip("Th\u1EDDi gian b\u1EAFt \u0111\u1EA7u Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 3.3s")]
	public float goodStart2Time; // 0x328
	[Tooltip("Th\u1EDDi gian k\u1EBFt th\u00FAc Good th\u1EE9 hai (gi\u00E2y) - m\u1EB7c \u0111\u1ECBnh 4.2s")]
	public float goodEnd2Time; // 0x32C
	private int timingBonus; // 0x330
	[Header("Timing Bonus (for ATTACK_LEGEND_)")]
	[Tooltip("Bonus correctCount khi Perfect (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int perfectBonus; // 0x334
	[Tooltip("Bonus correctCount khi Good (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int goodBonus; // 0x338
	[Tooltip("Bonus correctCount khi Bad (n\u1EBFu kh\u00F4ng g\u00F5 \u0111\u1EE7 7 n\u00FAt)")]
	public int badBonus; // 0x33C
	[Tooltip("M\u00E0u text Perfect")]
	private Coroutine blinkCoroutine; // 0x340
	[Header("Legend Card Background Effects")]
	[Tooltip("\u1EA2nh n\u1EC1n c\u1EA7n \u00E1p d\u1EE5ng hi\u1EC7u \u1EE9ng")]
	public Image backgroundImage; // 0x348
	[Tooltip("M\u00E0u flash effect (default: tr\u1EAFng)")]
	public Color flashColor; // 0x350
	[Tooltip("S\u1ED1 l\u1EA7n flash")]
	public int flashCount; // 0x360
	[Tooltip("Th\u1EDDi gian m\u1ED7i l\u1EA7n flash (gi\u00E2y)")]
	public float flashDuration; // 0x364
	[Tooltip("C\u01B0\u1EDDng \u0111\u1ED9 rung (shake magnitude)")]
	public float shakeMagnitude; // 0x368
	[Tooltip("Th\u1EDDi gian rung (gi\u00E2y)")]
	public float shakeDuration; // 0x36C
	private Color originalBackgroundColor; // 0x370
	private bool isBackgroundEffectActive; // 0x380
	[Header("Legend Card Background Effects")]
	[Tooltip("Ch\u1EBF \u0111\u1ED9 t\u01B0\u01A1ng ph\u1EA3n: true = tr\u1EAFng, false = \u0111en")]
	public bool useWhiteContrast; // 0x381
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n tr\u1EAFng")]
	public Color whiteContrastColor; // 0x384
	[Tooltip("M\u00E0u t\u01B0\u01A1ng ph\u1EA3n \u0111en")]
	public Color blackContrastColor; // 0x394
	[Tooltip("Th\u1EDDi gian chuy\u1EC3n sang m\u00E0u t\u01B0\u01A1ng ph\u1EA3n (gi\u00E2y)")]
	public float contrastTransitionTime; // 0x3A4
	[Tooltip("Ch\u1EBF \u0111\u1ED9 flash: true = c\u00F3 transition m\u01B0\u1EE3t, false = flash g\u1EA5p")]
	public bool smoothTransition; // 0x3A8
	private static Sprite[] _volumeAtlasSprites; // 0x1A8
	private static readonly List<CardUIPVP> _registry; // 0x1B0
	private string _elemTypeSrc; // 0x3B0
	private string _elemTypeUpper; // 0x3B8
	private int currentArrowSeed; // 0x3C0
	[Header("MEGA1/MEGA3 Card Settings (chi\u00EAu ch\u1ECDn h\u00E0ng)")]
	public GameObject mega1TogglePanel; // 0x3C8
	public Toggle[] mega1RowToggles; // 0x3D0
	public UnityEngine.UI.Text mega1SelectedCountText; // 0x3D8
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA1/MEGA3 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega1; // 0x3E0
	private List<int> mega1SelectedRows; // 0x3E8
	private bool isMega1PanelOpen; // 0x3F0
	private Coroutine mega1WatchCoroutine; // 0x3F8
	private Camera _matchCameraCache; // 0x400
	private bool _isLegendEffectActive; // 0x408
	private GameObject _mega1AlignOwner; // 0x410
	private VerticalLayoutGroup _mega1Vlg; // 0x418
	private ContentSizeFitter _mega1Csf; // 0x420
	private RectTransform _mega1PanelRt; // 0x428
	private Canvas _mega1Canvas; // 0x430
	private RectTransform[] _mega1ToggleRt; // 0x438
	private RectTransform[] _mega1ToggleParentRt; // 0x440
	[Header("MEGA2 Card Settings")]
	[Tooltip("Panel cha ch\u1EE9a toggle m\u1EABu")]
	public GameObject mega2TogglePanel; // 0x448
	[Tooltip("Toggle m\u1EABu (1 c\u00E1i) \u2014 script s\u1EBD clone ra board.width \u00D7 board.height c\u00E1i")]
	public Toggle mega2TogglePrefab; // 0x450
	[Tooltip("Text hi\u1EC3n th\u1ECB s\u1ED1 \u0111\u00E3 ch\u1ECDn, v\u00ED d\u1EE5 \'\u0110\u00E3 ch\u1ECDn: 2/3\'")]
	public UnityEngine.UI.Text mega2SelectedCountText; // 0x458
	[Tooltip("GameObject ch\u1EE9a txt h\u01B0\u1EDBng d\u1EABn MEGA2 \u2014 hi\u1EC7n khi m\u1EDF panel, \u1EA9n khi \u0111\u00F3ng")]
	public GameObject txtInfoMega2; // 0x460
	private List<Toggle> _mega2Toggles; // 0x468
	private List<Animator> _mega2Animators; // 0x470
	[TupleElementNames(new string[2] {"col", "row" })]
	private List<ValueTuple<int, int>> mega2SelectedDots; // 0x478
	private bool isMega2PanelOpen; // 0x480
	private bool isMegaIcarusSelectionMode; // 0x481
	private const int MegaIcarusRadius = 3; // Metadata: 0x005ED967
	private Coroutine mega2WatchCoroutine; // 0x488

	// Properties
	public static CardUIPVP ActiveDotSkillCard { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180955550-0x00000001809555B0 0x00000001809555B0-0x0000000180955660
	CardData IAuditionHost.Card { get; } // 0x00000001802A8720-0x00000001802A8730 
	Transform IAuditionHost.OverlayRoot { get; } // 0x00000001809556E0-0x00000001809557F0 
	bool IAuditionHost.IsActive { get; } // 0x00000001809557F0-0x00000001809558E0 
	private static float QteChallengeWaitSec { get; } // 0x0000000180955A00-0x0000000180955A50 

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
	private sealed class __c__DisplayClass208_0 // TypeDefIndex: 178
	{
		// Fields
		public Image img; // 0x10

		// Constructors
		public __c__DisplayClass208_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseAuditionFrameGlow_b__0(float v); // 0x0000000180B094B0-0x0000000180B09520
		internal void _PulseAuditionFrameGlow_b__1(); // 0x0000000180B09520-0x0000000180B09590
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass213_0 // TypeDefIndex: 179
	{
		// Fields
		public Image img; // 0x10
		public GameObject go; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass213_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ReleaseAuditionScrim_b__0(float v); // 0x0000000180B09590-0x0000000180B09710
		internal void _ReleaseAuditionScrim_b__1(); // 0x0000000180B09710-0x0000000180B09A20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass261_0 // TypeDefIndex: 180
	{
		// Fields
		public Image cue; // 0x10
		public CardUIPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass261_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayArrowIntro_b__0(); // 0x0000000180B09A20-0x0000000180B09C80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass262_0 // TypeDefIndex: 181
	{
		// Fields
		public CardUIPVP __4__this; // 0x10
		public string captured; // 0x18

		// Constructors
		public __c__DisplayClass262_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachArrowTapButton_b__0(); // 0x0000000180B09C80-0x0000000180B09CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass267_0 // TypeDefIndex: 182
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass267_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnArrowHitBurst_b__0(); // 0x0000000180B09CD0-0x0000000180B09E00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass269_0 // TypeDefIndex: 183
	{
		// Fields
		public Image arrow; // 0x10
		public Vector3 originalPos; // 0x18
		public CardUIPVP __4__this; // 0x28

		// Constructors
		public __c__DisplayClass269_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ShakeArrowWrong_b__0(Color c); // 0x0000000180B09E00-0x0000000180B09F20
		internal void _ShakeArrowWrong_b__1(); // 0x0000000180B09F20-0x0000000180B0A430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass278_0 // TypeDefIndex: 184
	{
		// Fields
		public Image currentArrow; // 0x10

		// Constructors
		public __c__DisplayClass278_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CheckDotArrow_b__0(); // 0x0000000180B0A430-0x0000000180B0A5A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass298_0 // TypeDefIndex: 185
	{
		// Fields
		public int idx; // 0x10
		public CardUIPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass298_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupMega1PanelOnce_b__0(bool on); // 0x0000000180B0A5A0-0x0000000180B0A5D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass331_0 // TypeDefIndex: 186
	{
		// Fields
		public int c; // 0x10
		public int r; // 0x14
		public int idx; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Constructors
		public __c__DisplayClass331_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupMega2PanelOnce_b__0(bool on); // 0x0000000180B0A5D0-0x0000000180B0A610
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass338_0 // TypeDefIndex: 187
	{
		// Fields
		public int col; // 0x10
		public int row; // 0x14

		// Constructors
		public __c__DisplayClass338_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _OnMega2ToggleChanged_b__0([TupleElementNames(new string[2] {"col", "row" })] ValueTuple<int, int> d); // 0x0000000180ACC3F0-0x0000000180ACC410
	}

	[CompilerGenerated]
	private sealed class _BackgroundFlickerShake_d__309 : IEnumerator<object> // TypeDefIndex: 188
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BackgroundFlickerShake_d__309(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B0A610-0x0000000180B0ACC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0ACC0-0x0000000180B0AD00
	}

	[CompilerGenerated]
	private sealed class _BlinkEnterButton_d__279 : IEnumerator<object> // TypeDefIndex: 189
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Image _btnImage_5__2; // 0x28
		private Color _originalColor_5__3; // 0x30
		private Color _highlightColor_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEnterButton_d__279(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B0AD00-0x0000000180B0B0B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0B0B0-0x0000000180B0B0F0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega1RowDestruction_d__306 : IEnumerator<object> // TypeDefIndex: 190
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega1RowDestruction_d__306(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0B0F0-0x0000000180B0B480
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0B480-0x0000000180B0B4C0
	}

	[CompilerGenerated]
	private sealed class _ExecuteMega2DotDestruction_d__342 : IEnumerator<object> // TypeDefIndex: 191
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ExecuteMega2DotDestruction_d__342(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0B4C0-0x0000000180B0BB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0BB90-0x0000000180B0BBD0
	}

	[CompilerGenerated]
	private sealed class _HandleDotSkillSequence_d__252 : IEnumerator<object> // TypeDefIndex: 192
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HandleDotSkillSequence_d__252(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180B0BBD0-0x0000000180B0D800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0D800-0x0000000180B0D840
	}

	[CompilerGenerated]
	private sealed class _HideCenterCard_d__229 : IEnumerator<object> // TypeDefIndex: 193
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideCenterCard_d__229(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
		private bool MoveNext(); // 0x0000000180B0D840-0x0000000180B0DE00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0DE00-0x0000000180B0DE40
	}

	[CompilerGenerated]
	private sealed class _Mega1WatchTurnTime_d__305 : IEnumerator<object> // TypeDefIndex: 194
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Mega1WatchTurnTime_d__305(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0DE40-0x0000000180B0DFE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0DFE0-0x0000000180B0E020
	}

	[CompilerGenerated]
	private sealed class _OpenMega1Panel_d__300 : IEnumerator<object> // TypeDefIndex: 195
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega1Panel_d__300(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0E020-0x0000000180B0E920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0E920-0x0000000180B0E960
	}

	[CompilerGenerated]
	private sealed class _OpenMega2Panel_d__337 : IEnumerator<object> // TypeDefIndex: 196
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenMega2Panel_d__337(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0E960-0x0000000180B0F0C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0F0C0-0x0000000180B0F100
	}

	[CompilerGenerated]
	private sealed class _PlayCardAnimationForAll_d__251 : IEnumerator<object> // TypeDefIndex: 197
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardAnimationForAll_d__251(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B0F100-0x0000000180B0F8C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B0F8C0-0x0000000180B0F900
	}

	[CompilerGenerated]
	private sealed class _PlayCardClickPreviewAnimation_d__250 : IEnumerator<object> // TypeDefIndex: 198
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private GameObject _ghost_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCardClickPreviewAnimation_d__250(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B0F900-0x0000000180B102D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B102D0-0x0000000180B10310
	}

	[CompilerGenerated]
	private sealed class _RestoreBackgroundColor_d__183 : IEnumerator<object> // TypeDefIndex: 199
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _duration_5__3; // 0x2C
		private Color _startColor_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RestoreBackgroundColor_d__183(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B10310-0x0000000180B10620
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B10620-0x0000000180B10660
	}

	[CompilerGenerated]
	private sealed class _RunMegaIcarusAutoCast_d__336 : IEnumerator<object> // TypeDefIndex: 200
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunMegaIcarusAutoCast_d__336(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B10660-0x0000000180B10990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B10990-0x0000000180B109D0
	}

	[CompilerGenerated]
	private sealed class _ShakeBackgroundAfterEnter_d__182 : IEnumerator<object> // TypeDefIndex: 201
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20
		private Vector3 _originalPosition_5__2; // 0x28
		private Vector3 _originalScale_5__3; // 0x34
		private float _elapsed_5__4; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShakeBackgroundAfterEnter_d__182(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B109D0-0x0000000180B10F50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B10F50-0x0000000180B10F90
	}

	[CompilerGenerated]
	private sealed class _TriggerMega2Explosion_d__339 : IEnumerator<object> // TypeDefIndex: 202
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardUIPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TriggerMega2Explosion_d__339(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B10F90-0x0000000180B113B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B113B0-0x0000000180B113F0
	}

	[CompilerGenerated]
	private sealed class _WaitForWsSkillResolution_d__304 : IEnumerator<object> // TypeDefIndex: 203
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForWsSkillResolution_d__304(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180B113F0-0x0000000180B116C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B116C0-0x0000000180B11700
	}

	// Constructors
	public CardUIPVP(); // 0x0000000180978750-0x0000000180979040
	static CardUIPVP(); // 0x0000000180979040-0x00000001809793F0

	// Methods
	public static void ResetStaticState(); // 0x0000000180955660-0x00000001809556E0
	IEnumerator IAuditionHost.HideCenterCardCo(); // 0x00000001809558E0-0x00000001809558F0
	void IAuditionHost.OnAuditionPress(string dir); // 0x00000001809558F0-0x00000001809559A0
	void IAuditionHost.OnAuditionTap(int elapsedMs); // 0x00000001809559A0-0x0000000180955A00
	public Image GetCenterCardImage(); // 0x00000001802D8E20-0x00000001802D8E30
	private void Start(); // 0x0000000180955A50-0x00000001809562F0
	private bool IsSkillCard(); // 0x00000001809562F0-0x00000001809564A0
	public int SkillCooldownLeft(); // 0x00000001809564A0-0x0000000180956600
	private bool IsLocalSilenced(); // 0x0000000180956600-0x0000000180956770
	public int GetHandIndex(); // 0x0000000180956770-0x00000001809568F0
	public bool ValidateCardUsage(); // 0x00000001809568F0-0x0000000180956BB0
	[IteratorStateMachine(typeof(_ShakeBackgroundAfterEnter_d__182))]
	private IEnumerator ShakeBackgroundAfterEnter(); // 0x0000000180956BB0-0x0000000180956C50
	[IteratorStateMachine(typeof(_RestoreBackgroundColor_d__183))]
	private IEnumerator RestoreBackgroundColor(); // 0x0000000180956C50-0x0000000180956CF0
	private void SetupControlButtonListeners(); // 0x0000000180956CF0-0x00000001809572E0
	private void HideDotSkillUI(); // 0x00000001809572E0-0x0000000180957990
	private void ShowDotSkillUI(); // 0x0000000180957990-0x0000000180958220
	private void OnDestroy(); // 0x0000000180958220-0x0000000180958550
	private void CreateDotSkillPanel(); // 0x0000000180958550-0x0000000180958BC0
	private void ApplyQteArrowMetrics(); // 0x0000000180958BC0-0x0000000180958ED0
	private void CreateTimeSliderWithZones(); // 0x0000000180958ED0-0x0000000180959BC0
	private void RemoveZonesFromSlider(); // 0x0000000180959BC0-0x0000000180959F70
	private Transform GetQteZoneParent(); // 0x0000000180959F70-0x000000018095A340
	private void ClearQteZones(Transform parent); // 0x000000018095A340-0x000000018095A5A0
	private void RebuildQteZones(); // 0x000000018095A5A0-0x000000018095A940
	private void CreateQteZone(Transform parent, float fromSec, float toSec, float total, Color color, string suffix, bool sendToBack); // 0x000000018095A940-0x000000018095ACA0
	private static Sprite LoadVolumeSprite(string name); // 0x000000018095ACA0-0x000000018095AF70
	private void BuildAuditionTimeline(); // 0x000000018095AF70-0x000000018095D160
	private void BuildPerfectMarkers(RectTransform track, float total); // 0x000000018095D160-0x000000018095D8D0
	private void BuildAuditionRibbon(Transform host, Vector2 panelPos, float panelH); // 0x000000018095D8D0-0x000000018095E0C0
	private void BuildAuditionJudgeText(RectTransform root); // 0x000000018095E0C0-0x000000018095E5C0
	private void PulseAuditionStar(bool on); // 0x000000018095E5C0-0x000000018095EB70
	private void CreateTimelineZone(RectTransform track, float fromSec, float toSec, float total, Color color, string nodeName); // 0x000000018095EB70-0x000000018095EF50
	private void ResetAuditionNeedle(); // 0x000000018095EF50-0x000000018095F4B0
	private void ReleaseAuditionTimeline(bool destroy); // 0x000000018095F4B0-0x000000018095FBE0
	private void EnsurePokyAuditionFrame(); // 0x000000018095FBE0-0x0000000180960520
	private static Image AddAuditionFrameLayer(RectTransform host, string nodeName, Sprite sprite, Color color, float pad); // 0x0000000180960520-0x0000000180960850
	private void PulseAuditionFrameGlow(); // 0x0000000180960850-0x0000000180960B90
	private static void SetAuditionGlowAlpha(Image img, float a); // 0x0000000180960B90-0x0000000180960CE0
	private void ApplyQteModalLayout(); // 0x0000000180960CE0-0x0000000180961500
	private void EnsureAuditionScrim(); // 0x0000000180961500-0x0000000180961D60
	private void SetAuditionScrimAlpha(float a); // 0x0000000180961D60-0x0000000180961EE0
	private void ReleaseAuditionScrim(bool immediate); // 0x0000000180961EE0-0x0000000180962400
	private QteModalSlot CaptureQteModalNode(Transform node); // 0x0000000180962400-0x0000000180962780
	private void RestoreQteModalLayout(bool immediate); // 0x0000000180962780-0x0000000180962AD0
	private void RestoreQteModalNode(ref QteModalSlot slot); // 0x0000000180962AD0-0x0000000180962F50
	private void RaiseQteOverlayOrder(); // 0x0000000180962F50-0x0000000180963400
	private static void RaiseQteButtonNode(Transform canvasT, Button btn); // 0x0000000180963400-0x0000000180963640
	private void ApplyQteButtonLayout(); // 0x0000000180963640-0x0000000180963DC0
	private void CaptureQteButton(int index, Button btn); // 0x0000000180963DC0-0x00000001809647B0
	private static void SkinDpadButton(Button btn, string dir); // 0x00000001809647B0-0x0000000180964B50
	private void PlaceDpadButton(Button btn, Vector2 pos, float size); // 0x0000000180964B50-0x0000000180964F30
	private void PlaceEnterButton(); // 0x0000000180964F30-0x0000000180965830
	private void RestoreQteButtonLayout(); // 0x0000000180965830-0x0000000180966090
	private void CreateTimingText(); // 0x0000000180966090-0x0000000180966940
	private void LoadDotSkillSprites(); // 0x0000000180966940-0x0000000180966C60
	private GameObject CreateDefaultArrowPrefab(); // 0x0000000180966C60-0x0000000180966DB0
	private void CreateAnimationCanvas(); // 0x0000000180966DB0-0x0000000180967A20
	[IteratorStateMachine(typeof(_HideCenterCard_d__229))]
	private IEnumerator HideCenterCard(); // 0x0000000180967A20-0x0000000180967AC0
	private void OnTurnStart(int entityIndex); // 0x0000000180967AC0-0x0000000180967CD0
	public void MarkAsUsed(); // 0x0000000180967CD0-0x0000000180967FE0
	public void RevertOptimisticUse(); // 0x0000000180967FE0-0x00000001809686B0
	public void SetCardData(CardData data); // 0x00000001809686B0-0x0000000180968C70
	public CardData GetCardData(); // 0x00000001802A8720-0x00000001802A8730
	private void RegisterInLookup(); // 0x0000000180968C70-0x0000000180968E10
	public static CardUIPVP FindByCardId(int cardId); // 0x0000000180968E10-0x0000000180969110
	public void AdoptSharedSkillRefs(CardUIPVP src); // 0x0000000180969110-0x0000000180969B00
	private static bool HasNoToggles(Toggle[] arr); // 0x0000000180969B00-0x0000000180969C50
	private bool RequiresDotSkillUI(); // 0x0000000180969C50-0x0000000180969D50
	private bool ValidateDotSkillComponents(); // 0x0000000180969D50-0x000000018096A3F0
	private string ElementTypeUpper(); // 0x000000018096A3F0-0x000000018096A520
	private bool IsBuffCard(); // 0x000000018096A520-0x000000018096A550
	private bool IsAttackCard(); // 0x000000018096A550-0x000000018096A760
	private bool IsMega1Card(); // 0x000000018096A760-0x000000018096A7F0
	private bool IsMega2Card(); // 0x000000018096A7F0-0x000000018096A890
	public bool IsDotSkillCard(); // 0x000000018096A890-0x000000018096A980
	[IteratorStateMachine(typeof(_PlayCardClickPreviewAnimation_d__250))]
	private IEnumerator PlayCardClickPreviewAnimation(); // 0x000000018096A980-0x000000018096AA20
	[IteratorStateMachine(typeof(_PlayCardAnimationForAll_d__251))]
	public IEnumerator PlayCardAnimationForAll(int userActorNumber); // 0x000000018096AA20-0x000000018096AAC0
	[IteratorStateMachine(typeof(_HandleDotSkillSequence_d__252))]
	public IEnumerator HandleDotSkillSequence(int userActorNumber); // 0x000000018096AAC0-0x000000018096AB70
	private void ApplyServerQteWindow(); // 0x000000018096AB70-0x000000018096AE00
	private int CurrentQteElapsedMs(); // 0x000000018096AE00-0x000000018096AE90
	private long? CurrentQteChallengeId(); // 0x000000018096AE90-0x000000018096B000
	private int CalculateDotsToDestroy(); // 0x000000018096B000-0x000000018096B150
	private string GetLastTimingResult(); // 0x000000018096B150-0x000000018096B300
	private string NormalizeArrowDir(string raw); // 0x000000018096B300-0x000000018096B670
	private void GenerateDotArrows(); // 0x000000018096B670-0x000000018096C020
	private void PlayArrowIntro(); // 0x000000018096C020-0x000000018096C460
	private void AttachArrowTapButton(Image arrow, string dir); // 0x000000018096C460-0x000000018096C7A0
	private void ApplyArrowSize(Image arrow); // 0x000000018096C7A0-0x000000018096C960
	private void RefreshArrowCue(); // 0x000000018096C960-0x000000018096CCD0
	private Color ArrowRestColor(Image arrow); // 0x000000018096CCD0-0x000000018096CDD0
	private void PulseArrow(Image arrow); // 0x000000018096CDD0-0x000000018096CFA0
	private void SpawnArrowHitBurst(RectTransform arrow); // 0x000000018096CFA0-0x000000018096D5A0
	private void RestoreShakenArrow(); // 0x000000018096D5A0-0x000000018096D780
	private void ShakeArrowWrong(Image arrow); // 0x000000018096D780-0x000000018096DD80
	private void ClearDotArrows(); // 0x000000018096DD80-0x000000018096E270
	private int CountMatchingDotsOnBoard(); // 0x000000018096E270-0x000000018096E720
	public void ResetCardVisual(); // 0x000000018096E720-0x000000018096EA50
	private void OnEnterButtonPress(); // 0x000000018096EA50-0x000000018096EAC0
	private void OnDirectionButtonPress(string direction); // 0x000000018096EAC0-0x000000018096EB00
	private void ShowTimingResult(); // 0x000000018096EB00-0x000000018096F050
	private void LateUpdate(); // 0x000000018096F050-0x000000018096F1C0
	private void Update(); // 0x000000018096F1C0-0x000000018096F420
	private void CheckDotArrow(string dir); // 0x000000018096F420-0x000000018096FC20
	[IteratorStateMachine(typeof(_BlinkEnterButton_d__279))]
	private IEnumerator BlinkEnterButton(); // 0x000000018096FC20-0x000000018096FCC0
	private void ResetDotCombo(); // 0x000000018096FCC0-0x000000018096FE30
	private string GetDirectionFromInput(); // 0x000000018096FE30-0x000000018096FF80
	public void ConsumeCardCondition(int actorNumber); // 0x000000018096FF80-0x0000000180970630
	public string GetDisabledReason(); // 0x0000000180970630-0x0000000180970D90
	private bool IsHandCurtainClosed(); // 0x0000000180970D90-0x0000000180971000
	public bool CanUseCard(); // 0x0000000180971000-0x00000001809712A0
	private bool CheckConditionUse(); // 0x00000001809712A0-0x0000000180971B60
	public void UpdateCardVisualPublic(); // 0x0000000180971B60-0x0000000180971B70
	private void UpdateCardVisual(); // 0x0000000180971B70-0x0000000180971D80
	public void ConvertToPlaceholder(); // 0x0000000180971D80-0x0000000180972270
	public static void ResetAllCardsForNewMatch(); // 0x0000000180972270-0x0000000180972330
	private void SetupMega1PanelOnce(); // 0x0000000180972330-0x0000000180972A10
	public void StartMega1Panel(); // 0x0000000180972A10-0x0000000180972AC0
	[IteratorStateMachine(typeof(_OpenMega1Panel_d__300))]
	private IEnumerator OpenMega1Panel(); // 0x0000000180972AC0-0x0000000180972B60
	private void OnMega1ToggleChanged(int rowIndex, bool isOn); // 0x0000000180972B60-0x0000000180973060
	private void UpdateMega1UI(); // 0x0000000180973060-0x0000000180973370
	private void CloseMega1Panel(bool executeDestroy); // 0x0000000180973370-0x0000000180973850
	[IteratorStateMachine(typeof(_WaitForWsSkillResolution_d__304))]
	public IEnumerator WaitForWsSkillResolution(float resWaitSec = 3f /* Metadata: 0x005ED797 */, float renderWaitSec = 14f /* Metadata: 0x005ED79B */); // 0x0000000180973850-0x00000001809738C0
	[IteratorStateMachine(typeof(_Mega1WatchTurnTime_d__305))]
	private IEnumerator Mega1WatchTurnTime(); // 0x00000001809738C0-0x0000000180973960
	[IteratorStateMachine(typeof(_ExecuteMega1RowDestruction_d__306))]
	private IEnumerator ExecuteMega1RowDestruction(); // 0x0000000180973960-0x0000000180973A00
	[IteratorStateMachine(typeof(_BackgroundFlickerShake_d__309))]
	private IEnumerator BackgroundFlickerShake(); // 0x0000000180973A00-0x0000000180973AA0
	private Camera GetMatchCamera(); // 0x0000000180973AA0-0x0000000180973EE0
	private bool EnsureMega1AlignCache(); // 0x0000000180973EE0-0x00000001809749F0
	private void LateUpdateMega1(); // 0x00000001809749F0-0x00000001809757E0
	private void SetupMega2PanelOnce(); // 0x00000001809757E0-0x0000000180975FD0
	private void AlignMega2TogglesToBoard(); // 0x0000000180975FD0-0x0000000180976990
	private bool WorldToMega2PanelLocal(Vector2 worldPos, Camera matchCam, Camera uiCamera, RectTransform panelRt, out Vector2 local); // 0x0000000180976990-0x0000000180976B20
	public void StartMega2Panel(); // 0x0000000180976B20-0x0000000180976BD0
	public void StartMegaIcarusPanel(); // 0x0000000180976BD0-0x0000000180976EA0
	[IteratorStateMachine(typeof(_RunMegaIcarusAutoCast_d__336))]
	private IEnumerator RunMegaIcarusAutoCast(); // 0x0000000180976EA0-0x0000000180976F40
	[IteratorStateMachine(typeof(_OpenMega2Panel_d__337))]
	private IEnumerator OpenMega2Panel(); // 0x0000000180976F40-0x0000000180976FE0
	private void OnMega2ToggleChanged(int col, int row, int idx, bool isOn); // 0x0000000180976FE0-0x00000001809776F0
	[IteratorStateMachine(typeof(_TriggerMega2Explosion_d__339))]
	private IEnumerator TriggerMega2Explosion(); // 0x00000001809776F0-0x0000000180977790
	private void CloseMega2Panel(bool executeDestroy); // 0x0000000180977790-0x0000000180977F40
	public void ForceCloseMega2Panel(); // 0x0000000180977F40-0x00000001809786B0
	[IteratorStateMachine(typeof(_ExecuteMega2DotDestruction_d__342))]
	private IEnumerator ExecuteMega2DotDestruction(); // 0x00000001809786B0-0x0000000180978750
	[CompilerGenerated]
	private void _Start_b__176_0(); // 0x00000001809793F0-0x0000000180979810
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__184_0(); // 0x0000000180979810-0x0000000180979880
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__184_1(); // 0x0000000180979880-0x00000001809798F0
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__184_2(); // 0x00000001809798F0-0x0000000180979960
	[CompilerGenerated]
	private void _SetupControlButtonListeners_b__184_3(); // 0x0000000180979960-0x00000001809799D0
	[CompilerGenerated]
	private void _EnsureAuditionScrim_b__211_0(float v); // 0x00000001809799D0-0x0000000180979C10
}

