/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class TooltipScrollRig // TypeDefIndex: 1033
{
	// Fields
	public const string NODE_SCROLL = "tipScroll"; // Metadata: 0x0068C191
	public const string NODE_VIEWPORT = "tipViewport"; // Metadata: 0x0068C19B
	public const string NODE_CONTENT = "tipContent"; // Metadata: 0x0068C1A7
	public const string NODE_BAR = "tipScrollBar"; // Metadata: 0x0068C1B2
	private const float BAR_WIDTH = 4f; // Metadata: 0x0068C1BF
	private static readonly Color BAR_BG; // 0x00
	private static readonly Color BAR_HANDLE; // 0x10

	// Constructors
	static TooltipScrollRig(); // 0x000000018050C420-0x000000018050C480

	// Methods
	public static ScrollRect EnsureStacked(RectTransform host, IList<RectTransform> move, float spacing, int siblingIndex = -1 /* Metadata: 0x0068C18F */); // 0x000000018050BAA0-0x000000018050BB30
	public static ScrollRect EnsureFixed(RectTransform host, IList<RectTransform> move, float contentHeight); // 0x000000018050B970-0x000000018050BAA0
	private static ScrollRect Build(RectTransform host, IList<RectTransform> move, bool stack, float spacing, int siblingIndex, bool stretchToHost); // 0x000000018050B190-0x000000018050B970
	private static Scrollbar BuildBar(RectTransform scroll); // 0x000000018050ADB0-0x000000018050B190
	public static void SetViewHeight(ScrollRect sr, float height); // 0x000000018050C200-0x000000018050C330
	public static void SetContentHeight(ScrollRect sr, float height); // 0x000000018050C140-0x000000018050C200
	public static float Measure(ScrollRect sr); // 0x000000018050BBF0-0x000000018050BD30
	public static bool Refresh(ScrollRect sr, bool stretchWhenShort = false /* Metadata: 0x0068C190 */); // 0x000000018050BEA0-0x000000018050C140
	public static ScrollRect Find(RectTransform host); // 0x000000018050BB30-0x000000018050BBF0
	private static GameObject NewNode(RectTransform parent, string name); // 0x000000018050BD30-0x000000018050BEA0
	private static void Stretch(RectTransform rt); // 0x000000018050C330-0x000000018050C420
}

