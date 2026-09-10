/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class HubBadgesData // TypeDefIndex: 1269
{
	// Fields
	public long computedAtMs; // 0x10
	public long noticeLatestId; // 0x18
	public int noticeUnread; // 0x20
	public int questClaimable; // 0x24
	public bool checkinAvailable; // 0x28
	public HubOnlineGiftBadge onlineGift; // 0x30
	public HubFriendBadge friend; // 0x38
	public HubGuildBadge guild; // 0x40
	public HubRechargeBadge recharge; // 0x48
	public HubWorldBossBadge worldBoss; // 0x50

	// Properties
	public bool IsPresent { get; } // 0x000000018058E900-0x000000018058E910 

	// Constructors
	public HubBadgesData(); // 0x00000001802E9CB0-0x00000001802E9CC0
}

