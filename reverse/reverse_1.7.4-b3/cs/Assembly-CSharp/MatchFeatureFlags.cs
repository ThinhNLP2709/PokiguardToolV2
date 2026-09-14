/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MatchFeatureFlags // TypeDefIndex: 1575
{
	// Properties
	private static bool DevOverrideAllowed { get; } // 0x000000018086B6A0-0x000000018086B750 
	public static bool DisableHubRenderInMatch { get; } // 0x000000018086B7E0-0x000000018086B890 
	public static bool UseMatchPrefab { get; } // 0x000000018086B890-0x000000018086B940 
	public static bool SuspendHubScriptsInMatch { get; } // 0x000000018086B940-0x000000018086B9F0 
	public static bool UseBattleScene { get; } // 0x000000018086B9F0-0x000000018086BAA0 
	public static bool UseBattleTransitionFx { get; } // 0x000000018086BAA0-0x000000018086BB50 
	public static bool UnloadUnusedAssetsAfterMatch { get; } // 0x000000018086BB50-0x000000018086BC00 
	public static bool UnloadHubInMatch { get; } // 0x000000018086BC00-0x000000018086BCB0 
	public static bool UseWsReadyStateCheck { get; } // 0x000000018086BCB0-0x000000018086BD60 
	public static bool SingleBootstrapPerMatch { get; } // 0x000000018086BD60-0x000000018086BE10 
	public static bool LockInputOnRemoteTurn { get; } // 0x000000018086BE10-0x000000018086BEC0 
	public static bool UseWsPreParse { get; } // 0x000000018086BEC0-0x000000018086BF70 
	public static bool ShowItemsWithoutForceRebuild { get; } // 0x000000018086BF70-0x000000018086C020 
	public static bool ReuseDestructionEntries { get; } // 0x000000018086C020-0x000000018086C0D0 
	public static bool CacheAnimatorOverrideControllers { get; } // 0x000000018086C0D0-0x000000018086C180 
	public static bool UseDotPool { get; } // 0x000000018086C180-0x000000018086C230 
	public static bool PrewarmMatchVfx { get; } // 0x000000018086C230-0x000000018086C2E0 
	public static bool CacheCardLookups { get; } // 0x000000018086C2E0-0x000000018086C390 
	public static bool EarlyAnimAck { get; } // 0x000000018086C390-0x000000018086C440 
	public static bool LocalSwapPreCheck { get; } // 0x000000018086C440-0x000000018086C4F0 
	public static bool ParallelHubLoadOnExit { get; } // 0x000000018086C4F0-0x000000018086C5A0 
	public static bool QteForgivingInput { get; } // 0x000000018086C5A0-0x000000018086C650 
	public static bool QteTimelineV2 { get; } // 0x000000018086C650-0x000000018086C700 
	public static bool QteButtonLayoutV2 { get; } // 0x000000018086C700-0x000000018086C7B0 
	public static bool AuditionV3 { get; } // 0x000000018086C7B0-0x000000018086C860 
	public static int ShadowReportEvery { get; } // 0x000000018086C860-0x000000018086CA80 
	public static bool TurnAnnouncer { get; } // 0x000000018086CA80-0x000000018086CB30 

	// Methods
	private static bool DevPrefOn(string key, bool defaultOn); // 0x000000018086B750-0x000000018086B7A0
	private static int DevPrefInt(string key, int defaultValue); // 0x000000018086B7A0-0x000000018086B7E0
}

