/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class BossRoomBridge // TypeDefIndex: 421
{
	// Fields
	private static BossRoomBridge _instance; // 0x00
	private bool _subscribed; // 0x10
	[CompilerGenerated]
	private Action OnBossRoomReady; // 0x18
	[CompilerGenerated]
	private Action<string> OnBossRoomFailed; // 0x20

	// Properties
	public static BossRoomBridge Instance { get; } // 0x0000000180362F60-0x0000000180362FF0 

	// Events
	public event Action OnBossRoomReady {
		add; // 0x0000000180362EC0-0x0000000180362F60
		remove; // 0x00000001803630B0-0x0000000180363150
	}
	public event Action<string> OnBossRoomFailed {
		add; // 0x0000000180362E00-0x0000000180362EC0
		remove; // 0x0000000180362FF0-0x00000001803630B0
	}

	// Constructors
	public BossRoomBridge(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001803629D0-0x0000000180362AF0
	public void Unsubscribe(); // 0x0000000180362D20-0x0000000180362E00
	public void CreateAndJoinPhoton(Dictionary<string, object> properties = null); // 0x0000000180362750-0x00000001803629D0
	public void LeaveBoth(); // 0x0000000180362C70-0x0000000180362D20
	private void HandleWsRoomEntered(string roomId); // 0x0000000180362B90-0x0000000180362C70
	private void HandleWsEnterFailed(string reason); // 0x0000000180362AF0-0x0000000180362B90
}

