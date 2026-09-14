/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildRaidBridge // TypeDefIndex: 885
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
	public static GuildRaidBridge Instance { get; } // 0x0000000180563710-0x00000001805637D0 
	public static long GuildRaidId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563BF0-0x0000000180563C30 0x0000000180563C30-0x0000000180563C80
	public static long RaidClosesAtMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563C80-0x0000000180563CC0 0x0000000180563CC0-0x0000000180563D10
	public static long RaidHpMax { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563D10-0x0000000180563D50 0x0000000180563D50-0x0000000180563DA0
	public static int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563DA0-0x0000000180563DE0 0x0000000180563DE0-0x0000000180563E30
	public static string LastEndReason { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563E30-0x0000000180563E70 0x0000000180563E70-0x0000000180563F10
	public static long ServerClockOffsetMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180563F40-0x0000000180563F80 0x0000000180563F80-0x0000000180563FD0
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180424E30-0x0000000180424E40 0x0000000180424E40-0x0000000180424E50
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805641C0-0x00000001805641D0 0x00000001805641D0-0x00000001805641E0
	private string EnemyPetName { [CompilerGenerated] set; } // 0x00000001802BA570-0x00000001802BA5D0

	// Events
	public event Action OnRaidRoomReady {
		add; // 0x00000001805637D0-0x00000001805638C0
		remove; // 0x00000001805638C0-0x00000001805639B0
	}
	public event Action<string> OnRaidRoomFailed {
		add; // 0x00000001805639B0-0x0000000180563AD0
		remove; // 0x0000000180563AD0-0x0000000180563BF0
	}

	// Constructors
	public GuildRaidBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public static void SetEndReason(string reason); // 0x0000000180563F10-0x0000000180563F40
	public static void SyncServerClock(long serverTimeMs); // 0x0000000180563FD0-0x00000001805640D0
	public static long NowServerMs(); // 0x00000001805640D0-0x00000001805641C0
	public void EnsureSubscribed(); // 0x00000001805641E0-0x0000000180564320
	public void CreateAndJoin(); // 0x0000000180564320-0x0000000180564730
	public void LeaveRoom(); // 0x0000000180564730-0x0000000180564780
	public static bool IsRaidRoom(string roomId, string roomType); // 0x0000000180564780-0x0000000180564970
	public static void ClearMatchContext(); // 0x0000000180564970-0x0000000180564AE0
	private void HandleWsRoomEntered(string roomId); // 0x0000000180564AE0-0x00000001805650A0
	private void HandleWsEnterFailed(string reason); // 0x00000001805650A0-0x0000000180565150
	private static int PropInt(Dictionary<string, object> props, string key); // 0x0000000180565150-0x00000001805653B0
	private static long PropLong(Dictionary<string, object> props, string key); // 0x00000001805653B0-0x0000000180565620
	private static string PropStr(Dictionary<string, object> props, string key); // 0x0000000180565620-0x00000001805656C0
}

