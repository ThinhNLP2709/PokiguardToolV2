/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening
{
	public class EaseFactory // TypeDefIndex: 13356
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 13357
		{
			// Fields
			public float motionDelay; // 0x10
			public EaseFunction customEase; // 0x18
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _StopMotion_b__0(float time, float duration, float overshootOrAmplitude, float period); // 0x0000000180718FC0-0x0000000180719040
		}
	
		// Constructors
		public EaseFactory(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static EaseFunction StopMotion(int motionFps, Ease? ease = default); // 0x0000000180707060-0x00000001807070F0
		public static EaseFunction StopMotion(int motionFps, AnimationCurve animCurve); // 0x00000001807070F0-0x00000001807071A0
		public static EaseFunction StopMotion(int motionFps, EaseFunction customEase); // 0x0000000180706F90-0x0000000180707060
	}
}
