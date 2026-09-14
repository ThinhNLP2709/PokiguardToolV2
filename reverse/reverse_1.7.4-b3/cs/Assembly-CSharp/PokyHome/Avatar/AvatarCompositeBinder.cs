/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	public static class AvatarCompositeBinder // TypeDefIndex: 2898
	{
		// Fields
		private static readonly Dictionary<object, State> _states; // 0x00
		private static int _sinceSweep; // 0x08
	
		// Properties
		private static bool FxOn { get; } // 0x0000000180D3AB90-0x0000000180D3AC00 
	
		// Nested types
		private sealed class State // TypeDefIndex: 2899
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
			public State(); // 0x0000000180D3DE50-0x0000000180D3DE80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0 // TypeDefIndex: 2900
		{
			// Fields
			public State st; // 0x10
			public Action<float> setAlpha; // 0x18
			public float targetAlpha; // 0x20
	
			// Constructors
			public __c__DisplayClass17_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Fade_b__0(); // 0x0000000180D3DE80-0x0000000180D3DEC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2901
		{
			// Fields
			public GameObject go; // 0x10
			public State st; // 0x18
			public float half; // 0x20
			public Action __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Pop_b__0(); // 0x0000000180D3DEC0-0x0000000180D3E130
			internal void _Pop_b__1(); // 0x0000000180D3E130-0x0000000180D3E2D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 2902
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
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D3E2D0-0x0000000180D3E670
			internal void _Bind_b__1(float a); // 0x0000000180D3E670-0x0000000180D3E810
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 2903
		{
			// Fields
			public RawImage raw; // 0x10
			public State st; // 0x18
			public int token; // 0x20
			public Action<float> __9__1; // 0x28
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D3E810-0x0000000180D3EBF0
			internal void _Bind_b__1(float a); // 0x0000000180D3EBF0-0x0000000180D3ED90
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 2904
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
			internal void _Bind_b__0(Sprite sprite); // 0x0000000180D3ED90-0x0000000180D3F1B0
			internal void _Bind_b__1(float a); // 0x0000000180D3F1B0-0x0000000180D3F2E0
		}
	
		// Constructors
		static AvatarCompositeBinder(); // 0x0000000180D3DCE0-0x0000000180D3DE00
	
		// Methods
		public static void Bind(Image img, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x005F2271 */); // 0x0000000180D3AC00-0x0000000180D3B0D0
		public static void Bind(RawImage raw, string layers, Texture legacyFallback); // 0x0000000180D3B0D0-0x0000000180D3B580
		public static void Bind(SpriteRenderer sr, string layers, Sprite legacyFallback, bool popFx = false /* Metadata: 0x005F2272 */); // 0x0000000180D3B580-0x0000000180D3BAB0
		public static void Unbind(Component target); // 0x0000000180D3BAB0-0x0000000180D3BD50
		private static bool SameAsApplied(State st, string layers, UnityEngine.Object current); // 0x0000000180D3BD50-0x0000000180D3BFA0
		private static bool HoldsComposite(State st, UnityEngine.Object current); // 0x0000000180D3BFA0-0x0000000180D3C160
		private static void ClearApplied(State st); // 0x0000000180D3C160-0x0000000180D3C280
		private static bool Ready(string layers); // 0x0000000180D3C280-0x0000000180D3C2C0
		private static State StateOf(object target); // 0x0000000180D3C2C0-0x0000000180D3C440
		private static void Sweep(); // 0x0000000180D3C440-0x0000000180D3C7F0
		private static Rect UvRectOf(Sprite sprite); // 0x0000000180D3C7F0-0x0000000180D3CAD0
		private static void Fade(GameObject go, State st, Action<float> setAlpha, float currentAlpha); // 0x0000000180D3CAD0-0x0000000180D3CF30
		private static void Pop(GameObject go, State st, bool popFx); // 0x0000000180D3CF30-0x0000000180D3D3E0
		private static void RescueAlpha(Graphic g, State st, string where); // 0x0000000180D3D3E0-0x0000000180D3D5F0
		private static void RescueAlpha(SpriteRenderer sr, State st, string where); // 0x0000000180D3D5F0-0x0000000180D3D850
		private static void SetAlpha(Graphic g, float a); // 0x0000000180D3D850-0x0000000180D3D8F0
		private static void SetAlpha(SpriteRenderer sr, float a); // 0x0000000180D3D8F0-0x0000000180D3DA20
		private static void RestoreAlpha(Component target, float a); // 0x0000000180D3DA20-0x0000000180D3DCE0
	}
}
