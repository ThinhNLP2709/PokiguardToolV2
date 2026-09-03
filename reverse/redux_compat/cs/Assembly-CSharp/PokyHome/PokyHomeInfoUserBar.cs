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
	public class PokyHomeInfoUserBar : MonoBehaviour // TypeDefIndex: 1881
	{
		// Fields
		[Tooltip("Node \'Main/UserGold/Text Gold\'.")]
		public UnityEngine.UI.Text goldText; // 0x20
		[Tooltip("Node \'Main/UserGem/Text Gem\'.")]
		public UnityEngine.UI.Text gemText; // 0x28
		[Tooltip("C\u00E1c \u00F4 t\u00E0i nguy\u00EAn KH\u00D4NG d\u00F9ng \u1EDF Home \u2014 builder t\u1EAFt s\u1EB5n (\u0111\u00E1, v\u00E9, xu\u2026).")]
		public GameObject[] hiddenSlots; // 0x30
		private int _gold; // 0x38
		private int _gem; // 0x3C
	
		// Constructors
		public PokyHomeInfoUserBar(); // 0x000000018062D2E0-0x000000018062D2F0
	
		// Methods
		private void Awake(); // 0x000000018062CDF0-0x000000018062CF10
		public void Bind(UserDTO user); // 0x000000018062CF10-0x000000018062D060
		public void SetGold(int value); // 0x000000018062D110-0x000000018062D1C0
		public void SetGem(int value); // 0x000000018062D060-0x000000018062D110
		public static string Short(int value); // 0x000000018062D1C0-0x000000018062D2E0
	}
}
