/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class GameNotice // TypeDefIndex: 824
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/NoticeToast"; // Metadata: 0x0064C9A3
	public const string PREFAB_PATH_POKY = "Prefabs/UI/NoticeToast_Poky"; // Metadata: 0x0064C9BA
	public const string SKIN_KEY = "NoticeToast"; // Metadata: 0x0064C9D6
	public const string PREFAB_PATH_GIFT = "Prefabs/Poky/PokyGiftToast"; // Metadata: 0x0064C9E2
	public const string SKIN_KEY_GIFT = "GiftToast"; // Metadata: 0x0064C9FD
	private static string _lastThrottledMsg; // 0x00
	private static float _lastThrottledAt; // 0x08

	// Constructors
	static GameNotice(); // 0x00000001804268A0-0x00000001804268E0

	// Methods
	private static GameObject LoadPrefab(); // 0x00000001804260A0-0x0000000180426220
	public static void Show(string message, float duration = 2.5f /* Metadata: 0x0064C993 */); // 0x00000001804265D0-0x00000001804268A0
	public static void ShowGift(string message, Sprite icon = null, string amount = null, float duration = 2.5f /* Metadata: 0x0064C997 */); // 0x0000000180426220-0x00000001804264D0
	public static void ShowThrottled(string message, float duration = 2f /* Metadata: 0x0064C99B */, float minGap = 1f /* Metadata: 0x0064C99F */); // 0x00000001804264D0-0x00000001804265D0
}

