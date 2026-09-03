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
	public class PokyKhoPetSkin : MonoBehaviour // TypeDefIndex: 1917
	{
		// Fields
		[Header("Khung trang tr\u00ED (kh\u00F4ng c\u00F3 h\u00E0nh \u0111\u1ED9ng) \u2014 s\u1EBD T\u1EAET Button")]
		public Button btnWalletGold; // 0x20
		public Button btnWalletEnergy; // 0x28
		public Button btnWalletMerit; // 0x30
		public Button btnSkillCard; // 0x38
		[Header("Ba \u00F4 kh\u1EA3m \u0111\u00E1 \u2014 Manager g\u1EAFn listener l\u00FAc ch\u1EA1y, CH\u1EC8 gi\u1EEF tham chi\u1EBFu")]
		public Button stoneSlot1; // 0x40
		public Button stoneSlot2; // 0x48
		public Button stoneSlot3; // 0x50
		[Header("D\u1EA5u + c\u1EE7a \u00F4 kh\u1EA3m tr\u1ED1ng (nh\u1EA5p nh\u00E1y khi \u00F4 ch\u01B0a c\u00F3 \u0111\u00E1)")]
		public Image plusSlot1; // 0x58
		public Image plusSlot2; // 0x60
		public Image plusSlot3; // 0x68
		private readonly Image[] _plus; // 0x70
		private readonly Image[] _icon; // 0x78
		private bool _hasPlus; // 0x80
	
		// Constructors
		public PokyKhoPetSkin(); // 0x0000000180645670-0x00000001806456F0
	
		// Methods
		private void Awake(); // 0x0000000180644E70-0x0000000180645170
		private static Image IconOf(Button slot); // 0x0000000180645170-0x0000000180645240
		private void LateUpdate(); // 0x0000000180645240-0x0000000180645490
		private static void Mute(Button b); // 0x0000000180645490-0x0000000180645580
		private static void Unmute(Button b); // 0x0000000180645580-0x0000000180645670
	}
}
