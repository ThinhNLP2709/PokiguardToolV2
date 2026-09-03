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

public static class GachaUtil // TypeDefIndex: 590
{
	// Fields
	public const string UI_DIR = "Image/GachaUI/"; // Metadata: 0x0064C573
	public const string UI_GALAXY_DIR = "Image/GalaxyUI/"; // Metadata: 0x0064C582
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Dictionary<string, Sprite> _rewardCache; // 0x08

	// Constructors
	static GachaUtil(); // 0x00000001803AA4F0-0x00000001803AA5C0

	// Methods
	public static Sprite LoadUI(string fileName); // 0x00000001803A98D0-0x00000001803A9A20
	public static Color RarityColor(string rarity); // 0x00000001803A9F70-0x00000001803A9FE0
	public static string RarityLabel(string rarity); // 0x00000001803A9FE0-0x00000001803AA030
	public static int RarityRank(string rarity); // 0x00000001803AA030-0x00000001803AA120
	public static Sprite RarityAura(string rarity); // 0x00000001803A9E10-0x00000001803A9F70
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item); // 0x00000001803A7F90-0x00000001803A7FF0
	public static bool IsShardPrize(GachaRollItemDTO item); // 0x00000001803A9820-0x00000001803A98D0
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item, Image piece); // 0x00000001803A7FF0-0x00000001803A88C0
	public static Image EnsurePieceChild(Image main); // 0x00000001803A93B0-0x00000001803A9820
	private static void ApplyShardFit(Image target, Image piece, bool shard); // 0x00000001803A88C0-0x00000001803A8D90
	public static void ApplyPieceOverlay(Image piece, bool show); // 0x00000001803A7D80-0x00000001803A7F90
	public static int DisplayAmount(string prizeType, int amount, bool convertedToShard); // 0x00000001803A9280-0x00000001803A92F0
	public static int DisplayAmount(GachaRollItemDTO item); // 0x00000001803A92F0-0x00000001803A93B0
	public static string PrizeLabel(GachaRollItemDTO item); // 0x00000001803A9B00-0x00000001803A9E10
	public static string CurrencyLabel(string currency); // 0x00000001803A9110-0x00000001803A9280
	public static string SlotLabel(GachaRollItemDTO item); // 0x00000001803AA450-0x00000001803AA4F0
	public static Sprite RewardPrefabSprite(string prizeType); // 0x00000001803AA120-0x00000001803AA450
	private static string NormalizeEItem(string t); // 0x00000001803A9A20-0x00000001803A9AA0
	public static string Num(long v); // 0x00000001803A9AA0-0x00000001803A9B00
	public static string Countdown(long seconds); // 0x00000001803A8D90-0x00000001803A9110
}

