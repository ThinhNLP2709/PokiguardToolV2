/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

internal static class WsTurnRhythm // TypeDefIndex: 455
{
	// Fields
	internal const float SwapSlideSec = 0.15f; // Metadata: 0x0064C43B
	internal const float GemExplodeStaggerSec = 0f; // Metadata: 0x0064C43F
	internal const float AfterExplodeSec = 0.06f; // Metadata: 0x0064C443
	internal const float FallWaitSec = 0.22f; // Metadata: 0x0064C447
	private const int DefaultBoardWidth = 8; // Metadata: 0x0064C44B
	private const int DefaultBoardHeight = 8; // Metadata: 0x0064C44C
	internal const float FallLandBufferSec = 0.05f; // Metadata: 0x0064C44D
	internal const float MatchFlashSec = 0.1f; // Metadata: 0x0064C451
	internal const float EffectsLeadSec = 0.35f; // Metadata: 0x0064C455
	internal const float PopupSec = 0.8f; // Metadata: 0x0064C459
	internal const float EntryFlySec = 0.32f; // Metadata: 0x0064C45D
	internal const float EntryFlyStaggerSec = 0.1f; // Metadata: 0x0064C461
	internal const float EmptyEntryShrinkSec = 0.3f; // Metadata: 0x0064C465
	internal const float RageConsumedPopupSec = 0.8f; // Metadata: 0x0064C469
	internal const float AttackSwingSec = 0.4f; // Metadata: 0x0064C46D
	internal const float AttackPopupSec = 0.8f; // Metadata: 0x0064C471
	internal const float AttackResetSec = 0.5f; // Metadata: 0x0064C475
	internal const float PlayerTurnEndBufferSec = 0.6f; // Metadata: 0x0064C479
	internal const float CardUseSec = 0.3f; // Metadata: 0x0064C47D
	internal const float CardHideLeadSec = 0.3f; // Metadata: 0x0064C481
	internal const float CardCurtainHoldSec = 2f; // Metadata: 0x0064C485
	internal const float FusionCurtainHoldSec = 3f; // Metadata: 0x0064C489
	internal const float OpsBudgetSec = 5f; // Metadata: 0x0064C48D
	internal const float OverBudgetFactor = 0.45f; // Metadata: 0x0064C491

	// Methods
	internal static float FallSettleSec(int width, int height = 0 /* Metadata: 0x0064C43A */); // 0x0000000180378130-0x0000000180378190
	internal static float FallWaitActualSec(int width, int height); // 0x0000000180378190-0x00000001803782A0
	internal static float SpeedFactor(float phaseStartedRealtime); // 0x00000001803782A0-0x0000000180378330
}

