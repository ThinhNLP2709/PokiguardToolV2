/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RewardChest // TypeDefIndex: 872
{
	// Fields
	public const string DIR = "Image/GachaUI/"; // Metadata: 0x0064CC58
	public const string POKY_RESOURCE = "UIPanels/PokyChestSprites"; // Metadata: 0x0064CC67
	private const string STAR_NODE = "star"; // Metadata: 0x0064CC81
	private static readonly Vector2 STAR_SIZE; // 0x00
	private static readonly Vector2 STAR_OFFSET; // 0x08
	private static readonly Color DIM; // 0x10
	private static readonly Dictionary<string, Sprite> _cache; // 0x20
	private static PokyChestSpriteSet _poky; // 0x28
	private static bool _pokyTried; // 0x30

	// Properties
	public static bool Enabled { get; } // 0x00000001804419D0-0x0000000180441A20 

	// Constructors
	static RewardChest(); // 0x00000001804418F0-0x00000001804419D0

	// Methods
	private static PokyChestSpriteSet PokySet(); // 0x0000000180441460-0x0000000180441840
	public static int TierFromRank(int rank, int total); // 0x0000000180441840-0x00000001804418F0
	public static Sprite Load(int tier, bool opened); // 0x0000000180441170-0x0000000180441460
	public static GameObject Ensure(Transform parent, Vector2 size, string name = "chest" /* Metadata: 0x0064CC52 */); // 0x0000000180440BC0-0x00000001804410A0
	public static void Apply(GameObject chest, int tier, bool opened); // 0x00000001804406B0-0x0000000180440880
	private static int ClosedTier(GameObject chest, Image img); // 0x0000000180440880-0x0000000180440BC0
	private static bool HasStar(GameObject chest); // 0x00000001804410A0-0x0000000180441170
	private static void ApplyStar(GameObject chest, int tier, bool opened); // 0x0000000180440110-0x00000001804406B0
}

