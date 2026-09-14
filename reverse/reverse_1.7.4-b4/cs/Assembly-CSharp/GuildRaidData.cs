/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class GuildRaidData // TypeDefIndex: 842
{
	// Fields
	public long serverTimeMs; // 0x10
	public bool featureOn; // 0x18
	public int levelRequired; // 0x1C
	public bool levelLocked; // 0x20
	public int userLevel; // 0x24
	public bool hasGuild; // 0x28
	public long guildId; // 0x30
	public string guildName; // 0x38
	public int guildLevel; // 0x40
	public bool hasWindow; // 0x44
	public string windowStatus; // 0x48
	public long opensAtMs; // 0x50
	public long closesAtMs; // 0x58
	public string dayKey; // 0x60
	public int bossConfigId; // 0x68
	public int bossPetId; // 0x6C
	public int displayPetId; // 0x70
	public string bossName; // 0x78
	public string element; // 0x80
	public int level; // 0x88
	public int star; // 0x8C
	public long hpMax; // 0x90
	public long hpCurrent; // 0x98
	public int fightingCount; // 0xA0
	public long raidId; // 0xA8
	public string raidStatus; // 0xB0
	public string killerName; // 0xB8
	public long killedAtMs; // 0xC0
	public int participants; // 0xC8
	public long totalDamage; // 0xD0
	public int freeLeft; // 0xD8
	public int freeMax; // 0xDC
	public int ticketLeft; // 0xE0
	public int ticketMax; // 0xE4
	public int ticketItemId; // 0xE8
	public int ticketOwned; // 0xEC
	public long myDamage; // 0xF0
	public int myRank; // 0xF8
	public int myAttempts; // 0xFC
	public long myBest; // 0x100
	public List<GuildRaidRow> top; // 0x108
	public TowerGiftBundle killReward; // 0x110
	public bool petOwned; // 0x118
	public long nextOpensAtMs; // 0x120
	public string nextBossName; // 0x128
	public int nextDisplayPetId; // 0x130
	public List<GuildRaidDayRow> week; // 0x138
	public string notice; // 0x140

	// Constructors
	public GuildRaidData(); // 0x000000018054FE20-0x00000001805502F0
}

