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

public class ChatEmojiBubble : MonoBehaviour // TypeDefIndex: 375
{
	// Fields
	private const float PopInSec = 0.22f; // Metadata: 0x0064C2A4
	private const float HoldSec = 2f; // Metadata: 0x0064C2A8
	private const float FadeOutSec = 0.3f; // Metadata: 0x0064C2AC
	private const float BubbleSize = 58f; // Metadata: 0x0064C2B0
	private CanvasGroup _group; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayRoutine_d__7 : IEnumerator<object> // TypeDefIndex: 376
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiBubble __4__this; // 0x20
		private float _t_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PlayRoutine_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180331780-0x0000000180331BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180331BB0-0x0000000180331BF0
	}

	// Constructors
	public ChatEmojiBubble(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static bool ShowOnActor(int actorNumber, string emojiId); // 0x000000018031A900-0x000000018031AC10
	private void Build(Sprite[] frames, string emojiId); // 0x000000018031A340-0x000000018031A890
	[IteratorStateMachine(typeof(_PlayRoutine_d__7))]
	private IEnumerator PlayRoutine(); // 0x000000018031A890-0x000000018031A900
}

