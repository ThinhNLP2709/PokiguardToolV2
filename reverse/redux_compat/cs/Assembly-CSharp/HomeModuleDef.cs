/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class HomeModuleDef // TypeDefIndex: 611
{
	// Fields
	[Tooltip("Kh\u1EDBp T\u00CAN node trong home_layout_spec.json \u2014 builder tra theo kho\u00E1 n\u00E0y.")]
	public string id; // 0x10
	[Tooltip("Nh\u00E3n ti\u1EBFng Vi\u1EC7t hi\u1EC7n d\u01B0\u1EDBi to\u00E0 nh\u00E0 / d\u01B0\u1EDBi n\u00FAt. B\u1ECF tr\u1ED1ng = kh\u00F4ng d\u1EF1ng ch\u1EEF.")]
	public string label; // 0x18
	[Tooltip("T\u00EAn sprite trong atlas Assets/Home/Art/Atlas/Home.png (tr\u1EA1ng th\u00E1i M\u1EDE).")]
	public string spriteName; // 0x20
	[Tooltip("Sprite tr\u1EA1ng th\u00E1i KHO\u00C1 (th\u01B0\u1EDDng l\u00E0 b\u1EA3n *_gray). B\u1ECF tr\u1ED1ng = kh\u00F4ng \u0111\u1ED5i \u1EA3nh khi kho\u00E1.")]
	public string graySpriteName; // 0x28
	[Tooltip("C\u1EA5p t\u1ED1i thi\u1EC3u \u0111\u1EC3 v\u00E0o. Ch\u01B0a \u0111\u1EE7 v\u1EABn b\u1EA5m \u0111\u01B0\u1EE3c nh\u01B0ng ch\u1EC9 hi\u1EC7n toast \u2014 ng\u01B0\u1EDDi ch\u01A1i ph\u1EA3i bi\u1EBFt v\u00EC sao m\u00ECnh kh\u00F4ng v\u00E0o \u0111\u01B0\u1EE3c, \u0111\u1EEBng \u0111\u1EC3 n\u00FAt ch\u1EBFt c\u00E2m.")]
	public int requireLevel; // 0x30
	[Tooltip("Kho\u00E1 route (danh s\u00E1ch tr\u1EAFng HomeDeepLink.Routes) ho\u1EB7c route n\u1ED9i b\u1ED9: settings / expand / gate_arena / gate_wheel / none.")]
	public string routeKey; // 0x38
	[Tooltip("Kho\u00E1 c\u1EDD t\u00EDnh n\u0103ng tr\u00EAn web admin. T\u1EAFt c\u1EDD th\u00EC b\u1EA5m ch\u1EC9 hi\u1EC7n toast t\u1EA1m \u0111\u00F3ng.")]
	public string flagKey; // 0x40
	public HomeFxPreset fxPreset; // 0x48
	public HomeNotifySource notifySource; // 0x4C

	// Constructors
	public HomeModuleDef(); // 0x00000001803B4D10-0x00000001803B4D20
}

