/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[RequireComponent(typeof(Image))]
public class ChatEmojiFlipbook : MonoBehaviour // TypeDefIndex: 431
{
	// Fields
	private Image _image; // 0x20
	private Sprite[] _frames; // 0x28
	private float _interval; // 0x30
	private int _index; // 0x34
	private Coroutine _routine; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 432
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiFlipbook __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180377950-0x0000000180377AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180377AB0-0x0000000180377AF0
	}

	// Constructors
	public ChatEmojiFlipbook(); // 0x000000018036C540-0x000000018036C550

	// Methods
	public bool SetEmoji(string emojiId); // 0x000000018036C290-0x000000018036C430
	public void SetFrames(Sprite[] frames, float fps); // 0x000000018036C430-0x000000018036C540
	private void OnEnable(); // 0x000000018036C130-0x000000018036C140
	private void OnDisable(); // 0x000000018036C110-0x000000018036C130
	private void RestartIfNeeded(); // 0x000000018036C1B0-0x000000018036C290
	[IteratorStateMachine(typeof(_Play_d__10))]
	private IEnumerator Play(); // 0x000000018036C140-0x000000018036C1B0
}

