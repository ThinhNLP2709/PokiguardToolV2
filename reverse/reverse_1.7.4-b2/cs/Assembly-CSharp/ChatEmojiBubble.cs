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

public class ChatEmojiBubble : MonoBehaviour // TypeDefIndex: 427
{
	// Fields
	private const float PopInSec = 0.22f; // Metadata: 0x0068B266
	private const float HoldSec = 2f; // Metadata: 0x0068B26A
	private const float FadeOutSec = 0.3f; // Metadata: 0x0068B26E
	private const float BubbleSize = 58f; // Metadata: 0x0068B272
	private CanvasGroup _group; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayRoutine_d__7 : IEnumerator<object> // TypeDefIndex: 428
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiBubble __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803774E0-0x0000000180377910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377910-0x0000000180377950
	}

	// Constructors
	public ChatEmojiBubble(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static bool ShowOnActor(int actorNumber, string emojiId); // 0x000000018036A060-0x000000018036A370
	private void Build(Sprite[] frames, string emojiId); // 0x0000000180369AA0-0x0000000180369FF0
	[IteratorStateMachine(typeof(_PlayRoutine_d__7))]
	private IEnumerator PlayRoutine(); // 0x0000000180369FF0-0x000000018036A060
}

