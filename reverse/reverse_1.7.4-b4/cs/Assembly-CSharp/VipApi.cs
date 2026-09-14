/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class VipApi // TypeDefIndex: 1457
{
	// Nested types
	[Serializable]
	private class ActivateReq // TypeDefIndex: 1458
	{
		// Fields
		public int tier; // 0x10

		// Constructors
		public ActivateReq(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class EmptyReq // TypeDefIndex: 1459
	{
		// Constructors
		public EmptyReq(); // 0x000000018028A320-0x000000018028A330
	}

	// Methods
	public static void Info(int userId, Action<VipInfoData> ok, Action<string> err); // 0x00000001807ED700-0x00000001807ED9E0
	public static void Activate(int userId, int tier, Action<VipActivateData> ok, Action<string> err); // 0x00000001807ED9E0-0x00000001807EDCF0
	public static void Claim(int userId, Action<VipClaimData> ok, Action<string> err); // 0x00000001807EDCF0-0x00000001807EDFF0
}

