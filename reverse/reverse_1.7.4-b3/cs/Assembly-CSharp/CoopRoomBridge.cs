/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class CoopRoomBridge // TypeDefIndex: 526
{
	// Fields
	private static CoopRoomBridge _instance; // 0x00

	// Properties
	public static CoopRoomBridge Instance { get; } // 0x00000001803BFF20-0x00000001803BFFE0 

	// Constructors
	public CoopRoomBridge(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void EnsureSubscribed(); // 0x000000018028A320-0x000000018028A330
	public void CreateAndJoinPhoton(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x00000001803BFFE0-0x00000001803C01C0
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803C01C0-0x00000001803C0350
	public void LeaveBoth(); // 0x00000001803C0350-0x00000001803C0380
}

