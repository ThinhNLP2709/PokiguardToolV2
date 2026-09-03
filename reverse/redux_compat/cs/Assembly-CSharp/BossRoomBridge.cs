/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class BossRoomBridge // TypeDefIndex: 371
{
	// Fields
	private static BossRoomBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnBossRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnBossRoomFailed; // 0x20

	// Properties
	public static BossRoomBridge Instance { get; } // 0x0000000180314480-0x0000000180314510 

	// Events
	public event Action OnBossRoomReady {
		add; // 0x00000001803143E0-0x0000000180314480
		remove; // 0x00000001803145D0-0x0000000180314670
	}
	public event Action<string> OnBossRoomFailed {
		add; // 0x0000000180314320-0x00000001803143E0
		remove; // 0x0000000180314510-0x00000001803145D0
	}

	// Constructors
	public BossRoomBridge(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void EnsureSubscribed(); // 0x0000000180313EF0-0x0000000180314010
	public void Unsubscribe(); // 0x0000000180314240-0x0000000180314320
	public void CreateAndJoinPhoton(Dictionary<string, object> properties = null); // 0x0000000180313C70-0x0000000180313EF0
	public void LeaveBoth(); // 0x0000000180314190-0x0000000180314240
	private void HandleWsRoomEntered(string roomId); // 0x00000001803140B0-0x0000000180314190
	private void HandleWsEnterFailed(string reason); // 0x0000000180314010-0x00000001803140B0
}

