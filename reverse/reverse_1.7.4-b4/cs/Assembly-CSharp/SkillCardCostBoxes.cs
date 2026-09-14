/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class SkillCardCostBoxes // TypeDefIndex: 1151
{
	// Fields
	public int version; // 0x10
	public List<Entry> cards; // 0x18
	private static SkillCardCostBoxes _loaded; // 0x00
	private static bool _tried; // 0x08
	private static Dictionary<int, Entry> _index; // 0x10

	// Properties
	public static SkillCardCostBoxes Loaded { get; } // 0x00000001806A8CA0-0x00000001806A9210 

	// Nested types
	[Serializable]
	public class Entry // TypeDefIndex: 1152
	{
		// Fields
		public int id; // 0x10
		public Box mana; // 0x18
		public Box power; // 0x20

		// Constructors
		public Entry(); // 0x00000001806A9420-0x00000001806A9550
	}

	[Serializable]
	public class Box // TypeDefIndex: 1153
	{
		// Fields
		public float x; // 0x10
		public float y; // 0x14
		public float w; // 0x18
		public float h; // 0x1C
		public float digitH; // 0x20
		public int gridW; // 0x24
		public int gridH; // 0x28
		public string[] cells; // 0x30

		// Properties
		public bool Valid { get; } // 0x00000001806A9550-0x00000001806A95A0 

		// Constructors
		public Box(); // 0x00000001806A95A0-0x00000001806A9630
	}

	// Constructors
	public SkillCardCostBoxes(); // 0x00000001806A9360-0x00000001806A9420

	// Methods
	public static Entry Find(long cardId); // 0x00000001806A9210-0x00000001806A92B0
	public static Color ParseHex(string hex, Color fallback); // 0x00000001806A92B0-0x00000001806A9360
}

