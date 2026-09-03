/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class TextUtilities // TypeDefIndex: 4839
	{
		// Methods
		private static Vector2 PostProcessMeasuredSize(TextElement te, Vector2 measuredSize, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode, float pixelsPerPoint); // 0x00000001823D0E00-0x00000001823D0FB0
		internal static Vector2 MeasureVisualElementTextSize(TextElement te, string textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode, float? fontsize = default); // 0x00000001823D0C30-0x00000001823D0E00
		internal static Vector2 MeasureVisualElementTextSize(TextElement te, [IsReadOnly] in RenderedText textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode, float? fontsize = default); // 0x00000001823D0A70-0x00000001823D0C30
		internal static FontAsset GetFontAssetFromStyle_MainThreadOnly(VisualElement ve); // 0x00000001823D0240-0x00000001823D03C0
		internal static bool IsFontAssigned(VisualElement ve); // 0x00000001823D0970-0x00000001823D0A70
		internal static TextSettings GetTextSettingsFrom(VisualElement ve); // 0x00000001823D0850-0x00000001823D0940
		internal static bool IsAdvancedTextEnabledForElement(VisualElement ve); // 0x00000001823D0940-0x00000001823D0970
		internal static TextCoreSettings GetTextCoreSettingsForElement(TextElement te, bool ignoreColors); // 0x00000001823D03C0-0x00000001823D0850
	
		// Extension methods
		public static TextWrappingMode toTextWrappingMode(this WhiteSpace whiteSpace, bool isSingleLineInputField); // 0x00000001823D0FE0-0x00000001823D1030
		public static TextOverflow toTextCore(this TextOverflow textOverflow, OverflowInternal overflow, TextOverflowPosition position); // 0x00000001823D0FB0-0x00000001823D0FE0
	}
}
