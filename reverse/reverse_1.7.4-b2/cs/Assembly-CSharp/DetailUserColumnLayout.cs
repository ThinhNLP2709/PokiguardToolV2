/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class DetailUserColumnLayout // TypeDefIndex: 2022
{
	// Fields
	private const float NAME_H = 46f; // Metadata: 0x0068DE78
	private const float RANK_H = 20f; // Metadata: 0x0068DE7C
	private const float ROW_H = 22f; // Metadata: 0x0068DE80
	private const float STAT_H = 22f; // Metadata: 0x0068DE84
	private const float STAT_GAP = 2f; // Metadata: 0x0068DE88
	private const float ICON = 20f; // Metadata: 0x0068DE8C
	private const float GAP = 3f; // Metadata: 0x0068DE90
	private const float CARD_GAP_TOP = 3f; // Metadata: 0x0068DE94
	private const float CARD_GAP_BOTTOM = 5f; // Metadata: 0x0068DE98

	// Nested types
	public struct Spec // TypeDefIndex: 2023
	{
		// Fields
		public float colX; // 0x00
		public float colW; // 0x04
		public float cardY; // 0x08
		public float cardScale; // 0x0C
		public int nameMaxSize; // 0x10
		public int rankMaxSize; // 0x14
		public int rowMaxSize; // 0x18
		public int statMaxSize; // 0x1C
	}

	// Methods
	public static float StackHeight(float cardH); // 0x00000001807143D0-0x0000000180714410
	public static void Apply(Image avatar, UnityEngine.UI.Text name, UnityEngine.UI.Text rank, UnityEngine.UI.Text total, UnityEngine.UI.Text attack, UnityEngine.UI.Text hp, UnityEngine.UI.Text mana, Spec s); // 0x0000000180713710-0x0000000180713B40
	public static void PlaceGuildLine(UnityEngine.UI.Text total, Spec s); // 0x0000000180713C40-0x0000000180713E70
	private static void Center(RectTransform rt); // 0x0000000180713B40-0x0000000180713BB0
	private static void PlaceText(UnityEngine.UI.Text t, RectTransform card, float k, Vector2 pos, Vector2 size, int maxSize); // 0x00000001807141F0-0x00000001807143D0
	private static void PlaceStat(UnityEngine.UI.Text t, RectTransform card, float k, float colW, float y, int maxSize); // 0x0000000180713E70-0x00000001807141F0
	private static void Fit(UnityEngine.UI.Text t, int maxSize, float k); // 0x0000000180713BB0-0x0000000180713C40
}

