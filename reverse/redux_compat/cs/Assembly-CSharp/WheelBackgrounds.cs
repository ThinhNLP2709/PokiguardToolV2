/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class WheelBackgrounds // TypeDefIndex: 946
{
	// Fields
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Color SOLID_DAILY; // 0x08
	private static readonly Color SOLID_GALAXY; // 0x18
	private static readonly Color SOLID_TREASURE; // 0x28

	// Constructors
	static WheelBackgrounds(); // 0x000000018047A620-0x000000018047A830

	// Methods
	public static Sprite Get(WheelKind kind); // 0x000000018047A1D0-0x000000018047A400
	public static Texture GetTexture(WheelKind kind); // 0x000000018047A130-0x000000018047A1D0
	public static Color SolidColor(WheelKind kind); // 0x000000018047A460-0x000000018047A620
	public static void Invalidate(); // 0x000000018047A400-0x000000018047A460
}

