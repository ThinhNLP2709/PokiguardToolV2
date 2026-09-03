/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class UIUpdateManagerPVP : MonoBehaviour // TypeDefIndex: 222
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
	public static UIUpdateManagerPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806A89A0-0x00000001806A89E0 0x00000001806A89E0-0x00000001806A8A40

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 223
	{
		// Fields
		public UIUpdateManagerPVP __4__this; // 0x10
		public Animator animator; // 0x18
		public int token; // 0x20
		public bool isEnemy; // 0x24
		public string petId; // 0x28
		public SpriteRenderer fallbackRenderer; // 0x30

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyPetClipsAsync_b__0(AnimationClip[] clips); // 0x00000001806A56D0-0x00000001806A5920
	}

	// Constructors
	public UIUpdateManagerPVP(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001806A64F0-0x00000001806A65E0
	private void Start(); // 0x00000001806A6CF0-0x00000001806A6D80
	private void OnDestroy(); // 0x00000001806A66A0-0x00000001806A6780
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x00000001806A6780-0x00000001806A6B20
	private void UpdateWeaknessText(ActivePVP.PlayerStats displayStats); // 0x00000001806A85F0-0x00000001806A89A0
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0064C064 */); // 0x00000001806A6D80-0x00000001806A76A0
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0064C065 */); // 0x00000001806A7CB0-0x00000001806A85F0
	public int GetActorToDisplay(); // 0x00000001806A6680-0x00000001806A66A0
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x00000001806A76A0-0x00000001806A7CB0
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x00000001806A6CE0-0x00000001806A6CF0
	public void ApplyPetClipsAsync(string petId, bool isEnemy); // 0x00000001806A6210-0x00000001806A64F0
	private void FitPetSize(bool isEnemy); // 0x00000001806A65E0-0x00000001806A6680
	public void ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x00000001806A6C00-0x00000001806A6CE0
	public void ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x00000001806A6B20-0x00000001806A6C00
}

