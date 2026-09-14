/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class SpecialCardFx // TypeDefIndex: 2330
{
	// Fields
	private static readonly Vector2 CARD_SIZE; // 0x00
	private static readonly Vector2 CARD_ANCHORED_POS; // 0x08
	private static Sprite _fusionArt; // 0x10
	private static bool _fusionArtProbed; // 0x18

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayCenterCard_d__11 : IEnumerator<object> // TypeDefIndex: 2331
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Sprite art; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayCenterCard_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805F0440-0x00000001805F0500
		private bool MoveNext(); // 0x0000000180B35D00-0x0000000180B36510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B36510-0x0000000180B36550
	}

	// Constructors
	static SpecialCardFx(); // 0x0000000180B35C90-0x0000000180B35D00

	// Methods
	public static Sprite LoadFusionCardArt(); // 0x0000000180B34FA0-0x0000000180B35470
	[IteratorStateMachine(typeof(_PlayCenterCard_d__11))]
	public static IEnumerator PlayCenterCard(Sprite art); // 0x0000000180B35470-0x0000000180B35510
	private static Canvas EnsureAnimationCanvas(); // 0x0000000180B35510-0x0000000180B35C90
}

