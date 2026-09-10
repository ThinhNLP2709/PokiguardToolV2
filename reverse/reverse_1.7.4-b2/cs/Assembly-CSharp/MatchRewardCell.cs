/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchRewardCell // TypeDefIndex: 908
{
	// Fields
	private const string POKY_PATH = "Prefabs/Poky/PokyMatchRewardCell"; // Metadata: 0x0068BEE6
	private const string SKIN_KEY = "MatchRewardCell"; // Metadata: 0x0068BF07
	private static readonly string[] IconNames; // 0x00
	private static GameObject _poky; // 0x08
	private static bool _tried; // 0x10

	// Constructors
	static MatchRewardCell(); // 0x00000001804D4120-0x00000001804D4270

	// Methods
	public static GameObject Spawn(GameObject legacyPrefab, Transform parent); // 0x00000001804D3D50-0x00000001804D4120
	private static GameObject PokyPrefab(); // 0x00000001804D3BB0-0x00000001804D3D50
	private static Sprite DefaultIcon(GameObject legacyPrefab); // 0x00000001804D3910-0x00000001804D3BB0
}

