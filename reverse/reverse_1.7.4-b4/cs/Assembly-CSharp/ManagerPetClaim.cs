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

public class ManagerPetClaim : MonoBehaviour // TypeDefIndex: 1620
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
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 1621
	{
		// Fields
		public ManagerPetClaim __4__this; // 0x10
		public PetClaimDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupClaimButton_b__0(); // 0x000000018089A8D0-0x000000018089A900
	}

	[CompilerGenerated]
	private sealed class _ClaimPetFromServer_d__28 : IEnumerator<object> // TypeDefIndex: 1622
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long petId; // 0x20
		public ManagerPetClaim __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimPetFromServer_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018089A900-0x000000018089ABD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018089ABD0-0x000000018089AC10
	}

	[CompilerGenerated]
	private sealed class _GetPetListFromServer_d__17 : IEnumerator<object> // TypeDefIndex: 1623
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerPetClaim __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GetPetListFromServer_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018089AC10-0x000000018089AF10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018089AF10-0x000000018089AF50
	}

	// Constructors
	public ManagerPetClaim(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void OnDisable(); // 0x00000001802D2830-0x00000001802D2840
	private void Awake(); // 0x0000000180896EB0-0x0000000180897450
	private void Start(); // 0x0000000180897450-0x0000000180897730
	private void SetupResultPanelButton(); // 0x0000000180897730-0x0000000180897930
	public void LoadPetList(); // 0x0000000180897930-0x0000000180897A90
	[IteratorStateMachine(typeof(_GetPetListFromServer_d__17))]
	private IEnumerator GetPetListFromServer(); // 0x0000000180897A90-0x0000000180897B30
	private void OnPetListLoaded(PetListResponse response); // 0x0000000180897B30-0x0000000180897D40
	private void OnPetListError(string error); // 0x0000000180897D40-0x0000000180897E00
	private void DisplayPetList(); // 0x0000000180897E00-0x00000001808981C0
	private void HideAllPetItems(); // 0x00000001808981C0-0x0000000180898360
	private void SetupPetItem(GameObject gpetObj, PetClaimDTO pet); // 0x0000000180898360-0x0000000180898A10
	private void SetupConditionText(GameObject parent, string textName, int current, int required); // 0x0000000180898A10-0x0000000180898D00
	private void SetupClaimButton(GameObject btnClaim, PetClaimDTO pet); // 0x0000000180898D00-0x0000000180899150
	private void SetupPetAnimation(GameObject petObj, long petId); // 0x0000000180899150-0x00000001808998A0
	private void ReplaceAnimations(Animator animator, AnimationClip[] newClips); // 0x00000001808998A0-0x0000000180899A10
	private void OnClaimPet(PetClaimDTO pet); // 0x0000000180899A10-0x0000000180899D20
	[IteratorStateMachine(typeof(_ClaimPetFromServer_d__28))]
	private IEnumerator ClaimPetFromServer(long petId); // 0x0000000180899D20-0x0000000180899DE0
	private void OnClaimSuccess(PetClaimResponse response); // 0x0000000180899DE0-0x0000000180899F90
	private void OnClaimError(string error); // 0x0000000180899F90-0x000000018089A1C0
	private void ShowResultPanel(bool success, string message, PetClaimDTO pet); // 0x000000018089A1C0-0x000000018089A770
	public void CloseResultPanel(); // 0x000000018089A770-0x000000018089A8B0
	private void OnEnable(); // 0x000000018089A8B0-0x000000018089A8D0
}

