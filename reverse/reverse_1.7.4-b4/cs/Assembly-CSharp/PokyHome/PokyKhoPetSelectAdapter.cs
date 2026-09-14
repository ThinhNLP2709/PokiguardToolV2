/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyKhoPetSelectAdapter : MonoBehaviour // TypeDefIndex: 2685
	{
		// Fields
		public ManagerKhoPet manager; // 0x20
		[Tooltip("G\u1ED1c popup ch\u1ECDn pet (PET/PanelFooter).")]
		public GameObject popupRoot; // 0x28
		public Button btnOpen; // 0x30
		public Button btnClose; // 0x38
		public Button btnPrevPet; // 0x40
		public Button btnNextPet; // 0x48
		public Button btnQuickFill; // 0x50
		private bool _wired; // 0x58
	
		// Constructors
		public PokyKhoPetSelectAdapter(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180C460C0-0x0000000180C460D0
		private void OnEnable(); // 0x0000000180C460D0-0x0000000180C46270
		private void OnDisable(); // 0x0000000180C46270-0x0000000180C46410
		private void EnsureReady(); // 0x0000000180C46410-0x0000000180C46700
		private static void Hook(Button b, UnityAction call); // 0x0000000180C46700-0x0000000180C46860
		public void OpenPopup(); // 0x0000000180C46860-0x0000000180C46AB0
		public void ClosePopup(); // 0x0000000180C46AB0-0x0000000180C46CD0
		private void ForceClose(); // 0x0000000180C46CD0-0x0000000180C46FB0
		private void OnPetSelected(PetUserDTO pet); // 0x0000000180C46FB0-0x0000000180C47100
		private void Neighbor(int dir); // 0x0000000180C47100-0x0000000180C47290
		private void QuickFill(); // 0x0000000180C47290-0x0000000180C47400
		[CompilerGenerated]
		private void _EnsureReady_b__11_0(); // 0x0000000180C47400-0x0000000180C47410
		[CompilerGenerated]
		private void _EnsureReady_b__11_1(); // 0x0000000180C47410-0x0000000180C47420
	}
}
