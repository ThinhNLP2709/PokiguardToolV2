/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.Avatar
{
	public static class AvatarCompositeBinder // TypeDefIndex: 2905
	{
		// Fields
		private static readonly Dictionary<object, State> _states; // 0x00
		private static int _sinceSweep; // 0x08
	
		// Properties
		private static bool FxOn { get; } // 0x0000000180D48950-0x0000000180D489C0 
	
		// Nested types
		private sealed class State // TypeDefIndex: 2906
		{
			// Fields
			public int token; // 0x10
			public int fadeTween; // 0x14
			public float baseAlpha; // 0x18
			public bool popping; // 0x1C
			public Vector3 popBase; // 0x20
			public string requestedLayers; // 0x30
			public Sprite appliedSprite; // 0x38
			public Texture appliedTexture; // 0x40
	
			// Constructors
			public State(); // 0x0000000180D4BBC0-0x0000000180D4BBF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0 // TypeDefIndex: 2907
		{
			// Fields
			public State st; // 0x10
			public Action<float> setAlpha; // 0x18
			public float targetAlpha; // 0x20
	
			// Constructors
			public __c__DisplayClass17_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fade_b__0(); // 0x0000000180D4BBF0-0x0000000180D4BC30
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2908
		{
			// Fields
			public GameObject go; // 0x10
			public State st; // 0x18
			public float half; // 0x20
			public Action __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Pop_b__0(); // 0x0000000180D4BC30-0x0000000180D4BEA0
			internal void _Pop_b__1(); // 0x0000000180D4BEA0-0x0000000180D4C040
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 2909
		{
			// Fields
			public Image img; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public bool popFx; // 0x24
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D4C040-0x0000000180D4C3E0
			internal void _Bind_b__1(float a); // 0x0000000180D4C3E0-0x0000000180D4C580
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2910
		{
			// Fields
			public RawImage raw; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D4C580-0x0000000180D4C960
			internal void _Bind_b__1(float a); // 0x0000000180D4C960-0x0000000180D4CB00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2911
		{
			// Fields
			public SpriteRenderer sr; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public bool popFx; // 0x24
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D4CB00-0x0000000180D4CF20
			internal void _Bind_b__1(float a); // 0x0000000180D4CF20-0x0000000180D4D050
		}
	
		// Constructors
		static AvatarCompositeBinder(); // 0x0000000180D4BAA0-0x0000000180D4BBC0
	
		// Methods
		public static void Bind(Image img, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x005F3688 */); // 0x0000000180D489C0-0x0000000180D48E90
		public static void Bind(RawImage raw, string layers, Texture legacyFallback); // 0x0000000180D48E90-0x0000000180D49340
		public static void Bind(SpriteRenderer sr, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x005F3689 */); // 0x0000000180D49340-0x0000000180D49870
		public static void Unbind(Component target); // 0x0000000180D49870-0x0000000180D49B10
		private static bool SameAsApplied(State st, string layers, UnityEngine.Object current); // 0x0000000180D49B10-0x0000000180D49D60
		private static bool HoldsComposite(State st, UnityEngine.Object current); // 0x0000000180D49D60-0x0000000180D49F20
		private static void ClearApplied(State st); // 0x0000000180D49F20-0x0000000180D4A040
		private static bool Ready(string layers); // 0x0000000180D4A040-0x0000000180D4A080
		private static State StateOf(object target); // 0x0000000180D4A080-0x0000000180D4A200
		private static void Sweep(); // 0x0000000180D4A200-0x0000000180D4A5B0
		private static Rect UvRectOf(Sprite sprite); // 0x0000000180D4A5B0-0x0000000180D4A890
		private static void Fade(GameObject go, State st, Action<float> setAlpha, float currentAlpha); // 0x0000000180D4A890-0x0000000180D4ACF0
		private static void Pop(GameObject go, State st, bool popFx); // 0x0000000180D4ACF0-0x0000000180D4B1A0
		private static void RescueAlpha(Graphic g, State st, string where); // 0x0000000180D4B1A0-0x0000000180D4B3B0
		private static void RescueAlpha(SpriteRenderer sr, State st, string where); // 0x0000000180D4B3B0-0x0000000180D4B610
		private static void SetAlpha(Graphic g, float a); // 0x0000000180D4B610-0x0000000180D4B6B0
		private static void SetAlpha(SpriteRenderer sr, float a); // 0x0000000180D4B6B0-0x0000000180D4B7E0
		private static void RestoreAlpha(Component target, float a); // 0x0000000180D4B7E0-0x0000000180D4BAA0
	}
}
