/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class WindowsQuitGuard // TypeDefIndex: 874
{
	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Install(); // 0x0000000180450CD0-0x0000000180450D60
	private static void EnsureProcessDies(); // 0x0000000180450B20-0x0000000180450C60
	private static extern IntPtr GetCurrentProcess(); // 0x0000000180450C60-0x0000000180450CD0
	private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode); // 0x0000000180450D60-0x0000000180450E00
}

