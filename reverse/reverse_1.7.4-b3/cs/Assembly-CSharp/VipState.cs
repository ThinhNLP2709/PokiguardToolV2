/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class VipState // TypeDefIndex: 1491
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
	public static int Level { get; } // 0x0000000180818770-0x00000001808187C0 
	public static bool CanClaim { get; } // 0x00000001808187C0-0x0000000180818810 
	public static VipInfoData Info { get; } // 0x0000000180818810-0x0000000180818860 
	public static int SelfUserId { get; } // 0x0000000180818AA0-0x0000000180818AF0 

	// Events
	public static event Action OnChanged {
		add; // 0x0000000180818860-0x0000000180818980
		remove; // 0x0000000180818980-0x0000000180818AA0
	}

	// Methods
	public static void ApplyUser(UserDTO u); // 0x0000000180818AF0-0x0000000180818B90
	public static void ApplyInfo(VipInfoData info); // 0x0000000180818B90-0x0000000180818D10
	public static void ApplyLevel(int level); // 0x0000000180818D10-0x0000000180818D90
	private static void Set(int level, bool canClaim, long nextResetAtMs); // 0x0000000180818D90-0x0000000180818EE0
	private static void SyncOwner(); // 0x0000000180818EE0-0x0000000180818FD0
	private static long NowMs(); // 0x0000000180818FD0-0x0000000180819080
}

