/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class GuildVaultData // TypeDefIndex: 854
{
	// Fields
	public long guildId; // 0x10
	public string guildName; // 0x18
	public long gold; // 0x20
	public bool canDistribute; // 0x28
	public bool canEqual; // 0x29
	public bool canManual; // 0x2A
	public long minPerMember; // 0x30
	public int membersCount; // 0x38
	public long equalShare; // 0x40
	public long equalRemainder; // 0x48
	public List<GuildVaultMember> members; // 0x50
	public List<GuildVaultLogRow> log; // 0x58
	public long lastDistributeSec; // 0x60
	public long serverTimeSec; // 0x68
	public bool featureOn; // 0x70

	// Constructors
	public GuildVaultData(); // 0x000000018054F0C0-0x000000018054F230
}

