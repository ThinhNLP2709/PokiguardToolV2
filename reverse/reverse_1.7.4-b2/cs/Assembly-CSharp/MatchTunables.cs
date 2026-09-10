/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchTunables // TypeDefIndex: 1172
{
	// Fields
	private const string K_RHYTHM = "tun.rhythm"; // Metadata: 0x0068CB25
	private const string K_NET = "tun.net"; // Metadata: 0x0068CB30
	private const string K_BLINK = "tun.blink"; // Metadata: 0x0068CB38
	private const string K_SHADOW = "tun.shadowReport"; // Metadata: 0x0068CB42
	private const string K_LOG = "tun.log"; // Metadata: 0x0068CB53
	[CompilerGenerated]
	private static float _SwapSlideSec_k__BackingField; // 0x00
	[CompilerGenerated]
	private static float _AfterExplodeSec_k__BackingField; // 0x04
	[CompilerGenerated]
	private static float _FallLandBufferSec_k__BackingField; // 0x08
	[CompilerGenerated]
	private static float _MatchFlashSec_k__BackingField; // 0x0C
	[CompilerGenerated]
	private static float _EffectsLeadSec_k__BackingField; // 0x10
	[CompilerGenerated]
	private static float _PopupSec_k__BackingField; // 0x14
	[CompilerGenerated]
	private static float _EntryFlySec_k__BackingField; // 0x18
	[CompilerGenerated]
	private static float _EntryFlyStaggerSec_k__BackingField; // 0x1C
	[CompilerGenerated]
	private static float _EmptyEntryShrinkSec_k__BackingField; // 0x20
	[CompilerGenerated]
	private static float _RageConsumedPopupSec_k__BackingField; // 0x24
	[CompilerGenerated]
	private static float _AttackSwingSec_k__BackingField; // 0x28
	[CompilerGenerated]
	private static float _AttackPopupSec_k__BackingField; // 0x2C
	[CompilerGenerated]
	private static float _AttackResetSec_k__BackingField; // 0x30
	[CompilerGenerated]
	private static float _CardUseSec_k__BackingField; // 0x34
	[CompilerGenerated]
	private static float _CardHideLeadSec_k__BackingField; // 0x38
	[CompilerGenerated]
	private static float _CardCurtainHoldSec_k__BackingField; // 0x3C
	[CompilerGenerated]
	private static float _FusionCurtainHoldSec_k__BackingField; // 0x40
	[CompilerGenerated]
	private static float _OpsBudgetSec_k__BackingField; // 0x44
	[CompilerGenerated]
	private static float _OverBudgetFactor_k__BackingField; // 0x48
	[CompilerGenerated]
	private static float _AnimAckBufferSec_k__BackingField; // 0x4C
	[CompilerGenerated]
	private static float _QteWaitSec_k__BackingField; // 0x50
	[CompilerGenerated]
	private static float _BlinkHz_k__BackingField; // 0x54
	[CompilerGenerated]
	private static float _BlinkStepSec_k__BackingField; // 0x58
	[CompilerGenerated]
	private static int _ShadowReportEvery_k__BackingField; // 0x5C
	[CompilerGenerated]
	private static int _LogLevel_k__BackingField; // 0x60
	[CompilerGenerated]
	private static int _SnapshotCount_k__BackingField; // 0x64
	private const string K_FX = "tun.fx"; // Metadata: 0x0068CB5B
	private const string K_FX_INVERT = "tun.fx.invert"; // Metadata: 0x0068CB62
	private const string K_QTE = "tun.qte"; // Metadata: 0x0068CB70
	private static bool _fxHitFlash; // 0x68
	private static bool _fxTurnBanner; // 0x69
	private static bool _fxComboPop; // 0x6A
	private static bool _fxComboBanner; // 0x6B
	[CompilerGenerated]
	private static float _FxHitFlashMinPct_k__BackingField; // 0x6C
	[CompilerGenerated]
	private static float _FxFlashSec_k__BackingField; // 0x70
	[CompilerGenerated]
	private static float _FxShakeSec_k__BackingField; // 0x74
	[CompilerGenerated]
	private static float _FxShakePixels_k__BackingField; // 0x78
	[CompilerGenerated]
	private static float _FxTurnBannerSec_k__BackingField; // 0x7C
	[CompilerGenerated]
	private static float _InvertAmount_k__BackingField; // 0x80
	[CompilerGenerated]
	private static float _InvertDim_k__BackingField; // 0x84
	[CompilerGenerated]
	private static float _QteArrowSize_k__BackingField; // 0x88
	[CompilerGenerated]
	private static float _QteArrowSpacing_k__BackingField; // 0x8C
	[CompilerGenerated]
	private static float _QteBtnSize_k__BackingField; // 0x90
	private const string K_TURN_ANNOUNCE = "tun.turnAnnounce"; // Metadata: 0x0068CB78
	[CompilerGenerated]
	private static bool _TurnAnnounceOn_k__BackingField; // 0x94
	[CompilerGenerated]
	private static float _TurnAnnounceShowSec_k__BackingField; // 0x98
	[CompilerGenerated]
	private static float _TurnAnnouncePopSec_k__BackingField; // 0x9C
	[CompilerGenerated]
	private static float _TurnAnnounceFadeSec_k__BackingField; // 0xA0
	[CompilerGenerated]
	private static int _TurnAnnounceFontSize_k__BackingField; // 0xA4
	[CompilerGenerated]
	private static bool _TurnAnnounceShowAvatar_k__BackingField; // 0xA8
	[CompilerGenerated]
	private static float _TurnAnnounceYOffset_k__BackingField; // 0xAC
	[CompilerGenerated]
	private static Color _TurnAnnounceColorSelf_k__BackingField; // 0xB0
	[CompilerGenerated]
	private static Color _TurnAnnounceColorOther_k__BackingField; // 0xC0
	[CompilerGenerated]
	private static Color _TurnAnnounceColorBoss_k__BackingField; // 0xD0
	[CompilerGenerated]
	private static bool _TurnAnnounceLowTierStatic_k__BackingField; // 0xE0
	[CompilerGenerated]
	private static bool _TurnAnnounceSfx_k__BackingField; // 0xE1
	public const string K_TURN_ANNOUNCE_UI = "match.turnAnnounce"; // Metadata: 0x0068CB89

	// Properties
	public static float SwapSlideSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588980-0x00000001805889D0 0x0000000180589B70-0x0000000180589BD0
	public static float AfterExplodeSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587C50-0x0000000180587CA0 0x0000000180588E50-0x0000000180588EB0
	public static float FallLandBufferSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805880B0-0x0000000180588100 0x0000000180589390-0x00000001805893F0
	public static float MatchFlashSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805885E0-0x0000000180588630 0x0000000180589750-0x00000001805897B0
	public static float EffectsLeadSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587F70-0x0000000180587FC0 0x0000000180589210-0x0000000180589270
	public static float PopupSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805886D0-0x0000000180588720 0x0000000180589870-0x00000001805898D0
	public static float EntryFlySec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588010-0x0000000180588060 0x00000001805892D0-0x0000000180589330
	public static float EntryFlyStaggerSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588060-0x00000001805880B0 0x0000000180589330-0x0000000180589390
	public static float EmptyEntryShrinkSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587FC0-0x0000000180588010 0x0000000180589270-0x00000001805892D0
	public static float RageConsumedPopupSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588890-0x00000001805888E0 0x0000000180589A50-0x0000000180589AB0
	public static float AttackSwingSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587D90-0x0000000180587DE0 0x0000000180588FD0-0x0000000180589030
	public static float AttackPopupSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587CF0-0x0000000180587D40 0x0000000180588F10-0x0000000180588F70
	public static float AttackResetSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587D40-0x0000000180587D90 0x0000000180588F70-0x0000000180588FD0
	public static float CardUseSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587F20-0x0000000180587F70 0x00000001805891B0-0x0000000180589210
	public static float CardHideLeadSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587ED0-0x0000000180587F20 0x0000000180589150-0x00000001805891B0
	public static float CardCurtainHoldSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587E80-0x0000000180587ED0 0x00000001805890F0-0x0000000180589150
	public static float FusionCurtainHoldSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588100-0x0000000180588150 0x00000001805893F0-0x0000000180589450
	public static float OpsBudgetSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588630-0x0000000180588680 0x00000001805897B0-0x0000000180589810
	public static float OverBudgetFactor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588680-0x00000001805886D0 0x0000000180589810-0x0000000180589870
	public static float AnimAckBufferSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587CA0-0x0000000180587CF0 0x0000000180588EB0-0x0000000180588F10
	public static float QteWaitSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588840-0x0000000180588890 0x00000001805899F0-0x0000000180589A50
	public static float BlinkHz { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587DE0-0x0000000180587E30 0x0000000180589030-0x0000000180589090
	public static float BlinkStepSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180587E30-0x0000000180587E80 0x0000000180589090-0x00000001805890F0
	public static int ShadowReportEvery { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805888E0-0x0000000180588930 0x0000000180589AB0-0x0000000180589B10
	public static int LogLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588590-0x00000001805885E0 0x00000001805896F0-0x0000000180589750
	public static int SnapshotCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588930-0x0000000180588980 0x0000000180589B10-0x0000000180589B70
	public static bool FxHitFlash { get; } // 0x00000001805882B0-0x0000000180588320 
	public static bool FxTurnBanner { get; } // 0x0000000180588410-0x0000000180588480 
	public static bool FxComboPop { get; } // 0x00000001805881A0-0x0000000180588210 
	public static bool FxComboBanner { get; } // 0x0000000180588150-0x00000001805881A0 
	public static float FxHitFlashMinPct { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588260-0x00000001805882B0 0x00000001805894B0-0x0000000180589510
	public static float FxFlashSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588210-0x0000000180588260 0x0000000180589450-0x00000001805894B0
	public static float FxShakeSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588370-0x00000001805883C0 0x0000000180589570-0x00000001805895D0
	public static float FxShakePixels { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588320-0x0000000180588370 0x0000000180589510-0x0000000180589570
	public static float FxTurnBannerSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805883C0-0x0000000180588410 0x00000001805895D0-0x0000000180589630
	public static float InvertAmount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588480-0x00000001805884E0 0x0000000180589630-0x0000000180589690
	public static float InvertDim { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805884E0-0x0000000180588540 0x0000000180589690-0x00000001805896F0
	public static float QteArrowSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588720-0x0000000180588780 0x00000001805898D0-0x0000000180589930
	public static float QteArrowSpacing { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588780-0x00000001805887E0 0x0000000180589930-0x0000000180589990
	public static float QteBtnSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805887E0-0x0000000180588840 0x0000000180589990-0x00000001805899F0
	public static bool TurnAnnounceOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588C10-0x0000000180588C70 0x0000000180589E10-0x0000000180589E70
	public static float TurnAnnounceShowSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588D90-0x0000000180588DF0 0x0000000180589F90-0x0000000180589FF0
	public static float TurnAnnouncePopSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588C70-0x0000000180588CD0 0x0000000180589E70-0x0000000180589ED0
	public static float TurnAnnounceFadeSec { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588AF0-0x0000000180588B50 0x0000000180589CF0-0x0000000180589D50
	public static int TurnAnnounceFontSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588B50-0x0000000180588BB0 0x0000000180589D50-0x0000000180589DB0
	public static bool TurnAnnounceShowAvatar { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588D30-0x0000000180588D90 0x0000000180589F30-0x0000000180589F90
	public static float TurnAnnounceYOffset { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588DF0-0x0000000180588E50 0x0000000180589FF0-0x000000018058A050
	public static Color TurnAnnounceColorSelf { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588A90-0x0000000180588AF0 0x0000000180589C90-0x0000000180589CF0
	public static Color TurnAnnounceColorOther { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588A30-0x0000000180588A90 0x0000000180589C30-0x0000000180589C90
	public static Color TurnAnnounceColorBoss { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805889D0-0x0000000180588A30 0x0000000180589BD0-0x0000000180589C30
	public static bool TurnAnnounceLowTierStatic { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588BB0-0x0000000180588C10 0x0000000180589DB0-0x0000000180589E10
	public static bool TurnAnnounceSfx { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180588CD0-0x0000000180588D30 0x0000000180589ED0-0x0000000180589F30
	private static bool IsLowTier { get; } // 0x0000000180588540-0x0000000180588590 

	// Constructors
	static MatchTunables(); // 0x00000001805876F0-0x0000000180587C50

	// Methods
	private static void EnsureLoaded(); // 0x00000001805852A0-0x0000000180585340
	public static float Get(string key, string prop, float def, float min, float max); // 0x0000000180585520-0x0000000180585690
	public static int GetInt(string key, string prop, int def, int min, int max); // 0x0000000180585340-0x0000000180585460
	public static string GetString(string key, string prop, string def); // 0x0000000180585460-0x0000000180585520
	private static bool TryGetColor(string key, string prop, out Color c); // 0x00000001805874D0-0x0000000180587600
	private static Color TurnAnnounceColor(string slot, string legacyProp, Color def); // 0x0000000180587600-0x00000001805876F0
	public static void SnapshotForMatch(); // 0x0000000180585690-0x00000001805874D0
	public static void ApplyLogLevel(); // 0x0000000180585150-0x00000001805852A0
}

