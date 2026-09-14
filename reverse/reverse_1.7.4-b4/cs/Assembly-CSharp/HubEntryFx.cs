/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HubEntryFx // TypeDefIndex: 1943
{
	// Fields
	private static readonly HashSet<Button> _punchWired; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x0000000180940790-0x0000000180940800 
	private static float EnterStagger { get; } // 0x0000000180940800-0x00000001809408A0 
	private static float PopFrom { get; } // 0x00000001809408A0-0x0000000180940950 
	private static float PopSec { get; } // 0x0000000180940950-0x0000000180940A00 
	private static float PressScale { get; } // 0x0000000180940A00-0x0000000180940AB0 
	private static float PressSec { get; } // 0x0000000180940AB0-0x0000000180940B60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1944
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayEntry_b__0(); // 0x00000001809429C0-0x0000000180942B20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1945
	{
		// Fields
		public Transform t; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AttachPressPunch_b__0(); // 0x0000000180942B20-0x0000000180942B80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1946
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
		internal void _Punch_b__0(); // 0x0000000180942B80-0x0000000180942DC0
		internal void _Punch_b__1(); // 0x0000000180942DC0-0x0000000180942F20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1947
	{
		// Fields
		public GameObject node; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PulseBadge_b__0(); // 0x0000000180942F20-0x0000000180943090
	}

	// Constructors
	static HubEntryFx(); // 0x00000001809428E0-0x00000001809429C0

	// Methods
	public static void PlayEntry(Transform rightGrid, Transform eventStrip); // 0x0000000180940B60-0x0000000180941360
	private static void Collect(Transform parent, List<Transform> outList); // 0x0000000180941360-0x0000000180941630
	public static int AttachPressPunch(HubButtonRegistry registry, Transform root); // 0x0000000180941630-0x0000000180941990
	private static bool IsUnder(Transform t, Transform root); // 0x0000000180941990-0x0000000180941B70
	public static void Punch(Transform t); // 0x0000000180941B70-0x00000001809420C0
	public static void PulseBadge(GameObject node, Vector3 baseScale, ref float lastPulseAt, ref int tweenId); // 0x00000001809420C0-0x00000001809424A0
	public static void CancelPulse(GameObject node, Vector3 baseScale, ref int tweenId); // 0x00000001809424A0-0x00000001809428E0
}

