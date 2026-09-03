/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class SpecialCardFx // TypeDefIndex: 1678
{
	// Fields
	private const string CANVAS_NAME = "CardAnimationCanvas"; // Metadata: 0x0064D91C
	private const string ART_NODE = "imgtCard"; // Metadata: 0x0064D930
	private static readonly Vector2 CARD_SIZE; // 0x00
	private static readonly Vector2 CARD_ANCHORED_POS; // 0x08
	public const float CENTER_CARD_SCALE = 2f; // Metadata: 0x0064D939
	private const float SCALE_IN_SEC = 0.4f; // Metadata: 0x0064D93D
	private const float HOLD_SEC = 0.9f; // Metadata: 0x0064D941
	private const float FADE_SEC = 0.25f; // Metadata: 0x0064D945
	private static Sprite _fusionArt; // 0x10
	private static bool _fusionArtProbed; // 0x18

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayCenterCard_d__11 : IEnumerator<object> // TypeDefIndex: 1679
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Sprite art; // 0x20
		private GameObject _go_5__2; // 0x28
		private CanvasGroup _cg_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayCenterCard_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
		private bool MoveNext(); // 0x00000001805E6370-0x00000001805E68C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E68C0-0x00000001805E6900
	}

	// Constructors
	static SpecialCardFx(); // 0x00000001805E4880-0x00000001805E48E0

	// Methods
	public static Sprite LoadFusionCardArt(); // 0x00000001805E4550-0x00000001805E4810
	[IteratorStateMachine(typeof(_PlayCenterCard_d__11))]
	public static IEnumerator PlayCenterCard(Sprite art); // 0x00000001805E4810-0x00000001805E4880
	private static Canvas EnsureAnimationCanvas(); // 0x00000001805E4160-0x00000001805E4550
}

