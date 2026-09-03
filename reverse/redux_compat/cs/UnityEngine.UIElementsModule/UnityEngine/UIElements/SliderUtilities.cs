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
	internal static class SliderUtilities // TypeDefIndex: 3922
	{
		// Methods
		private static bool SameValues(float a, float b, float epsilon); // 0x00000001823AC440-0x00000001823AC460
		internal static void UpdateDragElementPosition(VisualElement slider, VisualElement dragContainer, VisualElement dragElement, VisualElement dragBorderElement, VisualElement trackElement, ref VisualElement fillElement, UniqueStyleString fillUssClassNameUnique, float normalizedPosition, SliderDirection direction, bool inverted, bool fill, ref float adjustedPageSizeFromClick); // 0x00000001823AC460-0x00000001823AC8C0
		private static void UpdateFill(ref VisualElement fillElement, VisualElement trackElement, float normalizedValue, SliderDirection direction, bool inverted, bool fill, UniqueStyleString fillUssClassNameUnique); // 0x00000001823AC8C0-0x00000001823AD000
		internal static void AdjustDragElement(VisualElement slider, VisualElement dragContainer, VisualElement dragElement, VisualElement dragBorderElement, float factor, SliderDirection direction); // 0x00000001823AC010-0x00000001823AC440
	}
}
