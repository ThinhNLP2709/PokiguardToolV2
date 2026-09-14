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

public static class GachaUtil // TypeDefIndex: 758
{
	// Fields
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Dictionary<string, Sprite> _rewardCache; // 0x08

	// Constructors
	static GachaUtil(); // 0x00000001804DFDD0-0x00000001804DFF50

	// Methods
	public static Sprite LoadUI(string fileName); // 0x00000001804DC210-0x00000001804DC3A0
	public static Color RarityColor(string rarity); // 0x00000001804DC3A0-0x00000001804DC410
	public static string RarityLabel(string rarity); // 0x00000001804DC410-0x00000001804DC460
	public static int RarityRank(string rarity); // 0x00000001804DC460-0x00000001804DC5E0
	public static Sprite RarityAura(string rarity); // 0x00000001804DC5E0-0x00000001804DC6C0
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item); // 0x00000001804DC6C0-0x00000001804DC730
	public static bool IsShardPrize(GachaRollItemDTO item); // 0x00000001804DC730-0x00000001804DC870
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item, Image piece); // 0x00000001804DC870-0x00000001804DD780
	public static Image EnsurePieceChild(Image main); // 0x00000001804DD780-0x00000001804DDEE0
	private static void ApplyShardFit(Image target, Image piece, bool shard); // 0x00000001804DDEE0-0x00000001804DE4F0
	public static void ApplyPieceOverlay(Image piece, bool show); // 0x00000001804DE4F0-0x00000001804DE910
	public static int DisplayAmount(string prizeType, int amount, bool convertedToShard); // 0x00000001804DE910-0x00000001804DE9B0
	public static int DisplayAmount(GachaRollItemDTO item); // 0x00000001804DE9B0-0x00000001804DEAA0
	public static string PrizeLabel(GachaRollItemDTO item); // 0x00000001804DEAA0-0x00000001804DEF60
	public static string CurrencyLabel(string currency); // 0x00000001804DEF60-0x00000001804DF1E0
	public static string SlotLabel(GachaRollItemDTO item); // 0x00000001804DF1E0-0x00000001804DF2C0
	public static Sprite RewardPrefabSprite(string prizeType); // 0x00000001804DF2C0-0x00000001804DF880
	private static string NormalizeEItem(string t); // 0x00000001804DF880-0x00000001804DF920
	public static string Num(long v); // 0x00000001804DF920-0x00000001804DFA10
	public static string Countdown(long seconds); // 0x00000001804DFA10-0x00000001804DFDD0
}

