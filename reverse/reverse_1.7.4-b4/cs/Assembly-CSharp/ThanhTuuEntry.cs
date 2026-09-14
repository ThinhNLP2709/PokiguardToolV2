/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ThanhTuuEntry // TypeDefIndex: 1251
{
	// Fields
	public static Func<bool> Opener; // 0x00
	private static ManagerQuangTruong _hub; // 0x08
	private static bool _flagsHooked; // 0x10

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass8_0 // TypeDefIndex: 1252
	{
		// Fields
		public MethodInfo open; // 0x10
		public bool returnsBool; // 0x18

		// Constructors
		public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ResolveOpener_b__0(); // 0x000000018032E870-0x000000018032E940
	}

	// Methods
	public static bool Open(); // 0x0000000180704DA0-0x0000000180704FF0
	public static void WireHub(ManagerQuangTruong hub); // 0x0000000180704FF0-0x0000000180705140
	private static void Wire(ManagerQuangTruong hub); // 0x0000000180705140-0x0000000180705470
	private static void OnFlagsChanged(); // 0x0000000180705470-0x0000000180705590
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Warm(); // 0x0000000180705590-0x00000001807055E0
	private static Func<bool> ResolveOpener(); // 0x00000001807055E0-0x0000000180705940
	private static void Notice(string message); // 0x0000000180705940-0x0000000180705AC0
}

