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
	public static class DOVirtual // TypeDefIndex: 13349
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 13350
		{
			// Fields
			public float val; // 0x10
			public TweenCallback<float> onVirtualUpdate; // 0x18
	
			// Constructors
			public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _Float_b__0(); // 0x00000001807187E0-0x00000001807187F0
			internal void _Float_b__1(float x); // 0x00000001807187F0-0x0000000180718800
			internal void _Float_b__2(); // 0x0000000180718800-0x0000000180718830
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass1_0 // TypeDefIndex: 13351
		{
			// Fields
			public int val; // 0x10
			public TweenCallback<int> onVirtualUpdate; // 0x18
	
			// Constructors
			public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Int_b__0(); // 0x00000001802E64B0-0x00000001802E64C0
			internal void _Int_b__1(int x); // 0x00000001805D5560-0x00000001805D5570
			internal void _Int_b__2(); // 0x0000000180718C50-0x0000000180718C80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 13352
		{
			// Fields
			public Vector2 val; // 0x10
			public TweenCallback<Vector2> onVirtualUpdate; // 0x18
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _Vector2_b__0(); // 0x0000000180719040-0x0000000180719060
			internal void _Vector2_b__1(Vector2 x); // 0x0000000180719060-0x0000000180719070
			internal void _Vector2_b__2(); // 0x0000000180719070-0x00000001807190B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 13353
		{
			// Fields
			public Vector3 val; // 0x10
			public TweenCallback<Vector3> onVirtualUpdate; // 0x20
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _Vector3_b__0(); // 0x0000000180719290-0x00000001807192B0
			internal void _Vector3_b__1(Vector3 x); // 0x00000001807192B0-0x00000001807192C0
			internal void _Vector3_b__2(); // 0x00000001807192C0-0x0000000180719300
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 13354
		{
			// Fields
			public Color val; // 0x10
			public TweenCallback<Color> onVirtualUpdate; // 0x20
	
			// Constructors
			public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Color _Color_b__0(); // 0x00000001802E65B0-0x00000001802E65C0
			internal void _Color_b__1(Color x); // 0x00000001806F7670-0x00000001806F7680
			internal void _Color_b__2(); // 0x0000000180719460-0x00000001807194A0
		}
	
		// Methods
		public static Tweener Float(float from, float to, float duration, TweenCallback<float> onVirtualUpdate); // 0x0000000180706820-0x00000001807069D0
		public static Tweener Int(int from, int to, float duration, TweenCallback<int> onVirtualUpdate); // 0x00000001807069D0-0x0000000180706BC0
		public static Tweener Vector2(Vector2 from, Vector2 to, float duration, TweenCallback<Vector2> onVirtualUpdate); // 0x0000000180706BC0-0x0000000180706D80
		public static Tweener Vector3(Vector3 from, Vector3 to, float duration, TweenCallback<Vector3> onVirtualUpdate); // 0x0000000180706D80-0x0000000180706F90
		public static Tweener Color(Color from, Color to, float duration, TweenCallback<Color> onVirtualUpdate); // 0x0000000180705D00-0x0000000180705F00
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType); // 0x0000000180706200-0x00000001807062C0
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float overshoot); // 0x0000000180706400-0x00000001807064C0
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float amplitude, float period); // 0x00000001807067B0-0x0000000180706820
		public static float EasedValue(float from, float to, float lifetimePercentage, AnimationCurve easeCurve); // 0x00000001807060D0-0x0000000180706200
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType); // 0x0000000180706670-0x00000001807067B0
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float overshoot); // 0x00000001807062C0-0x0000000180706400
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float amplitude, float period); // 0x0000000180705FF0-0x00000001807060D0
		public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, AnimationCurve easeCurve); // 0x00000001807064C0-0x0000000180706670
		public static Tween DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true /* Metadata: 0x006A797A */); // 0x0000000180705F00-0x0000000180705FF0
	}
}
