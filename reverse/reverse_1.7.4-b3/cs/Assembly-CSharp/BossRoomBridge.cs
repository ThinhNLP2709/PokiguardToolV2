/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class BossRoomBridge // TypeDefIndex: 475
{
	// Fields
	private static BossRoomBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnBossRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnBossRoomFailed; // 0x20

	// Properties
	public static BossRoomBridge Instance { get; } // 0x0000000180383A90-0x0000000180383B50 

	// Events
	public event Action OnBossRoomReady {
		add; // 0x0000000180383B50-0x0000000180383C40
		remove; // 0x0000000180383C40-0x0000000180383D30
	}
	public event Action<string> OnBossRoomFailed {
		add; // 0x0000000180383D30-0x0000000180383E50
		remove; // 0x0000000180383E50-0x0000000180383F70
	}

	// Constructors
	public BossRoomBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x0000000180383F70-0x00000001803840B0
	public void CreateAndJoinPhoton(Dictionary<string, object> properties = null); // 0x00000001803840B0-0x0000000180384280
	public void LeaveBoth(); // 0x0000000180384280-0x0000000180384330
	private void HandleWsRoomEntered(string roomId); // 0x0000000180384330-0x0000000180384420
	private void HandleWsEnterFailed(string reason); // 0x0000000180384420-0x00000001803844D0
}

