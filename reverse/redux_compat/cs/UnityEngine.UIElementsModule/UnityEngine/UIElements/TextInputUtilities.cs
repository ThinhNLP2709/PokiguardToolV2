/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class TextInputUtilities // TypeDefIndex: 3904
	{
		// Methods
		internal static void UpdateScrollOffset(VisualElement self, TextElement textElement, ScrollView scrollView, ref Vector2 scrollOffset, ref bool scrollViewWasClamped, ref Vector2 lastCursorPos, bool isBackspace, bool widthChanged); // 0x00000001823AEE30-0x00000001823AF300
		private static Vector2 GetScrollOffset(VisualElement self, TextElement textElement, ScrollView scrollView, Vector2 scrollOffset, bool scrollViewWasClamped, ref Vector2 lastCursorPos, float xOffset, float yOffset, float contentViewportWidth, bool isBackspace, bool widthChanged); // 0x00000001823AE750-0x00000001823AEB20
		internal static void SetScrollViewMode(VisualElement self, TextElement textElement, ScrollView scrollView, UniqueStyleString verticalVariant, UniqueStyleString verticalHorizontalVariant, UniqueStyleString horizontalVariant); // 0x00000001823AECC0-0x00000001823AEE30
		internal static void SetMultilineContainerStyle(VisualElement self, VisualElement multilineContainer); // 0x00000001823AEB20-0x00000001823AECC0
	}
}
