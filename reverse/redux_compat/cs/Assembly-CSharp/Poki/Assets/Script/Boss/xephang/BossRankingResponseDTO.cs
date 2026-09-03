/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace Poki.Assets.Script.Boss.xephang
{
	[Serializable]
	public class BossRankingResponseDTO // TypeDefIndex: 2006
	{
		// Fields
		public long bossScheduleId; // 0x10
		public string bossName; // 0x18
		public List<BossRankingPlayerDTO> topPlayers; // 0x20
		public BossRankingPlayerDTO currentPlayer; // 0x28
		public string status; // 0x30
		public string battleDate; // 0x38
		public long endTimeMs; // 0x40
		public long settleAtMs; // 0x48
		public long serverTimeMs; // 0x50
		public bool claimOpen; // 0x58
	
		// Constructors
		public BossRankingResponseDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
