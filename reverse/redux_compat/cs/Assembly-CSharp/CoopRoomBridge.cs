/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class CoopRoomBridge // TypeDefIndex: 404
{
	// Fields
	private static CoopRoomBridge _instance; // 0x00

	// Properties
	public static CoopRoomBridge Instance { get; } // 0x0000000180334960-0x00000001803349F0 

	// Constructors
	public CoopRoomBridge(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001802E76C0-0x00000001802E76D0
	public void CreateAndJoinPhoton(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x0000000180334640-0x00000001803347C0
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803347C0-0x0000000180334930
	public void LeaveBoth(); // 0x0000000180334930-0x0000000180334960
}

