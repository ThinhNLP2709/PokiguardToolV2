/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PvpRoomBridge // TypeDefIndex: 439
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
	public static PvpRoomBridge Instance { get; } // 0x000000018034AB50-0x000000018034ABE0 

	// Events
	public event Action OnPvpRoomReady {
		add; // 0x000000018034AAB0-0x000000018034AB50
		remove; // 0x000000018034ACA0-0x000000018034AD40
	}
	public event Action<string> OnPvpRoomFailed {
		add; // 0x000000018034A9F0-0x000000018034AAB0
		remove; // 0x000000018034ABE0-0x000000018034ACA0
	}

	// Constructors
	public PvpRoomBridge(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void EnsureSubscribed(); // 0x000000018034A410-0x000000018034A530
	public void Unsubscribe(); // 0x000000018034A910-0x000000018034A9F0
	public void CreateAndJoinPhoton(int maxPlayers = 4 /* Metadata: 0x0064C3D1 */, Dictionary<string, object> properties = null); // 0x000000018034A270-0x000000018034A410
	public void JoinAndJoinPhoton(string roomId); // 0x000000018034A790-0x000000018034A910
	public void CancelPending(); // 0x000000018034A1D0-0x000000018034A270
	private void HandleWsRoomEntered(string roomId); // 0x000000018034A690-0x000000018034A790
	private void HandleWsEnterFailed(string reason); // 0x000000018034A5E0-0x000000018034A690
	private void FailPending(string reason); // 0x000000018034A530-0x000000018034A5E0
}

