/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class RoomSummaryDTO // TypeDefIndex: 503
{
	// Fields
	public string roomId; // 0x10
	public string roomType; // 0x18
	public string ownerUsername; // 0x20
	public int memberCount; // 0x28
	public int maxPlayers; // 0x2C
	public bool inMatch; // 0x30
	public bool open; // 0x31
	public long createdAt; // 0x38
	public Dictionary<string, bool> members; // 0x40
	public Dictionary<string, object> properties; // 0x48

	// Constructors
	public RoomSummaryDTO(); // 0x000000018028A320-0x000000018028A330
}

