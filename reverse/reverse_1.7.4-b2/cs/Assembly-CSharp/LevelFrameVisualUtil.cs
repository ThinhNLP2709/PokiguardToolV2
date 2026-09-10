/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class LevelFrameVisualUtil // TypeDefIndex: 1169
{
	// Fields
	private const string FallbackPath = "Image/hclv/lv_0001"; // Metadata: 0x0068C6CC
	public const int MaxFrameLevel = 78; // Metadata: 0x0068C6DF
	private static readonly Color[] TierTextColors; // 0x00

	// Constructors
	static LevelFrameVisualUtil(); // 0x0000000180575F00-0x0000000180575FF0

	// Methods
	public static int ClampLevel(int level); // 0x0000000180575B00-0x0000000180575B10
	public static Sprite LoadFrameSprite(int level); // 0x0000000180575D90-0x0000000180575F00
	public static int GetTierIndex(int level); // 0x0000000180575BD0-0x0000000180575C70
	public static Color GetTierTextColor(int level); // 0x0000000180575C70-0x0000000180575D90
	public static UnityEngine.UI.Text FindLevelText(Transform frameRoot); // 0x0000000180575B10-0x0000000180575BD0
	public static void ApplyToImage(Image img, int level, UnityEngine.UI.Text txtLv, Sprite spriteOverride = null); // 0x0000000180575760-0x0000000180575B00
}

