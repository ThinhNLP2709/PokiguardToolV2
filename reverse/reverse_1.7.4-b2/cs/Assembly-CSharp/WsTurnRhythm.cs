/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

internal static class WsTurnRhythm // TypeDefIndex: 543
{
	// Fields
	internal const float GemExplodeStaggerSec = 0f; // Metadata: 0x0068B640
	internal const float FallWaitSec = 0.22f; // Metadata: 0x0068B644
	private const int DefaultBoardWidth = 8; // Metadata: 0x0068B648
	private const int DefaultBoardHeight = 8; // Metadata: 0x0068B649

	// Properties
	internal static float SwapSlideSec { get; } // 0x00000001803E01E0-0x00000001803E0270 
	internal static float AfterExplodeSec { get; } // 0x00000001803DF730-0x00000001803DF7C0 
	internal static float FallLandBufferSec { get; } // 0x00000001803DFD60-0x00000001803DFDF0 
	internal static float MatchFlashSec { get; } // 0x00000001803DFE80-0x00000001803DFF10 
	internal static float EffectsLeadSec { get; } // 0x00000001803DFB20-0x00000001803DFBB0 
	internal static float PopupSec { get; } // 0x00000001803E00C0-0x00000001803E0150 
	internal static float EntryFlySec { get; } // 0x00000001803DFC40-0x00000001803DFCD0 
	internal static float EntryFlyStaggerSec { get; } // 0x00000001803DFCD0-0x00000001803DFD60 
	internal static float EmptyEntryShrinkSec { get; } // 0x00000001803DFBB0-0x00000001803DFC40 
	internal static float RageConsumedPopupSec { get; } // 0x00000001803E0150-0x00000001803E01E0 
	internal static float AttackSwingSec { get; } // 0x00000001803DF8E0-0x00000001803DF970 
	internal static float AttackPopupSec { get; } // 0x00000001803DF7C0-0x00000001803DF850 
	internal static float AttackResetSec { get; } // 0x00000001803DF850-0x00000001803DF8E0 
	internal static float PlayerTurnEndBufferSec { get; } // 0x00000001803E0030-0x00000001803E00C0 
	internal static float CardUseSec { get; } // 0x00000001803DFA90-0x00000001803DFB20 
	internal static float CardHideLeadSec { get; } // 0x00000001803DFA00-0x00000001803DFA90 
	internal static float CardCurtainHoldSec { get; } // 0x00000001803DF970-0x00000001803DFA00 
	internal static float FusionCurtainHoldSec { get; } // 0x00000001803DFDF0-0x00000001803DFE80 
	internal static float OpsBudgetSec { get; } // 0x00000001803DFF10-0x00000001803DFFA0 
	internal static float OverBudgetFactor { get; } // 0x00000001803DFFA0-0x00000001803E0030 

	// Methods
	internal static float FallSettleSec(int width, int height = 0 /* Metadata: 0x0068B63F */); // 0x00000001803DF3E0-0x00000001803DF440
	internal static float FallWaitActualSec(int width, int height); // 0x00000001803DF440-0x00000001803DF5E0
	internal static float SpeedFactor(float phaseStartedRealtime); // 0x00000001803DF5E0-0x00000001803DF730
}

