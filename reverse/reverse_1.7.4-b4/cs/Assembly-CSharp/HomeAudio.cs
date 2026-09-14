/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomeAudio : MonoBehaviour // TypeDefIndex: 963
{
	// Fields
	private const float FADE_IN_SEC = 1f; // Metadata: 0x005F053F
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
	private sealed class _FadeIn_d__17 : IEnumerator<object> // TypeDefIndex: 964
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001805DF9A0-0x00000001805DFDF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805DFDF0-0x00000001805DFE30
	}

	// Constructors
	public HomeAudio(); // 0x00000001805DF950-0x00000001805DF9A0

	// Methods
	private void Awake(); // 0x00000001805DDDF0-0x00000001805DE100
	private void OnEnable(); // 0x00000001805DE100-0x00000001805DE180
	private void OnDisable(); // 0x00000001805DE180-0x00000001805DE200
	private void Start(); // 0x00000001805DE200-0x00000001805DE230
	private void OnDestroy(); // 0x00000001805DE230-0x00000001805DE390
	public void SetupButtonSounds(GameObject root); // 0x00000001805DE390-0x00000001805DE690
	public void PlayClick(); // 0x00000001805DE690-0x00000001805DE9B0
	private void PlayBgm(); // 0x00000001805DE9B0-0x00000001805DED40
	[IteratorStateMachine(typeof(_FadeIn_d__17))]
	private IEnumerator FadeIn(); // 0x00000001805DED40-0x00000001805DEDE0
	private void OnVolumeChanged(float _); // 0x00000001805DEDE0-0x00000001805DEF70
	private float TargetVolume(); // 0x00000001805DEF70-0x00000001805DEFB0
	private void ApplyGlobalClickSound(); // 0x00000001805DEFB0-0x00000001805DF2C0
	private void RestoreGlobalClickSound(); // 0x00000001805DF2C0-0x00000001805DF4B0
	private void PauseMatchBgmIfPlaying(); // 0x00000001805DF4B0-0x00000001805DF730
	private void ResumeMatchBgm(); // 0x00000001805DF730-0x00000001805DF950
}

