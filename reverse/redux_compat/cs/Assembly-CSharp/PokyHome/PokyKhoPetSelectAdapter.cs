/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyKhoPetSelectAdapter : MonoBehaviour // TypeDefIndex: 1916
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
		public PokyKhoPetSelectAdapter(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x0000000180644210-0x0000000180644220
		private void OnEnable(); // 0x0000000180644AD0-0x0000000180644B60
		private void OnDisable(); // 0x0000000180644A50-0x0000000180644AD0
		private void EnsureReady(); // 0x0000000180644360-0x00000001806447A0
		private static void Hook(Button b, UnityAction call); // 0x00000001806448B0-0x0000000180644950
		public void OpenPopup(); // 0x0000000180644BF0-0x0000000180644D60
		public void ClosePopup(); // 0x0000000180644220-0x0000000180644360
		private void ForceClose(); // 0x00000001806447A0-0x00000001806448B0
		private void OnPetSelected(PetUserDTO pet); // 0x0000000180644B60-0x0000000180644BF0
		private void Neighbor(int dir); // 0x0000000180644950-0x0000000180644A50
		private void QuickFill(); // 0x0000000180644D60-0x0000000180644E50
		[CompilerGenerated]
		private void _EnsureReady_b__11_0(); // 0x0000000180644E50-0x0000000180644E60
		[CompilerGenerated]
		private void _EnsureReady_b__11_1(); // 0x0000000180644E60-0x0000000180644E70
	}
}
