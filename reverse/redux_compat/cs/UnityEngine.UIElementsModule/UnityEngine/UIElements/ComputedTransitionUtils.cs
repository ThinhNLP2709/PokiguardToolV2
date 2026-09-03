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
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class ComputedTransitionUtils // TypeDefIndex: 4368
	{
		// Fields
		private static readonly ComputedTransitionProperty[] k_EmptyTransitions; // 0x00
		private static List<ComputedTransitionProperty> s_ComputedTransitionsBuffer; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4369
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<float, float> __9__13_0; // 0x08
			public static Func<float, float> __9__13_1; // 0x10
			public static Func<float, float> __9__13_2; // 0x18
			public static Func<float, float> __9__13_3; // 0x20
			public static Func<float, float> __9__13_4; // 0x28
			public static Func<float, float> __9__13_5; // 0x30
			public static Func<float, float> __9__13_6; // 0x38
			public static Func<float, float> __9__13_7; // 0x40
			public static Func<float, float> __9__13_8; // 0x48
			public static Func<float, float> __9__13_9; // 0x50
			public static Func<float, float> __9__13_10; // 0x58
			public static Func<float, float> __9__13_11; // 0x60
			public static Func<float, float> __9__13_12; // 0x68
			public static Func<float, float> __9__13_13; // 0x70
			public static Func<float, float> __9__13_14; // 0x78
			public static Func<float, float> __9__13_15; // 0x80
			public static Func<float, float> __9__13_16; // 0x88
			public static Func<float, float> __9__13_17; // 0x90
			public static Func<float, float> __9__13_18; // 0x98
			public static Func<float, float> __9__13_19; // 0xA0
			public static Func<float, float> __9__13_20; // 0xA8
			public static Func<float, float> __9__13_21; // 0xB0
			public static Func<float, float> __9__13_22; // 0xB8
	
			// Constructors
			static __c(); // 0x000000018253E400-0x000000018253E470
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _ConvertTransitionFunction_b__13_0(float t); // 0x000000018253E270-0x000000018253E2A0
			internal float _ConvertTransitionFunction_b__13_1(float t); // 0x000000018253E340-0x000000018253E350
			internal float _ConvertTransitionFunction_b__13_2(float t); // 0x000000018253E380-0x000000018253E390
			internal float _ConvertTransitionFunction_b__13_3(float t); // 0x000000018253E390-0x000000018253E3A0
			internal float _ConvertTransitionFunction_b__13_4(float t); // 0x000000018253E3A0-0x000000018253E3B0
			internal float _ConvertTransitionFunction_b__13_5(float t); // 0x000000018253E3B0-0x000000018253E3C0
			internal float _ConvertTransitionFunction_b__13_6(float t); // 0x000000018253E3C0-0x000000018253E3D0
			internal float _ConvertTransitionFunction_b__13_7(float t); // 0x000000018253E3D0-0x000000018253E3E0
			internal float _ConvertTransitionFunction_b__13_8(float t); // 0x000000018253E3E0-0x000000018253E3F0
			internal float _ConvertTransitionFunction_b__13_9(float t); // 0x000000018253E3F0-0x000000018253E400
			internal float _ConvertTransitionFunction_b__13_10(float t); // 0x000000018253E2A0-0x000000018253E2B0
			internal float _ConvertTransitionFunction_b__13_11(float t); // 0x000000018253E2B0-0x000000018253E2C0
			internal float _ConvertTransitionFunction_b__13_12(float t); // 0x000000018253E2C0-0x000000018253E2D0
			internal float _ConvertTransitionFunction_b__13_13(float t); // 0x000000018253E2D0-0x000000018253E2E0
			internal float _ConvertTransitionFunction_b__13_14(float t); // 0x000000018253E2E0-0x000000018253E2F0
			internal float _ConvertTransitionFunction_b__13_15(float t); // 0x000000018253E2F0-0x000000018253E300
			internal float _ConvertTransitionFunction_b__13_16(float t); // 0x000000018253E300-0x000000018253E310
			internal float _ConvertTransitionFunction_b__13_17(float t); // 0x000000018253E310-0x000000018253E320
			internal float _ConvertTransitionFunction_b__13_18(float t); // 0x000000018253E320-0x000000018253E330
			internal float _ConvertTransitionFunction_b__13_19(float t); // 0x000000018253E330-0x000000018253E340
			internal float _ConvertTransitionFunction_b__13_20(float t); // 0x000000018253E350-0x000000018253E360
			internal float _ConvertTransitionFunction_b__13_21(float t); // 0x000000018253E360-0x000000018253E370
			internal float _ConvertTransitionFunction_b__13_22(float t); // 0x000000018253E370-0x000000018253E380
		}
	
		// Constructors
		static ComputedTransitionUtils(); // 0x00000001825235B0-0x00000001825236B0
	
		// Methods
		internal static void UpdateComputedTransitions(ref ComputedStyle computedStyle, out ComputedTransitionProperty[] computedTransitions); // 0x0000000182523370-0x00000001825235B0
		private static ComputedTransitionProperty[] GetOrComputeTransitionPropertyData(ref ComputedStyle computedStyle); // 0x0000000182522940-0x0000000182522AB0
		private static int GetTransitionHashCode(ref ComputedStyle cs); // 0x0000000182522AB0-0x0000000182522CE0
		internal static bool SameTransitionProperty(ref ComputedStyle x, ref ComputedStyle y); // 0x0000000182522FC0-0x00000001825232B0
		private static bool SameTransitionProperty(ReadOnlySpan<StylePropertyId> a, ReadOnlySpan<StylePropertyId> b); // 0x0000000182522F10-0x0000000182522FC0
		private static bool SameTransitionProperty(ReadOnlySpan<TimeValue> a, ReadOnlySpan<TimeValue> b); // 0x00000001825232B0-0x0000000182523370
		private static void ComputeTransitionPropertyData(ref ComputedStyle computedStyle, List<ComputedTransitionProperty> outData); // 0x0000000182521720-0x0000000182521A80
		private static T GetWrappingTransitionData<T>(ReadOnlySpan<T> list, int i, T defaultValue)
			where T : struct;
		private static int ConvertTransitionTime(TimeValue time); // 0x0000000182522820-0x0000000182522940
		private static Func<float, float> ConvertTransitionFunction(EasingMode mode); // 0x0000000182521A80-0x0000000182522820
	
		// Extension methods
		internal static bool HasTransitionProperty(this ComputedTransitionProperty[] computedTransitions, StylePropertyId id); // 0x0000000182522E20-0x0000000182522F10
		internal static bool GetTransitionProperty(this ComputedTransitionProperty[] computedTransitions, StylePropertyId id, out ComputedTransitionProperty result); // 0x0000000182522CE0-0x0000000182522E20
	}
}
