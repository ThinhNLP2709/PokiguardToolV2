/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class LevelFrameVisualUtil // TypeDefIndex: 972
{
	// Fields
	private const string FallbackPath = "Image/hclv/lv_0001"; // Metadata: 0x0064CEE7
	private static readonly Color[] TierTextColors; // 0x00

	// Constructors
	static LevelFrameVisualUtil(); // 0x0000000180474110-0x0000000180474200

	// Methods
	public static int ClampLevel(int level); // 0x0000000180473D10-0x0000000180473D20
	public static Sprite LoadFrameSprite(int level); // 0x0000000180473FA0-0x0000000180474110
	public static int GetTierIndex(int level); // 0x0000000180473DE0-0x0000000180473E80
	public static Color GetTierTextColor(int level); // 0x0000000180473E80-0x0000000180473FA0
	public static UnityEngine.UI.Text FindLevelText(Transform frameRoot); // 0x0000000180473D20-0x0000000180473DE0
	public static void ApplyToImage(Image img, int level, UnityEngine.UI.Text txtLv, Sprite spriteOverride = null); // 0x0000000180473980-0x0000000180473D10
}

