/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchVfxWarmup // TypeDefIndex: 1407
{
	// Fields
	public const int MEGA_ICARUS_PET_ID = 2257; // Metadata: 0x0068CFB1
	private static readonly string[] MATCH_FX_PREFIXES; // 0x00
	private static readonly string[] MATCH_UI_SPRITES; // 0x08
	private const int FRAMES_PER_STEP = 3; // Metadata: 0x0068CFB3
	private const float STEP_BUDGET_MS = 6f; // Metadata: 0x0068CFB4
	private static bool _running; // 0x10
	private static bool _megaIcarusWarmed; // 0x11
	private static bool _materialsWarmed; // 0x12
	private static bool _matchUiWarmed; // 0x13
	private const string RC_VFX_CACHE_RELEASE = "match.vfxCacheRelease"; // Metadata: 0x0068CFB8
	public const string PREF_VFX_CACHE_RELEASE = "ff_MatchVfxCacheRelease"; // Metadata: 0x0068CFCE

	// Properties
	public static bool MaterialsWarmed { get; } // 0x00000001805BFFA0-0x00000001805BFFF0 
	public static bool AllWarm { get; } // 0x00000001805BFE70-0x00000001805BFFA0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WarmCo_d__13 : IEnumerator<object> // TypeDefIndex: 1408
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool includeMegaIcarus; // 0x20
		private int _warmed_5__2; // 0x24
		private int _i_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WarmCo_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D6530-0x00000001805D65B0
		private bool MoveNext(); // 0x00000001805D5D00-0x00000001805D64F0
		private void __m__Finally1(); // 0x00000001805D65B0-0x00000001805D6610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D64F0-0x00000001805D6530
	}

	// Constructors
	static MatchVfxWarmup(); // 0x00000001805BFC60-0x00000001805BFE70

	// Methods
	[IteratorStateMachine(typeof(_WarmCo_d__13))]
	public static IEnumerator WarmCo(bool includeMegaIcarus); // 0x00000001805BFB00-0x00000001805BFB60
	public static void RequestWarm(MonoBehaviour host, bool includeMegaIcarus); // 0x00000001805BF840-0x00000001805BFA90
	public static void WarmMegaIcarusNow(); // 0x00000001805BFB60-0x00000001805BFC60
	public static void ReleaseAfterMatch(); // 0x00000001805BF650-0x00000001805BF840
	public static void ResetSessionState(); // 0x00000001805BFA90-0x00000001805BFB00
}

