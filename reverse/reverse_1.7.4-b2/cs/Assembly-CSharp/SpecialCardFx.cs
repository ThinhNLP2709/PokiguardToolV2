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

public static class SpecialCardFx // TypeDefIndex: 1951
{
	// Fields
	private const string CANVAS_NAME = "CardAnimationCanvas"; // Metadata: 0x0068DD4B
	private const string ART_NODE = "imgtCard"; // Metadata: 0x0068DD5F
	private static readonly Vector2 CARD_SIZE; // 0x00
	private static readonly Vector2 CARD_ANCHORED_POS; // 0x08
	public const float CENTER_CARD_SCALE = 2f; // Metadata: 0x0068DD68
	private const float SCALE_IN_SEC = 0.4f; // Metadata: 0x0068DD6C
	private const float HOLD_SEC = 0.9f; // Metadata: 0x0068DD70
	private const float FADE_SEC = 0.25f; // Metadata: 0x0068DD74
	private static Sprite _fusionArt; // 0x10
	private static bool _fusionArtProbed; // 0x18

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayCenterCard_d__11 : IEnumerator<object> // TypeDefIndex: 1952
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Sprite art; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayCenterCard_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
		private bool MoveNext(); // 0x000000018070D9F0-0x000000018070DF40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070DF40-0x000000018070DF80
	}

	// Constructors
	static SpecialCardFx(); // 0x000000018070C360-0x000000018070C3C0

	// Methods
	public static Sprite LoadFusionCardArt(); // 0x000000018070C030-0x000000018070C2F0
	[IteratorStateMachine(typeof(_PlayCenterCard_d__11))]
	public static IEnumerator PlayCenterCard(Sprite art); // 0x000000018070C2F0-0x000000018070C360
	private static Canvas EnsureAnimationCanvas(); // 0x000000018070BC40-0x000000018070C030
}

