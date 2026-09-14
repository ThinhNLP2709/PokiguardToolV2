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

public static class RewardChest // TypeDefIndex: 1452
{
	// Fields
	private static readonly Vector2 STAR_SIZE; // 0x00
	private static readonly Vector2 STAR_OFFSET; // 0x08
	private static readonly Color DIM; // 0x10
	private static readonly Dictionary<string, Sprite> _cache; // 0x20
	private static PokyChestSpriteSet _poky; // 0x28
	private static bool _pokyTried; // 0x30

	// Properties
	public static bool Enabled { get; } // 0x00000001807E8580-0x00000001807E85D0 

	// Constructors
	static RewardChest(); // 0x00000001807EB220-0x00000001807EB350

	// Methods
	private static PokyChestSpriteSet PokySet(); // 0x00000001807E85D0-0x00000001807E8A80
	public static int TierFromRank(int rank, int total); // 0x00000001807E8A80-0x00000001807E8AE0
	public static Sprite Load(int tier, bool opened); // 0x00000001807E8AE0-0x00000001807E8FC0
	public static GameObject Ensure(Transform parent, Vector2 size, string name = "chest" /* Metadata: 0x005EFBA1 */); // 0x00000001807E8FC0-0x00000001807E98B0
	public static void Apply(GameObject chest, int tier, bool opened); // 0x00000001807E98B0-0x00000001807E9C30
	private static int ClosedTier(GameObject chest, Image img); // 0x00000001807E9C30-0x00000001807EA460
	private static bool HasStar(GameObject chest); // 0x00000001807EA460-0x00000001807EA6D0
	private static void ApplyStar(GameObject chest, int tier, bool opened); // 0x00000001807EA6D0-0x00000001807EB220
}

