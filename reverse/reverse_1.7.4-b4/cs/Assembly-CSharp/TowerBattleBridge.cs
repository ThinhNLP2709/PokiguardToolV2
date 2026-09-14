/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TowerBattleBridge // TypeDefIndex: 1329
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
	public static TowerBattleBridge Instance { get; } // 0x000000018075A8C0-0x000000018075A980 
	public int Floor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180424E30-0x0000000180424E40 0x0000000180424E40-0x0000000180424E50
	public int EnemyPetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805641C0-0x00000001805641D0 0x00000001805641D0-0x00000001805641E0
	public int EnemyPetLevel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6C60-0x00000001803C6C70 0x00000001803C6C70-0x00000001803C6C80
	public int LimitTurn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803C6C80-0x00000001803C6C90 0x00000001803C6C90-0x00000001803C6CA0

	// Events
	public event Action OnTowerRoomReady {
		add; // 0x000000018075A980-0x000000018075AA70
		remove; // 0x000000018075AA70-0x000000018075AB60
	}
	public event Action<string> OnTowerRoomFailed {
		add; // 0x000000018075AB60-0x000000018075AC80
		remove; // 0x000000018075AC80-0x000000018075ADA0
	}

	// Constructors
	public TowerBattleBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x000000018075ADA0-0x000000018075AEE0
	public void CreateAndJoin(); // 0x000000018075AEE0-0x000000018075B130
	public void LeaveRoom(); // 0x000000018075B130-0x000000018075B260
	private void HandleWsRoomEntered(string roomId); // 0x000000018075B260-0x000000018075B620
	private void HandleWsEnterFailed(string reason); // 0x000000018075B620-0x000000018075B6D0
	private static int PropInt(Dictionary<string, object> props, string key); // 0x000000018075B6D0-0x000000018075B930
}

