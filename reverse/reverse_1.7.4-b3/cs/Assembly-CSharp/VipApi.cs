/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class VipApi // TypeDefIndex: 1455
{
	// Nested types
	[Serializable]
	private class ActivateReq // TypeDefIndex: 1456
	{
		// Fields
		public int tier; // 0x10

		// Constructors
		public ActivateReq(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class EmptyReq // TypeDefIndex: 1457
	{
		// Constructors
		public EmptyReq(); // 0x000000018028A320-0x000000018028A330
	}

	// Methods
	public static void Info(int userId, Action<VipInfoData> ok, Action<string> err); // 0x00000001807EB690-0x00000001807EB940
	public static void Activate(int userId, int tier, Action<VipActivateData> ok, Action<string> err); // 0x00000001807EB940-0x00000001807EBC20
	public static void Claim(int userId, Action<VipClaimData> ok, Action<string> err); // 0x00000001807EBC20-0x00000001807EBF00
}

