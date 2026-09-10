/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PvpRoomBridge // TypeDefIndex: 508
{
	// Fields
	private static PvpRoomBridge _instance; // 0x00
	private string _pendingRoomId; // 0x10
	private bool _subscribed; // 0x18
	[CompilerGenerated]
	private Action OnPvpRoomReady; // 0x20
	[CompilerGenerated]
	private Action<string> OnPvpRoomFailed; // 0x28

	// Properties
	public static PvpRoomBridge Instance { get; } // 0x00000001803A97A0-0x00000001803A9830 

	// Events
	public event Action OnPvpRoomReady {
		add; // 0x00000001803A9700-0x00000001803A97A0
		remove; // 0x00000001803A98F0-0x00000001803A9990
	}
	public event Action<string> OnPvpRoomFailed {
		add; // 0x00000001803A9640-0x00000001803A9700
		remove; // 0x00000001803A9830-0x00000001803A98F0
	}

	// Constructors
	public PvpRoomBridge(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001803A9060-0x00000001803A9180
	public void Unsubscribe(); // 0x00000001803A9560-0x00000001803A9640
	public void CreateAndJoinPhoton(int maxPlayers = 4 /* Metadata: 0x0068B44A */, Dictionary<string, object> properties = null); // 0x00000001803A8EC0-0x00000001803A9060
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803A93E0-0x00000001803A9560
	public void CancelPending(); // 0x00000001803A8E20-0x00000001803A8EC0
	private void HandleWsRoomEntered(string roomId); // 0x00000001803A92E0-0x00000001803A93E0
	private void HandleWsEnterFailed(string reason); // 0x00000001803A9230-0x00000001803A92E0
	private void FailPending(string reason); // 0x00000001803A9180-0x00000001803A9230
}

