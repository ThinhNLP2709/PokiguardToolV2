/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public static class AvatarCompositeBinder // TypeDefIndex: 2451
	{
		// Fields
		private static readonly Dictionary<object, State> _states; // 0x00
		private const int SWEEP_EVERY = 128; // Metadata: 0x0068F527
		private static int _sinceSweep; // 0x08
	
		// Properties
		private static bool FxOn { get; } // 0x00000001807FBCB0-0x00000001807FBD10 
	
		// Nested types
		private sealed class State // TypeDefIndex: 2452
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
			public State(); // 0x000000018080B640-0x000000018080B670
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0 // TypeDefIndex: 2453
		{
			// Fields
			public State st; // 0x10
			public Action<float> setAlpha; // 0x18
			public float targetAlpha; // 0x20
	
			// Constructors
			public __c__DisplayClass17_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Fade_b__0(); // 0x000000018080CE80-0x000000018080CEC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2454
		{
			// Fields
			public GameObject go; // 0x10
			public State st; // 0x18
			public float half; // 0x20
			public Action __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Pop_b__0(); // 0x000000018080CEC0-0x000000018080D060
			internal void _Pop_b__1(); // 0x000000018080D060-0x000000018080D120
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 2455
		{
			// Fields
			public Image img; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public bool popFx; // 0x24
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x000000018080D1E0-0x000000018080D420
			internal void _Bind_b__1(float a); // 0x000000018080D420-0x000000018080D530
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2456
		{
			// Fields
			public RawImage raw; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x000000018080D530-0x000000018080D790
			internal void _Bind_b__1(float a); // 0x000000018080D790-0x000000018080D8A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2457
		{
			// Fields
			public SpriteRenderer sr; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public bool popFx; // 0x24
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x000000018080DD80-0x000000018080DFA0
			internal void _Bind_b__1(float a); // 0x000000018080DFA0-0x000000018080E0A0
		}
	
		// Constructors
		static AvatarCompositeBinder(); // 0x00000001807FBBE0-0x00000001807FBCB0
	
		// Methods
		public static void Bind(Image img, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x0068F525 */); // 0x00000001807FA390-0x00000001807FA620
		public static void Bind(RawImage raw, string layers, Texture legacyFallback); // 0x00000001807FA620-0x00000001807FA8B0
		public static void Bind(SpriteRenderer sr, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x0068F526 */); // 0x00000001807FA0F0-0x00000001807FA390
		public static void Unbind(Component target); // 0x00000001807FB800-0x00000001807FB9D0
		private static bool SameAsApplied(State st, string layers, UnityEngine.Object current); // 0x00000001807FB1C0-0x00000001807FB2E0
		private static bool HoldsComposite(State st, UnityEngine.Object current); // 0x00000001807FABF0-0x00000001807FACA0
		private static void ClearApplied(State st); // 0x00000001807FA8B0-0x00000001807FA910
		private static bool Ready(string layers); // 0x00000001807FAF70-0x00000001807FAFB0
		private static State StateOf(object target); // 0x00000001807FB400-0x00000001807FB560
		private static void Sweep(); // 0x00000001807FB560-0x00000001807FB800
		private static Rect UvRectOf(Sprite sprite); // 0x00000001807FB9D0-0x00000001807FBBE0
		private static void Fade(GameObject go, State st, Action<float> setAlpha, float currentAlpha); // 0x00000001807FA910-0x00000001807FABF0
		private static void Pop(GameObject go, State st, bool popFx); // 0x00000001807FACA0-0x00000001807FAF70
		private static void SetAlpha(Graphic g, float a); // 0x00000001807FB2E0-0x00000001807FB380
		private static void SetAlpha(SpriteRenderer sr, float a); // 0x00000001807FB380-0x00000001807FB400
		private static void RestoreAlpha(Component target, float a); // 0x00000001807FAFB0-0x00000001807FB1C0
	}
}
