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

[DisallowMultipleComponent]
public class HomeAudio : MonoBehaviour // TypeDefIndex: 961
{
	// Fields
	private const float FADE_IN_SEC = 1f; // Metadata: 0x005EF172
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
	private sealed class _FadeIn_d__17 : IEnumerator<object> // TypeDefIndex: 962
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public HomeAudio __4__this; // 0x20
		private float _target_5__2; // 0x28
		private float _t_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001805DE020-0x00000001805DE470
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DE470-0x00000001805DE4B0
	}

	// Constructors
	public HomeAudio(); // 0x00000001805DDFD0-0x00000001805DE020

	// Methods
	private void Awake(); // 0x00000001805DC470-0x00000001805DC780
	private void OnEnable(); // 0x00000001805DC780-0x00000001805DC800
	private void OnDisable(); // 0x00000001805DC800-0x00000001805DC880
	private void Start(); // 0x00000001805DC880-0x00000001805DC8B0
	private void OnDestroy(); // 0x00000001805DC8B0-0x00000001805DCA10
	public void SetupButtonSounds(GameObject root); // 0x00000001805DCA10-0x00000001805DCD10
	public void PlayClick(); // 0x00000001805DCD10-0x00000001805DD030
	private void PlayBgm(); // 0x00000001805DD030-0x00000001805DD3C0
	[IteratorStateMachine(typeof(_FadeIn_d__17))]
	private IEnumerator FadeIn(); // 0x00000001805DD3C0-0x00000001805DD460
	private void OnVolumeChanged(float _); // 0x00000001805DD460-0x00000001805DD5F0
	private float TargetVolume(); // 0x00000001805DD5F0-0x00000001805DD630
	private void ApplyGlobalClickSound(); // 0x00000001805DD630-0x00000001805DD940
	private void RestoreGlobalClickSound(); // 0x00000001805DD940-0x00000001805DDB30
	private void PauseMatchBgmIfPlaying(); // 0x00000001805DDB30-0x00000001805DDDB0
	private void ResumeMatchBgm(); // 0x00000001805DDDB0-0x00000001805DDFD0
}

