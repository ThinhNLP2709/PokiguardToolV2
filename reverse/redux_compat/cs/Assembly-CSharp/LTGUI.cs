/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LTGUI // TypeDefIndex: 307
{
	// Fields
	public static int RECT_LEVELS; // 0x00
	public static int RECTS_PER_LEVEL; // 0x04
	public static int BUTTONS_MAX; // 0x08
	private static LTRect[] levels; // 0x10
	private static int[] levelDepths; // 0x18
	private static Rect[] buttons; // 0x20
	private static int[] buttonLevels; // 0x28
	private static int[] buttonLastFrame; // 0x30
	private static LTRect r; // 0x38
	private static Color color; // 0x40
	private static bool isGUIEnabled; // 0x50
	private static int global_counter; // 0x54

	// Nested types
	public enum Element_Type // TypeDefIndex: 308
	{
		Texture = 0,
		Label = 1
	}

	// Constructors
	public LTGUI(); // 0x00000001802E5CB0-0x00000001802E5CC0
	static LTGUI(); // 0x00000001806F4560-0x00000001806F4610

	// Methods
	public static void init(); // 0x00000001806F53B0-0x00000001806F54B0
	public static void initRectCheck(); // 0x00000001806F5230-0x00000001806F53B0
	public static void reset(); // 0x00000001806F5850-0x00000001806F5950
	public static void update(int updateLevel); // 0x00000001806F5B30-0x00000001806F68C0
	public static bool checkOnScreen(Rect rect); // 0x00000001806F4610-0x00000001806F46D0
	public static void destroy(int id); // 0x00000001806F4860-0x00000001806F4940
	public static void destroyAll(int depth); // 0x00000001806F4770-0x00000001806F4860
	public static LTRect label(Rect rect, string label, int depth); // 0x00000001806F5540-0x00000001806F5690
	public static LTRect label(LTRect rect, string label, int depth); // 0x00000001806F54B0-0x00000001806F5540
	public static LTRect texture(Rect rect, Texture texture, int depth); // 0x00000001806F59E0-0x00000001806F5B30
	public static LTRect texture(LTRect rect, Texture texture, int depth); // 0x00000001806F5950-0x00000001806F59E0
	public static LTRect element(LTRect rect, int depth); // 0x00000001806F4940-0x00000001806F4DE0
	public static bool hasNoOverlap(Rect rect, int depth); // 0x00000001806F4EA0-0x00000001806F5230
	public static bool pressedWithinRect(Rect rect); // 0x00000001806F5690-0x00000001806F5850
	public static bool checkWithinRect(Vector2 vec2, Rect rect); // 0x00000001806F46D0-0x00000001806F4770
	public static Vector2 firstTouch(); // 0x00000001806F4DE0-0x00000001806F4EA0
}

