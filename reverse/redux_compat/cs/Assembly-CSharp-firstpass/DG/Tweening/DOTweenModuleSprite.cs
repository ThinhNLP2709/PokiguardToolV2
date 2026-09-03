/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenModuleSprite // TypeDefIndex: 15127
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 15128
		{
			// Fields
			public SpriteRenderer target; // 0x10
	
			// Constructors
			public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Color _DOColor_b__0(); // 0x00000001802E5B60-0x00000001802E5BA0
			internal void _DOColor_b__1(Color x); // 0x00000001802E5BA0-0x00000001802E5BD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass1_0 // TypeDefIndex: 15129
		{
			// Fields
			public SpriteRenderer target; // 0x10
	
			// Constructors
			public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Color _DOFade_b__0(); // 0x00000001802E5B60-0x00000001802E5BA0
			internal void _DOFade_b__1(Color x); // 0x00000001802E5BA0-0x00000001802E5BD0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 15130
		{
			// Fields
			public Color to; // 0x10
			public SpriteRenderer target; // 0x20
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Color _DOBlendableColor_b__0(); // 0x00000001802E65B0-0x00000001802E65C0
			internal void _DOBlendableColor_b__1(Color x); // 0x00000001802E66E0-0x00000001802E67F0
		}
	
		// Extension methods
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this SpriteRenderer target, Color endValue, float duration); // 0x00000001802DE460-0x00000001802DE5D0
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this SpriteRenderer target, float endValue, float duration); // 0x00000001802DE5D0-0x00000001802DE730
		public static Sequence DOGradientColor(this SpriteRenderer target, Gradient gradient, float duration); // 0x00000001802DE730-0x00000001802DE930
		public static Tweener DOBlendableColor(this SpriteRenderer target, Color endValue, float duration); // 0x00000001802DE280-0x00000001802DE460
	}
}
