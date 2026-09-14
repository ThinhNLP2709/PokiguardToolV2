/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class VipState // TypeDefIndex: 1493
{
	// Fields
	private static VipInfoData _info; // 0x00
	private static int _level; // 0x08
	private static bool _canClaim; // 0x0C
	private static long _nextResetAtMs; // 0x10
	private static int _ownerId; // 0x18
	[CompilerGenerated]
	private static Action OnChanged; // 0x20

	// Properties
	public static int Level { get; } // 0x000000018081A860-0x000000018081A8B0 
	public static bool CanClaim { get; } // 0x000000018081A8B0-0x000000018081A900 
	public static VipInfoData Info { get; } // 0x000000018081A900-0x000000018081A950 
	public static int SelfUserId { get; } // 0x000000018081AB90-0x000000018081ABE0 

	// Events
	public static event Action OnChanged {
		add; // 0x000000018081A950-0x000000018081AA70
		remove; // 0x000000018081AA70-0x000000018081AB90
	}

	// Methods
	public static void ApplyUser(UserDTO u); // 0x000000018081ABE0-0x000000018081AC80
	public static void ApplyInfo(VipInfoData info); // 0x000000018081AC80-0x000000018081AE00
	public static void ApplyLevel(int level); // 0x000000018081AE00-0x000000018081AE80
	private static void Set(int level, bool canClaim, long nextResetAtMs); // 0x000000018081AE80-0x000000018081AFD0
	private static void SyncOwner(); // 0x000000018081AFD0-0x000000018081B0C0
	private static long NowMs(); // 0x000000018081B0C0-0x000000018081B170
}

