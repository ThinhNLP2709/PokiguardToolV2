/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TowerBattleBridge // TypeDefIndex: 768
{
	// Fields
	public const string ROOM_PREFIX = "Tower_"; // Metadata: 0x0064C909
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
	public static TowerBattleBridge Instance { get; } // 0x00000001803FDE20-0x00000001803FDEB0 
	public int Floor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
	public int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780

	// Events
	public event Action OnTowerRoomReady {
		add; // 0x00000001803FDD80-0x00000001803FDE20
		remove; // 0x00000001803FDF70-0x00000001803FE010
	}
	public event Action<string> OnTowerRoomFailed {
		add; // 0x00000001803FDCC0-0x00000001803FDD80
		remove; // 0x00000001803FDEB0-0x00000001803FDF70
	}

	// Constructors
	public TowerBattleBridge(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001803FD600-0x00000001803FD720
	public void Unsubscribe(); // 0x00000001803FDBE0-0x00000001803FDCC0
	public void CreateAndJoin(); // 0x00000001803FD380-0x00000001803FD600
	public void LeaveRoom(); // 0x00000001803FDA20-0x00000001803FDAB0
	private void HandleWsRoomEntered(string roomId); // 0x00000001803FD7C0-0x00000001803FDA20
	private void HandleWsEnterFailed(string reason); // 0x00000001803FD720-0x00000001803FD7C0
	private static int PropInt(Dictionary<string, object> props, string key); // 0x00000001803FDAB0-0x00000001803FDBE0
}

