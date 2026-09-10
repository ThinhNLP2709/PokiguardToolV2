/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GameNotice // TypeDefIndex: 1019
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/NoticeToast"; // Metadata: 0x0068C079
	public const string PREFAB_PATH_POKY = "Prefabs/UI/NoticeToast_Poky"; // Metadata: 0x0068C090
	public const string SKIN_KEY = "NoticeToast"; // Metadata: 0x0068C0AC
	public const string PREFAB_PATH_GIFT = "Prefabs/Poky/PokyGiftToast"; // Metadata: 0x0068C0B8
	public const string SKIN_KEY_GIFT = "GiftToast"; // Metadata: 0x0068C0D3
	private static string _lastThrottledMsg; // 0x00
	private static float _lastThrottledAt; // 0x08

	// Constructors
	static GameNotice(); // 0x00000001804FC010-0x00000001804FC050

	// Methods
	private static GameObject LoadPrefab(); // 0x00000001804FB810-0x00000001804FB990
	public static void Show(string message, float duration = 2.5f /* Metadata: 0x0068C069 */); // 0x00000001804FBD40-0x00000001804FC010
	public static void ShowGift(string message, Sprite icon = null, string amount = null, float duration = 2.5f /* Metadata: 0x0068C06D */); // 0x00000001804FB990-0x00000001804FBC40
	public static void ShowThrottled(string message, float duration = 2f /* Metadata: 0x0068C071 */, float minGap = 1f /* Metadata: 0x0068C075 */); // 0x00000001804FBC40-0x00000001804FBD40
}

