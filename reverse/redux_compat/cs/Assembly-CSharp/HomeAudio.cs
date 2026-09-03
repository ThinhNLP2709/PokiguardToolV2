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

[DisallowMultipleComponent]
public class HomeAudio : MonoBehaviour // TypeDefIndex: 598
{
	// Fields
	private const float FADE_IN_SEC = 1f; // Metadata: 0x0064C5C3
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
	private sealed class _FadeIn_d__17 : IEnumerator<object> // TypeDefIndex: 599
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeAudio __4__this; // 0x20
		private float _target_5__2; // 0x28
		private float _t_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803BCF40-0x00000001803BD140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BD140-0x00000001803BD180
	}

	// Constructors
	public HomeAudio(); // 0x00000001803ADD70-0x00000001803ADD80

	// Methods
	private void Awake(); // 0x00000001803ACF60-0x00000001803AD070
	private void OnEnable(); // 0x00000001803AD310-0x00000001803AD380
	private void OnDisable(); // 0x00000001803AD2A0-0x00000001803AD310
	private void Start(); // 0x00000001803ADA70-0x00000001803ADD30
	private void OnDestroy(); // 0x00000001803AD0E0-0x00000001803AD2A0
	public void SetupButtonSounds(GameObject root); // 0x00000001803AD910-0x00000001803ADA70
	public void PlayClick(); // 0x00000001803AD650-0x00000001803AD780
	private void PlayBgm(); // 0x00000001803AD500-0x00000001803AD650
	[IteratorStateMachine(typeof(_FadeIn_d__17))]
	private IEnumerator FadeIn(); // 0x00000001803AD070-0x00000001803AD0E0
	private void OnVolumeChanged(float _); // 0x00000001803AD380-0x00000001803AD430
	private float TargetVolume(); // 0x00000001803ADD30-0x00000001803ADD70
	private void ApplyGlobalClickSound(); // 0x00000001803ACE80-0x00000001803ACF60
	private void RestoreGlobalClickSound(); // 0x00000001803AD780-0x00000001803AD840
	private void PauseMatchBgmIfPlaying(); // 0x00000001803AD430-0x00000001803AD500
	private void ResumeMatchBgm(); // 0x00000001803AD840-0x00000001803AD910
}

