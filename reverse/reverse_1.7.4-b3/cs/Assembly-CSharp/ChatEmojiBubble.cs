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

public class ChatEmojiBubble : MonoBehaviour // TypeDefIndex: 481
{
	// Fields
	private const float PopInSec = 0.22f; // Metadata: 0x005EE163
	private const float HoldSec = 2f; // Metadata: 0x005EE167
	private const float FadeOutSec = 0.3f; // Metadata: 0x005EE16B
	private const float BubbleSize = 58f; // Metadata: 0x005EE16F
	private CanvasGroup _group; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayRoutine_d__7 : IEnumerator<object> // TypeDefIndex: 482
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiBubble __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018038FC00-0x00000001803903B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803903B0-0x00000001803903F0
	}

	// Constructors
	public ChatEmojiBubble(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static bool ShowOnActor(int actorNumber, string emojiId); // 0x000000018038EF50-0x000000018038F4D0
	private void Build(Sprite[] frames, string emojiId); // 0x000000018038F4D0-0x000000018038FB60
	[IteratorStateMachine(typeof(_PlayRoutine_d__7))]
	private IEnumerator PlayRoutine(); // 0x000000018038FB60-0x000000018038FC00
}

