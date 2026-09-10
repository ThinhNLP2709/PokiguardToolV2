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

public static class GachaUtil // TypeDefIndex: 667
{
	// Fields
	public const string UI_DIR = "Image/GachaUI/"; // Metadata: 0x0068B726
	public const string UI_GALAXY_DIR = "Image/GalaxyUI/"; // Metadata: 0x0068B735
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Dictionary<string, Sprite> _rewardCache; // 0x08

	// Constructors
	static GachaUtil(); // 0x000000018042CE90-0x000000018042CF60

	// Methods
	public static Sprite LoadUI(string fileName); // 0x000000018042C240-0x000000018042C390
	public static Color RarityColor(string rarity); // 0x000000018042C8E0-0x000000018042C950
	public static string RarityLabel(string rarity); // 0x000000018042C950-0x000000018042C9A0
	public static int RarityRank(string rarity); // 0x000000018042C9A0-0x000000018042CA90
	public static Sprite RarityAura(string rarity); // 0x000000018042C780-0x000000018042C8E0
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item); // 0x000000018042A7E0-0x000000018042A840
	public static bool IsShardPrize(GachaRollItemDTO item); // 0x000000018042C190-0x000000018042C240
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item, Image piece); // 0x000000018042A840-0x000000018042B230
	public static Image EnsurePieceChild(Image main); // 0x000000018042BD20-0x000000018042C190
	private static void ApplyShardFit(Image target, Image piece, bool shard); // 0x000000018042B230-0x000000018042B700
	public static void ApplyPieceOverlay(Image piece, bool show); // 0x000000018042A5D0-0x000000018042A7E0
	public static int DisplayAmount(string prizeType, int amount, bool convertedToShard); // 0x000000018042BBF0-0x000000018042BC60
	public static int DisplayAmount(GachaRollItemDTO item); // 0x000000018042BC60-0x000000018042BD20
	public static string PrizeLabel(GachaRollItemDTO item); // 0x000000018042C470-0x000000018042C780
	public static string CurrencyLabel(string currency); // 0x000000018042BA80-0x000000018042BBF0
	public static string SlotLabel(GachaRollItemDTO item); // 0x000000018042CDD0-0x000000018042CE90
	public static Sprite RewardPrefabSprite(string prizeType); // 0x000000018042CA90-0x000000018042CDD0
	private static string NormalizeEItem(string t); // 0x000000018042C390-0x000000018042C410
	public static string Num(long v); // 0x000000018042C410-0x000000018042C470
	public static string Countdown(long seconds); // 0x000000018042B700-0x000000018042BA80
}

