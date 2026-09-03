/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Audio;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenModuleAudio // TypeDefIndex: 15101
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 15102
		{
			// Fields
			public AudioSource target; // 0x10
	
			// Constructors
			public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _DOFade_b__0(); // 0x00000001802E5BF0-0x00000001802E5C10
			internal void _DOFade_b__1(float x); // 0x00000001802E5C10-0x00000001802E5C30
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass1_0 // TypeDefIndex: 15103
		{
			// Fields
			public AudioSource target; // 0x10
	
			// Constructors
			public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _DOPitch_b__0(); // 0x00000001802E5FF0-0x00000001802E6010
			internal void _DOPitch_b__1(float x); // 0x00000001802E6010-0x00000001802E6030
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 15104
		{
			// Fields
			public AudioMixer target; // 0x10
			public string floatName; // 0x18
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _DOSetFloat_b__0(); // 0x00000001802E62C0-0x00000001802E6300
			internal void _DOSetFloat_b__1(float x); // 0x00000001802E6300-0x00000001802E6330
		}
	
		// Extension methods
		public static TweenerCore<float, float, FloatOptions> DOFade(this AudioSource target, float endValue, float duration); // 0x00000001802DB0C0-0x00000001802DB240
		public static TweenerCore<float, float, FloatOptions> DOPitch(this AudioSource target, float endValue, float duration); // 0x00000001802DB3B0-0x00000001802DB510
		public static TweenerCore<float, float, FloatOptions> DOSetFloat(this AudioMixer target, string floatName, float endValue, float duration); // 0x00000001802DB6B0-0x00000001802DB820
		public static int DOComplete(this AudioMixer target, bool withCallbacks = false /* Metadata: 0x006A9E83 */); // 0x00000001802DB060-0x00000001802DB0C0
		public static int DOKill(this AudioMixer target, bool complete = false /* Metadata: 0x006A9E84 */); // 0x00000001802DB300-0x00000001802DB360
		public static int DOFlip(this AudioMixer target); // 0x00000001802DB240-0x00000001802DB290
		public static int DOGoto(this AudioMixer target, float to, bool andPlay = false /* Metadata: 0x006A9E85 */); // 0x00000001802DB290-0x00000001802DB300
		public static int DOPause(this AudioMixer target); // 0x00000001802DB360-0x00000001802DB3B0
		public static int DOPlay(this AudioMixer target); // 0x00000001802DB5B0-0x00000001802DB600
		public static int DOPlayBackwards(this AudioMixer target); // 0x00000001802DB510-0x00000001802DB560
		public static int DOPlayForward(this AudioMixer target); // 0x00000001802DB560-0x00000001802DB5B0
		public static int DORestart(this AudioMixer target); // 0x00000001802DB600-0x00000001802DB660
		public static int DORewind(this AudioMixer target); // 0x00000001802DB660-0x00000001802DB6B0
		public static int DOSmoothRewind(this AudioMixer target); // 0x00000001802DB820-0x00000001802DB870
		public static int DOTogglePause(this AudioMixer target); // 0x00000001802DB870-0x00000001802DB8C0
	}
}
