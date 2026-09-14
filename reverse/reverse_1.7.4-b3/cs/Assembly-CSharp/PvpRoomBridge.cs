/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PvpRoomBridge // TypeDefIndex: 561
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
	public static PvpRoomBridge Instance { get; } // 0x00000001803EAF50-0x00000001803EB010 

	// Events
	public event Action<string> OnPvpRoomFailed {
		add; // 0x00000001803EB010-0x00000001803EB130
		remove; // 0x00000001803EB130-0x00000001803EB250
	}

	// Constructors
	public PvpRoomBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x00000001803EB250-0x00000001803EB390
	public void CreateAndJoinPhoton(int maxPlayers = 4 /* Metadata: 0x005EE333 */, Dictionary<string, object> properties = null); // 0x00000001803EB390-0x00000001803EB590
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803EB590-0x00000001803EB730
	public void CancelPending(); // 0x00000001803EB730-0x00000001803EB820
	private void HandleWsRoomEntered(string roomId); // 0x00000001803EB820-0x00000001803EB970
	private void HandleWsEnterFailed(string reason); // 0x00000001803EB970-0x00000001803EBA70
}

