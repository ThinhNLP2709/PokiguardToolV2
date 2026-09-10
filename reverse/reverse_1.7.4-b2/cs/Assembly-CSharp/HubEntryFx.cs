/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HubEntryFx // TypeDefIndex: 1558
{
	// Fields
	public const string FLAG_KEY = "ui.hub.fx"; // Metadata: 0x0068D443
	private const string TUNABLE_KEY = "hub.fx"; // Metadata: 0x0068D44D
	private const float DEF_ENTER_STAGGER = 0.3f; // Metadata: 0x0068D454
	private const float DEF_POP_FROM = 0.92f; // Metadata: 0x0068D458
	private const float DEF_POP_SEC = 0.18f; // Metadata: 0x0068D45C
	private const float DEF_PRESS_SCALE = 0.94f; // Metadata: 0x0068D460
	private const float DEF_PRESS_SEC = 0.12f; // Metadata: 0x0068D464
	public const float PULSE_MIN_GAP = 5f; // Metadata: 0x0068D468
	private static readonly HashSet<Button> _punchWired; // 0x00

	// Properties
	public static bool Enabled { get; } // 0x00000001805F7B30-0x00000001805F7B90 
	private static float EnterStagger { get; } // 0x00000001805F7B90-0x00000001805F7C20 
	private static float PopFrom { get; } // 0x00000001805F7C20-0x00000001805F7CB0 
	private static float PopSec { get; } // 0x00000001805F7CB0-0x00000001805F7D40 
	private static float PressScale { get; } // 0x00000001805F7D40-0x00000001805F7DD0 
	private static float PressSec { get; } // 0x00000001805F7DD0-0x00000001805F7E60 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 1559
	{
		// Fields
		public Transform t; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayEntry_b__0(); // 0x0000000180609C60-0x0000000180609CF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass22_0 // TypeDefIndex: 1560
	{
		// Fields
		public Transform t; // 0x10

		// Constructors
		public __c__DisplayClass22_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AttachPressPunch_b__0(); // 0x0000000180609CF0-0x0000000180609D40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 1561
	{
		// Fields
		public Transform t; // 0x10
		public GameObject go; // 0x18
		public Vector3 baseScale; // 0x20
		public float sec; // 0x2C
		public Action __9__1; // 0x30

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Punch_b__0(); // 0x0000000180609F30-0x000000018060A0B0
		internal void _Punch_b__1(); // 0x000000018060A0B0-0x000000018060A140
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1562
	{
		// Fields
		public GameObject node; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PulseBadge_b__0(); // 0x000000018060A140-0x000000018060A1E0
	}

	// Constructors
	static HubEntryFx(); // 0x00000001805F7AA0-0x00000001805F7B30

	// Methods
	public static void PlayEntry(Transform rightGrid, Transform eventStrip); // 0x00000001805F6CE0-0x00000001805F72F0
	private static void Collect(Transform parent, List<Transform> outList); // 0x00000001805F6B00-0x00000001805F6C10
	public static int AttachPressPunch(HubButtonRegistry registry, Transform root); // 0x00000001805F6770-0x00000001805F6A00
	private static bool IsUnder(Transform t, Transform root); // 0x00000001805F6C10-0x00000001805F6CE0
	public static void Punch(Transform t); // 0x00000001805F76B0-0x00000001805F7AA0
	public static void PulseBadge(GameObject node, Vector3 baseScale, ref float lastPulseAt, ref int tweenId); // 0x00000001805F72F0-0x00000001805F76B0
	public static void CancelPulse(GameObject node, Vector3 baseScale, ref int tweenId); // 0x00000001805F6A00-0x00000001805F6B00
}

