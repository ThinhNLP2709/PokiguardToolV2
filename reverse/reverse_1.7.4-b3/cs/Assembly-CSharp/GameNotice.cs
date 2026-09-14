/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GameNotice // TypeDefIndex: 1390
{
	// Fields
	private static string _lastThrottledMsg; // 0x00
	private static float _lastThrottledAt; // 0x08

	// Nested types
	public struct GiftLine // TypeDefIndex: 1391
	{
		// Fields
		public string message; // 0x00
		public Sprite icon; // 0x08
		public string amount; // 0x10

		// Constructors
		public GiftLine(string message, Sprite icon, string amount); // 0x0000000180786060-0x0000000180786160
	}

	// Constructors
	static GameNotice(); // 0x0000000180786010-0x0000000180786060

	// Methods
	private static GameObject LoadPrefab(); // 0x0000000180784C10-0x0000000180784E40
	public static void Show(string message, float duration = 2.5f /* Metadata: 0x005EFA41 */); // 0x0000000180784E40-0x00000001807850F0
	public static void ShowGift(string message, Sprite icon = null, string amount = null, float duration = 2.5f /* Metadata: 0x005EFA45 */); // 0x00000001807850F0-0x00000001807851C0
	public static void ShowGift(string message, Sprite icon, string amount, float duration, float offsetY); // 0x00000001807851C0-0x0000000180785250
	internal static PokyGiftToastView ShowGiftLine(string message, Sprite icon, string amount, float duration, float offsetY); // 0x0000000180785250-0x0000000180785660
	public static void ShowGuildHorn(string sender, string message); // 0x0000000180785660-0x0000000180785990
	public static void ShowGiftQueue(List<GiftLine> lines, float hold = 0.75f /* Metadata: 0x005EFA49 */); // 0x0000000180785990-0x0000000180785C50
	private static bool GiftToastReady(); // 0x0000000180785C50-0x0000000180785E40
	public static void ShowThrottled(string message, float duration = 2f /* Metadata: 0x005EFA4D */, float minGap = 1f /* Metadata: 0x005EFA51 */); // 0x0000000180785E40-0x0000000180786010
}

