/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGame.LegendPet
{
	public static class LegendStarLayout // TypeDefIndex: 2572
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
		public sealed class Constellation // TypeDefIndex: 2573
		{
			// Fields
			public readonly Vector2[][] Groups; // 0x10
			public readonly float Aspect; // 0x18
	
			// Constructors
			public Constellation(Vector2[][] groups, float aspect); // 0x0000000180BE04F0-0x0000000180BE0570
	
			// Methods
			public bool TryGet(int starType, int index, out Vector2 pos); // 0x0000000180BE0570-0x0000000180BE0600
		}
	
		// Constructors
		static LegendStarLayout(); // 0x0000000180BDE580-0x0000000180BE04F0
	
		// Methods
		public static Constellation For(long petId); // 0x0000000180BDE310-0x0000000180BDE3C0
		public static float AspectOf(long petId); // 0x0000000180BDE3C0-0x0000000180BDE430
		public static Vector2 Ring(int starType, int index, int countInType); // 0x0000000180BDE430-0x0000000180BDE580
	}
}
