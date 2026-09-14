/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class WindowsQuitGuard // TypeDefIndex: 1456
{
	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Install(); // 0x00000001807ED3C0-0x00000001807ED460
	private static void EnsureProcessDies(); // 0x00000001807ED460-0x00000001807ED5F0
	private static extern IntPtr GetCurrentProcess(); // 0x00000001807ED5F0-0x00000001807ED660
	private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode); // 0x00000001807ED660-0x00000001807ED700
}

