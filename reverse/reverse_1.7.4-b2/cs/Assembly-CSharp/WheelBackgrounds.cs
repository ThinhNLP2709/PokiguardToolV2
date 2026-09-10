/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class WheelBackgrounds // TypeDefIndex: 1140
{
	// Fields
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Color SOLID_DAILY; // 0x08
	private static readonly Color SOLID_GALAXY; // 0x18
	private static readonly Color SOLID_TREASURE; // 0x28

	// Constructors
	static WheelBackgrounds(); // 0x0000000180563BA0-0x0000000180563DB0

	// Methods
	public static Sprite Get(WheelKind kind); // 0x0000000180563750-0x0000000180563980
	public static Texture GetTexture(WheelKind kind); // 0x00000001805636B0-0x0000000180563750
	public static Color SolidColor(WheelKind kind); // 0x00000001805639E0-0x0000000180563BA0
	public static void Invalidate(); // 0x0000000180563980-0x00000001805639E0
}

