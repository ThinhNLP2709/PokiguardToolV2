/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class TooltipScrollRig // TypeDefIndex: 1413
{
	// Fields
	private static readonly Color BAR_BG; // 0x00
	private static readonly Color BAR_HANDLE; // 0x10

	// Constructors
	static TooltipScrollRig(); // 0x000000018079BCA0-0x000000018079BD00

	// Methods
	public static ScrollRect EnsureStacked(RectTransform host, IList<RectTransform> move, float spacing, int siblingIndex = -1 /* Metadata: 0x005F0F2C */); // 0x0000000180799B40-0x0000000180799BD0
	public static ScrollRect EnsureFixed(RectTransform host, IList<RectTransform> move, float contentHeight); // 0x0000000180799BD0-0x0000000180799C70
	private static ScrollRect Build(RectTransform host, IList<RectTransform> move, bool stack, float spacing, int siblingIndex, bool stretchToHost); // 0x0000000180799C70-0x000000018079A860
	private static Scrollbar BuildBar(RectTransform scroll); // 0x000000018079A860-0x000000018079AD20
	public static void SetViewHeight(ScrollRect sr, float height); // 0x000000018079AD20-0x000000018079AF50
	public static void SetContentHeight(ScrollRect sr, float height); // 0x000000018079AF50-0x000000018079B110
	public static float Measure(ScrollRect sr); // 0x000000018079B110-0x000000018079B400
	public static bool Refresh(ScrollRect sr, bool stretchWhenShort = false /* Metadata: 0x005F0F2D */); // 0x000000018079B400-0x000000018079B930
	private static GameObject NewNode(RectTransform parent, string name); // 0x000000018079B930-0x000000018079BBB0
	private static void Stretch(RectTransform rt); // 0x000000018079BBB0-0x000000018079BCA0
}

