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
	public class PokyHubRoute // TypeDefIndex: 1858
	{
		// Fields
		[Tooltip("T\u00EAn node trong poky_home_spec.json (Campaign, Arena, Shop, ButtonEvent\u2026).")]
		public string nodeId; // 0x10
		[Tooltip("Kho\u00E1 route \u2014 PokyHubActions.Invoke tra b\u1EA3ng n\u00E0y.")]
		public string routeKey; // 0x18
		[Tooltip("Nh\u00E3n ti\u1EBFng Vi\u1EC7t hi\u1EC7n tr\u00EAn n\u00FAt. R\u1ED7ng = gi\u1EEF nh\u00E3n g\u1ED1c Poky (theo labelKey).")]
		public string label; // 0x20
		[Tooltip("Kho\u00E1 trong poky_lang.json \u2014 ch\u1EC9 d\u00F9ng khi label r\u1ED7ng.")]
		public string labelKey; // 0x28
		[Tooltip("C\u1EDD t\u00EDnh n\u0103ng web admin (m\u1EB7c \u0111\u1ECBnh B\u1EACT). R\u1ED7ng = kh\u00F4ng c\u00F3 c\u1ED5ng c\u1EDD.")]
		public string flagKey; // 0x30
		public PokyNotifySource notifySource; // 0x38
	
		// Constructors
		public PokyHubRoute(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
