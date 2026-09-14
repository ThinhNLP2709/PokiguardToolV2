/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public static UIUpdateManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D5AFB0-0x0000000180D5AFF0 0x0000000180D5AFF0-0x0000000180D5B090

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
		internal void _ApplyPetClipsAsync_b__0(AnimationClip[] clips); // 0x0000000180D5FA30-0x0000000180D5FD80
	}

	// Constructors
	public UIUpdateManagerPVP(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180D5B090-0x0000000180D5B210
	private void Start(); // 0x0000000180D5B210-0x0000000180D5B340
	private void OnDestroy(); // 0x0000000180D5B340-0x0000000180D5B4D0
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x0000000180D5B4D0-0x0000000180D5BE30
	private void UpdateWeaknessText(ActivePVP.PlayerStats displayStats); // 0x0000000180D5BE30-0x0000000180D5C480
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005ED9A7 */); // 0x0000000180D5C480-0x0000000180D5D560
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005ED9A8 */); // 0x0000000180D5D560-0x0000000180D5E400
	public int GetActorToDisplay(); // 0x0000000180D5E400-0x0000000180D5E420
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x0000000180D5E420-0x0000000180D5EFA0
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x0000000180D5EFA0-0x0000000180D5EFB0
	public void ApplyPetClipsAsync(string petId, bool isEnemy); // 0x0000000180D5EFB0-0x0000000180D5F550
	private void FitPetSize(bool isEnemy); // 0x0000000180D5F550-0x0000000180D5F670
	public void ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x0000000180D5F670-0x0000000180D5F850
	public void ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x0000000180D5F850-0x0000000180D5FA30
}

