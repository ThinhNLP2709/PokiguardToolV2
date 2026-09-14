/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchFeatureFlags // TypeDefIndex: 1577
{
	// Properties
	private static bool DevOverrideAllowed { get; } // 0x000000018086D930-0x000000018086D9E0 
	public static bool DisableHubRenderInMatch { get; } // 0x000000018086DA70-0x000000018086DB20 
	public static bool UseMatchPrefab { get; } // 0x000000018086DB20-0x000000018086DBD0 
	public static bool SuspendHubScriptsInMatch { get; } // 0x000000018086DBD0-0x000000018086DC80 
	public static bool UseBattleScene { get; } // 0x000000018086DC80-0x000000018086DD30 
	public static bool UseBattleTransitionFx { get; } // 0x000000018086DD30-0x000000018086DDE0 
	public static bool UnloadUnusedAssetsAfterMatch { get; } // 0x000000018086DDE0-0x000000018086DE90 
	public static bool UnloadHubInMatch { get; } // 0x000000018086DE90-0x000000018086DF40 
	public static bool UseWsReadyStateCheck { get; } // 0x000000018086DF40-0x000000018086DFF0 
	public static bool SingleBootstrapPerMatch { get; } // 0x000000018086DFF0-0x000000018086E0A0 
	public static bool LockInputOnRemoteTurn { get; } // 0x000000018086E0A0-0x000000018086E150 
	public static bool UseWsPreParse { get; } // 0x000000018086E150-0x000000018086E200 
	public static bool ShowItemsWithoutForceRebuild { get; } // 0x000000018086E200-0x000000018086E2B0 
	public static bool ReuseDestructionEntries { get; } // 0x000000018086E2B0-0x000000018086E360 
	public static bool CacheAnimatorOverrideControllers { get; } // 0x000000018086E360-0x000000018086E410 
	public static bool UseDotPool { get; } // 0x000000018086E410-0x000000018086E4C0 
	public static bool PrewarmMatchVfx { get; } // 0x000000018086E4C0-0x000000018086E570 
	public static bool CacheCardLookups { get; } // 0x000000018086E570-0x000000018086E620 
	public static bool EarlyAnimAck { get; } // 0x000000018086E620-0x000000018086E6D0 
	public static bool LocalSwapPreCheck { get; } // 0x000000018086E6D0-0x000000018086E780 
	public static bool ParallelHubLoadOnExit { get; } // 0x000000018086E780-0x000000018086E830 
	public static bool QteForgivingInput { get; } // 0x000000018086E830-0x000000018086E8E0 
	public static bool QteTimelineV2 { get; } // 0x000000018086E8E0-0x000000018086E990 
	public static bool QteButtonLayoutV2 { get; } // 0x000000018086E990-0x000000018086EA40 
	public static bool AuditionV3 { get; } // 0x000000018086EA40-0x000000018086EAF0 
	public static int ShadowReportEvery { get; } // 0x000000018086EAF0-0x000000018086ED10 
	public static bool TurnAnnouncer { get; } // 0x000000018086ED10-0x000000018086EDC0 

	// Methods
	private static bool DevPrefOn(string key, bool defaultOn); // 0x000000018086D9E0-0x000000018086DA30
	private static int DevPrefInt(string key, int defaultValue); // 0x000000018086DA30-0x000000018086DA70
}

