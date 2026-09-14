/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class UIUpdateManager : MonoBehaviour // TypeDefIndex: 86
{
	// Fields
	[CompilerGenerated]
	private static UIUpdateManager _Instance_k__BackingField; // 0x00
	internal ManagerMatch managerMatch; // 0x20
	internal Active active; // 0x28
	internal Board board; // 0x30
	private NumTextCache _cNoNPC; // 0x38
	private NumTextCache _cManaNPC; // 0x48
	private NumTextCache _cHpPlayer; // 0x58
	private NumTextCache _cNoPlayer; // 0x68
	private NumTextCache _cManaPlayer; // 0x78
	private int _displayPetToken; // 0x88
	private int _lastBoundDisplayPetId; // 0x8C

	// Properties
	public static UIUpdateManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180479A60-0x0000000180479AA0 0x0000000180479AA0-0x0000000180479B40

	// Nested types
	private struct NumTextCache // TypeDefIndex: 87
	{
		// Fields
		public UnityEngine.UI.Text Owner; // 0x00
		public int A; // 0x08
		public int B; // 0x0C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 88
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public int petId; // 0x1C

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupDisplayPetAnimatorCached_b__0(AnimationClip[] clips); // 0x00000001804806A0-0x00000001804809C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 89
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass34_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupDisplayPlayerPetAnimator_b__0(AnimationClip[] clips); // 0x00000001804809C0-0x0000000180480B80
	}

	[CompilerGenerated]
	private sealed class _ApplyDisplayPetClipsWhenIdle_d__28 : IEnumerator<object> // TypeDefIndex: 90
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int token; // 0x20
		public UIUpdateManager __4__this; // 0x28
		public int petId; // 0x30
		public AnimationClip[] clips; // 0x38
		private float _deadline_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDisplayPetClipsWhenIdle_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180480B80-0x0000000180480DC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180480DC0-0x0000000180480E00
	}

	// Constructors
	public UIUpdateManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180479B40-0x0000000180479B50
	private void Start(); // 0x0000000180479B50-0x0000000180479CD0
	private void OnDestroy(); // 0x0000000180479CD0-0x0000000180479E60
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005EEA9C */); // 0x0000000180479E60-0x000000018047B460
	private static void SetPairText(UnityEngine.UI.Text t, int cur, int max, ref NumTextCache c); // 0x000000018047B460-0x000000018047B6C0
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005EEA9D */); // 0x000000018047B6C0-0x000000018047C800
	private void UpdateWeaknessText(Active.PlayerStats displayStats); // 0x000000018047C800-0x000000018047CE50
	public int GetActorToDisplay(); // 0x000000018047CE50-0x000000018047D210
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x000000018047D210-0x000000018047DC10
	public void ResetDisplayBindCache(); // 0x000000018047DC10-0x000000018047DC30
	private static string ResolveDisplayNameForActor(int wsActor); // 0x000000018047DC30-0x000000018047DEE0
	private static int ResolveVipLevelForActor(int wsActor); // 0x000000018047DEE0-0x000000018047E180
	private void SetupDisplayPetAnimatorCached(int petId); // 0x000000018047E180-0x000000018047E420
	[IteratorStateMachine(typeof(_ApplyDisplayPetClipsWhenIdle_d__28))]
	private IEnumerator ApplyDisplayPetClipsWhenIdle(int petId, AnimationClip[] clips, int token); // 0x000000018047E420-0x000000018047E540
	public static void PrewarmDisplayPetClips(int petId); // 0x000000018047E540-0x000000018047E650
	private void ApplyDisplayPetClips(int petId, AnimationClip[] clips); // 0x000000018047E650-0x000000018047E970
	private bool ApplyStaticDisplayPet(int petId); // 0x000000018047E970-0x000000018047EE40
	private int[] DisplayEquipCounter(); // 0x000000018047EE40-0x000000018047F070
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x000000018047F070-0x000000018047FC30
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x000000018047FC30-0x000000018047FF10
	private void BindDisplayPlayerPet(AnimationClip[] clips, string petId); // 0x000000018047FF10-0x0000000180480080
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x0000000180480080-0x00000001804800A0
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips, out bool complete); // 0x00000001804800A0-0x0000000180480390
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x0000000180480390-0x00000001804803B0
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips, out bool complete); // 0x00000001804803B0-0x00000001804806A0
}

