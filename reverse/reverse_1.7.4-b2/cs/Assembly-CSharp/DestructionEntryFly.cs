/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class DestructionEntryFly // TypeDefIndex: 1921
{
	// Fields
	private const float POP_SEC = 0.06f; // Metadata: 0x0068DC19
	private const float POP_SCALE = 1.15f; // Metadata: 0x0068DC1D
	private const float END_SCALE = 0.25f; // Metadata: 0x0068DC21
	private static readonly List<Transform> _buf; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 1922
	{
		// Fields
		public bool reuse; // 0x10
		public Transform panelT; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass5_1 // TypeDefIndex: 1923
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 s; // 0x18
		public __c__DisplayClass5_0 CS___8__locals1; // 0x28

		// Constructors
		public __c__DisplayClass5_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlyAllToPet_b__0(); // 0x00000001806FA3D0-0x00000001806FA500
	}

	// Constructors
	static DestructionEntryFly(); // 0x00000001806E96E0-0x00000001806E9770

	// Methods
	public static int FlyAllToPet(GameObject panel, Transform pet, float durationSec); // 0x00000001806E9660-0x00000001806E96E0
	public static int FlyAllToPet(GameObject panel, Transform pet, float durationSec, float staggerSec); // 0x00000001806E8D70-0x00000001806E9660
}

