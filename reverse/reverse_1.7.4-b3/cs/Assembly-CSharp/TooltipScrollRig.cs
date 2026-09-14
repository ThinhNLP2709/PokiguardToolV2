/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class TooltipScrollRig // TypeDefIndex: 1411
{
	// Fields
	private static readonly Color BAR_BG; // 0x00
	private static readonly Color BAR_HANDLE; // 0x10

	// Constructors
	static TooltipScrollRig(); // 0x0000000180799C30-0x0000000180799C90

	// Methods
	public static ScrollRect EnsureStacked(RectTransform host, IList<RectTransform> move, float spacing, int siblingIndex = -1 /* Metadata: 0x005EFB5F */); // 0x0000000180797AD0-0x0000000180797B60
	public static ScrollRect EnsureFixed(RectTransform host, IList<RectTransform> move, float contentHeight); // 0x0000000180797B60-0x0000000180797C00
	private static ScrollRect Build(RectTransform host, IList<RectTransform> move, bool stack, float spacing, int siblingIndex, bool stretchToHost); // 0x0000000180797C00-0x00000001807987F0
	private static Scrollbar BuildBar(RectTransform scroll); // 0x00000001807987F0-0x0000000180798CB0
	public static void SetViewHeight(ScrollRect sr, float height); // 0x0000000180798CB0-0x0000000180798EE0
	public static void SetContentHeight(ScrollRect sr, float height); // 0x0000000180798EE0-0x00000001807990A0
	public static float Measure(ScrollRect sr); // 0x00000001807990A0-0x0000000180799390
	public static bool Refresh(ScrollRect sr, bool stretchWhenShort = false /* Metadata: 0x005EFB60 */); // 0x0000000180799390-0x00000001807998C0
	private static GameObject NewNode(RectTransform parent, string name); // 0x00000001807998C0-0x0000000180799B40
	private static void Stretch(RectTransform rt); // 0x0000000180799B40-0x0000000180799C30
}

