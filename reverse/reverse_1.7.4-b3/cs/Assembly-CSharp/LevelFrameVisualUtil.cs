/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LevelFrameVisualUtil // TypeDefIndex: 1574
{
	// Fields
	private static readonly Color[] TierTextColors; // 0x00

	// Constructors
	static LevelFrameVisualUtil(); // 0x000000018086B550-0x000000018086B6A0

	// Methods
	public static int ClampLevel(int level); // 0x000000018086ABB0-0x000000018086ABC0
	public static Sprite LoadFrameSprite(int level); // 0x000000018086ABC0-0x000000018086AE20
	public static int GetTierIndex(int level); // 0x000000018086AE20-0x000000018086AEC0
	public static Color GetTierTextColor(int level); // 0x000000018086AEC0-0x000000018086AFF0
	public static UnityEngine.UI.Text FindLevelText(Transform frameRoot); // 0x000000018086AFF0-0x000000018086B200
	public static void ApplyToImage(Image img, int level, UnityEngine.UI.Text txtLv, Sprite spriteOverride = null); // 0x000000018086B200-0x000000018086B550
}

