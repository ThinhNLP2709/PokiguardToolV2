/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core.Easing
{
	public static class EaseManager // TypeDefIndex: 13532
	{
		// Fields
		private const float _PiOver2 = 1.5707964f; // Metadata: 0x006A7C20
		private const float _TwoPi = 6.2831855f; // Metadata: 0x006A7C24
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13533
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static EaseFunction __9__4_0; // 0x08
			public static EaseFunction __9__4_1; // 0x10
			public static EaseFunction __9__4_2; // 0x18
			public static EaseFunction __9__4_3; // 0x20
			public static EaseFunction __9__4_4; // 0x28
			public static EaseFunction __9__4_5; // 0x30
			public static EaseFunction __9__4_6; // 0x38
			public static EaseFunction __9__4_7; // 0x40
			public static EaseFunction __9__4_8; // 0x48
			public static EaseFunction __9__4_9; // 0x50
			public static EaseFunction __9__4_10; // 0x58
			public static EaseFunction __9__4_11; // 0x60
			public static EaseFunction __9__4_12; // 0x68
			public static EaseFunction __9__4_13; // 0x70
			public static EaseFunction __9__4_14; // 0x78
			public static EaseFunction __9__4_15; // 0x80
			public static EaseFunction __9__4_16; // 0x88
			public static EaseFunction __9__4_17; // 0x90
			public static EaseFunction __9__4_18; // 0x98
			public static EaseFunction __9__4_19; // 0xA0
			public static EaseFunction __9__4_20; // 0xA8
			public static EaseFunction __9__4_21; // 0xB0
			public static EaseFunction __9__4_22; // 0xB8
			public static EaseFunction __9__4_23; // 0xC0
			public static EaseFunction __9__4_24; // 0xC8
			public static EaseFunction __9__4_25; // 0xD0
			public static EaseFunction __9__4_26; // 0xD8
			public static EaseFunction __9__4_27; // 0xE0
			public static EaseFunction __9__4_28; // 0xE8
			public static EaseFunction __9__4_29; // 0xF0
			public static EaseFunction __9__4_30; // 0xF8
			public static EaseFunction __9__4_31; // 0x100
			public static EaseFunction __9__4_32; // 0x108
			public static EaseFunction __9__4_33; // 0x110
			public static EaseFunction __9__4_34; // 0x118
			public static EaseFunction __9__4_35; // 0x120
	
			// Constructors
			static __c(); // 0x00000001807396B0-0x0000000180739720
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _ToEaseFunction_b__4_0(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738640-0x0000000180738650
			internal float _ToEaseFunction_b__4_1(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738AA0-0x0000000180738B20
			internal float _ToEaseFunction_b__4_2(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807393D0-0x0000000180739440
			internal float _ToEaseFunction_b__4_3(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739550-0x00000001807395D0
			internal float _ToEaseFunction_b__4_4(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807395D0-0x00000001807395E0
			internal float _ToEaseFunction_b__4_5(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739530-0x0000000180739550
			internal float _ToEaseFunction_b__4_6(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807395E0-0x0000000180739630
			internal float _ToEaseFunction_b__4_7(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739630-0x0000000180739640
			internal float _ToEaseFunction_b__4_8(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739640-0x0000000180739660
			internal float _ToEaseFunction_b__4_9(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739660-0x00000001807396B0
			internal float _ToEaseFunction_b__4_10(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738650-0x0000000180738670
			internal float _ToEaseFunction_b__4_11(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738670-0x00000001807386A0
			internal float _ToEaseFunction_b__4_12(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807386A0-0x0000000180738700
			internal float _ToEaseFunction_b__4_13(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738700-0x0000000180738720
			internal float _ToEaseFunction_b__4_14(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738720-0x0000000180738750
			internal float _ToEaseFunction_b__4_15(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738750-0x00000001807387B0
			internal float _ToEaseFunction_b__4_16(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807387B0-0x0000000180738840
			internal float _ToEaseFunction_b__4_17(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738840-0x00000001807388F0
			internal float _ToEaseFunction_b__4_18(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807388F0-0x0000000180738A00
			internal float _ToEaseFunction_b__4_19(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738A00-0x0000000180738AA0
			internal float _ToEaseFunction_b__4_20(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738B20-0x0000000180738BC0
			internal float _ToEaseFunction_b__4_21(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738BC0-0x0000000180738CC0
			internal float _ToEaseFunction_b__4_22(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738CC0-0x0000000180738E70
			internal float _ToEaseFunction_b__4_23(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180738E70-0x0000000180739030
			internal float _ToEaseFunction_b__4_24(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739030-0x00000001807392B0
			internal float _ToEaseFunction_b__4_25(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807392B0-0x00000001807392D0
			internal float _ToEaseFunction_b__4_26(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807392D0-0x0000000180739300
			internal float _ToEaseFunction_b__4_27(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739300-0x0000000180739370
			internal float _ToEaseFunction_b__4_28(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739370-0x00000001807393A0
			internal float _ToEaseFunction_b__4_29(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807393A0-0x00000001807393D0
			internal float _ToEaseFunction_b__4_30(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739440-0x0000000180739470
			internal float _ToEaseFunction_b__4_31(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739470-0x00000001807394A0
			internal float _ToEaseFunction_b__4_32(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807394A0-0x00000001807394D0
			internal float _ToEaseFunction_b__4_33(float time, float duration, float overshootOrAmplitude, float period); // 0x00000001807394D0-0x0000000180739500
			internal float _ToEaseFunction_b__4_34(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739500-0x0000000180739530
			internal float _ToEaseFunction_b__4_35(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180739530-0x0000000180739550
		}
	
		// Methods
		public static float Evaluate(Tween t, float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180731060-0x00000001807310B0
		public static float Evaluate(Ease easeType, EaseFunction customEase, float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180730270-0x0000000180731060
		public static EaseFunction ToEaseFunction(Ease ease); // 0x00000001807310C0-0x0000000180732630
		internal static bool IsFlashEase(Ease ease); // 0x00000001807310B0-0x00000001807310C0
	}
}
