/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public static class DefaultControls // TypeDefIndex: 13022
	{
		// Fields
		private static IFactoryControls m_CurrentFactory; // 0x00
		private const float kWidth = 160f; // Metadata: 0x006A76D3
		private const float kThickHeight = 30f; // Metadata: 0x006A76D7
		private const float kThinHeight = 20f; // Metadata: 0x006A76DB
		private static readonly Vector2 s_ThickElementSize; // 0x08
		private static readonly Vector2 s_ThinElementSize; // 0x10
		private static readonly Vector2 s_ImageElementSize; // 0x18
		private static readonly Color s_DefaultSelectableColor; // 0x20
		private static readonly Color s_PanelColor; // 0x30
		private static readonly Color s_TextColor; // 0x40
	
		// Properties
		public static IFactoryControls factory { get; } // 0x0000000182367B40-0x0000000182367B90 
	
		// Nested types
		public interface IFactoryControls // TypeDefIndex: 13023
		{
			// Methods
			GameObject CreateGameObject(string name, params Type[] components);
		}
	
		private class DefaultRuntimeFactory : IFactoryControls // TypeDefIndex: 13024
		{
			// Fields
			public static readonly IFactoryControls Default; // 0x00
	
			// Constructors
			public DefaultRuntimeFactory(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static DefaultRuntimeFactory(); // 0x0000000182367C00-0x0000000182367C70
	
			// Methods
			public GameObject CreateGameObject(string name, params Type[] components); // 0x0000000182367B90-0x0000000182367C00
		}
	
		public struct Resources // TypeDefIndex: 13025
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
		static DefaultControls(); // 0x0000000182367A20-0x0000000182367B40
	
		// Methods
		private static GameObject CreateUIElementRoot(string name, Vector2 size, params Type[] components); // 0x0000000182367510-0x0000000182367630
		private static GameObject CreateUIObject(string name, GameObject parent, params Type[] components); // 0x0000000182367630-0x0000000182367720
		private static void SetDefaultTextValues(Text lbl); // 0x0000000182367770-0x0000000182367850
		private static void SetDefaultColorTransitionValues(Selectable slider); // 0x0000000182367720-0x0000000182367770
		private static void SetParentAndAlign(GameObject child, GameObject parent); // 0x0000000182367940-0x0000000182367A20
		private static void SetLayerRecursively(GameObject go, int layer); // 0x0000000182367850-0x0000000182367940
		public static GameObject CreatePanel(Resources resources); // 0x0000000182364D80-0x0000000182365080
		public static GameObject CreateButton(Resources resources); // 0x0000000182362930-0x0000000182362DC0
		public static GameObject CreateText(Resources resources); // 0x0000000182366C30-0x0000000182366DE0
		public static GameObject CreateImage(Resources resources); // 0x00000001823644E0-0x0000000182364620
		public static GameObject CreateRawImage(Resources resources); // 0x0000000182365080-0x00000001823651C0
		public static GameObject CreateSlider(Resources resources); // 0x00000001823662D0-0x0000000182366C30
		public static GameObject CreateScrollbar(Resources resources); // 0x0000000182365CF0-0x00000001823662D0
		public static GameObject CreateToggle(Resources resources); // 0x0000000182366DE0-0x0000000182367510
		public static GameObject CreateInputField(Resources resources); // 0x0000000182364620-0x0000000182364D80
		public static GameObject CreateDropdown(Resources resources); // 0x0000000182362DC0-0x00000001823644E0
		public static GameObject CreateScrollView(Resources resources); // 0x0000000182365300-0x0000000182365CF0
		public static GameObject CreateRaycastReceiver(Resources resources); // 0x00000001823651C0-0x0000000182365300
	}
}
