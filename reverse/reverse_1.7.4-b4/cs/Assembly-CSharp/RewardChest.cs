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

public static class RewardChest // TypeDefIndex: 1454
{
	// Fields
	private static readonly Vector2 STAR_SIZE; // 0x00
	private static readonly Vector2 STAR_OFFSET; // 0x08
	private static readonly Color DIM; // 0x10
	private static readonly Dictionary<string, Sprite> _cache; // 0x20
	private static PokyChestSpriteSet _poky; // 0x28
	private static bool _pokyTried; // 0x30

	// Properties
	public static bool Enabled { get; } // 0x00000001807EA5F0-0x00000001807EA640 

	// Constructors
	static RewardChest(); // 0x00000001807ED290-0x00000001807ED3C0

	// Methods
	private static PokyChestSpriteSet PokySet(); // 0x00000001807EA640-0x00000001807EAAF0
	public static int TierFromRank(int rank, int total); // 0x00000001807EAAF0-0x00000001807EAB50
	public static Sprite Load(int tier, bool opened); // 0x00000001807EAB50-0x00000001807EB030
	public static GameObject Ensure(Transform parent, Vector2 size, string name = "chest" /* Metadata: 0x005F0F6E */); // 0x00000001807EB030-0x00000001807EB920
	public static void Apply(GameObject chest, int tier, bool opened); // 0x00000001807EB920-0x00000001807EBCA0
	private static int ClosedTier(GameObject chest, Image img); // 0x00000001807EBCA0-0x00000001807EC4D0
	private static bool HasStar(GameObject chest); // 0x00000001807EC4D0-0x00000001807EC740
	private static void ApplyStar(GameObject chest, int tier, bool opened); // 0x00000001807EC740-0x00000001807ED290
}

