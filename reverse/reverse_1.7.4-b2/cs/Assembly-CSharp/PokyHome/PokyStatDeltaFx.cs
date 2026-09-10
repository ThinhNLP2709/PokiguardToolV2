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

namespace PokyHome
{
	public static class PokyStatDeltaFx // TypeDefIndex: 2274
	{
		// Fields
		public const int MAX_LINES = 3; // Metadata: 0x0068E534
		private const float RISE = 70f; // Metadata: 0x0068E535
		private const float LIFE = 1.1f; // Metadata: 0x0068E539
		private const float POP_TIME = 0.25f; // Metadata: 0x0068E53D
		private const float FADE_FROM = 0.64f; // Metadata: 0x0068E541
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 2275
		{
			// Fields
			public RectTransform rt; // 0x10
			public UnityEngine.UI.Text txt; // 0x18
			public float x; // 0x20
			public float y0; // 0x24
			public GameObject go; // 0x28
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Spawn_b__0(float v); // 0x00000001807AEBA0-0x00000001807AED30
			internal void _Spawn_b__1(); // 0x00000001807AED30-0x00000001807AEDA0
		}
	
		// Methods
		public static void Play(UnityEngine.UI.Text template, RectTransform anchor, IList<string> lines); // 0x00000001807A2320-0x00000001807A2600
		private static void Spawn(UnityEngine.UI.Text template, RectTransform parent, Vector2 basePos, string line, int index); // 0x00000001807A2600-0x00000001807A2BD0
	}
}
