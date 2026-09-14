/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public static BossRoomBridge Instance { get; } // 0x0000000180383C40-0x0000000180383D00 

	// Events
	public event Action OnBossRoomReady {
		add; // 0x0000000180383D00-0x0000000180383DF0
		remove; // 0x0000000180383DF0-0x0000000180383EE0
	}
	public event Action<string> OnBossRoomFailed {
		add; // 0x0000000180383EE0-0x0000000180384000
		remove; // 0x0000000180384000-0x0000000180384120
	}

	// Constructors
	public BossRoomBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x0000000180384120-0x0000000180384260
	public void CreateAndJoinPhoton(Dictionary<string, object> properties = null); // 0x0000000180384260-0x0000000180384430
	public void LeaveBoth(); // 0x0000000180384430-0x00000001803844E0
	private void HandleWsRoomEntered(string roomId); // 0x00000001803844E0-0x00000001803845D0
	private void HandleWsEnterFailed(string reason); // 0x00000001803845D0-0x0000000180384680
}

