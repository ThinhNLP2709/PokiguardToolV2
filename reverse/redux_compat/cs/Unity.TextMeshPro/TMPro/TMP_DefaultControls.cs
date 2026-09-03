/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMP_DefaultControls // TypeDefIndex: 11801
	{
		// Fields
		private const float kWidth = 160f; // Metadata: 0x006A1F33
		private const float kThickHeight = 30f; // Metadata: 0x006A1F37
		private const float kThinHeight = 20f; // Metadata: 0x006A1F3B
		private static readonly Vector2 s_TextElementSize; // 0x00
		private static readonly Vector2 s_ThickElementSize; // 0x08
		private static readonly Vector2 s_ThinElementSize; // 0x10
		private static readonly Color s_DefaultSelectableColor; // 0x18
		private static readonly Color s_TextColor; // 0x28
	
		// Nested types
		public struct Resources // TypeDefIndex: 11802
		{
			// Fields
			public Sprite standard; // 0x00
			public Sprite background; // 0x08
			public Sprite inputField; // 0x10
			public Sprite knob; // 0x18
			public Sprite checkmark; // 0x20
			public Sprite dropdown; // 0x28
			public Sprite mask; // 0x30
		}
	
		// Constructors
		static TMP_DefaultControls(); // 0x0000000182071CC0-0x0000000182071D70
	
		// Methods
		private static GameObject CreateUIElementRoot(string name, Vector2 size); // 0x00000001820718A0-0x0000000182071940
		private static GameObject CreateUIObject(string name, GameObject parent); // 0x0000000182071940-0x0000000182071A00
		private static void SetDefaultTextValues(TMP_Text lbl); // 0x0000000182071A50-0x0000000182071AF0
		private static void SetDefaultColorTransitionValues(Selectable slider); // 0x0000000182071A00-0x0000000182071A50
		private static void SetParentAndAlign(GameObject child, GameObject parent); // 0x0000000182071BE0-0x0000000182071CC0
		private static void SetLayerRecursively(GameObject go, int layer); // 0x0000000182071AF0-0x0000000182071BE0
		public static GameObject CreateScrollbar(Resources resources); // 0x00000001820714B0-0x00000001820717F0
		public static GameObject CreateButton(Resources resources); // 0x000000018206F850-0x000000018206FBC0
		public static GameObject CreateText(Resources resources); // 0x00000001820717F0-0x00000001820718A0
		public static GameObject CreateInputField(Resources resources); // 0x0000000182070D50-0x00000001820714B0
		public static GameObject CreateDropdown(Resources resources); // 0x000000018206FBC0-0x0000000182070D50
		private static T AddComponent<T>(GameObject go)
			where T : Component;
	}
}
