/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class LevelFrameVisualUtil // TypeDefIndex: 1576
{
	// Fields
	private static readonly Color[] TierTextColors; // 0x00

	// Constructors
	static LevelFrameVisualUtil(); // 0x000000018086D7E0-0x000000018086D930

	// Methods
	public static int ClampLevel(int level); // 0x000000018086CE40-0x000000018086CE50
	public static Sprite LoadFrameSprite(int level); // 0x000000018086CE50-0x000000018086D0B0
	public static int GetTierIndex(int level); // 0x000000018086D0B0-0x000000018086D150
	public static Color GetTierTextColor(int level); // 0x000000018086D150-0x000000018086D280
	public static UnityEngine.UI.Text FindLevelText(Transform frameRoot); // 0x000000018086D280-0x000000018086D490
	public static void ApplyToImage(Image img, int level, UnityEngine.UI.Text txtLv, Sprite spriteOverride = null); // 0x000000018086D490-0x000000018086D7E0
}

