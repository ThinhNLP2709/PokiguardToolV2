/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGame.LegendPet
{
	public static class LegendStarLayout // TypeDefIndex: 2565
	{
		// Fields
		private static readonly Vector2[][] P1678; // 0x00
		private static readonly Vector2[][] P1680; // 0x08
		private static readonly Vector2[][] P1645; // 0x10
		private static readonly Vector2[][] P1716; // 0x18
		private static readonly Vector2[][] P1639; // 0x20
		private static readonly Vector2[][] P1861; // 0x28
		private static readonly Vector2[][] P2035; // 0x30
		private static readonly Dictionary<long, Constellation> _byPet; // 0x38
		private static readonly float[] RING_RADII; // 0x40
		private static readonly float[] RING_PHASE; // 0x48
	
		// Nested types
		public sealed class Constellation // TypeDefIndex: 2566
		{
			// Fields
			public readonly Vector2[][] Groups; // 0x10
			public readonly float Aspect; // 0x18
	
			// Constructors
			public Constellation(Vector2[][] groups, float aspect); // 0x0000000180BD30D0-0x0000000180BD3150
	
			// Methods
			public bool TryGet(int starType, int index, out Vector2 pos); // 0x0000000180BD3150-0x0000000180BD31E0
		}
	
		// Constructors
		static LegendStarLayout(); // 0x0000000180BD1310-0x0000000180BD30D0
	
		// Methods
		public static Constellation For(long petId); // 0x0000000180BD10A0-0x0000000180BD1150
		public static float AspectOf(long petId); // 0x0000000180BD1150-0x0000000180BD11C0
		public static Vector2 Ring(int starType, int index, int countInType); // 0x0000000180BD11C0-0x0000000180BD1310
	}
}
