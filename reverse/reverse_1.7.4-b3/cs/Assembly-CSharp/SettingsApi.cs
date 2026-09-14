/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class SettingsApi // TypeDefIndex: 1203
{
	// Nested types
	[Serializable]
	public class RenameInfoData // TypeDefIndex: 1204
	{
		// Fields
		public string currentName; // 0x10
		public int costGold; // 0x18
		public int gold; // 0x1C
		public int cooldownRemainingSec; // 0x20
		public string rules; // 0x28

		// Constructors
		public RenameInfoData(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class RenameRes // TypeDefIndex: 1205
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public string newName; // 0x20
		public int remainingGold; // 0x28
		public int costGold; // 0x2C
		public int retryAfterSec; // 0x30

		// Constructors
		public RenameRes(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class RenameReq // TypeDefIndex: 1206
	{
		// Fields
		public string newName; // 0x10

		// Constructors
		public RenameReq(); // 0x000000018028A320-0x000000018028A330
	}

	// Methods
	public static Coroutine GetRenameInfo(int userId, Action<RenameInfoData> onOk, Action<string> onErr); // 0x00000001806D1B90-0x00000001806D1E20
	public static Coroutine Rename(int userId, string newName, Action<RenameRes> onOk, Action<string> onErr); // 0x00000001806D1E20-0x00000001806D2130
}

