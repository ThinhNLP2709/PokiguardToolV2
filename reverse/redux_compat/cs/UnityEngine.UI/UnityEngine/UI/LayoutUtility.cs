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
	public static class LayoutUtility // TypeDefIndex: 13086
	{
		// Fields
		private static readonly Func<ILayoutElement, float> k_GetMinWidth; // 0x00
		private static readonly Func<ILayoutElement, float> k_GetMaxWidth; // 0x08
		private static readonly Func<ILayoutElement, float> k_GetPreferredWidth; // 0x10
		private static readonly Func<ILayoutElement, float> k_GetFlexibleWidth; // 0x18
		private static readonly Func<ILayoutElement, float> k_GetMinHeight; // 0x20
		private static readonly Func<ILayoutElement, float> k_GetMaxHeight; // 0x28
		private static readonly Func<ILayoutElement, float> k_GetPreferredHeight; // 0x30
		private static readonly Func<ILayoutElement, float> k_GetFlexibleHeight; // 0x38
		private static readonly Func<float, float, bool> k_GreaterThan; // 0x40
		private static readonly Func<float, float, bool> k_LessThan; // 0x48
		public const float DefaultMaxSize = 1F / 0F; // Metadata: 0x006A7769
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13087
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182597500-0x0000000182597570
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _.cctor_b__27_0(ILayoutElement e); // 0x00000001825971D0-0x0000000182597220
			internal float _.cctor_b__27_1(ILayoutElement e); // 0x0000000182597220-0x0000000182597270
			internal float _.cctor_b__27_2(ILayoutElement e); // 0x0000000182597270-0x00000001825972C0
			internal float _.cctor_b__27_3(ILayoutElement e); // 0x00000001825972C0-0x0000000182597310
			internal float _.cctor_b__27_4(ILayoutElement e); // 0x0000000182597310-0x0000000182597360
			internal float _.cctor_b__27_5(ILayoutElement e); // 0x0000000182597360-0x00000001825973B0
			internal float _.cctor_b__27_6(ILayoutElement e); // 0x00000001825973B0-0x0000000182597400
			internal float _.cctor_b__27_7(ILayoutElement e); // 0x0000000182597400-0x0000000182597450
			internal bool _.cctor_b__27_8(float a, float b); // 0x0000000182597450-0x0000000182597460
			internal bool _.cctor_b__27_9(float a, float b); // 0x0000000182597460-0x0000000182597470
		}
	
		// Constructors
		static LayoutUtility(); // 0x0000000182595800-0x0000000182595CB0
	
		// Methods
		public static float GetMinSize(RectTransform rect, int axis); // 0x0000000182595080-0x0000000182595190
		public static float GetMaxSize(RectTransform rect, int axis); // 0x0000000182594E50-0x0000000182594F80
		public static float GetPreferredSize(RectTransform rect, int axis); // 0x0000000182595650-0x0000000182595780
		public static float GetFlexibleSize(RectTransform rect, int axis); // 0x0000000182594770-0x0000000182594880
		public static float GetMinWidth(RectTransform rect); // 0x0000000182595190-0x0000000182595200
		public static float GetMaxWidth(RectTransform rect); // 0x0000000182594F80-0x0000000182595010
		public static float GetPreferredWidth(RectTransform rect); // 0x0000000182595780-0x0000000182595800
		public static float GetFlexibleWidth(RectTransform rect); // 0x0000000182594880-0x00000001825948F0
		public static float GetMinHeight(RectTransform rect); // 0x0000000182595010-0x0000000182595080
		public static float GetMaxHeight(RectTransform rect); // 0x0000000182594DC0-0x0000000182594E50
		public static float GetPreferredHeight(RectTransform rect); // 0x0000000182595200-0x0000000182595280
		public static float GetFlexibleHeight(RectTransform rect); // 0x0000000182594700-0x0000000182594770
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue); // 0x00000001825948F0-0x00000001825949D0
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue, out ILayoutElement source); // 0x0000000182594D20-0x0000000182594DC0
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, Func<float, float, bool> predicate, float defaultValue, out ILayoutElement source); // 0x00000001825949D0-0x0000000182594D20
		private static float GetPreferredLayoutProperty(RectTransform rect, Func<ILayoutElement, float> minProperty, Func<ILayoutElement, float> preferredProperty, Func<ILayoutElement, float> maxProperty, float defaultValue); // 0x0000000182595280-0x0000000182595650
	}
}
