/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public static UIUpdateManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D68D70-0x0000000180D68DB0 0x0000000180D68DB0-0x0000000180D68E50

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
		public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyPetClipsAsync_b__0(AnimationClip[] clips); // 0x0000000180D6D7F0-0x0000000180D6DB40
	}

	// Constructors
	public UIUpdateManagerPVP(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180D68E50-0x0000000180D68FD0
	private void Start(); // 0x0000000180D68FD0-0x0000000180D69100
	private void OnDestroy(); // 0x0000000180D69100-0x0000000180D69290
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x0000000180D69290-0x0000000180D69BF0
	private void UpdateWeaknessText(ActivePVP.PlayerStats displayStats); // 0x0000000180D69BF0-0x0000000180D6A240
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005EED77 */); // 0x0000000180D6A240-0x0000000180D6B320
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005EED78 */); // 0x0000000180D6B320-0x0000000180D6C1C0
	public int GetActorToDisplay(); // 0x0000000180D6C1C0-0x0000000180D6C1E0
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x0000000180D6C1E0-0x0000000180D6CD60
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x0000000180D6CD60-0x0000000180D6CD70
	public void ApplyPetClipsAsync(string petId, bool isEnemy); // 0x0000000180D6CD70-0x0000000180D6D310
	private void FitPetSize(bool isEnemy); // 0x0000000180D6D310-0x0000000180D6D430
	public void ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x0000000180D6D430-0x0000000180D6D610
	public void ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x0000000180D6D610-0x0000000180D6D7F0
}

