/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class DetailUserColumnLayout // TypeDefIndex: 2423
{
	// Nested types
	public struct Spec // TypeDefIndex: 2424
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
	public static void Apply(Image avatar, UnityEngine.UI.Text name, UnityEngine.UI.Text rank, UnityEngine.UI.Text total, UnityEngine.UI.Text attack, UnityEngine.UI.Text hp, UnityEngine.UI.Text mana, Spec s); // 0x0000000180B6DFD0-0x0000000180B6E600
	public static void PlaceGuildLine(UnityEngine.UI.Text total, Spec s); // 0x0000000180B6E600-0x0000000180B6EA50
	private static void Center(RectTransform rt); // 0x0000000180B6EA50-0x0000000180B6EAC0
	private static void PlaceText(UnityEngine.UI.Text t, RectTransform card, float k, Vector2 pos, Vector2 size, int maxSize); // 0x0000000180B6EAC0-0x0000000180B6EE80
	private static void PlaceStat(UnityEngine.UI.Text t, RectTransform card, float k, float colW, float y, int maxSize); // 0x0000000180B6EE80-0x0000000180B6F510
	private static void Fit(UnityEngine.UI.Text t, int maxSize, float k); // 0x0000000180B6F510-0x0000000180B6F6C0
}

