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

[DisallowMultipleComponent]
public class HomeAudio : MonoBehaviour // TypeDefIndex: 794
{
	// Fields
	private const float FADE_IN_SEC = 1f; // Metadata: 0x0068BBEE
	[Tooltip("Nh\u1EA1c n\u1EC1n Home (Assets/Home/Audio/MainHome.ogg).")]
	public AudioClip bgm; // 0x20
	[Tooltip("Ti\u1EBFng b\u1EA5m n\u00FAt Home (Assets/Home/Audio/Button_Common.ogg).")]
	public AudioClip clickSound; // 0x28
	[Range(0f, 1f)]
	public float clickVolume; // 0x30
	private AudioSource _source; // 0x38
	private AudioClip _prevGlobalClick; // 0x40
	private bool _clickApplied; // 0x48
	private bool _pausedMatchBgm; // 0x49
	private Coroutine _fadeCo; // 0x50

	// Nested types
	[CompilerGenerated]
	private sealed class _FadeIn_d__17 : IEnumerator<object> // TypeDefIndex: 795
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeAudio __4__this; // 0x20
		private float _target_5__2; // 0x28
		private float _t_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804962B0-0x00000001804964B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804964B0-0x00000001804964F0
	}

	// Constructors
	public HomeAudio(); // 0x000000018048D4E0-0x000000018048D4F0

	// Methods
	private void Awake(); // 0x000000018048C650-0x000000018048C760
	private void OnEnable(); // 0x000000018048CA20-0x000000018048CA90
	private void OnDisable(); // 0x000000018048C9B0-0x000000018048CA20
	private void Start(); // 0x000000018048D1C0-0x000000018048D4A0
	private void OnDestroy(); // 0x000000018048C7D0-0x000000018048C9B0
	public void SetupButtonSounds(GameObject root); // 0x000000018048D060-0x000000018048D1C0
	public void PlayClick(); // 0x000000018048CD60-0x000000018048CEB0
	private void PlayBgm(); // 0x000000018048CC10-0x000000018048CD60
	[IteratorStateMachine(typeof(_FadeIn_d__17))]
	private IEnumerator FadeIn(); // 0x000000018048C760-0x000000018048C7D0
	private void OnVolumeChanged(float _); // 0x000000018048CA90-0x000000018048CB40
	private float TargetVolume(); // 0x000000018048D4A0-0x000000018048D4E0
	private void ApplyGlobalClickSound(); // 0x000000018048C560-0x000000018048C650
	private void RestoreGlobalClickSound(); // 0x000000018048CEB0-0x000000018048CF90
	private void PauseMatchBgmIfPlaying(); // 0x000000018048CB40-0x000000018048CC10
	private void ResumeMatchBgm(); // 0x000000018048CF90-0x000000018048D060
}

