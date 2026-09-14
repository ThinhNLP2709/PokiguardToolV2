/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class TowerBattleBridge // TypeDefIndex: 1327
{
	// Fields
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
	public static TowerBattleBridge Instance { get; } // 0x00000001807589F0-0x0000000180758AB0 
	public int Floor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804240D0-0x00000001804240E0 0x00000001804240E0-0x00000001804240F0
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562890-0x00000001805628A0 0x00000001805628A0-0x00000001805628B0
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5F90-0x00000001803C5FA0 0x00000001803C5FA0-0x00000001803C5FB0
	public int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C5FB0-0x00000001803C5FC0 0x00000001803C5FC0-0x00000001803C5FD0

	// Events
	public event Action OnTowerRoomReady {
		add; // 0x0000000180758AB0-0x0000000180758BA0
		remove; // 0x0000000180758BA0-0x0000000180758C90
	}
	public event Action<string> OnTowerRoomFailed {
		add; // 0x0000000180758C90-0x0000000180758DB0
		remove; // 0x0000000180758DB0-0x0000000180758ED0
	}

	// Constructors
	public TowerBattleBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x0000000180758ED0-0x0000000180759010
	public void CreateAndJoin(); // 0x0000000180759010-0x0000000180759260
	public void LeaveRoom(); // 0x0000000180759260-0x0000000180759390
	private void HandleWsRoomEntered(string roomId); // 0x0000000180759390-0x0000000180759750
	private void HandleWsEnterFailed(string reason); // 0x0000000180759750-0x0000000180759800
	private static int PropInt(Dictionary<string, object> props, string key); // 0x0000000180759800-0x0000000180759A60
}

