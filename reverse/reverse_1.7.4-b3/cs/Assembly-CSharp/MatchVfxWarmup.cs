/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MatchVfxWarmup // TypeDefIndex: 1789
{
	// Fields
	private static readonly string[] MATCH_FX_PREFIXES; // 0x00
	private static readonly string[] MATCH_UI_SPRITES; // 0x08
	private static bool _running; // 0x10
	private static bool _megaIcarusWarmed; // 0x11
	private static bool _galaxyRickyWarmed; // 0x12
	private static bool _materialsWarmed; // 0x13
	private static bool _matchUiWarmed; // 0x14

	// Properties
	public static bool MaterialsWarmed { get; } // 0x00000001808DFE80-0x00000001808DFEE0 
	public static bool AllWarm { get; } // 0x00000001808DFEE0-0x00000001808E0020 

	// Nested types
	[CompilerGenerated]
	private sealed class _WarmCo_d__14 : IEnumerator<object> // TypeDefIndex: 1790
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool includeMegaIcarus; // 0x20
		private int _warmed_5__2; // 0x24
		private int _i_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WarmCo_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808E0D70-0x00000001808E0E60
		private bool MoveNext(); // 0x00000001808E0E60-0x00000001808E1650
		private void __m__Finally1(); // 0x00000001808E1650-0x00000001808E16C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E16C0-0x00000001808E1700
	}

	// Constructors
	static MatchVfxWarmup(); // 0x00000001808E0AD0-0x00000001808E0D70

	// Methods
	[IteratorStateMachine(typeof(_WarmCo_d__14))]
	public static IEnumerator WarmCo(bool includeMegaIcarus); // 0x00000001808E0020-0x00000001808E0070
	public static void RequestWarm(MonoBehaviour host, bool includeMegaIcarus); // 0x00000001808E0070-0x00000001808E0250
	public static void WarmMegaIcarusNow(); // 0x00000001808E0250-0x00000001808E0350
	public static void WarmGalaxyRickyNow(); // 0x00000001808E0350-0x00000001808E06B0
	public static void ReleaseAfterMatch(); // 0x00000001808E06B0-0x00000001808E0A50
	public static void ResetSessionState(); // 0x00000001808E0A50-0x00000001808E0AD0
}

