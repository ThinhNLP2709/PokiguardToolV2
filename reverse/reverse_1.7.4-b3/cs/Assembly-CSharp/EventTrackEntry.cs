/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EventTrackEntry // TypeDefIndex: 612
{
	// Fields
	public static Func<string, bool> Opener; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass6_0 // TypeDefIndex: 613
	{
		// Fields
		public MethodInfo open; // 0x10
		public bool returnsBool; // 0x18

		// Constructors
		public __c__DisplayClass6_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ResolveOpener_b__0(string k); // 0x0000000180435240-0x0000000180435390
	}

	// Methods
	public static bool Open(string key); // 0x00000001804349F0-0x0000000180434B90
	public static void WireHub(MonoBehaviour hub); // 0x0000000180434B90-0x0000000180434C70
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Warm(); // 0x0000000180434C70-0x0000000180434CC0
	private static Func<string, bool> ResolveOpener(); // 0x0000000180434CC0-0x00000001804350C0
	private static void Notice(string message); // 0x00000001804350C0-0x0000000180435240
}

