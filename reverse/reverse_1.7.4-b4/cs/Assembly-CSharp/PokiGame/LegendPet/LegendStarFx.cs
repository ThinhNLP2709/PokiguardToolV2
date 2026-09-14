/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGame.LegendPet
{
	[DisallowMultipleComponent]
	public class LegendStarFx : MonoBehaviour // TypeDefIndex: 2582
	{
		// Fields
		private const int MOTE_POOL = 24; // Metadata: 0x005F23F5
		private const int RING_POOL = 4; // Metadata: 0x005F23F6
		private const int GLOW_POOL = 3; // Metadata: 0x005F23F7
		private const float MOTE_SIZE = 26f; // Metadata: 0x005F23F8
		private const float RING_SIZE = 120f; // Metadata: 0x005F23FC
		private const float GLOW_SIZE = 150f; // Metadata: 0x005F2400
		private const float MOTE_REACH = 2.6f; // Metadata: 0x005F2404
		private Image[] _motes; // 0x20
		private Image[] _rings; // 0x28
		private Image[] _glows; // 0x30
		private int _nextMote; // 0x38
		private int _nextRing; // 0x3C
		private int _nextGlow; // 0x40
		private bool _built; // 0x44
	
		// Properties
		public bool Ready { get; } // 0x0000000180BE31C0-0x0000000180BE31E0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2583
		{
			// Fields
			public Image img; // 0x10
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EmitRing_b__0(float t); // 0x0000000180BE5F20-0x0000000180BE6130
			internal void _EmitRing_b__1(); // 0x0000000180BE6130-0x0000000180BE6280
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass25_0 // TypeDefIndex: 2584
		{
			// Fields
			public Vector2 pos; // 0x10
	
			// Constructors
			public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass25_1 // TypeDefIndex: 2585
		{
			// Fields
			public Image img; // 0x10
			public Vector2 target; // 0x18
			public __c__DisplayClass25_0 CS___8__locals1; // 0x20
	
			// Constructors
			public __c__DisplayClass25_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _EmitMotes_b__0(float t); // 0x0000000180BE6280-0x0000000180BE6550
			internal void _EmitMotes_b__1(); // 0x0000000180BE6550-0x0000000180BE66A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass26_0 // TypeDefIndex: 2586
		{
			// Fields
			public Image img; // 0x10
	
			// Constructors
			public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _FadeOut_b__0(float a); // 0x0000000180BE66A0-0x0000000180BE6820
			internal void _FadeOut_b__1(); // 0x0000000180BE6820-0x0000000180BE6970
		}
	
		// Constructors
		public LegendStarFx(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Build(); // 0x0000000180BE31E0-0x0000000180BE38E0
		private Image NewNode(string name, Sprite sprite, float size); // 0x0000000180BE38E0-0x0000000180BE3D70
		private void OnDisable(); // 0x0000000180BE3D70-0x0000000180BE3DA0
		public void CancelAll(); // 0x0000000180BE3D70-0x0000000180BE3DA0
		private static void Sleep(Image[] pool); // 0x0000000180BE3DA0-0x0000000180BE3FE0
		public void PlayInlay(Vector2 localPos, Color tint, float gemSize); // 0x0000000180BE3FE0-0x0000000180BE4140
		public void PlayComplete(Vector2 center, Color tint, float stageRadius); // 0x0000000180BE4140-0x0000000180BE4330
		private void EmitGlow(Vector2 pos, Color tint, float size, float life); // 0x0000000180BE4330-0x0000000180BE4720
		private void EmitRing(Vector2 pos, Color tint, float from, float to, float life, float delay); // 0x0000000180BE4720-0x0000000180BE4D00
		private void EmitMotes(Vector2 pos, Color tint, float size, int count, float reach, float life, float stagger); // 0x0000000180BE4D00-0x0000000180BE5470
		private static void FadeOut(Image img, float from, float life); // 0x0000000180BE5470-0x0000000180BE5680
		private static Image Take(Image[] pool, ref int cursor); // 0x0000000180BE5680-0x0000000180BE57F0
		public static LegendStarFx Mount(RectTransform stage); // 0x0000000180BE57F0-0x0000000180BE5F20
	}
}
