/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class GuildSeasonInfo // TypeDefIndex: 849
{
	// Fields
	public int seasonNo; // 0x10
	public string status; // 0x18
	public long startSec; // 0x20
	public long endSec; // 0x28
	public long remainSec; // 0x30
	public long serverTimeSec; // 0x38
	public int cycleDays; // 0x40
	public string rankBy; // 0x48
	public List<GuildSeasonReward> rewards; // 0x50
	public bool ticketPerMember; // 0x58
	public int minMemberDays; // 0x5C

	// Properties
	public bool HasSeason { get; } // 0x000000018054EFF0-0x000000018054F000 

	// Constructors
	public GuildSeasonInfo(); // 0x000000018054F000-0x000000018054F0C0
}

