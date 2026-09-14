/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GameNotice // TypeDefIndex: 1392
{
	// Fields
	private static string _lastThrottledMsg; // 0x00
	private static float _lastThrottledAt; // 0x08

	// Nested types
	public struct GiftLine // TypeDefIndex: 1393
	{
		// Fields
		public string message; // 0x00
		public Sprite icon; // 0x08
		public string amount; // 0x10

		// Constructors
		public GiftLine(string message, Sprite icon, string amount); // 0x0000000180787FB0-0x00000001807880B0
	}

	// Constructors
	static GameNotice(); // 0x0000000180787F60-0x0000000180787FB0

	// Methods
	private static GameObject LoadPrefab(); // 0x0000000180786B60-0x0000000180786D90
	public static void Show(string message, float duration = 2.5f /* Metadata: 0x005F0E0E */); // 0x0000000180786D90-0x0000000180787040
	public static void ShowGift(string message, Sprite icon = null, string amount = null, float duration = 2.5f /* Metadata: 0x005F0E12 */); // 0x0000000180787040-0x0000000180787110
	public static void ShowGift(string message, Sprite icon, string amount, float duration, float offsetY); // 0x0000000180787110-0x00000001807871A0
	internal static PokyGiftToastView ShowGiftLine(string message, Sprite icon, string amount, float duration, float offsetY); // 0x00000001807871A0-0x00000001807875B0
	public static void ShowGuildHorn(string sender, string message); // 0x00000001807875B0-0x00000001807878E0
	public static void ShowGiftQueue(List<GiftLine> lines, float hold = 0.75f /* Metadata: 0x005F0E16 */); // 0x00000001807878E0-0x0000000180787BA0
	private static bool GiftToastReady(); // 0x0000000180787BA0-0x0000000180787D90
	public static void ShowThrottled(string message, float duration = 2f /* Metadata: 0x005F0E1A */, float minGap = 1f /* Metadata: 0x005F0E1E */); // 0x0000000180787D90-0x0000000180787F60
}

