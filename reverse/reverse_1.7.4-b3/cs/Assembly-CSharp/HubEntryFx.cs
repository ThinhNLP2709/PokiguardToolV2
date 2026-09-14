/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HubEntryFx // TypeDefIndex: 1941
{
	// Fields
	private static readonly HashSet<Button> _punchWired; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x000000018093D190-0x000000018093D200 
	private static float EnterStagger { get; } // 0x000000018093D200-0x000000018093D2A0 
	private static float PopFrom { get; } // 0x000000018093D2A0-0x000000018093D350 
	private static float PopSec { get; } // 0x000000018093D350-0x000000018093D400 
	private static float PressScale { get; } // 0x000000018093D400-0x000000018093D4B0 
	private static float PressSec { get; } // 0x000000018093D4B0-0x000000018093D560 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1942
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayEntry_b__0(); // 0x000000018093F3C0-0x000000018093F520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1943
	{
		// Fields
		public Transform t; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachPressPunch_b__0(); // 0x000000018093F520-0x000000018093F580
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1944
	{
		// Fields
		public Transform t; // 0x10
		public GameObject go; // 0x18
		public Vector3 baseScale; // 0x20
		public float sec; // 0x2C
		public Action __9__1; // 0x30

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Punch_b__0(); // 0x000000018093F580-0x000000018093F7C0
		internal void _Punch_b__1(); // 0x000000018093F7C0-0x000000018093F920
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1945
	{
		// Fields
		public GameObject node; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseBadge_b__0(); // 0x000000018093F920-0x000000018093FA90
	}

	// Constructors
	static HubEntryFx(); // 0x000000018093F2E0-0x000000018093F3C0

	// Methods
	public static void PlayEntry(Transform rightGrid, Transform eventStrip); // 0x000000018093D560-0x000000018093DD60
	private static void Collect(Transform parent, List<Transform> outList); // 0x000000018093DD60-0x000000018093E030
	public static int AttachPressPunch(HubButtonRegistry registry, Transform root); // 0x000000018093E030-0x000000018093E390
	private static bool IsUnder(Transform t, Transform root); // 0x000000018093E390-0x000000018093E570
	public static void Punch(Transform t); // 0x000000018093E570-0x000000018093EAC0
	public static void PulseBadge(GameObject node, Vector3 baseScale, ref float lastPulseAt, ref int tweenId); // 0x000000018093EAC0-0x000000018093EEA0
	public static void CancelPulse(GameObject node, Vector3 baseScale, ref int tweenId); // 0x000000018093EEA0-0x000000018093F2E0
}

