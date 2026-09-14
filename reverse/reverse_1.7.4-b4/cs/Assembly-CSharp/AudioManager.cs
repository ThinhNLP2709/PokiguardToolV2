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

public class AudioManager : MonoBehaviour // TypeDefIndex: 2207
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
	public static AudioManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180ABD860-0x0000000180ABD8A0 0x0000000180ABD8A0-0x0000000180ABD940

	// Nested types
	[CompilerGenerated]
	private sealed class _ResetPitchAfterDelay_d__62 : IEnumerator<object> // TypeDefIndex: 2208
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public AudioManager __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResetPitchAfterDelay_d__62(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC08C0-0x0000000180AC09B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC09B0-0x0000000180AC09F0
	}

	// Constructors
	public AudioManager(); // 0x0000000180AC0730-0x0000000180AC08C0

	// Methods
	private void Awake(); // 0x0000000180ABD940-0x0000000180ABDB40
	private void Start(); // 0x0000000180ABDB40-0x0000000180ABDB60
	private void LoadAudioSettings(); // 0x0000000180ABDB60-0x0000000180ABDE70
	private void SetupAudioSources(); // 0x0000000180ABDE70-0x0000000180ABE2A0
	public void PlayRandomBackgroundMusic(); // 0x0000000180ABE2A0-0x0000000180ABE7D0
	public void PlayNextBackgroundMusic(); // 0x0000000180ABE7D0-0x0000000180ABE7E0
	public void StopBackgroundMusic(); // 0x0000000180ABE7E0-0x0000000180ABE920
	public void SetBGMVolume(float volume); // 0x0000000180ABE920-0x0000000180ABEAA0
	public void PlayMatchSound(string dotTag); // 0x0000000180ABEAA0-0x0000000180ABEC70
	private int GetSoundIndexFromTag(string tag); // 0x0000000180ABEC70-0x0000000180ABEF30
	public void PlaySwordClickSound(); // 0x0000000180ABEF30-0x0000000180ABF040
	public void PlayAttackSound(); // 0x0000000180ABF040-0x0000000180ABF050
	public void PlayAttackPowerSound(); // 0x0000000180ABF050-0x0000000180ABF060
	public void PlayHealSound(); // 0x0000000180ABF060-0x0000000180ABF070
	public void PlayManaSound(); // 0x0000000180ABF070-0x0000000180ABF080
	public void PlayPowerSound(); // 0x0000000180ABF080-0x0000000180ABF090
	public void PlayWinSound(); // 0x0000000180ABF090-0x0000000180ABF0A0
	public void PlayMultiplierMatchSound(); // 0x0000000180ABF0A0-0x0000000180ABF0B0
	public void PlayPetAnimSound(int key); // 0x0000000180ABF0B0-0x0000000180ABF300
	public void PlayDiamondMatchSound(); // 0x0000000180ABF300-0x0000000180ABF310
	public void PlayDotAnimationSound(string dotTag, int multiplier); // 0x0000000180ABF310-0x0000000180ABF720
	public void PlayLoseSound(); // 0x0000000180ABF720-0x0000000180ABF730
	public void PlayMatchResultSound(bool playerWon); // 0x0000000180ABF730-0x0000000180ABF8F0
	private void PlaySfx(AudioClip clip); // 0x0000000180ABF8F0-0x0000000180ABFA90
	public void PlayCardSoundByElement(string elementType); // 0x0000000180ABFA90-0x0000000180ABFCF0
	public void PlayCardSoundById(int cardId); // 0x0000000180ABFCF0-0x0000000180ABFD70
	public void PlayMatchSoundWithCombo(string dotTag, int comboCount); // 0x0000000180ABFD70-0x0000000180ABFFC0
	[IteratorStateMachine(typeof(_ResetPitchAfterDelay_d__62))]
	private IEnumerator ResetPitchAfterDelay(float delay); // 0x0000000180ABFFC0-0x0000000180AC0080
	public void ResetCombo(); // 0x0000000180AC0080-0x0000000180AC0090
	public void SetSFXVolume(float volume); // 0x0000000180AC0090-0x0000000180AC0210
	public void MuteAll(); // 0x0000000180AC0210-0x0000000180AC0450
	public void UnmuteAll(); // 0x0000000180AC0450-0x0000000180AC0690
	public string GetCurrentTrackName(); // 0x0000000180AC0690-0x0000000180AC0730
}

