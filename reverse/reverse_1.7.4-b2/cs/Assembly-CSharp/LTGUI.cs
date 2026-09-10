/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LTGUI // TypeDefIndex: 333
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
	public enum Element_Type // TypeDefIndex: 334
	{
		Texture = 0,
		Label = 1
	}

	// Constructors
	public LTGUI(); // 0x00000001802E9CB0-0x00000001802E9CC0
	static LTGUI(); // 0x0000000180340500-0x00000001803405B0

	// Methods
	public static void init(); // 0x0000000180341350-0x0000000180341450
	public static void initRectCheck(); // 0x00000001803411D0-0x0000000180341350
	public static void reset(); // 0x00000001803417F0-0x00000001803418F0
	public static void update(int updateLevel); // 0x0000000180341AD0-0x0000000180342860
	public static bool checkOnScreen(Rect rect); // 0x00000001803405B0-0x0000000180340670
	public static void destroy(int id); // 0x0000000180340800-0x00000001803408E0
	public static void destroyAll(int depth); // 0x0000000180340710-0x0000000180340800
	public static LTRect label(Rect rect, string label, int depth); // 0x00000001803414E0-0x0000000180341630
	public static LTRect label(LTRect rect, string label, int depth); // 0x0000000180341450-0x00000001803414E0
	public static LTRect texture(Rect rect, Texture texture, int depth); // 0x0000000180341980-0x0000000180341AD0
	public static LTRect texture(LTRect rect, Texture texture, int depth); // 0x00000001803418F0-0x0000000180341980
	public static LTRect element(LTRect rect, int depth); // 0x00000001803408E0-0x0000000180340D80
	public static bool hasNoOverlap(Rect rect, int depth); // 0x0000000180340E40-0x00000001803411D0
	public static bool pressedWithinRect(Rect rect); // 0x0000000180341630-0x00000001803417F0
	public static bool checkWithinRect(Vector2 vec2, Rect rect); // 0x0000000180340670-0x0000000180340710
	public static Vector2 firstTouch(); // 0x0000000180340D80-0x0000000180340E40
}

