/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildBattleBridge // TypeDefIndex: 678
{
	// Fields
	public const string ROOM_PREFIX = "GuildBoss_"; // Metadata: 0x0068B7AB
	public const string ROOM_TYPE = "GUILD_BOSS"; // Metadata: 0x0068B7B6
	public const int MAX_PLAYERS = 3; // Metadata: 0x0068B7C1
	private static GuildBattleBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnRoomFailed; // 0x20
	[CompilerGenerated]
	private int _Diff_k__BackingField; // 0x28
	[CompilerGenerated]
	private int _Node_k__BackingField; // 0x2C
	[CompilerGenerated]
	private int _EnemyPetId_k__BackingField; // 0x30
	[CompilerGenerated]
	private int _EnemyPetLevel_k__BackingField; // 0x34
	[CompilerGenerated]
	private string _EnemyPetName_k__BackingField; // 0x38
	[CompilerGenerated]
	private int _LimitTurn_k__BackingField; // 0x40

	// Properties
	public static bool InGuildBossRoom { get; } // 0x000000018043A7B0-0x000000018043A8A0 
	public static GuildBattleBridge Instance { get; } // 0x000000018043A8A0-0x000000018043A930 
	public int Diff { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DEC20-0x00000001803DEC30 0x00000001803DF3D0-0x00000001803DF3E0
	public int Node { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018043A930-0x000000018043A940 0x000000018043AAA0-0x000000018043AAB0
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF70-0x000000018039BF80 0x000000018039D720-0x000000018039D730
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF60-0x000000018039BF70 0x000000018039D710-0x000000018039D720
	public string EnemyPetName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20
	public int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C660-0x000000018039C670 0x000000018039DCC0-0x000000018039DCD0

	// Events
	public event Action OnRoomReady {
		add; // 0x000000018043A710-0x000000018043A7B0
		remove; // 0x000000018043AA00-0x000000018043AAA0
	}
	public event Action<string> OnRoomFailed {
		add; // 0x000000018043A650-0x000000018043A710
		remove; // 0x000000018043A940-0x000000018043AA00
	}

	// Constructors
	public GuildBattleBridge(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public static bool IsGuildBossRoom(string roomId, string roomType); // 0x000000018043A230-0x000000018043A2F0
	public void EnsureSubscribed(); // 0x0000000180439D10-0x0000000180439E30
	public void Unsubscribe(); // 0x000000018043A570-0x000000018043A650
	public void CreateAndJoin(string roomToken, int diff, int node); // 0x0000000180439790-0x0000000180439D10
	public void LeaveRoom(); // 0x000000018043A2F0-0x000000018043A380
	private void HandleWsRoomEntered(string roomId); // 0x0000000180439ED0-0x000000018043A230
	private void HandleWsEnterFailed(string reason); // 0x0000000180439E30-0x0000000180439ED0
	private static int PropInt(Dictionary<string, object> props, string key); // 0x000000018043A380-0x000000018043A4B0
	private static string PropStr(Dictionary<string, object> props, string key); // 0x000000018043A4B0-0x000000018043A570
}

