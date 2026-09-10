/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class UIUpdateManagerPVP : MonoBehaviour // TypeDefIndex: 248
{
	// Fields
	[CompilerGenerated]
	private static UIUpdateManagerPVP _Instance_k__BackingField; // 0x00
	internal ManagerMatchPVP managerMatch; // 0x20
	internal ActivePVP active; // 0x28
	internal BoardPVP board; // 0x30
	private int _userClipToken; // 0x38
	private int _enemyClipToken; // 0x3C

	// Properties
	public static UIUpdateManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180856210-0x0000000180856250 0x0000000180856250-0x00000001808562B0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 249
	{
		// Fields
		public UIUpdateManagerPVP __4__this; // 0x10
		public Animator animator; // 0x18
		public int token; // 0x20
		public bool isEnemy; // 0x24
		public string petId; // 0x28
		public SpriteRenderer fallbackRenderer; // 0x30

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyPetClipsAsync_b__0(AnimationClip[] clips); // 0x0000000180853020-0x0000000180853270
	}

	// Constructors
	public UIUpdateManagerPVP(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180853FA0-0x0000000180854090
	private void Start(); // 0x00000001808547A0-0x0000000180854830
	private void OnDestroy(); // 0x0000000180854150-0x0000000180854230
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x0000000180854230-0x00000001808545D0
	private void UpdateWeaknessText(ActivePVP.PlayerStats displayStats); // 0x0000000180855E90-0x0000000180856210
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0068AD7C */); // 0x0000000180854830-0x0000000180855030
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0068AD7D */); // 0x0000000180855640-0x0000000180855E90
	public int GetActorToDisplay(); // 0x0000000180854130-0x0000000180854150
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x0000000180855030-0x0000000180855640
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x0000000180854790-0x00000001808547A0
	public void ApplyPetClipsAsync(string petId, bool isEnemy); // 0x0000000180853CC0-0x0000000180853FA0
	private void FitPetSize(bool isEnemy); // 0x0000000180854090-0x0000000180854130
	public void ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x00000001808546B0-0x0000000180854790
	public void ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x00000001808545D0-0x00000001808546B0
}

