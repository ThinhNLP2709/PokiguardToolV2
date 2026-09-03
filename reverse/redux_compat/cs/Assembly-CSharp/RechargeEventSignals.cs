/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RechargeEventSignals // TypeDefIndex: 739
{
	// Fields
	public const string WS_TYPE = "RECHARGE_EVENT_PROGRESS"; // Metadata: 0x0064C8BC
	[CompilerGenerated]
	private static Action OnProgress; // 0x00

	// Events
	public static event Action OnProgress {
		add; // 0x00000001803FD200-0x00000001803FD2C0
		remove; // 0x00000001803FD2C0-0x00000001803FD380
	}

	// Methods
	public static void RaiseProgress(); // 0x00000001803FD060-0x00000001803FD200
}

