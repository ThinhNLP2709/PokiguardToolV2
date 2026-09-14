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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[RequireComponent(typeof(Image))]
public class ChatEmojiFlipbook : MonoBehaviour // TypeDefIndex: 485
{
	// Fields
	private Image _image; // 0x20
	private Sprite[] _frames; // 0x28
	private float _interval; // 0x30
	private int _index; // 0x34
	private Coroutine _routine; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 486
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiFlipbook __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001803926A0-0x0000000180392920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180392920-0x0000000180392B60
	}

	// Constructors
	public ChatEmojiFlipbook(); // 0x0000000180392650-0x00000001803926A0

	// Methods
	public bool SetEmoji(string emojiId); // 0x0000000180392090-0x0000000180392150
	public void SetFrames(Sprite[] frames, float fps); // 0x0000000180392150-0x0000000180392370
	private void OnEnable(); // 0x0000000180392370-0x0000000180392380
	private void OnDisable(); // 0x0000000180392380-0x00000001803923E0
	private void RestartIfNeeded(); // 0x00000001803923E0-0x00000001803925B0
	[IteratorStateMachine(typeof(_Play_d__10))]
	private IEnumerator Play(); // 0x00000001803925B0-0x0000000180392650
}

