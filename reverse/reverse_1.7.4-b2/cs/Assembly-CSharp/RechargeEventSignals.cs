/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RechargeEventSignals // TypeDefIndex: 929
{
	// Fields
	public const string WS_TYPE = "RECHARGE_EVENT_PROGRESS"; // Metadata: 0x0068BF7C
	[CompilerGenerated]
	private static Action OnProgress; // 0x00

	// Events
	public static event Action OnProgress {
		add; // 0x00000001804DDC90-0x00000001804DDD50
		remove; // 0x00000001804DDD50-0x00000001804DDE10
	}

	// Methods
	public static void RaiseProgress(); // 0x00000001804DDAF0-0x00000001804DDC90
}

