/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchFeatureFlags // TypeDefIndex: 1171
{
	// Fields
	private const string RC_DISABLE_HUB_RENDER = "match.disableHubRender"; // Metadata: 0x0068C6E7
	private const string RC_USE_MATCH_PREFAB = "match.useMatchPrefab"; // Metadata: 0x0068C6FE
	private const string RC_SUSPEND_HUB_SCRIPTS = "match.suspendHubScripts"; // Metadata: 0x0068C713
	private const string RC_USE_BATTLE_SCENE = "match.useBattleScene"; // Metadata: 0x0068C72B
	private const string RC_BATTLE_TRANSITION_FX = "match.battleTransitionFx"; // Metadata: 0x0068C740
	private const string RC_UNLOAD_UNUSED_AFTER_MATCH = "match.unloadUnusedAfterMatch"; // Metadata: 0x0068C759
	private const string RC_UNLOAD_HUB_IN_MATCH = "match.unloadHubInMatch"; // Metadata: 0x0068C776
	private const string RC_READY_STATE_CHECK = "match.readyStateCheck"; // Metadata: 0x0068C78D
	private const string RC_SINGLE_BOOTSTRAP = "match.singleBootstrap"; // Metadata: 0x0068C7A3
	private const string RC_INPUT_LOCK_BOSS_TURN = "match.inputLockBossTurn"; // Metadata: 0x0068C7B9
	private const string RC_PRE_PARSE = "match.preParse"; // Metadata: 0x0068C7D1
	private const string RC_SHOW_ITEMS_NO_FORCE_REBUILD = "match.showItemsNoForceRebuild"; // Metadata: 0x0068C7E0
	private const string RC_DESTROY_ENTRY_POOL = "match.destroyEntryPool"; // Metadata: 0x0068C7FE
	private const string RC_AOC_CACHE = "match.aocCache"; // Metadata: 0x0068C815
	private const string RC_DOT_POOL = "match.dotPool"; // Metadata: 0x0068C824
	private const string RC_VFX_PREWARM = "match.vfxPrewarm"; // Metadata: 0x0068C832
	private const string RC_CARD_LOOKUP_CACHE = "match.cardLookupCache"; // Metadata: 0x0068C843
	private const string RC_EARLY_ACK = "match.earlyAck"; // Metadata: 0x0068C859
	private const string RC_LOCAL_SWAP_CHECK = "match.localSwapCheck"; // Metadata: 0x0068C868
	private const string RC_EXIT_PARALLEL_HUB = "match.exitParallelHubLoad"; // Metadata: 0x0068C87D
	private const string RC_QTE_FORGIVING = "match.qteForgiving"; // Metadata: 0x0068C897
	private const string RC_QTE_TIMELINE_V2 = "match.qteTimelineV2"; // Metadata: 0x0068C8AA
	private const string RC_QTE_BUTTON_LAYOUT_V2 = "match.qteButtonLayoutV2"; // Metadata: 0x0068C8BE
	private const string RC_TURN_ANNOUNCER = "match.turnAnnouncer"; // Metadata: 0x0068C8D6
	public const string PREF_DISABLE_HUB_RENDER = "ff_DisableHubRenderInMatch"; // Metadata: 0x0068C8EA
	public const string PREF_USE_MATCH_PREFAB = "ff_UseMatchPrefab"; // Metadata: 0x0068C905
	public const string PREF_SUSPEND_HUB_SCRIPTS = "ff_SuspendHubScriptsInMatch"; // Metadata: 0x0068C917
	public const string PREF_USE_BATTLE_SCENE = "ff_UseBattleScene"; // Metadata: 0x0068C933
	public const string PREF_BATTLE_TRANSITION_FX = "ff_BattleTransitionFx"; // Metadata: 0x0068C945
	public const string PREF_UNLOAD_UNUSED_AFTER_MATCH = "ff_UnloadUnusedAfterMatch"; // Metadata: 0x0068C95B
	public const string PREF_UNLOAD_HUB_IN_MATCH = "ff_UnloadHubInMatch"; // Metadata: 0x0068C975
	public const string PREF_READY_STATE_CHECK = "ff_MatchWsReadyStateCheck"; // Metadata: 0x0068C989
	public const string PREF_SINGLE_BOOTSTRAP = "ff_MatchSingleBootstrap"; // Metadata: 0x0068C9A3
	public const string PREF_INPUT_LOCK_BOSS_TURN = "ff_MatchInputLockBossTurn"; // Metadata: 0x0068C9BB
	public const string PREF_PRE_PARSE = "ff_MatchPreParse"; // Metadata: 0x0068C9D5
	public const string PREF_SHOW_ITEMS_NO_FORCE_REBUILD = "ff_MatchShowItemsNoForceRebuild"; // Metadata: 0x0068C9E6
	public const string PREF_DESTROY_ENTRY_POOL = "ff_MatchDestroyEntryPool"; // Metadata: 0x0068CA06
	public const string PREF_AOC_CACHE = "ff_MatchAocCache"; // Metadata: 0x0068CA1F
	public const string PREF_DOT_POOL = "ff_MatchDotPool"; // Metadata: 0x0068CA30
	public const string PREF_VFX_PREWARM = "ff_MatchVfxPrewarm"; // Metadata: 0x0068CA40
	public const string PREF_CARD_LOOKUP_CACHE = "ff_MatchCardLookupCache"; // Metadata: 0x0068CA53
	public const string PREF_EARLY_ACK = "ff_MatchEarlyAck"; // Metadata: 0x0068CA6B
	public const string PREF_LOCAL_SWAP_CHECK = "ff_MatchLocalSwapCheck"; // Metadata: 0x0068CA7C
	public const string PREF_EXIT_PARALLEL_HUB = "ff_MatchExitParallelHubLoad"; // Metadata: 0x0068CA93
	public const string PREF_QTE_FORGIVING = "ff_MatchQteForgiving"; // Metadata: 0x0068CAAF
	public const string PREF_QTE_TIMELINE_V2 = "ff_MatchQteTimelineV2"; // Metadata: 0x0068CAC4
	public const string PREF_QTE_BUTTON_LAYOUT_V2 = "ff_MatchQteButtonLayoutV2"; // Metadata: 0x0068CADA
	public const string PREF_SHADOW_REPORT_EVERY = "ff_MatchShadowReportEvery"; // Metadata: 0x0068CAF4
	private const int SHADOW_REPORT_EVERY_DEFAULT = 5; // Metadata: 0x0068CB0E
	public const string PREF_TURN_ANNOUNCER = "ff_MatchTurnAnnouncer"; // Metadata: 0x0068CB0F

	// Properties
	public static bool DisableHubRenderInMatch { get; } // 0x00000001805844F0-0x0000000180584570 
	public static bool UseMatchPrefab { get; } // 0x0000000180584FD0-0x0000000180585050 
	public static bool SuspendHubScriptsInMatch { get; } // 0x0000000180584C50-0x0000000180584CD0 
	public static bool UseBattleScene { get; } // 0x0000000180584E50-0x0000000180584ED0 
	public static bool UseBattleTransitionFx { get; } // 0x0000000180584ED0-0x0000000180584F50 
	public static bool UnloadUnusedAssetsAfterMatch { get; } // 0x0000000180584DD0-0x0000000180584E50 
	public static bool UnloadHubInMatch { get; } // 0x0000000180584D50-0x0000000180584DD0 
	public static bool UseWsReadyStateCheck { get; } // 0x00000001805850D0-0x0000000180585150 
	public static bool SingleBootstrapPerMatch { get; } // 0x0000000180584BD0-0x0000000180584C50 
	public static bool LockInputOnRemoteTurn { get; } // 0x0000000180584670-0x00000001805846F0 
	public static bool UseWsPreParse { get; } // 0x0000000180585050-0x00000001805850D0 
	public static bool ShowItemsWithoutForceRebuild { get; } // 0x0000000180584B50-0x0000000180584BD0 
	public static bool ReuseDestructionEntries { get; } // 0x0000000180584970-0x00000001805849F0 
	public static bool CacheAnimatorOverrideControllers { get; } // 0x00000001805843F0-0x0000000180584470 
	public static bool UseDotPool { get; } // 0x0000000180584F50-0x0000000180584FD0 
	public static bool PrewarmMatchVfx { get; } // 0x0000000180584770-0x00000001805847F0 
	public static bool CacheCardLookups { get; } // 0x0000000180584470-0x00000001805844F0 
	public static bool EarlyAnimAck { get; } // 0x0000000180584570-0x00000001805845F0 
	public static bool LocalSwapPreCheck { get; } // 0x00000001805845F0-0x0000000180584670 
	public static bool ParallelHubLoadOnExit { get; } // 0x00000001805846F0-0x0000000180584770 
	public static bool QteForgivingInput { get; } // 0x0000000180584870-0x00000001805848F0 
	public static bool QteTimelineV2 { get; } // 0x00000001805848F0-0x0000000180584970 
	public static bool QteButtonLayoutV2 { get; } // 0x00000001805847F0-0x0000000180584870 
	public static int ShadowReportEvery { get; } // 0x00000001805849F0-0x0000000180584B50 
	public static bool TurnAnnouncer { get; } // 0x0000000180584CD0-0x0000000180584D50 
}

