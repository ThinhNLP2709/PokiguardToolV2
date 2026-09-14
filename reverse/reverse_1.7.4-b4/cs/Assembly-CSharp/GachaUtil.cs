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

public static class GachaUtil // TypeDefIndex: 759
{
	// Fields
	private static readonly Dictionary<string, Sprite> _cache; // 0x00
	private static readonly Dictionary<string, Sprite> _rewardCache; // 0x08

	// Constructors
	static GachaUtil(); // 0x00000001804E1440-0x00000001804E15C0

	// Methods
	public static Sprite LoadUI(string fileName); // 0x00000001804DD880-0x00000001804DDA10
	public static Color RarityColor(string rarity); // 0x00000001804DDA10-0x00000001804DDA80
	public static string RarityLabel(string rarity); // 0x00000001804DDA80-0x00000001804DDAD0
	public static int RarityRank(string rarity); // 0x00000001804DDAD0-0x00000001804DDC50
	public static Sprite RarityAura(string rarity); // 0x00000001804DDC50-0x00000001804DDD30
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item); // 0x00000001804DDD30-0x00000001804DDDA0
	public static bool IsShardPrize(GachaRollItemDTO item); // 0x00000001804DDDA0-0x00000001804DDEE0
	public static void ApplyPrizeIcon(Image target, GachaRollItemDTO item, Image piece); // 0x00000001804DDEE0-0x00000001804DEDF0
	public static Image EnsurePieceChild(Image main); // 0x00000001804DEDF0-0x00000001804DF550
	private static void ApplyShardFit(Image target, Image piece, bool shard); // 0x00000001804DF550-0x00000001804DFB60
	public static void ApplyPieceOverlay(Image piece, bool show); // 0x00000001804DFB60-0x00000001804DFF80
	public static int DisplayAmount(string prizeType, int amount, bool convertedToShard); // 0x00000001804DFF80-0x00000001804E0020
	public static int DisplayAmount(GachaRollItemDTO item); // 0x00000001804E0020-0x00000001804E0110
	public static string PrizeLabel(GachaRollItemDTO item); // 0x00000001804E0110-0x00000001804E05D0
	public static string CurrencyLabel(string currency); // 0x00000001804E05D0-0x00000001804E0850
	public static string SlotLabel(GachaRollItemDTO item); // 0x00000001804E0850-0x00000001804E0930
	public static Sprite RewardPrefabSprite(string prizeType); // 0x00000001804E0930-0x00000001804E0EF0
	private static string NormalizeEItem(string t); // 0x00000001804E0EF0-0x00000001804E0F90
	public static string Num(long v); // 0x00000001804E0F90-0x00000001804E1080
	public static string Countdown(long seconds); // 0x00000001804E1080-0x00000001804E1440
}

