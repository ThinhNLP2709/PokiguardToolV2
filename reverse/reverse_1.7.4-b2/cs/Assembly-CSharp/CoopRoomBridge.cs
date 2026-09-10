/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class CoopRoomBridge // TypeDefIndex: 472
{
	// Fields
	private static CoopRoomBridge _instance; // 0x00

	// Properties
	public static CoopRoomBridge Instance { get; } // 0x0000000180391940-0x00000001803919D0 

	// Constructors
	public CoopRoomBridge(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void EnsureSubscribed(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void CreateAndJoinPhoton(string roomType, int maxPlayers, Dictionary<string, object> properties = null); // 0x0000000180391620-0x00000001803917A0
	public void JoinAndJoinPhoton(string roomId); // 0x00000001803917A0-0x0000000180391910
	public void LeaveBoth(); // 0x0000000180391910-0x0000000180391940
}

