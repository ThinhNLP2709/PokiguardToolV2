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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public static UIUpdateManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804787F0-0x0000000180478830 0x0000000180478830-0x00000001804788D0

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
		internal void _SetupDisplayPetAnimatorCached_b__0(AnimationClip[] clips); // 0x000000018047F430-0x000000018047F750
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
		internal void _SetupDisplayPlayerPetAnimator_b__0(AnimationClip[] clips); // 0x000000018047F750-0x000000018047F910
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018047F910-0x000000018047FB50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018047FB50-0x000000018047FB90
	}

	// Constructors
	public UIUpdateManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001804788D0-0x00000001804788E0
	private void Start(); // 0x00000001804788E0-0x0000000180478A60
	private void OnDestroy(); // 0x0000000180478A60-0x0000000180478BF0
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005ED6CC */); // 0x0000000180478BF0-0x000000018047A1F0
	private static void SetPairText(UnityEngine.UI.Text t, int cur, int max, ref NumTextCache c); // 0x000000018047A1F0-0x000000018047A450
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x005ED6CD */); // 0x000000018047A450-0x000000018047B590
	private void UpdateWeaknessText(Active.PlayerStats displayStats); // 0x000000018047B590-0x000000018047BBE0
	public int GetActorToDisplay(); // 0x000000018047BBE0-0x000000018047BFA0
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x000000018047BFA0-0x000000018047C9A0
	public void ResetDisplayBindCache(); // 0x000000018047C9A0-0x000000018047C9C0
	private static string ResolveDisplayNameForActor(int wsActor); // 0x000000018047C9C0-0x000000018047CC70
	private static int ResolveVipLevelForActor(int wsActor); // 0x000000018047CC70-0x000000018047CF10
	private void SetupDisplayPetAnimatorCached(int petId); // 0x000000018047CF10-0x000000018047D1B0
	[IteratorStateMachine(typeof(_ApplyDisplayPetClipsWhenIdle_d__28))]
	private IEnumerator ApplyDisplayPetClipsWhenIdle(int petId, AnimationClip[] clips, int token); // 0x000000018047D1B0-0x000000018047D2D0
	public static void PrewarmDisplayPetClips(int petId); // 0x000000018047D2D0-0x000000018047D3E0
	private void ApplyDisplayPetClips(int petId, AnimationClip[] clips); // 0x000000018047D3E0-0x000000018047D700
	private bool ApplyStaticDisplayPet(int petId); // 0x000000018047D700-0x000000018047DBD0
	private int[] DisplayEquipCounter(); // 0x000000018047DBD0-0x000000018047DE00
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x000000018047DE00-0x000000018047E9C0
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x000000018047E9C0-0x000000018047ECA0
	private void BindDisplayPlayerPet(AnimationClip[] clips, string petId); // 0x000000018047ECA0-0x000000018047EE10
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x000000018047EE10-0x000000018047EE30
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips, out bool complete); // 0x000000018047EE30-0x000000018047F120
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x000000018047F120-0x000000018047F140
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips, out bool complete); // 0x000000018047F140-0x000000018047F430
}

