/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class DestructionEntryFly // TypeDefIndex: 1650
{
	// Fields
	private const float POP_SEC = 0.06f; // Metadata: 0x0064D81C
	private const float POP_SCALE = 1.15f; // Metadata: 0x0064D820
	private const float END_SCALE = 0.25f; // Metadata: 0x0064D824
	private static readonly List<Transform> _buf; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 1651
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlyAllToPet_b__0(); // 0x00000001805D43A0-0x00000001805D4410
	}

	// Constructors
	static DestructionEntryFly(); // 0x00000001805C2430-0x00000001805C24C0

	// Methods
	public static int FlyAllToPet(GameObject panel, Transform pet, float durationSec); // 0x00000001805C23B0-0x00000001805C2430
	public static int FlyAllToPet(GameObject panel, Transform pet, float durationSec, float staggerSec); // 0x00000001805C1B40-0x00000001805C23B0
}

