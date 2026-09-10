/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyKhoPetSelectAdapter : MonoBehaviour // TypeDefIndex: 2242
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
		public PokyKhoPetSelectAdapter(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x00000001807886C0-0x00000001807886D0
		private void OnEnable(); // 0x0000000180788F80-0x0000000180789010
		private void OnDisable(); // 0x0000000180788F00-0x0000000180788F80
		private void EnsureReady(); // 0x0000000180788810-0x0000000180788C50
		private static void Hook(Button b, UnityAction call); // 0x0000000180788D60-0x0000000180788E00
		public void OpenPopup(); // 0x00000001807890A0-0x0000000180789210
		public void ClosePopup(); // 0x00000001807886D0-0x0000000180788810
		private void ForceClose(); // 0x0000000180788C50-0x0000000180788D60
		private void OnPetSelected(PetUserDTO pet); // 0x0000000180789010-0x00000001807890A0
		private void Neighbor(int dir); // 0x0000000180788E00-0x0000000180788F00
		private void QuickFill(); // 0x0000000180789210-0x0000000180789300
		[CompilerGenerated]
		private void _EnsureReady_b__11_0(); // 0x0000000180789300-0x0000000180789310
		[CompilerGenerated]
		private void _EnsureReady_b__11_1(); // 0x0000000180789310-0x0000000180789320
	}
}
