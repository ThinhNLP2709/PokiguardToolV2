/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class PokyChestSpriteSet : MonoBehaviour // TypeDefIndex: 868
{
	// Fields
	[Tooltip("R\u01B0\u01A1ng \u0110\u00D3NG theo b\u1EADc 1..3 (Poky: nh\u1ECF \u00B7 l\u1EDBn \u00B7 l\u1EDBn+sao)")]
	public Sprite[] closed; // 0x20
	[Tooltip("R\u01B0\u01A1ng \u0110\u00C3 M\u1EDE theo b\u1EADc 1..3")]
	public Sprite[] opened; // 0x28
	[Tooltip("Ng\u00F4i sao v\u00E0ng g\u1EAFn g\u00F3c ph\u1EA3i-tr\u00EAn cho r\u01B0\u01A1ng b\u1EADc 3 (StarVer2::goldStar 28\u00D726)")]
	public Sprite starBadge; // 0x30

	// Properties
	public bool Ready { get; } // 0x000000018043FFE0-0x0000000180440110 

	// Constructors
	public PokyChestSpriteSet(); // 0x000000018043FF60-0x000000018043FFE0

	// Methods
	public Sprite Get(int tier, bool isOpened); // 0x000000018043FF00-0x000000018043FF60
}

