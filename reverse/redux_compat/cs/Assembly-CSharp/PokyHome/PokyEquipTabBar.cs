/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyEquipTabBar : MonoBehaviour // TypeDefIndex: 1902
	{
		// Fields
		[Header("N\u1EC1n 5 th\u1EBB tab (Image c\u1EE7a node tab Poky)")]
		public Image tabInfo; // 0x20
		public Image tabPet; // 0x28
		public Image tabAvt; // 0x30
		public Image tabWeapon; // 0x38
		public Image tabShard; // 0x40
		[Header("Kh\u1ED1i n\u1ED9i dung t\u01B0\u01A1ng \u1EE9ng (Manager b\u1EADt/t\u1EAFt)")]
		public GameObject contentInfo; // 0x48
		public GameObject contentPet; // 0x50
		public GameObject contentAvt; // 0x58
		public GameObject contentWeapon; // 0x60
		public GameObject contentShard; // 0x68
		[Header("Sprite tr\u1EA1ng th\u00E1i")]
		public Sprite spriteOn; // 0x70
		public Sprite spriteOff; // 0x78
		private int _current; // 0x80
	
		// Constructors
		public PokyEquipTabBar(); // 0x000000018062A010-0x000000018062A030
	
		// Methods
		private void OnEnable(); // 0x0000000180629F30-0x0000000180629F50
		private void LateUpdate(); // 0x0000000180629F20-0x0000000180629F30
		private void Apply(); // 0x0000000180629BD0-0x0000000180629DA0
		private int CurrentTab(); // 0x0000000180629DA0-0x0000000180629F20
		private void Set(Image img, bool on); // 0x0000000180629F50-0x000000018062A010
	}
}
