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

public static class RewardChest // TypeDefIndex: 1073
{
	// Fields
	public const string DIR = "Image/GachaUI/"; // Metadata: 0x0068C3F6
	public const string POKY_RESOURCE = "UIPanels/PokyChestSprites"; // Metadata: 0x0068C405
	private const string STAR_NODE = "star"; // Metadata: 0x0068C41F
	private static readonly Vector2 STAR_SIZE; // 0x00
	private static readonly Vector2 STAR_OFFSET; // 0x08
	private static readonly Color DIM; // 0x10
	private static readonly Dictionary<string, Sprite> _cache; // 0x20
	private static PokyChestSpriteSet _poky; // 0x28
	private static bool _pokyTried; // 0x30

	// Properties
	public static bool Enabled { get; } // 0x00000001805166A0-0x00000001805166F0 

	// Constructors
	static RewardChest(); // 0x00000001805165C0-0x00000001805166A0

	// Methods
	private static PokyChestSpriteSet PokySet(); // 0x0000000180516130-0x0000000180516510
	public static int TierFromRank(int rank, int total); // 0x0000000180516510-0x00000001805165C0
	public static Sprite Load(int tier, bool opened); // 0x0000000180515E40-0x0000000180516130
	public static GameObject Ensure(Transform parent, Vector2 size, string name = "chest" /* Metadata: 0x0068C3F0 */); // 0x0000000180515890-0x0000000180515D70
	public static void Apply(GameObject chest, int tier, bool opened); // 0x0000000180515380-0x0000000180515550
	private static int ClosedTier(GameObject chest, Image img); // 0x0000000180515550-0x0000000180515890
	private static bool HasStar(GameObject chest); // 0x0000000180515D70-0x0000000180515E40
	private static void ApplyStar(GameObject chest, int tier, bool opened); // 0x0000000180514DE0-0x0000000180515380
}

