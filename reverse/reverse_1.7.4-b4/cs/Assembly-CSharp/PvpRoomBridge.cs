/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PvpRoomBridge // TypeDefIndex: 562
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
	public static PvpRoomBridge Instance { get; } // 0x00000001803EBC90-0x00000001803EBD50 

	// Events
	public event Action<string> OnPvpRoomFailed {
		add; // 0x00000001803EBD50-0x00000001803EBE70
		remove; // 0x00000001803EBE70-0x00000001803EBF90
	}

	// Constructors
	public PvpRoomBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x00000001803EBF90-0x00000001803EC0D0
	public void CreateAndJoinPhoton(int maxPlayers = 4 /* Metadata: 0x005EF704 */, Dictionary<string, object> properties = null); // 0x00000001803EC0D0-0x00000001803EC2D0
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803EC2D0-0x00000001803EC470
	public void CancelPending(); // 0x00000001803EC470-0x00000001803EC560
	private void HandleWsRoomEntered(string roomId); // 0x00000001803EC560-0x00000001803EC6B0
	private void HandleWsEnterFailed(string reason); // 0x00000001803EC6B0-0x00000001803EC7B0
}

