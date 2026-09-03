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

public class AudioManager : MonoBehaviour // TypeDefIndex: 1567
{
	// Fields
	[CompilerGenerated]
	private static AudioManager _Instance_k__BackingField; // 0x00
	[Header("Audio Sources")]
	public AudioSource bgmSource; // 0x20
	public AudioSource sfxSource; // 0x28
	[Header("Background Music - 6 Tracks")]
	[Tooltip("S\u1EBD random 1 trong 6 b\u00E0i n\u00E0y khi b\u1EAFt \u0111\u1EA7u")]
	public AudioClip[] backgroundMusics; // 0x30
	[Header("Match Sounds (6 lo\u1EA1i vi\u00EAn)")]
	[Tooltip("Th\u1EE9 t\u1EF1: xanh, xanhduong, do, tim, trang, vang")]
	public AudioClip[] matchSounds; // 0x38
	[Header("Special Sounds")]
	public AudioClip swordClickSound; // 0x40
	[Header("Card Effect Sounds")]
	[Tooltip("ATTACK card th\u01B0\u1EDDng (id=4/5, elementType=ATTACK)")]
	public AudioClip attackSound; // 0x48
	[Tooltip("ATTACK_LEGEND / dot-skill s\u00E1t th\u01B0\u01A1ng l\u1EDBn")]
	public AudioClip attackPowerSound; // 0x50
	[Tooltip("HP heal (cardID 1/6/7/8, HEALTH)")]
	public AudioClip healSound; // 0x58
	[Tooltip("Mana card (cardID 2, MANA)")]
	public AudioClip manaSound; // 0x60
	[Tooltip("Power/No card (cardID 3, POWER)")]
	public AudioClip powerSound; // 0x68
	[Header("Multiplier / Special Dot Sounds")]
	[Tooltip("Ph\u00E1 vi\u00EAn c\u00F3 multiplier >= 2 (vi\u00EAn c\u00F3 animation sparkle text)")]
	public AudioClip multiplierMatchSound; // 0x70
	[Tooltip("Ph\u00E1 vi\u00EAn kim c\u01B0\u01A1ng v\u00E0ng (vang Dot)")]
	public AudioClip diamondMatchSound; // 0x78
	[Header("Pet Animation Sounds")]
	[Tooltip("key=1: pet \u0111\u00E1nh th\u01B0\u1EDDng (vang Dot, kh\u00F4ng full n\u1ED9)")]
	public AudioClip petAttackSound; // 0x80
	[Tooltip("key=2: pet \u0111\u00E1nh full n\u1ED9 / dame card (vang Dot full power, MEGA, ATTACK card)")]
	public AudioClip petAttackPowerSound; // 0x88
	[Tooltip("key=3: pet buff/heal (xanh/xanhduong/do/tim/trang Dot)")]
	public AudioClip petBuffSound; // 0x90
	[Tooltip("key=4: pet b\u1ECB \u0111\u00E1nh / n\u00E9")]
	public AudioClip petHurtSound; // 0x98
	[Header("Match Result Sounds")]
	[Tooltip("Th\u1EAFng tr\u1EADn")]
	public AudioClip winSound; // 0xA0
	[Tooltip("Thua tr\u1EADn")]
	public AudioClip loseSound; // 0xA8
	[Header("Settings")]
	[Range(0f, 1f)]
	public float bgmVolume; // 0xB0
	[Range(0f, 1f)]
	public float sfxVolume; // 0xB4
	[Header("In-Match Mix")]
	[Range(0f, 1f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n BGM khi trong tr\u1EADn (gi\u1EA3m \u0111\u1EC3 SFX n\u1ED5i). 0.4 = 40% setting g\u1ED1c.")]
	public float inMatchBgmFactor; // 0xB8
	[Range(1f, 2f)]
	[Tooltip("H\u1EC7 s\u1ED1 nh\u00E2n SFX khi trong tr\u1EADn (t\u0103ng \u0111\u1EC3 hi\u1EC7u \u1EE9ng r\u00F5). 1.4 = 140% setting g\u1ED1c, clamp 1.")]
	public float inMatchSfxFactor; // 0xBC
	[Header("Debug Info")]
	[SerializeField]
	private int currentBGMIndex; // 0xC0
	private int _matchSfxLastFrame; // 0xC4
	private int _matchSfxPlaysThisFrame; // 0xC8
	private int _petAnimSfxLastFrame; // 0xCC
	private int _petAnimSfxLastKey; // 0xD0
	private int _animSfxLastFrame; // 0xD4
	private int _animSfxPlaysThisFrame; // 0xD8
	[Header("Combo Settings")]
	public float comboPitchIncrement; // 0xDC
	private int currentCombo; // 0xE0

	// Properties
	public static AudioManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018059D510-0x000000018059D550 0x000000018059D550-0x000000018059D5B0

	// Nested types
	[CompilerGenerated]
	private sealed class _ResetPitchAfterDelay_d__62 : IEnumerator<object> // TypeDefIndex: 1568
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public AudioManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResetPitchAfterDelay_d__62(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A9E90-0x00000001805A9F60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A9F60-0x00000001805A9FA0
	}

	// Constructors
	public AudioManager(); // 0x000000018059D440-0x000000018059D510

	// Methods
	private void Awake(); // 0x000000018059BA80-0x000000018059BC90
	private void Start(); // 0x000000018059D300-0x000000018059D320
	private void LoadAudioSettings(); // 0x000000018059BE70-0x000000018059C240
	private void SetupAudioSources(); // 0x000000018059D1B0-0x000000018059D300
	public void PlayRandomBackgroundMusic(); // 0x000000018059CB80-0x000000018059CE80
	public void PlayNextBackgroundMusic(); // 0x000000018059CA50-0x000000018059CA60
	public void StopBackgroundMusic(); // 0x000000018059D320-0x000000018059D3A0
	public void SetBGMVolume(float volume); // 0x000000018059D050-0x000000018059D100
	public void PlayMatchSound(string dotTag); // 0x000000018059C940-0x000000018059CA40
	private int GetSoundIndexFromTag(string tag); // 0x000000018059BCF0-0x000000018059BE70
	public void PlaySwordClickSound(); // 0x000000018059CF20-0x000000018059CFB0
	public void PlayAttackSound(); // 0x000000018059C2F0-0x000000018059C300
	public void PlayAttackPowerSound(); // 0x000000018059C2E0-0x000000018059C2F0
	public void PlayHealSound(); // 0x000000018059C6C0-0x000000018059C6D0
	public void PlayManaSound(); // 0x000000018059C6E0-0x000000018059C6F0
	public void PlayPowerSound(); // 0x000000018059CB70-0x000000018059CB80
	public void PlayWinSound(); // 0x000000018059CFB0-0x000000018059CFC0
	public void PlayMultiplierMatchSound(); // 0x000000018059CA40-0x000000018059CA50
	public void PlayPetAnimSound(int key); // 0x000000018059CA60-0x000000018059CB70
	public void PlayDiamondMatchSound(); // 0x000000018059C510-0x000000018059C520
	public void PlayDotAnimationSound(string dotTag, int multiplier); // 0x000000018059C520-0x000000018059C6C0
	public void PlayLoseSound(); // 0x000000018059C6D0-0x000000018059C6E0
	public void PlayMatchResultSound(bool playerWon); // 0x000000018059C6F0-0x000000018059C7B0
	private void PlaySfx(AudioClip clip); // 0x000000018059CE80-0x000000018059CF20
	public void PlayCardSoundByElement(string elementType); // 0x000000018059C300-0x000000018059C490
	public void PlayCardSoundById(int cardId); // 0x000000018059C490-0x000000018059C510
	public void PlayMatchSoundWithCombo(string dotTag, int comboCount); // 0x000000018059C7B0-0x000000018059C940
	[IteratorStateMachine(typeof(_ResetPitchAfterDelay_d__62))]
	private IEnumerator ResetPitchAfterDelay(float delay); // 0x000000018059CFD0-0x000000018059D050
	public void ResetCombo(); // 0x000000018059CFC0-0x000000018059CFD0
	public void SetSFXVolume(float volume); // 0x000000018059D100-0x000000018059D1B0
	public void MuteAll(); // 0x000000018059C240-0x000000018059C2E0
	public void UnmuteAll(); // 0x000000018059D3A0-0x000000018059D440
	public string GetCurrentTrackName(); // 0x000000018059BC90-0x000000018059BCF0
}

