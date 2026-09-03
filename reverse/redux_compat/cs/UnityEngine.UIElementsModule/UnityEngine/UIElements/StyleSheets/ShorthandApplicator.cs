/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules]
	internal static class ShorthandApplicator // TypeDefIndex: 5221
	{
		// Fields
		private static List<TimeValue> s_TransitionDelayList; // 0x00
		private static List<TimeValue> s_TransitionDurationList; // 0x08
		private static List<StylePropertyName> s_TransitionPropertyList; // 0x10
		private static List<EasingFunction> s_TransitionTimingFunctionList; // 0x18
	
		// Constructors
		static ShorthandApplicator(); // 0x0000000182453660-0x0000000182453800
	
		// Methods
		public static void ApplyBackgroundPosition(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x00000001824509E0-0x0000000182450AE0
		public static void ApplyBorderColor(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182450AE0-0x0000000182450C10
		public static void ApplyBorderRadius(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182450C10-0x0000000182450E10
		public static void ApplyBorderWidth(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182450E10-0x0000000182450F80
		public static void ApplyFlex(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182450F80-0x00000001824510B0
		public static void ApplyGap(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x00000001824510B0-0x00000001824511F0
		public static void ApplyMargin(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x00000001824511F0-0x0000000182451440
		public static void ApplyPadding(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182451440-0x0000000182451690
		public static void ApplyUnityBackgroundScaleMode(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182451750-0x00000001824518F0
		public static void ApplyUnityTextOutline(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x00000001824518F0-0x0000000182451A90
		private static bool CompileFlexShorthand(StylePropertyReader reader, out float grow, out float shrink, out Length basis); // 0x00000001824529C0-0x0000000182452C30
		private static void CompileBorderRadius(StylePropertyReader reader, out Length top, out Length right, out Length bottom, out Length left); // 0x0000000182452390-0x00000001824524D0
		private static void CompileBackgroundPosition(StylePropertyReader reader, out BackgroundPosition backgroundPositionX, out BackgroundPosition backgroundPositionY); // 0x0000000182451A90-0x00000001824521A0
		public static void CompileUnityBackgroundScaleMode(StylePropertyReader reader, out BackgroundPosition backgroundPositionX, out BackgroundPosition backgroundPositionY, out BackgroundRepeat backgroundRepeat, out BackgroundSize backgroundSize); // 0x00000001824535A0-0x0000000182453660
		private static void CompileGap(StylePropertyReader reader, out Length rowGap, out Length columnGap); // 0x0000000182452C30-0x0000000182452CD0
		private static void CompileBoxArea(StylePropertyReader reader, out Length top, out Length right, out Length bottom, out Length left); // 0x0000000182452850-0x00000001824529C0
		private static void CompileBorderBoxArea(StylePropertyReader reader, out float top, out float right, out float bottom, out float left); // 0x00000001824521A0-0x0000000182452390
		private static void CompileBoxArea(StylePropertyReader reader, out Color top, out Color right, out Color bottom, out Color left); // 0x00000001824524D0-0x0000000182452850
		private static void CompileTextOutline(StylePropertyReader reader, out Color outlineColor, out float outlineWidth); // 0x0000000182452CD0-0x0000000182452DD0
		public static void ApplyTransition(StylePropertyReader reader, ref ComputedStyle computedStyle); // 0x0000000182451690-0x0000000182451750
		private static void CompileTransition(StylePropertyReader reader, ref UnmanagedRefCountedList<TimeValue> outDelay, ref UnmanagedRefCountedList<TimeValue> outDuration, ref UnmanagedRefCountedList<StylePropertyId> outProperty, ref UnmanagedRefCountedList<EasingFunction> outTimingFunction); // 0x0000000182452DD0-0x00000001824535A0
		[CompilerGenerated]
		internal static void _CompileBackgroundPosition_g__SwapKeyword_16_0(ref BackgroundPositionKeyword a, ref BackgroundPositionKeyword b); // 0x0000000180CC7CF0-0x0000000180CC7D00
	}
}
