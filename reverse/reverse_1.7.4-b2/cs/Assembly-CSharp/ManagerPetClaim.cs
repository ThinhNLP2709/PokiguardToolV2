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

public class ManagerPetClaim : MonoBehaviour // TypeDefIndex: 1217
{
	// Fields
	[Header("Panel References")]
	public GameObject panelPet; // 0x20
	public GameObject panelResult; // 0x28
	[Header("Gpet Items")]
	public GameObject gpet1; // 0x30
	public GameObject gpet2; // 0x38
	public GameObject gpet3; // 0x40
	[Header("Panel Result")]
	public UnityEngine.UI.Text txtResultMessage; // 0x48
	public GameObject resultPetAnimation; // 0x50
	public Button btnOkResult; // 0x58
	[Header("Default Assets (Optional)")]
	public Sprite defaultPetSprite; // 0x60
	private List<PetClaimDTO> petList; // 0x68
	private long userId; // 0x70
	private bool isLoading; // 0x78

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1218
	{
		// Fields
		public ManagerPetClaim __4__this; // 0x10
		public PetClaimDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupClaimButton_b__0(); // 0x00000001805A5760-0x00000001805A5790
	}

	[CompilerGenerated]
	private sealed class _ClaimPetFromServer_d__28 : IEnumerator<object> // TypeDefIndex: 1219
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long petId; // 0x20
		public ManagerPetClaim __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimPetFromServer_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A3190-0x00000001805A3360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A3360-0x00000001805A33A0
	}

	[CompilerGenerated]
	private sealed class _GetPetListFromServer_d__17 : IEnumerator<object> // TypeDefIndex: 1220
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerPetClaim __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GetPetListFromServer_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A37D0-0x00000001805A3960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A3960-0x00000001805A39A0
	}

	// Constructors
	public ManagerPetClaim(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void OnDisable(); // 0x0000000180312750-0x0000000180312760
	private void Awake(); // 0x000000018059CD70-0x000000018059CFF0
	private void Start(); // 0x000000018059ED20-0x000000018059F010
	private void SetupResultPanelButton(); // 0x000000018059E9D0-0x000000018059EB20
	public void LoadPetList(); // 0x000000018059D580-0x000000018059D690
	[IteratorStateMachine(typeof(_GetPetListFromServer_d__17))]
	private IEnumerator GetPetListFromServer(); // 0x000000018059D3D0-0x000000018059D440
	private void OnPetListLoaded(PetListResponse response); // 0x000000018059DCD0-0x000000018059DE00
	private void OnPetListError(string error); // 0x000000018059DC30-0x000000018059DCD0
	private void DisplayPetList(); // 0x000000018059D0F0-0x000000018059D3D0
	private void HideAllPetItems(); // 0x000000018059D440-0x000000018059D580
	private void SetupPetItem(GameObject gpetObj, PetClaimDTO pet); // 0x000000018059E630-0x000000018059E9D0
	private void SetupConditionText(GameObject parent, string textName, int current, int required); // 0x000000018059E0F0-0x000000018059E240
	private void SetupClaimButton(GameObject btnClaim, PetClaimDTO pet); // 0x000000018059DED0-0x000000018059E0F0
	private void SetupPetAnimation(GameObject petObj, long petId); // 0x000000018059E240-0x000000018059E630
	private void ReplaceAnimations(Animator animator, AnimationClip[] newClips); // 0x000000018059DE00-0x000000018059DED0
	private void OnClaimPet(PetClaimDTO pet); // 0x000000018059D860-0x000000018059DAA0
	[IteratorStateMachine(typeof(_ClaimPetFromServer_d__28))]
	private IEnumerator ClaimPetFromServer(long petId); // 0x000000018059CFF0-0x000000018059D070
	private void OnClaimSuccess(PetClaimResponse response); // 0x000000018059DAA0-0x000000018059DC10
	private void OnClaimError(string error); // 0x000000018059D690-0x000000018059D860
	private void ShowResultPanel(bool success, string message, PetClaimDTO pet); // 0x000000018059EB20-0x000000018059ED20
	public void CloseResultPanel(); // 0x000000018059D070-0x000000018059D0F0
	private void OnEnable(); // 0x000000018059DC10-0x000000018059DC30
}

