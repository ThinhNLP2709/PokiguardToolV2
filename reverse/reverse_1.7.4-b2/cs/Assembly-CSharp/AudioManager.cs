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

public class AudioManager : MonoBehaviour // TypeDefIndex: 1831
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
	public static AudioManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806D6E60-0x00000001806D6EA0 0x00000001806D6EA0-0x00000001806D6F00

	// Nested types
	[CompilerGenerated]
	private sealed class _ResetPitchAfterDelay_d__62 : IEnumerator<object> // TypeDefIndex: 1832
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public AudioManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResetPitchAfterDelay_d__62(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E3840-0x00000001806E3910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E3910-0x00000001806E3950
	}

	// Constructors
	public AudioManager(); // 0x00000001806D6D90-0x00000001806D6E60

	// Methods
	private void Awake(); // 0x00000001806D53D0-0x00000001806D55E0
	private void Start(); // 0x00000001806D6C50-0x00000001806D6C70
	private void LoadAudioSettings(); // 0x00000001806D57C0-0x00000001806D5B90
	private void SetupAudioSources(); // 0x00000001806D6B00-0x00000001806D6C50
	public void PlayRandomBackgroundMusic(); // 0x00000001806D64D0-0x00000001806D67D0
	public void PlayNextBackgroundMusic(); // 0x00000001806D63A0-0x00000001806D63B0
	public void StopBackgroundMusic(); // 0x00000001806D6C70-0x00000001806D6CF0
	public void SetBGMVolume(float volume); // 0x00000001806D69A0-0x00000001806D6A50
	public void PlayMatchSound(string dotTag); // 0x00000001806D6290-0x00000001806D6390
	private int GetSoundIndexFromTag(string tag); // 0x00000001806D5640-0x00000001806D57C0
	public void PlaySwordClickSound(); // 0x00000001806D6870-0x00000001806D6900
	public void PlayAttackSound(); // 0x00000001806D5C40-0x00000001806D5C50
	public void PlayAttackPowerSound(); // 0x00000001806D5C30-0x00000001806D5C40
	public void PlayHealSound(); // 0x00000001806D6010-0x00000001806D6020
	public void PlayManaSound(); // 0x00000001806D6030-0x00000001806D6040
	public void PlayPowerSound(); // 0x00000001806D64C0-0x00000001806D64D0
	public void PlayWinSound(); // 0x00000001806D6900-0x00000001806D6910
	public void PlayMultiplierMatchSound(); // 0x00000001806D6390-0x00000001806D63A0
	public void PlayPetAnimSound(int key); // 0x00000001806D63B0-0x00000001806D64C0
	public void PlayDiamondMatchSound(); // 0x00000001806D5E60-0x00000001806D5E70
	public void PlayDotAnimationSound(string dotTag, int multiplier); // 0x00000001806D5E70-0x00000001806D6010
	public void PlayLoseSound(); // 0x00000001806D6020-0x00000001806D6030
	public void PlayMatchResultSound(bool playerWon); // 0x00000001806D6040-0x00000001806D6100
	private void PlaySfx(AudioClip clip); // 0x00000001806D67D0-0x00000001806D6870
	public void PlayCardSoundByElement(string elementType); // 0x00000001806D5C50-0x00000001806D5DE0
	public void PlayCardSoundById(int cardId); // 0x00000001806D5DE0-0x00000001806D5E60
	public void PlayMatchSoundWithCombo(string dotTag, int comboCount); // 0x00000001806D6100-0x00000001806D6290
	[IteratorStateMachine(typeof(_ResetPitchAfterDelay_d__62))]
	private IEnumerator ResetPitchAfterDelay(float delay); // 0x00000001806D6920-0x00000001806D69A0
	public void ResetCombo(); // 0x00000001806D6910-0x00000001806D6920
	public void SetSFXVolume(float volume); // 0x00000001806D6A50-0x00000001806D6B00
	public void MuteAll(); // 0x00000001806D5B90-0x00000001806D5C30
	public void UnmuteAll(); // 0x00000001806D6CF0-0x00000001806D6D90
	public string GetCurrentTrackName(); // 0x00000001806D55E0-0x00000001806D5640
}

