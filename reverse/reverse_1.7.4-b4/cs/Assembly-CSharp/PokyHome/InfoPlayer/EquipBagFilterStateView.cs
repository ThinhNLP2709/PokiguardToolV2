/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class EquipBagFilterStateView : MonoBehaviour // TypeDefIndex: 2781
	{
		// Fields
		[Header("Tab th\u1EC3 lo\u1EA1i \u2014 \u0111\u00FAng th\u1EE9 t\u1EF1 EquipCategory (All \u00B7 Weapon \u00B7 Pet \u00B7 Costume \u00B7 Effect)")]
		public Image[] tabBackgrounds; // 0x20
		[Tooltip("\u1EA2nh n\u1EC1n tab \u0110ANG CH\u1ECCN (t\u00EDm).")]
		public Sprite tabActiveSprite; // 0x28
		[Tooltip("\u1EA2nh n\u1EC1n tab kh\u00F4ng ch\u1ECDn (xanh).")]
		public Sprite tabInactiveSprite; // 0x30
		[Header("N\u00FAt l\u1ECDc \u00F4 \u2014 song song v\u1EDBi slotFilterValues")]
		public Image[] slotFilterBackgrounds; // 0x38
		[Tooltip("Gi\u00E1 tr\u1ECB EquipSlot c\u1EE7a t\u1EEBng n\u00FAt l\u1ECDc, \u0111\u00FAng th\u1EE9 t\u1EF1 c\u00E1c n\u00FAt tr\u00EAn m\u00E0n h\u00ECnh.")]
		public int[] slotFilterValues; // 0x40
		[Header("S\u1EAFp theo chi\u1EBFn l\u1EF1c")]
		[Tooltip("D\u1EA5u tick c\u1EE7a n\u00FAt \'S\u1EAFp x\u1EBFp theo chi\u1EBFn l\u1EF1c\'. T\u1EAET S\u1EB4N.")]
		public GameObject sortCheckMark; // 0x48
		[Header("M\u00E0u")]
		[Tooltip("N\u00FAt \u0111ang ch\u1ECDn \u2014 gi\u1EEF nguy\u00EAn m\u00E0u g\u1ED1c c\u1EE7a art.")]
		public Color activeColor; // 0x50
		[Tooltip("N\u00FAt kh\u00F4ng ch\u1ECDn \u2014 l\u00E0m T\u1ED0I \u0111i, kh\u00F4ng l\u00E0m s\u00E1ng: art \u0111\u00E3 tr\u1EAFng, s\u00E1ng th\u00EAm kh\u00F4ng \u0111\u1ED5i g\u00EC.")]
		public Color inactiveColor; // 0x60
	
		// Constructors
		public EquipBagFilterStateView(); // 0x0000000180CD0090-0x0000000180CD0280
	
		// Methods
		public void Refresh(EquipCategory category, EquipSlot activeSlot, bool sortByPower); // 0x0000000180CCF640-0x0000000180CCF840
		private void RefreshTabs(EquipCategory active, EquipSlot activeSlot); // 0x0000000180CCF840-0x0000000180CCFDE0
		private void RefreshSlotFilters(EquipSlot active); // 0x0000000180CCFDE0-0x0000000180CD0090
	}
}
