/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class WindowsQuitGuard // TypeDefIndex: 1075
{
	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Install(); // 0x0000000180528390-0x0000000180528420
	private static void EnsureProcessDies(); // 0x00000001805281E0-0x0000000180528320
	private static extern IntPtr GetCurrentProcess(); // 0x0000000180528320-0x0000000180528390
	private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode); // 0x0000000180528420-0x0000000180528510
}

