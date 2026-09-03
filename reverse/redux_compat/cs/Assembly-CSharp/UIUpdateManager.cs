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

public class UIUpdateManager : MonoBehaviour // TypeDefIndex: 76
{
	// Fields
	[CompilerGenerated]
	private static UIUpdateManager _Instance_k__BackingField; // 0x00
	internal ManagerMatch managerMatch; // 0x20
	internal Active active; // 0x28
	internal Board board; // 0x30
	private int _displayPetToken; // 0x38
	private int _lastBoundDisplayPetId; // 0x3C

	// Properties
	public static UIUpdateManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180313840-0x0000000180313880 0x0000000180313880-0x0000000180313920

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass19_0 // TypeDefIndex: 77
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public int petId; // 0x1C

		// Constructors
		public __c__DisplayClass19_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupDisplayPetAnimatorCached_b__0(AnimationClip[] clips); // 0x000000018052BBC0-0x000000018052BD40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 78
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupDisplayPlayerPetAnimator_b__0(AnimationClip[] clips); // 0x000000018052BDB0-0x000000018052BE60
	}

	[CompilerGenerated]
	private sealed class _ApplyDisplayPetClipsWhenIdle_d__20 : IEnumerator<object> // TypeDefIndex: 79
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDisplayPetClipsWhenIdle_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180522B70-0x0000000180522D00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180522D00-0x0000000180522D40
	}

	// Constructors
	public UIUpdateManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x0000000180310630-0x0000000180310690
	private void Start(); // 0x0000000180311C40-0x0000000180311D10
	private void OnDestroy(); // 0x0000000180310960-0x0000000180310A40
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0064BF90 */); // 0x0000000180311D10-0x0000000180312630
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0064BF91 */); // 0x0000000180312C70-0x0000000180313580
	private void UpdateWeaknessText(Active.PlayerStats displayStats); // 0x0000000180313580-0x0000000180313840
	public int GetActorToDisplay(); // 0x0000000180310780-0x0000000180310960
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x0000000180310AD0-0x0000000180310FF0
	public void ResetDisplayBindCache(); // 0x0000000180311510-0x0000000180311520
	private static string ResolveDisplayNameForActor(int wsActor); // 0x0000000180311520-0x0000000180311700
	private void SetupDisplayPetAnimatorCached(int petId); // 0x0000000180311700-0x00000001803119D0
	[IteratorStateMachine(typeof(_ApplyDisplayPetClipsWhenIdle_d__20))]
	private IEnumerator ApplyDisplayPetClipsWhenIdle(int petId, AnimationClip[] clips, int token); // 0x00000001803101E0-0x0000000180310290
	public static void PrewarmDisplayPetClips(int petId); // 0x0000000180310A40-0x0000000180310AD0
	private void ApplyDisplayPetClips(int petId, AnimationClip[] clips); // 0x0000000180310290-0x00000001803103D0
	private bool ApplyStaticDisplayPet(int petId); // 0x00000001803103D0-0x0000000180310630
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x0000000180312630-0x0000000180312C70
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x00000001803119D0-0x0000000180311C40
	private void BindDisplayPlayerPet(AnimationClip[] clips, string petId); // 0x0000000180310690-0x0000000180310780
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x00000001803113C0-0x0000000180311510
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips, out bool complete); // 0x0000000180311280-0x00000001803113C0
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x0000000180311130-0x0000000180311280
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips, out bool complete); // 0x0000000180310FF0-0x0000000180311130
}

