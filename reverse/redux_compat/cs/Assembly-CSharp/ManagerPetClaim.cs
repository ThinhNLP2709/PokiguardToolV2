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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerPetClaim : MonoBehaviour // TypeDefIndex: 1019
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
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1020
	{
		// Fields
		public ManagerPetClaim __4__this; // 0x10
		public PetClaimDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupClaimButton_b__0(); // 0x00000001804AA940-0x00000001804AA970
	}

	[CompilerGenerated]
	private sealed class _ClaimPetFromServer_d__28 : IEnumerator<object> // TypeDefIndex: 1021
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long petId; // 0x20
		public ManagerPetClaim __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimPetFromServer_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A88C0-0x00000001804A8A90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A8A90-0x00000001804A8AD0
	}

	[CompilerGenerated]
	private sealed class _GetPetListFromServer_d__17 : IEnumerator<object> // TypeDefIndex: 1022
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerPetClaim __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GetPetListFromServer_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A8C90-0x00000001804A8E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A8E20-0x00000001804A8E60
	}

	// Constructors
	public ManagerPetClaim(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void OnDisable(); // 0x00000001803099A0-0x00000001803099B0
	private void Awake(); // 0x0000000180490270-0x00000001804904F0
	private void Start(); // 0x0000000180492220-0x0000000180492510
	private void SetupResultPanelButton(); // 0x0000000180491ED0-0x0000000180492020
	public void LoadPetList(); // 0x0000000180490A80-0x0000000180490B90
	[IteratorStateMachine(typeof(_GetPetListFromServer_d__17))]
	private IEnumerator GetPetListFromServer(); // 0x00000001804908D0-0x0000000180490940
	private void OnPetListLoaded(PetListResponse response); // 0x00000001804911D0-0x0000000180491300
	private void OnPetListError(string error); // 0x0000000180491130-0x00000001804911D0
	private void DisplayPetList(); // 0x00000001804905F0-0x00000001804908D0
	private void HideAllPetItems(); // 0x0000000180490940-0x0000000180490A80
	private void SetupPetItem(GameObject gpetObj, PetClaimDTO pet); // 0x0000000180491B30-0x0000000180491ED0
	private void SetupConditionText(GameObject parent, string textName, int current, int required); // 0x00000001804915F0-0x0000000180491740
	private void SetupClaimButton(GameObject btnClaim, PetClaimDTO pet); // 0x00000001804913D0-0x00000001804915F0
	private void SetupPetAnimation(GameObject petObj, long petId); // 0x0000000180491740-0x0000000180491B30
	private void ReplaceAnimations(Animator animator, AnimationClip[] newClips); // 0x0000000180491300-0x00000001804913D0
	private void OnClaimPet(PetClaimDTO pet); // 0x0000000180490D60-0x0000000180490FA0
	[IteratorStateMachine(typeof(_ClaimPetFromServer_d__28))]
	private IEnumerator ClaimPetFromServer(long petId); // 0x00000001804904F0-0x0000000180490570
	private void OnClaimSuccess(PetClaimResponse response); // 0x0000000180490FA0-0x0000000180491110
	private void OnClaimError(string error); // 0x0000000180490B90-0x0000000180490D60
	private void ShowResultPanel(bool success, string message, PetClaimDTO pet); // 0x0000000180492020-0x0000000180492220
	public void CloseResultPanel(); // 0x0000000180490570-0x00000001804905F0
	private void OnEnable(); // 0x0000000180491110-0x0000000180491130
}

