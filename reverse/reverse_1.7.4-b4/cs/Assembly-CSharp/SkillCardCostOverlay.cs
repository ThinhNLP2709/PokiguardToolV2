/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public static class SkillCardCostOverlay // TypeDefIndex: 1154
{
	// Fields
	private static Font _font; // 0x00
	private static bool _fontTried; // 0x08

	// Methods
	public static void Apply(Image cardImage, CardData data); // 0x00000001806A9630-0x00000001806A9970
	public static void Remove(Transform cardImage); // 0x00000001806A9970-0x00000001806A99E0
	private static bool Paint(Image cardImage, string node, SkillCardCostBoxes.Box box, int value); // 0x00000001806A99E0-0x00000001806AA990
	private static Texture2D PlateTexture(Texture2D existing, SkillCardCostBoxes.Box box); // 0x00000001806AA990-0x00000001806AACD0
	private static Rect DrawnSpriteRect(Image img); // 0x00000001806AACD0-0x00000001806AB0B0
	private static Font LoadFont(); // 0x00000001806AB0B0-0x00000001806AB2D0
	private static void RemoveOne(Transform parent, string node); // 0x00000001806AB2D0-0x00000001806AB590
}

