/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[Serializable]
	public class PokyHomeModuleDef // TypeDefIndex: 1886
	{
		// Fields
		[Tooltip("Kh\u1EDBp T\u00CAN node trong poky_home_spec.json \u2014 builder tra theo kho\u00E1 n\u00E0y.")]
		public string id; // 0x10
		[Tooltip("Kho\u00E1 trong poky_lang.json (language_config b\u1EA3n g\u1ED1c). R\u1ED7ng = d\u00F9ng nh\u00E3n c\u1EE9ng b\u00EAn d\u01B0\u1EDBi.")]
		public string labelKey; // 0x18
		[Tooltip("Nh\u00E3n c\u1EE9ng khi kh\u00F4ng c\u00F3 kho\u00E1 ng\u00F4n ng\u1EEF. B\u1ECF tr\u1ED1ng = gi\u1EEF ch\u1EEF c\u00F3 s\u1EB5n trong spec.")]
		public string label; // 0x20
		[Tooltip("T\u00EAn sprite tr\u1EA1ng th\u00E1i M\u1EDE (trong Assets/PokyHome/Art/Atlas/Home.png).")]
		public string spriteName; // 0x28
		[Tooltip("Sprite tr\u1EA1ng th\u00E1i KHO\u00C1 (b\u1EA3n _gray). B\u1ECF tr\u1ED1ng = l\u00E0m x\u00E1m b\u1EB1ng m\u00E0u.")]
		public string graySpriteName; // 0x30
		[Tooltip("C\u1EA5p t\u1ED1i thi\u1EC3u \u0111\u1EC3 v\u00E0o (game_config.require_lv c\u1EE7a b\u1EA3n g\u1ED1c). 0/1 = lu\u00F4n m\u1EDF. Ch\u01B0a \u0111\u1EE7 c\u1EA5p v\u1EABn b\u1EA5m \u0111\u01B0\u1EE3c nh\u01B0ng ch\u1EC9 hi\u1EC7n toast \u2014 n\u00FAt ch\u1EBFt c\u00E2m l\u00E0 UX t\u1EC7 nh\u1EA5t.")]
		public int requireLevel; // 0x38
		[Tooltip("Kho\u00E1 route trong danh s\u00E1ch tr\u1EAFng HomeDeepLink.Routes, ho\u1EB7c route n\u1ED9i b\u1ED9: settings / focus_next / none.")]
		public string routeKey; // 0x40
		[Tooltip("Kho\u00E1 c\u1EDD t\u00EDnh n\u0103ng tr\u00EAn web admin (m\u1EB7c \u0111\u1ECBnh B\u1EACT \u2014 m\u1EA5t m\u1EA1ng kh\u00F4ng \u0111\u01B0\u1EE3c l\u00E0m ch\u1EBFt UI).")]
		public string flagKey; // 0x48
		public PokyNotifySource notifySource; // 0x50
	
		// Constructors
		public PokyHomeModuleDef(); // 0x0000000180630D80-0x0000000180630D90
	}
}
