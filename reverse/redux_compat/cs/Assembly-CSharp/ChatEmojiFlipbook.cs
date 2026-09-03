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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[RequireComponent(typeof(Image))]
public class ChatEmojiFlipbook : MonoBehaviour // TypeDefIndex: 379
{
	// Fields
	private Image _image; // 0x20
	private Sprite[] _frames; // 0x28
	private float _interval; // 0x30
	private int _index; // 0x34
	private Coroutine _routine; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Play_d__10 : IEnumerator<object> // TypeDefIndex: 380
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChatEmojiFlipbook __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Play_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x0000000180331BF0-0x0000000180331D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180331D50-0x0000000180331D90
	}

	// Constructors
	public ChatEmojiFlipbook(); // 0x000000018031CD00-0x000000018031CD10

	// Methods
	public bool SetEmoji(string emojiId); // 0x000000018031CA50-0x000000018031CBF0
	public void SetFrames(Sprite[] frames, float fps); // 0x000000018031CBF0-0x000000018031CD00
	private void OnEnable(); // 0x000000018031C8F0-0x000000018031C900
	private void OnDisable(); // 0x000000018031C8D0-0x000000018031C8F0
	private void RestartIfNeeded(); // 0x000000018031C970-0x000000018031CA50
	[IteratorStateMachine(typeof(_Play_d__10))]
	private IEnumerator Play(); // 0x000000018031C900-0x000000018031C970
}

