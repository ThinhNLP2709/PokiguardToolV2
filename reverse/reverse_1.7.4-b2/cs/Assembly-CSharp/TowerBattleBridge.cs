/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TowerBattleBridge // TypeDefIndex: 958
{
	// Fields
	public const string ROOM_PREFIX = "Tower_"; // Metadata: 0x0068BFDA
	private static TowerBattleBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnTowerRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnTowerRoomFailed; // 0x20
	[CompilerGenerated]
	private int _Floor_k__BackingField; // 0x28
	[CompilerGenerated]
	private int _EnemyPetId_k__BackingField; // 0x2C
	[CompilerGenerated]
	private int _EnemyPetLevel_k__BackingField; // 0x30
	[CompilerGenerated]
	private int _LimitTurn_k__BackingField; // 0x34

	// Properties
	public static TowerBattleBridge Instance { get; } // 0x00000001804E2F20-0x00000001804E2FB0 
	public int Floor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DEC20-0x00000001803DEC30 0x00000001803DF3D0-0x00000001803DF3E0
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018043A930-0x000000018043A940 0x000000018043AAA0-0x000000018043AAB0
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF70-0x000000018039BF80 0x000000018039D720-0x000000018039D730
	public int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039BF60-0x000000018039BF70 0x000000018039D710-0x000000018039D720

	// Events
	public event Action OnTowerRoomReady {
		add; // 0x00000001804E2E80-0x00000001804E2F20
		remove; // 0x00000001804E3070-0x00000001804E3110
	}
	public event Action<string> OnTowerRoomFailed {
		add; // 0x00000001804E2DC0-0x00000001804E2E80
		remove; // 0x00000001804E2FB0-0x00000001804E3070
	}

	// Constructors
	public TowerBattleBridge(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001804E2700-0x00000001804E2820
	public void Unsubscribe(); // 0x00000001804E2CE0-0x00000001804E2DC0
	public void CreateAndJoin(); // 0x00000001804E2560-0x00000001804E2700
	public void LeaveRoom(); // 0x00000001804E2B20-0x00000001804E2BB0
	private void HandleWsRoomEntered(string roomId); // 0x00000001804E28C0-0x00000001804E2B20
	private void HandleWsEnterFailed(string reason); // 0x00000001804E2820-0x00000001804E28C0
	private static int PropInt(Dictionary<string, object> props, string key); // 0x00000001804E2BB0-0x00000001804E2CE0
}

