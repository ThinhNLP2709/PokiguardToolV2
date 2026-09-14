/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyShopTabAdapter : MonoBehaviour // TypeDefIndex: 2694
	{
		// Fields
		[Header("4 kh\u1ED1i danh s\u00E1ch c\u1EE7a ShopManager (ngu\u1ED3n tr\u1EA1ng th\u00E1i)")]
		public GameObject listAvt; // 0x20
		public GameObject listPet; // 0x28
		public GameObject listItem; // 0x30
		public GameObject listPackage; // 0x38
		[Header("4 d\u1EA5u tab v\u00E0ng (Background/Checkmark c\u1EE7a Poky)")]
		public GameObject markAvt; // 0x40
		public GameObject markPet; // 0x48
		public GameObject markItem; // 0x50
		public GameObject markPackage; // 0x58
		private int _shown; // 0x60
	
		// Constructors
		public PokyShopTabAdapter(); // 0x0000000180C49FE0-0x0000000180C4A030
	
		// Methods
		private void OnEnable(); // 0x0000000180C498B0-0x0000000180C498C0
		private void LateUpdate(); // 0x0000000180C498C0-0x0000000180C49920
		private void Apply(); // 0x0000000180C49920-0x0000000180C49E50
		private static void Set(GameObject go, bool on); // 0x0000000180C49E50-0x0000000180C49FE0
	}
}
