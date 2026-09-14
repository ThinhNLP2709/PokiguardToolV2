/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildRaidBridge // TypeDefIndex: 883
{
	// Fields
	private static GuildRaidBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnRaidRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnRaidRoomFailed; // 0x20
	[CompilerGenerated]
	private static long _GuildRaidId_k__BackingField; // 0x08
	[CompilerGenerated]
	private static long _RaidClosesAtMs_k__BackingField; // 0x10
	[CompilerGenerated]
	private static long _RaidHpMax_k__BackingField; // 0x18
	[CompilerGenerated]
	private static int _LimitTurn_k__BackingField; // 0x20
	[CompilerGenerated]
	private static string _LastEndReason_k__BackingField; // 0x28
	[CompilerGenerated]
	private static long _ServerClockOffsetMs_k__BackingField; // 0x30
	[CompilerGenerated]
	private int _EnemyPetId_k__BackingField; // 0x28
	[CompilerGenerated]
	private int _EnemyPetLevel_k__BackingField; // 0x2C
	[CompilerGenerated]
	private string _EnemyPetName_k__BackingField; // 0x30

	// Properties
	public static GuildRaidBridge Instance { get; } // 0x0000000180561DE0-0x0000000180561EA0 
	public static long GuildRaidId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805622C0-0x0000000180562300 0x0000000180562300-0x0000000180562350
	public static long RaidClosesAtMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562350-0x0000000180562390 0x0000000180562390-0x00000001805623E0
	public static long RaidHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805623E0-0x0000000180562420 0x0000000180562420-0x0000000180562470
	public static int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562470-0x00000001805624B0 0x00000001805624B0-0x0000000180562500
	public static string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562500-0x0000000180562540 0x0000000180562540-0x00000001805625E0
	public static long ServerClockOffsetMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562610-0x0000000180562650 0x0000000180562650-0x00000001805626A0
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804240D0-0x00000001804240E0 0x00000001804240E0-0x00000001804240F0
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562890-0x00000001805628A0 0x00000001805628A0-0x00000001805628B0
	private string EnemyPetName { [CompilerGenerated] set; } // 0x00000001802BA540-0x00000001802BA5A0

	// Events
	public event Action OnRaidRoomReady {
		add; // 0x0000000180561EA0-0x0000000180561F90
		remove; // 0x0000000180561F90-0x0000000180562080
	}
	public event Action<string> OnRaidRoomFailed {
		add; // 0x0000000180562080-0x00000001805621A0
		remove; // 0x00000001805621A0-0x00000001805622C0
	}

	// Constructors
	public GuildRaidBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public static void SetEndReason(string reason); // 0x00000001805625E0-0x0000000180562610
	public static void SyncServerClock(long serverTimeMs); // 0x00000001805626A0-0x00000001805627A0
	public static long NowServerMs(); // 0x00000001805627A0-0x0000000180562890
	public void EnsureSubscribed(); // 0x00000001805628B0-0x00000001805629F0
	public void CreateAndJoin(); // 0x00000001805629F0-0x0000000180562E00
	public void LeaveRoom(); // 0x0000000180562E00-0x0000000180562E50
	public static bool IsRaidRoom(string roomId, string roomType); // 0x0000000180562E50-0x0000000180563040
	public static void ClearMatchContext(); // 0x0000000180563040-0x00000001805631B0
	private void HandleWsRoomEntered(string roomId); // 0x00000001805631B0-0x0000000180563770
	private void HandleWsEnterFailed(string reason); // 0x0000000180563770-0x0000000180563820
	private static int PropInt(Dictionary<string, object> props, string key); // 0x0000000180563820-0x0000000180563A80
	private static long PropLong(Dictionary<string, object> props, string key); // 0x0000000180563A80-0x0000000180563CF0
	private static string PropStr(Dictionary<string, object> props, string key); // 0x0000000180563CF0-0x0000000180563D90
}

