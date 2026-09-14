/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LTGUI // TypeDefIndex: 330
{
	// Fields
	public static int RECT_LEVELS; // 0x00
	public static int RECTS_PER_LEVEL; // 0x04
	public static int BUTTONS_MAX; // 0x08
	private static LTRect[] levels; // 0x10
	private static int[] levelDepths; // 0x18
	private static Color color; // 0x20
	private static bool isGUIEnabled; // 0x30
	private static int global_counter; // 0x34

	// Nested types
	public enum Element_Type // TypeDefIndex: 331
	{
		Texture = 0,
		Label = 1
	}

	// Constructors
	static LTGUI(); // 0x00000001802FB300-0x00000001802FB3B0

	// Methods
	public static void reset(); // 0x00000001802FB0D0-0x00000001802FB220
	public static void destroy(int id); // 0x00000001802FB220-0x00000001802FB300
}

