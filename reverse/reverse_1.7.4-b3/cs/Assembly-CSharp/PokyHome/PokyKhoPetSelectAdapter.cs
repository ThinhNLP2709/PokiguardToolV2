/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyKhoPetSelectAdapter : MonoBehaviour // TypeDefIndex: 2678
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
		private void Awake(); // 0x0000000180C38C60-0x0000000180C38C70
		private void OnEnable(); // 0x0000000180C38C70-0x0000000180C38E10
		private void OnDisable(); // 0x0000000180C38E10-0x0000000180C38FB0
		private void EnsureReady(); // 0x0000000180C38FB0-0x0000000180C392A0
		private static void Hook(Button b, UnityAction call); // 0x0000000180C392A0-0x0000000180C39400
		public void OpenPopup(); // 0x0000000180C39400-0x0000000180C39650
		public void ClosePopup(); // 0x0000000180C39650-0x0000000180C39870
		private void ForceClose(); // 0x0000000180C39870-0x0000000180C39B50
		private void OnPetSelected(PetUserDTO pet); // 0x0000000180C39B50-0x0000000180C39CA0
		private void Neighbor(int dir); // 0x0000000180C39CA0-0x0000000180C39E30
		private void QuickFill(); // 0x0000000180C39E30-0x0000000180C39FA0
		[CompilerGenerated]
		private void _EnsureReady_b__11_0(); // 0x0000000180C39FA0-0x0000000180C39FB0
		[CompilerGenerated]
		private void _EnsureReady_b__11_1(); // 0x0000000180C39FB0-0x0000000180C39FC0
	}
}
