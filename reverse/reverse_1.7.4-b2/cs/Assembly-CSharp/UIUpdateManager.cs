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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

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
	public static UIUpdateManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180429B80-0x0000000180429BC0 0x0000000180429BC0-0x0000000180429C20

	// Nested types
	private struct NumTextCache // TypeDefIndex: 87
	{
		// Fields
		public UnityEngine.UI.Text Owner; // 0x00
		public int A; // 0x08
		public int B; // 0x0C
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 88
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public int petId; // 0x1C

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupDisplayPetAnimatorCached_b__0(AnimationClip[] clips); // 0x0000000180425C60-0x0000000180425E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 89
	{
		// Fields
		public UIUpdateManager __4__this; // 0x10
		public int token; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass32_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupDisplayPlayerPetAnimator_b__0(AnimationClip[] clips); // 0x0000000180425E40-0x0000000180425F00
	}

	[CompilerGenerated]
	private sealed class _ApplyDisplayPetClipsWhenIdle_d__27 : IEnumerator<object> // TypeDefIndex: 90
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyDisplayPetClipsWhenIdle_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180424170-0x0000000180424300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180424300-0x0000000180424340
	}

	// Constructors
	public UIUpdateManager(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001804267F0-0x0000000180426850
	private void Start(); // 0x0000000180427EF0-0x0000000180427FC0
	private void OnDestroy(); // 0x0000000180426B20-0x0000000180426C00
	public void UpdateBossHPSlider(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0068AAAF */); // 0x0000000180427FC0-0x00000001804288D0
	private static void SetPairText(UnityEngine.UI.Text t, int cur, int max, ref NumTextCache c); // 0x0000000180427A70-0x0000000180427B70
	public void UpdateDisplaySliders(MatchStatMask mask = MatchStatMask.None | MatchStatMask.HP | MatchStatMask.Mana | MatchStatMask.Power | MatchStatMask.All /* Metadata: 0x0068AAB0 */); // 0x0000000180429090-0x0000000180429860
	private void UpdateWeaknessText(Active.PlayerStats displayStats); // 0x0000000180429860-0x0000000180429B80
	public int GetActorToDisplay(); // 0x0000000180426940-0x0000000180426B20
	public void RefreshDisplayUIForWsActor(int wsActor); // 0x0000000180426C90-0x0000000180427350
	public void ResetDisplayBindCache(); // 0x0000000180427870-0x0000000180427890
	private static string ResolveDisplayNameForActor(int wsActor); // 0x0000000180427890-0x0000000180427A70
	private void SetupDisplayPetAnimatorCached(int petId); // 0x0000000180427B70-0x0000000180427D30
	[IteratorStateMachine(typeof(_ApplyDisplayPetClipsWhenIdle_d__27))]
	private IEnumerator ApplyDisplayPetClipsWhenIdle(int petId, AnimationClip[] clips, int token); // 0x00000001804263A0-0x0000000180426450
	public static void PrewarmDisplayPetClips(int petId); // 0x0000000180426C00-0x0000000180426C90
	private void ApplyDisplayPetClips(int petId, AnimationClip[] clips); // 0x0000000180426450-0x0000000180426590
	private bool ApplyStaticDisplayPet(int petId); // 0x0000000180426590-0x00000001804267F0
	internal void UpdateDisplayPlayerUI(PetUserDTO petStats); // 0x00000001804288D0-0x0000000180429090
	private void SetupDisplayPlayerPetAnimator(string petId); // 0x0000000180427D30-0x0000000180427EF0
	private void BindDisplayPlayerPet(AnimationClip[] clips, string petId); // 0x0000000180426850-0x0000000180426940
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips); // 0x0000000180427720-0x0000000180427870
	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips, out bool complete); // 0x00000001804275E0-0x0000000180427720
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips); // 0x0000000180427490-0x00000001804275E0
	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips, out bool complete); // 0x0000000180427350-0x0000000180427490
}

