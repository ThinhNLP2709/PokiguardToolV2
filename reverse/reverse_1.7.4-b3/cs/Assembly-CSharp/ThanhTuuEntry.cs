/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ThanhTuuEntry // TypeDefIndex: 1249
{
	// Fields
	public static Func<bool> Opener; // 0x00
	private static ManagerQuangTruong _hub; // 0x08
	private static bool _flagsHooked; // 0x10

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass8_0 // TypeDefIndex: 1250
	{
		// Fields
		public MethodInfo open; // 0x10
		public bool returnsBool; // 0x18

		// Constructors
		public __c__DisplayClass8_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ResolveOpener_b__0(); // 0x000000018032E750-0x000000018032E820
	}

	// Methods
	public static bool Open(); // 0x0000000180702FF0-0x0000000180703240
	public static void WireHub(ManagerQuangTruong hub); // 0x0000000180703240-0x0000000180703390
	private static void Wire(ManagerQuangTruong hub); // 0x0000000180703390-0x00000001807036C0
	private static void OnFlagsChanged(); // 0x00000001807036C0-0x00000001807037E0
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Warm(); // 0x00000001807037E0-0x0000000180703830
	private static Func<bool> ResolveOpener(); // 0x0000000180703830-0x0000000180703B90
	private static void Notice(string message); // 0x0000000180703B90-0x0000000180703D10
}

